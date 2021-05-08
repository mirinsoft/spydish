using Microsoft.Win32;
using Privatezilla.Locales;

namespace Privatezilla.Setting.Edge
{
    internal class BlockEdgeRollout : SettingBase
    {
        private const string EdgeKey = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\EdgeUpdate";
        private const int DesiredValue = 1;

        public override string ID()
        {
            return Locale.settingsEdgeBlockEdgeRollout;
        }

        public override string Info()
        {
            return Locale.settingsEdgeBlockEdgeRolloutInfo;
        }

        public override bool CheckSetting()
        {
            return !(
               RegistryHelper.IntEquals(EdgeKey, "DoNotUpdateToEdgeWithChromium", DesiredValue)
             );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(EdgeKey, "DoNotUpdateToEdgeWithChromium", DesiredValue, RegistryValueKind.DWord);
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
                Registry.SetValue(EdgeKey, "DoNotUpdateToEdgeWithChromium", 0, RegistryValueKind.DWord);
                return true;
            }
            catch
            { }

            return false;
        }

    }
}