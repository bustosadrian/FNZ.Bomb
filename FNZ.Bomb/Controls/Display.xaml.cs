using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace FNZ.Bomb.Controls
{
    /// <summary>
    /// Interaction logic for Display.xaml
    /// </summary>
    public partial class Display : UserControl
    {
        public Display()
        {
            InitializeComponent();
        }

        private void DisplayCode()
        {
            string[] digits = new string[Length];
            if(Code != null)
            {
                char[] chars = Code.ToCharArray();
                for (int i = 0; i < digits.Length && i < Code.Length; i++)
                {
                    var o = chars[i];
                    digits[Length - i - 1] = o.ToString();
                }
            }
            if(Digits == null || Digits.Count != digits.Length)
            {
                Digits = new ObservableCollection<string>(digits.ToList());
            }
            else
            {
                for(int i = 0; i < digits.Length; i++)
                {
                    Digits[i] = digits[i];
                }
            }
        }

        #region Properties

        public static readonly DependencyProperty CodeProperty =
            DependencyProperty.Register("Code", typeof(string),
                typeof(Display), new PropertyMetadata(null, UpdateDisplay));
        public string Code
        {
            get { return (string)GetValue(CodeProperty); }
            set { SetValue(CodeProperty, value); }
        }

        public static readonly DependencyProperty DigitsProperty =
            DependencyProperty.Register("Digits", typeof(ObservableCollection<string>),
                typeof(Display), new PropertyMetadata(null));
        public ObservableCollection<string> Digits
        {
            get { return (ObservableCollection<string>)GetValue(DigitsProperty); }
            set { SetValue(DigitsProperty, value); }
        }

        public static readonly DependencyProperty LenghtProperty =
            DependencyProperty.Register("Length", typeof(int),
                typeof(Display), new PropertyMetadata(0, UpdateDisplay));
        public int Length
        {
            get { return (int)GetValue(LenghtProperty); }
            set { SetValue(LenghtProperty, value); }
        }

        private static void UpdateDisplay(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Display)d).DisplayCode();
        }


        #endregion
    }
}
