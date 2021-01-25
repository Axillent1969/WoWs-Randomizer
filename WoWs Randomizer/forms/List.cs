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
        private static string CONDITION_ALLSHIPS = "AllShipType";
        private static string CONDITION_ALLTIERS = "AllTiers";
        private static string CONDITION_ALLNATIONS = "AllNations";

        private DataTable table = new DataTable();
        List<string> exposedFields = new List<string>();
        private Dictionary<string, Option> mapping = new Dictionary<string, Option>();
        public List<long> personalShips = new List<long>();
        public HashSet<long> ExcludedShips = new HashSet<long>();

        public List()
        {
            InitializeComponent();
            resultGrid.DataSource = table;
            PrepareFieldNames();
        }

        private void PrepareFieldNames()
        {
            GatherExposedFieldNames(typeof(Ship));
            GatherExposedFieldNames(typeof(ShipMetrics));
            exposedFields.Sort();
            fillSelector();
        }

        private void GatherExposedFieldNames(Type clazz)
        {
            FieldInfo[] fields = clazz.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            for (int i = 0; i < fields.Length; i++)
            {
                string n = fields[i].Name;
                string disp = n.Replace("k__BackingField", "").Replace("<", "").Replace(">", "");

                var ex = clazz.GetProperty(disp);
                bool isDefined = false;

                if (ex != null)
                {
                    isDefined = Attribute.IsDefined(ex, typeof(Exposed));
                }

                if (isDefined)
                {
                    Option opt = new Option(disp, n,clazz.Name,fields[i].FieldType.ToString());
                    this.mapping.Add(disp, opt);
                    exposedFields.Add(disp);
                }
            }
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
            lblRecordCount.Text = table.Rows.Count + " records found.";
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

        private List<string> AssembleConditions()
        {
            List<string> conditions = new List<string>();

            bool isShipClassSelected = false;
            var cbShipClass = groupShipClass.Controls.OfType<CheckBox>();
            foreach (CheckBox cb in cbShipClass)
            {
                if (cb.Checked)
                {
                    isShipClassSelected = true;
                    conditions.Add(cb.AccessibleName);
                }
            }
            if (isShipClassSelected == false)
            {
                conditions.Add(CONDITION_ALLSHIPS);
            }

            bool isTierSelected = false;
            var cbTiers = groupTier.Controls.OfType<CheckBox>();
            foreach (CheckBox cb in cbTiers)
            {
                if (cb.Checked)
                {
                    conditions.Add(cb.Tag.ToString());
                    isTierSelected = true;
                }
            }
            if (isTierSelected == false)
            {
                conditions.Add(CONDITION_ALLTIERS);
            }

            if (cbTechTree.Checked || cbPremium.Checked)
            {
                if (cbTechTree.Checked) { conditions.Add("PS:" + cbTechTree.Tag.ToString()); }
                if (cbPremium.Checked) { conditions.Add("PS:" + cbPremium.Tag.ToString()); }
            }
            else
            {
                conditions.Add("PS:" + cbTechTree.Tag.ToString());
                conditions.Add("PS:" + cbPremium.Tag.ToString());
            }

            bool isNationSelected = false;
            var cbNations = groupNations.Controls.OfType<CheckBox>();
            foreach (CheckBox cb in cbNations)
            {
                if (cb.Checked)
                {
                    conditions.Add(cb.Tag.ToString());
                    isNationSelected = true;
                }
            }
            if (isNationSelected == false)
            {
                conditions.Add(CONDITION_ALLNATIONS);
            }

            return conditions;
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
            List<Ship> ShipQuery;
            List<string> conditions = AssembleConditions();

            if ( cbAllShips.Checked )
            {
                ShipQuery = new List<Ship>(Program.AllShips);
            } else
            {
                ShipQuery = new List<Ship>(AssembleShipList());
            }

            foreach (Ship ship in ShipQuery)
            {
                MetricsExctractor extractor = new MetricsExctractor(ship);

                if (!(conditions.Contains(CONDITION_ALLSHIPS) || conditions.Contains(ship.ShipType.ToString())))
                {
                    {
                        continue;
                    }
                }
                if (!(conditions.Contains(CONDITION_ALLTIERS) || conditions.Contains(ship.Tier.ToString())))
                {
                    continue;
                }
                if (!(conditions.Contains("PS:" + ship.Premium.ToString().ToLower())))
                {
                    continue;
                }
                if (!(conditions.Contains(CONDITION_ALLNATIONS) || conditions.Contains(ship.Country.ToString())))
                {
                    continue;
                }

                ShipMetrics metrics = extractor.GetMetrics();
                if ( isConditionMetForShip(ship,metrics) == false)
                {
                    continue;
                }

                populateTableRow(ship, metrics);
            }

            resultGrid.Sort(resultGrid.Columns[0], ListSortDirection.Ascending);
        }

        private void populateTableRow(Ship ship, ShipMetrics metrics)
        {
            try
            {
                DataRow row = table.NewRow();

                int rowIdx = 0;
                foreach (var obj in userSelectedFields.Items)
                {
                    string itm = (string)obj;
                    Option opt = this.mapping[itm];
                    if (opt != null)
                    {
                        if (opt.ClassName.Equals(typeof(Ship).Name))
                        {
                            row[rowIdx] = GetFieldValue(ship,opt.Value);
                        }
                        else if (opt.ClassName.Equals(typeof(ShipMetrics).Name))
                        {
                            row[rowIdx] = GetFieldValue(metrics,opt.Value);
                        }
                    }
                    rowIdx++;
                }
                table.Rows.Add(row);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private object GetFieldValue(object clazz, string fieldName)
        {
            FieldInfo fld = clazz.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            return fld.GetValue(clazz);
        }

        private double SafeConvertToDouble(string value)
        {
            try
            {
                return double.Parse(value);
            }
            catch (Exception)
            {
            }
            return 0.0;
        }

        private bool isConditionMetForShip(Ship ship, ShipMetrics metrics)
        {
            foreach (string query in listQuery.Items)
            {
                string[] tmp = query.Split(' ');
                string fldName = tmp[0];
                string queryCondition = tmp[1];
                string queryValue = tmp[2];
                double queryValueDbl = 0.0;
                string fieldValue = "";
                double fieldValueDbl = 0.0;
                bool compareDouble = false;

                Option opt = this.mapping[fldName];
                
                if (opt.ClassName.Equals(typeof(Ship).Name))
                {
                    object val = GetFieldValue(ship, opt.Value);
                    if (val is double)
                    {
                        fieldValueDbl = (double)val;
                        compareDouble = true;
                    }
                    fieldValue = val.ToString();

                }
                else if (opt.ClassName.Equals(typeof(ShipMetrics).Name))
                {
                    object val = GetFieldValue(metrics, opt.Value);
                    if ( val is double )
                    {
                        fieldValueDbl = (double)val;
                        compareDouble = true;
                    }
                    fieldValue = val.ToString();
                } else
                {
                    return false;
                }

                if ( compareDouble )
                {
                    queryValueDbl = SafeConvertToDouble(queryValue);
                }

                if ( queryCondition.Equals("!="))
                {
                    if ((compareDouble && queryValueDbl == fieldValueDbl) || (compareDouble == false && fieldValue.Equals(queryValue)))
                    {
                        return false;
                    }
                } else if ( queryCondition.Equals("="))
                {
                    if ((compareDouble && queryValueDbl != fieldValueDbl) || (compareDouble == false && !fieldValue.Equals(queryValue)))
                    {
                        return false;
                    }
                } else if ( queryCondition.StartsWith("<"))
                {
                    // This can only be done on values - not strings. If field is string, we need to convert to double;
                    if ( compareDouble == false )
                    {
                        queryValueDbl = SafeConvertToDouble(queryValue);
                        fieldValueDbl = SafeConvertToDouble(fieldValue);
                    }
                    bool isEqualOk = queryCondition.Contains("=");
                    if ( queryValueDbl < fieldValueDbl)
                    {
                        return false;
                    } else if ( isEqualOk == false && queryValueDbl == fieldValueDbl)
                    {
                        return false;
                    }


                } else if ( queryCondition.StartsWith(">"))
                {
                    // This can only be done on values - not strings. If field is string, we need to convert to double;
                    if (compareDouble == false)
                    {
                        queryValueDbl = SafeConvertToDouble(queryValue);
                        fieldValueDbl = SafeConvertToDouble(fieldValue);
                    }
                    bool isEqualOk = queryCondition.Contains("=");
                    if (fieldValueDbl < queryValueDbl )
                    {
                        return false;
                    }
                    else if (isEqualOk == false && queryValueDbl == fieldValueDbl)
                    {
                        return false;
                    }
                }
            }
            return true;
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

        private void btnRemoveQuery_Click(object sender, EventArgs e)
        {
            if ( listQuery.SelectedItems.Count == 0 ) { return; }
            listQuery.Items.Remove(listQuery.SelectedItem);
        }

        private void btnAddQuery_Click(object sender, EventArgs e)
        {
            QueryBuilder builder = new QueryBuilder();
            builder.exposedFieldNames = this.exposedFields;
            if ( builder.ShowDialog() == DialogResult.OK )
            {
                listQuery.Items.Add(builder.QueryResult);
            }
        }
    }
    class Option
    {
        private string name = "";
        private string value = "";
        private string classname = "";
        private string fieldType = "System.Double";

        public Option(string DisplayName, string Value, string classname, string fieldType = "System.Double")
        {
            this.name = DisplayName;
            this.value = Value;
            this.classname = classname;
            this.fieldType = fieldType;
            
        }
        public string DisplayName { get { return this.name; } }
        public string Value { get { return this.value; } }
        public string ClassName { get { return this.classname; } }
        public string FieldType { get { return this.fieldType; } }
    }
}
