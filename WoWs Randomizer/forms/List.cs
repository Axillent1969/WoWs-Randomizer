using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WoWs_Randomizer.utils;
using WoWs_Randomizer.utils.ship;

namespace WoWs_Randomizer.forms
{
    public partial class List : Form
    {
        private DataTable table = new DataTable();
        List<string> exposedFields = new List<string>();
        private Dictionary<string, Option> mapping = new Dictionary<string, Option>();
        public List<long> personalShips = new List<long>();
        public HashSet<long> ExcludedShips = new HashSet<long>();

        public List()
        {
            InitializeComponent();
            resultGrid.DataSource = table;
            GatherExposedFieldNames();
        }

        private void GatherExposedFieldNames()
        {
            Type myType = typeof(ShipMetrics);
            FieldInfo[] fields = myType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            for (int i = 0; i < fields.Length; i++)
            {
                string n = fields[i].Name;
                string disp = n.Replace("k__BackingField", "").Replace("<", "").Replace(">", "");

                var ex = myType.GetProperty(disp);
                bool isDefined = false;

                if (ex != null)
                {
                    isDefined = Attribute.IsDefined(ex, typeof(Exposed));
                }

                if (isDefined)
                {
                    Option opt = new Option(disp, n,"metrics");
                    this.mapping.Add(disp, opt);
                    exposedFields.Add(disp);
                }
            }

            Type myType2 = typeof(Ship);
            FieldInfo[] fields2 = myType2.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            for (int i = 0; i < fields2.Length; i++)
            {
                string n = fields2[i].Name;
                string disp = n.Replace("k__BackingField", "").Replace("<", "").Replace(">", "");

                var ex = myType2.GetProperty(disp);
                bool isDefined = false;

                if (ex != null)
                {
                    isDefined = Attribute.IsDefined(ex, typeof(Exposed));
                }

                if (isDefined)
                {
                    Option opt = new Option(disp, n,"ship");
                    this.mapping.Add(disp, opt);
                    exposedFields.Add(disp);
                }
            }
            exposedFields.Sort();
            fillSelector();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (userSelectedFields.Items.Count == 0)
            {
                MessageBox.Show("No items selected...");
                return;
            }
            table = new DataTable();
            resultGrid.DataSource = table;
            addHeaders();
            addRows();
        }

        private void fillSelector()
        {
            allFieldNames.Items.Clear();
            foreach (string itm in exposedFields)
            {
                allFieldNames.Items.Add(itm);
            }
        }

        private List<Ship> AssembleShipList()
        {
            List<Ship> ships = new List<Ship>();

            foreach(long shipId in this.personalShips)
            {
                if ( cbExclusionList.Checked == false || (cbExclusionList.Checked == true && !this.ExcludedShips.Contains(shipId)))
                {
                    Ship findShip = Program.AllShips.Find(x => x.ID == shipId);
                    if (findShip != null)
                    {
                        ships.Add(findShip);
                    }
                }
            }

            return ships;
        }

        private void addHeaders()
        {
            table.Columns.Clear();

            foreach (var obj in userSelectedFields.Items)
            {
                string itm = (string)obj;
                table.Columns.Add(itm);
            }
        }

        private void addRows()
        {
            table.Rows.Clear();
            List<Ship> ShipQuery = new List<Ship>();
            if ( cbAllShips.Checked )
            {
                ShipQuery = new List<Ship>(Program.AllShips);
            } else
            {
                ShipQuery = new List<Ship>(AssembleShipList());
            }

            List<string> conditions = new List<string>();
            if ( cbBB.Checked || cbCA.Checked || cbCA.Checked || cbDD.Checked || cbCV.Checked || cbSub.Checked )
            {
                if ( cbBB.Checked ) { conditions.Add(cbBB.AccessibleName); }
                if ( cbCA.Checked ) { conditions.Add(cbCA.AccessibleName); }
                if ( cbDD.Checked ) { conditions.Add(cbDD.AccessibleName); }
                if ( cbCV.Checked ) { conditions.Add(cbCV.AccessibleName); }
                if ( cbSub.Checked ) { conditions.Add(cbSub.AccessibleName); }
            }
            else
            {
                conditions.Add("AllShipType");
            }

            if ( CBTier1.Checked || CBTier2.Checked || CBTier3.Checked || CBTier4.Checked || CBTier5.Checked || CBTier6.Checked || CBTier7.Checked || CBTier8.Checked || CBTier9.Checked || CBTier10.Checked)
            {
                if (CBTier1.Checked) { conditions.Add(CBTier1.Tag.ToString()); }
                if (CBTier2.Checked) { conditions.Add(CBTier2.Tag.ToString()); }
                if (CBTier3.Checked) { conditions.Add(CBTier3.Tag.ToString()); }
                if (CBTier4.Checked) { conditions.Add(CBTier4.Tag.ToString()); }
                if (CBTier5.Checked) { conditions.Add(CBTier5.Tag.ToString()); }
                if (CBTier6.Checked) { conditions.Add(CBTier6.Tag.ToString()); }
                if (CBTier7.Checked) { conditions.Add(CBTier7.Tag.ToString()); }
                if (CBTier8.Checked) { conditions.Add(CBTier8.Tag.ToString()); }
                if (CBTier9.Checked) { conditions.Add(CBTier9.Tag.ToString()); }
                if (CBTier10.Checked) { conditions.Add(CBTier10.Tag.ToString()); }
            } else
            {
                conditions.Add("AllTiers");
            }

            if ( cbTechTree.Checked || cbPremium.Checked )
            {
                if ( cbTechTree.Checked ) { conditions.Add("PS:" + cbTechTree.Tag.ToString()); }
                if ( cbPremium.Checked ) { conditions.Add("PS:" + cbPremium.Tag.ToString()); }
            } else
            {
                conditions.Add("PS:" + cbTechTree.Tag.ToString());
                conditions.Add("PS:" + cbPremium.Tag.ToString());
            }

            List<Ship> shipsToRemove = new List<Ship>();
            foreach (Ship ship in ShipQuery)
            {
                bool isRemoved = false;
                if (!(conditions.Contains("AllShipType") || conditions.Contains(ship.ShipType.ToString())))
                {
                    {
                        shipsToRemove.Add(ship);
                        isRemoved = true;
                    }
                }
                if (isRemoved == false && !(conditions.Contains("AllTiers") || conditions.Contains(ship.Tier.ToString())))
                {
                    shipsToRemove.Add(ship);
                    isRemoved = true;
                }
                if ( isRemoved == false && !(conditions.Contains("PS:" + ship.Premium.ToString().ToLower())))
                {
                    shipsToRemove.Add(ship);
                    isRemoved = true;
                }

            }
            if ( shipsToRemove.Count > 0 )
            {
                foreach(Ship ship in shipsToRemove)
                {
                    ShipQuery.Remove(ship);
                }
            }

            foreach (Ship ship in ShipQuery) {

                try
                {
                    MetricsExctractor Extractor = new MetricsExctractor(ship);
                    ShipMetrics metrics = Extractor.GetMetrics();

                    DataRow row = table.NewRow();

                    int rowIdx = 0;
                    foreach (var obj in userSelectedFields.Items)
                    {
                        string itm = (string)obj;
                        FieldInfo fld = null;

                        Option opt = this.mapping[itm];
                        if ( opt != null )
                        {
                            if ( opt.ClassName.Equals("ship"))
                            {
                                fld = typeof(Ship).GetField(opt.Value, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                                row[rowIdx] = fld.GetValue(ship);
                            } else if ( opt.ClassName.Equals("metrics"))
                            {
                                fld = typeof(ShipMetrics).GetField(opt.Value, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                                row[rowIdx] = fld.GetValue(metrics);
                            }
                        }
                        rowIdx++;
                    }
                    table.Rows.Add(row);
                } catch (Exception ex) {
                    Console.WriteLine(ex);
                    Console.WriteLine(table);
                    Console.WriteLine(table.Columns.Count);
                    Console.WriteLine(table.Rows.Count);
                }
            }

            resultGrid.Sort(resultGrid.Columns[0], ListSortDirection.Ascending);
        }

        private void userSelectedFields_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.userSelectedFields.SelectedItem == null) { return; }
            this.userSelectedFields.DoDragDrop(this.userSelectedFields.SelectedItem, DragDropEffects.Move);
        }

        private void userSelectedFields_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void userSelectedFields_DragDrop(object sender, DragEventArgs e)
        {
            Point point = userSelectedFields.PointToClient(new Point(e.X, e.Y));
            int index = this.userSelectedFields.IndexFromPoint(point);
            if (index < 0) index = this.userSelectedFields.Items.Count - 1;
            object data = e.Data.GetData(typeof(string));
            this.userSelectedFields.Items.Remove(data);
            this.userSelectedFields.Items.Insert(index, data);
        }

        private void allFieldNames_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (allFieldNames.SelectedItems.Count == 0)
            {
                return;
            }
            foreach (string name in allFieldNames.SelectedItems)
            {
                userSelectedFields.Items.Add(name);
            }

            for (int i = allFieldNames.SelectedItems.Count - 1; i >= 0; i--)
            {
                allFieldNames.Items.Remove(allFieldNames.SelectedItems[i]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (userSelectedFields.SelectedItems.Count == 0)
            {
                return;
            }
            foreach (string name in userSelectedFields.SelectedItems)
            {
                allFieldNames.Items.Add(name);
            }
            for (int i = userSelectedFields.SelectedItems.Count - 1; i >= 0; i--)
            {
                userSelectedFields.Items.Remove(userSelectedFields.SelectedItems[i]);
            }

        }

        private void allFieldNames_DoubleClick(object sender, EventArgs e)
        {
            if ( allFieldNames.SelectedItems.Count > 0 )
            {
                copySelectedItemToOtherList(allFieldNames, userSelectedFields);
            }
        }

        private void copySelectedItemToOtherList(ListBox From, ListBox To)
        {
            foreach (string name in From.SelectedItems)
            {
                To.Items.Add(name);
            }

            for (int i = From.SelectedItems.Count - 1; i >= 0; i--)
            {
                From.Items.Remove(From.SelectedItems[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userSelectedFields.SelectionMode = SelectionMode.MultiSimple;
            for(int i = 0; i < userSelectedFields.Items.Count;i++)
            {
                userSelectedFields.SetSelected(i, true);
            }
            copySelectedItemToOtherList(userSelectedFields, allFieldNames);
            userSelectedFields.SelectionMode = SelectionMode.One;
        }

        private void cbPersonalShips_CheckedChanged(object sender, EventArgs e)
        {
            if ( cbPersonalShips.Checked )
            {
                cbExclusionList.Enabled = true;
            } else
            {
                cbExclusionList.Enabled = false;
            }
        }
    }
    class Option
    {
        private string name = "";
        private string value = "";
        private string classname = "";

        public Option(string DisplayName, string Value, string classname)
        {
            this.name = DisplayName;
            this.value = Value;
            this.classname = classname;
        }
        public string DisplayName { get { return this.name; } }
        public string Value { get { return this.value; } }
        public string ClassName { get { return this.classname; } }
    }
}
