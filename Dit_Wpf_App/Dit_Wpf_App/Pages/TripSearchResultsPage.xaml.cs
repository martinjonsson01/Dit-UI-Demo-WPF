using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Dit_Wpf_App.Pages;
using Dit_Wpf_App.Animation;
using Dit_Wpf_App.Converters;
using Dit_Wpf_App.DataModels;
using Dit_Wpf_App.Pages.Home_SubPages;

namespace Dit_Wpf_App.Pages
{
    /// <summary>
    /// Interaction logic for TripSearchResultsPage.xaml
    /// </summary>
    public partial class TripSearchResultsPage : BasePage
    {
        public TripSearchResultsPage()
        {
            PageLoadAnimation = PageAnimation.SlideAndFadeInFromBottom;
            PageUnloadAnimation = PageAnimation.SlideAndFadeOutToBottom;
            ShouldAnimateFinishBeforeSwap = true;
            SlideSeconds = 0.3f;
            
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is HomePage homePage)
            {
                if (homePage.DataContext is MainWindow mainWindow)
                {
                    mainWindow.MainPageHost.CurrentPage = ApplicationPageConverter.GetPage(ApplicationPage.Home);
                    mainWindow.MainPageHost.CurrentPage.DataContext = mainWindow;

                    // Make old HomePage visible again.
                    homePage.Visibility = Visibility.Visible;

                    mainWindow.MainPageHost.CurrentPage.PageLoadAnimation = PageAnimation.AppearInstant;
                    if (mainWindow.MainPageHost.CurrentPage is HomePage newHomePage)
                    {
                        newHomePage.HomePageHost.CurrentPage.PageLoadAnimation = PageAnimation.AppearInstant;
                    }
                }
            }
        }

        private void Trip_Click(object sender, RoutedEventArgs e)
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
            // Open Trip Details page.
            mainWindow.MainPageHost.CurrentPage = ApplicationPageConverter.GetPage(ApplicationPage.TripDetails);
            mainWindow.MainPageHost.CurrentPage.DataContext = homePage;
        }

        private async void Schedule_Click(object sender, RoutedEventArgs e)
        {
            // Set Handled to true so that Trip_Click doesn't get triggered.
            e.Handled = true;

            if (!(DataContext is HomePage homePage)) return;
            if (!(homePage.DataContext is MainWindow mainWindow)) return;

            // Close this page by pressing the back button.
            Back_Click(sender, e);
            // Wait for Unload animation to finish.
            await Task.Delay(100);
            // Make sure MainPageHost's CurrentPage is an instance of HomePage.
            if (mainWindow.MainPageHost.CurrentPage is HomePage newHomePage)
            {
                // Raise the ClickEvent on the ButtonTabSchedule, opening the HomeSubTripSchedulePage.
                newHomePage.ButtonTabSchedule.Dispatcher.Invoke(() =>
                    newHomePage.ButtonTabSchedule.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent)));
            }
        }
    }
}
