using System;
using System.ComponentModel;

namespace TaskManager.Model
{
    [Serializable]
    public class Task: INotifyPropertyChanged
    {
        private string _description;
        private bool _isComplite;
        private DateTime _dateOfCreation = DateTime.Now;
        private DateTime _dateOfComplite;

        public DateTime DateOfComplite
        {
            get { 
                return _dateOfComplite;
            }
            set
            {
                _dateOfComplite = value;
                OnPropertyChanged("DateOfComplite");
            }
        }

        public DateTime DateOfCreation { 
            get {
                return _dateOfCreation;
            } 
            set {
                _dateOfCreation = value;

                OnPropertyChanged("DateOfCreation");
            } 
        }
        public string Description {
            get
            {
                return _description;
            }
            set
            {
                if(_description == value)
                    return;

                _description = value;
                this.OnPropertyChanged("Description");
            }
        }
        public bool IsComplite { 
            get 
            {
                return _isComplite;
            }
            set 
            {
                if (_isComplite == value)
                    return;

                _isComplite = value;

                if(_isComplite)
                    _dateOfComplite = DateTime.Now;

                OnPropertyChanged("IsComplite");
            } 
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
