using Microsoft.Win32;
using Privatezilla.Locales;

namespace Privatezilla.Setting.Privacy
{
    internal class InstalledApps : SettingBase
    {
        private const string InstalledKey = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return Locale.settingsPrivacyInstalledApps;
        }

        public override string Info()
        {
            return Locale.settingsPrivacyInstalledAppsInfo.Replace("\\n", "\n");
        }

        public override bool CheckSetting()
        {

          return !(
          RegistryHelper.IntEquals(InstalledKey, "SilentInstalledAppsEnabled", DesiredValue)
              );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(InstalledKey, "SilentInstalledAppsEnabled", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(InstalledKey, "SilentInstalledAppsEnabled", 1, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }

    }
}