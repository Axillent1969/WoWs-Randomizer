using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WoWs_Randomizer.forms
{
    public partial class QueryBuilder : Form
    {
        public List<string> exposedFieldNames = null;
        public string QueryResult = "";

        private Query currentQuery = new Query();
        public QueryBuilder()
        {
            InitializeComponent();
            
        }

        public void UpdateQuery()
        {
            txtQueryResult.Text = currentQuery.ToString();
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            currentQuery.SetOperator("=");
            UpdateQuery();
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            currentQuery.SetOperator(btn.Text);
            UpdateQuery();
        }

        class Query
        {
            private string field = "";
            private string op = "";
            private string value = "";

            public Query() { }
            public Query(string field, string op, string value)
            {
                this.field = field;
                this.op = op;
                this.value = value;
            }

            public void SetField(string field)
            {
                this.field = field;
            }
            public void SetOperator(string op)
            {
                this.op = op;
            }
            public void SetValue(string value)
            {
                this.value = value;
            }
            public bool IsValidQuery()
            {
                return !(this.field.Equals("") || this.op.Equals("") || this.value.Equals(""));
            }

            override public string ToString()
            {
                return this.field + " " + this.op + " " + this.value;
            }
        }

        private void fieldSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox box = (ListBox)sender;
            currentQuery.SetField(box.SelectedItem.ToString());
            UpdateQuery();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            btnOK.DialogResult = DialogResult.None;
            if ( currentQuery.IsValidQuery() )
            {
                QueryResult = currentQuery.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            } else
            {
                MessageBox.Show("The query is not valid/is incomplete. Review the query and try again.", "Query not valid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void QueryBuilder_Load(object sender, EventArgs e)
        {
            fieldSelection.Items.AddRange(exposedFieldNames.ToArray());
        }

        private void txtValue_KeyUp(object sender, KeyEventArgs e)
        {
            currentQuery.SetValue(txtValue.Text);
            UpdateQuery();
        }
    }
}
