
namespace WoWs_Randomizer.forms
{
    partial class List
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
            this.resultGrid = new System.Windows.Forms.DataGridView();
            this.btnShow = new System.Windows.Forms.Button();
            this.allFieldNames = new System.Windows.Forms.ListBox();
            this.userSelectedFields = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbExclusionList = new System.Windows.Forms.CheckBox();
            this.cbPersonalShips = new System.Windows.Forms.RadioButton();
            this.cbAllShips = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbSub = new System.Windows.Forms.CheckBox();
            this.cbCV = new System.Windows.Forms.CheckBox();
            this.cbDD = new System.Windows.Forms.CheckBox();
            this.cbCA = new System.Windows.Forms.CheckBox();
            this.cbBB = new System.Windows.Forms.CheckBox();
            this.CBTier10 = new System.Windows.Forms.CheckBox();
            this.CBTier9 = new System.Windows.Forms.CheckBox();
            this.CBTier8 = new System.Windows.Forms.CheckBox();
            this.CBTier7 = new System.Windows.Forms.CheckBox();
            this.CBTier6 = new System.Windows.Forms.CheckBox();
            this.CBTier5 = new System.Windows.Forms.CheckBox();
            this.CBTier4 = new System.Windows.Forms.CheckBox();
            this.CBTier3 = new System.Windows.Forms.CheckBox();
            this.CBTier2 = new System.Windows.Forms.CheckBox();
            this.CBTier1 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbPremium = new System.Windows.Forms.CheckBox();
            this.cbTechTree = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // resultGrid
            // 
            this.resultGrid.AllowUserToAddRows = false;
            this.resultGrid.AllowUserToDeleteRows = false;
            this.resultGrid.AllowUserToOrderColumns = true;
            this.resultGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.resultGrid.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.resultGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultGrid.Location = new System.Drawing.Point(12, 327);
            this.resultGrid.Name = "resultGrid";
            this.resultGrid.Size = new System.Drawing.Size(1184, 363);
            this.resultGrid.TabIndex = 0;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(12, 298);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(137, 23);
            this.btnShow.TabIndex = 5;
            this.btnShow.Text = "Search";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // allFieldNames
            // 
            this.allFieldNames.FormattingEnabled = true;
            this.allFieldNames.Location = new System.Drawing.Point(998, 5);
            this.allFieldNames.Name = "allFieldNames";
            this.allFieldNames.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.allFieldNames.Size = new System.Drawing.Size(198, 316);
            this.allFieldNames.Sorted = true;
            this.allFieldNames.TabIndex = 8;
            this.allFieldNames.DragOver += new System.Windows.Forms.DragEventHandler(this.allFieldNames_DragOver);
            this.allFieldNames.DoubleClick += new System.EventHandler(this.allFieldNames_DoubleClick);
            // 
            // userSelectedFields
            // 
            this.userSelectedFields.AllowDrop = true;
            this.userSelectedFields.FormattingEnabled = true;
            this.userSelectedFields.Location = new System.Drawing.Point(710, 5);
            this.userSelectedFields.Name = "userSelectedFields";
            this.userSelectedFields.Size = new System.Drawing.Size(207, 316);
            this.userSelectedFields.TabIndex = 9;
            this.userSelectedFields.DragDrop += new System.Windows.Forms.DragEventHandler(this.userSelectedFields_DragDrop);
            this.userSelectedFields.DragOver += new System.Windows.Forms.DragEventHandler(this.userSelectedFields_DragOver);
            this.userSelectedFields.MouseDown += new System.Windows.Forms.MouseEventHandler(this.userSelectedFields_MouseDown);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(932, 84);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(46, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "<<";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(932, 127);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(46, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = ">>";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(932, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbExclusionList);
            this.groupBox1.Controls.Add(this.cbPersonalShips);
            this.groupBox1.Controls.Add(this.cbAllShips);
            this.groupBox1.Location = new System.Drawing.Point(25, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 93);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ships";
            // 
            // cbExclusionList
            // 
            this.cbExclusionList.AutoSize = true;
            this.cbExclusionList.Enabled = false;
            this.cbExclusionList.Location = new System.Drawing.Point(39, 67);
            this.cbExclusionList.Name = "cbExclusionList";
            this.cbExclusionList.Size = new System.Drawing.Size(112, 17);
            this.cbExclusionList.TabIndex = 2;
            this.cbExclusionList.Text = "Use Exclusion List";
            this.cbExclusionList.UseVisualStyleBackColor = true;
            // 
            // cbPersonalShips
            // 
            this.cbPersonalShips.AutoSize = true;
            this.cbPersonalShips.Location = new System.Drawing.Point(18, 43);
            this.cbPersonalShips.Name = "cbPersonalShips";
            this.cbPersonalShips.Size = new System.Drawing.Size(115, 17);
            this.cbPersonalShips.TabIndex = 1;
            this.cbPersonalShips.Text = "Personal ships only";
            this.cbPersonalShips.UseVisualStyleBackColor = true;
            this.cbPersonalShips.CheckedChanged += new System.EventHandler(this.cbPersonalShips_CheckedChanged);
            // 
            // cbAllShips
            // 
            this.cbAllShips.AutoSize = true;
            this.cbAllShips.Checked = true;
            this.cbAllShips.Location = new System.Drawing.Point(18, 20);
            this.cbAllShips.Name = "cbAllShips";
            this.cbAllShips.Size = new System.Drawing.Size(63, 17);
            this.cbAllShips.TabIndex = 0;
            this.cbAllShips.TabStop = true;
            this.cbAllShips.Text = "All ships";
            this.cbAllShips.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbSub);
            this.groupBox2.Controls.Add(this.cbCV);
            this.groupBox2.Controls.Add(this.cbDD);
            this.groupBox2.Controls.Add(this.cbCA);
            this.groupBox2.Controls.Add(this.cbBB);
            this.groupBox2.Location = new System.Drawing.Point(25, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ship class";
            // 
            // cbSub
            // 
            this.cbSub.AccessibleName = "Submarine";
            this.cbSub.AutoSize = true;
            this.cbSub.Location = new System.Drawing.Point(104, 43);
            this.cbSub.Name = "cbSub";
            this.cbSub.Size = new System.Drawing.Size(76, 17);
            this.cbSub.TabIndex = 4;
            this.cbSub.Text = "Submarine";
            this.cbSub.UseVisualStyleBackColor = true;
            // 
            // cbCV
            // 
            this.cbCV.AccessibleName = "AirCarrier";
            this.cbCV.AutoSize = true;
            this.cbCV.Location = new System.Drawing.Point(104, 20);
            this.cbCV.Name = "cbCV";
            this.cbCV.Size = new System.Drawing.Size(56, 17);
            this.cbCV.TabIndex = 3;
            this.cbCV.Text = "Carrier";
            this.cbCV.UseVisualStyleBackColor = true;
            // 
            // cbDD
            // 
            this.cbDD.AccessibleName = "Destroyer";
            this.cbDD.AutoSize = true;
            this.cbDD.Location = new System.Drawing.Point(18, 66);
            this.cbDD.Name = "cbDD";
            this.cbDD.Size = new System.Drawing.Size(71, 17);
            this.cbDD.TabIndex = 2;
            this.cbDD.Text = "Destroyer";
            this.cbDD.UseVisualStyleBackColor = true;
            // 
            // cbCA
            // 
            this.cbCA.AccessibleName = "Cruiser";
            this.cbCA.AutoSize = true;
            this.cbCA.Location = new System.Drawing.Point(18, 43);
            this.cbCA.Name = "cbCA";
            this.cbCA.Size = new System.Drawing.Size(58, 17);
            this.cbCA.TabIndex = 1;
            this.cbCA.Text = "Cruiser";
            this.cbCA.UseVisualStyleBackColor = true;
            // 
            // cbBB
            // 
            this.cbBB.AccessibleName = "Battleship";
            this.cbBB.AutoSize = true;
            this.cbBB.Location = new System.Drawing.Point(18, 20);
            this.cbBB.Name = "cbBB";
            this.cbBB.Size = new System.Drawing.Size(72, 17);
            this.cbBB.TabIndex = 0;
            this.cbBB.Text = "Battleship";
            this.cbBB.UseVisualStyleBackColor = true;
            // 
            // CBTier10
            // 
            this.CBTier10.AutoSize = true;
            this.CBTier10.Location = new System.Drawing.Point(112, 114);
            this.CBTier10.Name = "CBTier10";
            this.CBTier10.Size = new System.Drawing.Size(59, 17);
            this.CBTier10.TabIndex = 35;
            this.CBTier10.Tag = "10";
            this.CBTier10.Text = "Tier 10";
            this.CBTier10.UseVisualStyleBackColor = true;
            // 
            // CBTier9
            // 
            this.CBTier9.AutoSize = true;
            this.CBTier9.Location = new System.Drawing.Point(112, 91);
            this.CBTier9.Name = "CBTier9";
            this.CBTier9.Size = new System.Drawing.Size(53, 17);
            this.CBTier9.TabIndex = 34;
            this.CBTier9.Tag = "9";
            this.CBTier9.Text = "Tier 9";
            this.CBTier9.UseVisualStyleBackColor = true;
            // 
            // CBTier8
            // 
            this.CBTier8.AutoSize = true;
            this.CBTier8.Location = new System.Drawing.Point(112, 67);
            this.CBTier8.Name = "CBTier8";
            this.CBTier8.Size = new System.Drawing.Size(53, 17);
            this.CBTier8.TabIndex = 33;
            this.CBTier8.Tag = "8";
            this.CBTier8.Text = "Tier 8";
            this.CBTier8.UseVisualStyleBackColor = true;
            // 
            // CBTier7
            // 
            this.CBTier7.AutoSize = true;
            this.CBTier7.Location = new System.Drawing.Point(112, 43);
            this.CBTier7.Name = "CBTier7";
            this.CBTier7.Size = new System.Drawing.Size(53, 17);
            this.CBTier7.TabIndex = 32;
            this.CBTier7.Tag = "7";
            this.CBTier7.Text = "Tier 7";
            this.CBTier7.UseVisualStyleBackColor = true;
            // 
            // CBTier6
            // 
            this.CBTier6.AutoSize = true;
            this.CBTier6.Location = new System.Drawing.Point(112, 19);
            this.CBTier6.Name = "CBTier6";
            this.CBTier6.Size = new System.Drawing.Size(53, 17);
            this.CBTier6.TabIndex = 31;
            this.CBTier6.Tag = "6";
            this.CBTier6.Text = "Tier 6";
            this.CBTier6.UseVisualStyleBackColor = true;
            // 
            // CBTier5
            // 
            this.CBTier5.AutoSize = true;
            this.CBTier5.Location = new System.Drawing.Point(19, 114);
            this.CBTier5.Name = "CBTier5";
            this.CBTier5.Size = new System.Drawing.Size(53, 17);
            this.CBTier5.TabIndex = 30;
            this.CBTier5.Tag = "5";
            this.CBTier5.Text = "Tier 5";
            this.CBTier5.UseVisualStyleBackColor = true;
            // 
            // CBTier4
            // 
            this.CBTier4.AutoSize = true;
            this.CBTier4.Location = new System.Drawing.Point(19, 91);
            this.CBTier4.Name = "CBTier4";
            this.CBTier4.Size = new System.Drawing.Size(53, 17);
            this.CBTier4.TabIndex = 29;
            this.CBTier4.Tag = "4";
            this.CBTier4.Text = "Tier 4";
            this.CBTier4.UseVisualStyleBackColor = true;
            // 
            // CBTier3
            // 
            this.CBTier3.AutoSize = true;
            this.CBTier3.Location = new System.Drawing.Point(19, 67);
            this.CBTier3.Name = "CBTier3";
            this.CBTier3.Size = new System.Drawing.Size(53, 17);
            this.CBTier3.TabIndex = 28;
            this.CBTier3.Tag = "3";
            this.CBTier3.Text = "Tier 3";
            this.CBTier3.UseVisualStyleBackColor = true;
            // 
            // CBTier2
            // 
            this.CBTier2.AutoSize = true;
            this.CBTier2.Location = new System.Drawing.Point(19, 43);
            this.CBTier2.Name = "CBTier2";
            this.CBTier2.Size = new System.Drawing.Size(53, 17);
            this.CBTier2.TabIndex = 27;
            this.CBTier2.Tag = "2";
            this.CBTier2.Text = "Tier 2";
            this.CBTier2.UseVisualStyleBackColor = true;
            // 
            // CBTier1
            // 
            this.CBTier1.AutoSize = true;
            this.CBTier1.Location = new System.Drawing.Point(19, 19);
            this.CBTier1.Name = "CBTier1";
            this.CBTier1.Size = new System.Drawing.Size(53, 17);
            this.CBTier1.TabIndex = 26;
            this.CBTier1.Tag = "1";
            this.CBTier1.Text = "Tier 1";
            this.CBTier1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CBTier8);
            this.groupBox3.Controls.Add(this.CBTier10);
            this.groupBox3.Controls.Add(this.CBTier1);
            this.groupBox3.Controls.Add(this.CBTier9);
            this.groupBox3.Controls.Add(this.CBTier2);
            this.groupBox3.Controls.Add(this.CBTier3);
            this.groupBox3.Controls.Add(this.CBTier7);
            this.groupBox3.Controls.Add(this.CBTier4);
            this.groupBox3.Controls.Add(this.CBTier6);
            this.groupBox3.Controls.Add(this.CBTier5);
            this.groupBox3.Location = new System.Drawing.Point(231, 29);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 146);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tier";
            // 
            // cbPremium
            // 
            this.cbPremium.AutoSize = true;
            this.cbPremium.Location = new System.Drawing.Point(343, 194);
            this.cbPremium.Name = "cbPremium";
            this.cbPremium.Size = new System.Drawing.Size(66, 17);
            this.cbPremium.TabIndex = 37;
            this.cbPremium.Tag = "true";
            this.cbPremium.Text = "Premium";
            this.cbPremium.UseVisualStyleBackColor = true;
            // 
            // cbTechTree
            // 
            this.cbTechTree.AutoSize = true;
            this.cbTechTree.Location = new System.Drawing.Point(237, 194);
            this.cbTechTree.Name = "cbTechTree";
            this.cbTechTree.Size = new System.Drawing.Size(72, 17);
            this.cbTechTree.TabIndex = 38;
            this.cbTechTree.Tag = "false";
            this.cbTechTree.Text = "Tech tree";
            this.cbTechTree.UseVisualStyleBackColor = true;
            // 
            // List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 702);
            this.Controls.Add(this.cbTechTree);
            this.Controls.Add(this.cbPremium);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.userSelectedFields);
            this.Controls.Add(this.allFieldNames);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.resultGrid);
            this.Name = "List";
            this.Text = "List";
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView resultGrid;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.ListBox allFieldNames;
        private System.Windows.Forms.ListBox userSelectedFields;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton cbPersonalShips;
        private System.Windows.Forms.RadioButton cbAllShips;
        private System.Windows.Forms.CheckBox cbExclusionList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbSub;
        private System.Windows.Forms.CheckBox cbCV;
        private System.Windows.Forms.CheckBox cbDD;
        private System.Windows.Forms.CheckBox cbCA;
        private System.Windows.Forms.CheckBox cbBB;
        private System.Windows.Forms.CheckBox CBTier10;
        private System.Windows.Forms.CheckBox CBTier9;
        private System.Windows.Forms.CheckBox CBTier8;
        private System.Windows.Forms.CheckBox CBTier7;
        private System.Windows.Forms.CheckBox CBTier6;
        private System.Windows.Forms.CheckBox CBTier5;
        private System.Windows.Forms.CheckBox CBTier4;
        private System.Windows.Forms.CheckBox CBTier3;
        private System.Windows.Forms.CheckBox CBTier2;
        private System.Windows.Forms.CheckBox CBTier1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbPremium;
        private System.Windows.Forms.CheckBox cbTechTree;
    }
}