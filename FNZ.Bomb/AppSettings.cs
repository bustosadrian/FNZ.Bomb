using System.Windows;

namespace FNZ.Bomb
{
    public class AppSettings
    {

        public AppSettings()
        {
            CodeLength = 6;
            WindowStyle = System.Windows.WindowStyle.SingleBorderWindow;
        }

        #region Properties

        public int? CodeLength
        {
            get;
            set;
        }

        public WindowStyle? WindowStyle
        {
            get;
            set;
        }

        #endregion
    }
}
