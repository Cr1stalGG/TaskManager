using System.Collections.Generic;

namespace TaskManager.Logic.Model
{
    internal class TaskGroup
    {
        public string Name { get; set; }
        public List<Task> Tasks { get; set; }

        public TaskGroup() 
        { 
            this.Name = string.Empty;
            this.Tasks = new List<Task>();
        }

        public TaskGroup(string Name)
        {
            this.Name = Name;
            this.Tasks = new List<Task>();
        }

        public TaskGroup(string Name, List<Task> Tasks)
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
