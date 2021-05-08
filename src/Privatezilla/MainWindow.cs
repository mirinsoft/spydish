using Privatezilla.ITreeNode;
using Privatezilla.Locales;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Privatezilla
{
    public partial class MainWindow : Form
    {
        // Setting progress
        private int _progress = 0;

        private int _progressIncrement = 0;

        // Update
        private readonly string _releaseURL = "https://raw.githubusercontent.com/builtbybel/privatezilla/master/latest.txt";

        public Version CurrentVersion = new Version(Application.ProductVersion);
        public Version LatestVersion;

        private void CheckRelease_Click(object sender, EventArgs e)
        {
            try
            {
                WebRequest hreq = WebRequest.Create(_releaseURL);
                hreq.Timeout = 10000;
                hreq.Headers.Set("Cache-Control", "no-cache, no-store, must-revalidate");

                WebResponse hres = hreq.GetResponse();
                StreamReader sr = new StreamReader(hres.GetResponseStream());

                LatestVersion = new Version(sr.ReadToEnd().Trim());

                // Done and dispose!
                sr.Dispose();
                hres.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); // Update check failed!
            }

            var equals = LatestVersion.CompareTo(CurrentVersion);

            if (equals == 0)
            {
                MessageBox.Show(Locale.releaseUpToDate, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information); // Up-to-date
            }
            else if (equals < 0)
            {
                MessageBox.Show(Locale.releaseUnofficial, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning); // Unofficial
            }
            else // New release available!
            {
                if (MessageBox.Show(Locale.releaseUpdateAvailable + LatestVersion + Locale.releaseUpdateYourVersion.Replace("\\r\\n", "\r\n") + CurrentVersion + Locale.releaseUpdateAvailableURL.Replace("\\r\\n", "\r\n\n"), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) // New release available!
                {
                    Process.Start("https://github.com/builtbybel/privatezilla/releases/tag/" + LatestVersion);
                }
            }
        }

        public void Globalization()
        {
            BtnDoPS.Text = Locale.BtnDoPS;
            BtnSettingsAnalyze.Text = Locale.BtnSettingsAnalyze;
            BtnSettingsDo.Text = Locale.BtnSettingsDo;
            BtnSettingsUndo.Text = Locale.BtnSettingsUndo;
            ChkCodePS.Text = Locale.ChkCodePS;
            LblPS.Text = Locale.LblPS;
            LblPSHeader.Text = Locale.LblPSHeader;
            LblSettings.Text = Locale.LblSettings;
            LblStatus.Text = Locale.LblStatus;
            TxtPSInfo.Text = Locale.TxtPSInfo;
            CheckRelease.Text = Locale.CheckRelease;
            CommunityPkg.Text = Locale.CommunityPkg;
            Help.Text = Locale.Help;
            Info.Text = Locale.Info;
            PSImport.Text = Locale.PSImport;
            PSMarketplace.Text = Locale.PSMarketplace;
            PSSaveAs.Text = Locale.PSSaveAs;
            Setting.Text = Locale.columnSetting; // Status column
            State.Text = Locale.columnState;     // State column
        }

        public MainWindow()
        {
            // Uncomment lower line and add lang code to run localization test
            // Thread.CurrentThread.CurrentUICulture = new CultureInfo("de");

            InitializeComponent();

            // Initilize settings
            InitializeSettings();

            // Check if community package is installed
            CommunityPackageAvailable();

            // GUI options
            LblMainMenu.Text = "\ue700";    // Hamburger menu

            // GUI localization
            Globalization();
        }

        public void InitializeSettings()
        {
            TvwSettings.Nodes.Clear();

            // Root node
            TreeNode root = new TreeNode("Windows 10 (" + WindowsHelper.GetOS() + ")")
            {
                Checked = false
            };

            // Settings > Privacy
            TreeNode privacy = new TreeNode(Locale.rootSettingsPrivacy, new TreeNode[] {
                new SettingNode(new Setting.Privacy.DisableTelemetry()),
                new SettingNode(new Setting.Privacy.DisableCompTelemetry()),
                new SettingNode(new Setting.Privacy.DisableAds()),
                new SettingNode(new Setting.Privacy.DisableWiFi()),
                new SettingNode(new Setting.Privacy.DiagnosticData()),
                new SettingNode(new Setting.Privacy.HandwritingData()),
                new SettingNode(new Setting.Privacy.DisableBiometrics()),
                new SettingNode(new Setting.Privacy.DisableTimeline()),
                new SettingNode(new Setting.Privacy.DisableLocation()),
                new SettingNode(new Setting.Privacy.DisableFeedback()),
                new SettingNode(new Setting.Privacy.DisableTips()),
                new SettingNode(new Setting.Privacy.DisableTipsLockScreen()),
                new SettingNode(new Setting.Privacy.InstalledApps()),
                new SettingNode(new Setting.Privacy.SuggestedApps()),
                new SettingNode(new Setting.Privacy.SuggestedContent()),
                new SettingNode(new Setting.Privacy.DisableCEIP()),
                new SettingNode(new Setting.Privacy.DisableHEIP()),
                new SettingNode(new Setting.Privacy.DisableMSExperiments()),
                new SettingNode(new Setting.Privacy.InventoryCollector()),
                new SettingNode(new Setting.Privacy.GetMoreOutOfWindows()),
            })
            {
                //Checked = true,
                //ToolTipText = "Privacy settings"
            };

            // Policies > Cortana
            TreeNode cortana = new TreeNode(Locale.rootSettingsCortana, new TreeNode[] {
                new SettingNode(new Setting.Cortana.DisableCortana()),
                new SettingNode(new Setting.Cortana.DisableBing()),
                new SettingNode(new Setting.Cortana.UninstallCortana()),
            });

            // Settings > Bloatware
            TreeNode bloatware = new TreeNode(Locale.rootSettingsBloatware, new TreeNode[] {
                new SettingNode(new Setting.Bloatware.RemoveUWPAll()),
                new SettingNode(new Setting.Bloatware.RemoveUWPDefaults()),
            })
            {
                ToolTipText = Locale.rootSettingsBloatwareInfo
            };

            // Settings > App permissions
            TreeNode apps = new TreeNode(Locale.rootSettingsApps, new TreeNode[] {
                new SettingNode(new Setting.Apps.AppNotifications()),
                new SettingNode(new Setting.Apps.Camera()),
                new SettingNode(new Setting.Apps.Microphone()),
                new SettingNode(new Setting.Apps.Call()),
                new SettingNode(new Setting.Apps.Notifications()),
                new SettingNode(new Setting.Apps.AccountInfo()),
                new SettingNode(new Setting.Apps.Contacts()),
                new SettingNode(new Setting.Apps.Calendar()),
                new SettingNode(new Setting.Apps.CallHistory()),
                new SettingNode(new Setting.Apps.Email()),
                new SettingNode(new Setting.Apps.Tasks()),
                new SettingNode(new Setting.Apps.Messaging()),
                new SettingNode(new Setting.Apps.Motion()),
                new SettingNode(new Setting.Apps.OtherDevices()),
                new SettingNode(new Setting.Apps.BackgroundApps()),
                new SettingNode(new Setting.Apps.TrackingApps()),
                new SettingNode(new Setting.Apps.DiagnosticInformation()),
                new SettingNode(new Setting.Apps.Documents()),
                new SettingNode(new Setting.Apps.Pictures()),
                new SettingNode(new Setting.Apps.Videos()),
                new SettingNode(new Setting.Apps.Radios()),
                new SettingNode(new Setting.Apps.FileSystem()),
                new SettingNode(new Setting.Apps.EyeGaze()),
                new SettingNode(new Setting.Apps.CellularData()),
            });

            // Settings > Updates
            TreeNode updates = new TreeNode(Locale.rootSettingsUpdates, new TreeNode[] {
                new SettingNode(new Setting.Updates.DisableUpdates()),
                new SettingNode(new Setting.Updates.DisableUpdatesSharing()),
                new SettingNode(new Setting.Updates.BlockMajorUpdates()),
                new SettingNode(new Setting.Updates.DisableSafeguards()),
            });

            // Settings > Gaming
            TreeNode gaming = new TreeNode(Locale.rootSettingsGaming, new TreeNode[] {
                new SettingNode(new Setting.Gaming.DisableGameBar()),
            });

            // Settings > Windows Defender
            TreeNode defender = new TreeNode(Locale.rootSettingsDefender, new TreeNode[] {
                new SettingNode(new Setting.Defender.DisableSmartScreenStore()),
            });

            // Settings > Microsoft Edge
            TreeNode edge = new TreeNode(Locale.rootSettingsEdge, new TreeNode[] {
                new SettingNode(new Setting.Edge.DisableAutoFillCredits()),
                new SettingNode(new Setting.Edge.EdgeBackground()),
                new SettingNode(new Setting.Edge.DisableSync()),
                new SettingNode(new Setting.Edge.BlockEdgeRollout()),
            });

            // Settings > Security
            TreeNode security = new TreeNode(Locale.rootSettingsSecurity, new TreeNode[] {
                new SettingNode(new Setting.Security.DisablePassword()),
                new SettingNode(new Setting.Security.WindowsDRM()),
            });

            // Add root nodes
            root.Nodes.AddRange(new TreeNode[]
            {
                privacy,
                cortana,
                bloatware,
                apps,
                updates,
                gaming,
                defender,
                edge,
                security,
             });

            TvwSettings.Nodes.Add(root);
            TvwSettings.ExpandAll();

            // Preselect nodes
            CheckNodes(privacy);

            // Set up ToolTip text for TvwSettings
            ToolTip tooltip = new ToolTip();
            tooltip.AutoPopDelay = 15000;
            tooltip.IsBalloon = true;
            tooltip.SetToolTip(this.TvwSettings, Locale.LblSettings);
        }

        private List<SettingNode> CollectSettingNodes()
        {
            List<SettingNode> selectedSettings = new List<SettingNode>();

            foreach (TreeNode treeNode in TvwSettings.Nodes.All())
            {
                if (treeNode.Checked && treeNode.GetType() == typeof(SettingNode))
                {
                    selectedSettings.Add((SettingNode)treeNode);
                }
            }

            _progressIncrement = (int)Math.Floor(100.0f / selectedSettings.Count);

            return selectedSettings;
        }

        private void Reset()
        {
            _progress = 0;
            _progressIncrement = 0;

            PBar.Visible = true;
            PBar.Value = 0;
            LvwStatus.HeaderStyle = ColumnHeaderStyle.Clickable; // Add Header to ListView
            LvwStatus.Items.Clear();
            LvwStatus.Refresh();
        }

        private void IncrementProgress()
        {
            _progress += _progressIncrement;
            PBar.Value = _progress;
        }

        private void DoProgress(int value)
        {
            _progress = value;
            PBar.Value = _progress;
        }

        // Check favored parent node including all child nodes
        public void CheckNodes(TreeNode startNode)
        {
            startNode.Checked = true;

            foreach (TreeNode node in startNode.Nodes)

                CheckNodes(node);
        }

        /// <summary>
        ///  Auto check child nodes when parent node is checked
        /// </summary>
        private void TvwSetting_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TvwSettings.BeginUpdate();

            foreach (TreeNode child in e.Node.Nodes)
            {
                child.Checked = e.Node.Checked;
            }

            TvwSettings.EndUpdate();
        }

        /// <summary>
        ///  Method to auto. resize column and set the width to the width of the last item in ListView
        /// </summary>
        private void ResizeListViewColumns(ListView lv)
        {
            foreach (ColumnHeader column in lv.Columns)
            {
                column.Width = -2;
            }
        }

        /// <summary>
        /// Check system for configured settings
        /// </summary>
        private async void BtnSettingsAnalyze_Click(object sender, EventArgs e)
        {
            Reset();
            int performSettingsCount = 0;

            LblStatus.Text = Locale.statusDoWait;
            BtnSettingsAnalyze.Enabled = false;

            LvwStatus.BeginUpdate();

            List<SettingNode> selectedSettings = CollectSettingNodes();

            foreach (SettingNode node in selectedSettings)
            {
                var setting = node.Setting;
                ListViewItem state = new ListViewItem(node.Parent.Text + ": " + setting.ID());
                ConfiguredTaskAwaitable<bool> analyzeTask = Task<bool>.Factory.StartNew(() => setting.CheckSetting()).ConfigureAwait(true);

                bool shouldPerform = await analyzeTask;

                if (shouldPerform)
                {
                    state.SubItems.Add(Locale.statusFailedConfigure); // Not configured
                    state.BackColor = Color.LavenderBlush;

                    performSettingsCount += 1;
                }
                else
                {
                    state.SubItems.Add(Locale.statusSuccessConfigure); // Configured
                    state.BackColor = Color.Honeydew;
                }

                state.Tag = setting;
                LvwStatus.Items.Add(state);
                IncrementProgress();
            }

            DoProgress(100);

            // Summary
            var sum = (Locale.summarySelected + " " + $"{selectedSettings.Count}" + " - " + Locale.summaryConfigured + " " + $"{selectedSettings.Count - performSettingsCount}" + " - " + Locale.summaryNotConfigured + " " + $"{performSettingsCount}");
            LblStatus.Text = Locale.statusFinishAnalyze + "\n" + sum;

            BtnSettingsAnalyze.Enabled = true;
            LvwStatus.EndUpdate();

            ResizeListViewColumns(LvwStatus);
        }

        /// <summary>
        /// Apply selected settings
        /// </summary>
        ///
        private async void ApplySettings(List<SettingNode> treeNodes)
        {
            BtnSettingsDo.Enabled = false;
            LvwStatus.BeginUpdate();

            foreach (SettingNode node in treeNodes)
            {
                // Add status info
                LblStatus.Text = Locale.statusDoWait + " (" + node.Text + ")";

                var setting = node.Setting;
                ConfiguredTaskAwaitable<bool> performTask = Task<bool>.Factory.StartNew(() => setting.DoSetting()).ConfigureAwait(true);

                var result = await performTask;

                var listItem = new ListViewItem(setting.ID());
                if (result)
                {
                    listItem.SubItems.Add(Locale.statusSuccessApply); // Applied
                    listItem.BackColor = Color.Honeydew;
                }
                else
                {
                    listItem.SubItems.Add(Locale.statusFailedApply); // Not applied
                    listItem.BackColor = Color.LavenderBlush;
                }

                LvwStatus.Items.Add(listItem);
                IncrementProgress();
            }

            DoProgress(100);

            LblStatus.Text = Locale.statusFinishApply;
            BtnSettingsDo.Enabled = true;
            LvwStatus.EndUpdate();

            ResizeListViewColumns(LvwStatus);
        }

        /// <summary>
        ///  Revert selected settings
        /// </summary>
        private async void UndoSettings(List<SettingNode> treeNodes)
        {
            LblStatus.Text = Locale.statusDoWait;
            BtnSettingsUndo.Enabled = false;
            LvwStatus.BeginUpdate();

            foreach (SettingNode node in treeNodes)
            {
                var setting = node.Setting;
                ConfiguredTaskAwaitable<bool> performTask = Task<bool>.Factory.StartNew(() => setting.UndoSetting()).ConfigureAwait(true);

                var result = await performTask;

                var listItem = new ListViewItem(setting.ID());
                if (result)
                {
                    listItem.SubItems.Add(Locale.statusSuccessApply); // Applied
                    listItem.BackColor = Color.Honeydew;
                }
                else
                {
                    listItem.SubItems.Add(Locale.statusFailedApply); // Not applied
                    listItem.BackColor = Color.LavenderBlush;
                }

                LvwStatus.Items.Add(listItem);
                IncrementProgress();
            }

            DoProgress(100);

            LblStatus.Text = Locale.statusFinishUndo;
            BtnSettingsUndo.Enabled = true;
            LvwStatus.EndUpdate();

            ResizeListViewColumns(LvwStatus);
        }

        private void BtnSettingsDo_Click(object sender, EventArgs e)
        {
            Reset();

            List<SettingNode> performNodes = CollectSettingNodes();
            ApplySettings(performNodes);
        }

        private void BtnSettingsUndo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Locale.statusUndoSettings, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Reset();

                List<SettingNode> performNodes = CollectSettingNodes();
                UndoSettings(performNodes);
            }
        }

        private void Info_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Privatezilla" + "\nVersion " + Program.GetCurrentVersionTostring() + " (Pollux)\r\n" +
                                            Locale.infoApp.Replace("\\t", "\t"), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LblMainMenu_Click(object sender, EventArgs e)
        {
            this.MainMenu.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Locale.helpApp.Replace("\\r\\n", "\r\n"), Help.Text, MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        /// <summary>
        /// Populate Setting files to Navigation > settings > LstPopulatePS
        /// </summary>
        private void PopulatePS()
        {
            // Switch to More
            PnlPS.Visible = true;
            BtnDoPS.Visible = true;
            ChkCodePS.Visible = true;
            LstPS.Visible = true;

            PnlSettings.Visible = false;
            BtnSettingsAnalyze.Visible = false;
            BtnSettingsUndo.Visible = false;
            BtnSettingsDo.Visible = false;
            TvwSettings.Visible = false;

            // Clear list
            LstPS.Items.Clear();

            DirectoryInfo dirs = new DirectoryInfo(@"scripts");
            FileInfo[] listSettings = dirs.GetFiles("*.ps1");
            foreach (FileInfo fi in listSettings)
            {
                LstPS.Items.Add(Path.GetFileNameWithoutExtension(fi.Name));
                LstPS.Enabled = true;
            }
        }

        private void LblPS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Show Info about feature
            try
            {
                StreamReader OpenFile = new StreamReader(@"scripts\" + "readme.txt");
                MessageBox.Show(OpenFile.ReadToEnd(), "Info about this feature", MessageBoxButtons.OK);
                OpenFile.Close();
            }
            catch
            { }

            // Refresh
            PopulatePS();
        }

        private void LblSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Switch to Setting
            PnlSettings.Visible = true;
            BtnSettingsAnalyze.Visible = true;
            BtnSettingsUndo.Visible = true;
            BtnSettingsDo.Visible = true;
            TvwSettings.Visible = true;

            PnlPS.Visible = false;
            BtnDoPS.Visible = false;
            ChkCodePS.Visible = false;
            LstPS.Visible = false;
        }

        private void LstPS_SelectedIndexChanged(object sender, EventArgs e)
        {
            string psdir = @"scripts\" + LstPS.Text + ".ps1";

            //Read PS content line by line
            try
            {
                using (StreamReader sr = new StreamReader(@"scripts\" + LstPS.Text + ".ps1", Encoding.Default))
                {
                    StringBuilder content = new StringBuilder();

                    // writes line by line to the StringBuilder until the end of the file is reached
                    while (!sr.EndOfStream)
                        content.AppendLine(sr.ReadLine());

                    // View Code
                    TxtConsolePS.Text = content.ToString();

                    // View Info
                    TxtPSInfo.Text = Locale.PSInfo.Replace("\\r\\n", "\r\n") + string.Join(Environment.NewLine, System.IO.File.ReadAllLines(psdir).Where(s => s.StartsWith("###")).Select(s => s.Substring(3).Replace("###", "\r\n\n")));
                }
            }
            catch { }
        }

        /// <summary>
        /// Run custom PowerShell scripts
        /// </summary>
        private async void BtnDoPS_Click(object sender, EventArgs e)
        {
            if (LstPS.CheckedItems.Count == 0)
            {
                MessageBox.Show(Locale.msgPSSelect, BtnDoPS.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            for (int i = 0; i < LstPS.Items.Count; i++)
            {
                if (LstPS.GetItemChecked(i))
                {
                    LstPS.SelectedIndex = i;
                    string psdir = @"scripts\" + LstPS.SelectedItem.ToString() + ".ps1";
                    var ps1File = psdir;

                    var equals = new[] { "Silent" };
                    var str = TxtPSInfo.Text;

                    BtnDoPS.Text = Locale.statusDoPSProcessing;
                    PnlPS.Enabled = false;

                    // Silent
                    if (equals.Any(str.Contains))
                    {
                        var startInfo = new ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = $"-executionpolicy bypass -file \"{ps1File}\"",
                            UseShellExecute = false,
                            CreateNoWindow = true,
                        };

                        await Task.Run(() => { Process.Start(startInfo).WaitForExit(); });
                    }
                    else   // Create ConsoleWindow
                    {
                        var startInfo = new ProcessStartInfo()
                        {
                            FileName = "powershell.exe",
                            Arguments = $"-executionpolicy bypass -file \"{ps1File}\"",
                            UseShellExecute = false,
                        };

                        await Task.Run(() => { Process.Start(startInfo).WaitForExit(); });
                    }

                    BtnDoPS.Text = Locale.statusDoPSApply;
                    PnlPS.Enabled = true;

                    // Done!
                    MessageBox.Show("Script " + "\"" + LstPS.Text + "\" " + Locale.msgPSSuccess, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Open PowerShell code view
        /// </summary>
        private void ChkCodePS_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkCodePS.Checked == true)
            {
                ChkCodePS.Text = Locale.PSBack;
                TxtConsolePS.Visible = true;
            }
            else
            {
                ChkCodePS.Text = Locale.ChkCodePS;
                TxtConsolePS.Visible = false;
            }
        }

        /// <summary>
        /// Import PowerShell script files
        /// </summary>
        private void PSImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "*.txt|*.txt|*.ps1|*.ps1";
            ofd.DefaultExt = ".ps1";
            ofd.RestoreDirectory = true;
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ofd.FilterIndex = 2;

            string strDestPath = Application.StartupPath + @"\scripts";
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in ofd.FileNames)
                {
                    try
                    {
                        File.Copy(fileName, strDestPath + @"\" + Path.GetFileName(fileName));
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message, this.Text); }
                }
            }

            // Refresh
            PopulatePS();
        }

        /// <summary>
        /// Save PowerShell script files as new preset script files
        /// </summary>
        private void PSSaveAs_Click(object sender, EventArgs e)
        {
            if (ChkCodePS.Checked == false)
            {
                MessageBox.Show(Locale.msgPSSave, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "*.txt|*.txt|*.ps1|*.ps1";
                dlg.DefaultExt = ".ps1";
                dlg.RestoreDirectory = true;
                dlg.InitialDirectory = Application.StartupPath + @"\scripts";
                dlg.FilterIndex = 2;

                try
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(dlg.FileName, TxtConsolePS.Text, Encoding.UTF8);
                        //Refresh
                        PopulatePS();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void PSMarketplace_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/builtbybel/privatezilla/tree/master/scripts");
        }

        private void CommunityPkg_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/builtbybel/privatezilla#community-package");
        }

        // Check if community package installed
        private void CommunityPackageAvailable()
        {
            string path = @"scripts";
            if (Directory.Exists(path))
            {
                LblPS.Visible = true;
                CommunityPkg.Visible = false;
            }
        }

        private bool sortAscending = false;

        private void LvwStatus_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (!sortAscending)
            {
                sortAscending = true;
            }
            else
            {
                sortAscending = false;
            }
            this.LvwStatus.ListViewItemSorter = new ListViewItemComparer(e.Column, sortAscending);
        }

        private void BtnMenuPS_Click(object sender, EventArgs e)
        {
            this.PSMenu.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void assetOpenGitHubPage_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/builtbybel/privatezilla");
        }
    }
}