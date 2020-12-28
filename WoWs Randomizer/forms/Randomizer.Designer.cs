using System.Collections.Generic;
using WoWs_Randomizer.utils.ship;

namespace WoWs_Randomizer
{
    

    partial class FormRandomizer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private List<Ship> MyShips { get; set; }

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRandomizer));
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.CBPremium = new System.Windows.Forms.CheckBox();
            this.CBNonPremium = new System.Windows.Forms.CheckBox();
            this.lblQueue = new System.Windows.Forms.Label();
            this.lblExcludedShips = new System.Windows.Forms.Label();
            this.lblShipsInPort = new System.Windows.Forms.Label();
            this.cbSingleSelect = new System.Windows.Forms.CheckBox();
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
            this.CBShipclass4 = new System.Windows.Forms.CheckBox();
            this.CBShipclass2 = new System.Windows.Forms.CheckBox();
            this.CBShipclass3 = new System.Windows.Forms.CheckBox();
            this.CBShipclass1 = new System.Windows.Forms.CheckBox();
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
            this.RandomizeButton = new System.Windows.Forms.Button();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMyShipsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exclusionListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfShipsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfModulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myShipsInPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shipComparisonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upgradesExaminerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProfileEU = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProfileNA = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProfileRU = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.installUpgradeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomizerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildManagerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.shipCompareToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.changeLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RightPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ShipMetricsTable = new System.Windows.Forms.TableLayoutPanel();
            this.ResultBox = new System.Windows.Forms.GroupBox();
            this.NoShipFoundHelpMsg = new System.Windows.Forms.Label();
            this.shipDescription = new System.Windows.Forms.Label();
            this.NoShipFoundMsg = new System.Windows.Forms.Label();
            this.BtnBuildMgr = new System.Windows.Forms.Button();
            this.BtnRecommendedBuild = new System.Windows.Forms.Button();
            this.ShipName = new System.Windows.Forms.Label();
            this.FlagImage = new System.Windows.Forms.PictureBox();
            this.ShipImage = new System.Windows.Forms.PictureBox();
            this.BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.LoadingImage = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.BGUpdater = new System.ComponentModel.BackgroundWorker();
            this.UpgradeFixer = new System.ComponentModel.BackgroundWorker();
            this.LeftPanel.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.RightPanel.SuspendLayout();
            this.ResultBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlagImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingImage)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LeftPanel
            // 
            this.LeftPanel.Controls.Add(this.CBPremium);
            this.LeftPanel.Controls.Add(this.CBNonPremium);
            this.LeftPanel.Controls.Add(this.lblQueue);
            this.LeftPanel.Controls.Add(this.lblExcludedShips);
            this.LeftPanel.Controls.Add(this.lblShipsInPort);
            this.LeftPanel.Controls.Add(this.cbSingleSelect);
            this.LeftPanel.Controls.Add(this.CBTier10);
            this.LeftPanel.Controls.Add(this.CBTier9);
            this.LeftPanel.Controls.Add(this.CBTier8);
            this.LeftPanel.Controls.Add(this.CBTier7);
            this.LeftPanel.Controls.Add(this.CBTier6);
            this.LeftPanel.Controls.Add(this.CBTier5);
            this.LeftPanel.Controls.Add(this.CBTier4);
            this.LeftPanel.Controls.Add(this.CBTier3);
            this.LeftPanel.Controls.Add(this.CBTier2);
            this.LeftPanel.Controls.Add(this.CBTier1);
            this.LeftPanel.Controls.Add(this.CBShipclass4);
            this.LeftPanel.Controls.Add(this.CBShipclass2);
            this.LeftPanel.Controls.Add(this.CBShipclass3);
            this.LeftPanel.Controls.Add(this.CBShipclass1);
            this.LeftPanel.Controls.Add(this.CBCountry11);
            this.LeftPanel.Controls.Add(this.CBCountry10);
            this.LeftPanel.Controls.Add(this.CBCountry9);
            this.LeftPanel.Controls.Add(this.CBCountry8);
            this.LeftPanel.Controls.Add(this.CBCountry7);
            this.LeftPanel.Controls.Add(this.CBCountry6);
            this.LeftPanel.Controls.Add(this.CBCountry5);
            this.LeftPanel.Controls.Add(this.CBCountry4);
            this.LeftPanel.Controls.Add(this.CBCountry3);
            this.LeftPanel.Controls.Add(this.CBCountry2);
            this.LeftPanel.Controls.Add(this.CBCountry1);
            this.LeftPanel.Controls.Add(this.RandomizeButton);
            this.LeftPanel.Location = new System.Drawing.Point(4, 27);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(200, 822);
            this.LeftPanel.TabIndex = 0;
            // 
            // CBPremium
            // 
            this.CBPremium.AutoSize = true;
            this.CBPremium.Location = new System.Drawing.Point(112, 546);
            this.CBPremium.Name = "CBPremium";
            this.CBPremium.Size = new System.Drawing.Size(66, 17);
            this.CBPremium.TabIndex = 31;
            this.CBPremium.Tag = "Premium";
            this.CBPremium.Text = "Premium";
            this.CBPremium.UseVisualStyleBackColor = true;
            // 
            // CBNonPremium
            // 
            this.CBNonPremium.AutoSize = true;
            this.CBNonPremium.Location = new System.Drawing.Point(19, 546);
            this.CBNonPremium.Name = "CBNonPremium";
            this.CBNonPremium.Size = new System.Drawing.Size(72, 17);
            this.CBNonPremium.TabIndex = 30;
            this.CBNonPremium.Tag = "Techtree";
            this.CBNonPremium.Text = "Tech tree";
            this.CBNonPremium.UseVisualStyleBackColor = true;
            // 
            // lblQueue
            // 
            this.lblQueue.AutoSize = true;
            this.lblQueue.Location = new System.Drawing.Point(19, 615);
            this.lblQueue.Name = "lblQueue";
            this.lblQueue.Size = new System.Drawing.Size(10, 13);
            this.lblQueue.TabIndex = 29;
            this.lblQueue.Text = ".";
            // 
            // lblExcludedShips
            // 
            this.lblExcludedShips.AutoSize = true;
            this.lblExcludedShips.Location = new System.Drawing.Point(19, 673);
            this.lblExcludedShips.Name = "lblExcludedShips";
            this.lblExcludedShips.Size = new System.Drawing.Size(10, 13);
            this.lblExcludedShips.TabIndex = 28;
            this.lblExcludedShips.Text = ".";
            // 
            // lblShipsInPort
            // 
            this.lblShipsInPort.AutoSize = true;
            this.lblShipsInPort.Location = new System.Drawing.Point(19, 644);
            this.lblShipsInPort.Name = "lblShipsInPort";
            this.lblShipsInPort.Size = new System.Drawing.Size(10, 13);
            this.lblShipsInPort.TabIndex = 27;
            this.lblShipsInPort.Text = ".";
            // 
            // cbSingleSelect
            // 
            this.cbSingleSelect.AutoSize = true;
            this.cbSingleSelect.Location = new System.Drawing.Point(19, 578);
            this.cbSingleSelect.Name = "cbSingleSelect";
            this.cbSingleSelect.Size = new System.Drawing.Size(133, 17);
            this.cbSingleSelect.TabIndex = 26;
            this.cbSingleSelect.Text = "Unique Randomization";
            this.cbSingleSelect.UseVisualStyleBackColor = true;
            this.cbSingleSelect.CheckedChanged += new System.EventHandler(this.cbSingleSelect_CheckedChanged);
            // 
            // CBTier10
            // 
            this.CBTier10.AutoSize = true;
            this.CBTier10.Location = new System.Drawing.Point(112, 510);
            this.CBTier10.Name = "CBTier10";
            this.CBTier10.Size = new System.Drawing.Size(59, 17);
            this.CBTier10.TabIndex = 25;
            this.CBTier10.Tag = "10";
            this.CBTier10.Text = "Tier 10";
            this.CBTier10.UseVisualStyleBackColor = true;
            // 
            // CBTier9
            // 
            this.CBTier9.AutoSize = true;
            this.CBTier9.Location = new System.Drawing.Point(112, 487);
            this.CBTier9.Name = "CBTier9";
            this.CBTier9.Size = new System.Drawing.Size(53, 17);
            this.CBTier9.TabIndex = 24;
            this.CBTier9.Tag = "9";
            this.CBTier9.Text = "Tier 9";
            this.CBTier9.UseVisualStyleBackColor = true;
            // 
            // CBTier8
            // 
            this.CBTier8.AutoSize = true;
            this.CBTier8.Location = new System.Drawing.Point(112, 463);
            this.CBTier8.Name = "CBTier8";
            this.CBTier8.Size = new System.Drawing.Size(53, 17);
            this.CBTier8.TabIndex = 23;
            this.CBTier8.Tag = "8";
            this.CBTier8.Text = "Tier 8";
            this.CBTier8.UseVisualStyleBackColor = true;
            // 
            // CBTier7
            // 
            this.CBTier7.AutoSize = true;
            this.CBTier7.Location = new System.Drawing.Point(112, 439);
            this.CBTier7.Name = "CBTier7";
            this.CBTier7.Size = new System.Drawing.Size(53, 17);
            this.CBTier7.TabIndex = 22;
            this.CBTier7.Tag = "7";
            this.CBTier7.Text = "Tier 7";
            this.CBTier7.UseVisualStyleBackColor = true;
            // 
            // CBTier6
            // 
            this.CBTier6.AutoSize = true;
            this.CBTier6.Location = new System.Drawing.Point(112, 415);
            this.CBTier6.Name = "CBTier6";
            this.CBTier6.Size = new System.Drawing.Size(53, 17);
            this.CBTier6.TabIndex = 21;
            this.CBTier6.Tag = "6";
            this.CBTier6.Text = "Tier 6";
            this.CBTier6.UseVisualStyleBackColor = true;
            // 
            // CBTier5
            // 
            this.CBTier5.AutoSize = true;
            this.CBTier5.Location = new System.Drawing.Point(19, 510);
            this.CBTier5.Name = "CBTier5";
            this.CBTier5.Size = new System.Drawing.Size(53, 17);
            this.CBTier5.TabIndex = 20;
            this.CBTier5.Tag = "5";
            this.CBTier5.Text = "Tier 5";
            this.CBTier5.UseVisualStyleBackColor = true;
            // 
            // CBTier4
            // 
            this.CBTier4.AutoSize = true;
            this.CBTier4.Location = new System.Drawing.Point(19, 487);
            this.CBTier4.Name = "CBTier4";
            this.CBTier4.Size = new System.Drawing.Size(53, 17);
            this.CBTier4.TabIndex = 19;
            this.CBTier4.Tag = "4";
            this.CBTier4.Text = "Tier 4";
            this.CBTier4.UseVisualStyleBackColor = true;
            // 
            // CBTier3
            // 
            this.CBTier3.AutoSize = true;
            this.CBTier3.Location = new System.Drawing.Point(19, 463);
            this.CBTier3.Name = "CBTier3";
            this.CBTier3.Size = new System.Drawing.Size(53, 17);
            this.CBTier3.TabIndex = 18;
            this.CBTier3.Tag = "3";
            this.CBTier3.Text = "Tier 3";
            this.CBTier3.UseVisualStyleBackColor = true;
            // 
            // CBTier2
            // 
            this.CBTier2.AutoSize = true;
            this.CBTier2.Location = new System.Drawing.Point(19, 439);
            this.CBTier2.Name = "CBTier2";
            this.CBTier2.Size = new System.Drawing.Size(53, 17);
            this.CBTier2.TabIndex = 17;
            this.CBTier2.Tag = "2";
            this.CBTier2.Text = "Tier 2";
            this.CBTier2.UseVisualStyleBackColor = true;
            // 
            // CBTier1
            // 
            this.CBTier1.AutoSize = true;
            this.CBTier1.Location = new System.Drawing.Point(19, 415);
            this.CBTier1.Name = "CBTier1";
            this.CBTier1.Size = new System.Drawing.Size(53, 17);
            this.CBTier1.TabIndex = 16;
            this.CBTier1.Tag = "1";
            this.CBTier1.Text = "Tier 1";
            this.CBTier1.UseVisualStyleBackColor = true;
            // 
            // CBShipclass4
            // 
            this.CBShipclass4.AutoSize = true;
            this.CBShipclass4.Location = new System.Drawing.Point(112, 373);
            this.CBShipclass4.Name = "CBShipclass4";
            this.CBShipclass4.Size = new System.Drawing.Size(56, 17);
            this.CBShipclass4.TabIndex = 15;
            this.CBShipclass4.Tag = "carrier";
            this.CBShipclass4.Text = "Carrier";
            this.CBShipclass4.UseVisualStyleBackColor = true;
            // 
            // CBShipclass2
            // 
            this.CBShipclass2.AutoSize = true;
            this.CBShipclass2.Location = new System.Drawing.Point(112, 349);
            this.CBShipclass2.Name = "CBShipclass2";
            this.CBShipclass2.Size = new System.Drawing.Size(58, 17);
            this.CBShipclass2.TabIndex = 14;
            this.CBShipclass2.Tag = "cruiser";
            this.CBShipclass2.Text = "Cruiser";
            this.CBShipclass2.UseVisualStyleBackColor = true;
            // 
            // CBShipclass3
            // 
            this.CBShipclass3.AutoSize = true;
            this.CBShipclass3.Location = new System.Drawing.Point(19, 373);
            this.CBShipclass3.Name = "CBShipclass3";
            this.CBShipclass3.Size = new System.Drawing.Size(72, 17);
            this.CBShipclass3.TabIndex = 13;
            this.CBShipclass3.Tag = "battleship";
            this.CBShipclass3.Text = "Battleship";
            this.CBShipclass3.UseVisualStyleBackColor = true;
            // 
            // CBShipclass1
            // 
            this.CBShipclass1.AutoSize = true;
            this.CBShipclass1.Location = new System.Drawing.Point(19, 349);
            this.CBShipclass1.Name = "CBShipclass1";
            this.CBShipclass1.Size = new System.Drawing.Size(71, 17);
            this.CBShipclass1.TabIndex = 12;
            this.CBShipclass1.Tag = "destroyer";
            this.CBShipclass1.Text = "Destroyer";
            this.CBShipclass1.UseVisualStyleBackColor = true;
            // 
            // CBCountry11
            // 
            this.CBCountry11.AutoSize = true;
            this.CBCountry11.Location = new System.Drawing.Point(19, 304);
            this.CBCountry11.Name = "CBCountry11";
            this.CBCountry11.Size = new System.Drawing.Size(97, 17);
            this.CBCountry11.TabIndex = 11;
            this.CBCountry11.Tag = "ussr";
            this.CBCountry11.Text = "USSR - Russia";
            this.CBCountry11.UseVisualStyleBackColor = true;
            // 
            // CBCountry10
            // 
            this.CBCountry10.AutoSize = true;
            this.CBCountry10.Location = new System.Drawing.Point(19, 280);
            this.CBCountry10.Name = "CBCountry10";
            this.CBCountry10.Size = new System.Drawing.Size(79, 17);
            this.CBCountry10.TabIndex = 10;
            this.CBCountry10.Tag = "usa";
            this.CBCountry10.Text = "USA - USA";
            this.CBCountry10.UseVisualStyleBackColor = true;
            // 
            // CBCountry9
            // 
            this.CBCountry9.AutoSize = true;
            this.CBCountry9.Location = new System.Drawing.Point(19, 256);
            this.CBCountry9.Name = "CBCountry9";
            this.CBCountry9.Size = new System.Drawing.Size(125, 17);
            this.CBCountry9.TabIndex = 9;
            this.CBCountry9.Tag = "uk";
            this.CBCountry9.Text = "UK - United Kingdom";
            this.CBCountry9.UseVisualStyleBackColor = true;
            // 
            // CBCountry8
            // 
            this.CBCountry8.AutoSize = true;
            this.CBCountry8.Location = new System.Drawing.Point(19, 232);
            this.CBCountry8.Name = "CBCountry8";
            this.CBCountry8.Size = new System.Drawing.Size(117, 17);
            this.CBCountry8.TabIndex = 8;
            this.CBCountry8.Tag = "pan_america";
            this.CBCountry8.Text = "PAN - Pan-America";
            this.CBCountry8.UseVisualStyleBackColor = true;
            // 
            // CBCountry7
            // 
            this.CBCountry7.AutoSize = true;
            this.CBCountry7.Location = new System.Drawing.Point(19, 208);
            this.CBCountry7.Name = "CBCountry7";
            this.CBCountry7.Size = new System.Drawing.Size(98, 17);
            this.CBCountry7.TabIndex = 7;
            this.CBCountry7.Tag = "pan_asia";
            this.CBCountry7.Text = "PAA - Pan-Asia";
            this.CBCountry7.UseVisualStyleBackColor = true;
            // 
            // CBCountry6
            // 
            this.CBCountry6.AutoSize = true;
            this.CBCountry6.Location = new System.Drawing.Point(19, 184);
            this.CBCountry6.Name = "CBCountry6";
            this.CBCountry6.Size = new System.Drawing.Size(71, 17);
            this.CBCountry6.TabIndex = 6;
            this.CBCountry6.Tag = "italy";
            this.CBCountry6.Text = "ITA - Italy";
            this.CBCountry6.UseVisualStyleBackColor = true;
            // 
            // CBCountry5
            // 
            this.CBCountry5.AutoSize = true;
            this.CBCountry5.Location = new System.Drawing.Point(19, 160);
            this.CBCountry5.Name = "CBCountry5";
            this.CBCountry5.Size = new System.Drawing.Size(80, 17);
            this.CBCountry5.TabIndex = 5;
            this.CBCountry5.Tag = "japan";
            this.CBCountry5.Text = "IJN - Japan";
            this.CBCountry5.UseVisualStyleBackColor = true;
            // 
            // CBCountry4
            // 
            this.CBCountry4.AutoSize = true;
            this.CBCountry4.Location = new System.Drawing.Point(19, 136);
            this.CBCountry4.Name = "CBCountry4";
            this.CBCountry4.Size = new System.Drawing.Size(100, 17);
            this.CBCountry4.TabIndex = 4;
            this.CBCountry4.Tag = "germany";
            this.CBCountry4.Text = "GER - Germany";
            this.CBCountry4.UseVisualStyleBackColor = true;
            // 
            // CBCountry3
            // 
            this.CBCountry3.AutoSize = true;
            this.CBCountry3.Location = new System.Drawing.Point(19, 112);
            this.CBCountry3.Name = "CBCountry3";
            this.CBCountry3.Size = new System.Drawing.Size(89, 17);
            this.CBCountry3.TabIndex = 3;
            this.CBCountry3.Tag = "france";
            this.CBCountry3.Text = "FRA - France";
            this.CBCountry3.UseVisualStyleBackColor = true;
            // 
            // CBCountry2
            // 
            this.CBCountry2.AutoSize = true;
            this.CBCountry2.Location = new System.Drawing.Point(19, 88);
            this.CBCountry2.Name = "CBCountry2";
            this.CBCountry2.Size = new System.Drawing.Size(92, 17);
            this.CBCountry2.TabIndex = 2;
            this.CBCountry2.Tag = "europe";
            this.CBCountry2.Text = "EUR - Europe";
            this.CBCountry2.UseVisualStyleBackColor = true;
            // 
            // CBCountry1
            // 
            this.CBCountry1.AutoSize = true;
            this.CBCountry1.Location = new System.Drawing.Point(19, 64);
            this.CBCountry1.Name = "CBCountry1";
            this.CBCountry1.Size = new System.Drawing.Size(125, 17);
            this.CBCountry1.TabIndex = 1;
            this.CBCountry1.Tag = "commonwealth";
            this.CBCountry1.Text = "CW - Commonwealth";
            this.CBCountry1.UseVisualStyleBackColor = true;
            // 
            // RandomizeButton
            // 
            this.RandomizeButton.Location = new System.Drawing.Point(19, 20);
            this.RandomizeButton.Name = "RandomizeButton";
            this.RandomizeButton.Size = new System.Drawing.Size(161, 23);
            this.RandomizeButton.TabIndex = 0;
            this.RandomizeButton.Text = "Randomize";
            this.RandomizeButton.UseVisualStyleBackColor = true;
            this.RandomizeButton.Click += new System.EventHandler(this.RandomizeButton_Click);
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.profilesToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(850, 24);
            this.MenuStrip.TabIndex = 1;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadMyShipsToolStripMenuItem,
            this.exclusionListToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exportToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // loadMyShipsToolStripMenuItem
            // 
            this.loadMyShipsToolStripMenuItem.Name = "loadMyShipsToolStripMenuItem";
            this.loadMyShipsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.loadMyShipsToolStripMenuItem.Text = "&Load my ships...";
            this.loadMyShipsToolStripMenuItem.Click += new System.EventHandler(this.LoadMyShipsToolStripMenuItem_ClickAsync);
            // 
            // exclusionListToolStripMenuItem
            // 
            this.exclusionListToolStripMenuItem.Name = "exclusionListToolStripMenuItem";
            this.exclusionListToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.exclusionListToolStripMenuItem.Text = "&Exclusion List";
            this.exclusionListToolStripMenuItem.Click += new System.EventHandler(this.ExclusionListToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.settingsToolStripMenuItem.Text = "&Settings...";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(156, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listOfShipsToolStripMenuItem,
            this.listOfModulesToolStripMenuItem,
            this.myShipsInPortToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.exportToolStripMenuItem.Text = "Ex&port...";
            // 
            // listOfShipsToolStripMenuItem
            // 
            this.listOfShipsToolStripMenuItem.Name = "listOfShipsToolStripMenuItem";
            this.listOfShipsToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.listOfShipsToolStripMenuItem.Text = "List of &Ships";
            this.listOfShipsToolStripMenuItem.Click += new System.EventHandler(this.listOfShipsToolStripMenuItem_Click);
            // 
            // listOfModulesToolStripMenuItem
            // 
            this.listOfModulesToolStripMenuItem.Name = "listOfModulesToolStripMenuItem";
            this.listOfModulesToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.listOfModulesToolStripMenuItem.Text = "List of &Modules";
            this.listOfModulesToolStripMenuItem.Click += new System.EventHandler(this.listOfModulesToolStripMenuItem_Click);
            // 
            // myShipsInPortToolStripMenuItem
            // 
            this.myShipsInPortToolStripMenuItem.Name = "myShipsInPortToolStripMenuItem";
            this.myShipsInPortToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.myShipsInPortToolStripMenuItem.Text = "&My Ships in port";
            this.myShipsInPortToolStripMenuItem.Click += new System.EventHandler(this.myShipsInPortToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(156, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildManagerToolStripMenuItem,
            this.shipComparisonToolStripMenuItem,
            this.upgradesExaminerToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // buildManagerToolStripMenuItem
            // 
            this.buildManagerToolStripMenuItem.Enabled = false;
            this.buildManagerToolStripMenuItem.Name = "buildManagerToolStripMenuItem";
            this.buildManagerToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.buildManagerToolStripMenuItem.Text = "&Build Manager";
            this.buildManagerToolStripMenuItem.Click += new System.EventHandler(this.buildManagerToolStripMenuItem_Click);
            // 
            // shipComparisonToolStripMenuItem
            // 
            this.shipComparisonToolStripMenuItem.Name = "shipComparisonToolStripMenuItem";
            this.shipComparisonToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.shipComparisonToolStripMenuItem.Text = "Ship &Comparison";
            this.shipComparisonToolStripMenuItem.Click += new System.EventHandler(this.ShipComparisonToolStripMenuItem_Click);
            // 
            // upgradesExaminerToolStripMenuItem
            // 
            this.upgradesExaminerToolStripMenuItem.Name = "upgradesExaminerToolStripMenuItem";
            this.upgradesExaminerToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.upgradesExaminerToolStripMenuItem.Text = "Ship &Wikipedia";
            this.upgradesExaminerToolStripMenuItem.Click += new System.EventHandler(this.upgradesExaminerToolStripMenuItem_Click);
            // 
            // profilesToolStripMenuItem
            // 
            this.profilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuProfileEU,
            this.menuProfileNA,
            this.menuProfileRU});
            this.profilesToolStripMenuItem.Name = "profilesToolStripMenuItem";
            this.profilesToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.profilesToolStripMenuItem.Text = "&Profiles";
            // 
            // menuProfileEU
            // 
            this.menuProfileEU.Checked = true;
            this.menuProfileEU.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuProfileEU.Name = "menuProfileEU";
            this.menuProfileEU.Size = new System.Drawing.Size(91, 22);
            this.menuProfileEU.Text = "&EU";
            this.menuProfileEU.Click += new System.EventHandler(this.menuProfile_Click);
            // 
            // menuProfileNA
            // 
            this.menuProfileNA.Name = "menuProfileNA";
            this.menuProfileNA.Size = new System.Drawing.Size(91, 22);
            this.menuProfileNA.Text = "&NA";
            this.menuProfileNA.Click += new System.EventHandler(this.menuProfile_Click);
            // 
            // menuProfileRU
            // 
            this.menuProfileRU.Name = "menuProfileRU";
            this.menuProfileRU.Size = new System.Drawing.Size(91, 22);
            this.menuProfileRU.Text = "&RU";
            this.menuProfileRU.Click += new System.EventHandler(this.menuProfile_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.installUpgradeToolStripMenuItem,
            this.randomizerToolStripMenuItem,
            this.buildManagerToolStripMenuItem1,
            this.shipCompareToolToolStripMenuItem,
            this.toolStripSeparator2,
            this.changeLogToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // installUpgradeToolStripMenuItem
            // 
            this.installUpgradeToolStripMenuItem.Name = "installUpgradeToolStripMenuItem";
            this.installUpgradeToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.installUpgradeToolStripMenuItem.Text = "&Install && Upgrade";
            this.installUpgradeToolStripMenuItem.Click += new System.EventHandler(this.installUpgradeToolStripMenuItem_Click);
            // 
            // randomizerToolStripMenuItem
            // 
            this.randomizerToolStripMenuItem.Name = "randomizerToolStripMenuItem";
            this.randomizerToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.randomizerToolStripMenuItem.Text = "&Randomizer";
            this.randomizerToolStripMenuItem.Click += new System.EventHandler(this.randomizerToolStripMenuItem_Click);
            // 
            // buildManagerToolStripMenuItem1
            // 
            this.buildManagerToolStripMenuItem1.Name = "buildManagerToolStripMenuItem1";
            this.buildManagerToolStripMenuItem1.Size = new System.Drawing.Size(174, 22);
            this.buildManagerToolStripMenuItem1.Text = "&Build Manager";
            this.buildManagerToolStripMenuItem1.Click += new System.EventHandler(this.buildManagerToolStripMenuItem1_Click);
            // 
            // shipCompareToolToolStripMenuItem
            // 
            this.shipCompareToolToolStripMenuItem.Name = "shipCompareToolToolStripMenuItem";
            this.shipCompareToolToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.shipCompareToolToolStripMenuItem.Text = "&Ship Compare Tool";
            this.shipCompareToolToolStripMenuItem.Click += new System.EventHandler(this.shipCompareToolToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(171, 6);
            // 
            // changeLogToolStripMenuItem
            // 
            this.changeLogToolStripMenuItem.Name = "changeLogToolStripMenuItem";
            this.changeLogToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.changeLogToolStripMenuItem.Text = "&Change Log...";
            this.changeLogToolStripMenuItem.Click += new System.EventHandler(this.changeLogToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // RightPanel
            // 
            this.RightPanel.Controls.Add(this.label1);
            this.RightPanel.Controls.Add(this.ShipMetricsTable);
            this.RightPanel.Location = new System.Drawing.Point(615, 27);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(228, 825);
            this.RightPanel.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ship Metrics";
            // 
            // ShipMetricsTable
            // 
            this.ShipMetricsTable.ColumnCount = 2;
            this.ShipMetricsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.ShipMetricsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.ShipMetricsTable.Location = new System.Drawing.Point(6, 27);
            this.ShipMetricsTable.Name = "ShipMetricsTable";
            this.ShipMetricsTable.RowCount = 1;
            this.ShipMetricsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 795F));
            this.ShipMetricsTable.Size = new System.Drawing.Size(219, 795);
            this.ShipMetricsTable.TabIndex = 0;
            // 
            // ResultBox
            // 
            this.ResultBox.Controls.Add(this.NoShipFoundHelpMsg);
            this.ResultBox.Controls.Add(this.shipDescription);
            this.ResultBox.Controls.Add(this.NoShipFoundMsg);
            this.ResultBox.Controls.Add(this.BtnBuildMgr);
            this.ResultBox.Controls.Add(this.BtnRecommendedBuild);
            this.ResultBox.Controls.Add(this.ShipName);
            this.ResultBox.Controls.Add(this.FlagImage);
            this.ResultBox.Controls.Add(this.ShipImage);
            this.ResultBox.Location = new System.Drawing.Point(210, 27);
            this.ResultBox.Name = "ResultBox";
            this.ResultBox.Size = new System.Drawing.Size(399, 504);
            this.ResultBox.TabIndex = 4;
            this.ResultBox.TabStop = false;
            this.ResultBox.Text = "Result";
            // 
            // NoShipFoundHelpMsg
            // 
            this.NoShipFoundHelpMsg.Location = new System.Drawing.Point(11, 187);
            this.NoShipFoundHelpMsg.Name = "NoShipFoundHelpMsg";
            this.NoShipFoundHelpMsg.Size = new System.Drawing.Size(370, 47);
            this.NoShipFoundHelpMsg.TabIndex = 10;
            this.NoShipFoundHelpMsg.Text = " If You have selected \'Unique Randomization\', then You have reached the end of th" +
    "e queue. Reset the queue by unchecking the checkbox and selecting it again.";
            this.NoShipFoundHelpMsg.Visible = false;
            // 
            // shipDescription
            // 
            this.shipDescription.Location = new System.Drawing.Point(11, 378);
            this.shipDescription.Name = "shipDescription";
            this.shipDescription.Size = new System.Drawing.Size(324, 89);
            this.shipDescription.TabIndex = 9;
            // 
            // NoShipFoundMsg
            // 
            this.NoShipFoundMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoShipFoundMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.NoShipFoundMsg.Location = new System.Drawing.Point(11, 160);
            this.NoShipFoundMsg.Name = "NoShipFoundMsg";
            this.NoShipFoundMsg.Size = new System.Drawing.Size(370, 27);
            this.NoShipFoundMsg.TabIndex = 8;
            this.NoShipFoundMsg.Text = "No ship found with that selection.";
            this.NoShipFoundMsg.Visible = false;
            // 
            // BtnBuildMgr
            // 
            this.BtnBuildMgr.Location = new System.Drawing.Point(190, 470);
            this.BtnBuildMgr.Name = "BtnBuildMgr";
            this.BtnBuildMgr.Size = new System.Drawing.Size(145, 23);
            this.BtnBuildMgr.TabIndex = 7;
            this.BtnBuildMgr.Text = "Open in Build Manager";
            this.BtnBuildMgr.UseVisualStyleBackColor = true;
            this.BtnBuildMgr.Visible = false;
            this.BtnBuildMgr.Click += new System.EventHandler(this.BtnBuildMgr_Click);
            // 
            // BtnRecommendedBuild
            // 
            this.BtnRecommendedBuild.Location = new System.Drawing.Point(11, 470);
            this.BtnRecommendedBuild.Name = "BtnRecommendedBuild";
            this.BtnRecommendedBuild.Size = new System.Drawing.Size(148, 23);
            this.BtnRecommendedBuild.TabIndex = 6;
            this.BtnRecommendedBuild.Text = "Show Personal Build";
            this.BtnRecommendedBuild.UseVisualStyleBackColor = true;
            this.BtnRecommendedBuild.Visible = false;
            this.BtnRecommendedBuild.Click += new System.EventHandler(this.BtnRecommendedBuild_Click);
            // 
            // ShipName
            // 
            this.ShipName.AutoSize = true;
            this.ShipName.BackColor = System.Drawing.SystemColors.Control;
            this.ShipName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShipName.Location = new System.Drawing.Point(11, 109);
            this.ShipName.Name = "ShipName";
            this.ShipName.Size = new System.Drawing.Size(22, 31);
            this.ShipName.TabIndex = 2;
            this.ShipName.Text = " ";
            // 
            // FlagImage
            // 
            this.FlagImage.Location = new System.Drawing.Point(11, 19);
            this.FlagImage.Name = "FlagImage";
            this.FlagImage.Size = new System.Drawing.Size(135, 85);
            this.FlagImage.TabIndex = 1;
            this.FlagImage.TabStop = false;
            // 
            // ShipImage
            // 
            this.ShipImage.BackColor = System.Drawing.SystemColors.Control;
            this.ShipImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ShipImage.Location = new System.Drawing.Point(11, 143);
            this.ShipImage.Name = "ShipImage";
            this.ShipImage.Size = new System.Drawing.Size(324, 232);
            this.ShipImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ShipImage.TabIndex = 0;
            this.ShipImage.TabStop = false;
            this.ShipImage.Click += new System.EventHandler(this.ShipImage_Click);
            // 
            // BackgroundWorker
            // 
            this.BackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
            this.BackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_RunWorkerCompleted);
            // 
            // LoadingImage
            // 
            this.LoadingImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.LoadingImage.Image = ((System.Drawing.Image)(resources.GetObject("LoadingImage.Image")));
            this.LoadingImage.Location = new System.Drawing.Point(218, 526);
            this.LoadingImage.Name = "LoadingImage";
            this.LoadingImage.Size = new System.Drawing.Size(176, 129);
            this.LoadingImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.LoadingImage.TabIndex = 5;
            this.LoadingImage.TabStop = false;
            this.LoadingImage.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 855);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(850, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(270, 17);
            this.StatusLabel.Text = "© 2020 Kenneth Axi : https//www.twitch.tv/axillent";
            this.StatusLabel.Click += new System.EventHandler(this.StatusLabel_Click);
            this.StatusLabel.MouseHover += new System.EventHandler(this.StatusLabel_MouseHover);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "Click to open ship info in WG Wikipedia";
            // 
            // BGUpdater
            // 
            this.BGUpdater.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGUpdater_DoWork);
            this.BGUpdater.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGUpdater_RunWorkerCompleted);
            // 
            // UpgradeFixer
            // 
            this.UpgradeFixer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.UpgradeFixer_DoWork);
            this.UpgradeFixer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.UpgradeFixer_RunWorkerCompleted);
            // 
            // FormRandomizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 877);
            this.Controls.Add(this.LoadingImage);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ResultBox);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this.RightPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "FormRandomizer";
            this.Text = "WoWs Randomizer";
            this.Load += new System.EventHandler(this.FormRandomizer_Load);
            this.LeftPanel.ResumeLayout(false);
            this.LeftPanel.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.RightPanel.ResumeLayout(false);
            this.RightPanel.PerformLayout();
            this.ResultBox.ResumeLayout(false);
            this.ResultBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlagImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingImage)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.Panel RightPanel;
        private System.Windows.Forms.GroupBox ResultBox;
        private System.ComponentModel.BackgroundWorker BackgroundWorker;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMyShipsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shipComparisonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.PictureBox LoadingImage;
        private System.Windows.Forms.Button RandomizeButton;
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
        private System.Windows.Forms.CheckBox CBShipclass4;
        private System.Windows.Forms.CheckBox CBShipclass2;
        private System.Windows.Forms.CheckBox CBShipclass3;
        private System.Windows.Forms.CheckBox CBShipclass1;
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
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Button BtnBuildMgr;
        private System.Windows.Forms.Button BtnRecommendedBuild;
        private System.Windows.Forms.Label ShipName;
        private System.Windows.Forms.PictureBox FlagImage;
        private System.Windows.Forms.PictureBox ShipImage;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel ShipMetricsTable;
        private System.Windows.Forms.Label NoShipFoundMsg;
        private System.Windows.Forms.ToolStripMenuItem exclusionListToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem changeLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem installUpgradeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomizerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildManagerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem shipCompareToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upgradesExaminerToolStripMenuItem;
        private System.Windows.Forms.Label shipDescription;
        private System.Windows.Forms.ToolStripMenuItem profilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuProfileEU;
        private System.Windows.Forms.ToolStripMenuItem menuProfileNA;
        private System.Windows.Forms.ToolStripMenuItem menuProfileRU;
        private System.Windows.Forms.CheckBox cbSingleSelect;
        private System.Windows.Forms.Label NoShipFoundHelpMsg;
        private System.Windows.Forms.Label lblShipsInPort;
        private System.Windows.Forms.Label lblExcludedShips;
        private System.Windows.Forms.Label lblQueue;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listOfShipsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listOfModulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myShipsInPortToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.CheckBox CBPremium;
        private System.Windows.Forms.CheckBox CBNonPremium;
        private System.ComponentModel.BackgroundWorker BGUpdater;
        private System.ComponentModel.BackgroundWorker UpgradeFixer;
    }
}

