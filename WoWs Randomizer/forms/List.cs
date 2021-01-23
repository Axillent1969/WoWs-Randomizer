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

        public List()
        {
            InitializeComponent();
            resultGrid.DataSource = table;
            //fieldSelector.AllowDrop = true;
        }

        private void test()
        {
            Type myType = typeof(ShipMetrics);
            FieldInfo[] fields = myType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            //Console.WriteLine("Display fields ... ");
            for(int i = 0; i < fields.Length; i++ )
            {
                string n = fields[i].Name;
                n = n.Replace("k__BackingField", "").Replace("<", "").Replace(">", "");

                //Console.WriteLine("FIELD: " + fields[i].Name + " -> " + n);

                var ex = myType.GetProperty(n);
                bool isDefined = false;

                if (ex != null)
                {
                    isDefined = Attribute.IsDefined(ex, typeof(Exposed));
                }

                if (isDefined)
                {
                    exposedFields.Add(n);
                }
            }

            Type myType2 = typeof(Ship);
            FieldInfo[] fields2 = myType2.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            for (int i = 0; i < fields2.Length; i++)
            {
                string n = fields2[i].Name;
                n = n.Replace("k__BackingField", "").Replace("<", "").Replace(">","");
                
                //Console.WriteLine("FIELD: " + fields2[i].Name + " -> " + n);

                var ex = myType2.GetProperty(n);
                bool isDefined = false;

                if ( ex != null )
                {
                    isDefined = Attribute.IsDefined(ex, typeof(Exposed));
                }

                if ( isDefined  )
                {
                    exposedFields.Add(n);
                }
                //Console.WriteLine("Has EXPOSED: " + isDefined);

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
            //fieldSelector.Items.Clear();
            //foreach(string itm in exposedFields)
            //{
            //    fieldSelector.Items.Add(itm);
            //}
            allFieldNames.Items.Clear();
            foreach (string itm in exposedFields)
            {
                allFieldNames.Items.Add(itm);
            }
        }

        private void addHeaders()
        {
            table.Columns.Clear();

            foreach(var obj in userSelectedFields.Items)
            {
                string itm = (string)obj;
                table.Columns.Add(itm);
            }
        }

        private void addRows()
        {
            table.Rows.Clear();

            foreach(Ship ship in Program.AllShips) {

                try
                {
                    MetricsExctractor Extractor = new MetricsExctractor(ship);
                    ShipMetrics metrics = Extractor.GetMetrics();


                    DataRow row = table.NewRow();

                    int rowIdx = 0;
                    foreach (var obj in userSelectedFields.Items)
                    {
                        string itm = (string)obj;
                        itm = "<" + itm + ">k__BackingField";
                        FieldInfo fld = typeof(Ship).GetField(itm, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                        row[rowIdx] = fld.GetValue(ship);
                        rowIdx++;
                    }
                    table.Rows.Add(row);
                } catch(Exception ex) {
                    Console.WriteLine(ex);
                    Console.WriteLine(table);
                    Console.WriteLine(table.Columns.Count);
                    Console.WriteLine(table.Rows.Count);
                }
            }

            resultGrid.Sort(resultGrid.Columns[0], ListSortDirection.Ascending);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            test();
        }

        private void fieldSelector_DragDrop(object sender, DragEventArgs e)
        {
            //Point point = fieldSelector.PointToClient(new Point(e.X, e.Y));
            //int index = this.fieldSelector.IndexFromPoint(point);
            //if (index < 0) index = this.fieldSelector.Items.Count - 1;
            //object data = e.Data.GetData(typeof(string));
            //this.fieldSelector.Items.Remove(data);
            //this.fieldSelector.Items.Insert(index, data);
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
            if ( allFieldNames.SelectedItems.Count == 0 )
            {
                return;
            }
            foreach( string name in allFieldNames.SelectedItems )
            {
                userSelectedFields.Items.Add(name);
            }

            for(int i = allFieldNames.SelectedItems.Count - 1; i >= 0; i--)
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
    }
}
