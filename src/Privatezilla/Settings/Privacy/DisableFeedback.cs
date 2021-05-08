using Microsoft.Win32;
using Privatezilla.Locales;

namespace Privatezilla.Setting.Privacy
{
    internal class DisableFeedback: SettingBase
    {
        private const string PeriodInNanoSeconds = @"HKEY_CURRENT_USER\Software\Microsoft\Siuf\Rules";
        private const string NumberOfSIUFInPeriod = @"HKEY_CURRENT_USER\Software\Microsoft\Siuf\Rules";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return Locale.settingsPrivacyDisableFeedback;
        }

        public override string Info()
        {
            return Locale.settingsPrivacyDisableFeedbackInfo;
        }

        public override bool CheckSetting()
        {
            return !(
                    RegistryHelper.IntEquals(PeriodInNanoSeconds, "PeriodInNanoSeconds", DesiredValue) &&
                    RegistryHelper.IntEquals(NumberOfSIUFInPeriod, "NumberOfSIUFInPeriod", DesiredValue)
                );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(PeriodInNanoSeconds, "PeriodInNanoSeconds", DesiredValue, RegistryValueKind.DWord);
                Registry.SetValue(NumberOfSIUFInPeriod, "NumberOfSIUFInPeriod", DesiredValue, RegistryValueKind.DWord);
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
                var RegKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Siuf\Rules", true);
                RegKey.DeleteValue("NumberOfSIUFInPeriod");
                RegKey.DeleteValue("PeriodInNanoSeconds");
                return true;

            }
            catch
            { }

            return false;
        }


    }
}