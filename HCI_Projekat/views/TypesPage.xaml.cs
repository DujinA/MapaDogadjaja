using HCI_Projekat.models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace HCI_Projekat.views
{
    /// <summary>
    /// Interaction logic for TypesPage.xaml
    /// </summary>
    public partial class TypesPage : Page
    {
        private ObservableCollection<EventType> typesList = new ObservableCollection<EventType>();
        private DatabaseEventType databaseEventType = new DatabaseEventType();
        private EventType eventType = new EventType();

        public TypesPage()
        {
            InitializeComponent();
            this.DataContext = this;
            loadItems();
        }

        private void loadItems()
        {
            foreach (var t in databaseEventType.getAll())
            {
                typesList.Add(t.Value);
            }
        }

        public ObservableCollection<EventType> TypesList
        {
            get
            {
                return typesList;
            }

            set { }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            AddType type = new AddType();
            type.Show();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            string message = "Da li ste sigurni da želite da uklonite selektovani tip dogadjaja?";
            string caption = "Potvrda";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            MessageBoxResult result = System.Windows.MessageBox.Show(message, caption, buttons, icon);

            if (result == MessageBoxResult.Yes)
            {
                typesList.Remove((EventType)dataGridType.SelectedItem);
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            databaseEventType.RemoveAll();
            foreach (EventType et in typesList)
            {
                databaseEventType.AddToDictionary(et);
            }
        }
    }
}