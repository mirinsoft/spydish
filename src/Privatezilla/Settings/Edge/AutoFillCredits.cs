using Microsoft.Win32;
using Privatezilla.Locales;

namespace Privatezilla.Setting.Edge
{
    internal class DisableAutoFillCredits : SettingBase
    {
        private const string EdgeKey = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Edge";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return Locale.settingsEdeAutoFillCredit;
        }

        public override string Info()
        {
            return Locale.settingsEdeAutoFillCreditInfo;
        }

        public override bool CheckSetting()
        {
            return !(
               RegistryHelper.IntEquals(EdgeKey, "AutofillCreditCardEnabled", DesiredValue)
             );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(EdgeKey, "AutofillCreditCardEnabled", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(EdgeKey, "AutofillCreditCardEnabled", 1, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }

    }
}