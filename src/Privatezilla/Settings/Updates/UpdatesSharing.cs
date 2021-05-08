using Microsoft.Win32;
using Privatezilla.Locales;

namespace Privatezilla.Setting.Updates
{
    internal class DisableUpdatesSharing : SettingBase
    {
        private const string SharingKey = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\DeliveryOptimization";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return Locale.settingsUpdatesUpdateSharing;
        }

        public override string Info()
        {
            return Locale.settingsUpdatesUpdateSharingInfo.Replace("\\n", "\n");
        }

        public override bool CheckSetting()
        {
            return !(
               RegistryHelper.IntEquals(SharingKey, "DODownloadMode", DesiredValue)
             );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(SharingKey, "DODownloadMode", DesiredValue, RegistryValueKind.DWord);
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
                var RegKey = Registry.LocalMachine.OpenSubKey(@"Software\Policies\Microsoft\Windows\DeliveryOptimization", true);
                RegKey.DeleteValue("DODownloadMode");

                return true;
            }
            catch
            { }

            return false;
        }

    }
}