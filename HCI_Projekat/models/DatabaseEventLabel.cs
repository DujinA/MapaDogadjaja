using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace HCI_Projekat.models
{
    class DatabaseEventLabel
    {
        private Dictionary<string, EventLabel> labelsDictionary = new Dictionary<string, EventLabel>();
        private readonly string file;

        public DatabaseEventLabel()
        {
            file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DatabaseEventLabel.models");
            LoadFile();
        }

        public void AddToDictionary(EventLabel el)
        {
            if (!labelsDictionary.ContainsKey(el.Id))
            {
                labelsDictionary.Add(el.Id, el);
                SaveFile();
            }
        }

        public void RemoveFromDictionary(EventLabel el)
        {
            labelsDictionary.Remove(el.Id);
            SaveFile();
        }

        public EventLabel this[string id]
        {
            get { return labelsDictionary[id]; }
            set { labelsDictionary[id] = value; }
        }

        public Dictionary<String, EventLabel> getAll()
        {
            return labelsDictionary;
        }

        public void RemoveAll()
        {
            labelsDictionary.Clear();
            SaveFile();
        }

        public void SaveFile()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            try
            {
                stream = File.Open(file, FileMode.OpenOrCreate);
                formatter.Serialize(stream, labelsDictionary);
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
                    labelsDictionary = (Dictionary<String, EventLabel>)formatter.Deserialize(stream);
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
                labelsDictionary = new Dictionary<String, EventLabel>();
        }
    }
}
