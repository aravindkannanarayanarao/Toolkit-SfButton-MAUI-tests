namespace MAUIExpander
{
    public partial class App : Application
    {
        public static double ScreenWidth { get; internal set; }
        public static double ScreenHeight { get; internal set; }
        public static float Density { get; internal set; }
        public App()
        {
			Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjGyl/VkV+XU9FfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hTH9RdEZiWn1ac3ZXR2FVWkd1");
            InitializeComponent();

            MainPage = new NavigationPage(new MainMenu());
        }
    }
}
