using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HCI_Projekat.models
{
    [Serializable]
    public class EventMap : INotifyPropertyChanged 
    {
        private Event eventOnMap;
        private Point coordiantesPoint;

        public EventMap()
        {
            eventOnMap = new Event();
            coordiantesPoint = new Point(0, 0);
        }

        public EventMap(Event eventOnMap, Point coordinatesPoint)
        {
            this.eventOnMap = eventOnMap;
            this.coordiantesPoint = coordinatesPoint;
        }

        public Event EventOnMap
        {
            get { return eventOnMap; }
            set
            {
                eventOnMap = value;
                OnPropertyChanged("EventOnMap");
            }
        }

        public Point CoordinatesPoint
        {
            get { return coordiantesPoint; }
            set
            {
                coordiantesPoint = value;
                OnPropertyChanged("CoordinatesPoint");
            }
        }

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
