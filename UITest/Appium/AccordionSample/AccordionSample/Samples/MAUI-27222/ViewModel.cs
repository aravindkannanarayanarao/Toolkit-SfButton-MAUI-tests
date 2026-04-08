using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AccordionSample.Samples
{
    #region Test
    public class Test : INotifyPropertyChanged
    {
        public ObservableCollection<Attachment> ocAtt { get; set; }

        private bool _isNotesEnabled;
        public bool IsNotesEnabled
        {
            get { return _isNotesEnabled; }
            set
            {
                _isNotesEnabled = value;
                OnPropertyChanged("IsNotesEnabled");
            }
        }

        private bool _isCompleteButtonVisible;
        public bool IsCompleteButtonVisible
        {
            get { return _isCompleteButtonVisible; }
            set
            {
                _isCompleteButtonVisible = value;
                OnPropertyChanged("IsCompleteButtonVisible");
            }
        }

        private string _saveMsg = "";
        public string SaveMsg
        {
            get { return _saveMsg; }
            set
            {
                _saveMsg = value;
                OnPropertyChanged("SaveMsg");
            }
        }

        private bool _saveMsgVisibility = false;
        public bool SaveMsgVisibility
        {
            get { return _saveMsgVisibility; }
            set
            {
                _saveMsgVisibility = value;
                OnPropertyChanged("SaveMsgVisibility");
            }
        }

        public Sub sub { get; set; }

        private bool _sPM;
        public bool cb1
        {
            get { return _sPM; }
            set
            {
                _sPM = value;
                OnPropertyChanged("sPM");
            }
        }

        private bool _sPMSwitchEnabled;
        public bool cb1Enabled
        {
            get { return _sPMSwitchEnabled; }
            set
            {
                _sPMSwitchEnabled = value;
                OnPropertyChanged("sPMSwitchEnabled");
            }
        }

        private bool _sPMA;
        public bool cb2
        {
            get { return _sPMA; }
            set
            {
                _sPMA = value;
                OnPropertyChanged("sPMA");
            }
        }

        private bool _sPMASwitchEnabled;
        public bool cb2Enabled
        {
            get { return _sPMASwitchEnabled; }
            set
            {
                _sPMASwitchEnabled = value;
                OnPropertyChanged("sPMASwitchEnabled");
            }
        }

        private bool _closeAllIsToggled;
        public bool closeAllIsToggled
        {
            get { return _closeAllIsToggled; }
            set
            {
                _closeAllIsToggled = value;
                OnPropertyChanged("closeAllIsToggled");
            }
        }

        private int _attachmentHeight;
        public int AttachmentHeight
        {
            get { return this._attachmentHeight; }
            set
            {
                _attachmentHeight = value;
                OnPropertyChanged("AttachmentHeight");
            }
        }

        public string? accordionText { get; set; }

        public StackOrientation? stackOrientation { get; set; }

        public Test()
        {
            SaveMsg = "Test";
            SaveMsgVisibility = true; //SaveMsgVisibility = false;

            ocAtt = new ObservableCollection<Attachment>();
            stackOrientation = StackOrientation.Vertical;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(
            [CallerMemberName] string? propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
    #endregion

    #region Sub

    public class Sub : INotifyPropertyChanged
    {
        public string? wdesc { get; set; }

        public string? desc { get; set; }

        public Sub()
        {

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(
            [CallerMemberName] string? propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
    #endregion

    #region Model

    public class Attachment
    {
        public string? file_name { get; set; }

        public Attachment()
        {

        }
    }
    #endregion
}
