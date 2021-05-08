using Microsoft.Win32;
using Privatezilla.Locales;

namespace Privatezilla.Setting.Privacy
{
    internal class DisableAds : SettingBase
    {
        private const string AdsKey = @"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\AdvertisingInfo";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return Locale.settingsPrivacyDisableAds;
        }

        public override string Info()
        {
            return Locale.settingsPrivacyDisableAdsInfo;
        }

        public override bool CheckSetting()
        {
            return !(
               RegistryHelper.IntEquals(AdsKey, "Enabled", DesiredValue)
             );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(AdsKey, "Enabled", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(AdsKey, "Enabled", 1, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }

    }
}