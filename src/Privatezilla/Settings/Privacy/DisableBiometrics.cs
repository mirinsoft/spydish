using Microsoft.Win32;
using Privatezilla.Locales;

namespace Privatezilla.Setting.Privacy
{
    internal class DisableBiometrics : SettingBase
    {
        private const string BiometricsKey = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Biometrics";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return Locale.settingsPrivacyDisableBiometrics;
        }

        public override string Info()
        {
            return Locale.settingsPrivacyDisableBiometricsInfo;
        }

        public override bool CheckSetting()
        {
            return !(
                RegistryHelper.IntEquals(BiometricsKey, "Enabled", DesiredValue)
              );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(BiometricsKey, "Enabled", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(BiometricsKey, "Enabled", 1, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }


    }
}