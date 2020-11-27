using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;
using WoWs_Randomizer.api;
using WoWs_Randomizer.objects;
using WoWs_Randomizer.utils;
using WoWs_Randomizer.utils.version;

namespace WoWs_Randomizer.forms
{
    public partial class HelpAbout : Form
    {
        public HelpAbout()
        {
            InitializeComponent();
        }

        private void HelpAbout_Load(object sender, EventArgs e)
        {
            String jsonFile = Commons.GetCurrentDirectory() + "/randomizer.json";
            ProgramVersion versionInfo;
            if ( File.Exists(jsonFile))
            {
                string jsonText = File.ReadAllText(jsonFile);
                versionInfo = JsonConvert.DeserializeObject<ProgramVersion>(jsonText);
            } else
            {
                versionInfo = WGAPI.GetProgramVersion();
            }

            programVersion.Text = versionInfo.Version;
            updateTime.Text = versionInfo.Updated;

            Settings settings = Commons.GetSettings();
            gameVersion.Text = settings.GameVersion;
            gameDate.Text = settings.GameUpdated.ToString();
            string cinfo = (settings.ConsumablesInfoVersion == null || settings.ConsumablesInfoVersion.Equals("")) ? "": settings.ConsumablesInfoVersion;
            lblConsumablesInfoVer.Text = cinfo;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            string HREF = @"https://www.twitch.tv/Axillent/";
            System.Diagnostics.Process.Start(HREF);
        }

        private void label11_Click(object sender, EventArgs e)
        {
            string HREF = @"https://www.streamlabs.com/Axillent/tip";
            System.Diagnostics.Process.Start(HREF);
        }

        private void label12_Click(object sender, EventArgs e)
        {
            string HREF = @"https://www.paypal.me/axillent";
            System.Diagnostics.Process.Start(HREF);
        }
    }
}
