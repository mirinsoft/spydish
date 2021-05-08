using Microsoft.Win32;
using Privatezilla.Locales;

namespace Privatezilla.Setting.Privacy
{
    internal class DisableTipsLockScreen : SettingBase
    {
        private const string SpotlightKey = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager";
        private const string LockScreenKey = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager";
        private const string TipsTricksSuggestions = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return Locale.settingsPrivacyDisableTipsLockScreen;

        }

        public override string Info()
        {
            return Locale.settingsPrivacyDisableTipsLockScreenInfo;
        }

        public override bool CheckSetting()
        {
            return !(
                RegistryHelper.IntEquals(SpotlightKey, "RotatingLockScreenEnabled", DesiredValue) &&
                RegistryHelper.IntEquals(LockScreenKey, "RotatingLockScreenOverlayEnabled", DesiredValue) &&
                RegistryHelper.IntEquals(TipsTricksSuggestions, "SubscribedContent-338389Enabled", DesiredValue)
             );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(SpotlightKey, "RotatingLockScreenEnabled", DesiredValue, RegistryValueKind.DWord);
                Registry.SetValue(LockScreenKey, "RotatingLockScreenOverlayEnabled", DesiredValue, RegistryValueKind.DWord);
                Registry.SetValue(TipsTricksSuggestions, "SubscribedContent-338389Enabled", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(SpotlightKey, "RotatingLockScreenEnabled", 1, RegistryValueKind.DWord);
                Registry.SetValue(LockScreenKey, "RotatingLockScreenOverlayEnabled", 1, RegistryValueKind.DWord);
                Registry.SetValue(TipsTricksSuggestions, "SubscribedContent-338389Enabled", 1, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }

    }
}