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
using Dit_Wpf_App.Pages;
using Dit_Wpf_App.Animation;
using Dit_Wpf_App.Converters;
using Dit_Wpf_App.DataModels;

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

                    mainWindow.MainPageHost.CurrentPage.PageLoadAnimation = PageAnimation.AppearInstant;
                    if (mainWindow.MainPageHost.CurrentPage is HomePage newHomePage)
                    {
                        newHomePage.HomePageHost.CurrentPage.PageLoadAnimation = PageAnimation.AppearInstant;
                    }
                }
            }
        }
    }
}
