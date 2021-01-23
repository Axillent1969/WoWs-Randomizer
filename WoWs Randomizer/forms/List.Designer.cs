
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
            this.button1 = new System.Windows.Forms.Button();
            this.allFieldNames = new System.Windows.Forms.ListBox();
            this.userSelectedFields = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // resultGrid
            // 
            this.resultGrid.AllowUserToAddRows = false;
            this.resultGrid.AllowUserToDeleteRows = false;
            this.resultGrid.AllowUserToOrderColumns = true;
            this.resultGrid.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.resultGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultGrid.Location = new System.Drawing.Point(12, 160);
            this.resultGrid.Name = "resultGrid";
            this.resultGrid.Size = new System.Drawing.Size(570, 330);
            this.resultGrid.TabIndex = 0;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(13, 13);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(137, 23);
            this.btnShow.TabIndex = 5;
            this.btnShow.Text = "Show Selection";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(324, 82);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // allFieldNames
            // 
            this.allFieldNames.FormattingEnabled = true;
            this.allFieldNames.Location = new System.Drawing.Point(901, 5);
            this.allFieldNames.Name = "allFieldNames";
            this.allFieldNames.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.allFieldNames.Size = new System.Drawing.Size(198, 485);
            this.allFieldNames.Sorted = true;
            this.allFieldNames.TabIndex = 8;
            this.allFieldNames.DragOver += new System.Windows.Forms.DragEventHandler(this.allFieldNames_DragOver);
            // 
            // userSelectedFields
            // 
            this.userSelectedFields.AllowDrop = true;
            this.userSelectedFields.FormattingEnabled = true;
            this.userSelectedFields.Location = new System.Drawing.Point(605, 5);
            this.userSelectedFields.Name = "userSelectedFields";
            this.userSelectedFields.Size = new System.Drawing.Size(207, 485);
            this.userSelectedFields.TabIndex = 9;
            this.userSelectedFields.DragDrop += new System.Windows.Forms.DragEventHandler(this.userSelectedFields_DragDrop);
            this.userSelectedFields.DragOver += new System.Windows.Forms.DragEventHandler(this.userSelectedFields_DragOver);
            this.userSelectedFields.MouseDown += new System.Windows.Forms.MouseEventHandler(this.userSelectedFields_MouseDown);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(832, 160);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(46, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "<<";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(832, 203);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(46, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = ">>";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 502);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.userSelectedFields);
            this.Controls.Add(this.allFieldNames);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.resultGrid);
            this.Name = "List";
            this.Text = "List";
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView resultGrid;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox allFieldNames;
        private System.Windows.Forms.ListBox userSelectedFields;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}