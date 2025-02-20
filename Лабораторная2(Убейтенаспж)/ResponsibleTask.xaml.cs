using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для ResponsibleTask.xaml
    /// </summary>
    public partial class ResponsibleTask : Window
    {
        private Task _task;

        public ResponsibleTask(Task task, ObservableCollection<Employee> employees)
        {
            InitializeComponent();
            _task = task;
            EmployeeComboBox.ItemsSource = employees;
            EmployeeComboBox.SelectedItem = _task.Responsible;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _task.Responsible = (Employee)EmployeeComboBox.SelectedItem;
            MessageBox.Show($"Ответственный за задачу '{_task.Title}' назначен: {_task.Responsible.FIO}");
            this.Close();
        }
    }
}
