using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Dit_Wpf_App.Annotations;
using Dit_Wpf_App.Pages;

namespace Dit_Wpf_App.Controls
{
    /// <summary>
    /// Interaction logic for PageHost.xaml
    /// </summary>
    public partial class PageHost : UserControl
    {

        public BasePage CurrentPage
        {
            get => (BasePage) GetValue(CurrentPageProperty);
            set => SetValue(CurrentPageProperty, value);
        }

        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), typeof(BasePage), typeof(PageHost), new UIPropertyMetadata(CurrentPagePropertyChanged));

        public PageHost()
        {
            InitializeComponent();
        }

        private static async void CurrentPagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Get the frames.
            var newPageFrame = (d as PageHost)?.NewPage;
            var oldPageFrame = (d as PageHost)?.OldPage;

            // If one of the pages is null then abort.
            if (newPageFrame == null || oldPageFrame == null) return;

            // If new page needs to finish animation before the swapping of pages
            // then wait for it to finish.
            if (newPageFrame.Content is BasePage basePage)
            {
                if (basePage.ShouldAnimateFinishBeforeSwap)
                {
                    await basePage.AnimateOutAsync();
                }
            } 

            // Store the current page content as the old page.
            var oldPageContent = newPageFrame.Content;

            // Remove current page from new page frame.
            newPageFrame.Content = null;

            // Move the previous page into the old page frame.
            oldPageFrame.Content = oldPageContent;

            // Animate out previous page when the Loaded event fires
            // right after this call due to moving frames.
            if (oldPageContent is BasePage oldPage)
                oldPage.ShouldAnimateOut = true;

            // Set the new page content.
            newPageFrame.Content = e.NewValue;
        }

    }
}
