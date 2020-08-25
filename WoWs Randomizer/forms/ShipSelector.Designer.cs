namespace WoWs_Randomizer.forms
{
    partial class ShipSelector
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
            this.shipSelectionBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // shipSelectionBox
            // 
            this.shipSelectionBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.shipSelectionBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.shipSelectionBox.FormattingEnabled = true;
            this.shipSelectionBox.Location = new System.Drawing.Point(27, 37);
            this.shipSelectionBox.Name = "shipSelectionBox";
            this.shipSelectionBox.Size = new System.Drawing.Size(319, 21);
            this.shipSelectionBox.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(352, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add ship";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ShipSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 94);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.shipSelectionBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ShipSelector";
            this.Text = "Select Ship to Compare";
            this.Load += new System.EventHandler(this.ShipSelector_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox shipSelectionBox;
        private System.Windows.Forms.Button button1;
    }
}