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
using Dit_Wpf_App.Pages.Home_SubPages;

namespace Dit_Wpf_App.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : BasePage
    {
        public HomePage()
        {
            SlideSeconds = 0.0001f;
            InitializeComponent();
            PageLoadAnimation = PageAnimation.AppearInstant;
            HomePageHost.CurrentPage = new HomeSubTripSearchPage();
            HomePageHost.CurrentPage.DataContext = this;
            SlideSeconds = 0.4f;
        }

        public void Tab_Click(object sender, RoutedEventArgs e)
        {
            bool searchTabClicked = (sender as Control)?.Name == "ButtonTabSearch";
            ButtonTabSchedule.IsEnabled = searchTabClicked;
            ButtonTabSearch.IsEnabled = !searchTabClicked;
            if (HomePageHost.OldPage.Content is BasePage oldPage)
            {
                oldPage.PageLoadAnimation = searchTabClicked ? PageAnimation.SlideInFromLeft : PageAnimation.SlideInFromRight;
                oldPage.PageUnloadAnimation = searchTabClicked ? PageAnimation.SlideOutToRight : PageAnimation.SlideOutToLeft;
            }
            if (HomePageHost.NewPage.Content is BasePage newPage)
            {
                newPage.PageLoadAnimation = searchTabClicked ? PageAnimation.SlideInFromLeft : PageAnimation.SlideInFromRight;
                newPage.PageUnloadAnimation = searchTabClicked ? PageAnimation.SlideOutToRight : PageAnimation.SlideOutToLeft;
            }
            BasePage page = null;
            if (searchTabClicked)
                page = new HomeSubTripSearchPage();
            else
                page = new HomeSubScheduledTripsPage();
            HomePageHost.CurrentPage = page;
            HomePageHost.CurrentPage.DataContext = this;
        }

        public override void Back_Click(object sender, RoutedEventArgs e)
        {
            Tab_Click(new Control {Name = "ButtonTabSearch"}, e);
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainWindow window)
            {
                SystemCommands.ShowSystemMenu(window, Utils.GetMousePosition(window));
            }
        }

        private void Topbar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is MainWindow window)
            {
                if (e.ChangedButton.Equals(MouseButton.Left))
                {
                    window.WindowState = WindowState.Normal;
                    window.DragMove();
                }
                else
                {
                    SystemCommands.ShowSystemMenu(window, Utils.GetMousePosition(window));
                }
            }
        }
    }
}
