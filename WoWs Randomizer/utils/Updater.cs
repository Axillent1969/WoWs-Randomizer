using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
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

        public Updater()
        {
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
            Settings MySettings = Commons.GetSettings();
            if (MySettings == null) { return; }
            if ( MySettings.GameVersion == null )
            {
                LoadGameVersionAsync();
            }
            if ( MySettings.Server == null || MySettings.Server.Equals(""))
            {
                return;
            }

            DateTime Today = DateTime.Now;
            DateTime LastCheck = MySettings.LastChecked;

            if (LastCheck == null || DateTime.Compare(LastCheck.AddHours(23), Today) <= 0)
            {
                MySettings.LastChecked = Today;
                if (MySettings.UserID != 0)
                {
                    loadUserShipsInPort(MySettings.UserID, true);
                }

                VersionInfoImport Import = WGAPI.GetVersionInfo();
                if (Import.Status.Equals("ok"))
                {
                    VersionInfo Info = Import.VersionInfo;
                    GameVersion = Info.GameVersion;
                    GameDate = Commons.ConvertToDate(Info.Updated);
                    if (MySettings.GameVersion != null && MySettings.GameVersion.Equals(Info.GameVersion))
                    {
                        if (DateTime.Compare(MySettings.GameUpdated, GameDate) != 0)
                        {
                            UpdateNeeded = true;
                        }
                    }
                    else
                    {
                        UpdateNeeded = true;
                    }
                    Commons.SaveSettings(MySettings);
                }
            }
            else
            {
                MySettings.LastChecked = Today;
                Commons.SaveSettings(MySettings);
            }
        }

        private void LoadGameVersionAsync(Settings settings = null)
        {
            Settings MySettings = null;
            bool noSave = false;
            if ( settings == null )
            {
                MySettings = Commons.GetSettings();
            } else
            {
                MySettings = settings;
                noSave = true;
            }
            VersionInfoImport Import = WGAPI.GetVersionInfo();
            if (Import.Status.Equals("ok"))
            {
                VersionInfo Info = Import.VersionInfo;
                long UpdatedAt = Info.Updated;
                string Version = Info.GameVersion;
                this.GameDate = Commons.ConvertToDate(UpdatedAt);
                this.GameVersion = Version;
                if (MySettings != null)
                {
                    MySettings.GameUpdated = GameDate;
                    MySettings.GameVersion = Version;
                    if ( noSave == false) { 
                        Commons.SaveSettings(MySettings);
                    }
                }
            }
        }

        private void CheckProgramVersion()
        {
            ProgramVersion versionInfo = WGAPI.GetProgramVersion();
            ChangeLog = versionInfo.ChangeLog;
            RandomizerVersion = versionInfo.Version;

            DateTime updateDate = new DateTime();
            updateDate = DateTime.Parse(versionInfo.Updated);
            if (!versionInfo.Version.Equals(Application.ProductVersion))
            {
                string msg = "The new version " + RandomizerVersion + " is available as per " + updateDate.ToShortDateString() + "\nDo You want to download it now?";
                var userInput = MessageBox.Show(msg, "New version of the WoWs Randomizer available!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (userInput == DialogResult.Yes)
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

        public void loadUserShipsInPort(long UserID, bool hideMessage = false)
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

        private void UpdateModules()
        {
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

        public static void AddConsumablesInfo(Settings mySettings, bool ForceUpdate = false)
        {
            if ( mySettings == null ) { return; }
            ConsumablesInfoImporter import = WGAPI.GetConsumablesInfo();
            if ( !import.Status.Equals("ok")) { return; }
            
            if ( ForceUpdate || !mySettings.ConsumablesInfoVersion.Equals(import.Version))
            {
                foreach(Ship ship in Program.AllShips)
                {
                    ship.Consumables = new List<ConsumableInfo>();
                }
                mySettings.ConsumablesInfoVersion = import.Version;

                foreach (KeyValuePair<string, List<ConsumablesInfoTypeImporter>> list in import.Consumables)
                {
                    ConsumableType CType;
                    Enum.TryParse(list.Key, out CType);

                    foreach (ConsumablesInfoTypeImporter con in list.Value)
                    {
                        List<Ship> ShipList = ShipFinder.FindShips(con.ID, con.Group, con.Exceptions);
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
            Settings MySettings = Commons.GetSettings();

            this.LoadGameVersionAsync(MySettings);
            this.UpdateModules();
            this.UpdateShips();
            Updater.AddConsumablesInfo(MySettings, true);
            this.UpdateUpgrades();
            this.UpdateCommanderSkills();
            this.UpdateFlags();

            this.loadUserShipsInPort(MySettings.UserID, true);

            if (MySettings.GameVersion != null && MySettings.GameVersion.Equals(this.GetGameVersion()))
            {
                MySettings.GameUpdated = this.GetGameDate();
                MessageBox.Show("Game data has been updated (still same game version): " + this.GetGameDate().ToString(),"Game Data Updated",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MySettings.GameUpdated = this.GetGameDate();
                MySettings.GameVersion = this.GetGameVersion();
                MessageBox.Show("Game version has changed: New version = " + this.GetGameVersion(), "Game Data Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Commons.SaveSettings(MySettings);
        }
    }
}
