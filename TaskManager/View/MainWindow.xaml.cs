using System.Windows;
using System.Windows.Controls;
using TaskManager.Logic.Model;

namespace TaskManager.View
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            //TaskGroups.Items.Add(getButton(new TaskGroup("ASdasd")));
        }

        private Button getButton(TaskGroup taskGroup)
        {
            Button button = new Button();

            button.Content= taskGroup.Name;
            button.Width = 250;
            button.Height = 25;

            return button;
        }
    }
}
