using System;
using System.ComponentModel;

namespace TaskManager.Logic.Model
{
    [Serializable]
    internal class TaskGroup
    {
        public string Name { get; set; }
        public BindingList<Task> Tasks { get; set; }

        public TaskGroup() 
        { 
            this.Name = string.Empty;
            this.Tasks = new BindingList<Task>();
        }

        public TaskGroup(string Name)
        {
            this.Name = Name;
            this.Tasks = new BindingList<Task>();
        }

        public TaskGroup(string Name, BindingList<Task> Tasks)
        {
            this.Name = Name;
            this.Tasks = Tasks;
        }

        public void AddTask(Task task)
        {
            this.Tasks.Add(task);
        }

    }
}
