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
using WoWs_Randomizer.objects;
using WoWs_Randomizer.utils;
using WoWs_Randomizer.utils.ship;

namespace WoWs_Randomizer.forms
{
    public partial class QueryTool : Form
    {
        private static string CONDITION_ALLSHIPS = "AllShipType";
        private static string CONDITION_ALLTIERS = "AllTiers";
        private static string CONDITION_ALLNATIONS = "AllNations";

        private DataTable table = new DataTable();
        List<string> exposedFields = new List<string>();
        private Dictionary<string, Option> mapping = new Dictionary<string, Option>();
        public List<long> personalShips = new List<long>();
        public HashSet<long> ExcludedShips = new HashSet<long>();

        public QueryTool()
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
                    Exposed attr = (Exposed)Attribute.GetCustomAttribute(ex, typeof(Exposed));
                    Option opt = new Option(disp, n,clazz.Name,fields[i].FieldType.ToString(),attr.getName());
                    this.mapping.Add(disp, opt);
                    exposedFields.Add(disp);
                }
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            doSearch();
        }

        private void doSearch()
        {
            if (userSelectedFields.Items.Count == 0)
            {
                MessageBox.Show("You have not selected any fields. Select one or more fields to display and try again.", "Unable to search", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Option opt = this.mapping[itm];
                Type t = Type.GetType(opt.FieldType);
                table.Columns.Add(itm,t);
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
            if ( fld.FieldType.ToString().Equals("System.String"))
            {
                return (string)fld.GetValue(clazz);
            }
            return Convert.ToDouble(fld.GetValue(clazz));
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
            lblDescription.Text = "";
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryReport report = new QueryReport();
            report.conditions = AssembleConditions();
            report.queries = new List<string>(listQuery.Items.Cast<string>().ToList());
            report.selectedFields = new List<string>(userSelectedFields.Items.Cast<string>().ToList());
            report.unusedFields = new List<string>(allFieldNames.Items.Cast<string>().ToList());
            report.useExclusionList = cbExclusionList.Checked;
            report.useAllShips = cbAllShips.Checked;

            Settings settings = Commons.GetSettings();
            string def = settings.SaveLocation;

            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.InitialDirectory = def;
            saveDlg.DefaultExt = "rpt";
            saveDlg.FileName = "report.rpt";
            saveDlg.Filter = "Randomizer Query Report (*.rpt)|*.rpt";
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                string file = saveDlg.FileName;
                if (!file.EndsWith(".rpt"))
                {
                    file += ".rpt";
                }
                BinarySerialize.WriteToBinaryFile(file, report);
            }
        }

        private void loadQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = Commons.GetSettings();

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Randomizer Query Report (*.rpt)|*.rpt";
            openFile.DefaultExt = "rpt";
            openFile.InitialDirectory = settings.SaveLocation;

            string fileName = "";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                fileName = openFile.FileName;
            }
            else
            {
                return;
            }

            QueryReport report = BinarySerialize.ReadFromBinaryFile<QueryReport>(fileName);

            UnselectAllCheckboxes();
            allFieldNames.Items.Clear();
            userSelectedFields.Items.Clear();
            listQuery.Items.Clear();

            if ( report.useAllShips == false ) { cbAllShips.Checked = false; cbPersonalShips.Checked = true; cbExclusionList.Enabled = true; }
            if ( report.useExclusionList ) { cbExclusionList.Checked = true;  } else { cbExclusionList.Checked = false; }

            foreach(string itm in report.unusedFields) { allFieldNames.Items.Add(itm); }
            foreach(string itm in report.selectedFields) { userSelectedFields.Items.Add(itm); }
            foreach(string itm in report.queries) { listQuery.Items.Add(itm); }

            foreach (string itm in report.conditions)
            {
                if (itm.Equals("PS:" + cbTechTree.Tag.ToString())) { cbTechTree.Checked = true; }
                else if (itm.Equals("PS:" + cbPremium.Tag.ToString())) { cbPremium.Checked = true; }
                else if ( itm.Equals(CONDITION_ALLNATIONS) || itm.Equals(CONDITION_ALLSHIPS) || itm.Equals(CONDITION_ALLTIERS)) { }
                else { SelectCheckboxByConditionName(itm); }
            }

            if ( cbPremium.Checked && cbTechTree.Checked )
            {
                cbTechTree.Checked = false;
                cbPremium.Checked = false;
            }

            btnShow_Click(new object(), new EventArgs());
        }

        private void SelectCheckboxByConditionName(string conditionName)
        {
            var cbNations = groupNations.Controls.OfType<CheckBox>();
            var cbTiers = groupTier.Controls.OfType<CheckBox>();
            var cbShipclass = groupShipClass.Controls.OfType<CheckBox>();

            var allCheckboxes = cbNations.Concat<CheckBox>(cbTiers).Concat<CheckBox>(cbShipclass);

            foreach (CheckBox cb in allCheckboxes)
            {
                if ( cb.AccessibleName != null && cb.AccessibleName.Equals(conditionName))
                {
                    cb.Checked = true;
                    break;
                } else if ( cb.Tag != null && cb.Tag.ToString().Equals(conditionName))
                {
                    cb.Checked = true;
                    break;
                }
            }
        }

        private void UnselectAllCheckboxes()
        {
            cbAllShips.Checked = true; 
            cbPersonalShips.Checked = false; 
            cbExclusionList.Checked = false;
            cbExclusionList.Enabled = false;

            var cbNations = groupNations.Controls.OfType<CheckBox>();
            foreach (CheckBox cb in cbNations) { cb.Checked = false; }
            var cbTiers = groupNations.Controls.OfType<CheckBox>();
            foreach (CheckBox cb in cbTiers) { cb.Checked = false; }
            var cbShipclass = groupShipClass.Controls.OfType<CheckBox>();
            foreach(CheckBox cb in cbShipclass) { cb.Checked = false; }
            cbTechTree.Checked = false;
            cbPremium.Checked = false;
        }

        private void allFieldNames_MouseClick(object sender, MouseEventArgs e)
        {
            string txt = "";
            if ( allFieldNames.SelectedItem != null )
            {
                foreach(string itm in allFieldNames.SelectedItems)
                {
                    Option opt = this.mapping[itm];
                    if ( !opt.Description.Equals(""))
                    {
                        txt += opt.Description + ", ";
                    }
                }
            }
            if ( txt.EndsWith(", "))
            {
                txt = txt.Substring(0, txt.Length - 2);
            }
            lblDescription.Text = txt;
        }
    }
    class Option
    {
        private string name = "";
        private string value = "";
        private string classname = "";
        private string fieldType = "System.Double";
        private string description = "";

        public Option(string DisplayName, string Value, string classname, string fieldType = "System.Double", string description = "")
        {
            this.name = DisplayName;
            this.value = Value;
            this.classname = classname;
            this.fieldType = fieldType;
            this.description = description;
        }
        public string DisplayName { get { return this.name; } }
        public string Value { get { return this.value; } }
        public string ClassName { get { return this.classname; } }
        public string FieldType { get { return this.fieldType; } }
        public string Description { get { return this.description; } }
    }
}
