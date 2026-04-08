using Prism.Commands;
using Prism.Navigation;
using Prism.Navigation.Xaml;
using System.ComponentModel;
using System.Windows.Input;
using INavigationService = Prism.Navigation.INavigationService;

namespace MemoryLeakTestSample
{
    public class MainPageViewModel : ViewModelBase
    {
        private string? initalMemory;
        private string? result;
        private string? controlMemory;
        private string? memoryLeak;
        private string? controlName;
        private bool initalLaunch = true;
        private int initialmemoryUsed;  
        private int memoryUsed;
        private int finalMemory;

        public MainPageViewModel()
        {
            Init();
            
        }

        private Action<object> Calculate(object contol)
        {
            throw new NotImplementedException();
        }

        private async void GotoExpanderPageCommandAsync(object obj)
        {
            controlName = "Expander";
            await Shell.Current.Navigation.PushAsync(new ExpanderPage());
        }

        private async void GotoAccordionPageCommand(object obj)
        {
            controlName = "Accordion";
            await Shell.Current.Navigation.PushAsync(new AccordionPage());
        }

        public DelegateCommand? GoToAccordionPageCommand { get; set; }
        public DelegateCommand? GoToExpanderPageCommand { get; set; }
        public DelegateCommand? GetGCCommand { get; set; }
        public string? InitalMemory
        {
            get => initalMemory;
            set => SetProperty(ref this.initalMemory, value);
        }

        public string? ControlMemory
        {
            get => this.controlMemory;
            set => SetProperty(ref this.controlMemory, value);
        }

        public string? MemoryLeak
        {
            get => this.memoryLeak;
            set => SetProperty(ref this.memoryLeak, value);
        }

        public string? Result
        {
            get => this.result;
            set => SetProperty(ref this.result, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if ((bool)initalLaunch)
            {
                this.initalLaunch = false;
                this.initialmemoryUsed = (int)(GC.GetTotalMemory(true) / 1024);
                this.InitalMemory = "Inital Memory: " + this.initialmemoryUsed.ToString() + "KB";
            }

            this.GCAndUpdate();
        }

        [Obsolete]
        private void Init()
        {

            this.GoToAccordionPageCommand = new DelegateCommand(async () =>
            {
                controlName = "Accordion";
                await Shell.Current.Navigation.PushAsync(new AccordionPage());
            });
            this.GoToExpanderPageCommand = new DelegateCommand(async () =>
            {
                controlName = "Expander";
                await Shell.Current.Navigation.PushAsync(new ExpanderPage());
            });
            this.GetGCCommand = new DelegateCommand(() =>
            {
                this.Calculate(this.controlName);
            });

        }

        [Obsolete]
        private void GCAndUpdate()
        {
            switch (this.controlName)
            {
                case "Accordion":
                    Calculate("Accordion");
                    break;
                case "Expander":
                    Calculate("Expander");
                    break;
                default:
                    break;
            }
        }

        [Obsolete]
        private void Calculate(String control)
        {
            this.memoryUsed = (int)(GC.GetTotalMemory(true) / 1024);
            this.ControlMemory = "Final Memory: " + this.memoryUsed.ToString() + "KB";
            this.finalMemory = (this.memoryUsed - initialmemoryUsed);
            this.MemoryLeak = "Memory Leak: " + this.finalMemory.ToString() + "KB";

            if (control == "Accordion")
            {
                if (this.finalMemory > 800)
                {
                    this.Result = "Result: High";
                }
                else
                {
                    this.Result = "Result: Normal";
                }

                return;
            }

            if (control == "Expander")
            {
                var averageMemory = 800;
                if (Device.RuntimePlatform == Device.Android)
                {
                    averageMemory = 850;
                }

                if (this.finalMemory > averageMemory)
                {
                    this.Result = "Result: High";
                }
                else
                {
                    this.Result = "Result: Normal";
                }

                return;
            }
        }
    }
}
