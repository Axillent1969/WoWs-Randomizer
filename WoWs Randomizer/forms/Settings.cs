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

                Program.Settings.LanguageCode = cc;
            }

            if ( this.Server.SelectedItem != null )
            {
                Program.Settings.Server = this.Server.SelectedItem.ToString();
            } else
            {
                Program.Settings.Server = "";
            }
            bool UpdateUserData = false;
            if ( !this.Nickname.Text.Equals(Program.Settings.Nickname) || Convert.ToInt64(this.UserID.Text) == 0 ) {
                UpdateUserData = true;
            }

            Program.Settings.Nickname = this.Nickname.Text;
            Program.Settings.SaveLocation = this.SaveDir.Text;
            Program.Settings.UserID = Convert.ToInt64(this.UserID.Text);
            
            if ( UpdateUserData )
            {
                bool PlayerLookup = UpdateUserPlayerIDAsync();
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
                Commons.SaveSettings(Program.Settings);
                this.Close();
            }
        }

        private bool UpdateUserPlayerIDAsync()
        {
            if (Program.Settings.UserID == 0 && !Program.Settings.Nickname.Equals("") && !Program.Settings.Server.Equals(""))
            {
                PlayerSearch PlayerImporter = WGAPI.SearchPlayer(Program.Settings.Nickname);
                if (PlayerImporter.Status.ToLower() == "ok")
                {
                    Program.Settings.UserID = PlayerImporter.Player[0].ID;
                    return true;
                }
                else
                {
                    MessageBox.Show("Unable to find a player with that nickname: " + Program.Settings.Nickname, "Error on Get User Info");
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

            if ( Program.Settings != null )
            {
                this.SaveDir.Text = Program.Settings.SaveLocation;
                this.Nickname.Text = Program.Settings.Nickname;
                this.Server.SelectedItem = Program.Settings.Server;
                this.UserID.Text = Program.Settings.UserID.ToString();
                
                if (Program.Settings.GameUpdated != null )
                {
                    this.lblUpdatedTime.Text = Commons.ConvertDateToLocalFormat(Program.Settings.GameUpdated,cc);
                    this.lblUpdatedTime.Visible = true;
                } else
                {
                    this.lblUpdatedTime.Text = "?";
                    this.lblUpdatedTime.Visible = false;

                    this.lblGameVersion.Text = "?";
                    this.lblGameVersion.Visible = false;
                }
                if (Program.Settings.GameVersion != null )
                {
                    this.lblGameVersion.Text = Program.Settings.GameVersion;
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
