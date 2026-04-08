"""
Patches Attributes.cs and BaseTest.cs to add TargetDevice attribute support.
This allows specifying a device UDID per test class so tests can target
specific emulators/devices when multiple are connected.

Usage:
    python add_target_device_support.py <shared_project_dir>

Example:
    python add_target_device_support.py UITests.Shared
    python add_target_device_support.py /full/path/to/UITests.Shared
"""

import os
import re
import sys


def find_file(directory, filename):
    """Find a file by name in the given directory."""
    for root, _, files in os.walk(directory):
        if filename in files:
            return os.path.join(root, filename)
    return None


def patch_attributes(filepath):
    """Add TargetDevice attribute class to Attributes.cs if not present."""
    with open(filepath, "r", encoding="utf-8") as f:
        content = f.read()

    if "class TargetDevice" in content:
        print(f"  [SKIP] TargetDevice attribute already exists in {filepath}")
        return False

    # Detect the namespace used in this file
    ns_match = re.search(r"namespace\s+([\w.]+)", content)
    if not ns_match:
        print(f"  [ERROR] Could not find namespace in {filepath}")
        return False

    target_device_block = '''
    /// <summary>
    /// Specifies the target device UDID for this test class.
    /// Applied at class level since the Appium driver session is per fixture.
    /// Example: [TargetDevice("emulator-5554")]
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class TargetDevice : Attribute
    {
        public string Udid { get; set; }
        public TargetDevice(string udid)
        {
            Udid = udid;
        }
    }'''

    # Insert before the last closing brace of the namespace
    last_brace = content.rfind("}")
    if last_brace == -1:
        print(f"  [ERROR] Could not find closing brace in {filepath}")
        return False

    content = content[:last_brace] + target_device_block + "\n" + content[last_brace:]

    with open(filepath, "w", encoding="utf-8") as f:
        f.write(content)

    namespace = ns_match.group(1)
    print(f"  [OK] Added TargetDevice attribute to {filepath} (namespace: {namespace})")
    return True


def get_attributes_namespace(filepath):
    """Extract the namespace from Attributes.cs."""
    with open(filepath, "r", encoding="utf-8") as f:
        content = f.read()
    ns_match = re.search(r"namespace\s+([\w.]+)", content)
    return ns_match.group(1) if ns_match else None


def patch_basetest(filepath, attributes_namespace):
    """Add TargetDevice UDID reading logic to BaseTest.cs."""
    with open(filepath, "r", encoding="utf-8") as f:
        content = f.read()

    modified = False

    # 1. Add 'using <namespace>;' if not present
    using_stmt = f"using {attributes_namespace};"
    if using_stmt not in content:
        # Also ensure 'using System.Reflection;' is present (needed for GetCustomAttribute)
        if "using System.Reflection;" not in content:
            # Add both after the last 'using' line
            last_using = max(content.rfind("\nusing "), 0)
            eol = content.index("\n", last_using + 1)
            content = content[:eol + 1] + "using System.Reflection;\n" + using_stmt + "\n" + content[eol + 1:]
        else:
            # Add after 'using System.Reflection;'
            insert_after = "using System.Reflection;"
            idx = content.index(insert_after) + len(insert_after)
            content = content[:idx] + "\n" + using_stmt + content[idx:]
        print(f"  [OK] Added '{using_stmt}' to {filepath}")
        modified = True
    else:
        print(f"  [SKIP] '{using_stmt}' already in {filepath}")

    # 2. Add Android UDID block if not present
    if "GetType().GetCustomAttribute<TargetDevice>()" in content:
        print(f"  [SKIP] TargetDevice UDID logic already in {filepath}")
    else:
        # Find the line: config.SetProperty(AppMain1, AppMain12); (or similar pattern)
        # Insert the Android block after it
        android_block = '''
        if (_testDevice == TestDevice.Android)
        {
            // Read UDID from TargetDevice attribute on the test class
            var targetDeviceAttr = GetType().GetCustomAttribute<TargetDevice>();
            if (targetDeviceAttr != null)
            {
                config.SetProperty("Udid", targetDeviceAttr.Udid);
            }
            // Fallback: use ANDROID_UDID environment variable
            else if (!string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("ANDROID_UDID")))
            {
                config.SetProperty("Udid", Environment.GetEnvironmentVariable("ANDROID_UDID"));
            }
        }
'''
        # Strategy: insert after config.SetProperty(AppMain...) line
        # Look for the pattern: config.SetProperty(AppMain..., ...);
        appmain_pattern = re.compile(
            r"(config\.SetProperty\(AppMain\w*,\s*AppMain\w*\);[^\n]*\n)",
            re.MULTILINE
        )
        match = appmain_pattern.search(content)

        if match:
            insert_pos = match.end()
            content = content[:insert_pos] + android_block + content[insert_pos:]
            print(f"  [OK] Added Android UDID block after AppMain config")
            modified = True
        else:
            # Fallback: insert after config.SetProperty(appIdentifierKey, appIdentifier);
            fallback_pattern = re.compile(
                r"(config\.SetProperty\(\w*[Aa]pp\w*,\s*\w*\);[^\n]*\n)",
                re.MULTILINE
            )
            matches = list(fallback_pattern.finditer(content))
            if matches:
                insert_pos = matches[-1].end()
                content = content[:insert_pos] + android_block + content[insert_pos:]
                print(f"  [OK] Added Android UDID block (fallback position)")
                modified = True
            else:
                print(f"  [ERROR] Could not find insertion point in {filepath}")
                print(f"         Manually add the Android UDID block after config setup")

    if modified:
        with open(filepath, "w", encoding="utf-8") as f:
            f.write(content)
        print(f"  [OK] Saved {filepath}")
    return modified


def main():
    if len(sys.argv) < 2:
        # Default to UITests.Shared relative to script location
        script_dir = os.path.dirname(os.path.abspath(__file__))
        shared_dir = os.path.join(script_dir, "UITests.Shared")
    else:
        shared_dir = os.path.abspath(sys.argv[1])

    if not os.path.isdir(shared_dir):
        print(f"Error: Directory not found: {shared_dir}")
        sys.exit(1)

    print(f"Target directory: {shared_dir}\n")

    # Find required files
    attributes_file = find_file(shared_dir, "Attributes.cs")
    basetest_file = find_file(shared_dir, "BaseTest.cs")

    if not attributes_file:
        print("Error: Attributes.cs not found")
        sys.exit(1)
    if not basetest_file:
        print("Error: BaseTest.cs not found")
        sys.exit(1)

    print(f"Found: {attributes_file}")
    print(f"Found: {basetest_file}\n")

    # Step 1: Patch Attributes.cs
    print("[1/2] Patching Attributes.cs ...")
    patch_attributes(attributes_file)

    # Step 2: Get the namespace from Attributes.cs
    ns = get_attributes_namespace(attributes_file)
    if not ns:
        print("Error: Could not determine namespace from Attributes.cs")
        sys.exit(1)

    # Step 3: Patch BaseTest.cs
    print(f"\n[2/2] Patching BaseTest.cs (attributes namespace: {ns}) ...")
    patch_basetest(basetest_file, ns)

    print("\nDone! To use it, add [TargetDevice(\"emulator-5554\")] to your test classes.")
    print("Example:")
    print('  [TargetDevice("emulator-5554")]')
    print("  internal class AccordionDevice1 : BaseTest { ... }")
    print('  [TargetDevice("emulator-5556")]')
    print("  internal class AccordionDevice2 : BaseTest { ... }")


if __name__ == "__main__":
    main()
