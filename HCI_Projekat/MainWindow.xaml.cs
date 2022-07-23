using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace HCI_Projekat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void HomeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.frame.NavigationService.Navigate(
                new Uri("views/MainPage.xaml", UriKind.Relative));
        }

        private void EventMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.frame.NavigationService.Navigate(
                new Uri("views/EventsPage.xaml", UriKind.Relative));
        }

        private void EventTypeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.frame.NavigationService.Navigate(
                new Uri("views/TypesPage.xaml", UriKind.Relative));
        }

        private void EventLabelMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.frame.NavigationService.Navigate(
                new Uri("views/LabelsPage.xaml", UriKind.Relative));
        }
    }
}
