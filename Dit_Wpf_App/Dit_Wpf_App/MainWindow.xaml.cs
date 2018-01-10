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
using Dit_Wpf_App.Pages;
using Dit_Wpf_App.Pages.Home_SubPages;

namespace Dit_Wpf_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            MainPageHost.CurrentPage = new HomePage();
            MainPageHost.CurrentPage.DataContext = this;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (MainPageHost.CurrentPage is HomePage homePage)
            {
                if (homePage.HomePageHost.CurrentPage is HomeSubScheduledTripsPage)
                {
                    MainPageHost.CurrentPage.Back_Click(sender, e);
                }
            }
            else
            {
                MainPageHost.CurrentPage.Back_Click(sender, e);
            }
        }

        private async void Home_Click(object sender, RoutedEventArgs e)
        {
            
            if (MainPageHost.CurrentPage is HomePage homePage)
            {
                if (homePage.HomePageHost.CurrentPage is HomeSubScheduledTripsPage)
                {
                    MainPageHost.CurrentPage.Back_Click(sender, e);
                }
            }
            else
            {
                MainPageHost.CurrentPage.Back_Click(sender, e);

                if (MainPageHost.CurrentPage is TripSearchResultsPage)
                {
                    await Task.Delay((int)(MainPageHost.CurrentPage.SlideSeconds * 1100));
                    MainPageHost.CurrentPage.Back_Click(sender, e);
                }
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
