namespace MemoryLeakTestSample
{
    public partial class App : Application
    {
        public static double ScreenWidth { get; internal set; }
        public static double ScreenHeight { get; internal set; }
        public static float Density { get; internal set; }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
