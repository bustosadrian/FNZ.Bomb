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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace FNZ.Bomb.Controls
{
    /// <summary>
    /// Interaction logic for Digit.xaml
    /// </summary>
    public partial class Digit : UserControl
    {
        public Digit()
        {
            InitializeComponent();
        }

        private void ValueChanged(string oldValue, string newValue)
        {
            if(!string.IsNullOrEmpty(oldValue) && string.IsNullOrEmpty(newValue))
            {
                ClearStoryboard.Begin(this, true);
            }
        }

        #region Properties

        private Storyboard ClearStoryboard
        {
            get
            {
                return (Storyboard)FindResource("ClearStoryboard");
            }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(string),
                typeof(Digit), new PropertyMetadata("*", OnValueChanged));
        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Digit)d).ValueChanged(e.OldValue as string, e.NewValue as string);
        }


        public static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register("Number", typeof(string),
                typeof(Digit), new PropertyMetadata(null));
        public string Number
        {
            get { return (string)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }

        //public static new readonly DependencyProperty FontSizeProperty =
        //    DependencyProperty.Register("FontSize", typeof(string),
        //        typeof(Digit), new PropertyMetadata(null));
        //public new string FontSizde
        //{
        //    get { return (string)GetValue(FontSizeProperty); }
        //    set { SetValue(FontSizeProperty, value); }
        //}

        #endregion
    }
}
