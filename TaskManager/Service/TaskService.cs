using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using TaskManager.Model;

namespace TaskManager.Service
{
    public interface TaskService
    {
        Button GetConfiguredButton(TaskGroup taskGroup, RoutedEventHandler function, RoutedEventHandler renameHandler, RoutedEventHandler deleteHandler);
        ContextMenu getConfiguredContextMenu(TaskGroup taskGroup, RoutedEventHandler renameHandler, RoutedEventHandler deleteHandler);
        bool isValidName(string val, List<TaskGroup> taskGroups);
        public int findTaskGroupByName(string value, List<TaskGroup> taskGroups);
        public List<TaskGroup> findTaskLikeDescription(String description);
        public List<TaskGroup> getComplitedTaskGroups();
        public List<Task> getComplitedTasks();

    }
}
