
namespace WoWs_Randomizer.forms
{
    partial class Clan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clan));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rtDescription = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.members = new System.Windows.Forms.DataGridView();
            this.lblCreated = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblLeader = new System.Windows.Forms.Label();
            this.lblMemberCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.members)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Created by";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Created";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description:";
            // 
            // rtDescription
            // 
            this.rtDescription.Enabled = false;
            this.rtDescription.Location = new System.Drawing.Point(18, 87);
            this.rtDescription.Name = "rtDescription";
            this.rtDescription.Size = new System.Drawing.Size(435, 78);
            this.rtDescription.TabIndex = 3;
            this.rtDescription.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(239, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Clan leader";
            // 
            // members
            // 
            this.members.AllowUserToAddRows = false;
            this.members.AllowUserToDeleteRows = false;
            this.members.AllowUserToOrderColumns = true;
            this.members.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.members.Location = new System.Drawing.Point(12, 174);
            this.members.Name = "members";
            this.members.ReadOnly = true;
            this.members.Size = new System.Drawing.Size(780, 264);
            this.members.TabIndex = 5;
            // 
            // lblCreated
            // 
            this.lblCreated.AutoSize = true;
            this.lblCreated.Location = new System.Drawing.Point(81, 9);
            this.lblCreated.Name = "lblCreated";
            this.lblCreated.Size = new System.Drawing.Size(35, 13);
            this.lblCreated.TabIndex = 6;
            this.lblCreated.Text = "label5";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Location = new System.Drawing.Point(81, 31);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(35, 13);
            this.lblCreatedBy.TabIndex = 7;
            this.lblCreatedBy.Text = "label6";
            // 
            // lblLeader
            // 
            this.lblLeader.AutoSize = true;
            this.lblLeader.Location = new System.Drawing.Point(314, 9);
            this.lblLeader.Name = "lblLeader";
            this.lblLeader.Size = new System.Drawing.Size(35, 13);
            this.lblLeader.TabIndex = 8;
            this.lblLeader.Text = "label7";
            // 
            // lblMemberCount
            // 
            this.lblMemberCount.Location = new System.Drawing.Point(692, 151);
            this.lblMemberCount.Name = "lblMemberCount";
            this.lblMemberCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMemberCount.Size = new System.Drawing.Size(100, 14);
            this.lblMemberCount.TabIndex = 9;
            this.lblMemberCount.Text = "label5";
            // 
            // Clan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblMemberCount);
            this.Controls.Add(this.lblLeader);
            this.Controls.Add(this.lblCreatedBy);
            this.Controls.Add(this.lblCreated);
            this.Controls.Add(this.members);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rtDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Clan";
            this.Text = "Clan";
            this.Load += new System.EventHandler(this.Clan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.members)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView members;
        private System.Windows.Forms.Label lblCreated;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblLeader;
        private System.Windows.Forms.Label lblMemberCount;
    }
}