﻿using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Pizza.com
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

        }

        private void vegButtonClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(VegMenu));
        }

        private void nonvegButtonClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NonvegMenu));
        }

        private void beveragesButtonClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Beverages));        }

        private void sidersButtonClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Siders));
        }

        private void CartClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Cart));
        }
    }
}
