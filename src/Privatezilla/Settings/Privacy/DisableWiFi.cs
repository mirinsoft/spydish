using Microsoft.Win32;
using Privatezilla.Locales;

namespace Privatezilla.Setting.Privacy
{
    internal class DisableWiFi : SettingBase
    {
        private const string WiFiKey = @"HKEY_LOCAL_MACHINE\Software\Microsoft\WcmSvc\wifinetworkmanager\config";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return Locale.settingsPrivacyDisableWiFi;
        }

        public override string Info()
        {
            return Locale.settingsPrivacyDisableWiFiInfo;
        }

        public override bool CheckSetting()
        {
            return !(
            RegistryHelper.IntEquals(WiFiKey, "AutoConnectAllowedOEM", DesiredValue)

            );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(WiFiKey, "AutoConnectAllowedOEM", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(WiFiKey, "AutoConnectAllowedOEM", 1, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }

    }
}