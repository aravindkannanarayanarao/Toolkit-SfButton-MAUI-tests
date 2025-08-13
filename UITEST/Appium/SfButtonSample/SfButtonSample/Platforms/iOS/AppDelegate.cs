using Foundation;

namespace SfButtonSample;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    //protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    protected override MauiApp CreateMauiApp()
    {
        //throw new NotImplementedException();





#if ENABLE_TEST_CLOUD
                Xamarin.Calabash.Start();
#endif
        return MauiProgram.CreateMauiApp();



    }
}