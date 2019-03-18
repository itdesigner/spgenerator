namespace DS.SPGenerator
{
    partial class frmSPTest
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
            this.components = new System.ComponentModel.Container();
            this.dgridResults = new System.Windows.Forms.DataGridView();
            this.cmdClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlBase = new System.Windows.Forms.Panel();
            this.pnlParameters = new System.Windows.Forms.Panel();
            this.vscrlParameters = new System.Windows.Forms.VScrollBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.lblMsg = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQueryTimeout = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.vscrlResults = new System.Windows.Forms.VScrollBar();
            this.pnlResults = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgridResults)).BeginInit();
            this.pnlBase.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgridResults
            // 
            this.dgridResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridResults.Location = new System.Drawing.Point(4, 3);
            this.dgridResults.Name = "dgridResults";
            this.dgridResults.Size = new System.Drawing.Size(587, 206);
            this.dgridResults.TabIndex = 0;
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(557, 511);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 1;
            this.cmdClose.Text = "&Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(466, 511);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "&Test SQL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.pnlParameters);
            this.pnlBase.Controls.Add(this.vscrlParameters);
            this.pnlBase.Location = new System.Drawing.Point(6, 19);
            this.pnlBase.Name = "pnlBase";
            this.pnlBase.Size = new System.Drawing.Size(354, 196);
            this.pnlBase.TabIndex = 3;
            // 
            // pnlParameters
            // 
            this.pnlParameters.Location = new System.Drawing.Point(4, 3);
            this.pnlParameters.Name = "pnlParameters";
            this.pnlParameters.Size = new System.Drawing.Size(330, 190);
            this.pnlParameters.TabIndex = 1;
            // 
            // vscrlParameters
            // 
            this.vscrlParameters.Location = new System.Drawing.Point(337, 0);
            this.vscrlParameters.Name = "vscrlParameters";
            this.vscrlParameters.Size = new System.Drawing.Size(17, 193);
            this.vscrlParameters.TabIndex = 0;
            this.vscrlParameters.Visible = false;
            this.vscrlParameters.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vscrlParameters_Scroll);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlBase);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 221);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SP Parameters";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(384, 80);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(248, 127);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(384, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Stored Procedure Text:";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMsg.Location = new System.Drawing.Point(18, 480);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 13);
            this.lblMsg.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(445, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Query TimeOut:";
            // 
            // txtQueryTimeout
            // 
            this.txtQueryTimeout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQueryTimeout.Location = new System.Drawing.Point(532, 213);
            this.txtQueryTimeout.Name = "txtQueryTimeout";
            this.txtQueryTimeout.Size = new System.Drawing.Size(100, 20);
            this.txtQueryTimeout.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.vscrlResults);
            this.groupBox2.Controls.Add(this.pnlResults);
            this.groupBox2.Location = new System.Drawing.Point(12, 262);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(630, 242);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Results";
            // 
            // vscrlResults
            // 
            this.vscrlResults.Location = new System.Drawing.Point(603, 16);
            this.vscrlResults.Name = "vscrlResults";
            this.vscrlResults.Size = new System.Drawing.Size(17, 212);
            this.vscrlResults.TabIndex = 12;
            this.vscrlResults.Visible = false;
            this.vscrlResults.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vscrlResults_Scroll);
            // 
            // pnlResults
            // 
            this.pnlResults.Controls.Add(this.dgridResults);
            this.pnlResults.Location = new System.Drawing.Point(6, 19);
            this.pnlResults.Name = "pnlResults";
            this.pnlResults.Size = new System.Drawing.Size(594, 212);
            this.pnlResults.TabIndex = 11;
            this.pnlResults.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlResults_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::DS.SPGenerator.Properties.Resources.dakotaSoftware;
            this.pictureBox1.Location = new System.Drawing.Point(402, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(216, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // frmSPTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(654, 545);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtQueryTimeout);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSPTest";
            this.Text = "Stored Procedure Tester";
            this.Load += new System.EventHandler(this.frmSPTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgridResults)).EndInit();
            this.pnlBase.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.pnlResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgridResults;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlBase;
        private System.Windows.Forms.VScrollBar vscrlParameters;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlParameters;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQueryTimeout;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.VScrollBar vscrlResults;
        private System.Windows.Forms.Panel pnlResults;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}