using System;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace HCI_Projekat.models
{
    [Serializable]
    public class EventType : INotifyPropertyChanged
    {
        private string id;
        private string name;
        private string description;
        private string iconPath;

        public EventType(string id, string name, string description, string iconPath)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.iconPath = iconPath;
        }

        public EventType()
        {
            id = "";
            name = "";
            description = "";
            iconPath = "";
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
                    foreach(var _event in Database.GetInstance().GetEventsList)
                    OnPropertyChanged("IconPath");
                }
            }
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
