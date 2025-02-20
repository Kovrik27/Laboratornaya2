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
    /// Логика взаимодействия для AddTask.xaml
    /// </summary>
    public partial class AddTask : Window
    {
        private int projectId;
        public AddTask(int projectId)
        {
            InitializeComponent();
            this.projectId = projectId;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            //var task = new Task
            //{
            //    Title = TitleTextBox.Text,
            //    Description = DescriptionTextBox.Text,
            //    Responsible = ResponsibleTextBox.Text,
            //    Status = StatusTextBox.Text
            //};

            //var projectsCRUD = ProjectsCRUD.GetInstance();
            //projectsCRUD.AddTask(projectId, task);

            //MessageBox.Show("Задача успешно добавлена!");
            //this.Close();
        }
    }
}
