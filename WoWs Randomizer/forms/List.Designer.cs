
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
            this.groupShipClass = new System.Windows.Forms.GroupBox();
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
            this.groupTier = new System.Windows.Forms.GroupBox();
            this.cbPremium = new System.Windows.Forms.CheckBox();
            this.cbTechTree = new System.Windows.Forms.CheckBox();
            this.groupNations = new System.Windows.Forms.GroupBox();
            this.CBCountry11 = new System.Windows.Forms.CheckBox();
            this.CBCountry10 = new System.Windows.Forms.CheckBox();
            this.CBCountry9 = new System.Windows.Forms.CheckBox();
            this.CBCountry8 = new System.Windows.Forms.CheckBox();
            this.CBCountry7 = new System.Windows.Forms.CheckBox();
            this.CBCountry6 = new System.Windows.Forms.CheckBox();
            this.CBCountry5 = new System.Windows.Forms.CheckBox();
            this.CBCountry4 = new System.Windows.Forms.CheckBox();
            this.CBCountry3 = new System.Windows.Forms.CheckBox();
            this.CBCountry2 = new System.Windows.Forms.CheckBox();
            this.CBCountry1 = new System.Windows.Forms.CheckBox();
            this.groupQuery = new System.Windows.Forms.GroupBox();
            this.listQuery = new System.Windows.Forms.ListBox();
            this.btnAddQuery = new System.Windows.Forms.Button();
            this.btnRemoveQuery = new System.Windows.Forms.Button();
            this.lblRecordCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupShipClass.SuspendLayout();
            this.groupTier.SuspendLayout();
            this.groupNations.SuspendLayout();
            this.groupQuery.SuspendLayout();
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
            this.btnShow.Location = new System.Drawing.Point(12, 271);
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
            this.groupBox1.Location = new System.Drawing.Point(25, 12);
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
            // groupShipClass
            // 
            this.groupShipClass.Controls.Add(this.cbSub);
            this.groupShipClass.Controls.Add(this.cbCV);
            this.groupShipClass.Controls.Add(this.cbDD);
            this.groupShipClass.Controls.Add(this.cbCA);
            this.groupShipClass.Controls.Add(this.cbBB);
            this.groupShipClass.Location = new System.Drawing.Point(25, 111);
            this.groupShipClass.Name = "groupShipClass";
            this.groupShipClass.Size = new System.Drawing.Size(200, 100);
            this.groupShipClass.TabIndex = 14;
            this.groupShipClass.TabStop = false;
            this.groupShipClass.Text = "Ship class";
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
            // groupTier
            // 
            this.groupTier.Controls.Add(this.CBTier8);
            this.groupTier.Controls.Add(this.CBTier10);
            this.groupTier.Controls.Add(this.CBTier1);
            this.groupTier.Controls.Add(this.CBTier9);
            this.groupTier.Controls.Add(this.CBTier2);
            this.groupTier.Controls.Add(this.CBTier3);
            this.groupTier.Controls.Add(this.CBTier7);
            this.groupTier.Controls.Add(this.CBTier4);
            this.groupTier.Controls.Add(this.CBTier6);
            this.groupTier.Controls.Add(this.CBTier5);
            this.groupTier.Location = new System.Drawing.Point(231, 12);
            this.groupTier.Name = "groupTier";
            this.groupTier.Size = new System.Drawing.Size(200, 146);
            this.groupTier.TabIndex = 36;
            this.groupTier.TabStop = false;
            this.groupTier.Text = "Tier";
            // 
            // cbPremium
            // 
            this.cbPremium.AutoSize = true;
            this.cbPremium.Location = new System.Drawing.Point(148, 217);
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
            this.cbTechTree.Location = new System.Drawing.Point(42, 217);
            this.cbTechTree.Name = "cbTechTree";
            this.cbTechTree.Size = new System.Drawing.Size(72, 17);
            this.cbTechTree.TabIndex = 38;
            this.cbTechTree.Tag = "false";
            this.cbTechTree.Text = "Tech tree";
            this.cbTechTree.UseVisualStyleBackColor = true;
            // 
            // groupNations
            // 
            this.groupNations.Controls.Add(this.CBCountry11);
            this.groupNations.Controls.Add(this.CBCountry10);
            this.groupNations.Controls.Add(this.CBCountry9);
            this.groupNations.Controls.Add(this.CBCountry8);
            this.groupNations.Controls.Add(this.CBCountry7);
            this.groupNations.Controls.Add(this.CBCountry6);
            this.groupNations.Controls.Add(this.CBCountry5);
            this.groupNations.Controls.Add(this.CBCountry4);
            this.groupNations.Controls.Add(this.CBCountry3);
            this.groupNations.Controls.Add(this.CBCountry2);
            this.groupNations.Controls.Add(this.CBCountry1);
            this.groupNations.Location = new System.Drawing.Point(437, 12);
            this.groupNations.Name = "groupNations";
            this.groupNations.Size = new System.Drawing.Size(214, 292);
            this.groupNations.TabIndex = 39;
            this.groupNations.TabStop = false;
            this.groupNations.Text = "Nation";
            // 
            // CBCountry11
            // 
            this.CBCountry11.AutoSize = true;
            this.CBCountry11.Location = new System.Drawing.Point(27, 259);
            this.CBCountry11.Name = "CBCountry11";
            this.CBCountry11.Size = new System.Drawing.Size(97, 17);
            this.CBCountry11.TabIndex = 22;
            this.CBCountry11.Tag = "ussr";
            this.CBCountry11.Text = "USSR - Russia";
            this.CBCountry11.UseVisualStyleBackColor = true;
            // 
            // CBCountry10
            // 
            this.CBCountry10.AutoSize = true;
            this.CBCountry10.Location = new System.Drawing.Point(27, 235);
            this.CBCountry10.Name = "CBCountry10";
            this.CBCountry10.Size = new System.Drawing.Size(79, 17);
            this.CBCountry10.TabIndex = 21;
            this.CBCountry10.Tag = "usa";
            this.CBCountry10.Text = "USA - USA";
            this.CBCountry10.UseVisualStyleBackColor = true;
            // 
            // CBCountry9
            // 
            this.CBCountry9.AutoSize = true;
            this.CBCountry9.Location = new System.Drawing.Point(27, 211);
            this.CBCountry9.Name = "CBCountry9";
            this.CBCountry9.Size = new System.Drawing.Size(125, 17);
            this.CBCountry9.TabIndex = 20;
            this.CBCountry9.Tag = "uk";
            this.CBCountry9.Text = "UK - United Kingdom";
            this.CBCountry9.UseVisualStyleBackColor = true;
            // 
            // CBCountry8
            // 
            this.CBCountry8.AutoSize = true;
            this.CBCountry8.Location = new System.Drawing.Point(27, 187);
            this.CBCountry8.Name = "CBCountry8";
            this.CBCountry8.Size = new System.Drawing.Size(117, 17);
            this.CBCountry8.TabIndex = 19;
            this.CBCountry8.Tag = "pan_america";
            this.CBCountry8.Text = "PAN - Pan-America";
            this.CBCountry8.UseVisualStyleBackColor = true;
            // 
            // CBCountry7
            // 
            this.CBCountry7.AutoSize = true;
            this.CBCountry7.Location = new System.Drawing.Point(27, 163);
            this.CBCountry7.Name = "CBCountry7";
            this.CBCountry7.Size = new System.Drawing.Size(98, 17);
            this.CBCountry7.TabIndex = 18;
            this.CBCountry7.Tag = "pan_asia";
            this.CBCountry7.Text = "PAA - Pan-Asia";
            this.CBCountry7.UseVisualStyleBackColor = true;
            // 
            // CBCountry6
            // 
            this.CBCountry6.AutoSize = true;
            this.CBCountry6.Location = new System.Drawing.Point(27, 139);
            this.CBCountry6.Name = "CBCountry6";
            this.CBCountry6.Size = new System.Drawing.Size(71, 17);
            this.CBCountry6.TabIndex = 17;
            this.CBCountry6.Tag = "italy";
            this.CBCountry6.Text = "ITA - Italy";
            this.CBCountry6.UseVisualStyleBackColor = true;
            // 
            // CBCountry5
            // 
            this.CBCountry5.AutoSize = true;
            this.CBCountry5.Location = new System.Drawing.Point(27, 115);
            this.CBCountry5.Name = "CBCountry5";
            this.CBCountry5.Size = new System.Drawing.Size(80, 17);
            this.CBCountry5.TabIndex = 16;
            this.CBCountry5.Tag = "japan";
            this.CBCountry5.Text = "IJN - Japan";
            this.CBCountry5.UseVisualStyleBackColor = true;
            // 
            // CBCountry4
            // 
            this.CBCountry4.AutoSize = true;
            this.CBCountry4.Location = new System.Drawing.Point(27, 91);
            this.CBCountry4.Name = "CBCountry4";
            this.CBCountry4.Size = new System.Drawing.Size(100, 17);
            this.CBCountry4.TabIndex = 15;
            this.CBCountry4.Tag = "germany";
            this.CBCountry4.Text = "GER - Germany";
            this.CBCountry4.UseVisualStyleBackColor = true;
            // 
            // CBCountry3
            // 
            this.CBCountry3.AutoSize = true;
            this.CBCountry3.Location = new System.Drawing.Point(27, 67);
            this.CBCountry3.Name = "CBCountry3";
            this.CBCountry3.Size = new System.Drawing.Size(89, 17);
            this.CBCountry3.TabIndex = 14;
            this.CBCountry3.Tag = "france";
            this.CBCountry3.Text = "FRA - France";
            this.CBCountry3.UseVisualStyleBackColor = true;
            // 
            // CBCountry2
            // 
            this.CBCountry2.AutoSize = true;
            this.CBCountry2.Location = new System.Drawing.Point(27, 43);
            this.CBCountry2.Name = "CBCountry2";
            this.CBCountry2.Size = new System.Drawing.Size(92, 17);
            this.CBCountry2.TabIndex = 13;
            this.CBCountry2.Tag = "europe";
            this.CBCountry2.Text = "EUR - Europe";
            this.CBCountry2.UseVisualStyleBackColor = true;
            // 
            // CBCountry1
            // 
            this.CBCountry1.AutoSize = true;
            this.CBCountry1.Location = new System.Drawing.Point(27, 19);
            this.CBCountry1.Name = "CBCountry1";
            this.CBCountry1.Size = new System.Drawing.Size(125, 17);
            this.CBCountry1.TabIndex = 12;
            this.CBCountry1.Tag = "commonwealth";
            this.CBCountry1.Text = "CW - Commonwealth";
            this.CBCountry1.UseVisualStyleBackColor = true;
            // 
            // groupQuery
            // 
            this.groupQuery.Controls.Add(this.listQuery);
            this.groupQuery.Location = new System.Drawing.Point(231, 164);
            this.groupQuery.Name = "groupQuery";
            this.groupQuery.Size = new System.Drawing.Size(200, 124);
            this.groupQuery.TabIndex = 40;
            this.groupQuery.TabStop = false;
            this.groupQuery.Text = "Selection query";
            // 
            // listQuery
            // 
            this.listQuery.BackColor = System.Drawing.SystemColors.Control;
            this.listQuery.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listQuery.FormattingEnabled = true;
            this.listQuery.Location = new System.Drawing.Point(7, 20);
            this.listQuery.Name = "listQuery";
            this.listQuery.Size = new System.Drawing.Size(187, 91);
            this.listQuery.TabIndex = 0;
            // 
            // btnAddQuery
            // 
            this.btnAddQuery.Location = new System.Drawing.Point(231, 294);
            this.btnAddQuery.Name = "btnAddQuery";
            this.btnAddQuery.Size = new System.Drawing.Size(93, 23);
            this.btnAddQuery.TabIndex = 41;
            this.btnAddQuery.Text = "Add Query";
            this.btnAddQuery.UseVisualStyleBackColor = true;
            this.btnAddQuery.Click += new System.EventHandler(this.btnAddQuery_Click);
            // 
            // btnRemoveQuery
            // 
            this.btnRemoveQuery.Location = new System.Drawing.Point(338, 294);
            this.btnRemoveQuery.Name = "btnRemoveQuery";
            this.btnRemoveQuery.Size = new System.Drawing.Size(93, 22);
            this.btnRemoveQuery.TabIndex = 42;
            this.btnRemoveQuery.Text = "Remove Query";
            this.btnRemoveQuery.UseVisualStyleBackColor = true;
            this.btnRemoveQuery.Click += new System.EventHandler(this.btnRemoveQuery_Click);
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Location = new System.Drawing.Point(13, 307);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(101, 13);
            this.lblRecordCount.TabIndex = 43;
            this.lblRecordCount.Text = "0 records displayed.";
            // 
            // List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 702);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.btnRemoveQuery);
            this.Controls.Add(this.btnAddQuery);
            this.Controls.Add(this.groupQuery);
            this.Controls.Add(this.groupNations);
            this.Controls.Add(this.cbTechTree);
            this.Controls.Add(this.cbPremium);
            this.Controls.Add(this.groupTier);
            this.Controls.Add(this.groupShipClass);
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
            this.groupShipClass.ResumeLayout(false);
            this.groupShipClass.PerformLayout();
            this.groupTier.ResumeLayout(false);
            this.groupTier.PerformLayout();
            this.groupNations.ResumeLayout(false);
            this.groupNations.PerformLayout();
            this.groupQuery.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupShipClass;
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
        private System.Windows.Forms.GroupBox groupTier;
        private System.Windows.Forms.CheckBox cbPremium;
        private System.Windows.Forms.CheckBox cbTechTree;
        private System.Windows.Forms.GroupBox groupNations;
        private System.Windows.Forms.CheckBox CBCountry11;
        private System.Windows.Forms.CheckBox CBCountry10;
        private System.Windows.Forms.CheckBox CBCountry9;
        private System.Windows.Forms.CheckBox CBCountry8;
        private System.Windows.Forms.CheckBox CBCountry7;
        private System.Windows.Forms.CheckBox CBCountry6;
        private System.Windows.Forms.CheckBox CBCountry5;
        private System.Windows.Forms.CheckBox CBCountry4;
        private System.Windows.Forms.CheckBox CBCountry3;
        private System.Windows.Forms.CheckBox CBCountry2;
        private System.Windows.Forms.CheckBox CBCountry1;
        private System.Windows.Forms.GroupBox groupQuery;
        private System.Windows.Forms.ListBox listQuery;
        private System.Windows.Forms.Button btnAddQuery;
        private System.Windows.Forms.Button btnRemoveQuery;
        private System.Windows.Forms.Label lblRecordCount;
    }
}