using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace HCI_Projekat.models
{
    [Serializable]
    public class Event : INotifyPropertyChanged
    {
        private string id;
        private string name;
        private string description;
        private EventType type;
        public string attendance;
        private string iconPath;
        private bool humanitarianEvent;
        private string cost;
        private string country;
        private string city;
        private bool iconType;
        private DateTime date;
        private ObservableCollection<EventLabel> labels;

        public Event(string id, string name, string description, EventType type, string attendance, string iconPath, bool humanitarianEvent, string cost, string country, string city, bool iconType, DateTime date)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.type = type;
            this.attendance = attendance;
            this.iconPath = iconPath;
            this.humanitarianEvent = humanitarianEvent;
            this.cost = cost;
            this.country = country;
            this.city = city;
            this.iconType = iconType;
            this.date = date;
            Labels = new ObservableCollection<EventLabel>();
        }

        public Event()
        {
            this.id = "prazno";
            this.name = "prazno";
            this.description = "prazno";
            this.iconPath = "prazno";
            this.humanitarianEvent = true;
            this.cost = "prazno";
            this.country = "prazno";
            this.city = "prazno";
            this.iconType = false;
            Labels = new ObservableCollection<EventLabel>();
        }

        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (value != description)
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        public EventType Type
        {
            get
            {
                return type;
            }
            set
            {

                type = value;
                OnPropertyChanged("Type");
            }

        }

        public string Attendance
        {
            get
            {
                return attendance;
            }
            set
            {
                if (value != attendance)
                {
                    attendance = value;
                    OnPropertyChanged("Attendance");
                }
            }
        }

        public string IconPath
        {
            get
            {
                return iconPath;
            }
            set
            {
                if (value != iconPath)
                {
                    iconPath = value;
                    OnPropertyChanged("IconPath");
                }

            }
        }

        public bool HumanitarianEvent
        {
            get
            {
                return humanitarianEvent;
            }
            set
            {
                if (value != humanitarianEvent)
                {
                    humanitarianEvent = value;
                    OnPropertyChanged("HumanitarianEvent");
                }
            }
        }

        public string Cost
        {
            get
            {
                return cost;
            }

            set
            {

                if (value != cost)
                {
                    cost = value;
                    OnPropertyChanged("Cost");
                }
            }
        }

        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                if (value != country)
                {
                    country = value;
                    OnPropertyChanged("Country");
                }
            }
        }

        public string City
        {
            get
            {
                return city;
            }
            set
            {
                if (value != city)
                {
                    city = value;
                    OnPropertyChanged("City");
                }
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                if (value != date)
                {
                    date = value;
                    OnPropertyChanged("Date");
                }
            }
        }

        public ObservableCollection<EventLabel> Labels
        {
            get
            {
                return labels;
            }
            set
            {
                if (value != labels)
                {
                    labels = value;
                    OnPropertyChanged("Labels");
                }
            }
        }

        public bool IconType
        {
            get { return iconType; }
            set
            {
                if(value != iconType)
                {
                    iconType = value;
                    OnPropertyChanged("IconType");
                }
            }
        }
        public void AddLabel(EventLabel label)
        {
            this.labels.Add(label);
        }

        public override string ToString()
        {
            return Name;
        }

        [field: NonSerialized] public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}