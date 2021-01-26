namespace WoWs_Randomizer.forms
{
    partial class ExclusionList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExclusionList));
            this.CategoryView = new System.Windows.Forms.TreeView();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnSaveClose = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.cbSelectAll = new System.Windows.Forms.CheckBox();
            this.resultGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // CategoryView
            // 
            this.CategoryView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CategoryView.Location = new System.Drawing.Point(0, 0);
            this.CategoryView.Name = "CategoryView";
            this.CategoryView.Size = new System.Drawing.Size(160, 353);
            this.CategoryView.TabIndex = 0;
            this.CategoryView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.CategoryView_BeforeSelect);
            this.CategoryView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.CategoryView_AfterSelect);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(12, 359);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(132, 23);
            this.BtnSave.TabIndex = 2;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnSaveClose
            // 
            this.BtnSaveClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnSaveClose.Location = new System.Drawing.Point(12, 388);
            this.BtnSaveClose.Name = "BtnSaveClose";
            this.BtnSaveClose.Size = new System.Drawing.Size(132, 23);
            this.BtnSaveClose.TabIndex = 3;
            this.BtnSaveClose.Text = "Save && Close";
            this.BtnSaveClose.UseVisualStyleBackColor = true;
            this.BtnSaveClose.Click += new System.EventHandler(this.BtnSaveClose_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(12, 417);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(132, 23);
            this.BtnCancel.TabIndex = 4;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // cbSelectAll
            // 
            this.cbSelectAll.AutoSize = true;
            this.cbSelectAll.Location = new System.Drawing.Point(463, 12);
            this.cbSelectAll.Name = "cbSelectAll";
            this.cbSelectAll.Size = new System.Drawing.Size(99, 17);
            this.cbSelectAll.TabIndex = 5;
            this.cbSelectAll.Text = "Select All Ships";
            this.cbSelectAll.UseVisualStyleBackColor = true;
            this.cbSelectAll.CheckedChanged += new System.EventHandler(this.cbSelectAll_CheckedChanged);
            // 
            // resultGrid
            // 
            this.resultGrid.AllowUserToAddRows = false;
            this.resultGrid.AllowUserToDeleteRows = false;
            this.resultGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.resultGrid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.resultGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultGrid.Location = new System.Drawing.Point(181, 35);
            this.resultGrid.Name = "resultGrid";
            this.resultGrid.Size = new System.Drawing.Size(397, 405);
            this.resultGrid.TabIndex = 6;
            // 
            // ExclusionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(586, 451);
            this.Controls.Add(this.resultGrid);
            this.Controls.Add(this.cbSelectAll);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSaveClose);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.CategoryView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExclusionList";
            this.Text = "ExclusionList";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExclusionList_FormClosing);
            this.Load += new System.EventHandler(this.ExclusionList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView CategoryView;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnSaveClose;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.CheckBox cbSelectAll;
        private System.Windows.Forms.DataGridView resultGrid;
    }
}