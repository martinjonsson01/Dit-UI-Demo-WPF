using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Dit_Wpf_App.DataModels;
using Dit_Wpf_App.Pages;
using Dit_Wpf_App.Pages.Home_SubPages;

namespace Dit_Wpf_App.Converters
{
    public static class ApplicationPageConverter
    {
        public static BasePage GetPage(ApplicationPage appPage)
        {
            // Find the appropriate page.
            switch (appPage)
            {
                case ApplicationPage.Home:
                    return new HomePage();

                case ApplicationPage.HomeSubTripSearchPage:
                    return new HomeSubTripSearchPage();

                case ApplicationPage.HomeSubScheduledTripsPage:
                    return new HomeSubScheduledTripsPage();

                case ApplicationPage.TripSearchResultsPage:
                    return new TripSearchResultsPage();

                default:
                    Debugger.Break();
                    return null;
            }
        }
    }
}
