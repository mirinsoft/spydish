using Microsoft.Win32;
using Privatezilla.Locales;

namespace Privatezilla.Setting.Privacy
{
    internal class DisableTimeline : SettingBase
    {
        private const string EnableActivityFeed = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\System";
        private const string PublishUserActivities = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\System";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return Locale.settingsPrivacyDisableTimeline;
        }

        public override string Info()
        {
            return Locale.settingsPrivacyDisableTimelineInfo.Replace("\\n", "\n");
        }

        public override bool CheckSetting()
        {
            return !(
                RegistryHelper.IntEquals(EnableActivityFeed, "EnableActivityFeed", DesiredValue) &&
                RegistryHelper.IntEquals(PublishUserActivities, "PublishUserActivities", DesiredValue)
            );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(EnableActivityFeed, "EnableActivityFeed", DesiredValue, RegistryValueKind.DWord);
                Registry.SetValue(PublishUserActivities, "PublishUserActivities", DesiredValue, RegistryValueKind.DWord);
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
                var RegKey = Registry.LocalMachine.OpenSubKey(@"Software\Policies\Microsoft\Windows\System", true);
                RegKey.DeleteValue("EnableActivityFeed");
                RegKey.DeleteValue("PublishUserActivities");

                return true;
            }
            catch
            { }

            return false;
        }

    }
}