using System.Windows;

namespace FNZ.Bomb
{
    public class AppSettings
    {

        public AppSettings()
        {
            CodeLength = 6;
            WindowStyle = System.Windows.WindowStyle.SingleBorderWindow;
            Alignment = TextAlignment.Right;
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

        public TextAlignment? Alignment
        {
            get;
            set;
        }

        #endregion
    }
}
