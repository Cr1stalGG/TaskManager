using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
