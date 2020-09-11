namespace WoWs_Randomizer.forms
{
    partial class CompareShip
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompareShip));
            this.RightPanel = new System.Windows.Forms.Panel();
            this.Headline = new System.Windows.Forms.Label();
            this.ShipMetricsTable = new System.Windows.Forms.TableLayoutPanel();
            this.RightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // RightPanel
            // 
            this.RightPanel.Controls.Add(this.Headline);
            this.RightPanel.Controls.Add(this.ShipMetricsTable);
            this.RightPanel.Location = new System.Drawing.Point(3, 3);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(228, 826);
            this.RightPanel.TabIndex = 4;
            // 
            // Headline
            // 
            this.Headline.AutoSize = true;
            this.Headline.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Headline.Location = new System.Drawing.Point(49, 0);
            this.Headline.Name = "Headline";
            this.Headline.Size = new System.Drawing.Size(125, 24);
            this.Headline.TabIndex = 1;
            this.Headline.Text = "Ship Metrics";
            // 
            // ShipMetricsTable
            // 
            this.ShipMetricsTable.ColumnCount = 2;
            this.ShipMetricsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.ShipMetricsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.ShipMetricsTable.Location = new System.Drawing.Point(6, 27);
            this.ShipMetricsTable.Name = "ShipMetricsTable";
            this.ShipMetricsTable.RowCount = 1;
            this.ShipMetricsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 701F));
            this.ShipMetricsTable.Size = new System.Drawing.Size(219, 796);
            this.ShipMetricsTable.TabIndex = 0;
            // 
            // CompareShip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 841);
            this.Controls.Add(this.RightPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CompareShip";
            this.Text = "CompareShip";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CompareShip_FormClosing);
            this.RightPanel.ResumeLayout(false);
            this.RightPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel RightPanel;
        private System.Windows.Forms.Label Headline;
        private System.Windows.Forms.TableLayoutPanel ShipMetricsTable;
    }
}