using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

namespace Dit_Wpf_App.Pages
{
    /// <summary>
    /// Interaction logic for TripDetailsPage.xaml
    /// </summary>
    public partial class TripDetailsPage : BasePage
    {
        private bool _skipResultsPage;

        public TripDetailsPage(string from, string to)
        {
            PageLoadAnimation = PageAnimation.SlideAndFadeInFromBottom;
            PageUnloadAnimation = PageAnimation.SlideAndFadeOutToBottom;
            ShouldAnimateFinishBeforeSwap = true;
            SlideSeconds = 0.3f;

            InitializeComponent();

            label_trip_details_from.Content = from;
            label_trip_details_to.Content = to;
            label_trip_details_description_from.Content = $"14:56 Från {from}";
        }

        public async override void Back_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is HomePage homePage)
            {
                if (homePage.DataContext is MainWindow mainWindow)
                {
                    BasePage page = new TripSearchResultsPage(label_trip_details_from.Content as string, label_trip_details_to.Content as string);
                    if (_skipResultsPage)
                        page = new HomePage();

                    mainWindow.MainPageHost.CurrentPage = page;

                    mainWindow.MainPageHost.CurrentPage.DataContext = _skipResultsPage ? (object) mainWindow : homePage;

                    mainWindow.MainPageHost.CurrentPage.PageLoadAnimation = PageAnimation.AppearInstant;
                    if (mainWindow.MainPageHost.CurrentPage is BasePage tripSearchResultsPage)
                    {
                        tripSearchResultsPage.PageLoadAnimation = PageAnimation.AppearInstant;
                        // Wait for Unload animation to finish so that it doesn't get interrupted.
                        await Task.Delay((int)(SlideSeconds * 900));
                        // Set previous page to homePage.
                        mainWindow.MainPageHost.NewPage.Content = homePage;
                        // Make old HomePage hidden so it doesn't pop up for a split second.
                        homePage.Visibility = Visibility.Hidden;
                    }
                }
            }
        }

        private async void Schedule_Click(object sender, RoutedEventArgs e)
        {
            // Set Handled to true so that Trip_Click doesn't get triggered.
            e.Handled = true;

            if (!(DataContext is HomePage homePage)) return;
            if (!(homePage.DataContext is MainWindow mainWindow)) return;
            
            // Close this page by pressing the back button.
            _skipResultsPage = true;
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

        private void Topbar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is HomePage homePage)
            {
                if (homePage.DataContext is MainWindow window)
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
}
