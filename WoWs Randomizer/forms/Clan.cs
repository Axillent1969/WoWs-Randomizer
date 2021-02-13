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
using WoWs_Randomizer.utils;

namespace WoWs_Randomizer.forms
{
    public partial class Clan : Form
    {
        public long ClanID = 0;
        private DataTable table = new DataTable();

        public Clan()
        {
            InitializeComponent();
            members.DataSource = table;
        }

        private void Clan_Load(object sender, EventArgs e)
        {
            string cc = Properties.Settings.Default.Locale;
            this.Text = ClanID + ": ";
            ClanImport Import = WGAPI.GetClanInfo(ClanID);
            if (Import.Status.Equals("ok"))
            {
                ClanData Claninfo = Import.Data[ClanID.ToString()];
                this.Text = ClanID + ": [" + Claninfo.Tag + "] - " + Claninfo.Name;

                lblCreated.Text = Commons.ConvertDateToLocalFormat(Commons.ConvertToDate(Claninfo.Created),cc);
                lblCreatedBy.Text = Claninfo.CreatedBy;
                lblLeader.Text = Claninfo.Leader;
                lblMemberCount.Text = Claninfo.Count + " members";
                rtDescription.Text = Claninfo.Description;

                AddHeaders();
                AddRows(Claninfo.Members);
            }
        }

        private void AddHeaders()
        {
            table.Columns.Clear();

            table.Columns.Add("Name");
            table.Columns.Add("Role");
            table.Columns.Add("Joined");
        }

        private void AddRows(Dictionary<string,ClanMember> Members)
        {
            table.Rows.Clear();
            foreach (KeyValuePair<string, ClanMember> mem in Members)
            {
                ClanMember member = mem.Value;
                DataRow row = table.NewRow();
                row[0] = member.Name;
                row[1] = member.Role;
                row[2] = Commons.ConvertDateToLocalFormat(Commons.ConvertToDate(member.MemberSince),Properties.Settings.Default.Locale);
                table.Rows.Add(row);
            }

            members.Sort(members.Columns[0], ListSortDirection.Ascending);
        }
    }
}
