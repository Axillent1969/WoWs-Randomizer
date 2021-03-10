using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WoWs_Randomizer.utils;
using WoWs_Randomizer.utils.ship;
using WoWs_Randomizer.utils.module;
using WoWs_Randomizer.utils.skills;
using WoWs_Randomizer.objects.consumables;
using WoWs_Randomizer.objects;
using static WoWs_Randomizer.utils.enums.LogLevels;

namespace WoWs_Randomizer
{
    static class Program
    {
        public static List<Ship> AllShips { get; set; }
        public static Dictionary<string, ModuleData> AllModules = null;
        public static Dictionary<string,List<Skill>> CommanderSkills = null;
        public static List<Consumable> Upgrades = null;
        public static List<Consumable> Flags = null;
        public static Settings Settings = null;
        public static LogHandler LOG = new LogHandler("Wows_Randomizer " + Application.ProductVersion);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LOG.SetLogLevel(LogLevel.ALL);
            LOG.DeleteLogFromDisk();
            LOG.Debug("Application start");
            LoadShips();
            try { Settings = Commons.GetSettings(); } catch (Exception) {  }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormRandomizer());
        }

        static void LoadShips()
        {
            string ShipFile = Commons.GetShipListFileName();
            if ( File.Exists(ShipFile))
            {
                LOG.Debug("Shipfile exists: " + ShipFile);
                try
                {
                    AllShips = BinarySerialize.ReadFromBinaryFile<List<Ship>>(ShipFile);
                } catch(Exception e) { AllShips = new List<Ship>(); LOG.Error("Exception during load", e); }

            } else
            {
                LOG.Debug("No shipfile exists");
                AllShips = new List<Ship>();
            }
        }
    }
}
