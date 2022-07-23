using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using HCI_Projekat.models;

namespace HCI_Projekat.views
{
    /// <summary>
    /// Interaction logic for AddLabel.xaml
    /// </summary>
    public partial class AddLabel : Window
    {
        private EventLabel eventLabel = new EventLabel();
        private DatabaseEventLabel databaseEventLabel = new DatabaseEventLabel();
        private Regex regexId = new Regex("[^a-z0-9]+");
        public AddLabel()
        {
            InitializeComponent();
            this.DataContext = eventLabel;
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {

            bool idSavingPermission = false;

            int permission = -1;

            string id = textBox1.Text;
            if (id != "")
            {
                idSavingPermission = true;
                if (databaseEventLabel.getAll().Count() != 0)
                {

                    foreach (var l in databaseEventLabel.getAll())
                    {
                        if (id.Equals(l.Value.Id.ToString()))
                        {
                            idSavingPermission = false;
                            permission = 1;
                            break;
                        }

                    }
                }
            }


            if (idSavingPermission == true)
            {
                databaseEventLabel.AddToDictionary(eventLabel);
                string message = "Etiketa sa oznakom " + textBox1.Text + " je kreirana!";
                string caption = "Obavestenje!";
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = System.Windows.MessageBox.Show(message, caption, buttons, icon);
                Close();
            }
            else if (permission == 1)
            {
                string message = "Oznaka dogadjaja koju ste uneli je zauzeta!";
                string caption = "Obavestenje!";
                ShowError(message, caption);
                textBox1.Focus();
            }
            else if (textBox1.Text.ToString() == "")
            {
                string message = "Polje oznaka ne sme biti prazno!";
                string caption = "Obavestenje!";
                ShowError(message, caption);
                textBox1.Focus();
            }

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }



        private void ShowError(string message, string caption)
        {
            MessageBoxButton buttons = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Error;
            MessageBoxResult result = System.Windows.MessageBox.Show(message, caption, buttons, icon);
        }

        private void textBox2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (textBox2.Text.Count() > 250)
            {
                string message = "Opis etikete ne sme imati vise od 250 karaktera!";
                string caption = "Obavestenje!";
                ShowError(message, caption);
                textBox2.Clear();
                textBox2.Focus();
            }
        }

        private void textBox1_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            e.Handled = regexId.IsMatch(e.Text);

            if (textBox1.Text.Count() > 20)
            {
                string message = "Oznaka etikete ne sme imati vise od 20 karaktera!";
                string caption = "Obavestenje!";
                ShowError(message, caption);
                textBox1.Clear();
                textBox1.Focus();
            }
        }
    }
}
