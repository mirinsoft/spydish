using Microsoft.Win32;
using Privatezilla.Locales;

namespace Privatezilla.Setting.Apps
{
    internal class BackgroundApps: SettingBase
    {
        private const string AppKey = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications";
        private const int DesiredValue =1;

        public override string ID()
        {
            return Locale.settingsAppsBackgroundApps;
        }

        public override string Info()
        {
            return Locale.settingsAppsBackgroundAppsInfo;
        }

        public override bool CheckSetting()
        {
            return !(
               RegistryHelper.IntEquals(AppKey, "GlobalUserDisabled", DesiredValue)
             );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(AppKey, "GlobalUserDisabled", DesiredValue, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }


        public override bool UndoSetting()
        {
            try
            {
                Registry.SetValue(AppKey, "GlobalUserDisabled", 0, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }
    }
}