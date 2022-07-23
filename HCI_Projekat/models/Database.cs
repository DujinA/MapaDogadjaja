using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Projekat.models
{
    public class Database : INotifyPropertyChanged
    {
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private ObservableCollection<EventType> typesList;
        private ObservableCollection<Event> eventsList;
        private ObservableCollection<EventLabel> labelsList;
        private ObservableCollection<EventMap> mapsList;

        private static Database instance = null;

        public Database()
        {
            eventsList = new ObservableCollection<Event>();
            typesList = new ObservableCollection<EventType>();
            labelsList = new ObservableCollection<EventLabel>();
            mapsList = new ObservableCollection<EventMap>();
        }

        public static Database GetInstance()
        {
            if (instance == null)
            {
                instance = new Database();
                return instance;
            }
            else return instance;
        }

        public ObservableCollection<EventType> TypesList
        {
            get { return typesList; }
            set
            {
                typesList = value;
                OnPropertyChanged("TypesList");
            }
        }

        public ObservableCollection<EventLabel> LabelsList
        {
            get { return labelsList; }
            set
            {
                labelsList = value;
                OnPropertyChanged("LabelsList");
            }
        }

        public ObservableCollection<Event> GetEventsList
        {
            get { return eventsList; }
            set
            {
                eventsList = value;
                OnPropertyChanged("GetEventsList");
            }
        }
        
        public ObservableCollection<EventMap> MapsList
        {
            get { return mapsList; }
            set
            {
                mapsList = value;
                OnPropertyChanged("MapsList");
            }
        }

        public void Save(string filePath)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, instance);
            stream.Close();
        }

        public bool Load(string filePath)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None);
            var deserialized = formatter.Deserialize(stream) as Database;
            instance.GetEventsList = deserialized.GetEventsList;
            instance.TypesList = deserialized.TypesList;
            instance.LabelsList = deserialized.LabelsList;
            instance.MapsList = deserialized.MapsList;
            if(instance != null)
            {
                return true;
            }
            return false;
        }

        public bool HasEvent(Event _event)
        {
            foreach (var e in eventsList)
            {
                if (e.Id.Equals(_event.Id))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasEventId(string id)
        {
            foreach (var e in eventsList)
            {
                if (e.Id.Equals(id))
                {
                    return true;
                }
            }
            return false;
        }
        public bool HasEventType(EventType eventType)
        {
            foreach(var et in typesList)
            {
                if (et.Id.Equals(eventType.Id))
                {
                    return true;
                }
            }
            return false;
        }
        public bool HasEventTypeId(string id)
        {
            foreach(var et in typesList)
            {
                if (et.Id.Equals(id))
                {
                    return true;
                }
            }
            return false;
        }
        public bool HasEventLabel(EventLabel eventLabel)
        {
            foreach(var el in labelsList)
            {
                if (el.Id.Equals(eventLabel.Id))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
