namespace WoWs_Randomizer.forms
{
    partial class ChangeLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeLog));
            this.logView = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.logText = new System.Windows.Forms.Label();
            this.logView.SuspendLayout();
            this.SuspendLayout();
            // 
            // logView
            // 
            this.logView.AutoSize = true;
            this.logView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.logView.Controls.Add(this.label1);
            this.logView.Controls.Add(this.logText);
            this.logView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logView.Location = new System.Drawing.Point(0, 0);
            this.logView.Name = "logView";
            this.logView.Size = new System.Drawing.Size(512, 289);
            this.logView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Changes made in each version:";
            // 
            // logText
            // 
            this.logText.AutoSize = true;
            this.logText.Location = new System.Drawing.Point(15, 29);
            this.logText.Name = "logText";
            this.logText.Size = new System.Drawing.Size(35, 13);
            this.logText.TabIndex = 0;
            this.logText.Text = "label1";
            // 
            // ChangeLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 289);
            this.Controls.Add(this.logView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChangeLog";
            this.Text = "Change Log";
            this.Load += new System.EventHandler(this.ChangeLog_Load);
            this.logView.ResumeLayout(false);
            this.logView.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel logView;
        private System.Windows.Forms.Label logText;
        private System.Windows.Forms.Label label1;
    }
}