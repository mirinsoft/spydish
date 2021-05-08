using Microsoft.Win32;
using Privatezilla.Locales;

namespace Privatezilla.Setting.Privacy
{
    internal class SuggestedApps : SettingBase
    {
        private const string SuggestedKey = @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return Locale.settingsPrivacyBlockSuggestedApps;
        }

        public override string Info()
        {
            return Locale.settingsPrivacyBlockSuggestedAppsInfo;
        }

        public override bool CheckSetting()
        {
             return !(
            RegistryHelper.IntEquals(SuggestedKey, "SubscribedContent-338388Enabled", DesiredValue)
                );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(SuggestedKey, "SubscribedContent-338388Enabled", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(SuggestedKey, "SubscribedContent-338388Enabled", 1 , RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }

    }
}