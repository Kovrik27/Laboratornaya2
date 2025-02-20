using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная2_Убейтенаспж_
{
    public class ProjectsCRUD : INotifyPropertyChanged
    {
        private static ProjectsCRUD instance;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Project> Projects { get; set; }
        private Project Project {  get; set; }

        public ProjectsCRUD()         
        {
            Projects = new ObservableCollection<Project>
            {
                new Project
                {
                    Id = 1,
                    Title = "Хиханьки да хахоньки",
                    Description = "Мой первый проект не судите строга",
                    Budget = "1 шефбургер джуниор",
                    DateStart = "30.02.2025",
                    DateEnd = "30.02.2025",
                    Status = "Бюджет не позволяет",
                    Tasks = new ObservableCollection<Task> { new Task {Id = 1, Title = "Начать проект", Description = "По желанию", Responsible = "Ермолаева М.А.", Status = "Скоро" } }
                }
            };
        }


       public static ProjectsCRUD GetInstance()
        {
            if (instance == null)
                instance = new ProjectsCRUD();
            return instance;
        }

        public async Task<ObservableCollection<Project>> GetAllProjects()
        {
            return new ObservableCollection<Project>(Projects);
        }

        public async void AddProject(Project project)
        {
            Project newProject = new Project()
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                Budget = project.Budget,
                DateStart = project.DateStart,
                DateEnd = project.DateEnd,
                Status = project.Status,
            };
            Projects.Add(newProject);
            OnPropertyChanged(nameof(Projects));
            
        }

        public async void UpdateProject(Project project)
        {
            var projectOld = Projects.FirstOrDefault(s => s.Id == project.Id);
            if (projectOld == null)
                return;
            else
            {
                projectOld.Id = project.Id;
                projectOld.Title = project.Title;
                projectOld.Description = project.Description;
                projectOld.Budget = project.Budget;
                projectOld.DateStart = project.DateStart;
                projectOld.DateEnd = project.DateEnd;
                projectOld.Status = project.Status;
            }
        }

        public async void DeleteProject(Project project)
        {
            var projectKill = Projects.FirstOrDefault(s => s.Id == project.Id);
            if (project.Id == projectKill.Id)
            {
                Projects.Remove(project);
            }
        }

        public async void AddTask(int projectId, Task task)
        {
            var project = Projects.FirstOrDefault(s => s.Id == projectId);
            if (project != null)
            {
                var tasks = project.GetData();
                task.Id = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1;
                tasks.Add(task);
            }
        }

        public async void UpdateTask(Task task)
        {
            var taskOld = Project.Tasks.FirstOrDefault(s => s.Id == task.Id);
            if (taskOld == null)
                return;
            else
            {
                taskOld.Id = task.Id;
                taskOld.Title = task.Title;
                taskOld.Description = task.Description;
                taskOld.Responsible = task.Responsible;
                taskOld.Status = task.Status;
            }
        }

        public async void DeleteTask(Task task)
        {
            var taskKill = Project.Tasks.FirstOrDefault(s => s.Id == task.Id);
            if (task.Id == taskKill.Id)
            {
                Project.Tasks.Remove(task);
            }
        }



    }
}
