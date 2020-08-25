using System.IO;
using WoWs_Randomizer.objects;

namespace WoWs_Randomizer.utils
{
    static class Commons
    {
        public static string GetCurrentDirectory()
        {
            string AssemblyLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
            return System.IO.Path.GetDirectoryName(AssemblyLocation);
        }

        public static string GetFlagsFileName()
        {
            string CurrentDirectory = GetCurrentDirectory();
            string FileName = CurrentDirectory + @"\flags.obj";
            return FileName;
        }

        public static string GetUpgradesFileName()
        {
            string CurrentDirectory = GetCurrentDirectory();
            string FileName = CurrentDirectory + @"\upgrades.obj";
            return FileName;
        }

        public static string GetCommanderSkillFileName()
        {
            string CurrentDirectory = GetCurrentDirectory();
            string FileName = CurrentDirectory + @"\skills.obj";
            return FileName;
        }

        public static string GetSettingsFileName()
        {
            string CurrentDirectory = GetCurrentDirectory();
            string FileName = CurrentDirectory + @"\settings.cfg";
            return FileName;
        }

        public static string GetExclusionListFileName()
        {
            string CurrentDirectory = GetCurrentDirectory();
            string FileName = CurrentDirectory + @"\exclusionlist.obj";
            return FileName;
        }

        public static string GetModulesFileName()
        {
            string CurrentDirectory = GetCurrentDirectory();
            return CurrentDirectory + @"\modules.obj";
        }

        public static string GetShipListFileName()
        {
            string CurrentDirectory = GetCurrentDirectory();
            return CurrentDirectory + @"\shiplist.obj";
        }

        public static string GetPersonalShipsFileName()
        {
            string CurrentDirectory = GetCurrentDirectory();
            return CurrentDirectory + @"\myships.obj";
        }

        public static Settings GetSettings()
        {
            string FileName = Commons.GetSettingsFileName();

            if (File.Exists(FileName))
            {
                Settings settings = BinarySerialize.ReadFromBinaryFile<Settings>(FileName);
                return settings;
            }
            return null;
        }

        public static void SaveSettings(Settings MySettings)
        {
            string FileName = Commons.GetSettingsFileName();
            BinarySerialize.WriteToBinaryFile<Settings>(FileName, MySettings);
        }

        public static bool IsNumeric(string test)
        {
            return int.TryParse(test, out _);
        }
    }
}
