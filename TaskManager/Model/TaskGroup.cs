using System;
using System.ComponentModel;

namespace TaskManager.Model
{
    [Serializable]
    public class TaskGroup
    {
        private string _name;
        private BindingList<Task> _tasks;

        public string Name {
            get {
                return _name;
            }
            set {
                _name = value;
            }
        }
        public BindingList<Task> Tasks { 
            get {
                return this._tasks;
            }
            set { 
                this._tasks = value;
            } }

        public TaskGroup() 
        { 
            this._name = string.Empty;
            this._tasks = new BindingList<Task>();
        }

        public TaskGroup(string Name)
        {
            this._name = Name;
            this._tasks = new BindingList<Task>();
        }

        public TaskGroup(string Name, BindingList<Task> Tasks)
        {
            this._name = Name;
            this._tasks = Tasks;
        }

        public void AddTask(Task task)
        {
            this._tasks.Add(task);
        }

    }
}
