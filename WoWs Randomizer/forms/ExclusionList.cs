using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0017:Simplify object initialization", Justification = "<Pending>")]
        private void DrawTable(List<Ship> Result, string SelectedCountry, bool selectAll = false) 
        {
            ResultTable.Visible = false;

            ResultTable.SuspendLayout();
            this.SuspendLayout();

            ResultTable.Controls.Clear();
            ResultTable.RowStyles.Clear();

            ResultTable.ColumnCount = 5;
            ResultTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 225F));
            ResultTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 275F));
            ResultTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            ResultTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            ResultTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            ResultTable.RowCount = 1;
            ResultTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));

            ResultTable.Controls.Add(new Label() { Text = "Name", Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold) }, 0, ResultTable.RowCount - 1);
            ResultTable.Controls.Add(new Label() { Text = "ID", Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold) }, 1, ResultTable.RowCount - 1);
            Label shipclass = new Label();
            shipclass.Text = "Class";
            shipclass.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            shipclass.Click += new EventHandler(LB_Click);
            if ( !SelectedCountry.Equals(""))
            {
                shipclass.Tag = SelectedCountry;
            }
            shipclass.Cursor = Cursors.Hand;
            ResultTable.Controls.Add(shipclass, 2, ResultTable.RowCount - 1);

            Label tier = new Label();
            tier.Text = "Tier";
            tier.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            tier.Click += new EventHandler(LB_Click);
            if ( !SelectedCountry.Equals(""))
            {
                tier.Tag = SelectedCountry;
            }
            tier.Cursor = Cursors.Hand;

            ResultTable.Controls.Add(tier, 3, ResultTable.RowCount - 1);
            ResultTable.Controls.Add(new Label() { Text = "Excluded", Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold) }, 4, ResultTable.RowCount - 1);

            foreach (Ship ship in Result)
            {
                ResultTable.RowCount += 1;
                ResultTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
                ResultTable.Controls.Add(new Label() { Text = ship.Name }, 0, ResultTable.RowCount - 1);
                ResultTable.Controls.Add(new Label() { Text = Convert.ToString(ship.ID) }, 1, ResultTable.RowCount - 1);
                ResultTable.Controls.Add(new Label() { Text = ship.ShipType }, 2, ResultTable.RowCount - 1);
                ResultTable.Controls.Add(new Label() { Text = Convert.ToString(ship.Tier) }, 3, ResultTable.RowCount - 1);
                CheckBox cb = new CheckBox();
                cb.Text = "";
                cb.Tag = ship.ID;
                cb.Click += new EventHandler(MarkDirty);
                if ( ExcludedShips.Contains(ship.ID) || selectAll == true)
                {
                    cb.Checked = true;
                }
                cb.Anchor = AnchorStyles.Top;
                ResultTable.Controls.Add(cb, 4, ResultTable.RowCount - 1);
            }
            ResultTable.ResumeLayout(true);
            ResultTable.Visible = true;
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
            ResultTable.Visible = false;
            TableLayoutControlCollection controls = ResultTable.Controls;
            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i] is CheckBox)
                {
                    using (CheckBox cb = (CheckBox)controls[i])
                    {
                        if (cb.Checked)
                        {
                            ExcludedShips.Add(Convert.ToInt64(cb.Tag));
                        }
                        else
                        {
                            if (ExcludedShips.Contains(Convert.ToInt64(cb.Tag)))
                            {
                                ExcludedShips.Remove(Convert.ToInt64(cb.Tag));
                            }
                        }
                    }
                }
            }
            ResultTable.Visible = true;
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
