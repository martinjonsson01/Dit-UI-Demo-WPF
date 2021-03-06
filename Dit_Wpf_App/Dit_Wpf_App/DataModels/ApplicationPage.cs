﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dit_Wpf_App.DataModels
{
    /// <summary>
    /// A page of the application.
    /// </summary>
    public enum ApplicationPage
    {
        /// <summary>
        /// The initial home page.
        /// </summary>
        Home = 0,

        /// <summary>
        /// The trip search sub-section of the home page.
        /// </summary>
        HomeSubTripSearch = 1,

        /// <summary>
        /// The scheduled trips sub-section of the home page.
        /// </summary>
        HomeSubScheduledTrips = 2,

        /// <summary>
        /// The trip search results page.
        /// </summary>
        TripSearchResults = 3,

        /// <summary>
        /// The trip details page.
        /// </summary>
        TripDetails = 4,
    }
}
