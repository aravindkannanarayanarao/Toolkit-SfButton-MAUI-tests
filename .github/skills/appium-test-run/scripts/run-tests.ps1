[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [string]$SamplePath,

    [Parameter(Mandatory = $true)]
    [string]$SampleName,

    [string]$ControlName = 'SfAccordion',

    [Parameter(Mandatory = $true)]
    [ValidateSet('Android', 'iOS', 'Windows', 'macOS')]
    [string]$Platform,

    [string]$Filter,

    [string]$Verbosity = 'normal'
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

function Write-Status {
    param([string]$Message, [string]$Type = 'INFO')
    $symbol = switch ($Type) {
        'OK'    { '✅' }
        'WARN'  { '⚠️' }
        'ERR'   { '❌' }
        'WAIT'  { '⏳' }
        default { 'ℹ️' }
    }
    Write-Host "$symbol $Message"
}

function Write-Json {
    param([Parameter(Mandatory = $true)]$Object)
    $Object | ConvertTo-Json -Depth 20
}

# ─── Map platform to project folder ───────────────────────────────────────────
$platformMap = @{
    'Android' = 'UITests.Android'
    'iOS'     = 'UITests.iOS'
    'Windows' = 'UITests.Windows'
    'macOS'   = 'UITests.macOS'
}

$testProjectFolder = $platformMap[$Platform]
$testProjectDir = Join-Path $SamplePath $testProjectFolder
$csprojPath = Join-Path $testProjectDir "$testProjectFolder.csproj"

# ─── Validate inputs ──────────────────────────────────────────────────────────
if (-not (Test-Path $SamplePath)) {
    Write-Status "Sample path not found: $SamplePath" -Type ERR
    exit 1
}

if (-not (Test-Path $csprojPath)) {
    Write-Status "Test project not found: $csprojPath" -Type ERR
    Write-Host "  Expected at: $csprojPath"
    Write-Host "  Available directories:"
    Get-ChildItem -Path $SamplePath -Directory | ForEach-Object { Write-Host "    $($_.Name)" }
    exit 1
}

Write-Status "Test project found: $csprojPath" -Type OK

# ─── Build the test command ────────────────────────────────────────────────────
$trxFileName = "${ControlName}_${SampleName}_TestResult.xml"
$dotnetTestCmd = "dotnet test `"$csprojPath`" --logger `"trx;LogFileName=$trxFileName`" --verbosity $Verbosity"

if (-not [string]::IsNullOrWhiteSpace($Filter)) {
    $dotnetTestCmd += " --filter `"$Filter`""
    Write-Status "Test filter applied: $Filter" -Type INFO
}

# ─── Run tests ─────────────────────────────────────────────────────────────────
Write-Status "Running tests on $Platform for $SampleName..." -Type WAIT
Write-Host "  Command: $dotnetTestCmd"
Write-Host ""

$testExitCode = 0
try {
    Invoke-Expression $dotnetTestCmd
    $testExitCode = $LASTEXITCODE
} catch {
    Write-Status "Test execution threw an exception: $_" -Type WARN
    $testExitCode = 1
}

# ─── Locate TRX results ───────────────────────────────────────────────────────
$testResultsDir = Join-Path $testProjectDir 'TestResults'
$trxPath = $null

if (Test-Path $testResultsDir) {
    # Find the most recent TRX file matching our naming pattern
    $trxFiles = Get-ChildItem -Path $testResultsDir -Filter '*.xml' -Recurse -File |
                Sort-Object LastWriteTime -Descending

    if ($trxFiles.Count -gt 0) {
        $trxPath = $trxFiles[0].FullName
        Write-Status "TRX result found: $trxPath" -Type OK
    } else {
        Write-Status "No TRX files found in $testResultsDir" -Type WARN
    }
} else {
    Write-Status "TestResults directory not found at $testResultsDir" -Type WARN
}

# ─── Parse TRX results ────────────────────────────────────────────────────────
$testResults = @()
$totalCount = 0
$passedCount = 0
$failedCount = 0
$skippedCount = 0

if ($trxPath -and (Test-Path $trxPath)) {
    try {
        [xml]$trxXml = Get-Content $trxPath
        $ns = @{ t = 'http://microsoft.com/schemas/VisualStudio/TeamTest/2010' }

        # Get summary counters
        $counters = $trxXml.TestRun.ResultSummary.Counters
        if ($counters) {
            $totalCount = [int]$counters.total
            $passedCount = [int]$counters.passed
            $failedCount = [int]$counters.failed
            $skippedCount = [int]($counters.notExecuted ?? 0)
        }

        # Get individual test results
        $unitResults = $trxXml.TestRun.Results.UnitTestResult
        if ($unitResults) {
            foreach ($result in $unitResults) {
                $entry = @{
                    testName = $result.testName
                    outcome  = $result.outcome
                    duration = $result.duration
                }

                if ($result.outcome -eq 'Failed' -and $result.Output.ErrorInfo) {
                    $entry['error'] = $result.Output.ErrorInfo.Message
                    $entry['stackTrace'] = $result.Output.ErrorInfo.StackTrace
                }

                $testResults += $entry
            }
        }

        Write-Status "TRX parsed: $totalCount total, $passedCount passed, $failedCount failed, $skippedCount skipped" -Type OK
    } catch {
        Write-Status "Failed to parse TRX file: $_" -Type WARN
    }
}

# ─── Locate screenshot artifacts ───────────────────────────────────────────────
$imagesDir = Join-Path $testProjectDir 'Images'
$snapshotsDir = Join-Path $imagesDir 'snapshots'
$snapshotsOutputDir = Join-Path $imagesDir 'snapshots-output'
$snapshotsDiffDir = Join-Path $imagesDir 'snapshots-diff'

$hasSnapshots = Test-Path $snapshotsDir
$hasOutput = Test-Path $snapshotsOutputDir
$hasDiff = Test-Path $snapshotsDiffDir

$snapshotCount = 0
$outputCount = 0
$diffCount = 0

if ($hasSnapshots) { $snapshotCount = (Get-ChildItem -Path $snapshotsDir -File -ErrorAction SilentlyContinue).Count }
if ($hasOutput) { $outputCount = (Get-ChildItem -Path $snapshotsOutputDir -File -ErrorAction SilentlyContinue).Count }
if ($hasDiff) { $diffCount = (Get-ChildItem -Path $snapshotsDiffDir -File -ErrorAction SilentlyContinue).Count }

# ─── Locate report directory ──────────────────────────────────────────────────
$reportDir = Join-Path $testProjectDir 'report'
$hasReport = Test-Path $reportDir

# ─── Output summary ───────────────────────────────────────────────────────────
$summary = @{
    status         = if ($testExitCode -eq 0) { 'completed' } else { 'completed_with_failures' }
    exitCode       = $testExitCode
    platform       = $Platform
    sampleName     = $SampleName
    controlName    = $ControlName
    csprojPath     = $csprojPath
    trxPath        = $trxPath
    total          = $totalCount
    passed         = $passedCount
    failed         = $failedCount
    skipped        = $skippedCount
    results        = $testResults
    artifacts      = @{
        snapshotsDir       = if ($hasSnapshots) { $snapshotsDir } else { $null }
        snapshotsOutputDir = if ($hasOutput) { $snapshotsOutputDir } else { $null }
        snapshotsDiffDir   = if ($hasDiff) { $snapshotsDiffDir } else { $null }
        reportDir          = if ($hasReport) { $reportDir } else { $null }
        snapshotCount      = $snapshotCount
        outputCount        = $outputCount
        diffCount          = $diffCount
    }
}

Write-Host ""
Write-Host "═══════════════════════════════════════════════════════════"
Write-Host " Test Run Summary — $Platform / $SampleName"
Write-Host "═══════════════════════════════════════════════════════════"
Write-Host " Total: $totalCount | Passed: $passedCount | Failed: $failedCount | Skipped: $skippedCount"
Write-Host " TRX: $trxPath"
Write-Host " Screenshots: $snapshotCount baseline, $outputCount output, $diffCount diff"
Write-Host "═══════════════════════════════════════════════════════════"
Write-Host ""

Write-Json $summary
