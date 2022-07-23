using HCI_Projekat.models;
using Microsoft.Win32;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace HCI_Projekat.views
{
    /// <summary>
    /// Interaction logic for AddType.xaml
    /// </summary>
    public partial class AddType : Window
    {
        private EventType eventType = new EventType();
        private DatabaseEventType databaseEventType = new DatabaseEventType();
        private OpenFileDialog fileDialog = new OpenFileDialog();

        private Regex regexId = new Regex("[^a-z0-9]+");

        public AddType()
        {
            InitializeComponent();
            this.DataContext = eventType;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            bool idSavingPermission = false;
            bool nameSavingPermission = false;

            int permission = -1;

            string id = textBox1.Text;
            if (id != "")
            {
                idSavingPermission = true;
                if (databaseEventType.getAll().Count() != 0)
                {
                    foreach (var t in databaseEventType.getAll())
                    {
                        if (id.Equals(t.Value.Id.ToString()))
                        {
                            idSavingPermission = false;
                            permission = 1;
                            break;
                        }
                    }
                }
            }

            if (textBox2.Text.ToString() != "")
            {
                nameSavingPermission = true;
            }
            else
            {
                nameSavingPermission = false;
            }

            if (idSavingPermission == true && nameSavingPermission == true)
            {
                databaseEventType.AddToDictionary(eventType);
                string message = "Tip dogadjaja " + textBox2.Text + " je kreiran!";
                string caption = "Obavestenje!";
                MessageBoxButton buttons = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon);
                Close();
            }
            else if (permission == 1)
            {
                string message = "Oznaka dogadjaja koju ste uneli je zauzeta!";
                string caption = "Obavestenje!";
                ShowError(message, caption);
                textBox1.Focus();
            }
            else if (textBox1.Text.ToString() == "" && textBox2.Text.ToString() == "")
            {
                string message = "Polja za oznaku i naziv tipa ne smeju biti prazni!";
                string caption = "Obavestenje!";
                ShowError(message, caption);
                textBox1.Focus();
            }
            else if (textBox2.Text.ToString() == "" && textBox1.Text.ToString() != "")
            {
                string message = "Naziv tipa dogadjaja ne sme biti prazan!";
                string caption = "Obavestenje!";
                ShowError(message, caption);
                textBox2.Focus();
            }
            else if (textBox1.Text.ToString() == "" && textBox2.Text.ToString() != "")
            {
                string message = "Polje oznaka ne sme biti prazno!";
                string caption = "Obavestenje!";
                ShowError(message, caption);
                textBox1.Focus();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (fileDialog.ShowDialog() == true)
            {
                string fname = fileDialog.FileName;
                image1.Source = new BitmapImage(new Uri(fname));
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void textBox1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = regexId.IsMatch(e.Text);

            if (textBox1.Text.Count() > 20)
            {
                string message = "Oznaka tipa dogadjaja ne sme imati vise od 20 karaktera!";
                string caption = "Obavestenje!";
                ShowError(message, caption);
                textBox1.Clear();
                textBox1.Focus();
            }
        }

        private void ShowError(string message, string caption)
        {
            MessageBoxButton buttons = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Error;
            MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon);
        }

        private void textBox2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (textBox2.Text.Count() > 20)
            {
                string message = "Naziv tipa dogadjaja ne sme imati vise od 20 karaktera!";
                string caption = "Obavestenje!";
                ShowError(message, caption);
                textBox2.Clear();
                textBox2.Focus();
            }
        }

        private void textBox3_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (textBox3.Text.Count() > 250)
            {
                string message = "Opis tipa dogadjaja ne sme imati vise od 250 karaktera!";
                string caption = "Obavestenje!";
                ShowError(message, caption);
                textBox3.Clear();
                textBox3.Focus();
            }
        }
    }
}