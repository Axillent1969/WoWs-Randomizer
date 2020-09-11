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
            this.ResultTable = new System.Windows.Forms.TableLayoutPanel();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnSaveClose = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
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
            // ResultTable
            // 
            this.ResultTable.AutoScroll = true;
            this.ResultTable.AutoSize = true;
            this.ResultTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ResultTable.CausesValidation = false;
            this.ResultTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.ResultTable.ColumnCount = 5;
            this.ResultTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.ResultTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.ResultTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.ResultTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.ResultTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            this.ResultTable.Location = new System.Drawing.Point(166, 0);
            this.ResultTable.Name = "ResultTable";
            this.ResultTable.RowCount = 1;
            this.ResultTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ResultTable.Size = new System.Drawing.Size(575, 2);
            this.ResultTable.TabIndex = 1;
            this.ResultTable.Visible = false;
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
            // ExclusionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(759, 458);
            this.Controls.Add(this.ResultTable);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSaveClose);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.CategoryView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExclusionList";
            this.Text = "ExclusionList";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExclusionList_FormClosing);
            this.Load += new System.EventHandler(this.ExclusionList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView CategoryView;
        private System.Windows.Forms.TableLayoutPanel ResultTable;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnSaveClose;
        private System.Windows.Forms.Button BtnCancel;
    }
}