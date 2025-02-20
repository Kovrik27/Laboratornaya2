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
    /// Логика взаимодействия для AddProject.xaml
    /// </summary>
    public partial class AddProject : Window
    {
        private ProjectsCRUD projectsCRUD;
        public Project Project { get; set; }
        public AddProject()
        {
            InitializeComponent();
            projectsCRUD = new ProjectsCRUD();
            Project = new Project();
            DataContext = this;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (Project != null )
            {
                projectsCRUD.AddProject(Project);

                MessageBox.Show("Проект успешно добавлен!");
                this.Close();
            }           
        }
    }
}
