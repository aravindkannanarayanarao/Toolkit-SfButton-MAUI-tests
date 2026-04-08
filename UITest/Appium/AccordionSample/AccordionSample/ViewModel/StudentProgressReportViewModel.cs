using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccordionSample
{
    public class StudentProgressReportViewModel : INotifyPropertyChanged
    {
        private string? sectionBasic;
        private string? sectionMspgl;

        public StudentProgressReportViewModel()
        {
            ProgressReport = new ProgressReport();
            ProgressReport.Cockpitdrills = 50;
            ProgressReport.Controls = 40;
            ProgressReport.MovingOff = 30;
        }

        public ProgressReport? ProgressReport { get; set; }

        internal void SaveProgressReport()
        {

        }

        public int Cockpitdrills { get { return ProgressReport!.Cockpitdrills; } set { ProgressReport!.Cockpitdrills = value; SaveProgressReport(); OnPropertyChanged("Cockpitdrills"); } }
        public int Controls { get { return ProgressReport!.Controls; } set { ProgressReport!.Controls = value; SaveProgressReport(); OnPropertyChanged("Controls"); } }
        public int MovingOff { get { return ProgressReport!.MovingOff; } set { ProgressReport!.MovingOff = value; SaveProgressReport(); OnPropertyChanged("MovingOff"); } }

        public string? SectionBasic
        {
            get
            {
                return sectionBasic;
            }
            set
            {
                sectionBasic = value;
                OnPropertyChanged("SectionBasic");
                OnPropertyChanged("SectionBasicVisibility");
            }
        }

        public bool? SectionBasicVisibility
        {
            get
            {
                var visible = !string.IsNullOrEmpty(SectionBasic);
                return visible;
            }
        }

        public string? SectionMspgl
        {
            get
            {
                return sectionMspgl;
            }
            set
            {
                sectionMspgl = value;
                OnPropertyChanged("SectionMspgl");
                OnPropertyChanged("SectionMspglVisibility");
            }
        }

        public bool SectionMspglVisibility
        {
            get
            {
                var visible = !string.IsNullOrEmpty(SectionMspgl);
                return false;
            }
        }

        public void SetSections()
        {
            SectionBasic = "sectionBasic";
            SectionMspgl = "sectionMspgl";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
