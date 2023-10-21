using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using TaskManager.Logic.Model;
using TaskManager.Logic.Util;

namespace TaskManager.View
{

    public partial class MainWindow : Window
    {
        private static List<TaskGroup> taskGroups;

        public MainWindow()
        {
            InitializeComponent();

            taskGroups = (List<TaskGroup>)Serializer.deserialize();
            
            Draw();
            
        }

        private void Draw()
        {
            TaskGroups.Items.Clear();

            foreach (TaskGroup taskGroup in taskGroups)
            {
                TaskGroups.Items.Add(GetConfiguredButton(taskGroup));
            }

            Button addButton = new Button();

            addButton.Content = "Add task group";
            addButton.Width = 235;
            addButton.Height = 25;
            addButton.Click += AddTaskGroup;

            TaskGroups.Items.Add(addButton);
        }

        private void AddTaskGroup(object sender, RoutedEventArgs e)
        {
            TaskGroupConfigurer.Visibility = Visibility.Visible;

            TaskGroupName.Text = null;
        }

        private void CreateTaskGroup(object sender, RoutedEventArgs e)
        {
            if(!isValidName(TaskGroupName.Text))
            {
                MessageBox.Show("Invalid task group name!!!");
                return;
            }

            TaskGroup taskGroup = new TaskGroup(TaskGroupName.Text);

            MainWindow.taskGroups.Add(taskGroup);

            TaskGroupConfigurer.Visibility = Visibility.Hidden;

            Draw();
        }


        private Button GetConfiguredButton(TaskGroup taskGroup)
        {
            Button button = new Button();

            button.Content= taskGroup.Name;
            button.Width = 235;
            button.Height = 25;
            button.Tag = taskGroup.Name;

            button.ContextMenu = getConfiguredContextMenu(taskGroup);

            button.Click += OpenTaskGroup;

            return button;
        }

        private void Rename(object sender, RoutedEventArgs e)
        {

            RenameTaskGroup.Visibility = Visibility.Visible;

            MenuItem rename = (MenuItem)sender;

            NewTaskGroupName.Text = null;

            RenameButton.Tag = rename.Tag;
        }

        private bool isValidName(string val)
        {
            if (val == "")
                return false;

            if(val.Length > 32)
                return false;

            foreach (var taskGroup in taskGroups)
                if (taskGroup.Name == val)
                    return false;

            return true;
        }

        private void RenameButtonClick(object sender, RoutedEventArgs e)
        {
            Button renameButton = (Button)sender;

            if (!isValidName(NewTaskGroupName.Text))
            {
                MessageBox.Show("Invalid task group name!!!");
                return;
            }

            taskGroups[findTaskGroupByName(renameButton.Tag.ToString())].Name = NewTaskGroupName.Text;

            Draw();

            RenameTaskGroup.Visibility = Visibility.Hidden;

            Serializer.serialize(taskGroups);
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            MenuItem delete = (MenuItem)sender;

            taskGroups.RemoveAt(findTaskGroupByName(delete.Tag.ToString()));


            Draw();
        }

        private ContextMenu getConfiguredContextMenu(TaskGroup taskGroup)
        {
            ContextMenu menu = new ContextMenu();

            MenuItem rename = new MenuItem();
            rename.Header = "Rename";
            rename.Tag= taskGroup.Name;
            rename.Click += Rename;

            MenuItem delete = new MenuItem();
            delete.Header = "Delete";
            delete.Tag = taskGroup.Name;
            delete.Click += Delete;

            menu.Items.Add(rename);
            menu.Items.Add(delete);

            return menu;
        }

        private void OpenTaskGroup(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            int id = findTaskGroupByName(btn.Tag.ToString());

            Tasks.ItemsSource = taskGroups[id].Tasks;
            Tasks.Visibility = Visibility.Visible;

            taskGroups[id].Tasks.ListChanged += tasksListChanged;
        }

        private int findTaskGroupByName(string value)
        {
            for(int i = 0; i < taskGroups.Count; ++i)
            {
                if (taskGroups[i].Name == value)
                    return i;
            }

            return -1;
        }

        private void tasksListChanged(object sender, ListChangedEventArgs e)
        {
            Serializer.serialize(taskGroups);
        }
    }
}
