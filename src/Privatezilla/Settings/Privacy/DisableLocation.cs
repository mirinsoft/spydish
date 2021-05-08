using Microsoft.Win32;
using Privatezilla.Locales;

namespace Privatezilla.Setting.Privacy
{
    internal class DisableLocation : SettingBase
    {
        private const string LocationKey = @"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\location";
        private const string DesiredValue = @"Deny";

        public override string ID()
        {
            return Locale.settingsPrivacyDisableLocation;
        }

        public override string Info()
        {
            return Locale.settingsPrivacyDisableLocationInfo;
        }

        public override bool CheckSetting()
        {
            return !(
                RegistryHelper.StringEquals(LocationKey, "Value", DesiredValue)
            );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(LocationKey, "Value", DesiredValue, RegistryValueKind.String);
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
                Registry.SetValue(LocationKey, "Value", "Allow", RegistryValueKind.String);
                return true;
            }
            catch
            { }

            return false;
        }

    }
}