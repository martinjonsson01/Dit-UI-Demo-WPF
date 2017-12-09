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

namespace Dit_Wpf_App.Pages.Home_SubPages
{
    /// <summary>
    /// Interaction logic for HomeSub_ScheduledTripsPage.xaml
    /// </summary>
    public partial class HomeSubScheduledTripsPage : BasePage
    {
        public HomeSubScheduledTripsPage()
        {
            PageLoadAnimation = PageAnimation.SlideInFromRight;
            PageUnloadAnimation = PageAnimation.SlideOutToLeft;

            InitializeComponent();
        }
    }
}
