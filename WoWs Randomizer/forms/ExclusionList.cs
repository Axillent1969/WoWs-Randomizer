using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WoWs_Randomizer.utils;
using WoWs_Randomizer.utils.ship;

namespace WoWs_Randomizer.forms
{
    public partial class ExclusionList : Form
    {
        public List<long> PersonalShips = new List<long>();
        public HashSet<long> ExcludedShips = new HashSet<long>();
        private bool isDirty = false;
        private DataTable table = new DataTable();

        public ExclusionList()
        {
            InitializeComponent();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0017:Simplify object initialization", Justification = "<Pending>")]
        private void ExclusionList_Load(object sender, EventArgs e)
        {
            TreeNode RootNode = new TreeNode("All My Ships");
            TreeNode Commonwealth = new TreeNode("Commonwealth");
            Commonwealth.Tag = "commonwealth";
            TreeNode Europe = new TreeNode("Europe");
            Europe.Tag = "europe";
            TreeNode France = new TreeNode("France");
            France.Tag = "france";
            TreeNode Germany = new TreeNode("Germany");
            Germany.Tag = "germany";
            TreeNode Japan = new TreeNode("Japan");
            Japan.Tag = "japan";
            TreeNode Italy = new TreeNode("Italy");
            Italy.Tag = "italy";
            TreeNode PAA = new TreeNode("Pan-Asia");
            PAA.Tag = "pan_asia";
            TreeNode PAN = new TreeNode("Pan-America");
            PAN.Tag = "pan_america";
            TreeNode UK = new TreeNode("UK");
            UK.Tag = "uk";
            TreeNode USA = new TreeNode("USA");
            USA.Tag = "usa";
            TreeNode USSR = new TreeNode("USSR");
            USSR.Tag = "ussr";

            TreeNode[] AllCountries = new TreeNode[] { Commonwealth, Europe, France, Germany, Japan, Italy, PAA, PAN, UK, USA, USSR };

            RootNode.Nodes.AddRange(AllCountries);
            CategoryView.Nodes.Add(RootNode);
            CategoryView.ExpandAll();

            LoadExcludedShips();
        }

        private void MarkDirty(object sender, EventArgs e)
        {
            isDirty = true;
        }

        private void LB_Click(object sender, EventArgs e)
        {
            string country = "";
            string sortorder = "";
            
            Label clicked = (Label)sender;

            if (clicked.Tag.ToString().Contains("/"))
            {
                string[] args = clicked.Tag.ToString().Split('/');
                country = args[0];
                sortorder = args[1];
            } else
            {
                country = clicked.Tag.ToString();
                sortorder = "asc";
            }
            List<Ship> Result = MatchingShips(country);

            if (sortorder.Equals("desc"))
            {
                if (clicked.Text.Equals("Tier")) { 
                    Result.Sort((x, y) => {
                        int result = x.Tier.CompareTo(y.Tier);
                        return result != 0 ? result : x.Name.CompareTo(y.Name);
                    });
                } else
                {
                    Result.Sort((x, y) =>
                    {
                        int result = x.ShipType.CompareTo(y.ShipType);
                        return result != 0 ? result : x.Name.CompareTo(y.Name);
                    });
                }
            } else
            {
                if ( clicked.Text.Equals("Tier"))
                {
                    Result.Sort((x, y) => {
                        int result = y.Tier.CompareTo(x.Tier);
                        return result != 0 ? result : x.Name.CompareTo(y.Name);
                    });
                } else
                {
                    Result.Sort((x, y) =>
                    {
                        int result = y.ShipType.CompareTo(x.ShipType);
                        return result != 0 ? result : x.Name.CompareTo(y.Name);
                    });
                }

            }
            //Next sortorder - Toggle current sortorder;
            if (sortorder.Equals("desc"))
            {
                sortorder = "asc";
            }
            else
            {
                sortorder = "desc";
            }
            DrawTable(Result, country + "/" + sortorder);
        }

        private void CategoryView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if ( e.Action == TreeViewAction.ByMouse)
            {
                cbSelectAll.Checked = false;
                UpdateWithoutSaveExclusionList();
                if (e.Node.Text.Equals("All My Ships")) { return; }
                List<Ship> Result = MatchingShips(e.Node.Tag.ToString());
                Result.Sort((x, y) => {
                    int result = x.Tier.CompareTo(y.Tier);
                    return result != 0 ? result : x.Name.CompareTo(y.Name);
                });
                DrawTable(Result, e.Node.Tag.ToString());
            }
        }
        private void addHeaders()
        {
            List<string> headers = new List<string>()
        {
            "Name",
            "ID",
            "Class",
            "Tier",
            "Excluded"
        };
            table.Columns.Clear();

            foreach (string h in headers)
            {
                if (h.Equals("Name") || h.Equals("Class"))
                {
                    table.Columns.Add(h,typeof(string));
                } else if ( h.Equals("ID") || h.Equals("Tier"))
                {
                    table.Columns.Add(h, typeof(long));
                } else
                {
                    table.Columns.Add(h, typeof(bool));
                }
            }
        }

        private void DrawTable(List<Ship> Result, string SelectedCountry, bool selectAll = false) 
        {
            this.SuspendLayout();
            table = new DataTable();
            resultGrid.DataSource = table;

            addHeaders();
            table.Rows.Clear();

            foreach (Ship ship in Result)
            {
                bool isExcluded = (ExcludedShips.Contains(ship.ID) || selectAll == true) ? true : false;
                table.Rows.Add(ship.Name, ship.ID.ToString(), ship.ShipType, ship.Tier.ToString(), isExcluded);
            }

            resultGrid.Sort(resultGrid.Columns[3], ListSortDirection.Ascending);
            this.ResumeLayout(true);
        }

        private List<Ship> MatchingShips(string tag)
        {
            List<Ship> Result = new List<Ship>();
            foreach (long ID in PersonalShips)
            {
                Ship findShip = Program.AllShips.Find(x => x.ID == ID);
                if (findShip != null)
                {
                    if (findShip.Country.Equals(tag))
                    {
                        Result.Add(findShip);
                    }
                }
            }

            return Result;
        }

        private void ExclusionList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ( e.CloseReason == CloseReason.UserClosing)
            {
                if (isDirty == false || (isDirty == true && MessageBox.Show("You have unsaved data. Are You sure You want to cancel the changes made?", "Unsaved data", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes))
                {
                    e.Cancel = false;
                    isDirty = false;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string country = CategoryView.SelectedNode.Tag.ToString();
            UpdateExclusionList();
            
            List<Ship> Result = MatchingShips(country);
            Result.Sort((x, y) => {
                int result = x.Tier.CompareTo(y.Tier);
                return result != 0 ? result : x.Name.CompareTo(y.Name);
            });
            DrawTable(Result, country);
        }

        private void UpdateWithoutSaveExclusionList()
        {
            foreach(DataRow row in table.Rows)
            {
                if ( (bool)row[4] == true)
                {
                    ExcludedShips.Add((long)row[1]);
                } else
                {
                    if ( ExcludedShips.Contains((long)row[1]))
                    {
                        ExcludedShips.Remove((long)row[1]);
                    }
                }
            }
        }

        private void UpdateExclusionList()
        {
            UpdateWithoutSaveExclusionList();
            SaveExcludedShips();
        }

        private void SaveExcludedShips()
        {
            BinarySerialize.WriteToBinaryFile<HashSet<long>>(Commons.GetExclusionListFileName(), ExcludedShips);
            isDirty = false;
        }

        private void LoadExcludedShips()
        {
            ExcludedShips.Clear();
            if ( File.Exists(Commons.GetExclusionListFileName()))
            {
                ExcludedShips = BinarySerialize.ReadFromBinaryFile<HashSet<long>>(Commons.GetExclusionListFileName());
            }
        }

        private void BtnSaveClose_Click(object sender, EventArgs e)
        {
            UpdateExclusionList();
            SaveExcludedShips();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CategoryView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            UpdateWithoutSaveExclusionList();
        }

        private void cbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            string country = CategoryView.SelectedNode.Tag.ToString();
            List<Ship> Result = MatchingShips(country);
            Result.Sort((x, y) => {
                int result = x.Tier.CompareTo(y.Tier);
                return result != 0 ? result : x.Name.CompareTo(y.Name);
            });
            isDirty = true;
            DrawTable(Result, country, cbSelectAll.Checked);
        }
    }
}
