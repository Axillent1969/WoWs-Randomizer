using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WoWs_Randomizer.api;
using WoWs_Randomizer.forms;
using WoWs_Randomizer.objects;
using WoWs_Randomizer.objects.module;
using WoWs_Randomizer.objects.modules;
using WoWs_Randomizer.objects.player;
using WoWs_Randomizer.objects.ship;
using WoWs_Randomizer.objects.skills;
using WoWs_Randomizer.objects.upgrades;
using WoWs_Randomizer.objects.version;
using WoWs_Randomizer.utils;
using WoWs_Randomizer.utils.specialFlags;

namespace WoWs_Randomizer
{
    public partial class FormRandomizer : Form
    {
        private delegate void SafeCallDelegate(string text);

        private bool ShipLoaded = false;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0044:Add readonly modifier", Justification = "<Pending>")]
        private List<long> PersonalShips = new List<long>();
        private List<long> AlreadyRandomizedShips = new List<long>();
        private HashSet<long> ExcludedShips = new HashSet<long>();
        private Ship RandomizedShip = null;
        private List<string> ChangeLog = new List<string>();
        private string RandomizerVersion = "";
        private ProfileHandler profileHandler = new ProfileHandler();

        private ShipRandomizer Randomizer = null;

        public FormRandomizer()
        {
            InitializeComponent();
            lblQueue.Text = "";
            profileHandler.addMenuitem(menuProfileEU);
            profileHandler.addMenuitem(menuProfileNA);
            profileHandler.addMenuitem(menuProfileRU);
            profileHandler.uncheckAll(); 

            Settings MySettings = Commons.GetSettings();
            if ( MySettings != null )
            {
                if ( MySettings.GameVersion == null )
                {
                    LoadGameVersion();
                } else
                {
                    CheckVersion();
                }
                profileHandler.checkItem(MySettings.Server.ToString());
            } else
            {
                loadMyShipsToolStripMenuItem.Enabled = false;
                LoadGameVersion();
            }
            if ( MySettings != null && MySettings.UserID != 0 )
            {
                LoadAllData();
            }
        }
        private void LoadAllData()
        {
            try { Program.AllModules = BinarySerialize.Read2<Dictionary<string, ModuleData>>(Commons.GetModulesFileName()); } catch (Exception) { }
            if (Program.AllModules == null || Program.AllModules.Count == 0)
            {
                LoadModulesAsync();
            }

            if (Program.AllShips.Count == 0)
            {
                UpdateShips();
            }
            LoadPersonalShips();
            LoadExcludedShips();
            LoadCommanderSkills();
            LoadUpgrades();
            LoadFlags();
            lblShipsInPort.Text = PersonalShips.Count.ToString() + " ships in port.";
            lblExcludedShips.Text = ExcludedShips.Count.ToString() + " excluded from randomization.";
        }

        private async void LoadUpgrades()
        {
            if ( File.Exists(Commons.GetUpgradesFileName() ))
            {
                Program.Upgrades = BinarySerialize.ReadFromBinaryFile<List<Consumable>>(Commons.GetUpgradesFileName());
            }
            if ( Program.Upgrades == null || Program.Upgrades.Count == 0 )
            {
                await UpdateUpgrades();
            }
        }

        private async Task UpdateUpgrades()
        {
            ConsumablesImporter Importer = await WGAPI.GetUpgrades();
            if (Importer.Status.ToLower().Equals("ok"))
            {
                Program.Upgrades = new List<Consumable>();
                foreach (KeyValuePair<string, Consumable> Data in Importer.Data)
                {
                    Program.Upgrades.Add(Data.Value);
                }
                BinarySerialize.WriteToBinaryFile(Commons.GetUpgradesFileName(), Program.Upgrades);
            }
        }

        private async void LoadCommanderSkills()
        {
            if ( File.Exists(Commons.GetCommanderSkillFileName() ))
            {
                Program.CommanderSkills = BinarySerialize.ReadFromBinaryFile<List<Skill>>(Commons.GetCommanderSkillFileName());
            }
            if ( Program.CommanderSkills == null || Program.CommanderSkills.Count == 0)
            {
                await UpdateCommanderSkills();
            }
        }

        private async Task UpdateCommanderSkills()
        {
            SkillImporter Importer = await WGAPI.GetCommanderSkills();
            if (Importer.Status.ToLower().Equals("ok"))
            {
                Program.CommanderSkills = new List<Skill>();
                foreach (KeyValuePair<string, Skill> SkillData in Importer.Data)
                {
                    Program.CommanderSkills.Add(SkillData.Value);
                }
                BinarySerialize.WriteToBinaryFile(Commons.GetCommanderSkillFileName(), Program.CommanderSkills);
            }
        }

        private async void LoadFlags()
        {
            if (File.Exists(Commons.GetFlagsFileName()))
            {
                Program.Flags = BinarySerialize.ReadFromBinaryFile<List<Consumable>>(Commons.GetFlagsFileName());
            }
            if (Program.Flags == null || Program.Flags.Count == 0)
            {
                await UpdateFlags();
            }
        }

        private async Task UpdateFlags()
        {
            ConsumablesImporter Importer = await WGAPI.GetFlags();
            if (Importer.Status.ToLower().Equals("ok"))
            {
                Program.Flags = new List<Consumable>();
                foreach (KeyValuePair<string, Consumable> Flag in Importer.Data)
                {
                    Program.Flags.Add(Flag.Value);
                }
                BinarySerialize.WriteToBinaryFile(Commons.GetFlagsFileName(), Program.Flags);
            }
        }

        private void CheckProgramVersion()
        {
            ProgramVersion versionInfo = WGAPI.GetProgramVersion();
            ChangeLog = versionInfo.ChangeLog;
            RandomizerVersion = versionInfo.Version;

            DateTime updateDate = new DateTime();
            updateDate = DateTime.Parse(versionInfo.Updated);
            if ( !versionInfo.Version.Equals(Application.ProductVersion))
            {
                string msg = "The new version " + RandomizerVersion + " is available as per " + updateDate.ToShortDateString() + "\nDo You want to download it now?";
                var userInput = MessageBox.Show(msg, "New version of the WoWs Randomizer available!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if ( userInput == DialogResult.Yes)
                {
                    string downloadsPath = KnownFolders.GetPath(KnownFolder.Downloads);
                    string fileName = downloadsPath + "\\" + Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location);
                    using (WebClient wc = new WebClient())
                    {
                        wc.DownloadFile(versionInfo.URL, fileName);
                        MessageBox.Show("The new version has been downloaded to Your download folder.\n(" + fileName + ")\nClose this program and replace the EXE-file in this folder with the downloaded one.", "New version downloaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private async void CheckVersion()
        {
            CheckProgramVersion();

            Settings MySettings = Commons.GetSettings();
            if ( MySettings == null )
            {
                MySettings = new Settings();
            }
            DateTime Today = DateTime.Now;
            
            DateTime LastCheck = MySettings.LastChecked;

            if ( LastCheck == null || DateTime.Compare(LastCheck.AddHours(23),Today) <= 0 )
            {
                MySettings.LastChecked = Today;

                if (MySettings == null) { MessageBox.Show("Unable to load ships...Settings not found.", "Load Personal Ships Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                if (MySettings.UserID != 0)
                {
                    await loadUserShipsInPort(MySettings.UserID, true);
                }

                VersionInfoImport Import = await WGAPI.GetVersionInfo();
                if ( Import.Status.Equals("ok"))
                {
                    VersionInfo Info = Import.VersionInfo;
                    if ( MySettings.GameVersion != null && MySettings.GameVersion.Equals(Info.GameVersion))
                    {
                        DateTime GameDate = Commons.ConvertToDate(Info.Updated);
                        if ( DateTime.Compare(MySettings.GameUpdated,GameDate) != 0 )
                        {
                            UpdateShips();
                            LoadModulesAsync();
                            await UpdateCommanderSkills();
                            await UpdateUpgrades();
                            await UpdateFlags();
                            MySettings.GameUpdated = GameDate;
                            MessageBox.Show("Game data has been updated (still same game version): " + GameDate.ToString());
                        }
                    } else
                    {
                        UpdateShips();
                        LoadModulesAsync();
                        await UpdateCommanderSkills();
                        await UpdateUpgrades();
                        await UpdateFlags();
                        MySettings.GameVersion = Info.GameVersion;
                        DateTime GameDate = Commons.ConvertToDate(Info.Updated);
                        MySettings.GameUpdated = GameDate;
                        MessageBox.Show("Game version has changed: New version = " + Info.GameVersion);
                    }
                    Commons.SaveSettings(MySettings);
                }
            } else
            {
                MySettings.LastChecked = Today;
                Commons.SaveSettings(MySettings);
            }
            if ( Program.AllShips == null || Program.AllShips.Count == 0 )
            {
                UpdateShips();
            }
        }

        private async void UpdateShips()
        {
            LoadingImage.Dock = DockStyle.Fill;
            LoadingImage.Visible = true;

            List<Ship> AllShips = await WGAPI.GetAllShipsFromWG();
            if (AllShips != null)
            {
                BinarySerialize.WriteToBinaryFile<List<Ship>>(Commons.GetShipListFileName(), AllShips);
                Program.AllShips = AllShips;
            }

            Thread.Sleep(1500);
            LoadingImage.Dock = DockStyle.None;
            LoadingImage.Visible = false;
        }

        private async void LoadGameVersion()
        {
            VersionInfoImport Import = await WGAPI.GetVersionInfo();
            if ( Import.Status.Equals("ok"))
            {
                VersionInfo Info = Import.VersionInfo;
                long UpdatedAt = Info.Updated;
                string Version = Info.GameVersion;
                DateTime GameDate = Commons.ConvertToDate(UpdatedAt);
                Settings MySettings = Commons.GetSettings();
                if ( MySettings != null )
                {
                    MySettings.GameUpdated = GameDate;
                    MySettings.GameVersion = Version;
                    Commons.SaveSettings(MySettings);
                }
            }
        }

        private void LoadPersonalShips()
        {
            string FileName = Commons.GetPersonalShipsFileName();
            if ( File.Exists(FileName))
            {
                this.PersonalShips.Clear();
                List<PlayerShip> Ships = BinarySerialize.ReadFromBinaryFile<List<PlayerShip>>(FileName);
                foreach (PlayerShip PlayerShipData in Ships)
                {
                    Ship findShip = Program.AllShips.Find(x => x.ID == PlayerShipData.ID);
                    if ( findShip != null )
                    {
                        if ( !findShip.Name.StartsWith("["))
                        {
                            this.PersonalShips.Add(PlayerShipData.ID);
                        }
                    } else
                    {
                        this.PersonalShips.Add(PlayerShipData.ID);
                    }
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

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            RandomizeShip();
            Thread.Sleep(2000);
        }

        private void RandomizeShip()
        {
            Ship ThisShip = GetRandomShip();
            if ( ThisShip != null )
            {
                RandomizedShip = ThisShip;
                LoadFlag(ThisShip.Country);
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

        private void LoadFlag(string Country)
        {
            Dictionary<string, string> Flags = new Dictionary<string, string>
            {
                { "japan", "https://wiki.gcdn.co/images/5/5b/Wows_flag_Japan.png" },
                { "usa", "https://wiki.gcdn.co/images/f/f2/Wows_flag_USA.png" },
                { "ussr", "https://wiki.gcdn.co/images/0/04/Wows_flag_Russian_Empire_and_USSR.png" },
                { "germany", "https://wiki.gcdn.co/images/6/6b/Wows_flag_Germany.png" },
                { "uk", "https://wiki.gcdn.co/images/3/34/Wows_flag_UK.png" },
                { "commonwealth", "https://wiki.gcdn.co/images/9/9a/Wows_flag_Commonwealth.png" },
                { "france", "https://wiki.gcdn.co/images/7/71/Wows_flag_France.png" },
                { "italy", "https://wiki.gcdn.co/images/d/d1/Wows_flag_Italy.png" },
                { "pan_asia", "https://wiki.gcdn.co/images/3/33/Wows_flag_Pan_Asia.png" },
                { "pan_america", "https://wiki.gcdn.co/images/9/9e/Wows_flag_Pan_America.png" },
                { "europe", "https://wiki.gcdn.co/images/5/52/Wows_flag_Europe.png" }
            };

            string url = Flags[Country.ToLower()];
            FlagImage.Load(url);
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
        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ( ShipLoaded )
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
            if ( cbSingleSelect.Checked )
            {
                lblQueue.Text = AlreadyRandomizedShips.Count.ToString() + " of " + (PersonalShips.Count - ExcludedShips.Count).ToString() + " ships used.";
            } else
            {
                lblQueue.Text = "";
            }
        }

        private void RandomizeButton_Click(object sender, EventArgs e)
        {
            shipDescription.Text = "";
            Settings settings = Commons.GetSettings();
            if (settings.SaveLocation.Equals("")) { BtnRecommendedBuild.Enabled = false;  } else { BtnRecommendedBuild.Enabled = true; }

            RandomizedShip = null;
            LoadingImage.Dock = DockStyle.Fill;
            LoadingImage.Visible = true;
            BackgroundWorker.RunWorkerAsync();
        }
        
        private void ShipImage_Click(object sender, EventArgs e)
        {
            string HREF = @"https://wiki.wargaming.net/en/Ship:";
            string SelectedShip = ShipName.Text.ToString();

            if (SelectedShip.Equals("") || SelectedShip.Equals(" "))
            {
                return;
            }
            else
            {
                SelectedShip = SelectedShip.Replace(' ', '_');
                System.Diagnostics.Process.Start(HREF + SelectedShip);
            }
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

        private async void LoadModulesAsync()
        {
            RandomizeButton.Enabled = false;
            string txt = RandomizeButton.Text;
            RandomizeButton.Text = "Loading data...";
            try
            {
                Program.AllModules = await WGAPI.GetAllModules();
                foreach(KeyValuePair<string,ModuleData> Mod in Program.AllModules)
                {
                    ModuleTranslator.Transfer(Mod.Value);
                }
                BinarySerialize.WriteToBinaryFile(Commons.GetModulesFileName(), Program.AllModules);
            }
            catch (Exception) {  }
            RandomizeButton.Text = txt;
            RandomizeButton.Enabled = true;
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

        private void OpenSettingsAndLoadShips()
        {
            FormSettings settingsForm = new FormSettings();
            if (settingsForm.ShowDialog(this) == DialogResult.OK)
            {
                Settings currentSettings = Commons.GetSettings();
                if (currentSettings.UserID != 0)
                {
                    _ = loadUserShipsInPort(currentSettings.UserID);
                }
                LoadAllData();
                Thread.Sleep(2500);
                MessageBox.Show("Game data has been updated.", "Information Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private async Task loadUserShipsInPort(long UserID, bool hideMessage = false)
        {
            PlayerShipImport Importer = await WGAPI.GetPlayerShips(UserID);
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
                OpenSettingsAndLoadShips();

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
            logform.log = this.ChangeLog;
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
            OpenSettingsAndLoadShips();
            Settings MySettings = Commons.GetSettings();
            if (MySettings != null)
            {
                if (!MySettings.Server.Equals("") && !MySettings.Nickname.Equals(""))
                {
                    loadMyShipsToolStripMenuItem.Enabled = true;
                }
            }
        }

        private async void LoadMyShipsToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            Settings MySettings = Commons.GetSettings();
            if (MySettings == null) { MessageBox.Show("Unable to load ships...Settings not found.", "Load Personal Ships Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if (MySettings.UserID != 0)
            {
                await loadUserShipsInPort(MySettings.UserID);
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
    }


}
