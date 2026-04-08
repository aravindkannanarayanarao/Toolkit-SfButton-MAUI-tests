using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccordionSample
{
    public class ProgressReport : INotifyPropertyChanged
    {

        private int cockpitdrills;
        public int Cockpitdrills
        {
            get { return cockpitdrills; }
            set
            {
                if (cockpitdrills != value)
                {
                    cockpitdrills = value;
                    this.RaisedOnPropertyChanged("Cockpitdrills");
                }
            }
        }

        private int control;
        public int Controls
        {
            get { return control; }
            set
            {
                if (control != value)
                {
                    control = value;
                    this.RaisedOnPropertyChanged("Controls");
                }
            }
        }
        private int movingOff;
        public int MovingOff
        {
            get { return movingOff; }
            set
            {
                if (movingOff != value)
                {
                    movingOff = value;
                    this.RaisedOnPropertyChanged("MovingOff");
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void RaisedOnPropertyChanged(string _PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_PropertyName));
            }
        }
    }
}
