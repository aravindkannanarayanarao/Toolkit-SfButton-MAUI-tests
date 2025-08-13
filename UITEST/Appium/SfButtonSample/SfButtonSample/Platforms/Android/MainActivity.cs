using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace SfButtonSample;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    public object TabLayoutResource { get; private set; }
    public object ToolbarResource { get; private set; }
    public object Platforms { get; private set; }



    protected override void OnCreate(Bundle savedInstanceState)
    {
        App.ScreenWidth = (Resources.DisplayMetrics.WidthPixels) * 0.75;
        App.ScreenHeight = (Resources.DisplayMetrics.HeightPixels) * 0.75;
        App.Density = Resources.DisplayMetrics.Density;
        base.OnCreate(savedInstanceState);
        Window.AddFlags(WindowManagerFlags.Fullscreen);
        Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);



    }
}
