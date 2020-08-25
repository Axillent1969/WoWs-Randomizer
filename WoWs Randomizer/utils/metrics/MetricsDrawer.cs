using System.Drawing;
using System.Windows.Forms;

namespace WoWs_Randomizer.utils
{
    class MetricsDrawer
    {
        private static readonly int TABLEWIDTH = 525;
        private TableLayoutPanel ShipMetricsTable = null;

        public MetricsDrawer(TableLayoutPanel ShipMetricsTable)
        {
            this.ShipMetricsTable = ShipMetricsTable;
            ClearTable();
        }

        public void AppendHeadline(string text)
        {
            Label lbl = GenerateHeadline(text);
            ShipMetricsTable.RowCount += 1;
            ShipMetricsTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            ShipMetricsTable.SetColumnSpan(lbl, 2);
            ShipMetricsTable.Controls.Add(lbl, 0, ShipMetricsTable.RowCount - 1);
            ShipMetricsTable.GetControlFromPosition(0, ShipMetricsTable.RowCount - 1).BackColor = Color.LightBlue;
        }

        public void AppendRow(string labelText, string value, string tooltipText = "", string tooltipTitle = "", string tag = "")
        {
            ShipMetricsTable.RowCount += 1;
            ShipMetricsTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            Label lbl = new Label();
            lbl.Text = labelText;
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            ShipMetricsTable.Controls.Add(lbl, 0, ShipMetricsTable.RowCount - 1);

            Label lblValue = new Label();
            lblValue.Text = value;
            lblValue.TextAlign = ContentAlignment.MiddleRight;
            if (!tag.Equals(""))
            {
                lblValue.Tag = tag;
            }
            ShipMetricsTable.Controls.Add(lblValue, 1, ShipMetricsTable.RowCount - 1);

            if (!string.IsNullOrWhiteSpace(tooltipText))
            {
                ToolTip eTtip = new ToolTip();
                if (!tooltipTitle.Equals(""))
                {
                    eTtip.ToolTipTitle = tooltipTitle;
                }
                eTtip.SetToolTip(lblValue, tooltipText);
                ShipMetricsTable.Controls.Add(lblValue, 1, ShipMetricsTable.RowCount - 1);
            }
        }

        public void AppendFullRow(string text)
        {
            ShipMetricsTable.RowCount += 1;
            ShipMetricsTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            Label lbl = new Label();
            lbl.Text = text;
            lbl.Width = TABLEWIDTH;
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            ShipMetricsTable.SetColumnSpan(lbl, 2);
            ShipMetricsTable.Controls.Add(lbl, 0, ShipMetricsTable.RowCount - 1);
        }

        public void SuspendLayout()
        {
            ShipMetricsTable.Visible = false;
            ShipMetricsTable.SuspendLayout();
        }

        public void ResumeLayout()
        {
            ShipMetricsTable.ResumeLayout(true);
            ShipMetricsTable.Visible = true;
        }

        private void ClearTable()
        {
            ShipMetricsTable.Controls.Clear();
            ShipMetricsTable.RowStyles.Clear();
            ShipMetricsTable.RowCount = 0;
            //ShipMetricsTable.ColumnStyles.Clear();

            ShipMetricsTable.ColumnCount = 2;
            ShipMetricsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 400F));
            ShipMetricsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125F));
        }

        private Label GenerateHeadline(string text)
        {
            Label Headline = new Label();
            Headline.Text = text;
            Headline.AutoSize = false;
            Headline.Dock = DockStyle.Fill;
            Headline.Anchor = AnchorStyles.Left;
            Headline.TextAlign = ContentAlignment.MiddleCenter;
            Headline.Width = TABLEWIDTH;

            return Headline;
        }
    }
}
