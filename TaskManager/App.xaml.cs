using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using TaskManager.Model;

namespace TaskManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //code
            List<TaskGroup> list = new List<TaskGroup>();

            base.OnStartup(e);
        }

    }
}
