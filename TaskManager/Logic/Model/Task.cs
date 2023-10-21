using System;
using System.ComponentModel;

namespace TaskManager.Logic.Model
{
    [Serializable]
    internal class Task: INotifyPropertyChanged
    {
        private string _description;
        private bool _isComplite;

        public DateTime Date { get; set; } = DateTime.Now;
        public string Description { get
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
