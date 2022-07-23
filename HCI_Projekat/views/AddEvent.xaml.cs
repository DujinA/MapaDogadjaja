using HCI_Projekat.models;
using Microsoft.Win32;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace HCI_Projekat.views
{
    /// <summary>
    /// Interaction logic for AddEvent.xaml
    /// </summary>
    public partial class AddEvent : Window
    {
        private Event _event = new Event();
        private DatabaseEvent databaseEvent = new DatabaseEvent();
        private OpenFileDialog fileDialog = new OpenFileDialog();
        private Regex regexId = new Regex("[^a-z0-9]+");
        private Regex regexName = null;

        public AddEvent()
        {
            InitializeComponent();
            this.DataContext = _event;
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            bool idSavingPermission = false;
            bool nameSavingPermission = false;

            int permission = -1;

            string id = textBox1.Text;
            if (id != "")
            {
                idSavingPermission = true;
                if (databaseEvent.getAll().Count() != 0)
                {
                    foreach (var ev in databaseEvent.getAll())
                    {
                        if (id.Equals(ev.Value.Id))
                        {
                            idSavingPermission = false;
                            permission = 1;
                            break;
                        }
                    }
                }
            }

            if (eventName.Text != "")
            {
                nameSavingPermission = true;
            }
            else
            {
                nameSavingPermission = false;
            }

            if (idSavingPermission == true && nameSavingPermission == true)
            {
                databaseEvent.AddToDictionary(_event);
                string message = "Dogadjaj " + eventName.Text + " je kreiran!";
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
            else if (textBox1.Text == "" && eventName.Text == "")
            {
                string message = "Polja za oznaku i naziv ne smeju biti prazni!";
                string caption = "Obavestenje!";
                ShowError(message, caption);
                textBox1.Focus();
            }
            else if (eventName.Text == "" && textBox1.Text != "")
            {
                string message = "Naziv dogadjaja ne sme biti prazan!";
                string caption = "Obavestenje!";
                ShowError(message, caption);
                eventName.Focus();
            }
            else if (textBox1.Text == "" && eventName.Text != "")
            {
                string message = "Polje oznaka ne sme biti prazno!";
                string caption = "Obavestenje!";
                ShowError(message, caption);
                textBox1.Focus();
            }
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
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
                string message = "Oznaka dogadjaja ne sme imati vise od 20 karaktera!";
                string caption = "Obavestenje!";
                ShowError(message, caption);
                textBox1.Clear();
                textBox1.Focus();
            }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (string l in e.AddedItems)
            {
                _event.Labels.Add(l);
            }

            foreach (string l in e.RemovedItems)
            {
                _event.Labels.Remove(l);
            }
        }

        private void ShowError(string message, string caption)
        {
            MessageBoxButton buttons = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Error;
            MessageBoxResult result = MessageBox.Show(message, caption, buttons, icon);
        }

        private void eventNamePreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (eventName.Text.Count() > 20)
            {
                string message = "Naziv dogadjaja ne sme imati vise od 20 karaktera!";
                string caption = "Obavestenje!";
                ShowError(message, caption);
                eventName.Clear();
                eventName.Focus();
            }
        }

        /*private void textBox7_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (new Regex("[^0-9.-]+").IsMatch(textBox7.Text.ToString())) ;
            {
                string message = "Unos cene održavanja dogadjaja mora biti izražen u numeričkom zapisu";
                string caption = "Obavestenje!";
                ShowError(message, caption);
                textBox5.Clear();
                textBox5.Focus();
            }
        }*/

        private void textBox3_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (textBox3.Text.Count() > 250)
            {
                string message = "Opis dogadjaja ne sme imati vise od 250 karaktera!";
                string caption = "Obavestenje!";
                ShowError(message, caption);
                textBox3.Clear();
                textBox3.Focus();
            }
        }

        /*private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            if (focusedControl is DependencyObject)
            {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp(str, this);
            }
        }*/

        public void doThings(string param)
        {
            //btnOK.Background = new SolidColorBrush(Color.FromRgb(32, 64, 128));
            Title = param;
        }
    }
}