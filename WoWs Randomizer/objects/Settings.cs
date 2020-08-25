using System;

namespace WoWs_Randomizer.objects
{
    [Serializable]
    class Settings
    {
        public string Server { get; set; }
        public string Nickname { get; set; }
        public string SaveLocation { get; set; }
        public long UserID { get; set; }
        public string GameVersion { get; set; }
        public DateTime GameUpdated { get; set; }
        public DateTime LastChecked { get; set; }

    }
}
