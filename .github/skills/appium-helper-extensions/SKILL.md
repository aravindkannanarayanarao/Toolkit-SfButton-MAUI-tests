````skill
---
name: appium-helper-extensions
description: Comprehensive reference for Syncfusion.UITestHelpers.Appium HelperExtensions class methods, organized by platform (Android, iOS, macOS, Windows) and action category (tap, scroll, swipe, text, drag, etc.). Use this skill to select the correct helper method when writing Appium test cases.
metadata:
  author: maui-custom-controls
  version: "1.0"
compatibility: Requires Syncfusion.UITestHelpers.Appium NuGet package with Appium.WebDriver 5.0.0.
---

# Appium HelperExtensions Skill

This skill is the definitive reference for all `HelperExtensions` static methods in the `Syncfusion.UITestHelpers.Appium` namespace. Use it to select the correct method for any UI automation action, with platform-specific guidance for Android, iOS, macOS (Catalyst), and Windows.

## Source Reference

- **Class**: `Syncfusion.UITestHelpers.Appium.HelperExtensions` (static)
- **File**: `Appium framework/src/Syncfusion.UITestHelpers.Appium/HelperExtensions.cs` (~6277 lines)
- **Action Classes**: `Appium framework/src/Syncfusion.UITestHelpers.Appium/Actions/` (35 files)

---

## Quick Method Lookup by Action

| I want to... | Method | Cross-platform? |
|--------------|--------|----------------|
| Tap an element | `app.Tap("id")` | Yes |
| Tap at coordinates | `app.TapCoordinates(x, y)` | Yes |
| Tap element by text | `app.TapByText("Submit")` | Yes |
| Double tap | `app.DoubleTap("id")` | Yes |
| Long press | `app.LongPress("id")` or `app.TouchAndHold("id")` | Yes |
| Right-click | `app.RightClick("id")` | Desktop only |
| Enter text | `app.EnterText("id", "text")` | Yes |
| Clear text | `app.ClearText("id")` | Yes |
| Dismiss keyboard | `app.DismissKeyboard()` | Mobile only |
| Press Enter | `app.PressEnter()` | Yes |
| Scroll down | `app.ScrollDown("id")` | Yes |
| Scroll to element | `app.ScrollDownTo("target", "container")` | Yes |
| Swipe left to right | `app.SwipeLeftToRight("id")` | Yes |
| Drag and drop | `app.DragAndDrop("source", "target")` | Yes |
| Set slider value | `app.SetSliderValue("id", 0.5)` | Yes |
| Set orientation | `app.SetOrientationLandscape()` | Mobile |
| Wait for element | `app.WaitForElement("id")` | Yes |
| Wait for no element | `app.WaitForNoElement("id")` | Yes |
| Check element exists | `app.DoesElementExist("id")` | Yes |
| Take screenshot | `app.Screenshot("filename")` | Yes |
| Navigate back | `app.Back()` or `app.TapBackArrow()` | Yes |
| Switch theme | `app.SetDarkTheme()` / `app.SetLightTheme()` | Yes |

---

## 1. TAP / CLICK Methods

### Cross-Platform Tap
```csharp
// Tap by AutomationId (most common)
app.Tap("myButtonId");

// Tap by IQuery
app.Tap(AppiumQuery.ById("myButtonId"));

// Tap on a found UIElement
var element = app.FindElement("myButtonId");
element.Tap();

// Tap at screen coordinates
app.TapCoordinates(200f, 400f);

// Tap by visible text
app.TapByText("Submit");

// Tap button by accessibility ID (with optional repeat count)
app.TapButton("submitBtn");
app.TapButton("incrementBtn", endLimit: 5);  // Tap 5 times

// Tap with delay after tap
element.TapWithDelay(delayInMilliseconds: 500);

// Tap by XPath
app.XpathTap("//android.widget.Button[@text='OK']");
```

### Desktop-Only Click (Mouse)
```csharp
// Mouse click (uses mouse actions instead of touch)
app.Click("myButtonId");
app.Click(AppiumQuery.ById("myButtonId"));
app.ClickCoordinates(200f, 400f);

// Right-click
app.RightClick("myButtonId");
app.RightClickMouse(200f, 400f);           // Native right-click at coordinates
app.RightClickMouse("myButtonId");          // Native right-click at element center
```

### Double Tap / Double Click
```csharp
// Touch-based double tap (mobile & desktop)
app.DoubleTap("myElementId");
app.DoubleTapCoordinates(200f, 400f);

// Mouse-based double click (desktop)
app.DoubleClick("myElementId");
app.DoubleClickCoordinates(200f, 400f);
```

---

## 2. LONG PRESS / TOUCH AND HOLD

```csharp
// Long mouse press (desktop)
app.LongPress("myElementId");

// Continuous touch gesture (mobile)
app.TouchAndHold("myElementId");
app.TouchAndHold(AppiumQuery.ById("myElementId"));
app.TouchAndHoldCoordinates(200f, 400f);

// Combined touch-hold-drag-drop
app.TouchHoldDragDrop("sourceElement", "targetElement", holdDurationMs: 500);

// Right-click / long-press on chat message
app.RightClickChatMessage("Hello World", timeoutSeconds: 5);
```

---

## 3. TEXT INPUT / KEYBOARD

### Enter Text
```csharp
// Standard: enter text + dismiss keyboard
app.EnterText("editorId", "Hello World");

// iOS-specific: enter text without keyboard dismiss
app.EnterTextiOS("editorId", "Hello World");

// By accessibility ID (cross-platform)
app.EnterTextInField("myAccessibilityId", "text");

// Into nested EditText (Android)
app.EnterTextIntoCustomField("accessibilityId", "value");

// Using visible text to find field
app.EnterTextSyncfusion("fieldLabel", "text");

// iOS focused field input
app.EnterTextIOSFocused("text", clearLength: 10, focusWaitMs: 300);

// Send keyboard keys to element
element.SendKeys("text");

// Android key event
app.SendKeys(keyCode: 66, metastate: 0);  // 66 = KEYCODE_ENTER
```

### Clear Text
```csharp
app.ClearText("editorId");
app.ClearText(AppiumQuery.ById("editorId"));
app.ClearTextFieldById("editorId");      // Platform-specific handling
element.Clear();

// iOS clear + enter
app.ClearAndEnterTextiOS("editorId", "new text");
```

### Keyboard Actions
```csharp
app.DismissKeyboard();
bool shown = app.IsKeyboardShown();
app.PressEnter();
app.PressEnterWindows();  // Reliable Enter on Windows

// Windows: focus entry + send Enter (triggers Completed event)
app.TriggerCompletedWindows("entryAutomationId", focusWaitMs: 120);
```

### Platform-Specific Text Patterns
```csharp
// Android
app.EnterText("editor", "text");
app.DismissKeyboard();

// iOS
app.EnterTextiOS("editor", "text");
app.Tap("Done");  // or app.iOSDone();

// Windows
app.EnterText("editor", "text");
app.PressEnterWindows();

// macOS / Catalyst
app.EnterText("editor", "text");
app.PressEnter();
```

---

## 4. SCROLL Methods

```csharp
// Directional scrolling on element
app.ScrollDown("scrollViewId");
app.ScrollUp("scrollViewId");
app.ScrollLeft("scrollViewId");
app.ScrollRight("scrollViewId");

// With query
app.ScrollDown(AppiumQuery.ById("scrollViewId"));

// Scroll until target element is visible
app.ScrollDownTo("targetElementId", "scrollViewId");
app.ScrollUpTo("targetElementId", "scrollViewId");

// Scroll until visible with timeout
app.ScrollUntilVisible("targetElementId", "scrollViewId", down: true);

// Scroll until text visible, then click
app.ScrollUntilVisibleText("targetText", "scrollViewId");

// Swipe from center of screen (for full-page scrolling)
app.SwipeDownFromCenter(deltaPercent: 0.3, down: true);
app.SwipeUpFromCenter(deltaPercent: 0.3);
```

---

## 5. SWIPE Methods

```csharp
// Screen-level swipes
app.SwipeLeftToRight();
app.SwipeRightToLeft();
app.SwipeTopToBottom();
app.SwipeBottomToTop();

// Element-level swipes
app.SwipeLeftToRight("elementId");
app.SwipeRightToLeft("elementId");
app.SwipeTopToBottom("elementId");
app.SwipeBottomToTop("elementId");

// With query
app.SwipeLeftToRight(AppiumQuery.ById("elementId"));
```

---

## 6. DRAG AND DROP

```csharp
// Element-to-element
app.DragAndDrop("sourceId", "targetId");
app.DragAndDrop(AppiumQuery.ById("source"), AppiumQuery.ById("target"));

// Coordinate-based
app.DragCoordinates(fromX, fromY, toX, toY);

// With configurable hold and duration
app.DragCoordinatesKanbanwait(fromX, fromY, toX, toY, holdDurationMs: 500, dragDurationMs: 1000);

// Advanced: with gestures (Android)
app.DragByCoordinatesWithDelayUsingGestures(startX, startY, endX, endY, delayMs: 600, settleMs: 200, speed: 500);

// Advanced: stepped drag with long hold
app.DragHoldDropByCoordinates(startX, startY, endX, endY,
    pickupDelayMs: 600, steps: 14, stepDelayMs: 60, holdAtEndMs: 9000);

// Advanced: drag through waypoint
app.DragViaWaypointHoldThenDrop(startX, startY, waypointX, waypointY, endX, endY);

// Pan gesture
app.Pan(fromX, fromY, toX, toY);
```

---

## 7. WAIT Methods

```csharp
// Wait for element to appear
app.WaitForElement("elementId");
app.WaitForElement("elementId", timeoutMessage: "Element not found", timeout: TimeSpan.FromSeconds(30));

// Wait for element to disappear
app.WaitForNoElement("elementId");

// Wait for any of multiple elements
app.WaitForAnyElement(new[] { "element1", "element2", "element3" });

// Wait for text content in element
app.WaitForTextToBePresentInElement("elementId", "expected text");

// Wait with Catalyst page settle handling
app.WaitForElementTillPageNavigationSettled("elementId");

// Retry query until present/absent
var result = app.QueryUntilPresent(() => app.FindElement("id"), retryCount: 10, delayInMs: 2000);
app.QueryUntilNotPresent(() => app.FindElement("id"), retryCount: 10, delayInMs: 2000);
```

---

## 8. ELEMENT STATE / QUERY

```csharp
// Check element state
bool exists = app.DoesElementExist("elementId");
bool focused = app.IsFocused("elementId");

// UIElement properties
bool displayed = element.IsDisplayed();
bool enabled = element.IsEnabled();
bool selected = element.IsSelected();
string text = element.GetText();
var rect = element.GetRect();
var attr = element.GetAttribute<string>("attributeName");

// Find elements
var el = app.FindElement("id");
var el2 = app.FindElementByText("visible text");
var els = app.FindElements("id");
var visible = app.FindVisibleElementByText("text", timeoutInSeconds: 3);

// Debug / diagnostic
string source = app.GetNativePageSource();
app.PrintTree();
app.DumpWindowsTextInputs();
```

---

## 9. SLIDER / STEPPER

```csharp
// Set slider value (0-1 normalized)
app.SetSliderValue("sliderId", 0.5);

// Set slider with explicit min/max range
app.SetSliderValue("sliderId", value: 75, minimum: 0, maximum: 100);

// Stepper controls
app.IncreaseStepper("stepperId");
app.DecreaseStepper("stepperId");
```

---

## 10. PINCH / ZOOM

```csharp
app.PinchToZoomIn("elementId");
app.PinchToZoomInCoordinates(200f, 400f);
app.PinchToZoomOut("elementId");
app.PinchToZoomOutCoordinates(200f, 400f);
```

---

## 11. ORIENTATION

```csharp
app.SetOrientationLandscape();
app.SetOrientationPortrait();
var orientation = app.GetOrientation();
```

---

## 12. CLIPBOARD

```csharp
string text = app.GetClipboardText();      // Android/iOS
app.SetClipboardText("content", label: "clipboard");
```

---

## 13. APP LIFECYCLE

```csharp
app.LaunchApp();
app.BackgroundApp();
app.ForegroundApp();
app.ResetApp();
app.CloseApp();
app.Back();
app.Refresh();
```

---

## 14. NAVIGATION / FLYOUT

```csharp
// Open a sample page and wait for it
app.OpenSample("SampleName", "waitElementId");
app.OpenSample("SampleName");

// Navigation
app.HomeBtn();
app.TapBackArrow();
app.TapBackArrow("customBackButtonId");
app.Back();

// Shell flyout
app.ShowFlyout();
app.TapShellFlyoutIcon();
app.TapInShellFlyout("flyoutItemName");

// FlyoutPage flyout
app.TapFlyoutPageIcon();
app.TapInFlyoutPageFlyout("flyoutItemName");

// Tab navigation
app.TapTab("TabName");
app.TapTab("TabName", isTopTab: true);
app.WaitForTabElement("TabName");

// More button and option
app.TapMoreButton();
app.Option();
```

---

## 15. ALERTS

```csharp
var alert = app.GetAlert();
var alerts = app.GetAlerts();
alert.DismissAlert();
var buttons = alert.GetAlertButtons();
var text = alert.GetAlertText();

// Tap display alert button
app.TapDisplayAlertButton("alert text", buttonIndex: 0);
```

---

## 16. DEVICE-SPECIFIC Methods

```csharp
// Device info
var device = app.GetTestDevice();
var appId = app.GetAppId();

// Volume
app.PressVolumeUp();
app.PressVolumeDown();

// Screen lock
app.Lock();
app.Unlock("pin", "1234");
bool locked = app.IsLocked();

// Recording (Android)
app.StartRecordingScreen();
app.StopRecordingScreen();

// Theme
app.SetDarkTheme();
app.SetLightTheme();

// Shake (Android)
app.Shake();
```

---

## 17. ANDROID-ONLY Methods

```csharp
// Network toggles
app.ToggleAirplaneMode();
app.ToggleWifi();
app.ToggleData();

// System animations
app.ToggleSystemAnimations(enableSystemAnimations: false);

// Performance data
var perf = app.GetPerformanceData("cpuinfo");  // cpuinfo, memoryinfo, networkinfo, batteryinfo

// System bars info
var bars = app.GetSystemBars();

// ComboBox (Syncfusion)
app.SelectFromComboBox("comboboxId", x, y);
app.SelectFromComboBox("comboboxId");
app.SelectFromComboBox("comboboxId", "SearchValue", x, y);

// AutoComplete (Syncfusion)
app.SelectFromAutoComplete("autoCompleteId", "valueToType", x, y);
app.SelectFromAutoCompleteByText("autoCompleteId", "valueToType");
```

---

## 18. iOS-ONLY Methods

```csharp
app.iOSDone();         // Tap iOS Done button

// Picker interactions
app.iOSPickerInteract("pickerId", "valueToSelect");
app.iOSPickerInteracts("pickerId", "valueToSelect");
app.iOSPickerSelectResilient("pickerId", "valueToSelect", maxAttempts: 3, settleMs: 250);

// AutoComplete
app.SelectFromAutoCompleteIOSByText("fieldId", "valueToType", "itemText");

// Text input
app.SendKeysToFocusedIOS("text", backspaces: 0, sendReturn: false);
app.ClearAndEnterTextiOS("editorId", "new text");
```

---

## 19. CATALYST/MAC-ONLY Methods

```csharp
app.EnterFullScreen();
app.ExitFullScreen();
```

---

## 20. NAMED POINTS (Coordinate Registry)

```csharp
app.AddPoint("myPoint", 100f, 200f);
app.TapByPointer("myPoint");
var allPoints = app.GetAllPoints();
app.PrintAllPoints();
```


## 21. Assertions verifications

```csharp
App.AssertAreEqual(expected, actual);
App.AssertIsTrue();
App.AssertAreEqual();
App.AssertAreEqual();
App.AssertAreEqual();

```


---

## Platform Decision Matrix

Use this matrix to choose the right method variant:

| Action | Android | iOS | Windows | macOS |
|--------|---------|-----|---------|-------|
| Tap element | `Tap()` | `Tap()` | `Click()` | `Click()` |
| Enter text | `EnterText()` + `DismissKeyboard()` | `EnterTextiOS()` + `iOSDone()` | `EnterText()` | `EnterText()` |
| Back navigation | `Back()` | `TapBackArrow()` | `TapBackArrow()` | `TapBackArrow()` |
| Fullscreen | N/A | N/A | N/A | `EnterFullScreen()` |
| Done button | N/A | `iOSDone()` | N/A | N/A |
| Picker | N/A | `iOSPickerInteract()` | N/A | N/A |
| Orientation | `SetOrientation*()` | `SetOrientation*()` | N/A | N/A |

## Common Test Patterns with Platform Guards

```csharp
[SetUp]
public void Setup()
{
#if MACOS
    App.EnterFullScreen();
#endif
}

[TearDown]
public void TearDown()
{
#if MACOS
    App.ExitFullScreen();
#endif
    Reset();
}

[Test]
public void TestWithPlatformHandling()
{
    Basicsbutton("SampleName");
    
    App.EnterText("editor", "test input");
#if ANDROID
    App.DismissKeyboard();
#elif IOS
    App.Tap("Done");
#endif
    
    Thread.Sleep(1000);
    TakeAndCompareScreenshot("TestResult");
}
```

## Action Classes Reference

| Action Class | Platform | Methods |
|-------------|----------|---------|
| `AppiumGeneralActions` | All | getAttribute, getRect, getSelected, getDisplayed, getEnabled |
| `AppiumTouchActions` | Mobile | tap, doubleTap, touchAndHold, dragAndDrop, scrollTo |
| `AppiumMouseActions` | Desktop | click, doubleClick, longPress |
| `AppiumScrollActions` | All | scrollLeft/Right/Up/Down, scrollTo |
| `AppiumSwipeActions` | All | swipeLeftToRight, swipeRightToLeft |
| `AppiumTextActions` | All | sendKeys, clear, getText |
| `AppiumSliderActions` | All | setSliderValue |
| `AppiumPointerActions` | All | click, doubleTap, dragAndDrop (PointerKind.Touch) |
| `AppiumPinchToZoomActions` | Mobile | pinchToZoomIn/Out |
| `AppiumOrientationActions` | Mobile | setOrientation |
| `AppiumClipboardActions` | Mobile | getClipboard, setClipboard |
| `AppiumDeviceActions` | All | pressVolume, lock/unlock, shake |
| `AppiumLifecycleActions` | All | launch, background, foreground, reset, close |
| `AppiumVirtualKeyboardActions` | All | dismissKeyboard, isKeyboardShown, pressEnter |
| `AppiumAndroidSpecificActions` | Android | toggleAirplane/Wifi/Data, getPerformance |
| `AppiumAndroidAlertActions` | Android | getAlert, dismissAlert, getAlertButtons |
| `AppiumAndroidStepperActions` | Android | increaseStepper, decreaseStepper |
| `AppiumAndroidThemeChangeAction` | Android | setDarkTheme, setLightTheme |
| `AppiumIOSSpecificActions` | iOS | shake |
| `AppiumIOSAlertActions` | iOS | getAlert, dismissAlert |
| `AppiumIOSMouseActions` | iOS | click, doubleClick |
| `AppiumIOSTouchActions` | iOS | tap, doubleTap, touchAndHold |
| `AppiumIOSStepperActions` | iOS | increaseStepper, decreaseStepper |
| `AppiumIOSThemeChangeAction` | iOS | setDarkTheme, setLightTheme |
| `AppiumCatalystSpecificActions` | macOS | enterFullScreen, exitFullScreen |
| `AppiumCatalystAlertActions` | macOS | getAlert, dismissAlert |
| `AppiumCatalystMouseActions` | macOS | click, doubleClick |
| `AppiumCatalystTouchActions` | macOS | tap, doubleTap |
| `AppiumCatalystScrollActions` | macOS | scrollLeft/Right/Up/Down |
| `AppiumWindowsStepperActions` | Windows | increaseStepper, decreaseStepper |
| `AppiumWindowsThemeChangeAction` | Windows | setDarkTheme, setLightTheme |

````
