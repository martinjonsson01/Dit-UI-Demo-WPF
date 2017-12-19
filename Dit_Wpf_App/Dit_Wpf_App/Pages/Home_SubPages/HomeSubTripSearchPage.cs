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
            mainWindow.MainPageHost.CurrentPage = ApplicationPageConverter.GetPage(ApplicationPage.TripSearchResults);
            mainWindow.MainPageHost.CurrentPage.DataContext = homePage;
        }

        private void Swap_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
