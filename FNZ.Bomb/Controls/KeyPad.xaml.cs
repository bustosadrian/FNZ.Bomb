using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FNZ.Bomb.Controls
{
    /// <summary>
    /// Interaction logic for KeyPad.xaml
    /// </summary>
    public partial class KeyPad : UserControl
    {
        public KeyPad()
        {
            InitializeComponent();
        }

        private void SetDigit(string value)
        {
            if (CanDigitExecute())
            {
                if (Code.Length < Length)
                {
                    Code += value;
                }
                RaiseAllCanExecute();
            }
        }

        private void ClearEverything()
        {
            if (CanClearExecute())
            {
                if (!string.IsNullOrEmpty(Code))
                {
                    Code = "";
                    RaiseAllCanExecute();
                }
            }
        }

        private void Clear()
        {
            if (CanClearExecute())
            {
                if (Code.Length > 0)
                {
                    Code = Code.Substring(0, Code.Length - 1);
                }
                RaiseAllCanExecute();
            }
        }

        private void Submit()
        {
            if (CanSubmitExecute())
            {
                Command?.Execute(Code);
                RaiseAllCanExecute();
            }
        }

        private void Press(Button button)
        {
            button.GetType().GetMethod("set_IsPressed",
                BindingFlags.Instance |
                BindingFlags.NonPublic)
                .Invoke(button, new object[] { true });
            button.GetType().GetMethod("set_IsPressed",
                BindingFlags.Instance |
                BindingFlags.NonPublic)
                .Invoke(button, new object[] { false });
            button.Command?.Execute(button.CommandParameter);
        }

        private void Self_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            RaiseAllCanExecute();
        }

        #region Key Handler

        public void Hit(KeyEventArgs e)
        {
            if (IsEnabled)
            {
                if (!e.Handled)
                {
                    Button b = null;
                    if ((e.Key >= Key.D0 && e.Key <= Key.D9) 
                        || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
                    {
                        if (CanDigitExecute())
                        {
                            switch (e.Key)
                            {
                                case Key.D0:
                                case Key.NumPad0:
                                    b = btn0;
                                    break;
                                case Key.D1:
                                case Key.NumPad1:
                                    b = btn1;
                                    break;
                                case Key.D2:
                                case Key.NumPad2:
                                    b = btn2;
                                    break;
                                case Key.D3:
                                case Key.NumPad3:
                                    b = btn3;
                                    break;
                                case Key.D4:
                                case Key.NumPad4:
                                    b = btn4;
                                    break;
                                case Key.D5:
                                case Key.NumPad5:
                                    b = btn5;
                                    break;
                                case Key.D6:
                                case Key.NumPad6:
                                    b = btn6;
                                    break;
                                case Key.D7:
                                case Key.NumPad7:
                                    b = btn7;
                                    break;
                                case Key.D8:
                                case Key.NumPad8:
                                    b = btn8;
                                    break;
                                case Key.D9:
                                case Key.NumPad9:
                                    b = btn9;
                                    break;
                            }
                        }
                    }
                    else if (e.Key == Key.Delete 
                        || e.Key == Key.Back 
                        || e.Key == Key.Decimal)
                    {
                        if (CanClearExecute())
                        {
                            b = btnClear;
                        }
                    }
                    else if (e.Key == Key.Escape)
                    {
                        if (CanClearExecute())
                        {
                            ClearEverything();
                        }
                    }
                    else if (e.Key == Key.Enter)
                    {
                        if (CanSubmitExecute())
                        {
                            b = btnSubmit;
                        }
                    }

                    if (b != null)
                    {
                        Press(b);
                        e.Handled = true;
                    }
                }
            }
        }

        #endregion

        #region Commands

        private DelegateCommand<string> _digitCommand;
        public DelegateCommand<string> DigitCommand
        {
            get
            {
                if(_digitCommand == null)
                {
                    _digitCommand = new DelegateCommand<string>(SetDigit, CanDigitExecute);
                }
                return _digitCommand;
            }
        }

        private DelegateCommand _clearCommand;
        public DelegateCommand ClearCommand
        {
            get
            {
                if (_clearCommand == null)
                {
                    _clearCommand = new DelegateCommand(Clear, CanClearExecute);
                }
                return _clearCommand;
            }
        }

        private DelegateCommand _submitCommand;
        public DelegateCommand SubmitCommand
        {
            get
            {
                if (_submitCommand == null)
                {
                    _submitCommand = new DelegateCommand(Submit, CanSubmitExecute);
                }
                return _submitCommand;
            }
        }

        private bool CanExecute()
        {
            return IsEnabled;
        }

        private bool CanDigitExecute(string value = null)
        {
            if (!CanExecute())
            {
                return false;
            }

            return true;
        }

        private bool CanOperationsExecute()
        {
            if (!CanExecute())
            {
                return false;
            }

            if(Code == null || Code.Length == 0)
            {
                return false;
            }

            return true;
        }

        private bool CanClearExecute()
        {
            if (!CanOperationsExecute())
            {
                return false;
            }

            return true;
        }

        private bool CanSubmitExecute()
        {
            if (!CanOperationsExecute())
            {
                return false;
            }

            return true;
        }

        private void RaiseAllCanExecute()
        {
            DigitCommand.RaiseCanExecuteChanged();
            ClearCommand.RaiseCanExecuteChanged();
            SubmitCommand.RaiseCanExecuteChanged();
        }

        #endregion

        #region Commands Properties

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(DelegateCommand<string>),
                typeof(KeyPad), new PropertyMetadata(null));
        public DelegateCommand<string> Command
        {
            get { return (DelegateCommand<string>)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        #endregion

        #region Properties

        public static readonly DependencyProperty CodeProperty =
            DependencyProperty.Register("Code", typeof(string),
        typeof(KeyPad), new PropertyMetadata(""));
        public string Code
        {
            get { return (string)GetValue(CodeProperty); }
            set { SetValue(CodeProperty, value); }
        }

        public static readonly DependencyProperty LenghtProperty =
            DependencyProperty.Register("Length", typeof(int),
                typeof(KeyPad), new PropertyMetadata(0));
        public int Length
        {
            get { return (int)GetValue(LenghtProperty); }
            set { SetValue(LenghtProperty, value); }
        }

        #endregion
    }
}
