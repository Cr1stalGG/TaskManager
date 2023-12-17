using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using TaskManager.Model;
using TaskManager.Service;
using TaskManager.Util;

namespace TaskManager.View
{
    public partial class MainWindow : Window
    {
        private static List<TaskGroup> taskGroups;
        private TaskService taskService;

        public MainWindow()
        {
            InitializeComponent();

            taskGroups = (List<TaskGroup>)Serializer.deserialize();
            taskService = new TaskServiceImpl();

            Draw();
        }

        private void FindTaskClick(object sender, RoutedEventArgs e)
        {
            FindTaskPanel.Visibility = Visibility.Visible;
        }
        private void FindTaskButtonClick(object sender, RoutedEventArgs e)
        {
            ShowInfo.ItemsSource = taskService.findTaskByDescription(InputTaskDescription.Text, taskGroups);

            HideAll();
            ShowInfo.Visibility = Visibility.Visible;
        }

        private void GetComplitedTasksClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void GetUncomplitedTasksClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void GetComplitedTaskGroups(object sender, RoutedEventArgs e)
        {
           
        }

        private void Draw()
        {
            TaskGroups.Items.Clear();

            foreach (TaskGroup taskGroup in taskGroups)
            {
                TaskGroups.Items.Add(taskService.GetConfiguredButton(taskGroup, OpenTaskGroup, Rename, Delete));
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

        private void CreateBackClick(object sender, RoutedEventArgs e)
        {
            TaskGroupConfigurer.Visibility = Visibility.Hidden;

        }

        private void RenameBackClick(object sender, RoutedEventArgs e)
        {
            RenameTaskGroup.Visibility = Visibility.Hidden;
        }

        private void CreateTaskGroup(object sender, RoutedEventArgs e)
        {
            if(!taskService.isValidName(TaskGroupName.Text, taskGroups))
            {
                MessageBox.Show("Invalid task group name!!!");
                return;
            }

            TaskGroup taskGroup = new TaskGroup(TaskGroupName.Text);

            MainWindow.taskGroups.Add(taskGroup);

            TaskGroupConfigurer.Visibility = Visibility.Hidden;

            Draw();
        }

        private void HideAll()
        {
            Tasks.Visibility = Visibility.Hidden;
            ShowInfo.Visibility = Visibility.Hidden;
            FindTaskPanel.Visibility = Visibility.Hidden;
        }

        private void Rename(object sender, RoutedEventArgs e)
        {

            RenameTaskGroup.Visibility = Visibility.Visible;

            MenuItem rename = (MenuItem)sender;

            NewTaskGroupName.Text = null;

            RenameButton.Tag = rename.Tag;

            Serializer.serialize(taskGroups);
        }

        private void RenameButtonClick(object sender, RoutedEventArgs e)
        {
            Button renameButton = (Button)sender;

            if (!taskService.isValidName(NewTaskGroupName.Text, taskGroups))
            {
                MessageBox.Show("Invalid task group name!!!");
                return;
            }

            taskGroups[taskService.findTaskGroupByName(renameButton.Tag.ToString(), taskGroups)].Name = NewTaskGroupName.Text;

            Draw();

            RenameTaskGroup.Visibility = Visibility.Hidden;

            Serializer.serialize(taskGroups);
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            MenuItem delete = (MenuItem)sender;

            taskGroups.RemoveAt(taskService.findTaskGroupByName(delete.Tag.ToString(), taskGroups));

            Serializer.serialize(taskGroups);
            Draw();
        }

        private void OpenTaskGroup(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            int id = taskService.findTaskGroupByName(btn.Tag.ToString(), taskGroups);

            Tasks.ItemsSource = taskGroups[id].Tasks;

            HideAll();

            Tasks.Visibility = Visibility.Visible;

            taskGroups[id].Tasks.ListChanged += tasksListChanged;
        }

        private void tasksListChanged(object sender, ListChangedEventArgs e)
        {
            Serializer.serialize(taskGroups);
        }

    }
}
