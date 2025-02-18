using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная2_Убейтенаспж_
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DateStart { get; set; }
        public string DateEnd { get; set;}
        public string Budget { get; set; }
        public string Status { get; set; }

        public ObservableCollection<Task> Tasks { get; set; }

        public Project() 
        {
            Tasks = new ObservableCollection<Task>();
        }

       public ObservableCollection<Task> GetData()
        {
            return Tasks;
        }
    }
}
