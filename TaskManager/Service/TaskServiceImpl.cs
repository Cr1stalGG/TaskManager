using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Linq;
using TaskManager.Model;

namespace TaskManager.Service
{
    public class TaskServiceImpl : TaskService
    {
        public Button GetConfiguredButton(TaskGroup taskGroup, RoutedEventHandler function, RoutedEventHandler renameHandler, RoutedEventHandler deleteHandler)
        {
            Button button = new Button();

            button.Content = taskGroup.Name;
            button.Width = 235;
            button.Height = 25;

            BrushConverter bc = new BrushConverter();
            Brush brush = (Brush)bc.ConvertFrom("#FF7938");
            brush.Freeze();

            button.Background = brush;
            button.Foreground = Brushes.White;

            button.Tag = taskGroup.Name;

            button.ContextMenu = getConfiguredContextMenu(taskGroup, renameHandler, deleteHandler);

            button.Click += function;

            return button;
        }

        public ContextMenu getConfiguredContextMenu(TaskGroup taskGroup, RoutedEventHandler renameHandler, RoutedEventHandler deleteHandler)
        {
            ContextMenu menu = new ContextMenu();

            MenuItem rename = new MenuItem();
            rename.Header = "Rename";
            rename.Tag = taskGroup.Name;
            rename.Click += renameHandler;

            MenuItem delete = new MenuItem();
            delete.Header = "Delete";
            delete.Tag = taskGroup.Name;
            delete.Click += deleteHandler;

            menu.Items.Add(rename);
            menu.Items.Add(delete);

            return menu;
        }

        public bool isValidName(string val, List<TaskGroup> taskGroups)
        {
            if (val == "")
                return false;

            if (val.Length > 32)
                return false;

            foreach (var taskGroup in taskGroups)
                if (taskGroup.Name == val)
                    return false;

            return true;
        }

        public int findTaskGroupByName(string value, List<TaskGroup> taskGroups)
        {
            for (int i = 0; i < taskGroups.Count; ++i)
            {
                if (taskGroups[i].Name == value)
                    return i;
            }

            return -1;
        }
    }
}
