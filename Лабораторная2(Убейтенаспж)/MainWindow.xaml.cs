using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Лабораторная2_Убейтенаспж_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ProjectsCRUD projectsCRUD = new ProjectsCRUD();
        private ObservableCollection<Project> _projects = new ObservableCollection<Project>();
        private Project _project;
        public ObservableCollection<Employee> Employees { get; set; }
        public ObservableCollection<Project> Projects
        {
            get => _projects;
            set
            {
                _projects = value;
                OnPropertyChanged(nameof(Projects));
            }
        }

        public Project Project
        {
            get => _project;
            set
            {
                _project = value;
                OnPropertyChanged(nameof(Project));
            }
        }


        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            GetData();

            Employees = new ObservableCollection<Employee>
           {
               new Employee { FIO = "Нуянцева Е.В.", Role = "Владелец" },
               new Employee { FIO = "Ермолаева М.А.", Role = "Владелец" }
           };
        }

        private async void GetData()
        {
            var newProjects = await projectsCRUD.GetAllProjects();
            Projects.Clear();
            foreach (var project in newProjects)
            {
                Projects.Add(project);
            }
        }

        private void OpenAddProject(object sender, RoutedEventArgs e)
        {
            //AddProject addProject = new AddProject();
            //addProject.Show();
            MessageBox.Show("Эта функция в разработке, поскольку за много часов я её не починила... Спрошу у Пушкина... Потыкайте другие...");
        }

        private void OpenUpdateProject(object sender, RoutedEventArgs e)
        {
            if (Project == null)
                return;

            UpdateProject updateProject = new UpdateProject(Project);
            updateProject.Show();
        }

        private void OpenTasksProject(object sender, RoutedEventArgs e)
        {
            if (Project == null)
                return;

            TasksProject tasksProject = new TasksProject(Project);
            tasksProject.Show();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void DeleteProject(object sender, RoutedEventArgs e)
        {
            if (Project == null)
                return;
            projectsCRUD.DeleteProject(Project);
            OnPropertyChanged(nameof(Project));
            OnPropertyChanged(nameof(Projects));
            GetData();
        }

        private void EmployeeListButton_Click(object sender, RoutedEventArgs e)
        {
            var employeeListPage = new EmployeeList(Employees);
            MainFrame.Navigate(employeeListPage);
        }
    }
}

