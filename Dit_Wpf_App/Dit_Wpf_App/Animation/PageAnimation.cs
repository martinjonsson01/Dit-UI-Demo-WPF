using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dit_Wpf_App.Animation
{
    /// <summary>
    /// Styles of page animations for appearing/disappearing.
    /// </summary>
    public enum PageAnimation
    {
        /// <summary>
        /// No animation takes place.
        /// </summary>
        None = 0,

        /// <summary>
        /// The page slides in and fades in from the right.
        /// </summary>
        SlideAndFadeInFromRight = 1,

        /// <summary>
        /// The page slides out and fades out to the left.
        /// </summary>
        SlideAndFadeOutToLeft = 2,

        /// <summary>
        /// The page slides in and fades in from the left.
        /// </summary>
        SlideAndFadeInFromLeft = 3,

        /// <summary>
        /// The page slides out and fades out to the right.
        /// </summary>
        SlideAndFadeOutToRight = 4,

        /// <summary>
        /// The page slides in from the right.
        /// </summary>
        SlideInFromRight = 5,

        /// <summary>
        /// The page slides out to the left.
        /// </summary>
        SlideOutToLeft = 6,

        /// <summary>
        /// The page slides in from the left.
        /// </summary>
        SlideInFromLeft = 7,

        /// <summary>
        /// The page slides out to the right.
        /// </summary>
        SlideOutToRight = 8,

        /// <summary>
        /// The page slides in from the bottom.
        /// </summary>
        SlideAndFadeInFromBottom = 9,

        /// <summary>
        /// The page slides out to the bottom.
        /// </summary>
        SlideAndFadeOutToBottom = 10,

        /// <summary>
        /// The page appears instantly.
        /// </summary>
        AppearInstant = 11,
    }
}
