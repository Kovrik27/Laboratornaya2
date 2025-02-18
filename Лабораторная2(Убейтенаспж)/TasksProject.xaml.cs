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
using System.Windows.Shapes;

namespace Лабораторная2_Убейтенаспж_
{
    /// <summary>
    /// Логика взаимодействия для TasksProject.xaml
    /// </summary>
    public partial class TasksProject : Window
    {
        private Project project;
        private ProjectsCRUD projectsCRUD = new ProjectsCRUD();
        public TasksProject(Project project)
        {
            InitializeComponent();
            this.DataContext = project;
            this.project = project;
        }

        private ObservableCollection<Task> tasks = new ObservableCollection<Task>();
        private Task task;

        public ObservableCollection<Task> Tasks
        {
            get => tasks;
            set
            {
                tasks = value;
                OnPropertyChanged(nameof(Tasks));
            }
        }

        public Task Task
        {
            get => task;
            set
            {
                task = value;
                OnPropertyChanged(nameof(Task));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OpenAddTask(object sender, RoutedEventArgs e)
        {
            int projectId = project.Id;
            AddTask addTask = new AddTask(projectId);
            addTask.Show();
        }

        private void OpenUpdateTask(object sender, RoutedEventArgs e)
        {
            if (Task == null)
                return;

            UpdateTask updateTask = new UpdateTask(Task);
            updateTask.Show();
        }

        private void DeleteTask(object sender, RoutedEventArgs e)
        {
            if (Task == null)
                return;
            projectsCRUD.DeleteTask(Task);
            OnPropertyChanged(nameof(Task));
            OnPropertyChanged(nameof(Tasks));
        }

    }
}
