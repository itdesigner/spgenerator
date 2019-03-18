namespace DS.SPGenerator
{
    partial class spGenMain
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Select All Rows");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Select By PK");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Select By Indexes");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Select By FK");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("All Selects", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Insert By PK");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Identity Insert");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("All Inserts", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("All Updates");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("All Deletes");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("All Types", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode8,
            treeNode9,
            treeNode10});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(spGenMain));
            this.tabAll = new System.Windows.Forms.TabControl();
            this.tabSPTypes = new System.Windows.Forms.TabPage();
            this.lblMsgSPTypesDetails = new System.Windows.Forms.Label();
            this.cmdSelectTest = new System.Windows.Forms.Button();
            this.listOrderBy = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTopCount = new System.Windows.Forms.TextBox();
            this.chkSelectTop = new System.Windows.Forms.CheckBox();
            this.rtbSelectSP = new System.Windows.Forms.RichTextBox();
            this.cmdSelectCopy = new System.Windows.Forms.Button();
            this.cmdSelectPublish = new System.Windows.Forms.Button();
            this.chkSelectDISTINCT = new System.Windows.Forms.CheckBox();
            this.txtSelectSPName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.listSelectWhere = new System.Windows.Forms.ListBox();
            this.cmnuCriteria = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.opEQUALTO = new System.Windows.Forms.ToolStripMenuItem();
            this.opGREATERTHAN = new System.Windows.Forms.ToolStripMenuItem();
            this.opGREATERTHANorEQUALTO = new System.Windows.Forms.ToolStripMenuItem();
            this.opLESSTHAN = new System.Windows.Forms.ToolStripMenuItem();
            this.opLESSTHANorEQUALTO = new System.Windows.Forms.ToolStripMenuItem();
            this.opLIKE = new System.Windows.Forms.ToolStripMenuItem();
            this.listSelectSelect = new System.Windows.Forms.ListBox();
            this.cmnuSelect = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.opClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.opSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.opToggleAll = new System.Windows.Forms.ToolStripMenuItem();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblMsgSPTypes = new System.Windows.Forms.Label();
            this.tabSPInsert = new System.Windows.Forms.TabPage();
            this.lblMsgInsertDetails = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.rtbInsertSP = new System.Windows.Forms.RichTextBox();
            this.lblMsgInsert = new System.Windows.Forms.Label();
            this.cmdInsertCopy = new System.Windows.Forms.Button();
            this.cmdInsertPublish = new System.Windows.Forms.Button();
            this.chkInsertIdentityReturn = new System.Windows.Forms.CheckBox();
            this.chkInsertIdentity = new System.Windows.Forms.CheckBox();
            this.txtInsertSPName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.listInsertSelect = new System.Windows.Forms.ListBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tabSPUpdate = new System.Windows.Forms.TabPage();
            this.lblMsgUpdateDetails = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.rtbUpdateSP = new System.Windows.Forms.RichTextBox();
            this.lblMsgUpdate = new System.Windows.Forms.Label();
            this.cmdUpdateCopy = new System.Windows.Forms.Button();
            this.cmdUpdatePublish = new System.Windows.Forms.Button();
            this.txtUpdateSPName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.listUpdateWhere = new System.Windows.Forms.ListBox();
            this.listUpdateSelect = new System.Windows.Forms.ListBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tablSPDelete = new System.Windows.Forms.TabPage();
            this.lblMsgDeleteDetails = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.rtbDeleteSP = new System.Windows.Forms.RichTextBox();
            this.lblMsgDelete = new System.Windows.Forms.Label();
            this.cmdDeleteCopy = new System.Windows.Forms.Button();
            this.cmdDeletePublish = new System.Windows.Forms.Button();
            this.txtDeleteSPName = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.listDeleteWhere = new System.Windows.Forms.ListBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tabTablecomplete = new System.Windows.Forms.TabPage();
            this.lblMsgDefaultsDetails = new System.Windows.Forms.Label();
            this.cmdDefaultSPGenerate = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.treeDefaultSPOptions = new DS.UIControls.TreeViews.TriStateTreeView();
            this.rtbDefaultSPs = new System.Windows.Forms.RichTextBox();
            this.lblMsgDefaults = new System.Windows.Forms.Label();
            this.cmdDefaultClipboard = new System.Windows.Forms.Button();
            this.cmdDefaultPublish = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.cboTables = new System.Windows.Forms.ComboBox();
            this.dbTableParametersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlUserAuth = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkWindowsAuthentication = new System.Windows.Forms.CheckBox();
            this.cboDatabases = new System.Windows.Forms.ComboBox();
            this.cboServers = new System.Windows.Forms.ComboBox();
            this.tmrMsg = new System.Windows.Forms.Timer(this.components);
            this.tmrStretch = new System.Windows.Forms.Timer(this.components);
            this.label21 = new System.Windows.Forms.Label();
            this.cboSP = new System.Windows.Forms.ComboBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rt2 = new System.Windows.Forms.RichTextBox();
            this.txtCode = new System.Windows.Forms.RichTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.grpADOMethodType = new System.Windows.Forms.GroupBox();
            this.chkUseScalar = new System.Windows.Forms.CheckBox();
            this.chkUseDataReader = new System.Windows.Forms.CheckBox();
            this.chkUseNonQuery = new System.Windows.Forms.CheckBox();
            this.chkUseDataSet = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdoVB = new System.Windows.Forms.RadioButton();
            this.rdoCSharp = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoTiersMultiple = new System.Windows.Forms.RadioButton();
            this.rdoTiersSingle = new System.Windows.Forms.RadioButton();
            this.rdoStandardADO = new System.Windows.Forms.RadioButton();
            this.rdoSpoil = new System.Windows.Forms.RadioButton();
            this.rdoADO = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.txtSPText = new System.Windows.Forms.RichTextBox();
            this.xpgMain = new UIComponents.XPPanelGroup();
            this.xppDataAccess = new UIComponents.XPPanel(472);
            this.expandingButton3 = new UIComponents.ExpandingButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imageSet1 = new UIComponents.ImageSet();
            this.xppSPGenerator = new UIComponents.XPPanel(472);
            this.xbtnShowComplexGenerator = new UIComponents.ExpandingButton();
            this.expandingButton2 = new UIComponents.ExpandingButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.xppConnection = new UIComponents.XPPanel(152);
            this.lblConnString = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.expandingButton1 = new UIComponents.ExpandingButton();
            this.xcmdGetServers = new UIComponents.ExpandingButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.HelperSaveDlg = new System.Windows.Forms.SaveFileDialog();
            this.tmrMsgDetails = new System.Windows.Forms.Timer(this.components);
            this.tabAll.SuspendLayout();
            this.tabSPTypes.SuspendLayout();
            this.cmnuCriteria.SuspendLayout();
            this.cmnuSelect.SuspendLayout();
            this.tabSPInsert.SuspendLayout();
            this.tabSPUpdate.SuspendLayout();
            this.tablSPDelete.SuspendLayout();
            this.tabTablecomplete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbTableParametersBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.pnlUserAuth.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.grpADOMethodType.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpgMain)).BeginInit();
            this.xpgMain.SuspendLayout();
            this.xppDataAccess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.xppSPGenerator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.xppConnection.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabAll
            // 
            this.tabAll.Controls.Add(this.tabSPTypes);
            this.tabAll.Controls.Add(this.tabSPInsert);
            this.tabAll.Controls.Add(this.tabSPUpdate);
            this.tabAll.Controls.Add(this.tablSPDelete);
            this.tabAll.Controls.Add(this.tabTablecomplete);
            this.tabAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.tabAll.HotTrack = true;
            this.tabAll.Location = new System.Drawing.Point(9, 83);
            this.tabAll.Name = "tabAll";
            this.tabAll.SelectedIndex = 0;
            this.tabAll.Size = new System.Drawing.Size(779, 382);
            this.tabAll.TabIndex = 0;
            this.tabAll.SelectedIndexChanged += new System.EventHandler(this.TabChanged);
            // 
            // tabSPTypes
            // 
            this.tabSPTypes.Controls.Add(this.lblMsgSPTypesDetails);
            this.tabSPTypes.Controls.Add(this.cmdSelectTest);
            this.tabSPTypes.Controls.Add(this.listOrderBy);
            this.tabSPTypes.Controls.Add(this.label10);
            this.tabSPTypes.Controls.Add(this.txtTopCount);
            this.tabSPTypes.Controls.Add(this.chkSelectTop);
            this.tabSPTypes.Controls.Add(this.rtbSelectSP);
            this.tabSPTypes.Controls.Add(this.cmdSelectCopy);
            this.tabSPTypes.Controls.Add(this.cmdSelectPublish);
            this.tabSPTypes.Controls.Add(this.chkSelectDISTINCT);
            this.tabSPTypes.Controls.Add(this.txtSelectSPName);
            this.tabSPTypes.Controls.Add(this.label9);
            this.tabSPTypes.Controls.Add(this.label8);
            this.tabSPTypes.Controls.Add(this.listSelectWhere);
            this.tabSPTypes.Controls.Add(this.listSelectSelect);
            this.tabSPTypes.Controls.Add(this.label7);
            this.tabSPTypes.Controls.Add(this.label6);
            this.tabSPTypes.Controls.Add(this.lblMsgSPTypes);
            this.tabSPTypes.Location = new System.Drawing.Point(4, 22);
            this.tabSPTypes.Name = "tabSPTypes";
            this.tabSPTypes.Padding = new System.Windows.Forms.Padding(3);
            this.tabSPTypes.Size = new System.Drawing.Size(771, 356);
            this.tabSPTypes.TabIndex = 1;
            this.tabSPTypes.Text = "Select Stored Procedures";
            this.tabSPTypes.UseVisualStyleBackColor = true;
            this.tabSPTypes.Click += new System.EventHandler(this.tabSPTypes_Click_1);
            // 
            // lblMsgSPTypesDetails
            // 
            this.lblMsgSPTypesDetails.AutoSize = true;
            this.lblMsgSPTypesDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblMsgSPTypesDetails.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblMsgSPTypesDetails.Location = new System.Drawing.Point(29, 333);
            this.lblMsgSPTypesDetails.Name = "lblMsgSPTypesDetails";
            this.lblMsgSPTypesDetails.Size = new System.Drawing.Size(23, 13);
            this.lblMsgSPTypesDetails.TabIndex = 54;
            this.lblMsgSPTypesDetails.Text = "lallll";
            // 
            // cmdSelectTest
            // 
            this.cmdSelectTest.Location = new System.Drawing.Point(423, 318);
            this.cmdSelectTest.Name = "cmdSelectTest";
            this.cmdSelectTest.Size = new System.Drawing.Size(75, 27);
            this.cmdSelectTest.TabIndex = 53;
            this.cmdSelectTest.Text = "&Test";
            this.cmdSelectTest.UseVisualStyleBackColor = true;
            this.cmdSelectTest.Click += new System.EventHandler(this.cmdSelectTest_Click);
            // 
            // listOrderBy
            // 
            this.listOrderBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.listOrderBy.FormattingEnabled = true;
            this.helpProvider1.SetHelpString(this.listOrderBy, "Select 0 or more fields for resultset ordering");
            this.listOrderBy.ItemHeight = 12;
            this.listOrderBy.Location = new System.Drawing.Point(22, 255);
            this.listOrderBy.Name = "listOrderBy";
            this.listOrderBy.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.helpProvider1.SetShowHelp(this.listOrderBy, true);
            this.listOrderBy.Size = new System.Drawing.Size(189, 52);
            this.listOrderBy.Sorted = true;
            this.listOrderBy.TabIndex = 52;
            this.listOrderBy.Click += new System.EventHandler(this.listOrderBy_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(19, 239);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 12);
            this.label10.TabIndex = 51;
            this.label10.Text = "Order Fields (Order By Clause):";
            // 
            // txtTopCount
            // 
            this.txtTopCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.helpProvider1.SetHelpString(this.txtTopCount, "Enter a numeric value");
            this.txtTopCount.Location = new System.Drawing.Point(111, 137);
            this.txtTopCount.Name = "txtTopCount";
            this.helpProvider1.SetShowHelp(this.txtTopCount, true);
            this.txtTopCount.Size = new System.Drawing.Size(66, 18);
            this.txtTopCount.TabIndex = 50;
            this.txtTopCount.TextChanged += new System.EventHandler(this.txtTopCount_TextChanged);
            // 
            // chkSelectTop
            // 
            this.chkSelectTop.AutoSize = true;
            this.chkSelectTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSelectTop.Location = new System.Drawing.Point(44, 139);
            this.chkSelectTop.Name = "chkSelectTop";
            this.chkSelectTop.Size = new System.Drawing.Size(61, 16);
            this.chkSelectTop.TabIndex = 49;
            this.chkSelectTop.Text = "Use TOP";
            this.chkSelectTop.UseVisualStyleBackColor = true;
            this.chkSelectTop.CheckedChanged += new System.EventHandler(this.txtTopCount_TextChanged);
            // 
            // rtbSelectSP
            // 
            this.rtbSelectSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rtbSelectSP.Location = new System.Drawing.Point(237, 53);
            this.rtbSelectSP.Name = "rtbSelectSP";
            this.rtbSelectSP.Size = new System.Drawing.Size(522, 254);
            this.rtbSelectSP.TabIndex = 48;
            this.rtbSelectSP.Text = "";
            this.rtbSelectSP.WordWrap = false;
            // 
            // cmdSelectCopy
            // 
            this.cmdSelectCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.cmdSelectCopy.Location = new System.Drawing.Point(506, 317);
            this.cmdSelectCopy.Name = "cmdSelectCopy";
            this.cmdSelectCopy.Size = new System.Drawing.Size(133, 29);
            this.cmdSelectCopy.TabIndex = 46;
            this.cmdSelectCopy.Text = "&Copy to Clipboard";
            this.cmdSelectCopy.UseVisualStyleBackColor = true;
            this.cmdSelectCopy.Click += new System.EventHandler(this.cmdSelectCopy_Click);
            // 
            // cmdSelectPublish
            // 
            this.cmdSelectPublish.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.cmdSelectPublish.Location = new System.Drawing.Point(647, 317);
            this.cmdSelectPublish.Name = "cmdSelectPublish";
            this.cmdSelectPublish.Size = new System.Drawing.Size(110, 29);
            this.cmdSelectPublish.TabIndex = 45;
            this.cmdSelectPublish.Text = "&Publish";
            this.cmdSelectPublish.UseVisualStyleBackColor = true;
            this.cmdSelectPublish.Click += new System.EventHandler(this.cmdSelectPublish_Click);
            // 
            // chkSelectDISTINCT
            // 
            this.chkSelectDISTINCT.AutoSize = true;
            this.chkSelectDISTINCT.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpString(this.chkSelectDISTINCT, "Check for a DISTINCT select");
            this.chkSelectDISTINCT.Location = new System.Drawing.Point(44, 122);
            this.chkSelectDISTINCT.Name = "chkSelectDISTINCT";
            this.helpProvider1.SetShowHelp(this.chkSelectDISTINCT, true);
            this.chkSelectDISTINCT.Size = new System.Drawing.Size(114, 16);
            this.chkSelectDISTINCT.TabIndex = 2;
            this.chkSelectDISTINCT.Text = "Use DISTINCT Select";
            this.chkSelectDISTINCT.UseVisualStyleBackColor = true;
            this.chkSelectDISTINCT.CheckedChanged += new System.EventHandler(this.chkSelectDISTINCT_CheckedChanged);
            // 
            // txtSelectSPName
            // 
            this.txtSelectSPName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.helpProvider1.SetHelpString(this.txtSelectSPName, "Provide a unique name for the Stored Procedure");
            this.txtSelectSPName.Location = new System.Drawing.Point(106, 15);
            this.txtSelectSPName.Name = "txtSelectSPName";
            this.helpProvider1.SetShowHelp(this.txtSelectSPName, true);
            this.txtSelectSPName.Size = new System.Drawing.Size(622, 18);
            this.txtSelectSPName.TabIndex = 0;
            this.txtSelectSPName.TextChanged += new System.EventHandler(this.txtSelectSPName_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(19, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Name for SP:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(235, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 12);
            this.label8.TabIndex = 26;
            this.label8.Text = "Select SP:";
            // 
            // listSelectWhere
            // 
            this.listSelectWhere.ContextMenuStrip = this.cmnuCriteria;
            this.listSelectWhere.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listSelectWhere.FormattingEnabled = true;
            this.helpProvider1.SetHelpString(this.listSelectWhere, "Select 0 or more items as filter criteria");
            this.listSelectWhere.ItemHeight = 12;
            this.listSelectWhere.Location = new System.Drawing.Point(22, 184);
            this.listSelectWhere.Name = "listSelectWhere";
            this.listSelectWhere.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.helpProvider1.SetShowHelp(this.listSelectWhere, true);
            this.listSelectWhere.Size = new System.Drawing.Size(189, 52);
            this.listSelectWhere.Sorted = true;
            this.listSelectWhere.TabIndex = 3;
            this.listSelectWhere.Click += new System.EventHandler(this.listSelectWhere_SelectedIndexChanged);
            this.listSelectWhere.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listSelectWhere_MouseDown);
            // 
            // cmnuCriteria
            // 
            this.cmnuCriteria.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opEQUALTO,
            this.opGREATERTHAN,
            this.opGREATERTHANorEQUALTO,
            this.opLESSTHAN,
            this.opLESSTHANorEQUALTO,
            this.opLIKE});
            this.cmnuCriteria.Name = "cmnuCriteria";
            this.cmnuCriteria.Size = new System.Drawing.Size(252, 136);
            // 
            // opEQUALTO
            // 
            this.opEQUALTO.Name = "opEQUALTO";
            this.opEQUALTO.Size = new System.Drawing.Size(251, 22);
            this.opEQUALTO.Text = "=    EQUAL TO";
            this.opEQUALTO.Click += new System.EventHandler(this.opEQUALTO_Click);
            // 
            // opGREATERTHAN
            // 
            this.opGREATERTHAN.Name = "opGREATERTHAN";
            this.opGREATERTHAN.Size = new System.Drawing.Size(251, 22);
            this.opGREATERTHAN.Text = ">   GREATER THAN";
            this.opGREATERTHAN.Click += new System.EventHandler(this.opGREATERTHAN_Click);
            // 
            // opGREATERTHANorEQUALTO
            // 
            this.opGREATERTHANorEQUALTO.Name = "opGREATERTHANorEQUALTO";
            this.opGREATERTHANorEQUALTO.Size = new System.Drawing.Size(251, 22);
            this.opGREATERTHANorEQUALTO.Text = ">= GREATER THAN or EQUAL TO";
            this.opGREATERTHANorEQUALTO.Click += new System.EventHandler(this.opGREATERTHANorEQUALTO_Click);
            // 
            // opLESSTHAN
            // 
            this.opLESSTHAN.Name = "opLESSTHAN";
            this.opLESSTHAN.Size = new System.Drawing.Size(251, 22);
            this.opLESSTHAN.Text = "<    LESS THAN";
            this.opLESSTHAN.Click += new System.EventHandler(this.opLESSTHAN_Click);
            // 
            // opLESSTHANorEQUALTO
            // 
            this.opLESSTHANorEQUALTO.Name = "opLESSTHANorEQUALTO";
            this.opLESSTHANorEQUALTO.Size = new System.Drawing.Size(251, 22);
            this.opLESSTHANorEQUALTO.Text = "<= LESS THAN or EQUAL TO";
            this.opLESSTHANorEQUALTO.Click += new System.EventHandler(this.opLESSTHANorEQUALTO_Click);
            // 
            // opLIKE
            // 
            this.opLIKE.Name = "opLIKE";
            this.opLIKE.Size = new System.Drawing.Size(251, 22);
            this.opLIKE.Text = "LIKE";
            this.opLIKE.Click += new System.EventHandler(this.opLIKE_Click);
            // 
            // listSelectSelect
            // 
            this.listSelectSelect.ContextMenuStrip = this.cmnuSelect;
            this.listSelectSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listSelectSelect.FormattingEnabled = true;
            this.helpProvider1.SetHelpString(this.listSelectSelect, "Select 0 or more fields to return");
            this.listSelectSelect.ItemHeight = 12;
            this.listSelectSelect.Location = new System.Drawing.Point(22, 53);
            this.listSelectSelect.Name = "listSelectSelect";
            this.listSelectSelect.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.helpProvider1.SetShowHelp(this.listSelectSelect, true);
            this.listSelectSelect.Size = new System.Drawing.Size(189, 64);
            this.listSelectSelect.Sorted = true;
            this.listSelectSelect.TabIndex = 1;
            this.toolTip1.SetToolTip(this.listSelectSelect, "Select Fields");
            this.listSelectSelect.Click += new System.EventHandler(this.listSelectSelect_SelectedIndexChanged);
            this.listSelectSelect.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listSelectSelect_MouseDown);
            // 
            // cmnuSelect
            // 
            this.cmnuSelect.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opClearAll,
            this.opSelectAll,
            this.opToggleAll});
            this.cmnuSelect.Name = "cmnuSelect";
            this.cmnuSelect.Size = new System.Drawing.Size(129, 70);
            // 
            // opClearAll
            // 
            this.opClearAll.Name = "opClearAll";
            this.opClearAll.Size = new System.Drawing.Size(128, 22);
            this.opClearAll.Text = "&Clear All";
            this.opClearAll.Click += new System.EventHandler(this.opClearAll_Click);
            // 
            // opSelectAll
            // 
            this.opSelectAll.Name = "opSelectAll";
            this.opSelectAll.Size = new System.Drawing.Size(128, 22);
            this.opSelectAll.Text = "&Select All";
            this.opSelectAll.Click += new System.EventHandler(this.opSelectAll_Click);
            // 
            // opToggleAll
            // 
            this.opToggleAll.Name = "opToggleAll";
            this.opToggleAll.Size = new System.Drawing.Size(128, 22);
            this.opToggleAll.Text = "&Toggle All";
            this.opToggleAll.Click += new System.EventHandler(this.opToggleAll_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(19, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 12);
            this.label7.TabIndex = 21;
            this.label7.Text = "Filter Fields (Where clause):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "Select Fields (Select clause):";
            // 
            // lblMsgSPTypes
            // 
            this.lblMsgSPTypes.AutoSize = true;
            this.lblMsgSPTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblMsgSPTypes.ForeColor = System.Drawing.Color.Firebrick;
            this.lblMsgSPTypes.Location = new System.Drawing.Point(29, 317);
            this.lblMsgSPTypes.Name = "lblMsgSPTypes";
            this.lblMsgSPTypes.Size = new System.Drawing.Size(23, 13);
            this.lblMsgSPTypes.TabIndex = 19;
            this.lblMsgSPTypes.Text = "lallll";
            // 
            // tabSPInsert
            // 
            this.tabSPInsert.Controls.Add(this.lblMsgInsertDetails);
            this.tabSPInsert.Controls.Add(this.button1);
            this.tabSPInsert.Controls.Add(this.rtbInsertSP);
            this.tabSPInsert.Controls.Add(this.lblMsgInsert);
            this.tabSPInsert.Controls.Add(this.cmdInsertCopy);
            this.tabSPInsert.Controls.Add(this.cmdInsertPublish);
            this.tabSPInsert.Controls.Add(this.chkInsertIdentityReturn);
            this.tabSPInsert.Controls.Add(this.chkInsertIdentity);
            this.tabSPInsert.Controls.Add(this.txtInsertSPName);
            this.tabSPInsert.Controls.Add(this.label11);
            this.tabSPInsert.Controls.Add(this.label12);
            this.tabSPInsert.Controls.Add(this.listInsertSelect);
            this.tabSPInsert.Controls.Add(this.label14);
            this.tabSPInsert.Location = new System.Drawing.Point(4, 22);
            this.tabSPInsert.Name = "tabSPInsert";
            this.tabSPInsert.Size = new System.Drawing.Size(771, 356);
            this.tabSPInsert.TabIndex = 2;
            this.tabSPInsert.Text = "Insert Stored Procedures";
            this.tabSPInsert.UseVisualStyleBackColor = true;
            // 
            // lblMsgInsertDetails
            // 
            this.lblMsgInsertDetails.AutoSize = true;
            this.lblMsgInsertDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblMsgInsertDetails.ForeColor = System.Drawing.Color.Firebrick;
            this.lblMsgInsertDetails.Location = new System.Drawing.Point(20, 328);
            this.lblMsgInsertDetails.Name = "lblMsgInsertDetails";
            this.lblMsgInsertDetails.Size = new System.Drawing.Size(23, 13);
            this.lblMsgInsertDetails.TabIndex = 55;
            this.lblMsgInsertDetails.Text = "lallll";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(442, 312);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 29);
            this.button1.TabIndex = 54;
            this.button1.Text = "&Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // rtbInsertSP
            // 
            this.rtbInsertSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.rtbInsertSP.Location = new System.Drawing.Point(237, 70);
            this.rtbInsertSP.Name = "rtbInsertSP";
            this.rtbInsertSP.Size = new System.Drawing.Size(522, 218);
            this.rtbInsertSP.TabIndex = 49;
            this.rtbInsertSP.Text = "";
            this.rtbInsertSP.WordWrap = false;
            // 
            // lblMsgInsert
            // 
            this.lblMsgInsert.AutoSize = true;
            this.lblMsgInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblMsgInsert.ForeColor = System.Drawing.Color.Firebrick;
            this.lblMsgInsert.Location = new System.Drawing.Point(20, 312);
            this.lblMsgInsert.Name = "lblMsgInsert";
            this.lblMsgInsert.Size = new System.Drawing.Size(23, 13);
            this.lblMsgInsert.TabIndex = 47;
            this.lblMsgInsert.Text = "lallll";
            // 
            // cmdInsertCopy
            // 
            this.cmdInsertCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.cmdInsertCopy.Location = new System.Drawing.Point(523, 312);
            this.cmdInsertCopy.Name = "cmdInsertCopy";
            this.cmdInsertCopy.Size = new System.Drawing.Size(118, 29);
            this.cmdInsertCopy.TabIndex = 46;
            this.cmdInsertCopy.Text = "&Copy to Clipboard";
            this.cmdInsertCopy.UseVisualStyleBackColor = true;
            this.cmdInsertCopy.Click += new System.EventHandler(this.cmdInsertCopy_Click);
            // 
            // cmdInsertPublish
            // 
            this.cmdInsertPublish.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.cmdInsertPublish.Location = new System.Drawing.Point(647, 312);
            this.cmdInsertPublish.Name = "cmdInsertPublish";
            this.cmdInsertPublish.Size = new System.Drawing.Size(110, 29);
            this.cmdInsertPublish.TabIndex = 45;
            this.cmdInsertPublish.Text = "&Publish";
            this.cmdInsertPublish.UseVisualStyleBackColor = true;
            this.cmdInsertPublish.Click += new System.EventHandler(this.cmdInsertPublish_Click);
            // 
            // chkInsertIdentityReturn
            // 
            this.chkInsertIdentityReturn.AutoSize = true;
            this.chkInsertIdentityReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.chkInsertIdentityReturn.Location = new System.Drawing.Point(38, 271);
            this.chkInsertIdentityReturn.Name = "chkInsertIdentityReturn";
            this.chkInsertIdentityReturn.Size = new System.Drawing.Size(124, 17);
            this.chkInsertIdentityReturn.TabIndex = 38;
            this.chkInsertIdentityReturn.Text = "Return Identity Value";
            this.chkInsertIdentityReturn.UseVisualStyleBackColor = true;
            this.chkInsertIdentityReturn.CheckedChanged += new System.EventHandler(this.chkInsertIdentityReturn_CheckedChanged);
            // 
            // chkInsertIdentity
            // 
            this.chkInsertIdentity.AutoSize = true;
            this.chkInsertIdentity.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.chkInsertIdentity.Location = new System.Drawing.Point(38, 248);
            this.chkInsertIdentity.Name = "chkInsertIdentity";
            this.chkInsertIdentity.Size = new System.Drawing.Size(128, 17);
            this.chkInsertIdentity.TabIndex = 37;
            this.chkInsertIdentity.Text = "Perform Identity Insert";
            this.chkInsertIdentity.UseVisualStyleBackColor = true;
            this.chkInsertIdentity.CheckedChanged += new System.EventHandler(this.chkInsertIdentity_CheckedChanged);
            // 
            // txtInsertSPName
            // 
            this.txtInsertSPName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.txtInsertSPName.Location = new System.Drawing.Point(108, 22);
            this.txtInsertSPName.Name = "txtInsertSPName";
            this.txtInsertSPName.Size = new System.Drawing.Size(651, 18);
            this.txtInsertSPName.TabIndex = 36;
            this.txtInsertSPName.TextChanged += new System.EventHandler(this.txtInsertSPName_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(20, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 13);
            this.label11.TabIndex = 35;
            this.label11.Text = "Name for SP:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(234, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 34;
            this.label12.Text = "Insert SP:";
            // 
            // listInsertSelect
            // 
            this.listInsertSelect.ContextMenuStrip = this.cmnuSelect;
            this.listInsertSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.listInsertSelect.FormattingEnabled = true;
            this.listInsertSelect.ItemHeight = 12;
            this.listInsertSelect.Location = new System.Drawing.Point(23, 69);
            this.listInsertSelect.Name = "listInsertSelect";
            this.listInsertSelect.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listInsertSelect.Size = new System.Drawing.Size(189, 172);
            this.listInsertSelect.Sorted = true;
            this.listInsertSelect.TabIndex = 31;
            this.listInsertSelect.Click += new System.EventHandler(this.listInsertSelect_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(20, 52);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "Insert Fields:";
            // 
            // tabSPUpdate
            // 
            this.tabSPUpdate.Controls.Add(this.lblMsgUpdateDetails);
            this.tabSPUpdate.Controls.Add(this.button4);
            this.tabSPUpdate.Controls.Add(this.rtbUpdateSP);
            this.tabSPUpdate.Controls.Add(this.lblMsgUpdate);
            this.tabSPUpdate.Controls.Add(this.cmdUpdateCopy);
            this.tabSPUpdate.Controls.Add(this.cmdUpdatePublish);
            this.tabSPUpdate.Controls.Add(this.txtUpdateSPName);
            this.tabSPUpdate.Controls.Add(this.label13);
            this.tabSPUpdate.Controls.Add(this.label15);
            this.tabSPUpdate.Controls.Add(this.listUpdateWhere);
            this.tabSPUpdate.Controls.Add(this.listUpdateSelect);
            this.tabSPUpdate.Controls.Add(this.label16);
            this.tabSPUpdate.Controls.Add(this.label17);
            this.tabSPUpdate.Location = new System.Drawing.Point(4, 22);
            this.tabSPUpdate.Name = "tabSPUpdate";
            this.tabSPUpdate.Size = new System.Drawing.Size(771, 356);
            this.tabSPUpdate.TabIndex = 3;
            this.tabSPUpdate.Text = "Update Stored Procedures";
            this.tabSPUpdate.UseVisualStyleBackColor = true;
            // 
            // lblMsgUpdateDetails
            // 
            this.lblMsgUpdateDetails.AutoSize = true;
            this.lblMsgUpdateDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblMsgUpdateDetails.ForeColor = System.Drawing.Color.Firebrick;
            this.lblMsgUpdateDetails.Location = new System.Drawing.Point(24, 335);
            this.lblMsgUpdateDetails.Name = "lblMsgUpdateDetails";
            this.lblMsgUpdateDetails.Size = new System.Drawing.Size(23, 13);
            this.lblMsgUpdateDetails.TabIndex = 56;
            this.lblMsgUpdateDetails.Text = "lallll";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(431, 321);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 29);
            this.button4.TabIndex = 55;
            this.button4.Text = "&Test";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // rtbUpdateSP
            // 
            this.rtbUpdateSP.Location = new System.Drawing.Point(237, 67);
            this.rtbUpdateSP.Name = "rtbUpdateSP";
            this.rtbUpdateSP.Size = new System.Drawing.Size(522, 235);
            this.rtbUpdateSP.TabIndex = 50;
            this.rtbUpdateSP.Text = "";
            this.rtbUpdateSP.WordWrap = false;
            // 
            // lblMsgUpdate
            // 
            this.lblMsgUpdate.AutoSize = true;
            this.lblMsgUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblMsgUpdate.ForeColor = System.Drawing.Color.Firebrick;
            this.lblMsgUpdate.Location = new System.Drawing.Point(24, 319);
            this.lblMsgUpdate.Name = "lblMsgUpdate";
            this.lblMsgUpdate.Size = new System.Drawing.Size(23, 13);
            this.lblMsgUpdate.TabIndex = 47;
            this.lblMsgUpdate.Text = "lallll";
            // 
            // cmdUpdateCopy
            // 
            this.cmdUpdateCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.cmdUpdateCopy.Location = new System.Drawing.Point(512, 321);
            this.cmdUpdateCopy.Name = "cmdUpdateCopy";
            this.cmdUpdateCopy.Size = new System.Drawing.Size(123, 29);
            this.cmdUpdateCopy.TabIndex = 46;
            this.cmdUpdateCopy.Text = "&Copy to Clipboard";
            this.cmdUpdateCopy.UseVisualStyleBackColor = true;
            this.cmdUpdateCopy.Click += new System.EventHandler(this.cmdUpdateCopy_Click);
            // 
            // cmdUpdatePublish
            // 
            this.cmdUpdatePublish.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.cmdUpdatePublish.Location = new System.Drawing.Point(641, 321);
            this.cmdUpdatePublish.Name = "cmdUpdatePublish";
            this.cmdUpdatePublish.Size = new System.Drawing.Size(110, 29);
            this.cmdUpdatePublish.TabIndex = 45;
            this.cmdUpdatePublish.Text = "&Publish";
            this.cmdUpdatePublish.UseVisualStyleBackColor = true;
            this.cmdUpdatePublish.Click += new System.EventHandler(this.cmdUpdatePublish_Click);
            // 
            // txtUpdateSPName
            // 
            this.txtUpdateSPName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.txtUpdateSPName.Location = new System.Drawing.Point(108, 20);
            this.txtUpdateSPName.Name = "txtUpdateSPName";
            this.txtUpdateSPName.Size = new System.Drawing.Size(651, 18);
            this.txtUpdateSPName.TabIndex = 28;
            this.txtUpdateSPName.TextChanged += new System.EventHandler(this.txtUpdateSPName_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(20, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "Name for SP:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(234, 51);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 13);
            this.label15.TabIndex = 35;
            this.label15.Text = "Update SP:";
            // 
            // listUpdateWhere
            // 
            this.listUpdateWhere.ContextMenuStrip = this.cmnuCriteria;
            this.listUpdateWhere.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.listUpdateWhere.FormattingEnabled = true;
            this.listUpdateWhere.ItemHeight = 12;
            this.listUpdateWhere.Location = new System.Drawing.Point(23, 194);
            this.listUpdateWhere.Name = "listUpdateWhere";
            this.listUpdateWhere.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listUpdateWhere.Size = new System.Drawing.Size(189, 100);
            this.listUpdateWhere.Sorted = true;
            this.listUpdateWhere.TabIndex = 31;
            this.listUpdateWhere.Click += new System.EventHandler(this.listUpdateWhere_SelectedIndexChanged);
            this.listUpdateWhere.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listUpdateWhere_MouseDown);
            // 
            // listUpdateSelect
            // 
            this.listUpdateSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.listUpdateSelect.FormattingEnabled = true;
            this.listUpdateSelect.ItemHeight = 12;
            this.listUpdateSelect.Location = new System.Drawing.Point(23, 67);
            this.listUpdateSelect.Name = "listUpdateSelect";
            this.listUpdateSelect.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listUpdateSelect.Size = new System.Drawing.Size(189, 88);
            this.listUpdateSelect.Sorted = true;
            this.listUpdateSelect.TabIndex = 29;
            this.listUpdateSelect.Click += new System.EventHandler(this.listUpdateSelect_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(20, 178);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(134, 13);
            this.label16.TabIndex = 34;
            this.label16.Text = "Filter Fields (Where clause):";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(20, 50);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 13);
            this.label17.TabIndex = 33;
            this.label17.Text = "Update Fields:";
            // 
            // tablSPDelete
            // 
            this.tablSPDelete.Controls.Add(this.lblMsgDeleteDetails);
            this.tablSPDelete.Controls.Add(this.button5);
            this.tablSPDelete.Controls.Add(this.rtbDeleteSP);
            this.tablSPDelete.Controls.Add(this.lblMsgDelete);
            this.tablSPDelete.Controls.Add(this.cmdDeleteCopy);
            this.tablSPDelete.Controls.Add(this.cmdDeletePublish);
            this.tablSPDelete.Controls.Add(this.txtDeleteSPName);
            this.tablSPDelete.Controls.Add(this.label18);
            this.tablSPDelete.Controls.Add(this.label19);
            this.tablSPDelete.Controls.Add(this.listDeleteWhere);
            this.tablSPDelete.Controls.Add(this.label20);
            this.tablSPDelete.Location = new System.Drawing.Point(4, 22);
            this.tablSPDelete.Name = "tablSPDelete";
            this.tablSPDelete.Size = new System.Drawing.Size(771, 356);
            this.tablSPDelete.TabIndex = 4;
            this.tablSPDelete.Text = "Delete Stored Procedures";
            this.tablSPDelete.UseVisualStyleBackColor = true;
            // 
            // lblMsgDeleteDetails
            // 
            this.lblMsgDeleteDetails.AutoSize = true;
            this.lblMsgDeleteDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblMsgDeleteDetails.ForeColor = System.Drawing.Color.Firebrick;
            this.lblMsgDeleteDetails.Location = new System.Drawing.Point(24, 335);
            this.lblMsgDeleteDetails.Name = "lblMsgDeleteDetails";
            this.lblMsgDeleteDetails.Size = new System.Drawing.Size(23, 13);
            this.lblMsgDeleteDetails.TabIndex = 57;
            this.lblMsgDeleteDetails.Text = "lallll";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(425, 319);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 29);
            this.button5.TabIndex = 56;
            this.button5.Text = "&Test";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // rtbDeleteSP
            // 
            this.rtbDeleteSP.Location = new System.Drawing.Point(239, 67);
            this.rtbDeleteSP.Name = "rtbDeleteSP";
            this.rtbDeleteSP.Size = new System.Drawing.Size(518, 235);
            this.rtbDeleteSP.TabIndex = 51;
            this.rtbDeleteSP.Text = "";
            this.rtbDeleteSP.WordWrap = false;
            // 
            // lblMsgDelete
            // 
            this.lblMsgDelete.AutoSize = true;
            this.lblMsgDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblMsgDelete.ForeColor = System.Drawing.Color.Firebrick;
            this.lblMsgDelete.Location = new System.Drawing.Point(24, 319);
            this.lblMsgDelete.Name = "lblMsgDelete";
            this.lblMsgDelete.Size = new System.Drawing.Size(23, 13);
            this.lblMsgDelete.TabIndex = 45;
            this.lblMsgDelete.Text = "lallll";
            // 
            // cmdDeleteCopy
            // 
            this.cmdDeleteCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.cmdDeleteCopy.Location = new System.Drawing.Point(506, 319);
            this.cmdDeleteCopy.Name = "cmdDeleteCopy";
            this.cmdDeleteCopy.Size = new System.Drawing.Size(122, 29);
            this.cmdDeleteCopy.TabIndex = 44;
            this.cmdDeleteCopy.Text = "&Copy to Clipboard";
            this.cmdDeleteCopy.UseVisualStyleBackColor = true;
            this.cmdDeleteCopy.Click += new System.EventHandler(this.cmdDeleteCopy_Click);
            // 
            // cmdDeletePublish
            // 
            this.cmdDeletePublish.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.cmdDeletePublish.Location = new System.Drawing.Point(634, 319);
            this.cmdDeletePublish.Name = "cmdDeletePublish";
            this.cmdDeletePublish.Size = new System.Drawing.Size(110, 29);
            this.cmdDeletePublish.TabIndex = 43;
            this.cmdDeletePublish.Text = "&Publish";
            this.cmdDeletePublish.UseVisualStyleBackColor = true;
            this.cmdDeletePublish.Click += new System.EventHandler(this.cmdDeletePublish_Click);
            // 
            // txtDeleteSPName
            // 
            this.txtDeleteSPName.Location = new System.Drawing.Point(108, 20);
            this.txtDeleteSPName.Name = "txtDeleteSPName";
            this.txtDeleteSPName.Size = new System.Drawing.Size(651, 20);
            this.txtDeleteSPName.TabIndex = 42;
            this.txtDeleteSPName.TextChanged += new System.EventHandler(this.txtDeleteSPName_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.label18.Location = new System.Drawing.Point(20, 23);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(81, 13);
            this.label18.TabIndex = 41;
            this.label18.Text = "Name for SP:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(234, 51);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(58, 13);
            this.label19.TabIndex = 40;
            this.label19.Text = "Delete SP:";
            // 
            // listDeleteWhere
            // 
            this.listDeleteWhere.ContextMenuStrip = this.cmnuCriteria;
            this.listDeleteWhere.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.listDeleteWhere.FormattingEnabled = true;
            this.listDeleteWhere.ItemHeight = 12;
            this.listDeleteWhere.Location = new System.Drawing.Point(23, 67);
            this.listDeleteWhere.Name = "listDeleteWhere";
            this.listDeleteWhere.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listDeleteWhere.Size = new System.Drawing.Size(189, 232);
            this.listDeleteWhere.Sorted = true;
            this.listDeleteWhere.TabIndex = 38;
            this.listDeleteWhere.Click += new System.EventHandler(this.listDeleteWhere_SelectedIndexChanged);
            this.listDeleteWhere.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listDeleteWhere_MouseDown);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(20, 50);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(62, 13);
            this.label20.TabIndex = 37;
            this.label20.Text = "Filter Fields:";
            // 
            // tabTablecomplete
            // 
            this.tabTablecomplete.Controls.Add(this.lblMsgDefaultsDetails);
            this.tabTablecomplete.Controls.Add(this.cmdDefaultSPGenerate);
            this.tabTablecomplete.Controls.Add(this.label23);
            this.tabTablecomplete.Controls.Add(this.treeDefaultSPOptions);
            this.tabTablecomplete.Controls.Add(this.rtbDefaultSPs);
            this.tabTablecomplete.Controls.Add(this.lblMsgDefaults);
            this.tabTablecomplete.Controls.Add(this.cmdDefaultClipboard);
            this.tabTablecomplete.Controls.Add(this.cmdDefaultPublish);
            this.tabTablecomplete.Controls.Add(this.label25);
            this.tabTablecomplete.Location = new System.Drawing.Point(4, 22);
            this.tabTablecomplete.Name = "tabTablecomplete";
            this.tabTablecomplete.Padding = new System.Windows.Forms.Padding(3);
            this.tabTablecomplete.Size = new System.Drawing.Size(771, 356);
            this.tabTablecomplete.TabIndex = 5;
            this.tabTablecomplete.Text = "Default Table Procedures";
            this.tabTablecomplete.UseVisualStyleBackColor = true;
            // 
            // lblMsgDefaultsDetails
            // 
            this.lblMsgDefaultsDetails.AutoSize = true;
            this.lblMsgDefaultsDetails.ForeColor = System.Drawing.Color.Firebrick;
            this.lblMsgDefaultsDetails.Location = new System.Drawing.Point(21, 329);
            this.lblMsgDefaultsDetails.Name = "lblMsgDefaultsDetails";
            this.lblMsgDefaultsDetails.Size = new System.Drawing.Size(23, 13);
            this.lblMsgDefaultsDetails.TabIndex = 67;
            this.lblMsgDefaultsDetails.Text = "lallll";
            // 
            // cmdDefaultSPGenerate
            // 
            this.cmdDefaultSPGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.cmdDefaultSPGenerate.Location = new System.Drawing.Point(68, 271);
            this.cmdDefaultSPGenerate.Name = "cmdDefaultSPGenerate";
            this.cmdDefaultSPGenerate.Size = new System.Drawing.Size(143, 29);
            this.cmdDefaultSPGenerate.TabIndex = 66;
            this.cmdDefaultSPGenerate.Text = "&Generate Default SP\'s";
            this.cmdDefaultSPGenerate.UseVisualStyleBackColor = true;
            this.cmdDefaultSPGenerate.Click += new System.EventHandler(this.cmdDefaultSPGenerate_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(21, 17);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(46, 13);
            this.label23.TabIndex = 65;
            this.label23.Text = "Options:";
            // 
            // treeDefaultSPOptions
            // 
            this.treeDefaultSPOptions.ImageIndex = 1;
            this.treeDefaultSPOptions.Location = new System.Drawing.Point(23, 33);
            this.treeDefaultSPOptions.Name = "treeDefaultSPOptions";
            treeNode1.Name = "nodeSelectsEverything";
            treeNode1.Text = "Select All Rows";
            treeNode2.Name = "nodeSelectsPK";
            treeNode2.Text = "Select By PK";
            treeNode3.Name = "nodeSelectsIndexes";
            treeNode3.Text = "Select By Indexes";
            treeNode4.Name = "nodeSelectsFK";
            treeNode4.Text = "Select By FK";
            treeNode5.Name = "nodeSelectsAll";
            treeNode5.Text = "All Selects";
            treeNode6.Name = "nodeInsertsPK";
            treeNode6.Text = "Insert By PK";
            treeNode7.Name = "nodeInsertsIdentity";
            treeNode7.Text = "Identity Insert";
            treeNode8.Name = "nodeInserts";
            treeNode8.Text = "All Inserts";
            treeNode9.Name = "nodeUpdates";
            treeNode9.Text = "All Updates";
            treeNode10.Name = "nodeDeletes";
            treeNode10.Text = "All Deletes";
            treeNode11.Name = "nodeAll";
            treeNode11.Text = "All Types";
            this.treeDefaultSPOptions.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode11});
            this.treeDefaultSPOptions.SelectedImageIndex = 1;
            this.treeDefaultSPOptions.Size = new System.Drawing.Size(188, 223);
            this.treeDefaultSPOptions.TabIndex = 64;
            this.treeDefaultSPOptions.UseVisualStyles = false;
            // 
            // rtbDefaultSPs
            // 
            this.rtbDefaultSPs.Location = new System.Drawing.Point(240, 33);
            this.rtbDefaultSPs.Name = "rtbDefaultSPs";
            this.rtbDefaultSPs.ReadOnly = true;
            this.rtbDefaultSPs.Size = new System.Drawing.Size(517, 274);
            this.rtbDefaultSPs.TabIndex = 63;
            this.rtbDefaultSPs.Text = "";
            this.rtbDefaultSPs.WordWrap = false;
            // 
            // lblMsgDefaults
            // 
            this.lblMsgDefaults.AutoSize = true;
            this.lblMsgDefaults.ForeColor = System.Drawing.Color.Firebrick;
            this.lblMsgDefaults.Location = new System.Drawing.Point(20, 313);
            this.lblMsgDefaults.Name = "lblMsgDefaults";
            this.lblMsgDefaults.Size = new System.Drawing.Size(23, 13);
            this.lblMsgDefaults.TabIndex = 62;
            this.lblMsgDefaults.Text = "lallll";
            // 
            // cmdDefaultClipboard
            // 
            this.cmdDefaultClipboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.cmdDefaultClipboard.Location = new System.Drawing.Point(506, 316);
            this.cmdDefaultClipboard.Name = "cmdDefaultClipboard";
            this.cmdDefaultClipboard.Size = new System.Drawing.Size(134, 29);
            this.cmdDefaultClipboard.TabIndex = 61;
            this.cmdDefaultClipboard.Text = "&Copy to Clipboard";
            this.cmdDefaultClipboard.UseVisualStyleBackColor = true;
            this.cmdDefaultClipboard.Click += new System.EventHandler(this.cmdDefaultCopy_Click);
            // 
            // cmdDefaultPublish
            // 
            this.cmdDefaultPublish.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.cmdDefaultPublish.Location = new System.Drawing.Point(647, 316);
            this.cmdDefaultPublish.Name = "cmdDefaultPublish";
            this.cmdDefaultPublish.Size = new System.Drawing.Size(110, 29);
            this.cmdDefaultPublish.TabIndex = 60;
            this.cmdDefaultPublish.Text = "&Publish";
            this.cmdDefaultPublish.UseVisualStyleBackColor = true;
            this.cmdDefaultPublish.Click += new System.EventHandler(this.cmdDefaultPublish_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(237, 17);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(68, 13);
            this.label25.TabIndex = 57;
            this.label25.Text = "Default SP\'s:";
            // 
            // cboTables
            // 
            this.cboTables.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbTableParametersBindingSource, "Table", true));
            this.cboTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTables.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.cboTables.FormattingEnabled = true;
            this.cboTables.Location = new System.Drawing.Point(51, 51);
            this.cboTables.Name = "cboTables";
            this.cboTables.Size = new System.Drawing.Size(292, 20);
            this.cboTables.TabIndex = 4;
            this.cboTables.SelectedIndexChanged += new System.EventHandler(this.ConnectionItemChanged);
            this.cboTables.TextChanged += new System.EventHandler(this.TableName_TextChanged);
            this.cboTables.LostFocus += new System.EventHandler(this.ConnectionItemChanged);
            // 
            // dbTableParametersBindingSource
            // 
            this.dbTableParametersBindingSource.DataSource = typeof(DS.SPGenerator.genCore.dbTableParameters);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label5.Location = new System.Drawing.Point(11, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Table:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label4.Location = new System.Drawing.Point(14, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Database:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label3.Location = new System.Drawing.Point(14, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Server:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlUserAuth);
            this.groupBox1.Controls.Add(this.chkWindowsAuthentication);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.groupBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Location = new System.Drawing.Point(29, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 76);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Authentication / Authorization";
            // 
            // pnlUserAuth
            // 
            this.pnlUserAuth.Controls.Add(this.label2);
            this.pnlUserAuth.Controls.Add(this.label1);
            this.pnlUserAuth.Controls.Add(this.txtUserName);
            this.pnlUserAuth.Controls.Add(this.txtPassword);
            this.pnlUserAuth.ForeColor = System.Drawing.Color.Black;
            this.pnlUserAuth.Location = new System.Drawing.Point(143, 19);
            this.pnlUserAuth.Name = "pnlUserAuth";
            this.pnlUserAuth.Size = new System.Drawing.Size(189, 46);
            this.pnlUserAuth.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label2.Location = new System.Drawing.Point(6, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label1.Location = new System.Drawing.Point(7, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Password:";
            // 
            // txtUserName
            // 
            this.txtUserName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbTableParametersBindingSource, "User", true));
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.txtUserName.Location = new System.Drawing.Point(69, 3);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(106, 18);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.TextChanged += new System.EventHandler(this.ConnectionItemChanged);
            this.txtUserName.LostFocus += new System.EventHandler(this.ConnectionItemChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbTableParametersBindingSource, "Password", true));
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.txtPassword.Location = new System.Drawing.Point(69, 24);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(106, 18);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.ConnectionItemChanged);
            this.txtPassword.LostFocus += new System.EventHandler(this.ConnectionItemChanged);
            // 
            // chkWindowsAuthentication
            // 
            this.chkWindowsAuthentication.AutoSize = true;
            this.chkWindowsAuthentication.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.dbTableParametersBindingSource, "UseWindowsAuthentication", true));
            this.chkWindowsAuthentication.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.chkWindowsAuthentication.ForeColor = System.Drawing.Color.Black;
            this.chkWindowsAuthentication.Location = new System.Drawing.Point(16, 19);
            this.chkWindowsAuthentication.Name = "chkWindowsAuthentication";
            this.chkWindowsAuthentication.Size = new System.Drawing.Size(165, 17);
            this.chkWindowsAuthentication.TabIndex = 0;
            this.chkWindowsAuthentication.Text = "Use Integrated Authentication";
            this.chkWindowsAuthentication.UseVisualStyleBackColor = true;
            this.chkWindowsAuthentication.CheckedChanged += new System.EventHandler(this.chkWindowsAuthentication_CheckedChanged);
            this.chkWindowsAuthentication.LostFocus += new System.EventHandler(this.ConnectionItemChanged);
            // 
            // cboDatabases
            // 
            this.cboDatabases.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbTableParametersBindingSource, "DatabaseName", true));
            this.cboDatabases.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.cboDatabases.FormattingEnabled = true;
            this.cboDatabases.Location = new System.Drawing.Point(80, 44);
            this.cboDatabases.Name = "cboDatabases";
            this.cboDatabases.Size = new System.Drawing.Size(243, 20);
            this.cboDatabases.TabIndex = 2;
            this.cboDatabases.SelectedIndexChanged += new System.EventHandler(this.ConnectionItemChanged);
            this.cboDatabases.TextChanged += new System.EventHandler(this.ConnectionItemChanged);
            this.cboDatabases.Leave += new System.EventHandler(this.cboDatabases_Leave);
            this.cboDatabases.LostFocus += new System.EventHandler(this.ConnectionItemChanged);
            // 
            // cboServers
            // 
            this.cboServers.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbTableParametersBindingSource, "Server", true));
            this.cboServers.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.cboServers.FormattingEnabled = true;
            this.cboServers.Location = new System.Drawing.Point(80, 21);
            this.cboServers.Name = "cboServers";
            this.cboServers.Size = new System.Drawing.Size(243, 20);
            this.cboServers.TabIndex = 0;
            this.cboServers.SelectedIndexChanged += new System.EventHandler(this.ConnectionItemChanged);
            this.cboServers.TextChanged += new System.EventHandler(this.ConnectionItemChanged);
            this.cboServers.Leave += new System.EventHandler(this.cboServers_Leave);
            this.cboServers.LostFocus += new System.EventHandler(this.ConnectionItemChanged);
            // 
            // tmrMsg
            // 
            this.tmrMsg.Interval = 5000;
            this.tmrMsg.Tick += new System.EventHandler(this.tmrMsg_Tick);
            // 
            // tmrStretch
            // 
            this.tmrStretch.Interval = 10;
            this.tmrStretch.Tick += new System.EventHandler(this.tmrStretch_Tick);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label21.Location = new System.Drawing.Point(31, 66);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(92, 13);
            this.label21.TabIndex = 15;
            this.label21.Text = "Stored Procedure:";
            // 
            // cboSP
            // 
            this.cboSP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbTableParametersBindingSource, "Table", true));
            this.cboSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.cboSP.FormattingEnabled = true;
            this.cboSP.Location = new System.Drawing.Point(126, 55);
            this.cboSP.Name = "cboSP";
            this.cboSP.Size = new System.Drawing.Size(292, 20);
            this.cboSP.TabIndex = 5;
            this.cboSP.SelectedIndexChanged += new System.EventHandler(this.cboSP_SelectedIndexChanged);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Location = new System.Drawing.Point(9, 86);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(765, 378);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rt2);
            this.tabPage1.Controls.Add(this.txtCode);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(757, 352);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = ".Net Code Gen ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rt2
            // 
            this.rt2.Font = new System.Drawing.Font("Courier New", 8F);
            this.rt2.Location = new System.Drawing.Point(640, 6);
            this.rt2.Name = "rt2";
            this.rt2.Size = new System.Drawing.Size(100, 23);
            this.rt2.TabIndex = 54;
            this.rt2.Text = "";
            this.rt2.Visible = false;
            this.rt2.WordWrap = false;
            // 
            // txtCode
            // 
            this.txtCode.Font = new System.Drawing.Font("Courier New", 8F);
            this.txtCode.Location = new System.Drawing.Point(280, 38);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(460, 296);
            this.txtCode.TabIndex = 53;
            this.txtCode.Text = "";
            this.txtCode.WordWrap = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(277, 19);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(99, 13);
            this.label22.TabIndex = 52;
            this.label22.Text = "Data Access Code:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.grpADOMethodType);
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Controls.Add(this.button2);
            this.groupBox5.Controls.Add(this.groupBox4);
            this.groupBox5.Controls.Add(this.groupBox3);
            this.groupBox5.Location = new System.Drawing.Point(16, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(255, 315);
            this.groupBox5.TabIndex = 51;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Code Options:";
            // 
            // grpADOMethodType
            // 
            this.grpADOMethodType.Controls.Add(this.chkUseScalar);
            this.grpADOMethodType.Controls.Add(this.chkUseDataReader);
            this.grpADOMethodType.Controls.Add(this.chkUseNonQuery);
            this.grpADOMethodType.Controls.Add(this.chkUseDataSet);
            this.grpADOMethodType.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpADOMethodType.Location = new System.Drawing.Point(8, 148);
            this.grpADOMethodType.Name = "grpADOMethodType";
            this.grpADOMethodType.Size = new System.Drawing.Size(115, 129);
            this.grpADOMethodType.TabIndex = 53;
            this.grpADOMethodType.TabStop = false;
            this.grpADOMethodType.Text = "ADO Call Type";
            // 
            // chkUseScalar
            // 
            this.chkUseScalar.AutoSize = true;
            this.chkUseScalar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUseScalar.Location = new System.Drawing.Point(14, 90);
            this.chkUseScalar.Name = "chkUseScalar";
            this.chkUseScalar.Size = new System.Drawing.Size(79, 16);
            this.chkUseScalar.TabIndex = 56;
            this.chkUseScalar.Text = "Scalar Result";
            this.chkUseScalar.UseVisualStyleBackColor = true;
            this.chkUseScalar.CheckedChanged += new System.EventHandler(this.chkUseScalar_CheckedChanged);
            // 
            // chkUseDataReader
            // 
            this.chkUseDataReader.AutoSize = true;
            this.chkUseDataReader.Checked = true;
            this.chkUseDataReader.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseDataReader.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUseDataReader.Location = new System.Drawing.Point(14, 28);
            this.chkUseDataReader.Name = "chkUseDataReader";
            this.chkUseDataReader.Size = new System.Drawing.Size(93, 16);
            this.chkUseDataReader.TabIndex = 53;
            this.chkUseDataReader.Text = "Use DataReader";
            this.chkUseDataReader.UseVisualStyleBackColor = true;
            this.chkUseDataReader.CheckedChanged += new System.EventHandler(this.chkUseDataReader_CheckedChanged);
            // 
            // chkUseNonQuery
            // 
            this.chkUseNonQuery.AutoSize = true;
            this.chkUseNonQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUseNonQuery.Location = new System.Drawing.Point(14, 69);
            this.chkUseNonQuery.Name = "chkUseNonQuery";
            this.chkUseNonQuery.Size = new System.Drawing.Size(66, 16);
            this.chkUseNonQuery.TabIndex = 55;
            this.chkUseNonQuery.Text = "NonQuery";
            this.chkUseNonQuery.UseVisualStyleBackColor = true;
            this.chkUseNonQuery.CheckedChanged += new System.EventHandler(this.chkUseList_CheckedChanged);
            // 
            // chkUseDataSet
            // 
            this.chkUseDataSet.AutoSize = true;
            this.chkUseDataSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUseDataSet.Location = new System.Drawing.Point(14, 48);
            this.chkUseDataSet.Name = "chkUseDataSet";
            this.chkUseDataSet.Size = new System.Drawing.Size(77, 16);
            this.chkUseDataSet.TabIndex = 54;
            this.chkUseDataSet.Text = "Use DataSet";
            this.chkUseDataSet.UseVisualStyleBackColor = true;
            this.chkUseDataSet.CheckedChanged += new System.EventHandler(this.chkUseDataSet_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.checkBox1);
            this.groupBox6.Controls.Add(this.checkBox2);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic);
            this.groupBox6.Location = new System.Drawing.Point(129, 110);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(115, 63);
            this.groupBox6.TabIndex = 52;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Generate Helpers";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(14, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(69, 16);
            this.checkBox1.TabIndex = 47;
            this.checkBox1.Text = "SQLHelper";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.Location = new System.Drawing.Point(14, 40);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(80, 16);
            this.checkBox2.TabIndex = 48;
            this.checkBox2.Text = "SPOIL Helper";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(133, 207);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 43);
            this.button3.TabIndex = 47;
            this.button3.Text = "&Generate Code";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(133, 256);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 46);
            this.button2.TabIndex = 48;
            this.button2.Text = "Copy To &Clipboard";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdoVB);
            this.groupBox4.Controls.Add(this.rdoCSharp);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic);
            this.groupBox4.Location = new System.Drawing.Point(127, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(117, 76);
            this.groupBox4.TabIndex = 51;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Language";
            // 
            // rdoVB
            // 
            this.rdoVB.AutoSize = true;
            this.rdoVB.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoVB.Location = new System.Drawing.Point(14, 43);
            this.rdoVB.Name = "rdoVB";
            this.rdoVB.Size = new System.Drawing.Size(54, 16);
            this.rdoVB.TabIndex = 1;
            this.rdoVB.Text = "VB.Net";
            this.rdoVB.UseVisualStyleBackColor = true;
            // 
            // rdoCSharp
            // 
            this.rdoCSharp.AutoSize = true;
            this.rdoCSharp.Checked = true;
            this.rdoCSharp.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoCSharp.Location = new System.Drawing.Point(15, 25);
            this.rdoCSharp.Name = "rdoCSharp";
            this.rdoCSharp.Size = new System.Drawing.Size(35, 16);
            this.rdoCSharp.TabIndex = 0;
            this.rdoCSharp.TabStop = true;
            this.rdoCSharp.Text = "C#";
            this.rdoCSharp.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdoTiersMultiple);
            this.groupBox3.Controls.Add(this.rdoTiersSingle);
            this.groupBox3.Controls.Add(this.rdoStandardADO);
            this.groupBox3.Controls.Add(this.rdoSpoil);
            this.groupBox3.Controls.Add(this.rdoADO);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic);
            this.groupBox3.Location = new System.Drawing.Point(8, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(115, 113);
            this.groupBox3.TabIndex = 50;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Access Type";
            // 
            // rdoTiersMultiple
            // 
            this.rdoTiersMultiple.AutoSize = true;
            this.rdoTiersMultiple.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoTiersMultiple.Location = new System.Drawing.Point(17, 84);
            this.rdoTiersMultiple.Name = "rdoTiersMultiple";
            this.rdoTiersMultiple.Size = new System.Drawing.Size(91, 16);
            this.rdoTiersMultiple.TabIndex = 4;
            this.rdoTiersMultiple.Text = "Tiers - Collection";
            this.rdoTiersMultiple.UseVisualStyleBackColor = true;
            // 
            // rdoTiersSingle
            // 
            this.rdoTiersSingle.AutoSize = true;
            this.rdoTiersSingle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoTiersSingle.Location = new System.Drawing.Point(17, 68);
            this.rdoTiersSingle.Name = "rdoTiersSingle";
            this.rdoTiersSingle.Size = new System.Drawing.Size(75, 16);
            this.rdoTiersSingle.TabIndex = 3;
            this.rdoTiersSingle.Text = "Tiers - Single";
            this.rdoTiersSingle.UseVisualStyleBackColor = true;
            this.rdoTiersSingle.CheckedChanged += new System.EventHandler(this.rdoTiersSingle_CheckedChanged);
            // 
            // rdoStandardADO
            // 
            this.rdoStandardADO.AutoSize = true;
            this.rdoStandardADO.Checked = true;
            this.rdoStandardADO.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoStandardADO.Location = new System.Drawing.Point(17, 19);
            this.rdoStandardADO.Name = "rdoStandardADO";
            this.rdoStandardADO.Size = new System.Drawing.Size(62, 16);
            this.rdoStandardADO.TabIndex = 2;
            this.rdoStandardADO.TabStop = true;
            this.rdoStandardADO.Text = "ADO.Net";
            this.rdoStandardADO.UseVisualStyleBackColor = true;
            this.rdoStandardADO.CheckedChanged += new System.EventHandler(this.rdoStandardADO_CheckedChanged);
            // 
            // rdoSpoil
            // 
            this.rdoSpoil.AutoSize = true;
            this.rdoSpoil.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSpoil.Location = new System.Drawing.Point(17, 52);
            this.rdoSpoil.Name = "rdoSpoil";
            this.rdoSpoil.Size = new System.Drawing.Size(43, 16);
            this.rdoSpoil.TabIndex = 1;
            this.rdoSpoil.Text = "Spoil";
            this.rdoSpoil.UseVisualStyleBackColor = true;
            this.rdoSpoil.CheckedChanged += new System.EventHandler(this.rdoSpoil_CheckedChanged);
            // 
            // rdoADO
            // 
            this.rdoADO.AutoSize = true;
            this.rdoADO.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoADO.Location = new System.Drawing.Point(17, 35);
            this.rdoADO.Name = "rdoADO";
            this.rdoADO.Size = new System.Drawing.Size(88, 16);
            this.rdoADO.TabIndex = 0;
            this.rdoADO.Text = "ADO Ent. Block";
            this.rdoADO.UseVisualStyleBackColor = true;
            this.rdoADO.CheckedChanged += new System.EventHandler(this.rdoADO_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button7);
            this.tabPage2.Controls.Add(this.button6);
            this.tabPage2.Controls.Add(this.txtSPText);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(757, 352);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "View Stored Procedure";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(366, 319);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(181, 23);
            this.button7.TabIndex = 2;
            this.button7.Text = "Client Performance Analysis";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(563, 319);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(181, 23);
            this.button6.TabIndex = 1;
            this.button6.Text = "Test Stored Procedure";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // txtSPText
            // 
            this.txtSPText.Location = new System.Drawing.Point(7, 23);
            this.txtSPText.Name = "txtSPText";
            this.txtSPText.Size = new System.Drawing.Size(737, 286);
            this.txtSPText.TabIndex = 0;
            this.txtSPText.Text = "";
            this.txtSPText.WordWrap = false;
            // 
            // xpgMain
            // 
            this.xpgMain.AutoScroll = true;
            this.xpgMain.BackColor = System.Drawing.Color.Transparent;
            this.xpgMain.Controls.Add(this.xppDataAccess);
            this.xpgMain.Controls.Add(this.xppSPGenerator);
            this.xpgMain.Controls.Add(this.xppConnection);
            this.xpgMain.Location = new System.Drawing.Point(1, 4);
            this.xpgMain.Name = "xpgMain";
            this.xpgMain.PanelGradient = ((UIComponents.GradientColor)(resources.GetObject("xpgMain.PanelGradient")));
            this.xpgMain.Size = new System.Drawing.Size(809, 719);
            this.xpgMain.TabIndex = 10;
            // 
            // xppDataAccess
            // 
            this.xppDataAccess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xppDataAccess.AnimationRate = 1;
            this.xppDataAccess.BackColor = System.Drawing.Color.Transparent;
            this.xppDataAccess.Caption = ".NET Code Generation";
            this.xppDataAccess.CaptionCornerType = ((UIComponents.CornerType)((((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight) 
            | UIComponents.CornerType.BottomLeft) 
            | UIComponents.CornerType.BottomRight)));
            this.xppDataAccess.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.xppDataAccess.CaptionGradient.Start = System.Drawing.Color.White;
            this.xppDataAccess.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xppDataAccess.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xppDataAccess.Controls.Add(this.expandingButton3);
            this.xppDataAccess.Controls.Add(this.pictureBox1);
            this.xppDataAccess.Controls.Add(this.tabControl2);
            this.xppDataAccess.Controls.Add(this.label21);
            this.xppDataAccess.Controls.Add(this.cboSP);
            this.xppDataAccess.CurveRadius = 15;
            this.xppDataAccess.ExpandedGlyphs.ImageSet = this.imageSet1;
            this.xppDataAccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.xppDataAccess.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xppDataAccess.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xppDataAccess.ImageItems.ImageSet = null;
            this.xppDataAccess.Location = new System.Drawing.Point(8, 648);
            this.xppDataAccess.Name = "xppDataAccess";
            this.xppDataAccess.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xppDataAccess.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xppDataAccess.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xppDataAccess.PanelState = UIComponents.XPPanelState.Collapsed;
            this.xppDataAccess.Size = new System.Drawing.Size(793, 33);
            this.xppDataAccess.TabIndex = 2;
            this.xppDataAccess.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.xppDataAccess.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.xppDataAccess.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xppDataAccess.Collapsed += new System.EventHandler(this.xpPanels_Changed);
            this.xppDataAccess.Collapsing += new System.EventHandler(this.xpPanels_Changing);
            this.xppDataAccess.Expanding += new System.EventHandler(this.xpPanels_Changing);
            this.xppDataAccess.Expanded += new System.EventHandler(this.xpPanels_Changed);
            this.xppDataAccess.Click += new System.EventHandler(this.xpPanel_Click);
            // 
            // expandingButton3
            // 
            this.expandingButton3.BackColor = System.Drawing.Color.Transparent;
            this.expandingButton3.ButtonText = "Get Stored Procs";
            this.expandingButton3.Image = global::DS.SPGenerator.Properties.Resources.sp;
            this.expandingButton3.Location = new System.Drawing.Point(424, 55);
            this.expandingButton3.Name = "expandingButton3";
            this.expandingButton3.Size = new System.Drawing.Size(22, 22);
            this.expandingButton3.SizeExpanded = 22;
            this.expandingButton3.SizeNormal = 15;
            this.expandingButton3.TabIndex = 32;
            this.expandingButton3.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::DS.SPGenerator.Properties.Resources.dakotaSoftware;
            this.pictureBox1.Location = new System.Drawing.Point(564, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(206, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.nexxusPictureBox_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.nexxusPictureBox_MouseLeave);
            // 
            // imageSet1
            // 
            this.imageSet1.Images.AddRange(new System.Drawing.Image[] {
            ((System.Drawing.Image)(resources.GetObject("imageSet1.Images")))});
            this.imageSet1.Size = new System.Drawing.Size(1000, 147);
            this.imageSet1.TransparentColor = System.Drawing.Color.Empty;
            // 
            // xppSPGenerator
            // 
            this.xppSPGenerator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xppSPGenerator.AnimationRate = 1;
            this.xppSPGenerator.BackColor = System.Drawing.Color.Transparent;
            this.xppSPGenerator.Caption = "Simple Stored Procedure Generator";
            this.xppSPGenerator.CaptionCornerType = UIComponents.CornerType.TopRight;
            this.xppSPGenerator.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.xppSPGenerator.CaptionGradient.Start = System.Drawing.Color.White;
            this.xppSPGenerator.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xppSPGenerator.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xppSPGenerator.Controls.Add(this.xbtnShowComplexGenerator);
            this.xppSPGenerator.Controls.Add(this.expandingButton2);
            this.xppSPGenerator.Controls.Add(this.pictureBox2);
            this.xppSPGenerator.Controls.Add(this.tabAll);
            this.xppSPGenerator.Controls.Add(this.cboTables);
            this.xppSPGenerator.Controls.Add(this.label5);
            this.xppSPGenerator.CurveRadius = 15;
            this.xppSPGenerator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.xppSPGenerator.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xppSPGenerator.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xppSPGenerator.ImageItems.ImageSet = null;
            this.xppSPGenerator.Location = new System.Drawing.Point(8, 168);
            this.xppSPGenerator.Name = "xppSPGenerator";
            this.xppSPGenerator.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xppSPGenerator.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xppSPGenerator.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xppSPGenerator.Size = new System.Drawing.Size(793, 472);
            this.xppSPGenerator.TabIndex = 1;
            this.xppSPGenerator.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.xppSPGenerator.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.xppSPGenerator.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xppSPGenerator.Collapsed += new System.EventHandler(this.xpPanels_Changed);
            this.xppSPGenerator.Collapsing += new System.EventHandler(this.xpPanels_Changing);
            this.xppSPGenerator.Expanding += new System.EventHandler(this.xpPanels_Changing);
            this.xppSPGenerator.Expanded += new System.EventHandler(this.xpPanels_Changed);
            this.xppSPGenerator.Click += new System.EventHandler(this.xpPanel_Click);
            // 
            // xbtnShowComplexGenerator
            // 
            this.xbtnShowComplexGenerator.BackColor = System.Drawing.Color.Transparent;
            this.xbtnShowComplexGenerator.ButtonText = "Generate Complex SP";
            this.xbtnShowComplexGenerator.Image = global::DS.SPGenerator.Properties.Resources.SQLWizard;
            this.xbtnShowComplexGenerator.Location = new System.Drawing.Point(379, 51);
            this.xbtnShowComplexGenerator.Name = "xbtnShowComplexGenerator";
            this.xbtnShowComplexGenerator.Size = new System.Drawing.Size(22, 22);
            this.xbtnShowComplexGenerator.SizeExpanded = 22;
            this.xbtnShowComplexGenerator.SizeNormal = 20;
            this.xbtnShowComplexGenerator.TabIndex = 35;
            this.xbtnShowComplexGenerator.Load += new System.EventHandler(this.xbtnShowComplexGenerator_Load);
            this.xbtnShowComplexGenerator.Click += new System.EventHandler(this.xbtnShowComplexGenerator_Click);
            // 
            // expandingButton2
            // 
            this.expandingButton2.BackColor = System.Drawing.Color.Transparent;
            this.expandingButton2.ButtonText = "Get Tables";
            this.expandingButton2.Image = global::DS.SPGenerator.Properties.Resources.tables;
            this.expandingButton2.Location = new System.Drawing.Point(352, 51);
            this.expandingButton2.Name = "expandingButton2";
            this.expandingButton2.Size = new System.Drawing.Size(22, 22);
            this.expandingButton2.SizeExpanded = 22;
            this.expandingButton2.SizeNormal = 15;
            this.expandingButton2.TabIndex = 32;
            this.expandingButton2.Click += new System.EventHandler(this.expandingButton2_Load);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::DS.SPGenerator.Properties.Resources.dakotaSoftware;
            this.pictureBox2.Location = new System.Drawing.Point(564, 49);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(206, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 34;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.MouseEnter += new System.EventHandler(this.nexxusPictureBox_MouseEnter);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.nexxusPictureBox_MouseLeave);
            // 
            // xppConnection
            // 
            this.xppConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xppConnection.AnimationRate = 0;
            this.xppConnection.BackColor = System.Drawing.Color.Transparent;
            this.xppConnection.Caption = "Connection Information";
            this.xppConnection.CaptionCornerType = UIComponents.CornerType.TopRight;
            this.xppConnection.CaptionGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(247)))));
            this.xppConnection.CaptionGradient.Start = System.Drawing.Color.White;
            this.xppConnection.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xppConnection.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xppConnection.Controls.Add(this.lblConnString);
            this.xppConnection.Controls.Add(this.groupBox7);
            this.xppConnection.Controls.Add(this.groupBox1);
            this.xppConnection.CurveRadius = 15;
            this.xppConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.xppConnection.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xppConnection.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xppConnection.ImageItems.ImageSet = null;
            this.xppConnection.Location = new System.Drawing.Point(8, 8);
            this.xppConnection.Name = "xppConnection";
            this.xppConnection.PanelGradient.End = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xppConnection.PanelGradient.Start = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.xppConnection.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xppConnection.Size = new System.Drawing.Size(793, 152);
            this.xppConnection.TabIndex = 0;
            this.xppConnection.TextColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
            this.xppConnection.TextHighlightColors.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
            this.xppConnection.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xppConnection.Paint += new System.Windows.Forms.PaintEventHandler(this.xppConnection_Paint);
            // 
            // lblConnString
            // 
            this.lblConnString.AutoSize = true;
            this.lblConnString.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblConnString.Location = new System.Drawing.Point(26, 127);
            this.lblConnString.Name = "lblConnString";
            this.lblConnString.Size = new System.Drawing.Size(0, 13);
            this.lblConnString.TabIndex = 11;
            this.lblConnString.DoubleClick += new System.EventHandler(this.lblConnString_DoubleClick);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.expandingButton1);
            this.groupBox7.Controls.Add(this.xcmdGetServers);
            this.groupBox7.Controls.Add(this.cboDatabases);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.cboServers);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.groupBox7.Location = new System.Drawing.Point(379, 45);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(385, 76);
            this.groupBox7.TabIndex = 10;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Server Information";
            // 
            // expandingButton1
            // 
            this.expandingButton1.BackColor = System.Drawing.Color.Transparent;
            this.expandingButton1.ButtonText = "Get Databases";
            this.expandingButton1.Image = global::DS.SPGenerator.Properties.Resources.DataStore;
            this.expandingButton1.Location = new System.Drawing.Point(329, 44);
            this.expandingButton1.Name = "expandingButton1";
            this.expandingButton1.Size = new System.Drawing.Size(22, 22);
            this.expandingButton1.SizeExpanded = 22;
            this.expandingButton1.SizeNormal = 15;
            this.expandingButton1.TabIndex = 32;
            this.expandingButton1.Click += new System.EventHandler(this.expandingButton1_Load);
            // 
            // xcmdGetServers
            // 
            this.xcmdGetServers.BackColor = System.Drawing.Color.Transparent;
            this.xcmdGetServers.ButtonText = "Find Servers";
            this.xcmdGetServers.Image = global::DS.SPGenerator.Properties.Resources.ConnectionOptions;
            this.xcmdGetServers.Location = new System.Drawing.Point(331, 19);
            this.xcmdGetServers.Name = "xcmdGetServers";
            this.xcmdGetServers.Size = new System.Drawing.Size(22, 22);
            this.xcmdGetServers.SizeExpanded = 22;
            this.xcmdGetServers.SizeNormal = 15;
            this.xcmdGetServers.TabIndex = 31;
            this.xcmdGetServers.Click += new System.EventHandler(this.xcmdGetServers_Load);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "OutputOptions.gif");
            this.imageList1.Images.SetKeyName(1, "ConnectionOptions.gif");
            this.imageList1.Images.SetKeyName(2, "DocumentorOptions.gif");
            this.imageList1.Images.SetKeyName(3, "folder2bliz.gif");
            // 
            // tmrMsgDetails
            // 
            this.tmrMsgDetails.Interval = 5000;
            this.tmrMsgDetails.Tick += new System.EventHandler(this.tmrMsgDetails_Tick);
            // 
            // spGenMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 703);
            this.Controls.Add(this.xpgMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "spGenMain";
            this.Text = "SSPCG (Simple Stored Procedure & Code Generator)";
            this.Load += new System.EventHandler(this.spGenMain_Load);
            this.tabAll.ResumeLayout(false);
            this.tabSPTypes.ResumeLayout(false);
            this.tabSPTypes.PerformLayout();
            this.cmnuCriteria.ResumeLayout(false);
            this.cmnuSelect.ResumeLayout(false);
            this.tabSPInsert.ResumeLayout(false);
            this.tabSPInsert.PerformLayout();
            this.tabSPUpdate.ResumeLayout(false);
            this.tabSPUpdate.PerformLayout();
            this.tablSPDelete.ResumeLayout(false);
            this.tablSPDelete.PerformLayout();
            this.tabTablecomplete.ResumeLayout(false);
            this.tabTablecomplete.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbTableParametersBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlUserAuth.ResumeLayout(false);
            this.pnlUserAuth.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.grpADOMethodType.ResumeLayout(false);
            this.grpADOMethodType.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xpgMain)).EndInit();
            this.xpgMain.ResumeLayout(false);
            this.xppDataAccess.ResumeLayout(false);
            this.xppDataAccess.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.xppSPGenerator.ResumeLayout(false);
            this.xppSPGenerator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.xppConnection.ResumeLayout(false);
            this.xppConnection.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabAll;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnlUserAuth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkWindowsAuthentication;
        private System.Windows.Forms.ComboBox cboDatabases;
        private System.Windows.Forms.ComboBox cboServers;
        private System.Windows.Forms.TabPage tabSPTypes;
        private System.Windows.Forms.ComboBox cboTables;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMsgSPTypes;
        private System.Windows.Forms.Timer tmrMsg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabSPInsert;
        private System.Windows.Forms.TabPage tabSPUpdate;
        private System.Windows.Forms.TabPage tablSPDelete;
        private System.Windows.Forms.ListBox listSelectWhere;
        private System.Windows.Forms.ListBox listSelectSelect;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSelectSPName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtInsertSPName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox listInsertSelect;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chkInsertIdentity;
        private System.Windows.Forms.CheckBox chkInsertIdentityReturn;
        private System.Windows.Forms.CheckBox chkSelectDISTINCT;
        private System.Windows.Forms.TextBox txtUpdateSPName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ListBox listUpdateWhere;
        private System.Windows.Forms.ListBox listUpdateSelect;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.BindingSource dbTableParametersBindingSource;
        private System.Windows.Forms.TextBox txtDeleteSPName;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ListBox listDeleteWhere;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button cmdDeleteCopy;
        private System.Windows.Forms.Button cmdDeletePublish;
        private System.Windows.Forms.Button cmdSelectCopy;
        private System.Windows.Forms.Button cmdSelectPublish;
        private System.Windows.Forms.Button cmdInsertCopy;
        private System.Windows.Forms.Button cmdInsertPublish;
        private System.Windows.Forms.Button cmdUpdateCopy;
        private System.Windows.Forms.Button cmdUpdatePublish;
        private System.Windows.Forms.Label lblMsgInsert;
        private System.Windows.Forms.Label lblMsgUpdate;
        private System.Windows.Forms.Label lblMsgDelete;
        private System.Windows.Forms.Timer tmrStretch;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cboSP;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdoVB;
        private System.Windows.Forms.RadioButton rdoCSharp;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdoSpoil;
        private System.Windows.Forms.RadioButton rdoADO;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.RadioButton rdoStandardADO;
        private System.Windows.Forms.CheckBox chkUseDataSet;
        private System.Windows.Forms.CheckBox chkUseDataReader;
        private System.Windows.Forms.CheckBox chkUseNonQuery;
        private System.Windows.Forms.CheckBox chkUseScalar;
        private System.Windows.Forms.GroupBox grpADOMethodType;
        private UIComponents.ExpandingButton xcmdGetServers;
        private UIComponents.ExpandingButton expandingButton1;
        private UIComponents.ExpandingButton expandingButton2;
        private UIComponents.ExpandingButton expandingButton3;
        private UIComponents.XPPanelGroup xpgMain;
        private UIComponents.XPPanel xppConnection;
        private UIComponents.XPPanel xppSPGenerator;
        private System.Windows.Forms.GroupBox groupBox7;
        private UIComponents.XPPanel xppDataAccess;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private UIComponents.ImageSet imageSet1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.RichTextBox rtbSelectSP;
        private System.Windows.Forms.RichTextBox rtbInsertSP;
        private System.Windows.Forms.RichTextBox rtbUpdateSP;
        private System.Windows.Forms.RichTextBox rtbDeleteSP;
        private System.Windows.Forms.RichTextBox txtSPText;
        private System.Windows.Forms.CheckBox chkSelectTop;
        private System.Windows.Forms.TextBox txtTopCount;
        private System.Windows.Forms.ListBox listOrderBy;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button cmdSelectTest;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.RichTextBox txtCode;
        private System.Windows.Forms.RichTextBox rt2;
        private System.Windows.Forms.ContextMenuStrip cmnuCriteria;
        private System.Windows.Forms.ToolStripMenuItem opEQUALTO;
        private System.Windows.Forms.ToolStripMenuItem opGREATERTHAN;
        private System.Windows.Forms.ToolStripMenuItem opGREATERTHANorEQUALTO;
        private System.Windows.Forms.ToolStripMenuItem opLESSTHAN;
        private System.Windows.Forms.ToolStripMenuItem opLESSTHANorEQUALTO;
        private System.Windows.Forms.ToolStripMenuItem opLIKE;
        private System.Windows.Forms.ContextMenuStrip cmnuSelect;
        private System.Windows.Forms.ToolStripMenuItem opClearAll;
        private System.Windows.Forms.ToolStripMenuItem opSelectAll;
        private System.Windows.Forms.ToolStripMenuItem opToggleAll;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.SaveFileDialog HelperSaveDlg;
        private System.Windows.Forms.RadioButton rdoTiersMultiple;
        private System.Windows.Forms.RadioButton rdoTiersSingle;
        private System.Windows.Forms.Label lblConnString;
        private System.Windows.Forms.Button button7;
        private UIComponents.ExpandingButton xbtnShowComplexGenerator;
        private System.Windows.Forms.TabPage tabTablecomplete;
        private System.Windows.Forms.RichTextBox rtbDefaultSPs;
        private System.Windows.Forms.Label lblMsgDefaults;
        private System.Windows.Forms.Button cmdDefaultClipboard;
        private System.Windows.Forms.Button cmdDefaultPublish;
        private System.Windows.Forms.Label label25;
        private UIControls.TreeViews.TriStateTreeView treeDefaultSPOptions;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button cmdDefaultSPGenerate;
        private System.Windows.Forms.Label lblMsgSPTypesDetails;
        private System.Windows.Forms.Timer tmrMsgDetails;
        private System.Windows.Forms.Label lblMsgInsertDetails;
        private System.Windows.Forms.Label lblMsgUpdateDetails;
        private System.Windows.Forms.Label lblMsgDeleteDetails;
        private System.Windows.Forms.Label lblMsgDefaultsDetails;

    }
}

