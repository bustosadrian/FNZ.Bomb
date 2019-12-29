using System.Windows;

namespace FNZ.Bomb
{
    public class MainWindowViewModel : BaseViewModel
    {
        public MainWindowViewModel()
        {
            WindowStyle = SettingsHandler.Instance.WindowStyle.Value;
            CodeLength = SettingsHandler.Instance.CodeLength.Value;
            EnableKeyPad();
        }

        private void HeaderTapped()
        {
            if(WindowStyle == WindowStyle.SingleBorderWindow)
            {
                WindowStyle = WindowStyle.None;
            }
            else
            {
                WindowStyle = WindowStyle.SingleBorderWindow;
            }
        }

        private void Submit(string code)
        {
            DisableKeyPad();
            SubmitedCode = code;
        }

        private void VerbiageHidden()
        {
            Code = null;
            EnableKeyPad();
        }

        private void EnableKeyPad()
        {
            IsKeyPadEnabled = true;
        }

        private void DisableKeyPad()
        {
            IsKeyPadEnabled = false;
        }

        #region Commands

        private DelegateCommand _headerCommand;
        public DelegateCommand HeaderCommand
        {
            get
            {
                if (_headerCommand == null)
                {
                    _headerCommand = new DelegateCommand(HeaderTapped);
                }
                return _headerCommand;
            }
        }

        private DelegateCommand<string> _submitCommand;
        public DelegateCommand<string> SubmitCommand
        {
            get
            {
                if(_submitCommand == null)
                {
                    _submitCommand = new DelegateCommand<string>(Submit);
                }
                return _submitCommand;
            }
        }

        private DelegateCommand _verbiageHiddenCommand;
        public DelegateCommand VerbiageHiddenCommand
        {
            get
            {
                if (_verbiageHiddenCommand == null)
                {
                    _verbiageHiddenCommand = new DelegateCommand(VerbiageHidden);
                }
                return _verbiageHiddenCommand;
            }
        }

        #endregion

        #region Properties

        private WindowStyle _windowStyle;
        public WindowStyle WindowStyle
        {
            get
            {
                return _windowStyle;
            }
            set
            {
                _windowStyle = value;
                if (_windowStyle == WindowStyle.None)
                {
                    ResizeMode = ResizeMode.NoResize;
                }
                else
                {
                    ResizeMode = ResizeMode.CanResize;
                }
                OnPropertyChanged("WindowStyle");
            }
        }

        private ResizeMode _resizeMode;
        public ResizeMode ResizeMode
        {
            get
            {
                return _resizeMode;
            }
            set
            {
                _resizeMode = value;
                if (_resizeMode == ResizeMode.NoResize)
                {
                    Topmost = true;
                }
                OnPropertyChanged("ResizeMode");
            }
        }

        private WindowState _windowState;
        public WindowState WindowState
        {
            get
            {
                return _windowState;
            }
            set
            {
                _windowState = value;
                OnPropertyChanged("WindowState");
            }
        }

        private bool _topmost;
        public bool Topmost
        {
            get
            {
                return _topmost;
            }
            set
            {
                _topmost = value;
                OnPropertyChanged("Topmost");
            }
        }

        private int _codeLength;
        public int CodeLength
        {
            get
            {
                return _codeLength;
            }
            set
            {
                _codeLength = value;
                OnPropertyChanged("CodeLength");
            }
        }

        private string _code;
        public string Code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
                OnPropertyChanged("Code");
            }
        }

        private string _submitedCode;
        public string SubmitedCode
        {
            get
            {
                return _submitedCode;
            }
            set
            {
                _submitedCode = value;
                OnPropertyChanged("SubmitedCode");
            }
        }

        private bool _isKeyPadEnabled;
        public bool IsKeyPadEnabled
        {
            get
            {
                return _isKeyPadEnabled;
            }
            set
            {
                _isKeyPadEnabled = value;
                OnPropertyChanged("IsKeyPadEnabled");
            }
        }

        #endregion
    }
}
