using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;
using Syncfusion.Maui.Toolkit.Hosting;
using Microsoft.Maui.LifecycleEvents;

namespace SfButtonSample;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureSyncfusionCore()
            .ConfigureSyncfusionToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Roboto-Medium.ttf", "RobotoMedium");
                fonts.AddFont("Roboto-Regular.ttf", "Roboto-Regular");
                fonts.AddFont("Samantha Demo.ttf", "SamanthaDemo");
                fonts.AddFont("SegmentIcon.ttf", "SegmentIcon");
            });
#if ANDROID
        Microsoft.Maui.Handlers.LabelHandler.Mapper.AppendToMapping("FontFamily", (handler, element) =>
        {
            if (element.Font.Family == "SegmentIcon")
            {
                const string font = "SegmentIcon.ttf";
                handler.PlatformView.Typeface = Android.Graphics.Typeface.CreateFromAsset(handler.MauiContext.Context.Assets, font);
            }
        });
#endif

#if WINDOWS
            builder.ConfigureLifecycleEvents(events =>
            {
                events.AddWindows(wndLifeCycleBuilder =>
                {
                    wndLifeCycleBuilder.OnWindowCreated(window =>
                    {
                        var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
                        Microsoft.UI.WindowId windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hWnd);
                        Microsoft.UI.Windowing.AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
                        if (appWindow is not null)
                        {
                            appWindow.SetPresenter(Microsoft.UI.Windowing.AppWindowPresenterKind.FullScreen);
                        }
                    });
                });
            });
#endif

        return builder.Build();
    }
}

