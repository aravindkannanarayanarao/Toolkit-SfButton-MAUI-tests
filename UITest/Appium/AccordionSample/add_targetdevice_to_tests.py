"""
Scans all .cs test files in a directory, finds every [Test] method,
and adds [TargetDevice("emulator-XXXX")] to each one — split 50/50
between two devices.

Usage:
    python add_targetdevice_to_tests.py <shared_dir> --device1 <udid1> --device2 <udid2>

Examples:
    python add_targetdevice_to_tests.py UITests.Shared --device1 emulator-5554 --device2 emulator-5556
    python add_targetdevice_to_tests.py UITests.Shared   # uses defaults: emulator-5554 and emulator-5556
"""

import os
import re
import sys
import argparse


def find_cs_files(directory):
    """Find all .cs files in the directory."""
    cs_files = []
    for root, _, files in os.walk(directory):
        for f in files:
            if f.endswith(".cs"):
                cs_files.append(os.path.join(root, f))
    return sorted(cs_files)


def find_test_methods(content):
    """
    Find all [Test] method locations in file content.
    Returns list of (line_index, method_name) tuples.
    """
    lines = content.split("\n")
    tests = []
    for i, line in enumerate(lines):
        stripped = line.strip()
        # Match [Test] attribute (possibly with other attributes on same line)
        if stripped == "[Test]" or stripped.startswith("[Test]") or stripped.startswith("[Test,"):
            # Find the method signature after this attribute block
            for j in range(i + 1, min(i + 10, len(lines))):
                method_match = re.search(r"public\s+(?:void|async\s+Task)\s+(\w+)\s*\(", lines[j])
                if method_match:
                    tests.append((i, method_match.group(1)))
                    break
    return tests


def has_target_device_attr(lines, test_line_idx):
    """Check if a [TargetDevice] attribute already exists near this [Test] line."""
    # Look at the few lines before and after [Test] but before the method
    start = max(0, test_line_idx - 3)
    end = min(len(lines), test_line_idx + 5)
    for i in range(start, end):
        if "TargetDevice" in lines[i]:
            return True
    return False


def get_indent(line):
    """Get the whitespace indentation of a line."""
    return line[: len(line) - len(line.lstrip())]


def add_using_if_needed(content, namespace):
    """Add 'using <namespace>;' if not already present."""
    using_stmt = f"using {namespace};"
    if using_stmt in content:
        return content, False
    # Add after the last 'using' statement
    lines = content.split("\n")
    last_using_idx = -1
    for i, line in enumerate(lines):
        if line.strip().startswith("using ") and line.strip().endswith(";"):
            last_using_idx = i
    if last_using_idx >= 0:
        lines.insert(last_using_idx + 1, using_stmt)
        return "\n".join(lines), True
    return content, False


def process_file(filepath, device1, device2, counter):
    """
    Process a single .cs file:
    - Find all [Test] methods
    - Add [TargetDevice] to each, alternating devices 50/50
    - Returns (modified, test_count, counter)
    """
    with open(filepath, "r", encoding="utf-8") as f:
        content = f.read()

    # Skip files with no [Test] methods
    if "[Test]" not in content:
        return False, 0, counter

    tests = find_test_methods(content)
    if not tests:
        return False, 0, counter

    lines = content.split("\n")
    modified = False
    insertions = []  # (line_index, device_udid)

    for test_line_idx, method_name in tests:
        if has_target_device_attr(lines, test_line_idx):
            # Already has TargetDevice, count it but skip
            counter += 1
            continue

        # Alternate devices based on counter
        device = device1 if counter % 2 == 0 else device2
        insertions.append((test_line_idx, device, method_name))
        counter += 1

    if not insertions:
        return False, len(tests), counter

    # Add using statement if needed
    content_with_using, using_added = add_using_if_needed(content, "AccordionScripts1")
    if using_added:
        lines = content_with_using.split("\n")
        # Shift all insertion indices by 1 since we added a line
        insertions = [(idx + 1, dev, name) for idx, dev, name in insertions]
        modified = True

    # Insert [TargetDevice] attributes (process in reverse to preserve line numbers)
    for line_idx, device, method_name in reversed(insertions):
        indent = get_indent(lines[line_idx])
        attr_line = f'{indent}[TargetDevice("{device}")]'
        lines.insert(line_idx, attr_line)
        modified = True

    if modified:
        with open(filepath, "w", encoding="utf-8") as f:
            f.write("\n".join(lines))

    return modified, len(tests), counter


def main():
    parser = argparse.ArgumentParser(
        description="Add [TargetDevice] attribute to each [Test] method, split 50/50 across two devices."
    )
    parser.add_argument(
        "directory",
        nargs="?",
        default="UITests.Shared",
        help="Path to the shared test project directory (default: UITests.Shared)",
    )
    parser.add_argument(
        "--device1", default="emulator-5554", help="UDID for first device (default: emulator-5554)"
    )
    parser.add_argument(
        "--device2", default="emulator-5556", help="UDID for second device (default: emulator-5556)"
    )
    args = parser.parse_args()

    shared_dir = os.path.abspath(args.directory)
    if not os.path.isdir(shared_dir):
        print(f"Error: Directory not found: {shared_dir}")
        sys.exit(1)

    device1 = args.device1
    device2 = args.device2

    print(f"Directory : {shared_dir}")
    print(f"Device 1  : {device1}")
    print(f"Device 2  : {device2}")
    print(f"{'=' * 60}\n")

    cs_files = find_cs_files(shared_dir)
    if not cs_files:
        print("No .cs files found.")
        sys.exit(1)

    total_tests = 0
    total_modified_files = 0
    counter = 0  # Global counter to distribute evenly across ALL files
    device1_count = 0
    device2_count = 0

    for filepath in cs_files:
        rel_path = os.path.relpath(filepath, shared_dir)
        was_modified, test_count, counter = process_file(filepath, device1, device2, counter)

        if test_count > 0:
            status = "UPDATED" if was_modified else "OK (already tagged)"
            print(f"  [{status}] {rel_path} — {test_count} tests")
            total_tests += test_count
            if was_modified:
                total_modified_files += 1

    # Count final distribution
    for filepath in cs_files:
        with open(filepath, "r", encoding="utf-8") as f:
            content = f.read()
        device1_count += content.count(f'[TargetDevice("{device1}")]')
        device2_count += content.count(f'[TargetDevice("{device2}")]')

    print(f"\n{'=' * 60}")
    print(f"Total test methods found : {total_tests}")
    print(f"Files modified           : {total_modified_files}")
    print(f"Device 1 ({device1}) : {device1_count} tests")
    print(f"Device 2 ({device2}) : {device2_count} tests")
    print(f"{'=' * 60}")


if __name__ == "__main__":
    main()
