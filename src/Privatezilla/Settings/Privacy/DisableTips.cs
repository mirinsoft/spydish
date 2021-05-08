using Microsoft.Win32;
using Privatezilla.Locales;

namespace Privatezilla.Setting.Privacy
{
    internal class DisableTips: SettingBase
    {
        private const string DisableSoftLanding = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\CloudContent";
        private const string DisableWindowsSpotlightFeatures = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\CloudContent";
        private const string DisableWindowsConsumerFeatures = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\CloudContent";
        private const string DoNotShowFeedbackNotifications = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\DataCollection";
        private const int DesiredValue = 1;

        public override string ID()
        {
            return Locale.settingsPrivacyDisableTips;
        }

        public override string Info()
        {
            return Locale.settingsPrivacyDisableTipsInfo;
        }

        public override bool CheckSetting()
        {
            return !(
                 RegistryHelper.IntEquals(DisableSoftLanding, "DisableSoftLanding", DesiredValue) &&
                 RegistryHelper.IntEquals(DisableWindowsSpotlightFeatures, "DisableWindowsSpotlightFeatures", DesiredValue) &&
                 RegistryHelper.IntEquals(DisableWindowsConsumerFeatures, "DisableWindowsConsumerFeatures", DesiredValue) &&
                 RegistryHelper.IntEquals(DoNotShowFeedbackNotifications, "DoNotShowFeedbackNotifications", DesiredValue)
             );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(DisableSoftLanding, "DisableSoftLanding", DesiredValue, RegistryValueKind.DWord);
                Registry.SetValue(DisableWindowsSpotlightFeatures, "DisableWindowsSpotlightFeatures", DesiredValue, RegistryValueKind.DWord);
                Registry.SetValue(DisableWindowsConsumerFeatures, "DisableWindowsConsumerFeatures", DesiredValue, RegistryValueKind.DWord);
                Registry.SetValue(DoNotShowFeedbackNotifications, "DoNotShowFeedbackNotifications", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(DisableSoftLanding, "DisableSoftLanding", 0, RegistryValueKind.DWord);
                Registry.SetValue(DisableWindowsSpotlightFeatures, "DisableWindowsSpotlightFeatures", 0, RegistryValueKind.DWord);
                Registry.SetValue(DisableWindowsConsumerFeatures, "DisableWindowsConsumerFeatures", 0, RegistryValueKind.DWord);
                Registry.SetValue(DoNotShowFeedbackNotifications, "DoNotShowFeedbackNotifications", 0, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }


    }
}