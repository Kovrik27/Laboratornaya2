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
    /// Логика взаимодействия для UpdateProject.xaml
    /// </summary>
    public partial class UpdateProject : Window
    {
        private Project project;
        private ProjectsCRUD projectsCRUD;
        public UpdateProject(Project project)
        {
            InitializeComponent();
            this.project = project;
            this.projectsCRUD = new ProjectsCRUD();
            this.DataContext = this.project;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            projectsCRUD.UpdateProject(project);
            this.Close();
        }
    }
}
