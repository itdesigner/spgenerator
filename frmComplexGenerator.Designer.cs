namespace DS.SPGenerator
{
    partial class frmComplexGenerator
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmComplexGenerator));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gradientPanel2 = new DS.UIControls.Panels.GradientPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelRel = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gradientPanel1 = new DS.UIControls.Panels.GradientPanel();
            this.rtbComplexSP = new System.Windows.Forms.RichTextBox();
            this.cmdPublish = new System.Windows.Forms.Button();
            this.txtComplexSPName = new System.Windows.Forms.TextBox();
            this.cmdCopyToClipboard = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdTest = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridCriteria = new System.Windows.Forms.DataGridView();
            this.tableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableAliasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aliasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.filterDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bindingsourceFilters = new System.Windows.Forms.BindingSource(this.components);
            this.SortDirection = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bindingsourceSorts = new System.Windows.Forms.BindingSource(this.components);
            this.SortOrder = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bindingsourceSortOrder = new System.Windows.Forms.BindingSource(this.components);
            this.bindingsourceFields = new System.Windows.Forms.BindingSource(this.components);
            this.lblMsg = new System.Windows.Forms.Label();
            this.lblDB = new System.Windows.Forms.Label();
            this.chkJoinFromClause = new System.Windows.Forms.CheckBox();
            this.menuManageRelations = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addOrRemoveTablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.removeRelationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllRowsFromSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllRowsFromDestinationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerLabel = new System.Windows.Forms.Timer(this.components);
            this.tmrMsg = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.treeRenderer1 = new DS.UIControls.Boxes.TreeListView.TreeRenderer();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn5 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.contextmenuTDP = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeAliasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDataTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gradientPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.gradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCriteria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingsourceFilters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingsourceSorts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingsourceSortOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingsourceFields)).BeginInit();
            this.menuManageRelations.SuspendLayout();
            this.contextmenuTDP.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gradientPanel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2MinSize = 191;
            this.splitContainer1.Size = new System.Drawing.Size(819, 722);
            this.splitContainer1.SplitterDistance = 416;
            this.splitContainer1.TabIndex = 0;
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gradientPanel2.BackColor = System.Drawing.Color.Transparent;
            this.gradientPanel2.BorderColor = System.Drawing.Color.SlateGray;
            this.gradientPanel2.BorderWidth = 2;
            this.gradientPanel2.Controls.Add(this.panel1);
            this.gradientPanel2.CornerRadius = 30;
            this.gradientPanel2.GradientEndColor = System.Drawing.Color.GhostWhite;
            this.gradientPanel2.GradientStartColor = System.Drawing.Color.LightSteelBlue;
            this.gradientPanel2.Image = null;
            this.gradientPanel2.ImageLocation = new System.Drawing.Point(4, 4);
            this.gradientPanel2.Location = new System.Drawing.Point(7, 8);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.PanelBackgroundImage = null;
            this.gradientPanel2.PanelBackgroundType = DS.UIControls.Panels.CaptionBrushType.VerticalGradient;
            this.gradientPanel2.ShadowColor = System.Drawing.Color.Black;
            this.gradientPanel2.ShadowDepth = 10;
            this.gradientPanel2.Size = new System.Drawing.Size(809, 405);
            this.gradientPanel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.labelRel);
            this.panel1.Location = new System.Drawing.Point(10, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 377);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDrawing_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelDrawing_MouseClick);
            // 
            // labelRel
            // 
            this.labelRel.AutoSize = true;
            this.labelRel.Location = new System.Drawing.Point(4, 402);
            this.labelRel.Name = "labelRel";
            this.labelRel.Size = new System.Drawing.Size(0, 13);
            this.labelRel.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gradientPanel1);
            this.splitContainer2.Panel1MinSize = 213;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Panel2.Controls.Add(this.lblMsg);
            this.splitContainer2.Panel2.Controls.Add(this.lblDB);
            this.splitContainer2.Panel2.Controls.Add(this.chkJoinFromClause);
            this.splitContainer2.Panel2MinSize = 187;
            this.splitContainer2.Size = new System.Drawing.Size(819, 302);
            this.splitContainer2.SplitterDistance = 295;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.SplitterMoving += new System.Windows.Forms.SplitterCancelEventHandler(this.splitContainer2_SplitterMoving);
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.gradientPanel1.BorderColor = System.Drawing.Color.SlateGray;
            this.gradientPanel1.BorderWidth = 2;
            this.gradientPanel1.Controls.Add(this.rtbComplexSP);
            this.gradientPanel1.Controls.Add(this.cmdPublish);
            this.gradientPanel1.Controls.Add(this.txtComplexSPName);
            this.gradientPanel1.Controls.Add(this.cmdCopyToClipboard);
            this.gradientPanel1.Controls.Add(this.label1);
            this.gradientPanel1.Controls.Add(this.cmdTest);
            this.gradientPanel1.CornerRadius = 30;
            this.gradientPanel1.GradientEndColor = System.Drawing.Color.GhostWhite;
            this.gradientPanel1.GradientStartColor = System.Drawing.Color.LightSteelBlue;
            this.gradientPanel1.Image = null;
            this.gradientPanel1.ImageLocation = new System.Drawing.Point(4, 4);
            this.gradientPanel1.Location = new System.Drawing.Point(7, 8);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.PanelBackgroundImage = null;
            this.gradientPanel1.PanelBackgroundType = DS.UIControls.Panels.CaptionBrushType.VerticalGradient;
            this.gradientPanel1.ShadowColor = System.Drawing.Color.Black;
            this.gradientPanel1.ShadowDepth = 10;
            this.gradientPanel1.Size = new System.Drawing.Size(285, 291);
            this.gradientPanel1.TabIndex = 3;
            // 
            // rtbComplexSP
            // 
            this.rtbComplexSP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbComplexSP.Location = new System.Drawing.Point(16, 46);
            this.rtbComplexSP.Name = "rtbComplexSP";
            this.rtbComplexSP.Size = new System.Drawing.Size(246, 196);
            this.rtbComplexSP.TabIndex = 0;
            this.rtbComplexSP.Text = "";
            this.rtbComplexSP.WordWrap = false;
            // 
            // cmdPublish
            // 
            this.cmdPublish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdPublish.Location = new System.Drawing.Point(211, 251);
            this.cmdPublish.Name = "cmdPublish";
            this.cmdPublish.Size = new System.Drawing.Size(51, 23);
            this.cmdPublish.TabIndex = 4;
            this.cmdPublish.Text = "&Publish";
            this.cmdPublish.UseVisualStyleBackColor = true;
            this.cmdPublish.Click += new System.EventHandler(this.cmdPublish_Click);
            // 
            // txtComplexSPName
            // 
            this.txtComplexSPName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComplexSPName.Location = new System.Drawing.Point(81, 15);
            this.txtComplexSPName.Name = "txtComplexSPName";
            this.txtComplexSPName.Size = new System.Drawing.Size(181, 20);
            this.txtComplexSPName.TabIndex = 2;
            this.txtComplexSPName.Leave += new System.EventHandler(this.txtComplexSPName_Leave);
            // 
            // cmdCopyToClipboard
            // 
            this.cmdCopyToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCopyToClipboard.Location = new System.Drawing.Point(154, 251);
            this.cmdCopyToClipboard.Name = "cmdCopyToClipboard";
            this.cmdCopyToClipboard.Size = new System.Drawing.Size(51, 23);
            this.cmdCopyToClipboard.TabIndex = 3;
            this.cmdCopyToClipboard.Text = "&Copy";
            this.cmdCopyToClipboard.UseVisualStyleBackColor = true;
            this.cmdCopyToClipboard.Click += new System.EventHandler(this.cmdCopyToClipboard_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "SP Name:";
            // 
            // cmdTest
            // 
            this.cmdTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTest.Location = new System.Drawing.Point(97, 251);
            this.cmdTest.Name = "cmdTest";
            this.cmdTest.Size = new System.Drawing.Size(51, 23);
            this.cmdTest.TabIndex = 2;
            this.cmdTest.Text = "&Test";
            this.cmdTest.UseVisualStyleBackColor = true;
            this.cmdTest.Click += new System.EventHandler(this.cmdTest_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::DS.SPGenerator.Properties.Resources.dakotaSoftware;
            this.pictureBox1.Location = new System.Drawing.Point(332, 262);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(176, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.gridCriteria);
            this.groupBox1.Location = new System.Drawing.Point(19, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 208);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
            // 
            // gridCriteria
            // 
            this.gridCriteria.AllowUserToAddRows = false;
            this.gridCriteria.AllowUserToDeleteRows = false;
            this.gridCriteria.AllowUserToOrderColumns = true;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridCriteria.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.gridCriteria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridCriteria.AutoGenerateColumns = false;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCriteria.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.gridCriteria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCriteria.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tableDataGridViewTextBoxColumn,
            this.tableAliasDataGridViewTextBoxColumn,
            this.columnDataGridViewTextBoxColumn,
            this.aliasDataGridViewTextBoxColumn,
            this.selectDataGridViewCheckBoxColumn,
            this.filterDataGridViewTextBoxColumn,
            this.SortDirection,
            this.SortOrder});
            this.gridCriteria.DataSource = this.bindingsourceFields;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridCriteria.DefaultCellStyle = dataGridViewCellStyle15;
            this.gridCriteria.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridCriteria.Location = new System.Drawing.Point(6, 19);
            this.gridCriteria.Name = "gridCriteria";
            this.gridCriteria.RowHeadersVisible = false;
            this.gridCriteria.Size = new System.Drawing.Size(477, 181);
            this.gridCriteria.TabIndex = 0;
            this.gridCriteria.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCriteria_CellEndEdit);
            this.gridCriteria.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridCriteria_CellMouseDown);
            this.gridCriteria.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridCriteria_CellMouseUp);
            this.gridCriteria.CurrentCellDirtyStateChanged += new System.EventHandler(this.gridCriteria_CurrentCellDirtyStateChanged);
            this.gridCriteria.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.gridCriteria_RowsAdded);
            this.gridCriteria.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.gridCriteria_RowsRemoved);
            // 
            // tableDataGridViewTextBoxColumn
            // 
            this.tableDataGridViewTextBoxColumn.DataPropertyName = "Table";
            this.tableDataGridViewTextBoxColumn.HeaderText = "Table";
            this.tableDataGridViewTextBoxColumn.Name = "tableDataGridViewTextBoxColumn";
            this.tableDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tableAliasDataGridViewTextBoxColumn
            // 
            this.tableAliasDataGridViewTextBoxColumn.DataPropertyName = "TableAlias";
            this.tableAliasDataGridViewTextBoxColumn.HeaderText = "Table Alias";
            this.tableAliasDataGridViewTextBoxColumn.Name = "tableAliasDataGridViewTextBoxColumn";
            this.tableAliasDataGridViewTextBoxColumn.ReadOnly = true;
            this.tableAliasDataGridViewTextBoxColumn.Width = 50;
            // 
            // columnDataGridViewTextBoxColumn
            // 
            this.columnDataGridViewTextBoxColumn.DataPropertyName = "Column";
            this.columnDataGridViewTextBoxColumn.HeaderText = "Column";
            this.columnDataGridViewTextBoxColumn.Name = "columnDataGridViewTextBoxColumn";
            this.columnDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aliasDataGridViewTextBoxColumn
            // 
            this.aliasDataGridViewTextBoxColumn.DataPropertyName = "Alias";
            this.aliasDataGridViewTextBoxColumn.HeaderText = "Alias";
            this.aliasDataGridViewTextBoxColumn.Name = "aliasDataGridViewTextBoxColumn";
            this.aliasDataGridViewTextBoxColumn.Width = 40;
            // 
            // selectDataGridViewCheckBoxColumn
            // 
            this.selectDataGridViewCheckBoxColumn.DataPropertyName = "Select";
            this.selectDataGridViewCheckBoxColumn.HeaderText = "Select";
            this.selectDataGridViewCheckBoxColumn.Name = "selectDataGridViewCheckBoxColumn";
            this.selectDataGridViewCheckBoxColumn.Width = 60;
            // 
            // filterDataGridViewTextBoxColumn
            // 
            this.filterDataGridViewTextBoxColumn.DataPropertyName = "Filter";
            this.filterDataGridViewTextBoxColumn.DataSource = this.bindingsourceFilters;
            this.filterDataGridViewTextBoxColumn.DisplayMember = "DisplayString";
            this.filterDataGridViewTextBoxColumn.HeaderText = "Filter";
            this.filterDataGridViewTextBoxColumn.Name = "filterDataGridViewTextBoxColumn";
            this.filterDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.filterDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.filterDataGridViewTextBoxColumn.ValueMember = "Criteria";
            this.filterDataGridViewTextBoxColumn.Width = 40;
            // 
            // bindingsourceFilters
            // 
            this.bindingsourceFilters.DataSource = typeof(DS.SPGenerator.FilterPair);
            // 
            // SortDirection
            // 
            this.SortDirection.DataPropertyName = "SortDirection";
            this.SortDirection.DataSource = this.bindingsourceSorts;
            this.SortDirection.DisplayMember = "DisplayString";
            this.SortDirection.HeaderText = "Sort";
            this.SortDirection.Name = "SortDirection";
            this.SortDirection.ValueMember = "SortOrder";
            this.SortDirection.Width = 40;
            // 
            // bindingsourceSorts
            // 
            this.bindingsourceSorts.DataSource = typeof(DS.SPGenerator.SortPair);
            // 
            // SortOrder
            // 
            this.SortOrder.DataPropertyName = "SortOrder";
            this.SortOrder.DataSource = this.bindingsourceSortOrder;
            this.SortOrder.DisplayMember = "Display";
            this.SortOrder.HeaderText = "Sort Order";
            this.SortOrder.Name = "SortOrder";
            this.SortOrder.ValueMember = "Order";
            this.SortOrder.Width = 40;
            // 
            // bindingsourceSortOrder
            // 
            this.bindingsourceSortOrder.DataSource = typeof(DS.SPGenerator.SortOrder);
            // 
            // bindingsourceFields
            // 
            this.bindingsourceFields.DataSource = typeof(DS.SPGenerator.AliasField);
            this.bindingsourceFields.CurrentItemChanged += new System.EventHandler(this.bindingsourceFields_CurrentItemChanged);
            // 
            // lblMsg
            // 
            this.lblMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMsg.AutoSize = true;
            this.lblMsg.ForeColor = System.Drawing.Color.Maroon;
            this.lblMsg.Location = new System.Drawing.Point(26, 269);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(59, 13);
            this.lblMsg.TabIndex = 5;
            this.lblMsg.Text = "MESSAGE";
            this.lblMsg.Visible = false;
            // 
            // lblDB
            // 
            this.lblDB.AutoSize = true;
            this.lblDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDB.Location = new System.Drawing.Point(23, 20);
            this.lblDB.Name = "lblDB";
            this.lblDB.Size = new System.Drawing.Size(93, 13);
            this.lblDB.TabIndex = 0;
            this.lblDB.Text = "Server - Database";
            // 
            // chkJoinFromClause
            // 
            this.chkJoinFromClause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkJoinFromClause.AutoSize = true;
            this.chkJoinFromClause.Location = new System.Drawing.Point(354, 19);
            this.chkJoinFromClause.Name = "chkJoinFromClause";
            this.chkJoinFromClause.Size = new System.Drawing.Size(148, 17);
            this.chkJoinFromClause.TabIndex = 1;
            this.chkJoinFromClause.Text = "Joins in the FROM Clause";
            this.chkJoinFromClause.UseVisualStyleBackColor = true;
            this.chkJoinFromClause.CheckedChanged += new System.EventHandler(this.chkJoinFromClause_CheckedChanged);
            // 
            // menuManageRelations
            // 
            this.menuManageRelations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addOrRemoveTablesToolStripMenuItem,
            this.toolStripMenuItem1,
            this.removeRelationToolStripMenuItem,
            this.selectAllRowsFromSourceToolStripMenuItem,
            this.selectAllRowsFromDestinationToolStripMenuItem});
            this.menuManageRelations.Name = "menuManageRelations";
            this.menuManageRelations.ShowCheckMargin = true;
            this.menuManageRelations.ShowImageMargin = false;
            this.menuManageRelations.Size = new System.Drawing.Size(246, 98);
            // 
            // addOrRemoveTablesToolStripMenuItem
            // 
            this.addOrRemoveTablesToolStripMenuItem.CheckOnClick = true;
            this.addOrRemoveTablesToolStripMenuItem.Name = "addOrRemoveTablesToolStripMenuItem";
            this.addOrRemoveTablesToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.addOrRemoveTablesToolStripMenuItem.Text = "Add or Remove &Tables";
            this.addOrRemoveTablesToolStripMenuItem.Click += new System.EventHandler(this.addTablesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(242, 6);
            // 
            // removeRelationToolStripMenuItem
            // 
            this.removeRelationToolStripMenuItem.CheckOnClick = true;
            this.removeRelationToolStripMenuItem.Name = "removeRelationToolStripMenuItem";
            this.removeRelationToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.removeRelationToolStripMenuItem.Text = "&Remove Relation";
            this.removeRelationToolStripMenuItem.Click += new System.EventHandler(this.removeRelationToolStripMenuItem_Click);
            // 
            // selectAllRowsFromSourceToolStripMenuItem
            // 
            this.selectAllRowsFromSourceToolStripMenuItem.CheckOnClick = true;
            this.selectAllRowsFromSourceToolStripMenuItem.Name = "selectAllRowsFromSourceToolStripMenuItem";
            this.selectAllRowsFromSourceToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.selectAllRowsFromSourceToolStripMenuItem.Text = "Select All Rows from Source";
            this.selectAllRowsFromSourceToolStripMenuItem.Click += new System.EventHandler(this.selectAllRowsFromSourceToolStripMenuItem_Click);
            // 
            // selectAllRowsFromDestinationToolStripMenuItem
            // 
            this.selectAllRowsFromDestinationToolStripMenuItem.CheckOnClick = true;
            this.selectAllRowsFromDestinationToolStripMenuItem.Name = "selectAllRowsFromDestinationToolStripMenuItem";
            this.selectAllRowsFromDestinationToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.selectAllRowsFromDestinationToolStripMenuItem.Text = "Select All Rows from Destination";
            this.selectAllRowsFromDestinationToolStripMenuItem.Click += new System.EventHandler(this.selectAllRowsFromDestinationToolStripMenuItem_Click);
            // 
            // timerLabel
            // 
            this.timerLabel.Interval = 3000;
            this.timerLabel.Tick += new System.EventHandler(this.timerLabel_Tick);
            // 
            // tmrMsg
            // 
            this.tmrMsg.Interval = 4000;
            this.tmrMsg.Tick += new System.EventHandler(this.tmrMsg_Tick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Data_Dataset.ico");
            this.imageList1.Images.SetKeyName(1, "db.ico");
            this.imageList1.Images.SetKeyName(2, "dbs.ico");
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.DataPropertyName = "SortDirection";
            this.dataGridViewComboBoxColumn1.HeaderText = "Sort";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.Width = 40;
            // 
            // dataGridViewComboBoxColumn2
            // 
            this.dataGridViewComboBoxColumn2.DataPropertyName = "SortDirection";
            this.dataGridViewComboBoxColumn2.HeaderText = "Sort";
            this.dataGridViewComboBoxColumn2.Name = "dataGridViewComboBoxColumn2";
            this.dataGridViewComboBoxColumn2.Width = 40;
            // 
            // dataGridViewComboBoxColumn3
            // 
            this.dataGridViewComboBoxColumn3.DataPropertyName = "SortOrder";
            this.dataGridViewComboBoxColumn3.HeaderText = "Sort Order";
            this.dataGridViewComboBoxColumn3.Name = "dataGridViewComboBoxColumn3";
            this.dataGridViewComboBoxColumn3.Width = 40;
            // 
            // dataGridViewComboBoxColumn4
            // 
            this.dataGridViewComboBoxColumn4.DataPropertyName = "SortDirection";
            this.dataGridViewComboBoxColumn4.HeaderText = "Sort";
            this.dataGridViewComboBoxColumn4.Name = "dataGridViewComboBoxColumn4";
            this.dataGridViewComboBoxColumn4.Width = 40;
            // 
            // dataGridViewComboBoxColumn5
            // 
            this.dataGridViewComboBoxColumn5.DataPropertyName = "SortOrder";
            this.dataGridViewComboBoxColumn5.HeaderText = "Sort Order";
            this.dataGridViewComboBoxColumn5.Name = "dataGridViewComboBoxColumn5";
            this.dataGridViewComboBoxColumn5.Width = 40;
            // 
            // contextmenuTDP
            // 
            this.contextmenuTDP.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeAliasToolStripMenuItem,
            this.removeTableToolStripMenuItem,
            this.showDataTypesToolStripMenuItem});
            this.contextmenuTDP.Name = "contextmenuTDP";
            this.contextmenuTDP.Size = new System.Drawing.Size(161, 92);
            // 
            // changeAliasToolStripMenuItem
            // 
            this.changeAliasToolStripMenuItem.Name = "changeAliasToolStripMenuItem";
            this.changeAliasToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.changeAliasToolStripMenuItem.Text = "&Change Alias";
            this.changeAliasToolStripMenuItem.Click += new System.EventHandler(this.changeAliasToolStripMenuItem_Click);
            // 
            // removeTableToolStripMenuItem
            // 
            this.removeTableToolStripMenuItem.Name = "removeTableToolStripMenuItem";
            this.removeTableToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.removeTableToolStripMenuItem.Text = "&Remove Table";
            this.removeTableToolStripMenuItem.Click += new System.EventHandler(this.removeTableToolStripMenuItem_Click);
            // 
            // showDataTypesToolStripMenuItem
            // 
            this.showDataTypesToolStripMenuItem.Checked = true;
            this.showDataTypesToolStripMenuItem.CheckOnClick = true;
            this.showDataTypesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showDataTypesToolStripMenuItem.Name = "showDataTypesToolStripMenuItem";
            this.showDataTypesToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.showDataTypesToolStripMenuItem.Text = "&Show data types";
            this.showDataTypesToolStripMenuItem.Click += new System.EventHandler(this.showDataTypesToolStripMenuItem_Click);
            // 
            // frmComplexGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(819, 722);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmComplexGenerator";
            this.Text = "Complex SP Generator";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gradientPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCriteria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingsourceFilters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingsourceSorts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingsourceSortOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingsourceFields)).EndInit();
            this.menuManageRelations.ResumeLayout(false);
            this.contextmenuTDP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtbComplexSP;
        private System.Windows.Forms.DataGridView gridCriteria;
        private System.Windows.Forms.ContextMenuStrip menuManageRelations;
        private System.Windows.Forms.ToolStripMenuItem removeRelationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllRowsFromSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllRowsFromDestinationToolStripMenuItem;
        private System.Windows.Forms.Label labelRel;
        private System.Windows.Forms.Timer timerLabel;
        private System.Windows.Forms.ToolStripMenuItem addOrRemoveTablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.CheckBox chkJoinFromClause;
        private System.Windows.Forms.Label lblDB;
        private System.Windows.Forms.Button cmdPublish;
        private System.Windows.Forms.Button cmdCopyToClipboard;
        private System.Windows.Forms.Button cmdTest;
        private System.Windows.Forms.Timer tmrMsg;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.BindingSource bindingsourceFields;
        private System.Windows.Forms.BindingSource bindingsourceFilters;
        private System.Windows.Forms.TextBox txtComplexSPName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private UIControls.Panels.GradientPanel gradientPanel1;
        private UIControls.Boxes.TreeListView.TreeRenderer treeRenderer1;
        private UIControls.Panels.GradientPanel gradientPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.BindingSource bindingsourceSorts;
        private System.Windows.Forms.BindingSource bindingsourceSortOrder;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn2;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn3;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn4;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableAliasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aliasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn filterDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn SortDirection;
        private System.Windows.Forms.DataGridViewComboBoxColumn SortOrder;
        private System.Windows.Forms.ContextMenuStrip contextmenuTDP;
        private System.Windows.Forms.ToolStripMenuItem changeAliasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showDataTypesToolStripMenuItem;
    }
}