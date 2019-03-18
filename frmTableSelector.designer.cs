namespace DS.SPGenerator
{
    partial class frmTableSelector
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
            this.lstAvailTables = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstSelectedTables = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdSelect = new System.Windows.Forms.Button();
            this.cmdDeSelect = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstAvailTables
            // 
            this.lstAvailTables.FormattingEnabled = true;
            this.lstAvailTables.Location = new System.Drawing.Point(12, 41);
            this.lstAvailTables.Name = "lstAvailTables";
            this.lstAvailTables.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstAvailTables.Size = new System.Drawing.Size(177, 173);
            this.lstAvailTables.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Available Tables:";
            // 
            // lstSelectedTables
            // 
            this.lstSelectedTables.FormattingEnabled = true;
            this.lstSelectedTables.Location = new System.Drawing.Point(287, 41);
            this.lstSelectedTables.Name = "lstSelectedTables";
            this.lstSelectedTables.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstSelectedTables.Size = new System.Drawing.Size(177, 173);
            this.lstSelectedTables.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Selected Tables:";
            // 
            // cmdSelect
            // 
            this.cmdSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSelect.Location = new System.Drawing.Point(201, 84);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(75, 23);
            this.cmdSelect.TabIndex = 4;
            this.cmdSelect.Text = ">>";
            this.cmdSelect.UseVisualStyleBackColor = true;
            this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
            // 
            // cmdDeSelect
            // 
            this.cmdDeSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDeSelect.Location = new System.Drawing.Point(201, 143);
            this.cmdDeSelect.Name = "cmdDeSelect";
            this.cmdDeSelect.Size = new System.Drawing.Size(75, 23);
            this.cmdDeSelect.TabIndex = 5;
            this.cmdDeSelect.Text = "<<";
            this.cmdDeSelect.UseVisualStyleBackColor = true;
            this.cmdDeSelect.Click += new System.EventHandler(this.cmdDeSelect_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.Location = new System.Drawing.Point(303, 243);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 6;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Location = new System.Drawing.Point(389, 243);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // frmTableSelector
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(478, 278);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdDeSelect);
            this.Controls.Add(this.cmdSelect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstSelectedTables);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstAvailTables);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmTableSelector";
            this.Text = "frmTableSelector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstAvailTables;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstSelectedTables;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdSelect;
        private System.Windows.Forms.Button cmdDeSelect;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
    }
}