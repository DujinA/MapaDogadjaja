using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace HCI_Projekat.models
{
    class DatabaseEvent
    {
        private Dictionary<string, Event> eventsDictionary = new Dictionary<string, Event>();
        private readonly string file;

        public DatabaseEvent()
        {
            file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DatabaseEvent.models");
            LoadFile();
        }

        public void AddToDictionary(Event e)
        {
            if (!eventsDictionary.ContainsKey(e.Id))
            {
                eventsDictionary.Add(e.Id, e);
                SaveFile();
            }
        }

        public void RemoveFromDictionary(Event e)
        {
            eventsDictionary.Remove(e.Id);
            SaveFile();
        }

        public Event this[string id]
        {
            get { return eventsDictionary[id]; }
            set { eventsDictionary[id] = value; }
        }

        public Dictionary<String, Event> getAll()
        {
            return eventsDictionary;
        }

        public void RemoveAll()
        {
            eventsDictionary.Clear();
            SaveFile();
        }

        public void SaveFile()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            try
            {
                stream = File.Open(file, FileMode.OpenOrCreate);
                formatter.Serialize(stream, eventsDictionary);
            }
            catch (SerializationException ex)
            {
                Console.WriteLine("Exception Message: " + ex.Message);
            }
            finally
            {
                if (stream != null)
                    stream.Dispose();
            }
        }

        private void LoadFile()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            if (File.Exists(file))
            {
                try
                {
                    stream = File.Open(file, FileMode.Open);
                    eventsDictionary = (Dictionary<String, Event>)formatter.Deserialize(stream);
                }
                catch (SerializationException ex)
                {
                    Console.WriteLine("Exception Message: " + ex.Message);
                }
                finally
                {
                    if (stream != null)
                        stream.Dispose();
                }

            }
            else
                eventsDictionary = new Dictionary<String, Event>();
        }
    }
}
