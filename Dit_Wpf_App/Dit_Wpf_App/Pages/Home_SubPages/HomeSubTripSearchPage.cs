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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Dit_Wpf_App.Animation;
using Dit_Wpf_App.Converters;
using Dit_Wpf_App.DataModels;

namespace Dit_Wpf_App.Pages.Home_SubPages
{
    /// <summary>
    /// Interaction logic for HomeSub_TripSearchPage.xaml
    /// </summary>
    public partial class HomeSubTripSearchPage : BasePage
    {
        public HomeSubTripSearchPage()
        {
            PageLoadAnimation = PageAnimation.SlideInFromLeft;
            PageUnloadAnimation = PageAnimation.SlideOutToLeft;

            InitializeComponent();
        }

        private async void Fab_Search_Click(object sender, RoutedEventArgs e)
        {
            if (!(DataContext is HomePage homePage)) return;
            if (!(homePage.DataContext is MainWindow mainWindow)) return;
            
            // Disable animations for all pages.
            homePage.PageUnloadAnimation = PageAnimation.None;
            homePage.PageLoadAnimation = PageAnimation.None;
            PageUnloadAnimation = PageAnimation.None;
            PageLoadAnimation = PageAnimation.None;
            if (homePage.HomePageHost.OldPage.Content is BasePage oldPage)
            {
                oldPage.PageUnloadAnimation = PageAnimation.None;
                oldPage.PageLoadAnimation = PageAnimation.None;
            }
            // Wait for the button to finish animating.
            await Task.Delay(120);
            mainWindow.MainPageHost.CurrentPage = new TripSearchResultsPage(button_stop_from.Content as string, button_stop_to.Content as string);
            mainWindow.MainPageHost.CurrentPage.DataContext = homePage;
        }

        private void Swap_Click(object sender, RoutedEventArgs e)
        {
            var fromContent = button_stop_from.Content;
            var toContent = button_stop_to.Content;
            button_stop_from.Content = toContent;
            button_stop_to.Content = fromContent;
        }

        private void HistoricTrip_Click(object sender, RoutedEventArgs e)
        {
            // Make sure button is a button and contains a stackpanel.
            if (!(sender is Button button)) return;
            if (!(button.Content is StackPanel contentContainer)) return;

            // Loop through children of stackpanel.
            foreach (var child in contentContainer.Children)
            {
                // Make sure child is a StackPanel and has a name that begins with "location_container".
                if (!(child is StackPanel locationContainer)) continue;
                if (!locationContainer.Name.StartsWith("location_container")) continue;

                // Make sure first child of nested stackpanel is a label.
                if (locationContainer.Children[0] is Label fromLabel)
                {
                    button_stop_from.Content = fromLabel.Content;
                }
                // Make sure second child of nested stackpanel is a label.
                if (locationContainer.Children[1] is Label toLabel)
                {
                    button_stop_to.Content = toLabel.Content;
                }
                // Search for the trip.
                Fab_Search_Click(sender, e);
            }
        }

    }
}
