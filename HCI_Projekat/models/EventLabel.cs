using System;
using System.ComponentModel;
using System.Windows.Media;

namespace HCI_Projekat.models
{
    [Serializable]
    public class EventLabel : INotifyPropertyChanged
    {
        private string id;
        private string description;
        private string colorCode;
        private Color color;

        public EventLabel(string id, string description, Color color)
        {
            this.id = id;
            this.description = description;
            this.color = color;
            this.colorCode = color.ToString();
        }

        public EventLabel()
        {
            id = "";
            colorCode = "";
            description = "";
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

        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                if (value != color)
                {
                    color = value;
                    colorCode = color.ToString();
                    OnPropertyChanged("ColorCode");
                    OnPropertyChanged("Color");
                }
            }
        }

        public string ColorCode
        {
            get { return colorCode; }
            set
            {
                colorCode = value;
                var convertFromString = ColorConverter.ConvertFromString(colorCode);
                if (convertFromString != null)
                    color = (Color)convertFromString;

                OnPropertyChanged("ColorCode");
                OnPropertyChanged("Color");
            }
        }

        public override string ToString()
        {
            return id + color.ToString();
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
