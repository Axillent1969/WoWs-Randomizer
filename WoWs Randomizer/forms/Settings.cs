using System;
using System.Windows.Forms;
using WoWs_Randomizer.api;
using WoWs_Randomizer.objects;
using WoWs_Randomizer.utils;
using WoWs_Randomizer.utils.player;

namespace WoWs_Randomizer.forms
{
    public partial class FormSettings : Form
    {

        public FormSettings()
        {
            InitializeComponent();
            LoadSettings();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0017:Simplify object initialization", Justification = "<Pending>")]
        private void BtnOK_ClickAsync(object sender, EventArgs e)
        {
            if (countryCode.SelectedItem != null)
            {
                string cc = countryCode.SelectedItem.ToString();
                Properties.Settings.Default.Locale = cc;
                Properties.Settings.Default.Save();
            }

            Settings settings = new Settings();
            if ( this.Server.SelectedItem != null )
            {
                settings.Server = this.Server.SelectedItem.ToString();
            } else
            {
                settings.Server = "";
            }
            bool UpdateUserData = false;
            if ( !this.Nickname.Text.Equals(settings.Nickname) || Convert.ToInt64(this.UserID.Text) == 0 ) {
                UpdateUserData = true;
            }

            settings.Nickname = this.Nickname.Text;
            settings.SaveLocation = this.SaveDir.Text;
            settings.UserID = Convert.ToInt64(this.UserID.Text);
            Commons.SaveSettings(settings);
            
            if ( UpdateUserData )
            {
                bool PlayerLookup = UpdateUserPlayerIDAsync(settings);
                if ( PlayerLookup == false )
                {
                    this.DialogResult = DialogResult.Cancel;
                } else
                {
                    this.DialogResult = DialogResult.OK;
                }
            } else
            {
                this.DialogResult = DialogResult.OK;
            }

            if ( this.DialogResult == DialogResult.OK )
            {
                this.Close();
            }
        }

        private bool UpdateUserPlayerIDAsync(Settings MySettings)
        {
            if (MySettings.UserID == 0 && !MySettings.Nickname.Equals("") && !MySettings.Server.Equals(""))
            {
                PlayerSearch PlayerImporter = WGAPI.SearchPlayer(MySettings.Nickname);
                if (PlayerImporter.Status.ToLower() == "ok")
                {
                    MySettings.UserID = PlayerImporter.Player[0].ID;
                    Commons.SaveSettings(MySettings);
                    return true;
                }
                else
                {
                    MessageBox.Show("Unable to find a player with that nickname: " + MySettings.Nickname, "Error on Get User Info");
                    return false;
                }
            } else
            {
                return true;
            }
        }

        private void LoadSettings()
        {
            string cc = Properties.Settings.Default.Locale;
            if ( !cc.Equals(""))
            {
                countryCode.SelectedIndex = countryCode.FindStringExact(cc);
            }

            Settings MySettings = Commons.GetSettings();
            if ( MySettings != null )
            {
                this.SaveDir.Text = MySettings.SaveLocation;
                this.Nickname.Text = MySettings.Nickname;
                this.Server.SelectedItem = MySettings.Server;
                this.UserID.Text = MySettings.UserID.ToString();
                
                if ( MySettings.GameUpdated != null )
                {
                    this.lblUpdatedTime.Text = MySettings.GameUpdated.ToString();
                    //this.lblUpdatedTime.Text = Commons.ConvertDateToLocalFormat(MySettings.GameUpdated,cc);
                    this.lblUpdatedTime.Visible = true;
                } else
                {
                    this.lblUpdatedTime.Text = "?";
                    this.lblUpdatedTime.Visible = false;

                    this.lblGameVersion.Text = "?";
                    this.lblGameVersion.Visible = false;
                }
                if ( MySettings.GameVersion != null )
                {
                    this.lblGameVersion.Text = MySettings.GameVersion;
                    this.lblGameVersion.Visible = true;
                } else
                {
                    this.lblGameVersion.Visible = false;
                }
            }
        }

        private void BtnSelectDir_click(object sender, EventArgs e)
        {
            using (var FolderBrowse = new FolderBrowserDialog())
            {
                DialogResult result = FolderBrowse.ShowDialog();
                if ( result == DialogResult.OK && !string.IsNullOrWhiteSpace(FolderBrowse.SelectedPath))
                {
                    SaveDir.Text = FolderBrowse.SelectedPath;
                }
            }
        }
    }
}
