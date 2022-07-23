using HCI_Projekat.models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace HCI_Projekat.views
{
    /// <summary>
    /// Interaction logic for LabelsPage.xaml
    /// </summary>
    public partial class LabelsPage : Page
    {
        private ObservableCollection<EventLabel> labelsList = new ObservableCollection<EventLabel>();
        private DatabaseEventLabel databaseEventLabel = new DatabaseEventLabel();
        private EventLabel eventLabel = new EventLabel();

        public LabelsPage()
        {
            InitializeComponent();
            this.DataContext = this;
            loadItems();
        }

        private void loadItems()
        {
            foreach (var l in databaseEventLabel.getAll())
            {
                labelsList.Add(l.Value);
            }
        }

        public ObservableCollection<EventLabel> LabelsList
        {
            get
            {
                return labelsList;
            }

            set { }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            string message = "Da li želite da uklonite selektovanu etiketu dogadjaja?";
            string caption = "Potvrda";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            MessageBoxResult result = System.Windows.MessageBox.Show(message, caption, buttons, icon);

            if (result == MessageBoxResult.Yes)
            {
                labelsList.Remove((EventLabel)dataGridLabel.SelectedItem);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            AddLabel l = new AddLabel();
            l.Show();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            databaseEventLabel.RemoveAll();
            foreach (EventLabel el in labelsList)
            {
                databaseEventLabel.AddToDictionary(el);
            }
        }
    }
}