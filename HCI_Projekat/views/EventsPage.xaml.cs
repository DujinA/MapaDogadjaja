using HCI_Projekat.models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace HCI_Projekat.views
{
    public partial class EventsPage : Page
    {
        private ObservableCollection<Event> eventsList = new ObservableCollection<Event>();
        private DatabaseEvent databaseEvent = new DatabaseEvent();
        private OpenFileDialog fileDialog = new OpenFileDialog();

        private Regex regexDate = new Regex(@"^(0?[1-9]|[12][0-9]|3[01])\-(0?[1-9]|1[012])\-\d{4}$");

        public EventsPage()
        {
            InitializeComponent();
            this.DataContext = this;
            loadItems();
        }

        private void loadItems()
        {
            foreach (var e in databaseEvent.getAll())
            {
                eventsList.Add(e.Value);
            }
        }

        public ObservableCollection<Event> EventsList
        {
            get
            {
                return eventsList;
            }

            set { }
        }

        public List<String> AttendanceList
        {
            get
            {
                return Event.attendanceList;
            }
            private set { }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            AddEvent addEvent = new AddEvent();
            addEvent.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            string message = "Da li ste sigurni da želite da uklonite selektovani dogadjaj?";
            string caption = "Potvrda";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            MessageBoxResult result = System.Windows.MessageBox.Show(message, caption, buttons, icon);

            if (result == MessageBoxResult.Yes)
            {
                eventsList.Remove((Event)dataGridEvent.SelectedItem);
            }
        }

        private void dataGridEvent_SelectionChanged()
        {

        }

        private void textBox6_TextChanged()
        {

        }
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            databaseEvent.RemoveAll();
            foreach (Event _event in eventsList)
            {
                databaseEvent.AddToDictionary(_event);
            }
        }

    }
}