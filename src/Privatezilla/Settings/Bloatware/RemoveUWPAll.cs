﻿using System;
using System.Management.Automation;
using System.IO;

namespace Privatezilla.Setting.Bloatware
{
    internal class RemoveUWPAll : SettingBase
    {
        public override string ID()
        {
            return "Remove all built-in apps";
        }

        public override string Info()
        {
            return "This will remove all built-in apps except Microsoft Store.";
        }

        public override bool CheckSetting()
        {
            // NOTE! OPTIMIZE
            // Check if app Windows.Photos exists and return true as not configured
            var appPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Packages", "Microsoft.Windows.Photos_8wekyb3d8bbwe");

            if (Directory.Exists(appPath))
            {
                return true;
            }


            return false;
        }

        public override bool DoSetting()
        {
            using (PowerShell script = PowerShell.Create())
            {
                script.AddScript("Get-appxprovisionedpackage –online | where-object {$_.packagename –notlike “*store*”} | Remove-AppxProvisionedPackage –online");
                script.AddScript("Get-AppxPackage | where-object {$_.name –notlike “*store*”} | Remove-AppxPackage");

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
                {}

                return false;
            }
        }

    }
}