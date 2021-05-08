using System;
using System.Management.Automation;
using System.IO;
using Privatezilla.Locales;

namespace Privatezilla.Setting.Bloatware
{
    internal class RemoveUWPDefaults : SettingBase
    {
        public override string ID()
        {
            return Locale.settingsBloatwareRemoveUWPDefaults;
        }

        public override string Info()
        {
            return Locale.settingsBloatwareRemoveUWPDefaultsInfo.Replace("\\n", "\n");
        }

        public override bool CheckSetting()
        {
            // NOTE! OPTIMIZE
            // Check if app Windows.Photos exists and return false as configured
            var appPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Packages", "Microsoft.Windows.Photos_8wekyb3d8bbwe");

            if (Directory.Exists(appPath))
            {
                return false;
            }


            return true;
        }

        public override bool DoSetting()
        {
            using (PowerShell script = PowerShell.Create())
            {
                script.AddScript("Get-appxprovisionedpackage –online | where-object {$_.packagename –notlike “*store*” -and $_.packagename –notlike “*appinstaller*” -and $_.packagename –notlike “*calculator*” -and $_.packagename –notlike “*photos*” -and $_.packagename –notlike “*sticky*” -and $_.packagename –notlike “*skypeapp*” -and $_.packagename –notlike “*alarms*” -and $_.packagename –notlike “*maps*” -and $_.packagename –notlike “*camera*” -and $_.packagename –notlike “*xbox*” -and $_.packagename –notlike “*communicationssapps*” -and $_.packagename –notlike “*zunemusic*” -and $_.packagename –notlike “*mspaint*” -and $_.packagename –notlike “*yourphone*” -and $_.packagename –notlike “*bingweather*”} | Remove-AppxProvisionedPackage –online");
                script.AddScript("Get-AppxPackage | where-object {$_.name –notlike “*store*” -and $_.name –notlike “*appinstaller*” -and $_.name –notlike “*calculator*” -and $_.name –notlike “*photos*” -and $_.name –notlike “*sticky*” -and $_.name –notlike “*skypeapp*” -and $_.name –notlike“*alarms*” -and $_.name –notlike “*maps*” -and $_.name –notlike “*camera*” -and $_.name –notlike “*xbox*” -and $_.name –notlike “*communicationssapps*” -and $_.name –notlike “*zunemusic*” -and $_.name –notlike “*mspaint*” -and $_.name –notlike “*yourphone*” -and $_.name –notlike “*bingweather*”} | Remove-AppxPackage");

                try
                {
                    script.Invoke();
                }
                catch
                { }
            }

            return true;
        }

        public override bool UndoSetting()
        {
            using (PowerShell script = PowerShell.Create())
            {
                script.AddScript("Get-AppxPackage -AllUsers| Foreach {Add-AppxPackage -DisableDevelopmentMode -Register “$($_.InstallLocation)\\AppXManifest.xml”}");

                try
                {
                    script.Invoke();
                    return true;
                }
                catch
                { }

                return false;
            }
        }

    }
}