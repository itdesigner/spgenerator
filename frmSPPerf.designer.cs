namespace DS.SPGenerator
{
    partial class frmSPPerf
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.cmdClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlBase = new System.Windows.Forms.Panel();
            this.pnlParameters = new System.Windows.Forms.Panel();
            this.vscrlParameters = new System.Windows.Forms.VScrollBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cboQueryType = new System.Windows.Forms.ComboBox();
            this.spinCallDelay = new System.Windows.Forms.NumericUpDown();
            this.spinCallNumbers = new System.Windows.Forms.NumericUpDown();
            this.chkParallel = new System.Windows.Forms.CheckBox();
            this.spinThreshhold = new System.Windows.Forms.NumericUpDown();
            this.spinIntervals = new System.Windows.Forms.NumericUpDown();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.lblMsg = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridTestResults = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkReuseConnection = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStdDev = new System.Windows.Forms.TextBox();
            this.txtAve = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.bindSource = new System.Windows.Forms.BindingSource(this.components);
            this.timerMsg = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlBase.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinCallDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinCallNumbers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinThreshhold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinIntervals)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTestResults)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.Location = new System.Drawing.Point(550, 436);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 1;
            this.cmdClose.Text = "&Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(458, 436);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Run Tests";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.pnlParameters);
            this.pnlBase.Controls.Add(this.vscrlParameters);
            this.pnlBase.Location = new System.Drawing.Point(6, 19);
            this.pnlBase.Name = "pnlBase";
            this.pnlBase.Size = new System.Drawing.Size(354, 102);
            this.pnlBase.TabIndex = 3;
            // 
            // pnlParameters
            // 
            this.pnlParameters.Location = new System.Drawing.Point(4, 3);
            this.pnlParameters.Name = "pnlParameters";
            this.pnlParameters.Size = new System.Drawing.Size(330, 96);
            this.pnlParameters.TabIndex = 1;
            // 
            // vscrlParameters
            // 
            this.vscrlParameters.Location = new System.Drawing.Point(337, 0);
            this.vscrlParameters.Name = "vscrlParameters";
            this.vscrlParameters.Size = new System.Drawing.Size(17, 102);
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
            this.groupBox1.Size = new System.Drawing.Size(366, 129);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SP Parameters";
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.chart1.BackImageTransparentColor = System.Drawing.Color.White;
            this.chart1.BackSecondaryColor = System.Drawing.Color.GhostWhite;
            this.chart1.BorderlineColor = System.Drawing.Color.CornflowerBlue;
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart1.BorderlineWidth = 2;
            this.chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea1.AlignWithChartArea = "HistogramArea";
            chartArea1.Area3DStyle.Inclination = 15;
            chartArea1.Area3DStyle.IsClustered = true;
            chartArea1.Area3DStyle.IsRightAngleAxes = false;
            chartArea1.Area3DStyle.Perspective = 10;
            chartArea1.Area3DStyle.Rotation = 10;
            chartArea1.Area3DStyle.WallWidth = 0;
            chartArea1.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)(((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisX.LabelStyle.Enabled = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.MajorTickMark.Size = 1.5F;
            chartArea1.AxisX.Title = "Call Timing Distribution";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Trebuchet MS", 8F);
            chartArea1.AxisY.IsReversed = true;
            chartArea1.AxisY.LabelStyle.Enabled = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.AxisY.Maximum = 2D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY2.IsLabelAutoFit = false;
            chartArea1.AxisY2.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.BackColor = System.Drawing.Color.OldLace;
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "Default";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 15F;
            chartArea1.Position.Width = 96F;
            chartArea1.Position.X = 3F;
            chartArea1.Position.Y = 4F;
            chartArea1.ShadowColor = System.Drawing.Color.Transparent;
            chartArea2.Area3DStyle.Inclination = 15;
            chartArea2.Area3DStyle.IsClustered = true;
            chartArea2.Area3DStyle.IsRightAngleAxes = false;
            chartArea2.Area3DStyle.Perspective = 10;
            chartArea2.Area3DStyle.Rotation = 10;
            chartArea2.Area3DStyle.WallWidth = 0;
            chartArea2.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep90) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea2.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisX.Title = "Call Time (ms)";
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Trebuchet MS", 8F);
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea2.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisY2.IsLabelAutoFit = false;
            chartArea2.AxisY2.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea2.BackColor = System.Drawing.Color.OldLace;
            chartArea2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea2.BackSecondaryColor = System.Drawing.Color.White;
            chartArea2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Name = "HistogramArea";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 77F;
            chartArea2.Position.Width = 93F;
            chartArea2.Position.X = 3F;
            chartArea2.Position.Y = 18F;
            chartArea2.ShadowColor = System.Drawing.Color.Transparent;
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.ChartAreas.Add(chartArea2);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Enabled = false;
            legend1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Default";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(213, 152);
            this.chart1.Name = "chart1";
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series1.ChartArea = "Default";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(252)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            series1.Enabled = false;
            series1.Legend = "Default";
            series1.MarkerSize = 9;
            series1.Name = "RawData";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series2.ChartArea = "Default";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(252)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            series2.Legend = "Default";
            series2.MarkerSize = 8;
            series2.Name = "DataDistribution";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series3.ChartArea = "HistogramArea";
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(64)))), ((int)(((byte)(10)))));
            series3.IsValueShownAsLabel = true;
            series3.Legend = "Default";
            series3.Name = "Histogram";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(425, 274);
            this.chart1.TabIndex = 11;
            this.toolTip1.SetToolTip(this.chart1, "Call timing distribution");
            // 
            // cboQueryType
            // 
            this.cboQueryType.FormattingEnabled = true;
            this.cboQueryType.Items.AddRange(new object[] {
            "Data Reader",
            "Data Set"});
            this.cboQueryType.Location = new System.Drawing.Point(19, 89);
            this.cboQueryType.Name = "cboQueryType";
            this.cboQueryType.Size = new System.Drawing.Size(100, 21);
            this.cboQueryType.TabIndex = 6;
            this.toolTip1.SetToolTip(this.cboQueryType, "Type of query to test");
            // 
            // spinCallDelay
            // 
            this.spinCallDelay.Location = new System.Drawing.Point(116, 56);
            this.spinCallDelay.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.spinCallDelay.Name = "spinCallDelay";
            this.spinCallDelay.Size = new System.Drawing.Size(46, 20);
            this.spinCallDelay.TabIndex = 3;
            this.toolTip1.SetToolTip(this.spinCallDelay, "Delay between calls");
            // 
            // spinCallNumbers
            // 
            this.spinCallNumbers.Location = new System.Drawing.Point(19, 56);
            this.spinCallNumbers.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.spinCallNumbers.Name = "spinCallNumbers";
            this.spinCallNumbers.Size = new System.Drawing.Size(46, 20);
            this.spinCallNumbers.TabIndex = 2;
            this.toolTip1.SetToolTip(this.spinCallNumbers, "Number of calls to make for test run");
            this.spinCallNumbers.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // chkParallel
            // 
            this.chkParallel.AutoSize = true;
            this.chkParallel.Location = new System.Drawing.Point(137, 27);
            this.chkParallel.Name = "chkParallel";
            this.chkParallel.Size = new System.Drawing.Size(85, 17);
            this.chkParallel.TabIndex = 1;
            this.chkParallel.Text = "Parallel Calls";
            this.toolTip1.SetToolTip(this.chkParallel, "Parallel or Consecutive execution");
            this.chkParallel.UseVisualStyleBackColor = true;
            this.chkParallel.CheckedChanged += new System.EventHandler(this.chkParallel_CheckedChanged);
            // 
            // spinThreshhold
            // 
            this.spinThreshhold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.spinThreshhold.DecimalPlaces = 1;
            this.spinThreshhold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spinThreshhold.Location = new System.Drawing.Point(11, 436);
            this.spinThreshhold.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.spinThreshhold.Name = "spinThreshhold";
            this.spinThreshhold.Size = new System.Drawing.Size(64, 20);
            this.spinThreshhold.TabIndex = 8;
            this.toolTip1.SetToolTip(this.spinThreshhold, "Call threshhold to display in results");
            this.spinThreshhold.ValueChanged += new System.EventHandler(this.spinThreshhold_ValueChanged);
            // 
            // spinIntervals
            // 
            this.spinIntervals.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.spinIntervals.Location = new System.Drawing.Point(147, 436);
            this.spinIntervals.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.spinIntervals.Name = "spinIntervals";
            this.spinIntervals.Size = new System.Drawing.Size(41, 20);
            this.spinIntervals.TabIndex = 14;
            this.toolTip1.SetToolTip(this.spinIntervals, "# of intervals for the graph display");
            this.spinIntervals.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.spinIntervals.ValueChanged += new System.EventHandler(this.spinIntervals_ValueChanged);
            // 
            // lblMsg
            // 
            this.lblMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMsg.AutoSize = true;
            this.lblMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMsg.Location = new System.Drawing.Point(271, 441);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 13);
            this.lblMsg.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.gridTestResults);
            this.groupBox2.Location = new System.Drawing.Point(12, 199);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(193, 189);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Results";
            // 
            // gridTestResults
            // 
            this.gridTestResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridTestResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTestResults.Location = new System.Drawing.Point(6, 19);
            this.gridTestResults.Name = "gridTestResults";
            this.gridTestResults.Size = new System.Drawing.Size(181, 164);
            this.gridTestResults.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cboQueryType);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.spinCallDelay);
            this.groupBox3.Controls.Add(this.spinCallNumbers);
            this.groupBox3.Controls.Add(this.chkParallel);
            this.groupBox3.Controls.Add(this.chkReuseConnection);
            this.groupBox3.Location = new System.Drawing.Point(390, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(236, 128);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Test Parameters";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(123, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Query Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "delay (ms)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "# calls";
            // 
            // chkReuseConnection
            // 
            this.chkReuseConnection.AutoSize = true;
            this.chkReuseConnection.Location = new System.Drawing.Point(19, 27);
            this.chkReuseConnection.Name = "chkReuseConnection";
            this.chkReuseConnection.Size = new System.Drawing.Size(114, 17);
            this.chkReuseConnection.TabIndex = 0;
            this.chkReuseConnection.Text = "Reuse Connection";
            this.chkReuseConnection.UseVisualStyleBackColor = true;
            this.chkReuseConnection.CheckedChanged += new System.EventHandler(this.chkReuseConnection_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 438);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Threshhold";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(190, 438);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Intervals";
            // 
            // txtStdDev
            // 
            this.txtStdDev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtStdDev.Location = new System.Drawing.Point(100, 394);
            this.txtStdDev.Name = "txtStdDev";
            this.txtStdDev.ReadOnly = true;
            this.txtStdDev.Size = new System.Drawing.Size(53, 20);
            this.txtStdDev.TabIndex = 16;
            // 
            // txtAve
            // 
            this.txtAve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAve.Location = new System.Drawing.Point(12, 394);
            this.txtAve.Name = "txtAve";
            this.txtAve.ReadOnly = true;
            this.txtAve.Size = new System.Drawing.Size(53, 20);
            this.txtAve.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 397);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Avg.";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(156, 397);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Std. Dev";
            // 
            // timerMsg
            // 
            this.timerMsg.Interval = 3000;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::DS.SPGenerator.Properties.Resources.dakotaSoftware;
            this.pictureBox1.Location = new System.Drawing.Point(23, 155);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(176, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // frmSPPerf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(640, 476);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAve);
            this.Controls.Add(this.txtStdDev);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.spinIntervals);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.spinThreshhold);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdClose);
            this.Name = "frmSPPerf";
            this.Text = "Stored Procedure Performance Analysis";
            this.Load += new System.EventHandler(this.frmSPTest_Load);
            this.pnlBase.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinCallDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinCallNumbers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinThreshhold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinIntervals)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTestResults)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlBase;
        private System.Windows.Forms.VScrollBar vscrlParameters;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnlParameters;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboQueryType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown spinCallDelay;
        private System.Windows.Forms.NumericUpDown spinCallNumbers;
        private System.Windows.Forms.CheckBox chkParallel;
        private System.Windows.Forms.CheckBox chkReuseConnection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown spinThreshhold;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown spinIntervals;
        private System.Windows.Forms.TextBox txtStdDev;
        private System.Windows.Forms.TextBox txtAve;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource bindSource;
        private System.Windows.Forms.DataGridView gridTestResults;
        private System.Windows.Forms.Timer timerMsg;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}