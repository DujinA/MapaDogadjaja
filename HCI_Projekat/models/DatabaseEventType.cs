using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace HCI_Projekat.models
{
    class DatabaseEventType
    {
        private Dictionary<string, EventType> typesDictionary = new Dictionary<string, EventType>();
        private readonly string file;

        public DatabaseEventType()
        {
            file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DatabaseEventType.models");
            LoadFile();
        }

        public void AddToDictionary(EventType et)
        {
            if (!typesDictionary.ContainsKey(et.Id))
            {
                typesDictionary.Add(et.Id, et);
                SaveFile();
            }
        }

        public void RemoveFromDictionary(EventType et)
        {
            typesDictionary.Remove(et.Id);
            SaveFile();
        }

        public EventType this[string id]
        {
            get { return typesDictionary[id]; }
            set { typesDictionary[id] = value; }
        }

        public Dictionary<String, EventType> getAll()
        {
            return typesDictionary;
        }

        public void RemoveAll()
        {
            typesDictionary.Clear();
            SaveFile();

        }

        public void SaveFile()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            try
            {
                stream = File.Open(file, FileMode.OpenOrCreate);
                formatter.Serialize(stream, typesDictionary);
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
                    typesDictionary = (Dictionary<String, EventType>)formatter.Deserialize(stream);
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
                typesDictionary = new Dictionary<String, EventType>();
        }
    }
}
