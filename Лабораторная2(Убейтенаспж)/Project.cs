using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная2_Убейтенаспж_
{
    public class Project : INotifyPropertyChanged
    {
        private int _id;
        private string _title;
        private string _description;
        private string _dateStart;
        private string _dateEnd;
        private string _budget;
        private string _status;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public string DateStart
        {
            get => _dateStart;
            set
            {
                _dateStart = value;
                OnPropertyChanged(nameof(DateStart));
            }
        }

        public string DateEnd
        {
            get => _dateEnd;
            set
            {
                _dateEnd = value;
                OnPropertyChanged(nameof(DateEnd));
            }
        }

        public string Budget
        {
            get => _budget;
            set
            {
                _budget = value;
                OnPropertyChanged(nameof(Budget));
            }
        }

        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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
