namespace WoWs_Randomizer.forms
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.label1 = new System.Windows.Forms.Label();
            this.SaveDir = new System.Windows.Forms.TextBox();
            this.BtnSelectDir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Nickname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Server = new System.Windows.Forms.ComboBox();
            this.BtnOK = new System.Windows.Forms.Button();
            this.UserID = new System.Windows.Forms.Label();
            this.lblGameVersion = new System.Windows.Forms.Label();
            this.lblUpdatedTime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.countryCode = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Save Directory";
            // 
            // SaveDir
            // 
            this.SaveDir.Location = new System.Drawing.Point(16, 29);
            this.SaveDir.Name = "SaveDir";
            this.SaveDir.Size = new System.Drawing.Size(256, 20);
            this.SaveDir.TabIndex = 1;
            // 
            // BtnSelectDir
            // 
            this.BtnSelectDir.Location = new System.Drawing.Point(273, 26);
            this.BtnSelectDir.Name = "BtnSelectDir";
            this.BtnSelectDir.Size = new System.Drawing.Size(94, 23);
            this.BtnSelectDir.TabIndex = 2;
            this.BtnSelectDir.Text = "Select directory";
            this.BtnSelectDir.UseVisualStyleBackColor = true;
            this.BtnSelectDir.Click += new System.EventHandler(this.BtnSelectDir_click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Wargaming Nickname";
            // 
            // Nickname
            // 
            this.Nickname.Location = new System.Drawing.Point(16, 86);
            this.Nickname.Name = "Nickname";
            this.Nickname.Size = new System.Drawing.Size(256, 20);
            this.Nickname.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Server";
            // 
            // Server
            // 
            this.Server.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Server.FormattingEnabled = true;
            this.Server.Items.AddRange(new object[] {
            "EU",
            "NA",
            "RU"});
            this.Server.Location = new System.Drawing.Point(16, 140);
            this.Server.Name = "Server";
            this.Server.Size = new System.Drawing.Size(121, 21);
            this.Server.TabIndex = 6;
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(292, 285);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 7;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_ClickAsync);
            // 
            // UserID
            // 
            this.UserID.AutoSize = true;
            this.UserID.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.UserID.Location = new System.Drawing.Point(278, 89);
            this.UserID.Name = "UserID";
            this.UserID.Size = new System.Drawing.Size(13, 13);
            this.UserID.TabIndex = 8;
            this.UserID.Text = "0";
            // 
            // lblGameVersion
            // 
            this.lblGameVersion.AutoSize = true;
            this.lblGameVersion.Location = new System.Drawing.Point(94, 275);
            this.lblGameVersion.Name = "lblGameVersion";
            this.lblGameVersion.Size = new System.Drawing.Size(10, 13);
            this.lblGameVersion.TabIndex = 9;
            this.lblGameVersion.Text = "-";
            // 
            // lblUpdatedTime
            // 
            this.lblUpdatedTime.AutoSize = true;
            this.lblUpdatedTime.Location = new System.Drawing.Point(94, 295);
            this.lblUpdatedTime.Name = "lblUpdatedTime";
            this.lblUpdatedTime.Size = new System.Drawing.Size(10, 13);
            this.lblUpdatedTime.TabIndex = 10;
            this.lblUpdatedTime.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 275);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Game Version:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Last update:";
            // 
            // countryCode
            // 
            this.countryCode.FormattingEnabled = true;
            this.countryCode.Items.AddRange(new object[] {
            "de-DE",
            "en-US",
            "en-GB",
            "en-CA",
            "es-ES",
            "fi-FI",
            "fr-BE",
            "fr-CA",
            "fr-FR",
            "it-IT",
            "nl-NL",
            "no-NO",
            "sv-FI",
            "sv-SE"});
            this.countryCode.Location = new System.Drawing.Point(16, 202);
            this.countryCode.Name = "countryCode";
            this.countryCode.Size = new System.Drawing.Size(121, 21);
            this.countryCode.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Country/Localisation";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 317);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.countryCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblUpdatedTime);
            this.Controls.Add(this.lblGameVersion);
            this.Controls.Add(this.UserID);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.Server);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Nickname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnSelectDir);
            this.Controls.Add(this.SaveDir);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSettings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SaveDir;
        private System.Windows.Forms.Button BtnSelectDir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Nickname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Server;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Label UserID;
        private System.Windows.Forms.Label lblGameVersion;
        private System.Windows.Forms.Label lblUpdatedTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox countryCode;
        private System.Windows.Forms.Label label6;
    }
}