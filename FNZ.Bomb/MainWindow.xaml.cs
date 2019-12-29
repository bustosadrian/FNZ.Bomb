using System.Windows;
using System.Windows.Input;

namespace FNZ.Bomb
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            KeyPad.Hit(e);
            if (!e.Handled)
            {
                Verbiage.Hit(e);
            }
            Focus();
        }
    }
}
