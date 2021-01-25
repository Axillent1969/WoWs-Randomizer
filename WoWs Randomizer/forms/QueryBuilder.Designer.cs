
namespace WoWs_Randomizer.forms
{
    partial class QueryBuilder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryBuilder));
            this.fieldSelection = new System.Windows.Forms.ListBox();
            this.btnEqual = new System.Windows.Forms.Button();
            this.btnNotEqual = new System.Windows.Forms.Button();
            this.btnGreaterThan = new System.Windows.Forms.Button();
            this.btnGreaterOrEqualThan = new System.Windows.Forms.Button();
            this.btnLessThan = new System.Windows.Forms.Button();
            this.btnLessOrEqualThan = new System.Windows.Forms.Button();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQueryResult = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fieldSelection
            // 
            this.fieldSelection.FormattingEnabled = true;
            this.fieldSelection.Location = new System.Drawing.Point(13, 13);
            this.fieldSelection.Name = "fieldSelection";
            this.fieldSelection.Size = new System.Drawing.Size(211, 173);
            this.fieldSelection.Sorted = true;
            this.fieldSelection.TabIndex = 0;
            this.fieldSelection.SelectedIndexChanged += new System.EventHandler(this.fieldSelection_SelectedIndexChanged);
            // 
            // btnEqual
            // 
            this.btnEqual.Location = new System.Drawing.Point(59, 201);
            this.btnEqual.Name = "btnEqual";
            this.btnEqual.Size = new System.Drawing.Size(33, 23);
            this.btnEqual.TabIndex = 1;
            this.btnEqual.Text = "=";
            this.btnEqual.UseVisualStyleBackColor = true;
            this.btnEqual.Click += new System.EventHandler(this.btnOperator_Click);
            // 
            // btnNotEqual
            // 
            this.btnNotEqual.Location = new System.Drawing.Point(59, 230);
            this.btnNotEqual.Name = "btnNotEqual";
            this.btnNotEqual.Size = new System.Drawing.Size(33, 23);
            this.btnNotEqual.TabIndex = 2;
            this.btnNotEqual.Text = "!=";
            this.btnNotEqual.UseVisualStyleBackColor = true;
            this.btnNotEqual.Click += new System.EventHandler(this.btnOperator_Click);
            // 
            // btnGreaterThan
            // 
            this.btnGreaterThan.Location = new System.Drawing.Point(98, 201);
            this.btnGreaterThan.Name = "btnGreaterThan";
            this.btnGreaterThan.Size = new System.Drawing.Size(33, 23);
            this.btnGreaterThan.TabIndex = 3;
            this.btnGreaterThan.Text = ">";
            this.btnGreaterThan.UseVisualStyleBackColor = true;
            this.btnGreaterThan.Click += new System.EventHandler(this.btnOperator_Click);
            // 
            // btnGreaterOrEqualThan
            // 
            this.btnGreaterOrEqualThan.Location = new System.Drawing.Point(98, 230);
            this.btnGreaterOrEqualThan.Name = "btnGreaterOrEqualThan";
            this.btnGreaterOrEqualThan.Size = new System.Drawing.Size(33, 23);
            this.btnGreaterOrEqualThan.TabIndex = 4;
            this.btnGreaterOrEqualThan.Text = ">=";
            this.btnGreaterOrEqualThan.UseVisualStyleBackColor = true;
            this.btnGreaterOrEqualThan.Click += new System.EventHandler(this.btnOperator_Click);
            // 
            // btnLessThan
            // 
            this.btnLessThan.Location = new System.Drawing.Point(137, 201);
            this.btnLessThan.Name = "btnLessThan";
            this.btnLessThan.Size = new System.Drawing.Size(33, 23);
            this.btnLessThan.TabIndex = 5;
            this.btnLessThan.Text = "<";
            this.btnLessThan.UseVisualStyleBackColor = true;
            this.btnLessThan.Click += new System.EventHandler(this.btnOperator_Click);
            // 
            // btnLessOrEqualThan
            // 
            this.btnLessOrEqualThan.Location = new System.Drawing.Point(137, 230);
            this.btnLessOrEqualThan.Name = "btnLessOrEqualThan";
            this.btnLessOrEqualThan.Size = new System.Drawing.Size(33, 23);
            this.btnLessOrEqualThan.TabIndex = 6;
            this.btnLessOrEqualThan.Text = "<=";
            this.btnLessOrEqualThan.UseVisualStyleBackColor = true;
            this.btnLessOrEqualThan.Click += new System.EventHandler(this.btnOperator_Click);
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(56, 284);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(100, 20);
            this.txtValue.TabIndex = 7;
            this.txtValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtValue_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Value:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 347);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Query";
            // 
            // txtQueryResult
            // 
            this.txtQueryResult.Enabled = false;
            this.txtQueryResult.Location = new System.Drawing.Point(12, 373);
            this.txtQueryResult.Name = "txtQueryResult";
            this.txtQueryResult.Size = new System.Drawing.Size(212, 20);
            this.txtQueryResult.TabIndex = 10;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(16, 409);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(149, 409);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // QueryBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtQueryResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.btnLessOrEqualThan);
            this.Controls.Add(this.btnLessThan);
            this.Controls.Add(this.btnGreaterOrEqualThan);
            this.Controls.Add(this.btnGreaterThan);
            this.Controls.Add(this.btnNotEqual);
            this.Controls.Add(this.btnEqual);
            this.Controls.Add(this.fieldSelection);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QueryBuilder";
            this.Text = "QueryBuilder";
            this.Load += new System.EventHandler(this.QueryBuilder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox fieldSelection;
        private System.Windows.Forms.Button btnEqual;
        private System.Windows.Forms.Button btnNotEqual;
        private System.Windows.Forms.Button btnGreaterThan;
        private System.Windows.Forms.Button btnGreaterOrEqualThan;
        private System.Windows.Forms.Button btnLessThan;
        private System.Windows.Forms.Button btnLessOrEqualThan;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQueryResult;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}