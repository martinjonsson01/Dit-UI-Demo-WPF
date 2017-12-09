using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Dit_Wpf_App.Animation;

namespace Dit_Wpf_App.Pages
{
    /// <summary>
    /// The base page for all pages to gain base functionality
    /// </summary>
    public class BasePage : Page
    {
        #region Public Properties

        /// <summary>
        /// The animation the play when the page is first loaded
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        /// <summary>
        /// The animation the play when the page is unloaded
        /// </summary>
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        /// <summary>
        /// The time any slide animation takes to complete
        /// </summary>
        public float SlideSeconds { get; set; } = 0.4f;

        /// <summary>
        /// A flag to indicate if this page should animate out on load.
        /// Useful for when we are moving the page to another frame
        /// </summary>
        public bool ShouldAnimateOut { get; set; }

        public bool ShouldAnimateFinishBeforeSwap { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BasePage()
        {
            // If we are animating in, hide to begin with
            if (PageLoadAnimation != PageAnimation.None)
                Visibility = Visibility.Collapsed;

            // Listen out for the page loading
            Loaded += BasePage_LoadedAsync;
        }

        #endregion

        #region Animation Load / Unload

        /// <summary>
        /// Once the page is loaded, perform any required animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_LoadedAsync(object sender, System.Windows.RoutedEventArgs e)
        {
            // If we are setup to animate out on load
            if (ShouldAnimateOut)
                // Animate out the page
                await AnimateOutAsync();
            // Otherwise...
            else
                // Animate the page in
                await AnimateInAsync();
        }

        /// <summary>
        /// Animates the page in
        /// </summary>
        /// <returns></returns>
        public async Task AnimateInAsync()
        {
            // Make sure we have something to do
            if (PageLoadAnimation == PageAnimation.None)
                return;

            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:

                    // Start the animation
                    await this.SlideAndFadeInFromRightAsync(SlideSeconds);

                    break;
                case PageAnimation.SlideAndFadeInFromLeft:

                    // Start the animation
                    await this.SlideAndFadeInFromLeftAsync(SlideSeconds);

                    break;
                case PageAnimation.SlideInFromRight:

                    // Start the animation
                    await this.SlideAndFadeInFromRightAsync(SlideSeconds, false);

                    break;
                case PageAnimation.SlideInFromLeft:

                    // Start the animation
                    await this.SlideAndFadeInFromLeftAsync(SlideSeconds, false);

                    break;
                case PageAnimation.SlideAndFadeInFromBottom:

                    // Start the animation
                    await this.SlideAndFadeInFromBottom(SlideSeconds);

                    break;
                case PageAnimation.AppearInstant:

                    // Start the animation
                    await this.AppearInstant(SlideSeconds);

                    break;
            }
        }

        /// <summary>
        /// Animates the page out
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOutAsync()
        {
            // Make sure we have something to do
            if (PageUnloadAnimation == PageAnimation.None)
                return;

            switch (PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:

                    // Start the animation
                    await this.SlideAndFadeOutToLeftAsync(SlideSeconds);

                    break;
                case PageAnimation.SlideAndFadeOutToRight:

                    // Start the animation
                    await this.SlideAndFadeOutToRightAsync(SlideSeconds);

                    break;
                case PageAnimation.SlideOutToLeft:

                    // Start the animation
                    await this.SlideAndFadeOutToLeftAsync(SlideSeconds, false);

                    break;
                case PageAnimation.SlideOutToRight:

                    // Start the animation
                    await this.SlideAndFadeOutToRightAsync(SlideSeconds, false);

                    break;
                case PageAnimation.SlideAndFadeOutToBottom:

                    // Start the animation
                    await this.SlideAndFadeOutToBottom(SlideSeconds);

                    break;
            }
        }

        #endregion
    }
}
