using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;

namespace TaskManager.Model
{
    [Serializable]
    public class Task: INotifyPropertyChanged
    {
        private string _description;
        private bool _isComplite;
        private DateTime _dateOfCreation = DateTime.Now;
        private DateTime _deadLine;

        public DateTime DateOfCreation
        {
            get
            {
                return _dateOfCreation;
            }
            set
            {
           
                _dateOfCreation = value;
                
                OnPropertyChanged("DateOfCreation");
            }
        }

        public string DeadLine
        {
            get { 
                return _deadLine.ToString();
            }
            set
            {
                if (DateTime.TryParse(value, out _deadLine))
                    _deadLine = DateTime.Parse(value);

                else
                {
                    MessageBox.Show("Invalid Date format", "Error");
                    _deadLine = DateTime.Now;
                    return;
                }

                if (_dateOfCreation > _deadLine)
                {
                    MessageBox.Show("Deadline must be later than date of creation", "Error");
                    _deadLine = DateTime.Now;
                    return;
                }
                OnPropertyChanged("DeadLine");
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
            } 
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
