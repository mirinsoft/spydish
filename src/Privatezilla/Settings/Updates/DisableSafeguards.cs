using Microsoft.Win32;
using Privatezilla.Locales;

namespace Privatezilla.Setting.Updates
{
    internal class DisableSafeguards : SettingBase
    {
        private const string SharingKey = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\WindowsUpdate";
        private const int DesiredValue = 1;

        public override string ID()
        {
            return Locale.settingsUpdatesDisableSafeguards;
        }

        public override string Info()
        {
            return Locale.settingsUpdatesDisableSafeguardsInfo.Replace("\\n", "\n");
        }

        public override bool CheckSetting()
        {
            return !(
               RegistryHelper.IntEquals(SharingKey, "DisableWUfBSafeguards", DesiredValue)
             );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(SharingKey, "DisableWUfBSafeguards", DesiredValue, RegistryValueKind.DWord);
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
                var RegKey = Registry.LocalMachine.OpenSubKey(@"Software\Policies\Microsoft\Windows\WindowsUpdate", true);
                RegKey.DeleteValue("DisableWUfBSafeguards");

                return true;
            }
            catch
            { }

            return false;
        }

    }
}