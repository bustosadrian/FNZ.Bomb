using System;
using System.Configuration;
using System.Windows;

namespace FNZ.Bomb
{
    public class SettingsHandler
    {
        private SettingsHandler()
        {

        }

        private static AppSettings Load()
        {
            AppSettings retval = null;

            AppSettings defaultSettings = new AppSettings();
            retval = new AppSettings();
            try
            {
                retval.CodeLength = int.Parse(ConfigurationManager.AppSettings["CodeLength"]);
            }
            catch
            {

            }

            try
            {
                retval.WindowStyle = (WindowStyle)System.Enum.Parse(
                    typeof(WindowStyle), ConfigurationManager.AppSettings["WindowStyle"]);
            }
            catch
            {

            }

            try
            {
                retval.Alignment = (TextAlignment)System.Enum.Parse(
                    typeof(TextAlignment), ConfigurationManager.AppSettings["Alignment"]);
            }
            catch
            {

            }

            retval.CodeLength =  retval.CodeLength ?? defaultSettings.CodeLength;
            retval.WindowStyle = retval.WindowStyle ?? defaultSettings.WindowStyle;
            retval.Alignment = retval.Alignment ?? defaultSettings.Alignment;

            return retval;
        }

        #region Properties

        private static AppSettings _instance;
        public static AppSettings Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = Load();
                }
                return _instance;
            }
        }

        #endregion
    }
}
