using Microsoft.Win32;
using Privatezilla.Locales;

namespace Privatezilla.Setting.Security
{
    internal class WindowsDRM : SettingBase
    {
        private const string DRMKey = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\WMDRM";
        private const int DesiredValue = 1;

        public override string ID()
        {
            return Locale.settingsSecurityWindowsDRM;
        }

        public override string Info()
        {
            return Locale.settingsSecurityWindowsDRMInfo;
        }

        public override bool CheckSetting()
        {
            return !(
        RegistryHelper.IntEquals(DRMKey, "DisableOnline", DesiredValue)
             );

        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(DRMKey, "DisableOnline", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(DRMKey, "DisableOnline", 0, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }

    }
}