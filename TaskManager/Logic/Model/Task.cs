using System;
using System.ComponentModel;

namespace TaskManager.Logic.Model
{
    [Serializable]
    internal class Task: INotifyPropertyChanged
    {
        private string _description;
        private bool _isComplite;
        private DateTime _date = DateTime.Now;

        public DateTime Date { 
            get {
                return _date;
            } 
            set {
                _date = value;
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
                OnPropertyChanged("IsComplite");
            } }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
