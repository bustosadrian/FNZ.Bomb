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
            retval.CodeLength =  retval.CodeLength ?? defaultSettings.CodeLength;
            retval.WindowStyle = retval.WindowStyle ?? defaultSettings.WindowStyle;

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
