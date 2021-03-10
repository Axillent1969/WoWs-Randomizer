using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using WoWs_Randomizer.api;
using WoWs_Randomizer.objects;
using WoWs_Randomizer.objects.consumables;
using WoWs_Randomizer.objects.version;
using WoWs_Randomizer.utils.module;
using WoWs_Randomizer.utils.modules;
using WoWs_Randomizer.utils.player;
using WoWs_Randomizer.utils.ship;
using WoWs_Randomizer.utils.skills;
using WoWs_Randomizer.utils.version;
using static WoWs_Randomizer.utils.ConsumableTypes;

namespace WoWs_Randomizer.utils
{
    class Updater
    {
        private List<ProgramVersionLog> ChangeLog = new List<ProgramVersionLog>();
        private string RandomizerVersion = "";
        private string GameVersion = "";
        private DateTime GameDate = new DateTime();
        private bool UpdateNeeded = false;
        private LogHandler LOG = Program.LOG;

        public Updater()
        {
            LOG.Debug("Updater started");
            CheckProgramVersion();
            VersionChecker();
        }

        public List<ProgramVersionLog> GetChangeLog() { return ChangeLog; }
        public string GetRandomizerVersion() { return RandomizerVersion; }
        public string GetGameVersion() { return GameVersion; }
        public DateTime GetGameDate() { return GameDate; }

        public bool IsUpdateRequired() { return UpdateNeeded; }

        private void VersionChecker()
        {
            LOG.Debug("VersionChecker()");
            if (Program.Settings == null) { return; }
            if (Program.Settings.GameVersion == null )
            {
                LOG.Debug("No version stored. Getting new version.");
                LoadGameVersionAsync();
            }
            if (Program.Settings.Server == null || Program.Settings.Server.Equals(""))
            {
                return;
            }

            DateTime Today = DateTime.Now;
            DateTime LastCheck = Program.Settings.LastChecked;

            if (LastCheck == null || DateTime.Compare(LastCheck.AddHours(23), Today) <= 0)
            {
                LOG.Debug("Last check not performed or more than 23 hours ago. Perform new check!");
                Program.Settings.LastChecked = Today;
                if (Program.Settings.UserID != 0)
                {
                    LOG.Debug("Loading users ships");
                    loadUserShipsInPort(Program.Settings.UserID, true);
                }

                VersionInfoImport Import = WGAPI.GetVersionInfo();
                if (Import.Status.Equals("ok"))
                {
                    VersionInfo Info = Import.VersionInfo;
                    GameVersion = Info.GameVersion;
                    GameDate = Commons.ConvertToDate(Info.Updated);
                    LOG.Info("Gameversion: " + Info.GameVersion);
                    if (Program.Settings.GameVersion != null && Program.Settings.GameVersion.Equals(Info.GameVersion))
                    {
                        if (DateTime.Compare(Program.Settings.GameUpdated, GameDate) != 0)
                        {
                            LOG.Info("Game data needs to be updated. Not same game date.");
                            UpdateNeeded = true;
                        }
                    }
                    else
                    {
                        LOG.Info("Game data needs to be updated. Not same game version");
                        UpdateNeeded = true;
                    }
                    //Commons.SaveSettings(MySettings);
                }
            }
            else
            {
                Program.Settings.LastChecked = Today;
                //Commons.SaveSettings(MySettings);
            }
        }

        private void LoadGameVersionAsync()
        {
            //Settings MySettings = null;
/*            bool noSave = false;
            if (Program.Settings == null )
            {
                //MySettings = Commons.GetSettings();
            } else
            {
               
                noSave = true;
            }*/
            VersionInfoImport Import = WGAPI.GetVersionInfo();
            if (Import.Status.Equals("ok"))
            {
                VersionInfo Info = Import.VersionInfo;
                long UpdatedAt = Info.Updated;
                string Version = Info.GameVersion;
                this.GameDate = Commons.ConvertToDate(UpdatedAt);
                this.GameVersion = Version;
                if (Program.Settings != null)
                {
                    Program.Settings.GameUpdated = GameDate;
                    Program.Settings.GameVersion = Version;
/*                    if ( noSave == false) { 
                        Commons.SaveSettings(MySettings);
                    }*/
                }
            }
        }

        private void CheckProgramVersion()
        {
            LOG.Debug("CheckProgramVersion()-RandomizerVersion: " + Application.ProductVersion);
            ProgramVersion versionInfo = WGAPI.GetProgramVersion();
            ChangeLog = versionInfo.ChangeLog;
            RandomizerVersion = versionInfo.Version;

            DateTime updateDate = new DateTime();
            updateDate = DateTime.Parse(versionInfo.Updated);
            if (!versionInfo.Version.Equals(Application.ProductVersion))
            {
                LOG.Debug("New version available.");
                string cc = Properties.Settings.Default.Locale;
                string msg = "The new version " + RandomizerVersion + " is available as per " + Commons.ConvertDateToLocalFormat(updateDate,cc) + "\nDo You want to download it now?";
                var userInput = MessageBox.Show(msg, "New version of the WoWs Randomizer available!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (userInput == DialogResult.Yes)
                {
                    LOG.Debug("User requested download of new Randomizer version");
                    string downloadsPath = KnownFolders.GetPath(KnownFolder.Downloads);
                    string fileName = downloadsPath + "\\" + Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location);
                    using (WebClient wc = new WebClient())
                    {
                        wc.DownloadFile(versionInfo.URL, fileName);
                        MessageBox.Show("The new version has been downloaded to Your download folder.\n(" + fileName + ")\nClose this program and replace the EXE-file in this folder with the downloaded one.", "New version downloaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LOG.Debug("Download complete.");
                    }
                }
            }
        }

        public void loadUserShipsInPort(long UserID, bool hideMessage = false)
        {
            LOG.Debug("loadUserShipsInPort()");
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

                if (hideMessage == false)
                {
                    MessageBox.Show("Your ships have been imported.", "Load Personal Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LOG.Debug("User ships downloaded ok");
            }
            else
            {
                LOG.Warning("Download of users ships failed!");
                MessageBox.Show("Some error occured during gathering of data. Try again later.", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void UpdateModules()
        {
            LOG.Debug("UpdateModules()");
            try
            {
                Program.AllModules = WGAPI.GetAllModules();
                foreach (KeyValuePair<string, ModuleData> Mod in Program.AllModules)
                {
                    ModuleTranslator.Transfer(Mod.Value);
                }
                BinarySerialize.WriteToBinaryFile(Commons.GetModulesFileName(), Program.AllModules);
            }
            catch (Exception) { }
        }

        private void UpdateShips()
        {
            LOG.Debug("UpdateShips()");
            List<Ship> AllShips = WGAPI.GetAllShipsFromWG();
            if (AllShips != null)
            {
                Program.AllShips = AllShips;
            }
        }

        public static void UpdateUpgradesInfo()
        {
            foreach (Ship ship in Program.AllShips)
            {
                ship.ApplyUpgradeCorrections();
            }
            //Properties.Settings.Default.UpgradeFix = true;
            //Properties.Settings.Default.Save();
        }

        private void UpdateUpgrades()
        {
            LOG.Debug("UpdateUpgrades()");
            ConsumablesImporter Importer = WGAPI.GetUpgrades();
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

        private void UpdateCommanderSkills()
        {
            LOG.Debug("UpdateCommanderSkills()");
            SkillImporter Importer = WGAPI.GetCommanderSkills();
            if ( Importer.Status.ToLower().Equals("ok"))
            {
                Program.CommanderSkills = new Dictionary<string, List<Skill>>();
                Program.CommanderSkills = Importer.Data;
                BinarySerialize.WriteToBinaryFile(Commons.GetCommanderSkillFileName(), Program.CommanderSkills);
                Thread.Sleep(250);
            }

/*            SkillImporter Importer = WGAPI.GetCommanderSkills();
            if (Importer.Status.ToLower().Equals("ok"))
            {
                Program.CommanderSkills = new List<Skill>();
                foreach (KeyValuePair<string, Skill> SkillData in Importer.Data)
                {
                    Program.CommanderSkills.Add(SkillData.Value);
                }
                BinarySerialize.WriteToBinaryFile(Commons.GetCommanderSkillFileName(), Program.CommanderSkills);
            }*/
        }

        private void UpdateFlags()
        {
            LOG.Debug("UpdateFlags()");
            ConsumablesImporter Importer = WGAPI.GetFlags();
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

        public static void AddConsumablesInfo(bool ForceUpdate = false)
        {
            if (Program.Settings == null ) { return; }
            ConsumablesInfoImporter import = WGAPI.GetConsumablesInfo();
            if ( !import.Status.Equals("ok")) { return; }
            
            if ( ForceUpdate || (Program.Settings.ConsumablesInfoVersion != null && !Program.Settings.ConsumablesInfoVersion.Equals(import.Version)))
            {
                foreach(Ship ship in Program.AllShips)
                {
                    ship.Consumables = new List<ConsumableInfo>();
                }
                Program.Settings.ConsumablesInfoVersion = import.Version;

                foreach (KeyValuePair<string, List<ConsumablesInfoTypeImporter>> list in import.Consumables)
                {
                    Enum.TryParse(list.Key, out ConsumableType CType);

                    foreach (ConsumablesInfoTypeImporter con in list.Value)
                    {
                        List<Ship> ShipList = new List<Ship>();

                        if ( con.GroupSelection != null && !con.GroupSelection.Equals(""))
                        {
                            ShipList = ShipFinder.FindShips(con.ID, con.GroupSelection, con.Exceptions);
                        } else
                        {
                            ShipList = ShipFinder.FindShips(con.ID, con.Group, con.Exceptions);
                        }
                        foreach (Ship ship in ShipList)
                        {
                            ship.Consumables.Add(new ConsumableInfo() { Duration = con.Duration, Range = con.Range, Type = CType, Cooldown = con.Cooldown, Charges = con.Charges, ExtraInfo = con.ExtraInfo });
                        }
                    }
                }
                UpdateUpgradesInfo();
                BinarySerialize.WriteToBinaryFile<List<Ship>>(Commons.GetShipListFileName(), Program.AllShips);
            }
        }

        public void UpdateAll()
        {
            //Settings MySettings = Commons.GetSettings();
            LOG.Debug("UpdateAll()");
            this.LoadGameVersionAsync();
            this.UpdateModules();
            this.UpdateShips();
            Updater.AddConsumablesInfo(true);
            this.UpdateUpgrades();
            this.UpdateCommanderSkills();
            this.UpdateFlags();

            this.loadUserShipsInPort(Program.Settings.UserID, true);

            if (Program.Settings.GameVersion != null && Program.Settings.GameVersion.Equals(this.GetGameVersion()))
            {
                Program.Settings.GameUpdated = this.GetGameDate();
                string cc = Properties.Settings.Default.Locale;
                MessageBox.Show("Game data has been updated (still same game version): " + Commons.ConvertDateToLocalFormat(this.GetGameDate(),cc),"Game Data Updated",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                Program.Settings.GameUpdated = this.GetGameDate();
                Program.Settings.GameVersion = this.GetGameVersion();
                MessageBox.Show("Game version has changed: New version = " + this.GetGameVersion(), "Game Data Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Commons.SaveSettings(MySettings);
        }
    }
}
