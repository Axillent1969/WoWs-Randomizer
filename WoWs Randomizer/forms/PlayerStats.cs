using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WoWs_Randomizer.api;
using WoWs_Randomizer.objects;
using WoWs_Randomizer.objects.clan;
using WoWs_Randomizer.objects.player;
using WoWs_Randomizer.utils;
using WoWs_Randomizer.utils.ship;

namespace WoWs_Randomizer.forms
{
    public partial class PlayerStats : Form
    {
        public PlayerStats()
        {
            InitializeComponent();
        }

        private void PlayerStatistics_Load(object sender, EventArgs e)
        {
            Settings MySettings = Commons.GetSettings();
            long userId = MySettings.UserID;
            string userName = MySettings.Nickname;
            this.Text = "Statistics of " + userName + " (" + userId + ")";
            LoadUserData(userId);
        }

        private void LoadUserData(long userId)
        {
            string cc = Properties.Settings.Default.Locale;
            PlayerClanInfoImport clanImport = WGAPI.GetPlayerClanInfo(userId);
            if (clanImport.Status.Equals("ok"))
            {
                PlayerClanInfoData data = clanImport.Data[userId.ToString()];
                ClanBaseData ClanInfo = data.ClanData;
                string txt = "";
                txt += "[" + ClanInfo.Tag + "] " + ClanInfo.Name + " (" + ClanInfo.Count + " members)\n" + data.Role + "\n(member since: " + Commons.ConvertDateToLocalFormat(Commons.ConvertToDate(data.Joined),cc) + ")";
                lblClanInfo.Text = txt;
                btnGetClanInfo.Tag = data.ClanID;
                btnGetClanInfo.Visible = true;
            } else
            {
                lblClanInfo.Text = "(no clan info availalbe)";
                btnGetClanInfo.Visible = false;
            }
            PlayerPersonalDataImport Import = WGAPI.GetPlayerPersonalData(userId);
            if (Import.Status.Equals("ok"))
            {
                string locale = Properties.Settings.Default.Locale;
                if ( locale.Length == 0 ) { locale = "en-US"; }

                PlayerPersonalData pdata = Import.Data[userId.ToString()];

                lblStatsUpdatedAt.Text = "The statistics was last updated at " + Commons.ConvertDateToLocalFormat(Commons.ConvertToDate(pdata.StatsUpdatedAt),locale);
                lblCreated.Text = "Account created: " + Commons.ConvertDateToLocalFormat(Commons.ConvertToDate(pdata.AccountCreated), locale);
                string txt = "Profile is ";
                if ( pdata.HiddenProfile )
                {
                    txt += "HIDDEN";
                } else
                {
                    txt += "VISIBLE";
                }
                
                lblHidden.Text = txt;

                PlayerStatistics stats = pdata.Statistics;
                PlayerBatteryStatistics mainBattery = stats.PVPStatistics.MainBattery;
                lblHits.Text = mainBattery.Hits.ToString();
                lblFrags.Text = mainBattery.Kills.ToString();
                lblFired.Text = mainBattery.ShotsFired.ToString();
                lblMaxKills.Text = mainBattery.MaxKilled.ToString();

                Ship findShip = Program.AllShips.Find(x => x.ID == mainBattery.MaxKilledShipId);
                lblMaxKillsShip.Text = findShip.Name;

                PlayerBatteryStatistics secBattery = stats.PVPStatistics.SecondBattery;
                lblHits2.Text = secBattery.Hits.ToString();
                lblFrags2.Text = secBattery.Kills.ToString();
                lblFired2.Text = secBattery.ShotsFired.ToString();
                lblMaxKills2.Text = secBattery.MaxKilled.ToString();

                findShip = Program.AllShips.Find(x => x.ID == secBattery.MaxKilledShipId);
                lblMaxKillsShip2.Text = findShip.Name;

                PlayerBatteryStatistics torps = stats.PVPStatistics.Torpedoes;
                lblHits3.Text = torps.Hits.ToString();
                lblFrags3.Text = torps.Kills.ToString();
                lblFired3.Text = torps.ShotsFired.ToString();
                lblMaxKills3.Text = torps.MaxKilled.ToString();

                findShip = Program.AllShips.Find(x => x.ID == torps.MaxKilledShipId);
                lblMaxKillsShip3.Text = findShip.Name;

                lblWin.Text = stats.PVPStatistics.Wins.ToString();
                lblLoss.Text = stats.PVPStatistics.Losses.ToString();
                lblDraw.Text = stats.PVPStatistics.Draws.ToString();
                lblTotalBattles.Text = stats.PVPStatistics.Battles.ToString();
                lblSurvived.Text = stats.PVPStatistics.SurvivedBattles.ToString();
                lblSurvivedWins.Text = stats.PVPStatistics.SurvivedBattlesWin.ToString();

                lblXPTotal.Text = stats.PVPStatistics.Experience.ToString();
                lblXPMax.Text = stats.PVPStatistics.MaxXP.ToString();
                findShip = Program.AllShips.Find(x => x.ID == stats.PVPStatistics.MaxXPShipId);
                lblXPMaxShip.Text = findShip.Name;

                lblDamageTotal.Text = stats.PVPStatistics.DamageDealt.ToString();
                lblDamageMax.Text = stats.PVPStatistics.MaxDamageDealt.ToString();
                findShip = Program.AllShips.Find(x => x.ID == stats.PVPStatistics.MaxDamageDealtShipId);
                lblDamageMaxShip.Text = findShip.Name;

                lblKillsTotal.Text = stats.PVPStatistics.ShipsKilled.ToString();
                lblKillsMax.Text = stats.PVPStatistics.MaxShipsKilled.ToString();
                findShip = Program.AllShips.Find(x => x.ID == stats.PVPStatistics.MaxShipsKilledShipId);
                lblKillsMaxShip.Text = findShip.Name;
                lblPlanesKilledTotal.Text = stats.PVPStatistics.PlanesKilled.ToString();
                lblPlanesKilledMax.Text = stats.PVPStatistics.MaxPlanesKilled.ToString();
                findShip = Program.AllShips.Find(x => x.ID == stats.PVPStatistics.MaxPlanesKilledShipId);
                lblPlanesKilledMaxShip.Text = findShip.Name;

                lblMaxShipsSpotted.Text = stats.PVPStatistics.MaxShipsSpotted.ToString();
                findShip = Program.AllShips.Find(x => x.ID == stats.PVPStatistics.MaxShipsSpottedShipId);
                lblMaxShipsSpottedShipId.Text = findShip.Name;
                lblShipsSpottedTotal.Text = stats.PVPStatistics.ShipsSpotted.ToString();
                lblMaxScouting.Text = stats.PVPStatistics.MaxScoutingDamage.ToString();
                findShip = Program.AllShips.Find(x => x.ID == stats.PVPStatistics.MaxScountingDamageShipId);
                lblMaxScoutingShip.Text = findShip.Name;
                lblScoutingTotal.Text = stats.PVPStatistics.ScoutingDamage.ToString();

                lblCapturePoints.Text = stats.PVPStatistics.CapturePoints.ToString();
                lblControlCapturePoints.Text = stats.PVPStatistics.ControlCapturePoints.ToString();
                lblDroppedCapturePoints.Text = stats.PVPStatistics.DroppedCapturePoints.ToString();

                PlayerAuxilliaryStatistics aux = stats.PVPStatistics.Ramming;
                lblRamming.Text = aux.Kills.ToString();
                aux = stats.PVPStatistics.Aircraft;
                lblAircraft.Text = aux.Kills.ToString();

            }
        }

        private void btnGetClanInfo_Click(object sender, EventArgs e)
        {
            long ClanID = (long)btnGetClanInfo.Tag;
            Clan clanForm = new Clan();
            clanForm.ClanID = ClanID;
            clanForm.Show();
        }
    }
}
