using Microsoft.Win32;
using Privatezilla.Locales;

namespace Privatezilla.Setting.Privacy
{
    internal class GetMoreOutOfWindows: SettingBase
    {
        private const string GetKey = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\UserProfileEngagement";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return Locale.settingsPrivacyGetMoreOutOfWindows;
        }

        public override string Info()
        {
            return Locale.settingsPrivacyGetMoreOutOfWindowsInfo.Replace("\\n", "\n");
        }

        public override bool CheckSetting()
        {
            return !(
            RegistryHelper.IntEquals(GetKey, "ScoobeSystemSettingEnabled", DesiredValue)

            );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(GetKey, "ScoobeSystemSettingEnabled", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(GetKey, "ScoobeSystemSettingEnabled", 1, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }

    }
}