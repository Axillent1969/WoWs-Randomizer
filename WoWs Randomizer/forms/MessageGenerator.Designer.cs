
namespace WoWs_Randomizer.forms
{
    partial class MessageGenerator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageGenerator));
            this.status = new System.Windows.Forms.ComboBox();
            this.startdate = new System.Windows.Forms.DateTimePicker();
            this.enddate = new System.Windows.Forms.DateTimePicker();
            this.id = new System.Windows.Forms.Label();
            this.message = new System.Windows.Forms.RichTextBox();
            this.link = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.FormattingEnabled = true;
            this.status.Items.AddRange(new object[] {
            "draft",
            "ok"});
            this.status.Location = new System.Drawing.Point(12, 31);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(121, 21);
            this.status.TabIndex = 0;
            this.status.Text = "draft";
            // 
            // startdate
            // 
            this.startdate.Location = new System.Drawing.Point(12, 83);
            this.startdate.MinDate = new System.DateTime(2021, 5, 19, 0, 0, 0, 0);
            this.startdate.Name = "startdate";
            this.startdate.Size = new System.Drawing.Size(200, 20);
            this.startdate.TabIndex = 1;
            // 
            // enddate
            // 
            this.enddate.Location = new System.Drawing.Point(249, 83);
            this.enddate.MinDate = new System.DateTime(2021, 5, 19, 0, 0, 0, 0);
            this.enddate.Name = "enddate";
            this.enddate.Size = new System.Drawing.Size(200, 20);
            this.enddate.TabIndex = 2;
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(249, 31);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(200, 21);
            this.id.TabIndex = 3;
            this.id.Text = "label1";
            // 
            // message
            // 
            this.message.Location = new System.Drawing.Point(12, 152);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(437, 96);
            this.message.TabIndex = 4;
            this.message.Text = "";
            // 
            // link
            // 
            this.link.Location = new System.Drawing.Point(12, 277);
            this.link.Name = "link";
            this.link.Size = new System.Drawing.Size(296, 20);
            this.link.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Status:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Start date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(249, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "End date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(249, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Message ID:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Message:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 261);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Link:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(12, 317);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 12;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(456, 12);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(332, 426);
            this.result.TabIndex = 13;
            this.result.Text = "";
            // 
            // MessageGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.result);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.link);
            this.Controls.Add(this.message);
            this.Controls.Add(this.id);
            this.Controls.Add(this.enddate);
            this.Controls.Add(this.startdate);
            this.Controls.Add(this.status);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MessageGenerator";
            this.Text = "MessageGenerator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox status;
        private System.Windows.Forms.DateTimePicker startdate;
        private System.Windows.Forms.DateTimePicker enddate;
        private System.Windows.Forms.Label id;
        private System.Windows.Forms.RichTextBox message;
        private System.Windows.Forms.TextBox link;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.RichTextBox result;
    }
}