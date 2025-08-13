using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SfButtonSample.ViewModel
{
    public class CommandViewModel : INotifyPropertyChanged
    {
        private string label1 = "";
        public string Label1
        {
            get
            {
                return label1;
            }
            set
            {
                label1 = value; RaisePropertyChanged("Label1");
            }
        }

        private string label2 = "";
        public string Label2
        {
            get
            {
                return label2;
            }
            set
            {
                label2 = value; RaisePropertyChanged("Label2");
            }
        }

        public ICommand OkCommand { private set; get; }

        public ICommand CancelCommand { private set; get; }

        int i = 0;
        public CommandViewModel()
        {
            OkCommand = new Command(
            execute: () =>
            {

                Label1 = "Ok Button is clicked: " + i++ + " times";

            });

            CancelCommand = new Command<string>(
                execute: (string arg) =>
                {
                    Label2 = "Cancel button is clicked and command parameter value obtained is: " + arg;
                });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(String name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
