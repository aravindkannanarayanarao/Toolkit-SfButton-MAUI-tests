using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Maui.Core;
using Syncfusion.Maui.Buttons;

namespace SfButtonSample
{
    public partial class CommandDemoViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool _LivraisonsJourCanExecute;

        public bool LivraisonsJourCanExecute
        {

            get => _LivraisonsJourCanExecute;

            set
            {
                _LivraisonsJourCanExecute = value;

                LivraisonsJourCommand.ChangeCanExecute();

                OnPropertyChanged(nameof(LivraisonsJourCanExecute));

            }

        }

        private Command _LivraisonsJourCommand;

        public Command LivraisonsJourCommand
        {

            get
            {

                _LivraisonsJourCommand ??= new Command(DoLivraisonsJourCommand, (param) => LivraisonsJourCanExecute);

                return _LivraisonsJourCommand;

            }

        }

        private void DoLivraisonsJourCommand(object param)
        {

            TextColor = Colors.Red;

            // AlertService.ShortAlert("OK");

        }

        private Color textColor = Colors.Green;

        public Color TextColor
        {
            get { return textColor; }
            set { textColor = value; OnPropertyChanged(nameof(TextColor)); }
        }




        private Command _TestCommand;



        public Command TestCommand
        {

            get
            {

                _TestCommand ??= new Command(DoTestCommand);

                return _TestCommand;

            }

        }
        public CommandDemoViewModel()
        {
            //LivraisonsJourCanExecute = true;
        }

        private void DoTestCommand(object param)
        {

            LivraisonsJourCanExecute = !LivraisonsJourCanExecute;

        }


    }

    public partial class CommandDemoViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool showStartButton;

        //public CommandDemoViewModelViewModel()
        //{
        //    this.ShowStartButton = true;
        //}

        public bool ShowStartButton { get; private set; }

        [RelayCommand(AllowConcurrentExecutions = true)]

        private async Task StartWorkout()
        {
            ShowStartButton = false;
            await Task.CompletedTask;
        }
    }

    internal class RelayCommandAttribute : Attribute
    {
        public bool AllowConcurrentExecutions { get; set; }
    }

    internal class ObservablePropertyAttribute : Attribute
    {
    }

    public class ObservableObject
    {
    }
}
