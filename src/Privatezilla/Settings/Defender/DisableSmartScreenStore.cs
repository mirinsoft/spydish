﻿using Microsoft.Win32;

namespace Privatezilla.Setting.Defender
{
    internal class DisableSmartScreenStore: SettingBase
    {
        private const string DefenderKey = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\AppHost";
        private const int DesiredValue = 0;

        public override string ID()
        {
            return "Disable SmartScreen for Store Apps";
        }

        public override string Info()
        {
            return "Windows Defender SmartScreen Filter helps protect your device by checking web content (URLs) that Microsoft Store apps use.";
        }

        public override bool CheckSetting()
        {
            return !(
               RegistryHelper.IntEquals(DefenderKey, "EnableWebContentEvaluation", DesiredValue)
             );
        }

        public override bool DoSetting()
        {
            try
            {
                Registry.SetValue(DefenderKey, "EnableWebContentEvaluation", DesiredValue, RegistryValueKind.DWord);
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

                var RegKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\AppHost", true);
                RegKey.DeleteValue("EnableWebContentEvaluation");

                return true;
            }
            catch
            { }

            return false;
        }
    }
}