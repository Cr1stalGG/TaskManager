namespace TaskManager.Logic.Model
{
    internal class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool isComplite { get; set; }
    
        public Task()
        {
            this.Title = string.Empty;
            this.Description = string.Empty;
            this.isComplite = false;
        }

        public Task(string Title, string Description)
        {
            this.Title = Title;
            this.Description = Description;
            this.isComplite = false;
        }
    }
}
