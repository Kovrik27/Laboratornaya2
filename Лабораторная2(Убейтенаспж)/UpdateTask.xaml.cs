using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Лабораторная2_Убейтенаспж_
{
    /// <summary>
    /// Логика взаимодействия для UpdateTask.xaml
    /// </summary>
    public partial class UpdateTask : Window
    {
        private Task task;
        private Project project;
        private ProjectsCRUD projectsCRUD;
        public UpdateTask(Task task, Project project)
        {
            InitializeComponent();
            this.task = task;
            this.projectsCRUD = new ProjectsCRUD();
            this.DataContext = this.task;
            this.project = project;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            projectsCRUD.UpdateTask(task, project);
            this.Close();
        }
    }
}
