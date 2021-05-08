using Microsoft.Win32;
using Privatezilla.Locales;

namespace Privatezilla.Setting.Cortana
{
    internal class DisableCortana : SettingBase
    {
        private const string CortanaKey = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\Windows Search";
        private const string CortanaIconKey = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return Locale.settingsCortanaDisableCortana;
        }

        public override string Info()
        {
            return Locale.settingsCortanaDisableCortanaInfo.Replace("\\n", "\n");
        }

        public override bool CheckSetting()
        {
            return !(
                    RegistryHelper.IntEquals(CortanaKey, "AllowCortana", DesiredValue) &&
                    RegistryHelper.IntEquals(CortanaIconKey, "ShowCortanaButton", DesiredValue)
                );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(CortanaKey, "AllowCortana", DesiredValue, RegistryValueKind.DWord);
                Registry.SetValue(CortanaIconKey, "ShowCortanaButton", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(CortanaKey, "AllowCortana", 1, RegistryValueKind.DWord);
                Registry.SetValue(CortanaIconKey, "ShowCortanaButton", 1, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }

    }
}