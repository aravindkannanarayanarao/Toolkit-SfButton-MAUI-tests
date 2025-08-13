namespace SfButtonSample;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MDAxQDMzMzAyZTMwMmUzMDNiMzMzMDNiY1FSYlBSaEN6RXlMaHZnY0tQZkQ2a2h1YVFMNHAxL21Qa1dXZXcxM0VNcz0=");
        MainPage = new NavigationPage(new MainPage());
    }
    public static double ScreenWidth { get; internal set; }
    public static double ScreenHeight { get; internal set; }
    public static float Density { get; internal set; }
}
