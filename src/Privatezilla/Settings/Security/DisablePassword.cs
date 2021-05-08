using Microsoft.Win32;
using Privatezilla.Locales;

namespace Privatezilla.Setting.Security
{
    internal class DisablePassword : SettingBase
    {
        private const string PasswordKey = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\CredUI";
        private const int DesiredValue = 1;

        public override string ID()
        {
            return Locale.settingsSecurityDisablePassword;
        }

        public override string Info()
        {
            return Locale.settingsSecurityDisablePasswordInfo;
        }

        public override bool CheckSetting()
        {
            return !(
             RegistryHelper.IntEquals(PasswordKey, "DisablePasswordReveal", DesiredValue)
             );

        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(PasswordKey, "DisablePasswordReveal", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(PasswordKey, "DisablePasswordReveal", 0, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }

    }
}