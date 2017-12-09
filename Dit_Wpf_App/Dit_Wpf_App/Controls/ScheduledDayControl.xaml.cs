using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Dit_Wpf_App.Annotations;

namespace Dit_Wpf_App.Controls
{
    /// <summary>
    /// Interaction logic for ScheduledDayControl.xaml
    /// </summary>
    public partial class ScheduledDayControl : UserControl
    {
        public static readonly DependencyProperty TimeSpanStringProperty
            = DependencyProperty.Register(
                    "TimeSpanString",
                    typeof(string),
                    typeof(ScheduledDayControl)
                );

        public string TimeSpanString
        {
            get => (string)GetValue(TimeSpanStringProperty);
            set => SetValue(TimeSpanStringProperty, value);
        }

        public static readonly DependencyProperty DayProperty
            = DependencyProperty.Register(
                "Day",
                typeof(DayOfWeek),
                typeof(ScheduledDayControl),
                new PropertyMetadata(DayOfWeek.Monday)
            );

        public DayOfWeek Day
        {
            get => (DayOfWeek)GetValue(DayProperty);
            set => SetValue(DayProperty, value);
        }

        public static readonly DependencyProperty IsActiveProperty
            = DependencyProperty.Register(
                "IsActive",
                typeof(bool),
                typeof(ScheduledDayControl)
            );

        public bool IsActive
        {
            get => (bool)GetValue(IsActiveProperty);
            set => SetValue(IsActiveProperty, value);
        }
        
        public ScheduledDayControl()
        {
            InitializeComponent();
        }

        private void ButtonDay_OnClick(object sender, RoutedEventArgs e)
        {
            IsActive = !IsActive;
            /*ButtonDay.Background =
                IsActive ? (SolidColorBrush)new BrushConverter().ConvertFrom("{ StaticResource AccentBrush }") : new SolidColorBrush();
            LabelDay.Foreground = IsActive ? new SolidColorBrush(Colors.White) : new SolidColorBrush(Colors.DimGray);
            ButtonTimeSpan.Visibility = IsActive ? Visibility.Visible : Visibility.Hidden;*/
        }
    }
}
