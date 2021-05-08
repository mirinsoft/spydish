using Microsoft.Win32;
using Privatezilla.Locales;

namespace Privatezilla.Setting.Privacy
{
    internal class DiagnosticData : SettingBase
    {
        private const string DiagnosticKey = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Privacy";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return Locale.settingsPrivacyDiagnosticData;
        }

        public override string Info()
        {
            return Locale.settingsPrivacyDiagnosticDataInfo;
        }

        public override bool CheckSetting()
        {
            return !(
        RegistryHelper.IntEquals(DiagnosticKey, "TailoredExperiencesWithDiagnosticDataEnabled", DesiredValue)
             );

        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(DiagnosticKey, "TailoredExperiencesWithDiagnosticDataEnabled", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(DiagnosticKey, "TailoredExperiencesWithDiagnosticDataEnabled", 1, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }

    }
}