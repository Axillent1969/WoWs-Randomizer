using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using WoWs_Randomizer.api;
using WoWs_Randomizer.forms;
using WoWs_Randomizer.utils;
using WoWs_Randomizer.utils.module;
using WoWs_Randomizer.utils.player;
using WoWs_Randomizer.utils.ship;
using WoWs_Randomizer.utils.skills;
using WoWs_Randomizer.objects.consumables;
using WoWs_Randomizer.objects;
using WoWs_Randomizer.objects.version;
using WoWs_Randomizer.objects.player;

namespace WoWs_Randomizer
{
    public partial class FormRandomizer : Form
    {
        private delegate void SafeCallDelegate(string text);

        private bool isLoaded = false;
        private bool ShipLoaded = false;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0044:Add readonly modifier", Justification = "<Pending>")]
        private List<long> PersonalShips = new List<long>();
        private List<long> AlreadyRandomizedShips = new List<long>();
        private HashSet<long> ExcludedShips = new HashSet<long>();
        private Ship RandomizedShip = null;
        private List<ProgramVersionLog> ChangeLog = new List<ProgramVersionLog>();
        private string RandomizerVersion = "";
        private ProfileHandler profileHandler = new ProfileHandler();

        private ShipRandomizer Randomizer = null;
        private Updater randomizerUpdater = null;

        private bool callUpdateAll = false;

        public FormRandomizer()
        {
            InitializeComponent();
            lblQueue.Text = "";
            profileHandler.addMenuitem(menuProfileEU);
            profileHandler.addMenuitem(menuProfileNA);
            profileHandler.addMenuitem(menuProfileRU);
            profileHandler.uncheckAll();

            randomizerUpdater = new Updater();
            this.ChangeLog = randomizerUpdater.GetChangeLog();
            this.RandomizerVersion = randomizerUpdater.GetRandomizerVersion();

            Settings MySettings = Commons.GetSettings();
            if ( MySettings != null && !MySettings.Server.Equals(""))
            {
                profileHandler.checkItem(MySettings.Server.ToString());
            }
            if (randomizerUpdater.IsUpdateRequired() == false && MySettings != null && MySettings.UserID != 0)
            {
                LoadAllData();
            } else if ( MySettings == null )
            {
                OpenSettingsForceUpdate();
                this.Refresh();
                callUpdateAll = true;

            } else
            {
                callUpdateAll = true;
            }

            //bool upgradeFix = Properties.Settings.Default.UpgradeFix;
            //if ( upgradeFix == false )
            //{
            //    StartLoadingAnimation();
            //    UpgradeFixer.RunWorkerAsync();
            //}
        }

        //private void DoUpgradeFix()
        //{
        //    Updater.UpdateUpgradesInfo();
        //    BinarySerialize.WriteToBinaryFile<List<Ship>>(Commons.GetShipListFileName(), Program.AllShips);
        //}

        private void StartLoadingAnimation()
        {
            LoadingImage.Dock = DockStyle.Fill;
            LoadingImage.Visible = true;
        }

        private void LoadAllData()
        {
            bool allFilesLoaded = true;
            try { Program.AllModules = BinarySerialize.Read2<Dictionary<string, ModuleData>>(Commons.GetModulesFileName()); } catch (Exception) { allFilesLoaded = false; } 
            try { Program.AllShips = BinarySerialize.Read2<List<Ship>>(Commons.GetShipListFileName()); } catch (Exception) { allFilesLoaded = false; } 
            try { Program.Upgrades = BinarySerialize.ReadFromBinaryFile<List<Consumable>>(Commons.GetUpgradesFileName()); } catch(Exception) { allFilesLoaded = false; }
            try { Program.CommanderSkills = BinarySerialize.ReadFromBinaryFile<List<Skill>>(Commons.GetCommanderSkillFileName()); } catch(Exception) { allFilesLoaded = false; }
            try { Program.Flags = BinarySerialize.ReadFromBinaryFile<List<Consumable>>(Commons.GetFlagsFileName()); } catch (Exception) { allFilesLoaded = false; }

            if ( allFilesLoaded == false )
            {
                StartLoadingAnimation();
                BGUpdater.RunWorkerAsync();
            } else
            {
                FinalizeLoad();
            }
        }

        private void FinalizeLoad()
        {
            readPersonalShipsFile();
            LoadExcludedShips();
            UpdateCounterLabels();
            AddConsumablesInfo();
        }

        private void AddConsumablesInfo()
        {
            bool ForceSave = (Program.AllShips[0].Consumables == null || Program.AllShips[0].Consumables.Count == 0);
            Settings mySettings = Commons.GetSettings();
            Updater.AddConsumablesInfo(mySettings,ForceSave);
            Commons.SaveSettings(mySettings);

        }

        private void UpdateCounterLabels()
        {
            lblShipsInPort.Text = PersonalShips.Count.ToString() + " ships in port.";
            lblExcludedShips.Text = ExcludedShips.Count.ToString() + " excluded from randomization.";
        }

        private void readPersonalShipsFile()
        {
            string FileName = Commons.GetPersonalShipsFileName();
            this.PersonalShips.Clear();
            List<PlayerShip> Ships = BinarySerialize.ReadFromBinaryFile<List<PlayerShip>>(FileName);
            foreach (PlayerShip PlayerShipData in Ships)
            {
                Ship findShip = Program.AllShips.Find(x => x.ID == PlayerShipData.ID);
                if (findShip != null)
                {
                    if (!findShip.Name.StartsWith("["))
                    {
                        this.PersonalShips.Add(PlayerShipData.ID);
                    }
                }
                else
                {
                    this.PersonalShips.Add(PlayerShipData.ID);
                }
            }
        }

        public void LoadExcludedShips()
        {
            ExcludedShips.Clear();
            if (File.Exists(Commons.GetExclusionListFileName()))
            {
                ExcludedShips = BinarySerialize.ReadFromBinaryFile<HashSet<long>>(Commons.GetExclusionListFileName());
            }
        }

        /// <summary>
        /// Randomization process; Button click starts background worker and when it complete event triggers, finalizes the UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RandomizeButton_Click(object sender, EventArgs e)
        {
            shipDescription.Text = "";
            Settings settings = Commons.GetSettings();
            if (settings.SaveLocation.Equals("")) { BtnRecommendedBuild.Enabled = false; } else { BtnRecommendedBuild.Enabled = true; }

            RandomizedShip = null;
            LoadingImage.Dock = DockStyle.Fill;
            LoadingImage.Visible = true;
            BackgroundWorker.RunWorkerAsync();
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            RandomizeShip();
            Thread.Sleep(2000);
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ShipLoaded)
            {
                FlagImage.Visible = true;
                ShipImage.Visible = true;
                ShipName.Visible = true;
                ShipImage.Cursor = Cursors.Hand;
                toolTip1.SetToolTip(ShipImage, "Ship: " + ShipName.Text);
                BtnBuildMgr.Visible = true;
                BtnRecommendedBuild.Visible = true;
                NoShipFoundMsg.Visible = false;
                NoShipFoundHelpMsg.Visible = false;
                LoadShipMetrics();
            }
            else
            {
                FlagImage.Visible = false;
                ShipImage.Visible = false;
                ShipName.Visible = false;
                ShipImage.Cursor = Cursors.Default;
                toolTip1.SetToolTip(ShipImage, null);
                BtnRecommendedBuild.Visible = false;
                BtnBuildMgr.Visible = false;
                NoShipFoundMsg.Visible = true;
                NoShipFoundHelpMsg.Visible = true;
            }
            LoadingImage.Visible = false;
            LoadingImage.Dock = DockStyle.None;
            if (cbSingleSelect.Checked)
            {
                lblQueue.Text = AlreadyRandomizedShips.Count.ToString() + " of " + (PersonalShips.Count - ExcludedShips.Count).ToString() + " ships used.";
            }
            else
            {
                lblQueue.Text = "";
            }
        }

        private void RandomizeShip()
        {
            Ship ThisShip = GetRandomShip();
            if ( ThisShip != null )
            {
                RandomizedShip = ThisShip;
                FlagImage.Load(Commons.GetFlagURL(ThisShip.Country));
                ShipImage.Load(ThisShip.Images.Small);
                SetShipName(ThisShip.Name);
                SetDescription(ThisShip.Description);
                ShipLoaded = true;
                if ( ThisShip.Premium )
                {
                    ShipImage.BackColor = SystemColors.Info;
                } else
                {
                    ShipImage.BackColor = SystemColors.Control;
                }
                AlreadyRandomizedShips.Add(ThisShip.ID);
            } else
            {
                ShipLoaded = false;
            }
        }

        private void SetDescription(string text)
        {
            if (shipDescription.InvokeRequired)
            {
                var t = new SafeCallDelegate(SetDescription);
                shipDescription.Invoke(t, new object[] { text });
            }
            else
            {
                shipDescription.Text = text;
            }
        }

        private void SetShipName(string Name)
        {
            if ( ShipName.InvokeRequired)
            {
                var t = new SafeCallDelegate(SetShipName);
                ShipName.Invoke(t, new object[] { Name});
            } else
            {
                ShipName.Text = Name;
            }
        }

        private Ship GetRandomShip()
        {
            if ( Randomizer == null )
            {
                this.Randomizer = new ShipRandomizer(this.ExcludedShips);
                this.Randomizer.AddPersonalShips(this.PersonalShips);
            }
            Randomizer.AddSelection(GetSelection());
            return Randomizer.GetRandomShip();
        }

        private Dictionary<string,List<string>> GetSelection()
        {
            System.Collections.Generic.IEnumerable<CheckBox> CheckBoxes = LeftPanel.Controls.OfType<CheckBox>();
            List<string> selectionCC = new List<string>();
            List<string> selectionShipclass = new List<string>();
            List<string> selectionTier = new List<string>();
            List<string> selectionPremium = new List<string>();

            Dictionary<string, List<string>> selection = new Dictionary<string, List<string>>();

            foreach(CheckBox CB in CheckBoxes)
            {
                if ( CB.Checked )
                {
                    if ( CB.Name.Contains("Country"))
                    {
                        selectionCC.Add(CB.Tag.ToString());
                    } else if ( CB.Name.Contains("Shipclass"))
                    {
                        selectionShipclass.Add(CB.Tag.ToString());
                    } else if ( CB.Name.Contains("Tier"))
                    {
                        selectionTier.Add(CB.Tag.ToString());
                    } else if ( CB.Name.Contains("Premium"))
                    {
                        selectionPremium.Add(CB.Tag.ToString());
                    } else if ( CB.Name.Contains("cbSingleSelect"))
                    {
                        selection.Add("unique", new List<string>() { "true" });
                    }
                }
            }
            selection.Add("country", selectionCC);
            selection.Add("shipclass", selectionShipclass);
            selection.Add("tier", selectionTier);
            selection.Add("premium", selectionPremium);
            return selection;
        }
        
        private void ShipImage_Click(object sender, EventArgs e)
        {
            WGAPI.OpenShipWikipedia(ShipName.Text.ToString());
        }

        private void LoadShipMetrics()
        {
            if ( RandomizedShip == null ) { return;  }

            MetricsExctractor Extractor = new MetricsExctractor(RandomizedShip);
            MetricsDrawer Drawer = new MetricsDrawer(ShipMetricsTable);
            MetricsTableComposer.DrawTable(Extractor, Drawer);

            try
            {
                Settings settings = Commons.GetSettings();
                string fileName = settings.SaveLocation;
                if (!fileName.EndsWith("\\"))
                {
                    fileName += @"\";
                }
                fileName += RandomizedShip.Name + ".bld";

                ShipBuild build = null;
                if (File.Exists(fileName))
                {
                    build = BinarySerialize.ReadFromBinaryFile<ShipBuild>(fileName);
                }

                if (build != null)
                {
                    BuildManagerHandler bmHandler = new BuildManagerHandler(ShipMetricsTable, Extractor.GetMetrics());
                    bmHandler.PerformAnimation(false);
                    bmHandler.KeepBackgroundTransparent(false);
                    bmHandler.ApplyAll(build.Flags);
                    bmHandler.ApplyAll(build.Skills);
                    bmHandler.ApplyAll(build.Upgrades);
                }
            }
            catch (Exception) { }
        }

        private void BtnBuildMgr_Click(object sender, EventArgs e)
        {
            BuildManager BManager = new BuildManager();
            BManager.SelectShip(RandomizedShip);
            BManager.Show();
        }

        private void BtnRecommendedBuild_Click(object sender, EventArgs e)
        {
            Settings settings = Commons.GetSettings();
            if ( !settings.SaveLocation.Equals("") )
            {
                string filename = settings.SaveLocation + "\\" + RandomizedShip.Name + ".bld";
                if ( File.Exists(filename ))
                {
                    ShipBuild build = BinarySerialize.ReadFromBinaryFile<ShipBuild>(filename);
                    if ( build != null)
                    {
                        BuildManager BManager = new BuildManager();
                        BManager.LoadBuild(build);
                        BManager.Show();
                    } else
                    {
                        MessageBox.Show("Couldn\'t open personal build.", "Unable to open personal build", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else
                {
                    MessageBox.Show("Couldn\'t find a build to open. File must be named with shipname only: '" + filename + "'.", "Unable to open personal build", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OpenSettingsForceUpdate()
        {
            FormSettings settingsForm = new FormSettings();

            if (settingsForm.ShowDialog(this) == DialogResult.OK)
            {
                callUpdateAll = true;
            }
            settingsForm.Dispose();
        }

        private void cbSingleSelect_CheckedChanged(object sender, EventArgs e)
        {
            AlreadyRandomizedShips.Clear();
        }

        private void exportShips(string filename,int filterIndex)
        {
            string separator = ",";
            if (filterIndex == 1)
            {
                separator = " ";
            }
            using (StreamWriter file = new StreamWriter(filename))
            {
                file.WriteLine("ID"+separator+"Name"+separator+"ShipId" + separator + "Type" +separator+"Tier");
                foreach (Ship ship in Program.AllShips)
                {
                    file.WriteLine(ship.ID + separator + ship.Name.Replace("\n","") + separator + ship.ShipId + separator + ship.ShipType + separator + ship.Tier);
                }
            }
        }

        private void exportModules(string filename, int filterIndex)
        {
            string separator = ",";
            if (filterIndex == 1)
            {
                separator = " ";
            }

            using (StreamWriter file = new StreamWriter(filename))
            {
                file.WriteLine("ID"+separator+"IdString"+separator+"Name" + separator + "Type");
                foreach(KeyValuePair<string,ModuleData> kvPair in Program.AllModules)
                {
                    ModuleData data = kvPair.Value;
                    string txt = data.ID.ToString() + separator;
                    txt += data.IDString + separator;
                    txt += data.Name.Replace("\n","") + separator;
                    txt += data.Type;

                    file.WriteLine(txt);
                }
            }
        }

        private void exportMyShips(string filename, int filterIndex)
        {
            string separator = ",";
            if ( filterIndex == 1)
            {
                separator = " ";
            }

            using (StreamWriter file = new StreamWriter(filename))
            {
                file.WriteLine("ID"+separator + "IdString" + separator + "Name" + separator + "Type" + separator + "Excluded");
                foreach(long shipId in PersonalShips)
                {
                    Ship ship = Program.AllShips.Find(x => x.ID == shipId);
                    if ( ship != null )
                    {
                        if ( ExcludedShips.Contains(shipId))
                        {
                            file.WriteLine(ship.ID + separator + ship.Name.Replace("\n", "") + separator + ship.ShipId + separator + ship.ShipType + separator + ship.Tier + separator + "Y");
                        } else
                        {
                            file.WriteLine(ship.ID + separator + ship.Name.Replace("\n", "") + separator + ship.ShipId + separator + ship.ShipType + separator + ship.Tier + separator + "N");
                        }
                    }
                }
            }
        }


        /// TOOLSTRIP EVENTS/METHODS
        /// 
        private void listOfShipsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "txt files (*.txt)|*.txt|csv files (*.csv)|*.csv|All files (*.*)|*.*";
            fileDialog.DefaultExt = "csv";
            fileDialog.FilterIndex = 2;
            fileDialog.CheckFileExists = false;
            fileDialog.CheckPathExists = true;
            fileDialog.SupportMultiDottedExtensions = false;
            fileDialog.Title = "Export list of ships";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                exportShips(fileDialog.FileName, fileDialog.FilterIndex);
                MessageBox.Show("File saved: " + fileDialog.FileName, "List exported", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void listOfModulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "txt files (*.txt)|*.txt|csv files (*.csv)|*.csv|All files (*.*)|*.*";
            fileDialog.DefaultExt = "csv";
            fileDialog.FilterIndex = 2;
            fileDialog.CheckFileExists = false;
            fileDialog.CheckPathExists = true;
            fileDialog.SupportMultiDottedExtensions = false;
            fileDialog.Title = "Export list of modules/upgrades";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                exportModules(fileDialog.FileName, fileDialog.FilterIndex);
                MessageBox.Show("File saved: " + fileDialog.FileName, "List exported", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void loadUserShipsInPort(long UserID, bool hideMessage = false)
        {
            PlayerShipImport Importer = WGAPI.GetPlayerShips(UserID);
            if (Importer.Status.ToLower().Equals("ok"))
            {
                List<PlayerShip> PersonalShips = new List<PlayerShip>();
                Dictionary<string, List<PlayerShip>> ImportedShips = Importer.Ships;

                foreach (KeyValuePair<string, List<PlayerShip>> ShipID in ImportedShips)
                {
                    foreach (PlayerShip PShip in ShipID.Value)
                    {
                        PersonalShips.Add(PShip);
                    }
                }

                string FileName = Commons.GetPersonalShipsFileName();
                BinarySerialize.WriteToBinaryFile<List<PlayerShip>>(FileName, PersonalShips);

                this.PersonalShips.Clear();
                foreach (PlayerShip PlayerShipData in PersonalShips)
                {
                    this.PersonalShips.Add(PlayerShipData.ID);
                }
                if (hideMessage == false)
                {
                    MessageBox.Show("Your ships have been imported.", "Load Personal Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Some error occured during gathering of data. Try again later.", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void menuProfile_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (item.Checked)
            {
                return;
            }
            try
            {
                profileHandler.activateItem(item.Text);
                Program.AllShips.Clear();
                PersonalShips.Clear();
                ExcludedShips.Clear();

                LoadAllData();
                Thread.Sleep(500);
                MessageBox.Show("Profile has been loaded.", "Profile loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {
                profileHandler.clearCurrentProfile();
                Settings settings = new Settings();
                settings.Server = item.Text;
                Commons.SaveSettings(settings);
                settings = null;
                Program.AllShips.Clear();

                loadMyShipsToolStripMenuItem.Enabled = false;
                OpenSettingsForceUpdate();
                if ( callUpdateAll )
                {
                    StartLoadingAnimation();
                    callUpdateAll = false;
                    BGUpdater.RunWorkerAsync();
                }
                Settings MySettings = Commons.GetSettings();
                if (MySettings != null)
                {
                    if (!MySettings.Server.Equals("") && !MySettings.Nickname.Equals(""))
                    {
                        loadMyShipsToolStripMenuItem.Enabled = true;
                    }
                }
            }
        }

        private void changeLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLog logform = new ChangeLog();
            logform.LogEntries = this.ChangeLog;
            logform.Text = "Change Log WoWs Randomizer ver. " + RandomizerVersion;
            logform.ShowDialog();
        }

        private void installUpgradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpInstall f = new HelpInstall();
            f.ShowDialog();
        }

        private void randomizerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpRandomizer f = new HelpRandomizer();
            f.ShowDialog();
        }

        private void buildManagerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HelpBuildManager f = new HelpBuildManager();
            f.ShowDialog();
        }

        private void shipCompareToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpCompareTool f = new HelpCompareTool();
            f.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpAbout f = new HelpAbout();
            f.ShowDialog();
        }

        private void upgradesExaminerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShipWiki wiki = new ShipWiki();
            wiki.IsBuilderActive = false;
            wiki.Show();
        }

        private void ShipComparisonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form compareTool = new CompareTool();
            compareTool.Show();
        }

        private void buildManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildManager BManager = new BuildManager();
            BManager.Show();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0017:Simplify object initialization", Justification = "<Pending>")]
        private void ExclusionListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExclusionList ExList = new ExclusionList();
            ExList.PersonalShips = this.PersonalShips;
            if (ExList.ShowDialog(this) == DialogResult.OK) { }
            LoadExcludedShips();
            ExList.Dispose();
            lblExcludedShips.Text = ExcludedShips.Count.ToString() + " excluded from randomization.";
        }

        private void myShipsInPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "txt files (*.txt)|*.txt|csv files (*.csv)|*.csv|All files (*.*)|*.*";
            fileDialog.DefaultExt = "csv";
            fileDialog.FilterIndex = 2;
            fileDialog.CheckFileExists = false;
            fileDialog.CheckPathExists = true;
            fileDialog.SupportMultiDottedExtensions = false;
            fileDialog.Title = "Export list of my ships in port";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                exportMyShips(fileDialog.FileName, fileDialog.FilterIndex);
                MessageBox.Show("File saved: " + fileDialog.FileName, "List exported", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSettingsForceUpdate();
            Settings MySettings = Commons.GetSettings();
            if (MySettings != null)
            {
                if (!MySettings.Server.Equals("") && !MySettings.Nickname.Equals(""))
                {
                    loadMyShipsToolStripMenuItem.Enabled = true;
                }
            }
        }

        private void LoadMyShipsToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            Settings MySettings = Commons.GetSettings();
            if (MySettings == null) { MessageBox.Show("Unable to load ships...Settings not found.", "Load Personal Ships Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if (MySettings.UserID != 0)
            {
                loadUserShipsInPort(MySettings.UserID);
            }
            else
            {
                MessageBox.Show("Unable to load ships; UserID not found - Go to File/Settings... and make sure that You have entered correct Username and Server", "Error loading personal data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.MessageLoop)
            {
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                System.Environment.Exit(1);
            }
        }

        private void FormRandomizer_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.isLoaded = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if ( this.isLoaded )
            {
                this.OnLoadComplete(e);
            }
        }

        protected virtual void OnLoadComplete(EventArgs e)
        {
            if ( callUpdateAll )
            {
                callUpdateAll = false;
                StartLoadingAnimation();
                BGUpdater.RunWorkerAsync();
            }
        }

        private void BGUpdater_DoWork(object sender, DoWorkEventArgs e)
        {
            randomizerUpdater.UpdateAll();
        }

        private void BGUpdater_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FinalizeLoad();

            LoadingImage.Dock = DockStyle.None;
            LoadingImage.Visible = false;
        }

        private void UpgradeFixer_DoWork(object sender, DoWorkEventArgs e)
        {
            //DoUpgradeFix();
        }

        private void UpgradeFixer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadingImage.Dock = DockStyle.None;
            LoadingImage.Visible = false;
        }

        private void StatusLabel_Click(object sender, EventArgs e)
        {
            string HREF = @"https://www.twitch.tv/Axillent/";
            System.Diagnostics.Process.Start(HREF);
        }

        private void StatusLabel_MouseHover(object sender, EventArgs e)
        {
            statusStrip1.Cursor = Cursors.Hand;
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryTool ShowList = new QueryTool();
            ShowList.personalShips = this.PersonalShips;
            ShowList.ExcludedShips = this.ExcludedShips;

            if ( ShowList.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void dataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayerPersonalDataImport Import = WGAPI.GetPlayerPersonalData(531307177);
            if ( Import.Status.Equals("ok"))
            {
                PlayerPersonalData pdata = Import.Data["531307177"];
                Console.WriteLine(pdata.HiddenProfile + " - " + pdata.LastBattle);
                Console.WriteLine(pdata.Statistics.PVPStatistics.MaxPlanesKilled);
            }
        }
    }
}
