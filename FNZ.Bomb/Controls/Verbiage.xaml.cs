using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace FNZ.Bomb.Controls
{
    /// <summary>
    /// Interaction logic for Verbiage.xaml
    /// </summary>
    public partial class Verbiage : UserControl
    {
        public Verbiage()
        {
            InitializeComponent();
        }

        private void DefuseCode()
        {
            if(Code == null)
            {
                State = null;
            }
            else
            {
                State = VerbiageState.DEFUSING;
                RaiseDefusing();
            }
        }

        public void Hit(KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                case Key.Escape:
                    Hide();
                    e.Handled = true;
                    break;
            }
        }

        private void Self_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Hide();
        }

        private void Hide()
        {
            switch (State)
            {
                case VerbiageState.DEFUSED:
                case VerbiageState.EXPLODED:
                    ExplodeStoryboard.Stop(this);
                    Code = null;
                    State = null;
                    RaiseHiden();
                    break;
                default:
                    break;
            }
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            bool defused = BombCore.Defuse(Code);
            if (defused)
            {
                State = VerbiageState.DEFUSED;
            }
            else
            {
                ExplodeStoryboard.Begin(this, true);
                State = VerbiageState.EXPLODED;
            }
        }

        #region Commands Properties

        public static readonly DependencyProperty HiddenCommandProperty =
            DependencyProperty.Register("HiddenCommand", typeof(DelegateCommand),
                typeof(Verbiage), new PropertyMetadata(null));
        public DelegateCommand HiddenCommand
        {
            get { return (DelegateCommand)GetValue(HiddenCommandProperty); }
            set { SetValue(HiddenCommandProperty, value); }
        }

        #endregion

        #region Events

        public static readonly RoutedEvent DefusingEvent = EventManager.RegisterRoutedEvent(
            "Defusing", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Verbiage));
        public event RoutedEventHandler Defusing
        {
            add { AddHandler(DefusingEvent, value); }
            remove { RemoveHandler(DefusingEvent, value); }
        }
        private void RaiseDefusing()
        {
            RaiseEvent(new RoutedEventArgs(DefusingEvent));
        }

        public static readonly RoutedEvent HiddenEvent = EventManager.RegisterRoutedEvent(
            "Hidden", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Verbiage));
        public event RoutedEventHandler Hidden
        {
            add { AddHandler(HiddenEvent, value); }
            remove { RemoveHandler(HiddenEvent, value); }
        }
        private void RaiseHiden()
        {
            //RaiseEvent(new RoutedEventArgs(HiddenEvent));
            HiddenCommand?.Execute(null);
        }

        #endregion

        #region Properties

        private Storyboard ExplodeStoryboard
        {
            get
            {
                return (Storyboard)FindResource("ExplodeStoryboard");            }
        }

        public static readonly DependencyProperty CodeProperty =
            DependencyProperty.Register("Code", typeof(string),
                typeof(Verbiage), new PropertyMetadata(null, OnCodeChanged));
        public string Code
        {
            get { return (string)GetValue(CodeProperty); }
            set { SetValue(CodeProperty, value); }
        }
        private static void OnCodeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Verbiage)d).DefuseCode();
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(VerbiageState?),
                typeof(Verbiage), new PropertyMetadata(null));
        public VerbiageState? State
        {
            get { return (VerbiageState?)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        #endregion
    }

    public enum VerbiageState
    {
        DEFUSING, DEFUSED, EXPLODED
    }

    public class VerbiageBoxConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush retval = null;

            if(value is VerbiageState state)
            {
                switch (state)
                {
                    case VerbiageState.DEFUSING:
                        retval = (SolidColorBrush)Application.Current.FindResource("VerbiageDefusing");
                        break;
                    case VerbiageState.DEFUSED:
                        retval = (SolidColorBrush)Application.Current.FindResource("VerbiageDefused");
                        break;
                    case VerbiageState.EXPLODED:
                        retval = (SolidColorBrush)Application.Current.FindResource("VerbiageExploded");
                        break;
                }
            }

            return retval;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class VerbiageBoxMessageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string retval = null;

            if (value is VerbiageState state)
            {
                switch (state)
                {
                    case VerbiageState.DEFUSING:
                        //retval = (string)Application.Current.FindResource("to.defusing");
                        retval = "DEFUSING...";
                        break;
                    case VerbiageState.DEFUSED:
                        //retval = (string)Application.Current.FindResource("defused");
                        retval = "DEFUSED!";
                        break;
                    case VerbiageState.EXPLODED:
                        //retval = (string)Application.Current.FindResource("explosion");
                        retval = "BOOM!";
                        break;
                }
            }

            return retval;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
