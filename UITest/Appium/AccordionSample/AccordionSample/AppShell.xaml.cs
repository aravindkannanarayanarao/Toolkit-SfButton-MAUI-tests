namespace AccordionSample
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(SfAccordionHorizontalShellPage), typeof(SfAccordionHorizontalShellPage));
            Routing.RegisterRoute(nameof(SfAccordionAbsoluteShellPage), typeof(SfAccordionAbsoluteShellPage));

        }
    }
}
