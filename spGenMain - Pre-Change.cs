using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DS.SPGenerator.genCore;
using System.Linq;
using System.Reflection;


namespace DS.SPGenerator
{
	public partial class spGenMain : Form
	{
		#region local variables

		DS.SPGenerator.genCore.SqlHelper sqlhlpr;
		dbTableParameters dbP;
		string nl = System.Environment.NewLine;
		string tab = "     ";
		bool bLoading = false;
		int lSizeFull=672;
		int lSizeMin = 242;
		eGenType m_genType = eGenType.datareader;
		SyntaxHighlighter sh;
		List<string> orderByList;
		List<whereItem> selectWhereList;
		List<whereItem> updateWhereList;
		List<whereItem> deleteWhereList;
		const int columns = 94;     // Shading width
		bool m_runOnce;
		bool m_genSQLHelper;
		bool m_genSPOILHelper;
		int indexover=0;
		ListBox lastSelectWhereBox;
		ListBox lastSelectBox;

		#endregion
		#region Tables, Lists and Constants
		#region Fonts

			const string proportionalFontName = "Courier New";
			const string monoFontName = "Courier New";
			const string proportionalFontDefinition = @"{\f0\fnil\fcharset0 " + proportionalFontName + @";}";
			const string monoFontDefinition = @"{\f1\fnil\fcharset0 " + monoFontName + @";}";
			const int proportionalFontSize = 8;
			const int monoFontSize = 8;

		#endregion
		#region Color Table

			int[] rgbText =         { 0, 0, 0 };
			int[] rgbCharacter =    { 128, 128, 128 };
			int[] rgbShade =        { 238, 238, 238 };
			int[] rgbLiteral =      { 144, 0, 16 };
			int[] rgbComment =      { 32, 128, 0 };
			int[] rgbKeyword =      { 13, 0, 255 };
			int[] rgbClass =        { 43, 145, 175 };

			// It is useful to set up some aliases ...
			public const string TX = @"\cf1 ";
			public const string CH = @"\cf2 ";
			public const string SH = @"\cf3 ";
			public const string LI = @"\cf4 ";
			public const string CO = @"\cf5 ";
			public const string KY = @"\cf6 ";
			public const string CL = @"\cf7 ";

			// ... and their escaped versions
			public const string escTX = @"\\cf1 ";
			public const string escCH = @"\\cf2 ";
			public const string escSH = @"\\cf3 ";
			public const string escLI = @"\\cf4 ";
			public const string escCO = @"\\cf5 ";
			public const string escKY = @"\\cf6 ";
			public const string escCL = @"\\cf7 ";

			string colorDefinitions = "";

		#endregion
		#region ASCII Values

			// Some ASCII constants
			const char LF = (char)0x0A;     // Line Feed
			const char CR = (char)0x0D;     // Carriage Return
			const char Space = (char)0x20;     // Space char

		#endregion
		#region Initialized Lists

			string keywordList = "";
			string keywordList2 = "";
			string unformattedClassList = "";
			string formattedClassList = "";

		#endregion
		#endregion
		#region enumerations

		private enum eGenType
		{
			datareader,
			dataset,
			nonquery,
			scalar
		}

		#endregion
		#region constructors and form load

		public spGenMain()
		{
			InitializeComponent();

		}
		private void spGenMain_Load(object sender, EventArgs e)
		{
			this.chkWindowsAuthentication.Text = "Use Integrated" + System.Environment.NewLine + "Authentication";
			this.Text = Application.ProductName + " - v" + Application.ProductVersion;
			m_genSQLHelper = false;
			m_genSPOILHelper = false;
			checkBox1.Checked = m_genSQLHelper;
			checkBox2.Checked = m_genSPOILHelper;
			chkWindowsAuthentication.Checked = false;
			sqlhlpr = new DS.SPGenerator.genCore.SqlHelper();
			dbP = new dbTableParameters();
			lblMsgUpdate.Text = "";
			lblMsgSPTypes.Text = "";
			lblMsgInsert.Text = "";
			lblMsgDelete.Text = "";
			xpgMain.SuspendLayout();
			xppDataAccess.PanelState = UIComponents.XPPanelState.Expanded;
			xppSPGenerator.PanelState = UIComponents.XPPanelState.Expanded;
			xppDataAccess.PanelState = UIComponents.XPPanelState.Collapsed;
			xpgMain.ResumeLayout();
			//sh = new SyntaxHighlighter();
			orderByList = new List<string>();
			selectWhereList = new List<whereItem>();
			updateWhereList = new List<whereItem>();
			deleteWhereList = new List<whereItem>();
			// Set Font properties for both Rich Text Boxes
			//txtCode.Font = new Font(proportionalFontName, proportionalFontSize, FontStyle.Regular);
			//rt2.Font = new Font(monoFontName, monoFontSize, FontStyle.Regular);
			button2.Enabled = false;
			button3.Enabled = false;
			m_runOnce = false;
			lastSelectWhereBox = new ListBox();
			lastSelectBox = new ListBox();

			txtCode.Text = "";

			string r = @"\red";
			string g = @"\green";
			string b = @"\blue";

			string tx = r + rgbText[0].ToString() + g + rgbText[1].ToString() + b + rgbText[2].ToString() + ";";
			string ch = r + rgbCharacter[0].ToString() + g + rgbCharacter[1].ToString() + b + rgbCharacter[2].ToString() + ";";
			string shC = r + rgbShade[0].ToString() + g + rgbShade[1].ToString() + b + rgbShade[2].ToString() + ";";
			string li = r + rgbLiteral[0].ToString() + g + rgbLiteral[1].ToString() + b + rgbLiteral[2].ToString() + ";";
			string co = r + rgbComment[0].ToString() + g + rgbComment[1].ToString() + b + rgbComment[2].ToString() + ";";
			string ky = r + rgbKeyword[0].ToString() + g + rgbKeyword[1].ToString() + b + rgbKeyword[2].ToString() + ";";
			string cl = r + rgbClass[0].ToString() + g + rgbClass[1].ToString() + b + rgbClass[2].ToString() + ";";

			// These colors will make up a new color table
			colorDefinitions = tx + ch + shC + li + co + ky + cl;

			keywordList = "\babstract\b|\bas\b|\bbase\b|\bbool\b|\bbreak\b|\bbyte\b|\bcase\b|\bcatch\b|\bchar\b|\bchecked\b|\bclass\b|\bconst\b|\bcontinue\b|\bdecimal\b|\bdefault\b|\bdelegate\b|\bdo\b|\bdouble\b|\belse\b|\benum\b|\bevent\b|\bexplicit\b|\bextern\b|\bfalse\b|\bfinally\b|\bfixed\b|\bfloat\b|\bfor\b|\bforeach\b|\bgoto\b|\bif\b|\bimplicit\b|\bin\b|\bint\b|\binterface\b|\binternal\b|\bis\b|\block\b|\blong\b|\bnamespace\b|\bnew\b|\bnull\b|\bobject\b|\boperator\b|\bout\b|\boverride\b|\bparams\b|\bprivate\b|\bprotected\b|\bpublic\b|\breadonly\b|\bref\b|\breturn\b|\bsbyte\b|\bsealed\b|\bshort\b|\bsizeof\b|\bstackalloc\b|\bstatic\b|\bstring\b|\bstruct\b|\bswitch\b|\bthis\b|\bthrow\b|\btrue\b|\btry\b|\btypeof\b|\buint\b|\bulong\b|\bunchecked\b|\bunsafe\b|\bushort\b|\busing\b|\bvirtual\b|\bvoid\b|\bvolatile\b|\bwhile\b";
			keywordList2 = " abstract | Abstract |as | As | as String | as string | base | Base | bool | Boolean | break | byte | Byte | case | Case | catch | catch| Catch | char |(char)| Char | checked | class | const | Const | continue | CType | DateTime |DateTime| DBNull | decimal |(decimal)| Decimal | default | Default | delegate | Delegate | do | Do | double | Double |(double)| else | Else | End While | End Using | End Try | End | enum | Enum | event | Event |Exception | explicit | Explicit | extern | false | False | finally | Finally | fixed | float |(float)| Float | for | For | foreach | Each | goto | Goto | get | Get | if | If | implicit | in | int |(int)| Int | int16 | int32 | int64 | Integer | interface | Interface | internal | Internal | is | lock | long | Loop | namespace | Namespace | new | New | Next | null | Null | object | Object | operator | out | override | Override | params | private | Private | protected | Protected | public | Public | readonly | Readonly | ref | return | Return | sbyte | sealed | short | sizeof | stackalloc | static | string | String | struct | switch| this | throw | true | try | Try | Type | typeof | TypeOf | uint | ulong | unchecked | unsafe | ushort | using | Using | virtual | void | volatile | while| While | XmlDocument";
			keywordList2 += "|SqlDbType.Int|SqlDbType.BigInt|SqlDbType.Bit|SqlDbType.Char|SqlDbType.DateTime|SqlDbType.Decimal|SqlDbType.Float|SqlDbType.Image|SqlDbType.Money|SqlDbType.NChar|SqlDbType.NText|SqlDbType.NVarChar|SqlDbType.Real|SqlDbType.SmallDateTime|SqlDbType.SmallInt|SqlDbType.SmallMoney|SqlDbType.Variant|SqlDbType.Text|SqlDbType.TinyInt|SqlDbType.UniqueIdentifier|SqlDbType.VarBinary|SqlDbType.VarChar|SqlDbType.Xml";
            
            sh = new SyntaxHighlighter();
		}

		#endregion
		#region form control events

		private void chkWindowsAuthentication_CheckedChanged(object sender, EventArgs e)
		{
			UpdateDbtParameters();
		}
		private void ConnectionItemChanged(object sender, EventArgs e)
		{
			UpdateDbtParameters();
			this.orderByList.Clear();
		}
		private void TabChanged(object sender, EventArgs e)
		{
			//deprecated by ShowTabs();
			ShowTabs();
		}
		private void cmdSelectCopy_Click(object sender, EventArgs e)
		{
			bool bRes = CopyToClipboard(this.rtbSelectSP.Text);
		}
		private void cmdInsertCopy_Click(object sender, EventArgs e)
		{
			bool bRes = CopyToClipboard(this.rtbInsertSP.Text);
		}
		private void cmdUpdateCopy_Click(object sender, EventArgs e)
		{
			bool bRes = CopyToClipboard(this.rtbUpdateSP.Text);
		}
		private void cmdDeleteCopy_Click(object sender, EventArgs e)
		{
			bool bRes = CopyToClipboard(this.rtbDeleteSP.Text);
		}
		private void tmrStretch_Tick(object sender, EventArgs e)
		{
			int iCurHeight = this.Height;
			if (dbP.IsValid())
			{
				//expanding
				if (iCurHeight >= lSizeFull)
				{
					iCurHeight = lSizeFull;
					tmrStretch.Enabled = false;
				}
				else
				{
					iCurHeight += 10;
					if (iCurHeight >= lSizeFull)
					{
						iCurHeight = lSizeFull;
						tmrStretch.Enabled = false;
					}
				}
			}
			else
			{
				//contracting
				if (iCurHeight <= lSizeMin)
				{
					iCurHeight = lSizeMin;
					tmrStretch.Enabled = false;
				}
				else
				{
					iCurHeight -= 10;
					if (iCurHeight <= lSizeMin)
					{
						iCurHeight = lSizeMin;
						tmrStretch.Enabled = false;
					}
				}
			}
			this.Height = iCurHeight;
		}
		private void button3_Click(object sender, EventArgs e)
		{
			if (ValidConnection() && cboSP.Text != "")
			{
				if (!m_runOnce)
				{
					GenerateCode(this.cboSP.SelectedItem.ToString(), ref this.txtCode);
					GenerateCode(this.cboSP.SelectedItem.ToString(), ref this.txtCode);
					m_runOnce = true; 
				}
				else
				{
					GenerateCode(this.cboSP.SelectedItem.ToString(), ref this.txtCode);
				}
				button2.Enabled = true;
				if ((rdoADO.Checked) && (checkBox1.Checked))
				{

					this.HelperSaveDlg.Title = "Select Name & Location for SQLHelper Class file";
					if (rdoCSharp.Checked)
					{
						//Use c# version
						this.HelperSaveDlg.Filter = "CS Files (*.cs)|*.cs|" + "All Files|";
						this.HelperSaveDlg.FileName="SQLHelper.cs";
						this.HelperSaveDlg.FilterIndex = 1;
					}
					else
					{
						//use vb version
						this.HelperSaveDlg.Filter = "VB Files (*.vb)|*.vb|" + "All Files|";
						this.HelperSaveDlg.FileName="SQLHelper.vb";
						this.HelperSaveDlg.FilterIndex = 1;
					}
					if( this.HelperSaveDlg.ShowDialog() == DialogResult.OK )
					{
						System.IO.FileInfo fi = new System.IO.FileInfo(this.HelperSaveDlg.FileName);
						if (rdoCSharp.Checked)
						{
							ExtractFileResourceToFileSystem("SQLHelper.cs", fi.Name, fi.DirectoryName);
						}
						else
						{
							ExtractFileResourceToFileSystem("SQLHelper.vb", fi.Name, fi.DirectoryName);
						}
					}
					else
					{
						MessageBox.Show("Not generating SQLHelper file...");
					}
				}
				if ((rdoSpoil.Checked) && (checkBox2.Checked))
				{

					this.HelperSaveDlg.Title = "Select Name & Location for SPOILHelper Class file";
					this.HelperSaveDlg.Filter = "DLL Files (*.dll)|*.dll|" + "All Files|";
					this.HelperSaveDlg.FileName = "SqlCommand.dll";
					this.HelperSaveDlg.FilterIndex = 1;
					if (this.HelperSaveDlg.ShowDialog() == DialogResult.OK)
					{
						System.IO.FileInfo fi = new System.IO.FileInfo(this.HelperSaveDlg.FileName);
						ExtractFileResourceToFileSystem("SqlCommand.dll", fi.Name, fi.DirectoryName);
					}
					else
					{
						MessageBox.Show("Not generating SPOIL Helper file...");
					}
				}
			}
		}
		private void tmrMsg_Tick(object sender, EventArgs e)
		{
			this.lblMsgDelete.Text = string.Empty;
			this.lblMsgSPTypes.Text = string.Empty;
			this.lblMsgInsert.Text = string.Empty;
			this.lblMsgUpdate.Text = string.Empty;
            tmrMsg.Enabled = false;
		}
		private void txtSelectSPName_TextChanged(object sender, EventArgs e)
		{
			//check that name is not already used
			foreach (string Proc in SqlHelper.EnumerateSPs(dbP.ConnectionString))
			{
				if (Proc.Trim().ToUpper() == txtSelectSPName.Text.Trim().ToUpper())
				{
					//display warning
					DisplayMsg("Stored Procedure with the name " + txtSelectSPName.Text.Trim() + " already exists...\r\nChoose a different name or change the CREATE to an ALTER...", 4);
				}
			}
			//if not used then
			this.rtbSelectSP.Rtf = sh.Highlight(BuildSelectSP());
		}
		private void listSelectSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.rtbSelectSP.Rtf = sh.Highlight(BuildSelectSP());
		}
		private void listSelectWhere_SelectedIndexChanged(object sender, EventArgs e)
		{
			lastSelectWhereBox = listSelectWhere;
			foreach (string selItem in listSelectWhere.SelectedItems)
			{
				//create a whereItem
				whereItem _wi = new whereItem(selItem,whereCriteriaSQL.EQUALTO);
				//check if it is already in the list
				bool bInSelectWhereList = false;
				if (selectWhereList.Count > 0)
				{
					foreach (whereItem wi in selectWhereList)
					{
						if (_wi.ColName == wi.ColName) { bInSelectWhereList = true; break; }
					}
				}
				if (!bInSelectWhereList) { selectWhereList.Add(_wi); }
			}
			if (selectWhereList.Count > 0)
			{
				foreach (whereItem listItem in selectWhereList)
				{
					if (!listSelectWhere.SelectedItems.Contains(listItem.ColName)) { selectWhereList.Remove(listItem); break; }
				}
			}
			this.rtbSelectSP.Rtf = sh.Highlight(BuildSelectSP());
		}
		private void txtInsertSPName_TextChanged(object sender, EventArgs e)
		{
			this.rtbInsertSP.Rtf = sh.Highlight(BuildInsertSP());
		}
		private void chkInsertIdentity_CheckedChanged(object sender, EventArgs e)
		{
			this.rtbInsertSP.Rtf = sh.Highlight(BuildInsertSP());
		}
		private void chkInsertIdentityReturn_CheckedChanged(object sender, EventArgs e)
		{
			this.rtbInsertSP.Rtf =sh.Highlight( BuildInsertSP());
		}
		private void listInsertSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (bLoading == false)
			{
				bLoading = true;
				//recheck all non-nullable fields
				string sType = string.Empty;
				// Loop through all items of a Hashtable
				IDictionaryEnumerator en = dbP.Columns.GetEnumerator();
				while (en.MoveNext())
				{
					ColumnProperties cp = (ColumnProperties)en.Value;
					if (cp.Nullable == false)
					{
						//loop thru the listInsertSelect listabox to ensure that it is still checked
						for (int i = 0; i < listInsertSelect.Items.Count; i++)
						{
							if (listInsertSelect.Items[i].ToString().Trim() == cp.Column) { listInsertSelect.SetSelected(i, true); }
						}
					}
				}
				bLoading = false;
				this.rtbInsertSP.Rtf = sh.Highlight(BuildInsertSP());
			}
		}
		private void chkSelectDISTINCT_CheckedChanged(object sender, EventArgs e)
		{
			this.rtbSelectSP.Rtf = sh.Highlight(BuildSelectSP());
		}
		private void txtUpdateSPName_TextChanged(object sender, EventArgs e)
		{
			this.rtbUpdateSP.Rtf = sh.Highlight(BuildUpdateSP());
		}
		private void listUpdateSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.rtbUpdateSP.Rtf = sh.Highlight(BuildUpdateSP());
		}
		private void listUpdateWhere_SelectedIndexChanged(object sender, EventArgs e)
		{
			lastSelectWhereBox = listUpdateWhere;
			foreach (string selItem in listUpdateWhere.SelectedItems)
			{
				//create a whereItem
				whereItem _wi = new whereItem(selItem, whereCriteriaSQL.EQUALTO);
				//check if it is already in the list
				bool bInUpdateWhereList = false;
				if (updateWhereList.Count > 0)
				{
					foreach (whereItem wi in updateWhereList)
					{
						if (_wi.ColName == wi.ColName) { bInUpdateWhereList = true; break; }
					}
				}
				if (!bInUpdateWhereList) { updateWhereList.Add(_wi); }
			}
			if (updateWhereList.Count > 0)
			{
				foreach (whereItem listItem in updateWhereList)
				{
					if (!listUpdateWhere.SelectedItems.Contains(listItem.ColName)) { updateWhereList.Remove(listItem); break; }
				}
			}
			this.rtbUpdateSP.Rtf = sh.Highlight(BuildUpdateSP());
		}
		private void txtDeleteSPName_TextChanged(object sender, EventArgs e)
		{
			this.rtbDeleteSP.Rtf = sh.Highlight(BuildDeleteSP());
		}
		private void listDeleteWhere_SelectedIndexChanged(object sender, EventArgs e)
		{
			lastSelectWhereBox = listDeleteWhere;
			foreach (string selItem in listDeleteWhere.SelectedItems)
			{
				//create a whereItem
				whereItem _wi = new whereItem(selItem, whereCriteriaSQL.EQUALTO);
				//check if it is already in the list
				bool bInDeleteWhereList = false;
				if (deleteWhereList.Count > 0)
				{
					foreach (whereItem wi in deleteWhereList)
					{
						if (_wi.ColName == wi.ColName) { bInDeleteWhereList = true; break; }
					}
				}
				if (!bInDeleteWhereList) { deleteWhereList.Add(_wi); }
			}
			if (deleteWhereList.Count > 0)
			{
				foreach (whereItem listItem in deleteWhereList)
				{
					bool bInListDeleteWhere = false;
					foreach (string thisItem in listDeleteWhere.SelectedItems)
					{
						if (thisItem.ToString() == listItem.ColName) { bInListDeleteWhere=true; break; }
					}
					if (!bInListDeleteWhere) { deleteWhereList.Remove(listItem); break; }
				}
			}
			this.rtbDeleteSP.Rtf = sh.Highlight(BuildDeleteSP());
		}
		private void cmdDeletePublish_Click(object sender, EventArgs e)
		{
			if (SqlHelper.PublishText(this.rtbDeleteSP.Text, dbP.ConnectionString)) { DisplayMsg("Stored Procedure Published successfully",4); } else { DisplayMsg("Stored Procedure Publish failed...",4); };
			//re-read sp list
			button1_Click(sender, e);
		}
		private void cmdUpdatePublish_Click(object sender, EventArgs e)
		{
			if (SqlHelper.PublishText(this.rtbUpdateSP.Text, dbP.ConnectionString)) { DisplayMsg("Stored Procedure Published successfully",4); } else { DisplayMsg("Stored Procedure Publish failed...",4); };
		}
		private void cmdInsertPublish_Click(object sender, EventArgs e)
		{
			if (SqlHelper.PublishText(this.rtbInsertSP.Text, dbP.ConnectionString)) { DisplayMsg("Stored Procedure Published successfully",4); } else { DisplayMsg("Stored Procedure Publish failed...",4); };
		}
		private void tabSPTypes_Click_1(object sender, EventArgs e)
		{

		}
		private void txtTopCount_TextChanged(object sender, EventArgs e)
		{
			int _topCount = 0;
			if (chkSelectTop.Checked)
			{
				txtTopCount.Enabled = true;
				if (txtTopCount.Text.Trim().Length > 0)
				{
					try
					{
						_topCount = System.Convert.ToInt32(txtTopCount.Text);
						txtTopCount.BackColor = Color.White;
					}
					catch
					{
						txtTopCount.BackColor = Color.Salmon;
						DisplayMsg("A valid whole number needs to be entered for the TOP clause...", 4);
					}
				}
				else
				{
					txtTopCount.BackColor = Color.Salmon;
					DisplayMsg("Enter a valid whole number for the TOP clause...", 4);
				}
			}
			else
			{
				txtTopCount.Enabled = false;
				txtTopCount.BackColor = Color.White;
			}
			this.rtbSelectSP.Rtf = sh.Highlight(BuildSelectSP());
		}
		private void listOrderBy_SelectedIndexChanged(object sender, EventArgs e)
		{
			foreach (string selItem in listOrderBy.SelectedItems)
			{
				if(!orderByList.Contains(selItem)) { orderByList.Add(selItem);}
			}
			foreach (string listItem in orderByList)
			{
				if (!listOrderBy.SelectedItems.Contains(listItem)) { orderByList.Remove(listItem); break; }
			}
			//orderByList.Add(listOrderBy.SelectedItem.ToString());
			this.rtbSelectSP.Rtf = sh.Highlight(BuildSelectSP());
		}
		private void cmdSelectPublish_Click(object sender, EventArgs e)
		{
			if (SqlHelper.PublishText(this.rtbSelectSP.Text, dbP.ConnectionString)) { DisplayMsg("Stored Procedure Published successfully",4); } else { DisplayMsg("Stored Procedure Publish failed...",4); };
		}
		private void tabPage2_Click(object sender, EventArgs e)
		{
			txtSPText.Text = SqlHelper.GetSPText(cboSP.SelectedItem.ToString(), dbP.ConnectionString);
		}
		private void cboServers_Leave(object sender, EventArgs e)
		{
			expandingButton1_Load(sender, e);
		}
		private void cboDatabases_Leave(object sender, EventArgs e)
		{
			expandingButton2_Load(sender, e);
			button1_Click(sender, e);
		}
		private void chkUseDataReader_CheckedChanged(object sender, EventArgs e)
		{
			if (chkUseDataReader.Checked) { m_genType = eGenType.datareader; chkUseDataSet.Checked = false; chkUseNonQuery.Checked = false; chkUseScalar.Checked = false; }
		}
		private void chkUseDataSet_CheckedChanged(object sender, EventArgs e)
		{
			if (chkUseDataSet.Checked) { m_genType = eGenType.dataset; chkUseDataReader.Checked = false; chkUseNonQuery.Checked = false; chkUseScalar.Checked = false; }
		}
		private void chkUseList_CheckedChanged(object sender, EventArgs e)
		{
			if (chkUseNonQuery.Checked) { m_genType = eGenType.nonquery; chkUseDataSet.Checked = false; chkUseDataReader.Checked = false; chkUseScalar.Checked = false; }
		}
		private void chkUseScalar_CheckedChanged(object sender, EventArgs e)
		{
			if (chkUseScalar.Checked) { m_genType = eGenType.scalar; chkUseDataSet.Checked = false; chkUseNonQuery.Checked = false; chkUseDataReader.Checked = false; }
		}
		private void cboSP_SelectedIndexChanged(object sender, EventArgs e)
		{
			DisplayStoredProc(cboSP.Text);
			txtCode.Text = string.Empty;
			button2.Enabled = false;
			button3.Enabled = true; 
		}
		private void rdoStandardADO_CheckedChanged(object sender, EventArgs e)
		{
			if (rdoStandardADO.Checked) 
			{ 
				grpADOMethodType.Text = "ADO Call Type"; 
				groupBox6.Enabled = false;
			} 
			else 
			{ 
				groupBox6.Enabled = true;
			}
		}
		private void xcmdGetServers_Load(object sender, EventArgs e)
		{
			cboServers.Items.Clear();
			DisplayMsg("Retrieving SqlServer list. . .", 3);
			Application.DoEvents();
			try
			{
				if (CheckAuthSet())
				{
					string[] serverList = sqlhlpr.EnumerateSQLServers();
					foreach (string sTemp in serverList)
					{
						cboServers.Items.Add(sTemp);
					}
					DisplayMsg("", 3);
				}
				else
				{
					DisplayMsg("Provide Authentication to enumerate SqlServers", 4);
				}
			}
			catch (Exception ex) { }
		}
		private void expandingButton1_Load(object sender, EventArgs e)
		{
			cboDatabases.Items.Clear();
			if (((txtPassword.Text.Length > 0) && (txtUserName.Text.Length > 0)) || (chkWindowsAuthentication.Checked))
			{
				DisplayMsg("Retrieving Database list. . .", 3);
				Application.DoEvents();
				try
				{
					if (cboServers.Text.Length > 0)
					{
						if (CheckAuthSet())
						{
							string[] dbList = sqlhlpr.EnumerateSQLServerDatabases(cboServers.Text, txtUserName.Text, txtPassword.Text, chkWindowsAuthentication.Checked);
							foreach (string sTemp in dbList)
							{
								cboDatabases.Items.Add(sTemp);
								DisplayMsg("", 3);
							}
						}
						else
						{
							DisplayMsg("Provide Authentication to enumerate Databases", 3);
						}
					}
					else { DisplayMsg("Must select or enter a Server Name before\r\nattempting to enumerate databases", 3); }
				}
				catch (Exception ex) { }
			}
			else
			{
				DisplayMsg("Provide Authentication to enumerate Databases", 3);
			}
		}
		private void expandingButton2_Load(object sender, EventArgs e)
		{
			cboTables.Items.Clear();
			if (ValidConnection())
			{
				DisplayMsg("Retrieving Table list. . .", 3);
				Application.DoEvents();
				try
				{
					if ((cboServers.Text.Length > 0) && (cboDatabases.Text.Length > 0))
					{
						string[] tableList = sqlhlpr.EnumerateDatabaseTables(dbP.BuildConnectionString());
						foreach (string sTemp in tableList)
						{
							cboTables.Items.Add(sTemp);
							DisplayMsg("", 3);
						}
						string[] viewList = sqlhlpr.EnumerateDatabaseViews(dbP.BuildConnectionString());
						foreach (string sTemp in viewList)
						{
							cboTables.Items.Add("[VIEW] " + sTemp);
							DisplayMsg("", 3);
						}
					}
					else { DisplayMsg("Must select or enter a Server Name and Database\r\nbefore attempting to enumerate tables", 3); }
				}
				catch (Exception ex) { }
			}
			else
			{
				DisplayMsg("Provide valid connection information before trying to list existing tables or SP's", 4);
			}
		}
		private void xpPanel_Click(object sender, EventArgs e)
		{
			UIComponents.XPPanel currentPanel = (UIComponents.XPPanel)sender;
			xpgMain.SuspendLayout();
			xpgMain.VerticalScroll.Visible = false;
			switch (currentPanel.Name)
			{
				case "xppDataAccess":
					xppDataAccess.CaptionCornerType = UIComponents.CornerType.TopRight;
					xppSPGenerator.PanelState = UIComponents.XPPanelState.Collapsed;
					xppSPGenerator.CaptionCornerType = UIComponents.CornerType.All;
					break;
				case "xppSPGenerator":
					xppSPGenerator.CaptionCornerType = UIComponents.CornerType.TopRight;
					xppDataAccess.PanelState = UIComponents.XPPanelState.Collapsed;
					xppDataAccess.CaptionCornerType = UIComponents.CornerType.All;
					break;
			}
			xpgMain.ResumeLayout();
		}
		private void xpPanels_Changing(object sender, EventArgs e)
		{
			xpgMain.VerticalScroll.Visible = false;
			tabMain.Visible = false;
			tabControl2.Visible = false;
		}
		private void xpPanels_Changed(object sender, EventArgs e)
		{
			UIComponents.XPPanel currentPanel = (UIComponents.XPPanel)sender;
			if (currentPanel.Name == "xppSPGenerator")
			{
				tabMain.Visible = true;
			}
			else if (currentPanel.Name == "xppDataAccess")
			{
				tabControl2.Visible = true;
			}
			else
			{
				//something else - do nothing}
			}
		}
		private void pictureBox2_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("www.dakotaIS.com");
		}
		private void txtCode_TextChanged(object sender, EventArgs e)
		{
			if (txtCode.Text.Trim().Length > 0) { button2.Enabled = true; } else { button2.Enabled = false; }
		}
		private void button1_Click(object sender, EventArgs e)
		{
			cboSP.Items.Clear();
			if (ValidConnection())
			{
				foreach (string Proc in SqlHelper.EnumerateSPs(dbP.ConnectionString))
				{
					if (Proc.StartsWith("Cannot open database")) { DisplayMsg("Provide valid connection information before trying \r\nto list existing tables or SP's", 4); }
					cboSP.Items.Add(Proc.ToString());
				}
			}
			else
			{
				DisplayMsg("Provide valid connection information before trying \r\nto list existing tables or SP's", 4);
			}

		}
		private void cmdSelectTest_Click(object sender, EventArgs e)
		{
			//get selected parameters into List<spParm> array
			List<spParam> _parmList = new List<spParam>();
			foreach (string sItem in listSelectWhere.SelectedItems)
			{
				spParam _parm = new spParam();
				if (sItem != "")
				{
					ColumnProperties scp = ((ColumnProperties)dbP.Columns[sItem]);
					_parm.ParamName = "@" + scp.Column; _parm.ParamType = scp.Type;
					_parmList.Add(_parm);
				}
				else
				{
					//do nothing - go to next selected item
				}
			}
			frmSPTest fT = new frmSPTest(rtbSelectSP.Rtf, _parmList, dbP.ConnectionString, spType.SELECT);
			fT.Show();
		}
		private void button1_Click_1(object sender, EventArgs e)
		{
			//get selected parameters into List<spParm> array
			List<spParam> _parmList = new List<spParam>();
			foreach (string sItem in listInsertSelect.SelectedItems)
			{
				spParam _parm = new spParam();
				if (sItem != "")
				{
					ColumnProperties scp = ((ColumnProperties)dbP.Columns[sItem]);
					_parm.ParamName = "@" + scp.Column; _parm.ParamType = scp.Type;
					_parmList.Add(_parm);
				}
				else
				{
					//do nothing - go to next selected item
				}
			}
			frmSPTest fT = new frmSPTest(rtbInsertSP.Rtf, _parmList, dbP.ConnectionString, spType.INSERT);
			fT.Show();
		}
		private void button4_Click(object sender, EventArgs e)
		{
			//get selected parameters into List<spParm> array
			List<spParam> _parmList = new List<spParam>();
			foreach (string sItem in listUpdateWhere.SelectedItems)
			{
				spParam _parm = new spParam();
				if (sItem != "")
				{
					ColumnProperties scp = ((ColumnProperties)dbP.Columns[sItem]);
					_parm.ParamName = "@" + scp.Column; _parm.ParamType = scp.Type;
					_parmList.Add(_parm);
				}
				else
				{
					//do nothing - go to next selected item
				}
			}
			foreach (string sItem in listUpdateSelect.SelectedItems)
			{
				spParam _parm = new spParam();
				if (sItem != "")
				{
					ColumnProperties scp = ((ColumnProperties)dbP.Columns[sItem]);
					_parm.ParamName = "@" + scp.Column; _parm.ParamType = scp.Type;
					bool _found = false;
					foreach (spParam spp in _parmList)
					{
						if (spp.ParamName == _parm.ParamName) { _found = true; break; }
					}
					if (!_found) { _parmList.Add(_parm); }
				}
				else
				{
					//do nothing - go to next selected item
				}
			}
			frmSPTest fT = new frmSPTest(rtbUpdateSP.Rtf, _parmList, dbP.ConnectionString, spType.UPDATE);
			fT.Show();
		}
		private void button5_Click(object sender, EventArgs e)
		{
			//get selected parameters into List<spParm> array
			List<spParam> _parmList = new List<spParam>();
			foreach (string sItem in listDeleteWhere.SelectedItems)
			{
				spParam _parm = new spParam();
				if (sItem != "")
				{
					ColumnProperties scp = ((ColumnProperties)dbP.Columns[sItem]);
					_parm.ParamName = "@" + scp.Column; _parm.ParamType = scp.Type;
					_parmList.Add(_parm);
				}
				else
				{
					//do nothing - go to next selected item
				}
			}
			frmSPTest fT = new frmSPTest(rtbDeleteSP.Rtf, _parmList, dbP.ConnectionString, spType.DELETE);
			fT.Show();
		}
		private void button2_Click(object sender, EventArgs e)
		{
			CopyToClipboard(txtCode.Text);
		}
		private void TableName_TextChanged(object sender, EventArgs e)
		{
			selectWhereList.Clear();
			updateWhereList.Clear();
			deleteWhereList.Clear();
			ConnectionItemChanged(sender, e);
		}
		private void button6_Click_1(object sender, EventArgs e)
		{
			//get selected parameters into List<spParm> array
			List<spParam> _parmList = new List<spParam>();
			DataSet _ds = GetSPparameters(cboSP.Text);
			foreach (DataRow dr in _ds.Tables[0].Rows)
			{
				spParam parm = new spParam();
				parm.Direction = dr["DIRECTION"].ToString();
				parm.Ordinal = System.Convert.ToInt32(dr["ORDINAL_POSITION"].ToString());
				parm.ParamName = dr["PARAM_NAME"].ToString();
				parm.ParamType = dr["PARAM_TYPE"].ToString();
				try { parm.Precision = System.Convert.ToInt32(dr["PRECISION"].ToString()); }
				catch { parm.Precision = 0; }
				try { parm.Scale = System.Convert.ToInt32(dr["SCALE"].ToString()); }
				catch { parm.Scale = 0; }
				try { parm.Size = System.Convert.ToInt32(dr["SIZE"].ToString()); }
				catch { parm.Size = 0; }
				parm.SpName = dr["SP_NAME"].ToString();
				string _dir = dr["DIRECTION"].ToString().Trim();
				switch (_dir)
				{
					case "IN":
						parm.Direction = "Input";
						break;
					case "OUT":
						parm.Direction = "Output";
						break;
					case "INOUT":
						parm.Direction = "InputOutput";
						break;
					default:
						//?? this will probably never be hit
						parm.Direction = "ReturnValue";
						break;
				}
				_parmList.Add(parm);
			}
			frmSPTest fT = new frmSPTest(cboSP.Text, txtSPText.Text, _parmList, dbP.ConnectionString, spType.COMPILED);
			fT.Show();
		}
		private void rdoSpoil_CheckedChanged(object sender, EventArgs e)
		{
			if (rdoSpoil.Checked) { grpADOMethodType.Text = "Spoil Call Type"; }
		}
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked) { m_genSQLHelper = true; } else { m_genSQLHelper = false; }
		}
		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox2.Checked) { m_genSPOILHelper = true; } else { m_genSPOILHelper = false; }
		}
		private void rdoADO_CheckedChanged(object sender, EventArgs e)
		{
			if (rdoADO.Checked)
			{
				chkUseDataReader.Checked = false;
				chkUseDataReader.Enabled = false;
			}
			else
			{
				chkUseDataReader.Checked = false;
				chkUseDataReader.Enabled = true;
			}
		}
		private void listSelectWhere_MouseDown(object sender, MouseEventArgs e)
		{
			indexover = listSelectWhere.IndexFromPoint(e.X, e.Y);
			System.Diagnostics.Debug.WriteLine("INDEXOVER: " + indexover.ToString());
			if (indexover >= 0 && indexover < listSelectWhere.Items.Count)
			{
				if (e.Button == MouseButtons.Right)
				{
					listSelectWhere.SelectedIndex = indexover;
				}
			}
			lastSelectWhereBox = listSelectWhere;
		}
		private void opEQUALTO_Click(object sender, EventArgs e)
		{
			List<whereItem> thisWhereList = new List<whereItem>();
			switch (lastSelectWhereBox.Name.ToString())
			{
				case "listDeleteWhere":
					thisWhereList = deleteWhereList;
					break;
				case "listSelectWhere":
					thisWhereList = selectWhereList;
					break;
				case "listUpdateWhere":
					thisWhereList = updateWhereList;
					break;
			}
			foreach (whereItem wi in thisWhereList)
			{
				if (lastSelectWhereBox.Items[indexover].ToString() == wi.ColName) { wi.Criteria = whereCriteriaSQL.EQUALTO; break; }
			}
			switch (tabMain.SelectedTab.Name.ToString())
			{
				case "tabSPTypes":
					this.rtbSelectSP.Rtf = sh.Highlight(BuildSelectSP());
					break;
				case "tablSPDelete":
					this.rtbDeleteSP.Rtf = sh.Highlight(BuildDeleteSP());
					break;
				case "tabSPInsert":
					this.rtbInsertSP.Rtf = sh.Highlight(BuildInsertSP());
					break;
				case "tabSPUpdate":
					this.rtbUpdateSP.Rtf = sh.Highlight(BuildUpdateSP());
					break;
			}

		}
		private void opGREATERTHAN_Click(object sender, EventArgs e)
		{
			List<whereItem> thisWhereList = new List<whereItem>();
			switch (lastSelectWhereBox.Name.ToString())
			{
				case "listDeleteWhere":
					thisWhereList = deleteWhereList;
					break;
				case "listSelectWhere":
					thisWhereList = selectWhereList;
					break;
				case "listUpdateWhere":
					thisWhereList = updateWhereList;
					break;
			}
			foreach (whereItem wi in thisWhereList)
			{
				if (lastSelectWhereBox.Items[indexover].ToString() == wi.ColName) { wi.Criteria = whereCriteriaSQL.GREATERTHAN; break; }
			}
			switch (tabMain.SelectedTab.Name.ToString())
			{
				case "tabSPTypes":
					this.rtbSelectSP.Rtf = sh.Highlight(BuildSelectSP());
					break;
				case "tablSPDelete":
					this.rtbDeleteSP.Rtf = sh.Highlight(BuildDeleteSP());
					break;
				case "tabSPInsert":
					this.rtbInsertSP.Rtf = sh.Highlight(BuildInsertSP());
					break;
				case "tabSPUpdate":
					this.rtbUpdateSP.Rtf = sh.Highlight(BuildUpdateSP());
					break;
			}
		}
		private void opGREATERTHANorEQUALTO_Click(object sender, EventArgs e)
		{
			List<whereItem> thisWhereList = new List<whereItem>();
			switch (lastSelectWhereBox.Name.ToString())
			{
				case "listDeleteWhere":
					thisWhereList = deleteWhereList;
					break;
				case "listSelectWhere":
					thisWhereList = selectWhereList;
					break;
				case "listUpdateWhere":
					thisWhereList = updateWhereList;
					break;
			}
			foreach (whereItem wi in thisWhereList)
			{
				if (lastSelectWhereBox.Items[indexover].ToString() == wi.ColName) { wi.Criteria = whereCriteriaSQL.GREATERTHAN_or_EQUALTO; break; }
			}
			switch (tabMain.SelectedTab.Name.ToString())
			{
				case "tabSPTypes":
					this.rtbSelectSP.Rtf = sh.Highlight(BuildSelectSP());
					break;
				case "tablSPDelete":
					this.rtbDeleteSP.Rtf = sh.Highlight(BuildDeleteSP());
					break;
				case "tabSPInsert":
					this.rtbInsertSP.Rtf = sh.Highlight(BuildInsertSP());
					break;
				case "tabSPUpdate":
					this.rtbUpdateSP.Rtf = sh.Highlight(BuildUpdateSP());
					break;
			}

		}
		private void opLESSTHAN_Click(object sender, EventArgs e)
		{
			List<whereItem> thisWhereList = new List<whereItem>();
			switch (lastSelectWhereBox.Name.ToString())
			{
				case "listDeleteWhere":
					thisWhereList = deleteWhereList;
					break;
				case "listSelectWhere":
					thisWhereList = selectWhereList;
					break;
				case "listUpdateWhere":
					thisWhereList = updateWhereList;
					break;
			}
			foreach (whereItem wi in thisWhereList)
			{
				if (lastSelectWhereBox.Items[indexover].ToString() == wi.ColName) { wi.Criteria = whereCriteriaSQL.LESSTHAN; break; }
			}
			switch (tabMain.SelectedTab.Name.ToString())
			{
				case "tabSPTypes":
					this.rtbSelectSP.Rtf = sh.Highlight(BuildSelectSP());
					break;
				case "tablSPDelete":
					this.rtbDeleteSP.Rtf = sh.Highlight(BuildDeleteSP());
					break;
				case "tabSPInsert":
					this.rtbInsertSP.Rtf = sh.Highlight(BuildInsertSP());
					break;
				case "tabSPUpdate":
					this.rtbUpdateSP.Rtf = sh.Highlight(BuildUpdateSP());
					break;
			}

		}
		private void opLESSTHANorEQUALTO_Click(object sender, EventArgs e)
		{
			List<whereItem> thisWhereList = new List<whereItem>();
			switch (lastSelectWhereBox.Name.ToString())
			{
				case "listDeleteWhere":
					thisWhereList = deleteWhereList;
					break;
				case "listSelectWhere":
					thisWhereList = selectWhereList;
					break;
				case "listUpdateWhere":
					thisWhereList = updateWhereList;
					break;
			}
			foreach (whereItem wi in thisWhereList)
			{
				if (lastSelectWhereBox.Items[indexover].ToString() == wi.ColName) { wi.Criteria = whereCriteriaSQL.LESSTHAN_or_EQUALTO; break; }
			}
			switch (tabMain.SelectedTab.Name.ToString())
			{
				case "tabSPTypes":
					this.rtbSelectSP.Rtf = sh.Highlight(BuildSelectSP());
					break;
				case "tablSPDelete":
					this.rtbDeleteSP.Rtf = sh.Highlight(BuildDeleteSP());
					break;
				case "tabSPInsert":
					this.rtbInsertSP.Rtf = sh.Highlight(BuildInsertSP());
					break;
				case "tabSPUpdate":
					this.rtbUpdateSP.Rtf = sh.Highlight(BuildUpdateSP());
					break;
			}

		}
		private void opLIKE_Click(object sender, EventArgs e)
		{
			List<whereItem> thisWhereList = new List<whereItem>();
			switch (lastSelectWhereBox.Name.ToString())
			{
				case "listDeleteWhere":
					thisWhereList = deleteWhereList;
					break;
				case "listSelectWhere":
					thisWhereList = selectWhereList;
					break;
				case "listUpdateWhere":
					thisWhereList = updateWhereList;
					break;
			}
			foreach (whereItem wi in thisWhereList)
			{
				if (lastSelectWhereBox.Items[indexover].ToString() == wi.ColName) { wi.Criteria = whereCriteriaSQL.LIKE; break; }
			}
			switch (tabMain.SelectedTab.Name.ToString())
			{
				case "tabSPTypes":
					this.rtbSelectSP.Rtf = sh.Highlight(BuildSelectSP());
					break;
				case "tablSPDelete":
					this.rtbDeleteSP.Rtf = sh.Highlight(BuildDeleteSP());
					break;
				case "tabSPInsert":
					this.rtbInsertSP.Rtf = sh.Highlight(BuildInsertSP());
					break;
				case "tabSPUpdate":
					this.rtbUpdateSP.Rtf = sh.Highlight(BuildUpdateSP());
					break;
			}

		}
		private void listUpdateWhere_MouseDown(object sender, MouseEventArgs e)
		{
			indexover = listUpdateWhere.IndexFromPoint(e.X, e.Y);
			//System.Diagnostics.Debug.WriteLine("INDEXOVER: " + indexover.ToString());
			if (indexover >= 0 && indexover < listUpdateWhere.Items.Count)
			{
				if (e.Button == MouseButtons.Right)
				{
					listUpdateWhere.SelectedIndex = indexover;
				}
			}
			lastSelectWhereBox = listUpdateWhere;
		}
		private void listDeleteWhere_MouseDown(object sender, MouseEventArgs e)
		{
			indexover = listDeleteWhere.IndexFromPoint(e.X, e.Y);
			//System.Diagnostics.Debug.WriteLine("INDEXOVER: " + indexover.ToString());
			if (indexover >= 0 && indexover < listDeleteWhere.Items.Count)
			{
				if (e.Button == MouseButtons.Right)
				{
					listDeleteWhere.SelectedIndex = indexover;
				}
			}
			lastSelectWhereBox = listDeleteWhere;
		}
		private void nexxusPictureBox_MouseEnter(object sender, EventArgs e)
		{
			PictureBox npb = (PictureBox)sender;
			npb.BorderStyle = BorderStyle.FixedSingle;
		}
		private void nexxusPictureBox_MouseLeave(object sender, EventArgs e)
		{
			PictureBox npb = (PictureBox)sender;
			npb.BorderStyle = BorderStyle.Fixed3D;
		}
		private void opClearAll_Click(object sender, EventArgs e)
		{
			ListBox lb = lastSelectBox;
			for (int i = 0; i < lb.Items.Count; i++)
			{
				lb.SetSelected(i, false);
			}
			RebuildLastQuery(lb);
		}
		private void opSelectAll_Click(object sender, EventArgs e)
		{
			ListBox lb = lastSelectBox;
			for (int i = 0; i < lb.Items.Count; i++)
			{
				lb.SetSelected(i, true);
			}
			RebuildLastQuery(lb);
		}
		private void opToggleAll_Click(object sender, EventArgs e)
		{
			ListBox lb = lastSelectBox;
			for (int i = 0; i < lb.Items.Count; i++)
			{
				lb.SetSelected(i, !lb.GetSelected(i));
			}
			RebuildLastQuery(lb);
		}
		private void listSelectSelect_MouseDown(object sender, MouseEventArgs e)
		{
			lastSelectBox = listSelectSelect;
		}
		#endregion
		#region Delegates
		// -----------------------------------------------------------------------------------------------------
		// Class Name Handler ... Class Name Handler ... Class Name Handler ... Class Name Handler ... Class Nam
		// -----------------------------------------------------------------------------------------------------
		static string KeyclassHandler(Match m)
		{
			string keyclass = m.ToString();
			return keyclass = CL + keyclass + TX;
		}

		// -----------------------------------------------------------------------------------------------------
		// Keyword Handler ... Keyword Handler ... Keyword Handler ... Keyword Handler ... Keyword Handler ... K
		// -----------------------------------------------------------------------------------------------------
		static string KeywordHandler(Match m)
		{
			string keyword = m.ToString();
			return keyword = KY + keyword + TX;
		}

		// -----------------------------------------------------------------------------------------------------
		// Character Handler ... Character Handler ... Character Handler ... Character Handler ... Character Han
		// -----------------------------------------------------------------------------------------------------
		static string CharacterHandler(Match m)
		{
			string character = m.ToString();
			return character = CH + character + TX;
		}

		// -----------------------------------------------------------------------------------------------------
		// Literal Handler ... Literal Handler ... Literal Handler ... Literal Handler ... Literal Handler ... L 
		// -----------------------------------------------------------------------------------------------------
		static string LiteralHandler(Match m)
		{
			string literal = m.ToString();

			// Remove any highlighting of Class Names, Keywords,
			// Characters, Comments in the literal
			literal = Regex.Replace(
						literal,
						escCL + "|" + escKY + "|" + escCH + "|" + escCO + "|" + escTX,
						"");

			return literal = LI + literal + TX;
		}

		// -----------------------------------------------------------------------------------------------------
		// Comment Handler ... Comment Handler ... Comment Handler ... Comment Handler ... Comment Handler ... C
		// -----------------------------------------------------------------------------------------------------
		static string CommentHandler(Match m)
		{
			string comment = m.ToString();

			// Remove any highlighting of Class Names, Keywords,
			// Characters, Literals embedded in the comment
			comment = Regex.Replace(
						comment,
						escCL + "|" + escKY + "|" + escCH + "|" + escLI + "|" + escTX,
						"");

			return comment = CO + comment + TX;
		}

		// -----------------------------------------------------------------------------------------------------
		// Cleanup Handler ... Cleanup Handler ... Cleanup Handler ... Cleanup Handler ... Cleanup Handler ... C
		// -----------------------------------------------------------------------------------------------------
		static string CleanupHandler(Match m)
		{
			string literal = m.ToString();

			// Remove any highlighting of Comments
			// embedded in the Literal
			literal = Regex.Replace(
						literal,
						escCO + "|" + escTX,
						"");

			return literal = LI + literal + TX;
		}

		// -----------------------------------------------------------------------------------------------------
		// Remove Handler ... Remove Handler ... Remove Handler ... Remove Handler ... Remove Handler ... Remove
		// -----------------------------------------------------------------------------------------------------
		static string RemoveHandler(Match m)
		{
			string s = m.ToString();
			return s = " ";
		}

				#endregion

		#region local business logic

		private void ShowTabs()
		{
			PopulateOtherTabs();
		}
		private void DisplayMsg(string msg, int seconds)
		{
			this.tmrMsg.Enabled = false;
			this.lblMsgSPTypes.Text = msg;
			this.lblMsgDelete.Text = msg;
			this.lblMsgInsert.Text = msg;
			this.lblMsgUpdate.Text = msg;
			this.tmrMsg.Interval = seconds * 1000;
			this.tmrMsg.Enabled = true;

		}
		private void UpdateDbtParameters()
		{
			dbP.DatabaseName = this.cboDatabases.Text;
			dbP.Server = this.cboServers.Text;
			dbP.Password = this.txtPassword.Text;
			dbP.User = this.txtUserName.Text;
			dbP.UseWindowsAuthentication = this.chkWindowsAuthentication.Checked;
			if (!this.cboTables.Text.StartsWith("[VIEW] "))
			{
				dbP.Table = this.cboTables.Text;
				dbP.View = "";
			}
			else
			{
				dbP.View = this.cboTables.Text.Replace("[VIEW] ","");
				dbP.Table = "";
			}
			if (chkWindowsAuthentication.Checked)
			{
				this.txtUserName.Enabled = false;
				this.txtPassword.Enabled = false;
			}
			else
			{
				this.txtUserName.Enabled = true;
				this.txtPassword.Enabled = true;
			}
			ShowTabs();
			// TODO: update lablConnString here
			if (ValidConnection()) { lblConnString.Text = dbP.BuildConnectionString(); }
		}
		private void PopulateOtherTabs()
		{
			if (dbP.IsValid())
			{
				bLoading = true;
				//dbP.Save();
				this.listSelectSelect.Items.Clear();
				this.listSelectWhere.Items.Clear();
				listInsertSelect.Items.Clear();
				this.listUpdateSelect.Items.Clear();
				this.listUpdateWhere.Items.Clear();
				this.listDeleteWhere.Items.Clear();
				this.listOrderBy.Items.Clear();

				if (dbP.Table.Length > 0)
				{
					this.txtSelectSPName.Text = "USP_" + dbP.Table + "_Select";
					this.txtInsertSPName.Text = "USP_" + dbP.Table + "_Insert";
					this.txtUpdateSPName.Text = "USP_" + dbP.Table + "_Update";
					this.txtDeleteSPName.Text = "USP_" + dbP.Table + "_Delete";
				}
				else
				{
					this.txtSelectSPName.Text = "USP_" + dbP.View + "_Select";
					this.txtInsertSPName.Text = "USP_" + dbP.View + "_Insert";
					this.txtUpdateSPName.Text = "USP_" + dbP.View + "_Update";
					this.txtDeleteSPName.Text = "USP_" + dbP.View + "_Delete";
				}

				// Loop through all items of a Hashtable
				IDictionaryEnumerator en = dbP.Columns.GetEnumerator();
				while (en.MoveNext())
				{
					this.listSelectSelect.Items.Add(en.Key.ToString());
					this.listSelectWhere.Items.Add(en.Key.ToString());
					this.listInsertSelect.Items.Add(en.Key.ToString());
					this.listUpdateSelect.Items.Add(en.Key.ToString());
					this.listUpdateWhere.Items.Add(en.Key.ToString());
					this.listDeleteWhere.Items.Add(en.Key.ToString());
					this.listOrderBy.Items.Add(en.Key.ToString());
				}
				for (int i = 0; i < listSelectSelect.Items.Count; i++)
				{
					listSelectSelect.SetSelected(i, true);
				}
				for (int i = 0; i < listInsertSelect.Items.Count; i++)
				{
					listInsertSelect.SetSelected(i, true);
				}
				for (int i = 0; i < listUpdateSelect.Items.Count; i++)
				{
					listUpdateSelect.SetSelected(i, true);
				}
				foreach (whereItem swi in selectWhereList)
				{
					for (int i = 0; i<listSelectWhere.Items.Count;i++)
					{
						if (listSelectWhere.Items[i].ToString() == swi.ColName) { listSelectWhere.SetSelected(i, true); break; }
					}
				}
				foreach (whereItem swi in updateWhereList)
				{
					for (int i = 0; i < listUpdateWhere.Items.Count; i++)
					{
						if (listUpdateWhere.Items[i].ToString() == swi.ColName) { listUpdateWhere.SetSelected(i, true); break; }
					}
				}
				foreach (whereItem swi in deleteWhereList)
				{
					for (int i = 0; i < listDeleteWhere.Items.Count; i++)
					{
						if (listDeleteWhere.Items[i].ToString() == swi.ColName) { listDeleteWhere.SetSelected(i, true); break; }
					}
				}
				foreach (string swi in orderByList)
				{
					for (int i = 0; i < this.listOrderBy.Items.Count; i++)
					{
						if (listOrderBy.Items[i].ToString() == swi) { listOrderBy.SetSelected(i, true); break; }
					}
				}
				bLoading = false;

				rtbSelectSP.Rtf = sh.Highlight(BuildSelectSP());
				this.rtbInsertSP.Rtf = sh.Highlight(BuildInsertSP());
				this.rtbUpdateSP.Rtf = sh.Highlight(BuildUpdateSP());
				this.rtbDeleteSP.Rtf = sh.Highlight(BuildDeleteSP());

			}
			else
			{
				//do nothing
			}
		}
		private bool CheckAuthSet()
		{
			bool bResult = false;
			if ((this.chkWindowsAuthentication.Checked) || (this.txtUserName.Text.Length > 0)) { bResult = true; } else { bResult = false; }
			return bResult;
		}
		private string CleanParam(string pIn)
		{
			string sTemp = string.Empty;
			sTemp = pIn.Replace(' ', '_');
			return sTemp;
		}
		private string CP(string pIn)
		{
			return CleanParam(pIn);
		}
		private string BuildSelectSP()
		{
			string sSel = "CREATE PROCEDURE [" + dbP.Schema + "].[" + txtSelectSPName.Text + "]";
			if (bLoading == false)
			{
				int iWhereCount = 0;
				int iSelectCount = 0;
				string sParams = string.Empty;
				string sWhere = nl + tab + "WHERE" + nl + tab + "(";
				string sOrderBy = nl + tab + "ORDER BY ";
				bool _distinct = chkSelectDISTINCT.Checked;
				foreach (whereItem sItem in selectWhereList)
				{
					if (sItem.ColName != "")
					{
						sParams += nl + tab + "@" + CP(sItem.ColName) + " " + ((ColumnProperties)dbP.Columns[sItem.ColName]).ColumnDefinition() + ",";
						iWhereCount++;

						sWhere += nl + tab + tab + "([" + sItem.ColName + "] " + sItem.SqlCriteriaString + " @" + CP(sItem.ColName) + ") AND";
					}
					else
					{
						sWhere = string.Empty;
					}
				}

				foreach (string sItem in orderByList)
				{
					if (sItem != "")
					{
						if ((_distinct && (listSelectSelect.SelectedItems.Contains(sItem))) || (!_distinct))
						{
							sOrderBy += sItem + ", ";
						}
						else
						{
							DisplayMsg("DISTINCT selects with ORDER BY Clause requires \r\nOrderBy fields to be in Select List...", 6);
						}
					}
					else
					{
						sOrderBy = string.Empty;
					}
				}
				if (sOrderBy.Length > 16) { sOrderBy = sOrderBy.Substring(0, sOrderBy.Length - 2); } else { sOrderBy = string.Empty; }
				if (sOrderBy.Length > 0) { sOrderBy += nl; } else { sOrderBy = string.Empty; }
				if (sWhere.Length > 20) { sWhere = sWhere.Substring(0, sWhere.Length - 3); } else { sWhere = string.Empty; }  //remove that trailing AND
				if (sWhere.Length > 0) { sWhere += nl + tab + ")"; } else { sWhere = string.Empty; }
				if (sParams.Length > 0) { sParams = sParams.Substring(0, sParams.Length - 1); } else { sParams = string.Empty; }     //remove the trailing comma
				if (iWhereCount > 0) { sSel += nl + "("; }
				sSel += sParams;
				if (iWhereCount > 0) { sSel += nl + ")"; }
				sSel += nl + "AS" + nl + "BEGIN" + nl + tab + "-- SET NOCOUNT ON added to prevent extra result sets from" + nl + tab + "-- interfering with SELECT statements.";
				sSel += nl + tab + "SET NOCOUNT ON;" + nl;
				sSel += nl + tab + "SELECT";
				if (this.chkSelectDISTINCT.Checked) { sSel += " DISTINCT"; }
				int _topCount=0; string s_topCount = string.Empty;
				try { _topCount = System.Convert.ToInt32(txtTopCount.Text); s_topCount = _topCount.ToString(); txtTopCount.BackColor = Color.White; }
				catch { if (this.chkSelectTop.Checked) { txtTopCount.BackColor = Color.Salmon; s_topCount = "100"; txtTopCount.Enabled = true; } else { txtTopCount.BackColor = Color.White; txtTopCount.Enabled = false; } }
				if (this.chkSelectTop.Checked) { sSel += " TOP " + s_topCount + " "; }
				foreach (string sSItem in listSelectSelect.SelectedItems)
				{
					sSel += nl + tab + tab + "[" + sSItem + "],";
					iSelectCount++;
				}
				//remove the trailing comma
				if (sSel.EndsWith(",")) { sSel = sSel.Substring(0, sSel.Length - 1); }
				if (iSelectCount == 0) { sSel += nl + tab + "--MUST DEFINE CUSTOM SELECT FIELDS"; }
				sSel += nl + tab + "FROM [" + dbP.Schema + "].[" + ((dbP.Table.Length>0)?dbP.Table:dbP.View) + "]";
				sSel += sWhere;
				sSel += sOrderBy;
				sSel += nl + "END";
			}
			return sSel;
		}
		private string BuildInsertSP()
		{
			string sSel = "CREATE PROCEDURE [" + dbP.Schema + "].[" + txtInsertSPName.Text + "]";
			if (bLoading == false)
			{
				int iInsertCount = 0;
				string sParams = string.Empty;
				string sValues = string.Empty;
				string sFields = string.Empty;
				string sIdentityColumn = dbP.GetIdentityColumn();
				foreach (string sItem in listInsertSelect.SelectedItems)
				{
					if (sItem != "")
					{
						if ((sItem != sIdentityColumn) || (this.chkInsertIdentity.Checked))
						{
							sParams += nl + tab + "@" + CP(sItem) + " " + ((ColumnProperties)dbP.Columns[sItem]).ColumnDefinition() + ",";
							sFields += nl + tab + tab + "[" + sItem + "],";
							sValues += nl + tab + tab + "@" + CP(sItem) + ",";
							iInsertCount++;
						}
					}
					else
					{

					}
				}
				if (iInsertCount > 0) { sSel += nl + "("; }
				if (sParams.Length > 0) { sParams = sParams.Substring(0, sParams.Length - 1); }
				if (sFields.Length > 0) { sFields = sFields.Substring(0, sFields.Length - 1); }
				if (sValues.Length > 0) { sValues = sValues.Substring(0, sValues.Length - 1); }
				sSel += sParams;
				if (iInsertCount > 0) { sSel += nl + ")"; }
				sSel += nl + "AS" + nl + "BEGIN" + nl + tab + "-- SET NOCOUNT ON added to prevent extra result sets from" + nl + tab + "-- interfering with INSERT statements.";
				sSel += nl + tab + "SET NOCOUNT ON;" + nl;
				if (this.chkInsertIdentityReturn.Checked) { sSel += nl + tab + "DECLARE @RES " + dbP.GetIdentityType(); }
				if (this.chkInsertIdentity.Checked) { sSel += nl + tab + "SET IDENTITY_INSERT " + dbP.Table + " ON;"; }
				sSel += nl + tab + "INSERT INTO [" + dbP.Schema + "].[" + ((dbP.Table.Length > 0) ? dbP.Table : dbP.View) + "]";
				sSel += nl + tab + "(" + sFields + nl + tab + ")";
				sSel += nl + tab + "VALUES";
				sSel += nl + tab + "(" + sValues + nl + tab + ")";
				if (this.chkInsertIdentityReturn.Checked)
				{
					sSel += nl + tab + "SELECT @RES = @@IDENTITY";
					sSel += nl + tab + "SELECT @RES As Id";
					sSel += nl + tab + "RETURN @RES";
				}
				sSel += nl + "END";
			}
			return sSel;
		}
		private string BuildUpdateSP()
		{
			string sSel = "CREATE PROCEDURE [" + dbP.Schema + "].[" + txtUpdateSPName.Text + "]";
			if (bLoading == false)
			{
				int iWhereCount = 0;
				int iSelectCount = 0;
				string sParams = string.Empty;
				string sUpdate = string.Empty;
				string sWhere = nl + tab + "WHERE" + nl + tab + "(";
				Hashtable hshParam = new Hashtable();

				foreach (whereItem sItem in updateWhereList)
				{
					if (sItem.ColName != "")
					{
						//sParams += nl + tab + "@" + sItem + " " + ((ColumnProperties)dbP.Columns[sItem]).ColumnDefinition() + ",";
						iWhereCount++;
						sWhere += nl + tab + tab + "([" + sItem.ColName + "] " + sItem.SqlCriteriaString + " @" + CP(sItem.ColName) + ") AND";
						if (hshParam[sItem.ColName] == null) { hshParam.Add(sItem.ColName, sItem.ColName); }
					}
					else
					{
						sWhere = string.Empty;
					}
				}
				foreach (string sSItem in listUpdateSelect.SelectedItems)
				{
					sUpdate += nl + tab + tab + "[" + sSItem + "]=@" + CP(sSItem) + ",";
					if (hshParam[sSItem] == null) { hshParam.Add(sSItem, sSItem); }
					//sParams += nl + tab + "@" + sSItem + " " + ((ColumnProperties)dbP.Columns[sSItem]).ColumnDefinition() + ",";
					iSelectCount++;
				}
				//generte Paramslist
				IDictionaryEnumerator en = hshParam.GetEnumerator();
				while (en.MoveNext())
				{
					String sSItem = (String)en.Value;
					sParams += nl + tab + "@" + CP(sSItem) + " " + ((ColumnProperties)dbP.Columns[sSItem]).ColumnDefinition() + ",";
				}
				if (iWhereCount > 0) { sSel += nl + "("; }
				if (sWhere.Length > 20) { sWhere = sWhere.Substring(0, sWhere.Length - 3); } else { sWhere = string.Empty; }  //remove that trailing AND
				if (sWhere.Length > 0) { sWhere += nl + tab + ")"; } else { sWhere = string.Empty; }
				if (sParams.Length > 0) { sParams = sParams.Substring(0, sParams.Length - 1); } else { sParams = string.Empty; }     //remove the trailing comma
				sSel += sParams;
				if (iWhereCount > 0) { sSel += nl + ")"; }
				sSel += nl + "AS" + nl + "BEGIN" + nl + tab + "-- SET NOCOUNT ON added to prevent extra result sets from" + nl + tab + "-- interfering with UPDATE statements.";
				sSel += nl + tab + "SET NOCOUNT ON;" + nl;
				sSel += nl + tab + "UPDATE " + "[" + dbP.Schema + "].[" + ((dbP.Table.Length > 0) ? dbP.Table : dbP.View) + "]";
				sSel += nl + tab + "SET";
				sSel += sUpdate;
				//remove the trailing comma
				if (sSel.EndsWith(",")) { sSel = sSel.Substring(0, sSel.Length - 1); }
				if (iSelectCount == 0) { sSel += nl + tab + "--MUST DEFINE FIELDS TO UPDATE"; }
				sSel += sWhere;
				sSel += nl + "END";
			}
			return sSel;
		}
		private string BuildDeleteSP()
		{
			string sSel = "CREATE PROCEDURE [" + dbP.Schema + "].[" + txtDeleteSPName.Text + "]";
			if (bLoading == false)
			{
				int iWhereCount = 0;
				string sParams = string.Empty;
				string sWhere = nl + tab + "WHERE" + nl + tab + "(";

				foreach (whereItem sItem in deleteWhereList)
				{
					if (sItem.ColName != "")
					{
						sParams += nl + tab + "@" + CP(sItem.ColName) + " " + ((ColumnProperties)dbP.Columns[sItem.ColName]).ColumnDefinition() + ",";
						iWhereCount++;
						sWhere += nl + tab + tab + "([" + sItem.ColName + "] " + sItem.SqlCriteriaString + " @" + CP(sItem.ColName) + ") AND";
					}
					else
					{
						sWhere = string.Empty;
					}
				}
				if (iWhereCount > 0) { sSel += nl + "("; }
				if (sWhere.Length > 20) { sWhere = sWhere.Substring(0, sWhere.Length - 3); } else { sWhere = string.Empty; }  //remove that trailing AND
				if (sWhere.Length > 0) { sWhere += nl + tab + ")"; } else { sWhere = string.Empty; }
				if (sParams.Length > 0) { sParams = sParams.Substring(0, sParams.Length - 1); } else { sParams = string.Empty; }     //remove the trailing comma
				sSel += sParams;
				if (iWhereCount > 0) { sSel += nl + ")"; }
				sSel += nl + "AS" + nl + "BEGIN" + nl + tab + "-- SET NOCOUNT ON added to prevent extra result sets from" + nl + tab + "-- interfering with DELETE statements.";
				sSel += nl + tab + "SET NOCOUNT ON;" + nl;
				sSel += nl + tab + "DELETE";
				sSel += nl + tab + "FROM [" + dbP.Schema + "].[" + ((dbP.Table.Length > 0) ? dbP.Table : dbP.View) + "]";
				sSel += sWhere;
				sSel += nl + "END";
				if (iWhereCount == 0) { sSel += nl + nl + "--WARNING, THIS WILL DELETE THE ENTIRE CONTENTS OF " + dbP.Table; }
			}
			return sSel;
		}
		private bool CopyToClipboard(string txt2copy)
		{
			bool bRes = false;
			try
			{
				//System.Windows.Forms.Clipboard.SetText(txt2copy, TextDataFormat.UnicodeText);
				txt2copy = txt2copy.Replace("\n", System.Environment.NewLine);
				System.Windows.Forms.Clipboard.SetDataObject(txt2copy, true);
				bRes = true;
			}
			catch (Exception ex)
			{
				bRes = false;
			}
			return bRes;
		}
		private void DisplayStoredProc(string spname)
		{
			string _spText = GetSPText(spname);
			txtSPText.Rtf = sh.Highlight(_spText);
		}
		private DataSet GetSPparameters(string spname)
		{
			string[] spFullName = spname.Split('.');
			string baseSPName = spname;
			if (spFullName.Length > 1)
			{
				baseSPName = spFullName[1];
			}
			else
			{
				baseSPName = spname;
			}
			string paramQ = "select p.SPECIFIC_SCHEMA + '.' + p.SPECIFIC_NAME as SP_NAME, p.PARAMETER_NAME as PARAM_NAME, p.DATA_TYPE as PARAM_TYPE,p.CHARACTER_MAXIMUM_LENGTH as SIZE,p.NUMERIC_PRECISION as PRECISION, p.NUMERIC_SCALE AS SCALE, p.PARAMETER_MODE as DIRECTION, p.ORDINAL_POSITION from INFORMATION_SCHEMA.PARAMETERS p WHERE (p.SPECIFIC_NAME IN (SELECT name FROM sys.objects WHERE type='P') AND p.SPECIFIC_NAME = '" + baseSPName + "') ORDER BY p.SPECIFIC_NAME,p.ORDINAL_POSITION";
			SqlDataAdapter da = new SqlDataAdapter(paramQ, dbP.ConnectionString);
			DataSet ds = new DataSet("spParams");
			da.Fill(ds);
			return ds;
		}
		private string GetSPText(string spname)
		{
			string _sptext = string.Empty;
			string sptextQ = "select c.text from sysobjects o inner join syscomments c on o.id=c.id where o.id = object_id('" + spname + "')";
			;
			SqlDataAdapter da = new SqlDataAdapter(sptextQ, dbP.ConnectionString);
			DataSet ds = new DataSet("spText");
			da.Fill(ds);
			if (ds.Tables[0].Rows.Count > 0) { _sptext = ds.Tables[0].Rows[0]["text"].ToString(); }
			return _sptext;
		}
		private string ConstructWorkstring(string code2highlight)
		{
			if (code2highlight != "")
			{
				rt2.Text = code2highlight;

				// Pad out the rt2 text with spaces
				string bufferString = "";
				string[] bufferArray = rt2.Text.Split(LF);

				char padder = Space;

				int i = -1;
				while (i < ((bufferArray.Length - 2) - 1))  // All but the last line
				{
					i++;
					bufferString += bufferArray[i].PadRight(columns, padder) + LF;
				}

				// We don't want a LF tacked onto the last line of the selection
				i++;
				bufferString += bufferArray[i].PadRight(columns, padder);
				rt2.Text = bufferString;

				string workstring = rt2.Rtf;
				return workstring;
			}
			else
			{
				return string.Empty;
			}
		}
		private string CreateColorTable(string s)
		{
			// Remove any existing Color Table ...
			string re = @"{\\colortbl .*;}";
			Regex r = new Regex(re);
			s = r.Replace
					  (s,
					  "");

			// ...  and insert a new one
			re = ";}}";
			r = new Regex(re);
			return s = r.Replace
							 (s,
							 re + @"{\colortbl ;" + colorDefinitions + @"}");
		}
		private string SyntaxHighlight(string workstring)
		{
			// Keyword
			Regex r = new Regex(keywordList2);
			workstring = r.Replace(
						 workstring,
						 new MatchEvaluator(KeywordHandler));

			////Class name
			//r = new Regex(formattedClassList);
			//workstring = r.Replace(
			//             workstring,
			//             new MatchEvaluator(KeyclassHandler));

			// Character
			r = new Regex(@"'.?'");
			//(@"('[^ ]*?(?<!\)')|"); 
			workstring = r.Replace(
						 workstring,
						 new MatchEvaluator(CharacterHandler));

			// Literal
			r = new Regex(@"@?""[^""]*""");
			workstring = r.Replace(
						 workstring,
						 new MatchEvaluator(LiteralHandler));

			// Comment (Type 1): // ... ... 
			r = new Regex(@"//.*\\par");
			//(@"(/(?!//)/[^ ]*)|"); 
			workstring = r.Replace(
						 workstring,
						 new MatchEvaluator(CommentHandler));

			// Comment (Type 1): // ... ... 
			r = new Regex(@"'.*\\par");
			//(@"(/(?!//)/[^ ]*)|"); 
			workstring = r.Replace(
						 workstring,
						 new MatchEvaluator(CommentHandler));

			// Comment (Type 2): /* ... ... */
			r = new Regex(@"/\*.*?\*/", RegexOptions.Singleline);
			//(@"(/*.*?*/)|");
			workstring = r.Replace(
						 workstring,
						 new MatchEvaluator(CommentHandler));

			// Any comments embedded in literals will have been
			// highlighted and we need to clean up such instances
			r = new Regex(@""".*/\*.*?\*/.*\\par");
			workstring = r.Replace(
						 workstring,
						 new MatchEvaluator(CleanupHandler));

			return workstring;
		}
		private void PasteResult(string workstring)
		{
			txtCode.SelectAll();
			txtCode.SelectedRtf = workstring;
		}
		public void CodeHighlight(string code2highlight)
		{
			string workstring = ConstructWorkstring(code2highlight);
			if (workstring != "")
			{
				// Add a color table
				workstring = CreateColorTable(workstring);

				// Apply highlighting
				workstring = SyntaxHighlight(workstring);

				// Copy the results back to rt1
				PasteResult(workstring);

				txtCode.Focus();
				txtCode.SelectionStart = 0;
			}
		}
		public void GenerateCode(String ObjName, ref System.Windows.Forms.RichTextBox tb)
		{
			//SyntaxHighlighter sh2 = new SyntaxHighlighter(true);
			tb.Text = String.Empty;
			if (rdoStandardADO.Checked)//Standard ADO.NET
			{
				if (ValidConnection() && cboSP.Text != "")
				{
					if (this.rdoCSharp.Checked)
					{
						//do C# code
						string _code = string.Empty;
						string _try = string.Empty;
						string _catch = tab + "catch(Exception ex)" + nl + tab + "{" + nl + tab + tab + "//add error handling code here" + nl + tab + "}" + nl;
						_catch += tab + "finally" + nl + tab + "{" + nl + tab + tab + "//close or dispose of any unmanaged resources here" + nl + tab + "}" + nl;
						string _params = string.Empty;
						string _variablePrefix = tab + "//data access variables" + nl + tab + "int RETURN_VALUE = 0;" + nl;
						string _variablePostfix = tab + tab + tab + "//return paramater values" + nl;

						//get parameters - if any
						DataSet _ds = GetSPparameters(ObjName);
						foreach (DataRow dr in _ds.Tables[0].Rows)
						{
							spParam parm = new spParam();
							parm.Direction = dr["DIRECTION"].ToString();
							parm.Ordinal = System.Convert.ToInt32(dr["ORDINAL_POSITION"].ToString());
							parm.ParamName = dr["PARAM_NAME"].ToString();
							parm.ParamType = dr["PARAM_TYPE"].ToString();
							try { parm.Precision = System.Convert.ToInt32(dr["PRECISION"].ToString()); }
							catch { parm.Precision = 0; }
							try { parm.Scale = System.Convert.ToInt32(dr["SCALE"].ToString()); }
							catch { parm.Scale = 0; }
							try { parm.Size = System.Convert.ToInt32(dr["SIZE"].ToString()); }
							catch { parm.Size = 0; }
							parm.SpName = dr["SP_NAME"].ToString();
							string _dir = dr["DIRECTION"].ToString().Trim();
							switch (_dir)
							{
								case "IN":
									parm.Direction = "Input";
									break;
								case "OUT":
									parm.Direction = "Output";
									break;
								case "INOUT":
									parm.Direction = "InputOutput";
									break;
								default:
									//?? this will probably never be hit
									parm.Direction = "ReturnValue";
									break;
							}
							try { parm.Precision = System.Convert.ToInt32(dr["PRECISION"].ToString()); }
							catch { parm.Precision = 0; }
							_params += tab + tab + tab + "cmd.Parameters.Add(\"" + parm.ParamName + "\"," + parm.ParamDef() + ");" + nl;
							_params += tab + tab + tab + "cmd.Parameters[\"" + parm.ParamName + "\"].Value = " + parm.VariableName() + ";" + nl;
							_params += tab + tab + tab + "cmd.Parameters[\"" + parm.ParamName + "\"].Direction = System.Data.ParameterDirection." + parm.Direction + ";" + nl;
							_variablePrefix += tab + parm.VariableType() + " " + parm.VariableName() + " = [VALUE HERE];" + nl;
							if (_dir.Contains("OUT")) { _variablePostfix += tab + tab + tab + parm.VariableName() + " = (" + parm.VariableType() + ")cmd.Parameters[\"" + parm.ParamName + "\"].Value;" + nl; }
						}

						_try += nl + tab + "//code coments here" + nl + tab + "try" + nl + tab + "{" + nl;
						_code += tab + tab + "//add or reference production connection string here" + nl;
						_code += tab + tab + "string connectionString = \"" + dbP.BuildConnectionString() + "\";" + nl;
						_code += tab + tab + "using (SqlConnection connection1 = new SqlConnection(connectionString))" + nl;
						_code += tab + tab + "{" + nl;
						_code += tab + tab + tab + "connection1.Open();" + nl;
						_code += tab + tab + tab + "SqlCommand cmd = new SqlCommand(\"" + ObjName + "\", connection1);" + nl;
						_code += tab + tab + tab + "cmd.CommandType = CommandType.StoredProcedure;" + nl;
						_code += tab + tab + tab + "cmd.Parameters.Add(\"@RETURN_VALUE\", System.Data.SqlDbType.Int, 0);" + nl;
						_code += tab + tab + tab + "cmd.Parameters[\"@RETURN_VALUE\"].Direction = System.Data.ParameterDirection.ReturnValue;" + nl;
						_code += tab + tab + tab + "cmd.Parameters[\"@RETURN_VALUE\"].Value = RETURN_VALUE;" + nl;
						_code += _params;
						switch (m_genType)
						{
							case eGenType.datareader:
								_code += tab + tab + tab + "SqlDataReader dr = cmd.ExecuteReader();" + nl;
								_code += tab + tab + tab + "while (dr.Read())" + nl;
								_code += tab + tab + tab + "{" + nl;
								_code += tab + tab + tab + tab + "//read your results here" + nl;
								_code += tab + tab + tab + tab + "//review the text of the stored procedure for any additional results that may be returned" + nl;

								System.Collections.Generic.List<ColumnProperties> returnColumns = this.TestSPWithDefaults(ObjName);
								if (returnColumns.Count > 0)
								{
									foreach (ColumnProperties cp in returnColumns)
									{
										_code += tab + tab + tab + tab + ((cp.TableOrdinal == 0) ? "" : "//") + cp.Cast2NetCode() + tab + tab + "// field " + cp.Column + " [" + cp.Type + "] returned in resultset " + cp.TableOrdinal.ToString() + nl;
									}
								}
								else
								{

									// do this only as a last resort
									//System.Collections.Generic.List<ColumnProperties> allFields = dbTableParameters.GetAllFields(dbP.BuildConnectionString(), this.cboDatabases.Text);

									//foreach (dbSPReturns spField in dbTableParameters.GetSPReturns(ObjName, dbP.BuildConnectionString()))
									//{
									//    foreach (ColumnProperties field in allFields)
									//    {
									//        if (field.Table == dbTableParameters.StripSchema(spField.Table) && field.Column == spField.Column)
									//        {
									//            _code += tab + tab + tab + tab + "// this field corresponds to the StoredProcedure return field " + spField.Column + " from " + spField.Table + nl;
									//            _code += tab + tab + tab + tab + field.Cast2NetCode() + nl;
									//            break;
									//        }
									//    }
									//}
									_code += tab + tab + tab + tab + "// SAMPLE: string _variable = rdr[\"Name\"].ToString();" + nl;
								}
								_code += tab + tab + tab + "}" + nl;
								break;

							case eGenType.dataset:
								_code += tab + tab + tab + "SqlDataAdapter adapter = new SqlDataAdapter(cmd);" + nl;
								_code += tab + tab + tab + "DataSet ds = new DataSet();" + nl;
								_code += tab + tab + tab + "adapter.Fill(ds);" + nl;
								_code += tab + tab + tab + "foreach (DataRow dr in ds.Tables[0].Rows)" + nl;
								_code += tab + tab + tab + "{" + nl;
								_code += tab + tab + tab + tab + "//read your results here" + nl;
								_code += tab + tab + tab + tab + "//review the text of the stored procedure for results that may be returned" + nl;
								System.Collections.Generic.List<ColumnProperties> returnColumnsDS = this.TestSPWithDefaults(ObjName);
								if (returnColumnsDS.Count > 0)
								{
									foreach (ColumnProperties cp in returnColumnsDS)
									{
										_code += tab + tab + tab + tab + ((cp.TableOrdinal == 0) ? "" : "//") + cp.Cast2NetCode() + tab + tab + "// field " + cp.Column + " [" + cp.Type + "] returned in resultset " + cp.TableOrdinal.ToString() + nl;
									}
								}
								else
								{
									_code += tab + tab + tab + tab + "// SAMPLE: string _variable = dr[\"Name\"].ToString();" + nl;
								}
								_code += tab + tab + tab + "}" + nl;
								break;
							case eGenType.nonquery:
								_code += tab + tab + tab + "cmd.ExecuteNonQuery();" + nl;
								break;
							case eGenType.scalar:
								//Object obj = cmd.ExecuteScalar();
								//_userID = (Decimal)obj
								_code += tab + tab + tab + "Object obj = cmd.ExecuteScalar();" + nl + nl;
								_code += tab + tab + tab + "//CAST SCALAR OBJECT TO DESIRED TYPE HERE" + nl;
								_code += tab + tab + tab + "//int _scalrResult = (Decimal)obj" + nl + nl;
								break;
						}
						_code += tab + tab + tab + "//return value from stored procedure" + nl;
						_code += tab + tab + tab + "RETURN_VALUE = ((int)(cmd.Parameters[\"@RETURN_VALUE\"].Value));" + nl;
						_code += _variablePostfix;
						if (_variablePostfix.Length <= 38) { _code += tab + tab + tab + "//no OUT or INOUT parameters to return" + nl; }
						_code += tab + tab + tab + "}" + nl;
						CodeHighlight(_variablePrefix + _try + _code + tab + "}" + nl + _catch);
					}
					else
					{
						//do VB.Net code
						string _code = string.Empty;
						string _try = string.Empty;
						string _catch = tab + "Catch ex As Exception" + nl + tab + "'add error handling code here" + nl;
						_catch += tab + "Finally" + nl + tab + "'close or dispose of any unmanaged resources here" + nl;
						string _params = string.Empty;
						string _variablePrefix = tab + "'data access variables" + nl + tab + "Dim RETURN_VALUE As int = 0" + nl;
						string _variablePostfix = tab + tab + tab + "'return paramater values" + nl;

						//get parameters - if any
						DataSet _ds = GetSPparameters(ObjName);
						foreach (DataRow dr in _ds.Tables[0].Rows)
						{
							spParam parm = new spParam();
							parm.Direction = dr["DIRECTION"].ToString();
							parm.Ordinal = System.Convert.ToInt32(dr["ORDINAL_POSITION"].ToString());
							parm.ParamName = dr["PARAM_NAME"].ToString();
							parm.ParamType = dr["PARAM_TYPE"].ToString();
							try { parm.Precision = System.Convert.ToInt32(dr["PRECISION"].ToString()); }
							catch { parm.Precision = 0; }
							try { parm.Scale = System.Convert.ToInt32(dr["SCALE"].ToString()); }
							catch { parm.Scale = 0; }
							try { parm.Size = System.Convert.ToInt32(dr["SIZE"].ToString()); }
							catch { parm.Size = 0; }
							parm.SpName = dr["SP_NAME"].ToString();
							string _dir = dr["DIRECTION"].ToString().Trim();
							switch (_dir)
							{
								case "IN":
									parm.Direction = "Input";
									break;
								case "OUT":
									parm.Direction = "Output";
									break;
								case "INOUT":
									parm.Direction = "InputOutput";
									break;
								default:
									//?? this will probably never be hit
									parm.Direction = "ReturnValue";
									break;
							}
							try { parm.Precision = System.Convert.ToInt32(dr["PRECISION"].ToString()); }
							catch { parm.Precision = 0; }
							_params += tab + tab + tab + "cmd.Parameters.Add(\"" + parm.ParamName + "\"," + parm.ParamDef() + ")" + nl;
							_params += tab + tab + tab + "cmd.Parameters(\"" + parm.ParamName + "\").Value = " + parm.VariableName() + nl;
							_params += tab + tab + tab + "cmd.Parameters(\"" + parm.ParamName + "\").Direction = System.Data.ParameterDirection." + parm.Direction + nl;
							_variablePrefix += tab + "Dim " + parm.VariableName() + " as " + parm.VariableType() + " = [VALUE HERE]" + nl;
							if (_dir.Contains("OUT"))
							{
								_variablePostfix += tab + tab + tab + parm.VariableName() + " = CType(" + "cmd.Parameters[\"" + parm.ParamName + "\"].Value, " + parm.VariableconversionType() + nl;
							}
						}

						_try += nl + tab + "'code coments here" + nl + tab + "Try" + nl;
						_code += tab + tab + "'add or reference production connection string here" + nl;
						_code += tab + tab + "Dim connectionString as String = \"" + dbP.BuildConnectionString() + "\"" + nl;
						_code += tab + tab + "Using connection1 as SqlConnection = New SqlConnection(connectionString)" + nl;
						_code += tab + tab + tab + "connection1.Open()" + nl;
						_code += tab + tab + tab + "Dim cmd as SqlCommand = New SqlCommand(\"" + ObjName + "\", connection1)" + nl;
						_code += tab + tab + tab + "cmd.CommandType = CommandType.StoredProcedure" + nl;
						_code += tab + tab + tab + "cmd.Parameters.Add(\"@RETURN_VALUE\", System.Data.SqlDbType.Int, 0)" + nl;
						_code += tab + tab + tab + "cmd.Parameters(\"@RETURN_VALUE\").Direction = System.Data.ParameterDirection.ReturnValue" + nl;
						_code += tab + tab + tab + "cmd.Parameters(\"@RETURN_VALUE\").Value = RETURN_VALUE" + nl;
						_code += _params;
						switch (m_genType)
						{
							case eGenType.datareader:
								_code += tab + tab + tab + "Dim rdr as SqlDataReader = cmd.ExecuteReader()" + nl;
								_code += tab + tab + tab + "While (rdr.Read())" + nl;
								_code += tab + tab + tab + tab + "'read your results here" + nl;
								_code += tab + tab + tab + tab + "'review the text of the stored procedure for results that may be returned" + nl;
								_code += tab + tab + tab + tab + "'Dim _variable as String = rdr(\"Name\").ToString()" + nl;
								_code += tab + tab + tab + "End While" + nl;
								break;

							case eGenType.dataset:
								_code += tab + tab + tab + "Dim adapter as SqlDataAdapter = New SqlDataAdapter(cmd)" + nl;
								_code += tab + tab + tab + "Dim ds as DataSet = New DataSet()" + nl;
								_code += tab + tab + tab + "adapter.Fill(ds)" + nl;
								_code += tab + tab + tab + "For Each dr as DataRow in ds.Tables(0).Rows" + nl;
								_code += tab + tab + tab + tab + "'read your results here" + nl;
								_code += tab + tab + tab + tab + "'review the text of the stored procedure for results that may be returned" + nl;
								_code += tab + tab + tab + tab + "'Dim _variable as String = dr(\"Name\").ToString()" + nl;
								_code += tab + tab + tab + "Next dr" + nl;
								break;
							case eGenType.nonquery:
								_code += tab + tab + tab + "cmd.ExecuteNonQuery();" + nl;
								break;
							case eGenType.scalar:
								//Object obj = cmd.ExecuteScalar();
								//_userID = (Decimal)obj
								_code += tab + tab + tab + "Dim obj as Object = cmd.ExecuteScalar()" + nl + nl;
								_code += tab + tab + tab + "'CAST SCALAR OBJECT TO DESIRED TYPE HERE" + nl;
								_code += tab + tab + tab + "'Dim _scalarResult as Int = System.Convert.ToInt32(obj)" + nl + nl;
								break;
						}
						_code += tab + tab + tab + "'return value from stored procedure" + nl;
						_code += tab + tab + tab + "RETURN_VALUE = System.Convert.ToInt32(cmd.Parameters[\"@RETURN_VALUE\"].Value.ToString())" + nl;
						_code += _variablePostfix;
						if (_variablePostfix.Length <= 36) { _code += tab + tab + tab + "'no OUT or INOUT parameters to return" + nl; }
						_code += tab + tab + "End Using" + nl;
						CodeHighlight(_variablePrefix + _try + _code + nl + _catch + tab + "End Try" + nl);
					}
				}
			}
			else if (this.rdoADO.Checked) //ADO.Net with Enterprise block SqlHelper
			{
				string _paramVariables = string.Empty;
				string _paramSetters = string.Empty;
				string _paramSettersVB = string.Empty;
				string _code = string.Empty;
				if (this.rdoCSharp.Checked)
				{
					//use c#
					//SqlHelper.ExecuteNonQuery(_conn, "spI_tTransHistory", System.DBNull.Value, sourceID, accountID, activityID, points, verification_code, processID, _commentid, transaction_date, Now)
					List<spParam> _parms = GetSpParamList(cboSP.Text);
					foreach (spParam spp in _parms)
					{
						_paramVariables += spp.VariableName() + ", ";
						_paramSetters += " " + spp.VariableType() + " " + spp.VariableName() + " = [SET VALUE HERE];" + nl;
						//_paramSetters += "Dim " + spp.VariableName() + " As " + spp.VariableType() + " = [SET VALUE HERE]" + nl;
					}
					_paramVariables = _paramVariables.Substring(0, _paramVariables.Length - 2);
					switch (m_genType)
					{
						case eGenType.datareader:
							_code += " //add or reference production connection string here" + nl;
							_code += " string _connectionString = \"" + dbP.BuildConnectionString() + "\";" + nl + nl;
							_code += " //local variables" + nl;
							_code += " DataSet ds = new DataSet();" + nl;
							_code += _paramSetters + nl;
							_code += " try" + nl + " {" + nl;
							_code += tab + "ds = SqlHelper.ExecuteDataSet(_connectionString, \"" + ObjName + "\", " + _paramVariables + " );" + nl;
							_code += " }" + nl + "catch(Exception ex)" + nl + " {" + nl + tab + "//error handling here" + nl + " }" + nl;
							break;
						case eGenType.dataset:
							_code += " //add or reference production connection string here" + nl;
							_code += " string _connectionString = \"" + dbP.BuildConnectionString() + "\";" + nl + nl;
							_code += " //local variables" + nl;
							_code += " DataSet ds = new DataSet();" + nl;
							_code += _paramSetters + nl;
							_code += " try" + nl + " {" + nl;
							_code += tab + " ds = SqlHelper.ExecuteDataSet(_connectionString, \"" + ObjName + "\", " + _paramVariables + " );" + nl;
							_code += " }" + nl + " catch(Exception ex)" + nl + " {" + nl + tab + "//error handling here" + nl + " }" + nl;
							break;
						case eGenType.nonquery:
							_code += " //add or reference production connection string here" + nl;
							_code += " string _connectionString = \"" + dbP.BuildConnectionString() + "\";" + nl + nl;
							_code += " //local variables" + nl;
							_code += _paramSetters + nl;
							_code += " try" + nl + " {" + nl;
							_code += tab + "SqlHelper.ExecuteNonQuery(_connectionString, \"" + ObjName + "\", " + _paramVariables + " );" + nl;
							_code += " }" + nl + " catch(Exception ex)" + nl + " {" + nl + tab + "//error handling here" + nl + " }" + nl;
							break;
						case eGenType.scalar:
							_code += " //add or reference production connection string here" + nl;
							_code += " string _connectionString = \"" + dbP.BuildConnectionString() + "\";" + nl + nl;
							_code += " //local variables" + nl;
							_code += " int RESULT = -1;" + nl;
							_code += _paramSetters + nl;
							_code += " try" + nl + " {" + nl;
							_code += tab + "RESULT = (int)SqlHelper.ExecuteScalar(_connectionString, \"" + ObjName + "\", " + _paramVariables + " );" + nl;
							_code += " }" + nl + " catch(Exception ex)" + nl + " {" + nl + tab + "//error handling here" + nl + " }" + nl;
							
							break;
					}
					CodeHighlight( _code );
				}
				else
				{
					//use vb.net
					//SqlHelper.ExecuteNonQuery(_conn, "spI_tTransHistory", System.DBNull.Value, sourceID, accountID, activityID, points, verification_code, processID, _commentid, transaction_date, Now)
					List<spParam> _parms = GetSpParamList(cboSP.Text);
					foreach (spParam spp in _parms)
					{
						_paramVariables += spp.VariableName() + ", ";
						_paramSettersVB += " Dim " + spp.VariableName() + " As " + spp.VariableType() + " = [SET VALUE HERE]" + nl;
					}
					_paramVariables =  _paramVariables.Substring(0, _paramVariables.Length - 2);
					switch (m_genType)
					{
						case eGenType.datareader:
							_code += " 'add or reference production connection string here" + nl;
							_code += " Dim _connectionString As string = \"" + dbP.BuildConnectionString() + "\"" + nl + nl;
							_code += " 'local variables" + nl;
							_code += " Dim ds As DataSet = New DataSet()" + nl;
							_code += _paramSettersVB + nl;
							_code += " Try" + nl;
							_code += tab + "ds = SqlHelper.ExecuteDataSet(_connectionString, \"" + ObjName + "\", " + _paramVariables + " )" + nl;
							_code += " Catch ex As Exception" + nl + tab + "'add error handling code here" + nl + " End Try" + nl;
							break;
						case eGenType.dataset:
							_code += " 'add or reference production connection string here" + nl;
							_code += " Dim _connectionString As string = \"" + dbP.BuildConnectionString() + "\"" + nl + nl;
							_code += " 'local variables" + nl;
							_code += " Dim ds As DataSet = New DataSet()" + nl;
							_code += _paramSettersVB + nl;
							_code += " Try" + nl;
							_code += tab + "ds = SqlHelper.ExecuteDataSet(_connectionString, \"" + ObjName + "\", " + _paramVariables + " )" + nl;
							_code += " Catch ex As Exception" + nl + tab + "'add error handling code here" + nl + " End Try" + nl;
							break;
						case eGenType.nonquery:
							_code += " 'add or reference production connection string here" + nl;
							_code += " Dim _connectionString As string = \"" + dbP.BuildConnectionString() + "\"" + nl + nl;
							_code += " 'local variables" + nl;
							_code += _paramSettersVB + nl;
							_code += " Try" + nl;
							_code += tab + "SqlHelper.ExecuteNonQuery(_connectionString, \"" + ObjName + "\", " + _paramVariables + " )" + nl;
							_code += " Catch ex As Exception" + nl + tab + "'add error handling code here" + nl + " End Try" + nl;
							break;
						case eGenType.scalar:
							_code += " 'add or reference production connection string here" + nl;
							_code += " Dim _connectionString As string = \"" + dbP.BuildConnectionString() + "\"" + nl + nl;
							_code += " 'local variables" + nl;
							_code += " Dim RESULT As int" + nl;
							_code += _paramSettersVB + nl;
							_code += " Try" + nl;
							_code += tab + "RESULT = CType(SqlHelper.ExecuteScalar(_conndbTableParameters.StripSchema(ObjName)ectionString, \"" + ObjName + "\", " + _paramVariables + " ),int)" + nl;
							_code += " Catch ex As Exception" + nl + tab + "'add error handling code here" + nl + " End Try" + nl;
							break;
					}
					CodeHighlight(_code);
				}

			}
			else if (this.rdoTiersSingle.Checked)//Single Result Tiers Code
			{
				StringBuilder sbInterface = new StringBuilder();
				StringBuilder sbDTO = new StringBuilder();
				System.Collections.Generic.List<ColumnProperties> returnColumns = this.TestSPWithDefaults(ObjName);
                string dataclassName = dbTableParameters.StripSchema(ObjName);
                string newdataclassName = DS.UIControls.Boxes.InputPrompt.Show("Provide an Name for generated data class and interface.", dataclassName);
                if (newdataclassName != null)
                {
                    dataclassName = newdataclassName;
                }
                string dataaccessclassName = dbTableParameters.StripSchema(CP(ObjName));
                string newdataaccessclassName = DS.UIControls.Boxes.InputPrompt.Show("Provide an Name for generated data access client class.", dataaccessclassName);
                if (newdataclassName != null)
                {
                    dataaccessclassName = newdataaccessclassName;
                }
				int _tableCount = (from p in returnColumns select p.TableOrdinal).Distinct().Count();
				for (int i = 0; i < _tableCount; i++)
				{
					if (this.rdoCSharp.Checked)
					{
						sbInterface.AppendLine("public interface I" + dataclassName + "_ResultSet" + i.ToString() + "Row");
						sbInterface.AppendLine("{");
						sbDTO.AppendLine("public class " + dataclassName + "_ResultSet" + i.ToString() + "Row : " + "I" + dataclassName + "_ResultSet" + i.ToString() + "Row, INotifyPropertyChanged");
						sbDTO.AppendLine("{");
						sbDTO.AppendLine(tab + "public event PropertyChangedEventHandler PropertyChanged;");
						sbDTO.AppendLine(tab + "private void NotifyPropertyChanged(String info)");
						sbDTO.AppendLine(tab + "{");
						sbDTO.AppendLine(tab + tab + "if (PropertyChanged != null)");
						sbDTO.AppendLine(tab + tab+ "{");
						sbDTO.AppendLine(tab + tab+ tab + "PropertyChanged(this, new PropertyChangedEventArgs(info));");
						sbDTO.AppendLine(tab + tab+ "}");
						sbDTO.AppendLine(tab + "}");
					}
					else
					{
						sbInterface.AppendLine("Public Interface I" + dataclassName + "_ResultSet" + i.ToString() + "Row");
						sbDTO.AppendLine("Public Class " + dataclassName + "_ResultSet" + i.ToString() + "Row Implements I" + dataclassName + "_ResultSet" + i.ToString() + "Row, INotifyPropertyChanged");
						sbDTO.AppendLine(tab + "Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged");
						sbDTO.AppendLine(tab + "Private Sub NotifyPropertyChanged(ByVal info As String)");
						sbDTO.AppendLine(tab + tab + "RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))");
						sbDTO.AppendLine(tab + "End Sub");
					}
					if (returnColumns.Count > 0)
					{
						//at least something was returned
						//check the number of tables returned

						foreach (ColumnProperties cp in returnColumns)
						{
							if (cp.TableOrdinal == i)
							{
								if (this.rdoCSharp.Checked)
								{
									// interface build for return types
									sbInterface.AppendLine(tab + cp.Type + " " + CP(cp.Column) + "{ get; set; }");
									// DTO build for return types
									sbDTO.AppendLine(tab + "private " + cp.Type + " _" + CP(cp.Column) + ";");
									sbDTO.AppendLine(tab + "public " + cp.Type + " " + CP(cp.Column));
									sbDTO.AppendLine(tab + "{");
									sbDTO.AppendLine(tab + tab + "get { return _" + CP(cp.Column) + ";}");
									sbDTO.AppendLine(tab + tab + "set");
									sbDTO.AppendLine(tab + tab + "{");
									sbDTO.AppendLine(tab + tab + tab + "if(value != this._" + CP(cp.Column) + ")");
									sbDTO.AppendLine(tab + tab + tab + "{");
									sbDTO.AppendLine(tab + tab + tab + tab + "this._" + CP(cp.Column) + " = value;");
									sbDTO.AppendLine(tab + tab + tab + tab + "NotifyPropertyChanged(\"" + CP(cp.Column) + "\");");
									sbDTO.AppendLine(tab + tab + tab + "}");
									sbDTO.AppendLine(tab + tab + "}");
									sbDTO.AppendLine(tab + "}");
								}
								else
								{
									// interface build for return types
									// Property OwnerName() As String
									sbInterface.AppendLine(tab + "Property " + CP(cp.Column) + "() As " + cp.Type);
									// DTO build for return types
									sbDTO.AppendLine(tab + "Dim _" + CP(cp.Column) + " As " + cp.Type);
									sbDTO.AppendLine(tab + "Public Property " + CP(cp.Column) + "() As " + cp.Type);
									sbDTO.AppendLine(tab + tab + "Get");
									sbDTO.AppendLine(tab + tab + tab + "Return _" + CP(cp.Column));
									sbDTO.AppendLine(tab + tab + "End Get");
									sbDTO.AppendLine(tab + tab + "Set(ByVal value As "+ cp.Type + ")");
									sbDTO.AppendLine(tab + tab + tab + "If Not (value = _" + CP(cp.Column) + ") Then");
									sbDTO.AppendLine(tab + tab + tab + tab + "_" + CP(cp.Column) + " = value");
									sbDTO.AppendLine(tab + tab + tab + tab + "NotifyPropertyChanged(\"" + CP(cp.Column) + "\")");
									sbDTO.AppendLine(tab + tab + tab + "End If");
									sbDTO.AppendLine(tab + tab + "End Set");
									sbDTO.AppendLine(tab + "End Property");

								}
							}
						}
					}
					else
					{

					}
					if (this.rdoCSharp.Checked)
					{
						sbInterface.AppendLine("}");
						sbDTO.AppendLine("}");
					}
					else
					{
						sbInterface.AppendLine("End Interface");
						sbDTO.AppendLine("End Class");
					}
				}
				if (ValidConnection() && cboSP.Text != "")
				{
					if (this.rdoCSharp.Checked)
					{
						//do C# code
						string _code = "";
						string _method = "public class " + dataaccessclassName + "_DataClient" + nl;
						_method += "{" + nl;
						_method += tab + "public int Execute(";
						
						string _try = string.Empty;
						string _catch = tab + tab + "catch(Exception ex)" + nl + tab + tab + "{" + nl + tab + tab + tab + "//add error handling code here" + nl + tab + tab + "}" + nl;
						_catch += tab + tab + "finally" + nl + tab + tab + "{" + nl + tab + tab + tab + "//close or dispose of any unmanaged resources here" + nl + tab + tab + "}" + nl;
						string _params = string.Empty;
						string _variablePrefix = tab + tab + "//data access variables" + nl + tab + tab + "int RETURN_VALUE = 0;" + nl;
						string _variablePostfix = tab + tab + tab + tab + "//return paramater values" + nl;
						string _exeParms = "";
						//get parameters - if any
						DataSet _ds = GetSPparameters(ObjName);
						foreach (DataRow dr in _ds.Tables[0].Rows)
						{
							spParam parm = new spParam();
							parm.Direction = dr["DIRECTION"].ToString();
							parm.Ordinal = System.Convert.ToInt32(dr["ORDINAL_POSITION"].ToString());
							parm.ParamName = dr["PARAM_NAME"].ToString();
							parm.ParamType = dr["PARAM_TYPE"].ToString();
							try { parm.Precision = System.Convert.ToInt32(dr["PRECISION"].ToString()); }
							catch { parm.Precision = 0; }
							try { parm.Scale = System.Convert.ToInt32(dr["SCALE"].ToString()); }
							catch { parm.Scale = 0; }
							try { parm.Size = System.Convert.ToInt32(dr["SIZE"].ToString()); }
							catch { parm.Size = 0; }
							parm.SpName = dr["SP_NAME"].ToString();
							string _dir = dr["DIRECTION"].ToString().Trim();
							string _paramDir = "";
							switch (_dir)
							{
								case "IN":
									parm.Direction = "Input";
									break;
								case "OUT":
									parm.Direction = "Output";
									_paramDir = "out ";
									break;
								case "INOUT":
									parm.Direction = "InputOutput";
									_paramDir = "ref ";
									break;
								default:
									//?? this will probably never be hit
									parm.Direction = "ReturnValue";
									_paramDir = "out ";
									break;
							}
							try { parm.Precision = System.Convert.ToInt32(dr["PRECISION"].ToString()); }
							catch { parm.Precision = 0; }
							_params += tab + tab + tab + tab + "cmd.Parameters.Add(\"" + parm.ParamName + "\"," + parm.ParamDef() + ");" + nl;
							_params += tab + tab + tab + tab + "cmd.Parameters[\"" + parm.ParamName + "\"].Value = " + parm.VariableName() + ";" + nl;
							_params += tab + tab + tab + tab + "cmd.Parameters[\"" + parm.ParamName + "\"].Direction = System.Data.ParameterDirection." + parm.Direction + ";" + nl;
							_variablePrefix += tab + tab + parm.VariableType() + " " + parm.VariableName() + " = " + parm.ParamName.Replace("@", "").ToLower() + ";" + nl;
							if (_dir.Contains("OUT")) { _variablePostfix += tab + tab + tab + parm.VariableName() + " = (" + parm.VariableType() + ")cmd.Parameters[\"" + parm.ParamName + "\"].Value;" + nl; }
							_exeParms += _paramDir + parm.VariableType() + " " + (parm.ParamName.Replace("@","") ).ToLower() + ", ";
						}
						
						for(int i=0;i<_tableCount;i++)
						{
							_variablePrefix += tab + tab + dataclassName + "_ResultSet" + i.ToString() + "Row _" + dataclassName + "_ResultSet" + i.ToString() + "Row = new " + dataclassName + "_ResultSet" + i.ToString() + "Row();" + nl;
							_exeParms += "out I" + dataclassName + "_ResultSet" + i.ToString() + "Row " + (dataclassName + "_ResultSet" + i.ToString() + "Row").ToLower() + ", ";
						}

						if (_exeParms.Length > 0) { _exeParms = _exeParms.Substring(0, _exeParms.Length - 2); }
						_method += _exeParms + ")" + nl;
						_method += tab + "{" + nl;

						_try += nl + tab + tab + "//code coments here" + nl + tab + tab + "try" + nl + tab + tab + "{" + nl;
						_code += tab + tab + tab + "//add or reference production connection string here" + nl;
						_code += tab + tab + tab + "string connectionString = \"" + dbP.BuildConnectionString() + "\";" + nl;
						_code += tab + tab + tab + "using (SqlConnection connection1 = new SqlConnection(connectionString))" + nl;
						_code += tab + tab + tab + "{" + nl;
						_code += tab + tab + tab + tab + "connection1.Open();" + nl;
						_code += tab + tab + tab + tab + "SqlCommand cmd = new SqlCommand(\"" + ObjName + "\", connection1);" + nl;
						_code += tab + tab + tab + tab + "cmd.CommandType = CommandType.StoredProcedure;" + nl;
						_code += tab + tab + tab + tab + "cmd.Parameters.Add(\"@RETURN_VALUE\", System.Data.SqlDbType.Int, 0);" + nl;
						_code += tab + tab + tab + tab + "cmd.Parameters[\"@RETURN_VALUE\"].Direction = System.Data.ParameterDirection.ReturnValue;" + nl;
						_code += tab + tab + tab + tab + "cmd.Parameters[\"@RETURN_VALUE\"].Value = RETURN_VALUE;" + nl;
						_code += _params;
						_code += tab + tab + tab + tab + "SqlDataReader rdr = cmd.ExecuteReader();" + nl;
						_code += tab + tab + tab + tab + "int _currentResultSet = 0;" + nl;
						_code += tab + tab + tab + tab + "do" + nl;
						_code += tab + tab + tab + tab + "{" + nl;
						_code += tab + tab + tab + tab + tab + "while (rdr.Read())" + nl;
						_code += tab + tab + tab + tab + tab + "{" + nl;
						_code += tab + tab + tab + tab + tab + tab + "switch(_currentResultSet)" + nl;
						_code += tab + tab + tab + tab + tab + tab + "{" + nl;
					   
						for (int _currentResultSet = 0; _currentResultSet < _tableCount; _currentResultSet++)
						{
							_code += tab + tab + tab + tab + tab + tab + tab + "case " + _currentResultSet.ToString() + ":" + nl;
							if (returnColumns.Count > 0)
							{
								_code += tab + tab + tab + tab + tab + tab + tab + tab + "//read your results here" + nl;
								_code += tab + tab + tab + tab + tab + tab + tab + tab + "//review the text of the stored procedure for any additional results that may be returned" + nl;
								foreach (ColumnProperties cp in returnColumns)
								{
									if (cp.TableOrdinal == _currentResultSet)
									{
										_code += tab + tab + tab + tab + tab + tab + tab + tab + cp.Cast2NetClassCode("_" + dataclassName + "_ResultSet" + cp.TableOrdinal.ToString() + "Row") + tab + tab + "// return field " + cp.Column + " [" + cp.Type + "]" + nl;
									}
								}
							}
							else
							{
								_code += tab + tab + tab + tab + tab + tab + "// SAMPLE: string _variable = rdr[\"Name\"].ToString();" + nl;
							}
							_code += tab + tab + tab + tab + tab + tab + tab + tab + "break;" + nl;
						}

						_code += tab + tab + tab + tab + tab + tab + "}" + nl;

						_code += tab + tab + tab + tab + tab + "}" + nl;
						_code += tab + tab + tab + tab + tab + "_currentResultSet++;" + nl;
						_code += tab + tab + tab + tab + "} while (rdr.NextResult());" + nl;

						_code += tab + tab + tab + tab + "//return value from stored procedure" + nl;
						_code += tab + tab + tab + tab + "RETURN_VALUE = ((int)(cmd.Parameters[\"@RETURN_VALUE\"].Value));" + nl;
						_code += _variablePostfix;
						if (_variablePostfix.Length <= 38) { _code += tab + tab + tab + tab + "//no OUT or INOUT parameters to return" + nl; }
						_code += tab + tab + tab + "}" + nl;
						string _return = "";
						for (int i = 0; i < _tableCount; i++)
						{
							_return += tab + tab +( dataclassName + "_ResultSet" + i.ToString()).ToLower() + "row = (I" + dataclassName + "_ResultSet" + i.ToString() + "Row)_" + dataclassName + "_ResultSet" + i.ToString() + "Row;" + nl;
						}
						_return += tab + tab + "return RETURN_VALUE;" + nl;
						CodeHighlight(sbInterface.ToString() + nl + sbDTO.ToString() + nl + _method + _variablePrefix + _try + _code + tab + tab + "}" + nl + _catch + _return + nl + tab + "}" + nl + "}" + nl );
					}
					else
					{
						//do VB.Net code
						string _code = string.Empty;
						string _method = "Public Class " + dataaccessclassName + "_DataClient" + nl;
						_method += tab + "Public Function Execute(";
						
						string _try = string.Empty;
						string _catch = tab + tab + "Catch ex As Exception" + nl + tab + tab + tab + "'add error handling code here" + nl;
						_catch += tab + tab + "Finally" + nl + tab + tab + tab + "'close or dispose of any unmanaged resources here" + nl;
						string _params = string.Empty;
						string _variablePrefix = tab + tab + "'data access variables" + nl + tab + tab + "Dim RETURN_VALUE As int = 0" + nl;
						string _variablePostfix = tab + tab + tab + tab + "'return paramater values" + nl;
						string _exeParams = "";
						//get parameters - if any
						DataSet _ds = GetSPparameters(ObjName);
						foreach (DataRow dr in _ds.Tables[0].Rows)
						{
							spParam parm = new spParam();
							parm.Direction = dr["DIRECTION"].ToString();
							parm.Ordinal = System.Convert.ToInt32(dr["ORDINAL_POSITION"].ToString());
							parm.ParamName = dr["PARAM_NAME"].ToString();
							parm.ParamType = dr["PARAM_TYPE"].ToString();
							try { parm.Precision = System.Convert.ToInt32(dr["PRECISION"].ToString()); }
							catch { parm.Precision = 0; }
							try { parm.Scale = System.Convert.ToInt32(dr["SCALE"].ToString()); }
							catch { parm.Scale = 0; }
							try { parm.Size = System.Convert.ToInt32(dr["SIZE"].ToString()); }
							catch { parm.Size = 0; }
							parm.SpName = dr["SP_NAME"].ToString();
							string _dir = dr["DIRECTION"].ToString().Trim();
							string _paramDir = "";
							switch (_dir)
							{
								case "IN":
									parm.Direction = "Input";
									break;
								case "OUT":
									parm.Direction = "Output";
									_paramDir = "out ";
									break;
								case "INOUT":
									parm.Direction = "InputOutput";
									_paramDir = "ref ";
									break;
								default:
									//?? this will probably never be hit
									parm.Direction = "ReturnValue";
									_paramDir = "out ";
									break;
							}
							try { parm.Precision = System.Convert.ToInt32(dr["PRECISION"].ToString()); }
							catch { parm.Precision = 0; }
							_params += tab + tab + tab + tab + "cmd.Parameters.Add(\"" + parm.ParamName + "\"," + parm.ParamDef() + ")" + nl;
							_params += tab + tab + tab + tab + "cmd.Parameters(\"" + parm.ParamName + "\").Value = " + parm.VariableName() + nl;
							_params += tab + tab + tab + tab + "cmd.Parameters[\"" + parm.ParamName + "\"].Direction = System.Data.ParameterDirection." + parm.Direction + nl;
							_variablePrefix += tab + tab + "Dim " + parm.VariableName() + " as " + parm.VariableType() + " = " + parm.ParamName.Replace("@", "").ToLower() + nl;
							if (_dir.Contains("OUT"))
							{
								_variablePostfix += tab + tab + tab + parm.VariableName() + " = CType(" + "cmd.Parameters[\"" + parm.ParamName + "\"].Value, " + parm.VariableconversionType() + nl;
							}
							_exeParams += "ByVal " + (parm.ParamName.Replace("@", "") ).ToLower() + " As " + parm.VariableType() + ", ";
						}
						for (int i = 0; i < _tableCount; i++)
						{
							_variablePrefix += tab + tab + "Dim _" + dataclassName + "_ResultSet" + i.ToString() + "Row As " + dataclassName + "_ResultSet" + i.ToString() + "Row = New " + dataclassName + "_ResultSet" + i.ToString() + "Row()" + nl;
							_exeParams += "ByRef " + (dataclassName + "_ResultSet" + i.ToString() + "row ").ToLower() + " As I" + (dataclassName + "_ResultSet" + i.ToString()) + "Row, ";
						}
						if (_exeParams.Length > 0) { _exeParams = _exeParams.Substring(0, _exeParams.Length - 2); }
						_method += _exeParams + ") As Integer" + nl;

						_try += nl + tab + tab + "'code coments here" + nl + tab + tab + "Try" + nl;
						_code += tab + tab + tab + "'add or reference production connection string here" + nl;
						_code += tab + tab + tab + "Dim connectionString as String = \"" + dbP.BuildConnectionString() + "\"" + nl;
						_code += tab + tab + tab + "Using connection1 as SqlConnection = New SqlConnection(connectionString)" + nl;
						_code += tab + tab + tab + tab + "connection1.Open()" + nl;
						_code += tab + tab + tab + tab + "Dim cmd as SqlCommand = New SqlCommand(\"" + ObjName + "\", connection1)" + nl;
						_code += tab + tab + tab + tab + "cmd.CommandType = CommandType.StoredProcedure" + nl;
						_code += tab + tab + tab + tab + "cmd.Parameters.Add(\"@RETURN_VALUE\", System.Data.SqlDbType.Int, 0)" + nl;
						_code += tab + tab + tab + tab + "cmd.Parameters[\"@RETURN_VALUE\"].Direction = System.Data.ParameterDirection.ReturnValue" + nl;
						_code += tab + tab + tab + tab + "cmd.Parameters[\"@RETURN_VALUE\"].Value = RETURN_VALUE" + nl;
						_code += _params;

						_code += tab + tab + tab + tab + "Dim rdr as SqlDataReader = cmd.ExecuteReader()" + nl;
						_code += tab + tab + tab + tab + "Dim _currentResultSet As Integer = 0" + nl;
						_code += tab + tab + tab + tab + "Do Until Not rdr.NextResult()" + nl;

						_code += tab + tab + tab + tab + tab + "While (rdr.Read())" + nl;
						_code += tab + tab + tab + tab + tab + tab + "Select Case _currentResultSet.ToString()" + nl;
						for (int _currentResultSet = 0; _currentResultSet < _tableCount; _currentResultSet++)
						{

							_code += tab + tab + tab + tab + tab + tab + tab + "Case \"" + _currentResultSet.ToString() + "\"" + nl;
							if (returnColumns.Count > 0)
							{
								_code += tab + tab + tab + tab + tab + tab + tab + tab + "'read your results here" + nl;
								_code += tab + tab + tab + tab + tab + tab + tab + tab + "'review the text of the stored procedure for results that may be returned" + nl;
								foreach (ColumnProperties cp in returnColumns)
								{
									if (cp.TableOrdinal == _currentResultSet)
									{
										_code += tab + tab + tab + tab + tab + tab + tab + tab + cp.Cast2NetClassCode("_" + dataclassName + "_ResultSet" + cp.TableOrdinal.ToString() + "Row").Replace(";", "") + tab + tab + "' return field " + cp.Column + " [" + cp.Type + "]" + nl;
									}
								}
							}
							else
							{
								_code += tab + tab + tab + tab + tab + tab + tab + tab + "' SAMPLE: Dim _variable as String = rdr(\"Name\").ToString()" + nl;
							}
						}
						_code += tab + tab + tab + tab + tab + tab + "End Select" + nl;
						_code += tab + tab + tab + tab + tab + "End While" + nl;
						_code += tab + tab + tab + tab + tab + "_currentResultSet++" + nl;
						_code += tab + tab + tab + tab + "Loop" + nl;
						_code += tab + tab + tab + tab + "'return value from stored procedure" + nl;
						_code += tab + tab + tab + tab + "RETURN_VALUE = System.Convert.ToInt32(cmd.Parameters[\"@RETURN_VALUE\"].Value.ToString())" + nl;
						_code += _variablePostfix;
						if (_variablePostfix.Length <= 36) { _code += tab + tab + tab + tab + "'no OUT or INOUT parameters to return" + nl; }
						_code += tab + tab + tab + "End Using" + nl;
						string _return = "";
						for (int i = 0; i < _tableCount; i++)
						{
							_return += tab + tab +( dataclassName + "_ResultSet" + i.ToString() + "Row").ToLower() + " = CType(_" + dataclassName + "_ResultSet" + i.ToString() + "Row, I" + dataclassName + "_ResultSet" + i.ToString() + "Row)" + nl;
						}
						_return += tab + tab + "Return RETURN_VALUE" + nl;
						CodeHighlight(sbInterface.ToString() + nl + sbDTO.ToString() + nl + _method + _variablePrefix + _try + _code + nl + _catch + tab + tab + "End Try" + nl + _return + nl + tab + "End Function" + nl + "End Class"+nl);
						//CodeHighlight(_variablePrefix + _try + _code + nl + _catch + tab + "End Try" + nl);
					}
				}

			}
			else if (this.rdoTiersMultiple.Checked)//Collection Result Tiers Code
			{
				StringBuilder sbInterface = new StringBuilder();
				StringBuilder sbDTO = new StringBuilder();
                string dataclassName = dbTableParameters.StripSchema(ObjName);
                string newdataclassName = DS.UIControls.Boxes.InputPrompt.Show("Provide an Name for generated data class and interface", dataclassName);
                if (newdataclassName != null)
                {
                    dataclassName = newdataclassName;
                }
                string dataaccessclassName = dbTableParameters.StripSchema(CP(ObjName));
                string newdataaccessclassName = DS.UIControls.Boxes.InputPrompt.Show("Provide an Name for generated data access client class.", dataaccessclassName);
                if (newdataclassName != null)
                {
                    dataaccessclassName = newdataaccessclassName;
                }
				System.Collections.Generic.List<ColumnProperties> returnColumns = this.TestSPWithDefaults(ObjName);
				int _tableCount = (from p in returnColumns select p.TableOrdinal).Distinct().Count();
				for (int i = 0; i < _tableCount; i++)
				{
					if (this.rdoCSharp.Checked)
					{
						sbInterface.AppendLine("public interface I" + dataclassName + "_ResultSet" + i.ToString() + "Row");
						sbInterface.AppendLine("{");
						sbDTO.AppendLine("public class " + dataclassName + "_ResultSet" + i.ToString() + "Row : " + "I" + dataclassName + "_ResultSet" + i.ToString() + "Row, INotifyPropertyChanged");
						sbDTO.AppendLine("{");
						sbDTO.AppendLine(tab + "public event PropertyChangedEventHandler PropertyChanged;");
						sbDTO.AppendLine(tab + "private void NotifyPropertyChanged(String info)");
						sbDTO.AppendLine(tab + "{");
						sbDTO.AppendLine(tab + tab + "if (PropertyChanged != null)");
						sbDTO.AppendLine(tab + tab + "{");
						sbDTO.AppendLine(tab + tab + tab + "PropertyChanged(this, new PropertyChangedEventArgs(info));");
						sbDTO.AppendLine(tab + tab + "}");
						sbDTO.AppendLine(tab + "}");
					}
					else
					{
						sbInterface.AppendLine("Public Interface I" + dataclassName + "_ResultSet" + i.ToString() + "Row");
						sbDTO.AppendLine("Public Class " + dataclassName + "_ResultSet" + i.ToString() + "Row Implements I" + dataclassName + "_ResultSet" + i.ToString() + "Row, INotifyPropertyChanged");
						sbDTO.AppendLine(tab + "Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged");
						sbDTO.AppendLine(tab + "Private Sub NotifyPropertyChanged(ByVal info As String)");
						sbDTO.AppendLine(tab + tab + "RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))");
						sbDTO.AppendLine(tab + "End Sub");
					}
					if (returnColumns.Count > 0)
					{
						//at least something was returned
						//check the number of tables returned

						foreach (ColumnProperties cp in returnColumns)
						{
							if (cp.TableOrdinal == i)
							{
								if (this.rdoCSharp.Checked)
								{
									// interface build for return types
									sbInterface.AppendLine(tab + cp.Type + " " + CP(cp.Column) + "{ get; set; }");
									// DTO build for return types
									sbDTO.AppendLine(tab + "private " + cp.Type + " _" + CP(cp.Column) + ";");
									sbDTO.AppendLine(tab + "public " + cp.Type + " " + CP(cp.Column));
									sbDTO.AppendLine(tab + "{");
									sbDTO.AppendLine(tab + tab + "get { return _" + CP(cp.Column) + ";}");
									sbDTO.AppendLine(tab + tab + "set");
									sbDTO.AppendLine(tab + tab + "{");
									sbDTO.AppendLine(tab + tab + tab + "if(value != this._" + CP(cp.Column) + ")");
									sbDTO.AppendLine(tab + tab + tab + "{");
									sbDTO.AppendLine(tab + tab + tab + tab + "this._" + CP(cp.Column) + " = value;");
									sbDTO.AppendLine(tab + tab + tab + tab + "NotifyPropertyChanged(\"" + CP(cp.Column) + "\");");
									sbDTO.AppendLine(tab + tab + tab + "}");
									sbDTO.AppendLine(tab + tab + "}");
									sbDTO.AppendLine(tab + "}");
								}
								else
								{
									// interface build for return types
									// Property OwnerName() As String
									sbInterface.AppendLine(tab + "Property " + CP(cp.Column) + "() As " + cp.Type);
									// DTO build for return types
									sbDTO.AppendLine(tab + "Dim _" + CP(cp.Column) + " As " + cp.Type);
									sbDTO.AppendLine(tab + "Public Property " + CP(cp.Column) + "() As " + cp.Type);
									sbDTO.AppendLine(tab + tab + "Get");
									sbDTO.AppendLine(tab + tab + tab + "Return _" + CP(cp.Column));
									sbDTO.AppendLine(tab + tab + "End Get");
									sbDTO.AppendLine(tab + tab + "Set(ByVal value As " + cp.Type + ")");
									sbDTO.AppendLine(tab + tab + tab + "If Not (value = _" + CP(cp.Column) + ") Then");
									sbDTO.AppendLine(tab + tab + tab + tab + "_" + CP(cp.Column) + " = value");
									sbDTO.AppendLine(tab + tab + tab + tab + "NotifyPropertyChanged(\"" + CP(cp.Column) + "\")");
									sbDTO.AppendLine(tab + tab + tab + "End If");
									sbDTO.AppendLine(tab + tab + "End Set");
									sbDTO.AppendLine(tab + "End Property");

								}
							}
						}
					}
					else
					{

					}
					if (this.rdoCSharp.Checked)
					{
						sbInterface.AppendLine("}");
						sbDTO.AppendLine("}");
					}
					else
					{
						sbInterface.AppendLine("End Interface");
						sbDTO.AppendLine("End Class");
					}
				}
				if (ValidConnection() && cboSP.Text != "")
				{
					if (this.rdoCSharp.Checked)
					{
						//do C# code
						string _code = "";
						string _method = "public class " + dataaccessclassName + "_DataClient" + nl;
						_method += "{" + nl;
						_method += tab + "public int Execute(";

						string _try = string.Empty;
						string _catch = tab + tab + "catch(Exception ex)" + nl + tab + tab + "{" + nl + tab + tab + tab + "//add error handling code here" + nl + tab + tab + "}" + nl;
						_catch += tab + tab + "finally" + nl + tab + tab + "{" + nl + tab + tab + tab + "//close or dispose of any unmanaged resources here" + nl + tab + tab + "}" + nl;
						string _params = string.Empty;
						string _variablePrefix = tab + tab + "//data access variables" + nl + tab + tab + "int RETURN_VALUE = 0;" + nl;
						string _variablePostfix = tab + tab + tab + tab + "//return paramater values" + nl;
						string _exeParms = "";
						//get parameters - if any
						DataSet _ds = GetSPparameters(ObjName);
						foreach (DataRow dr in _ds.Tables[0].Rows)
						{
							spParam parm = new spParam();
							parm.Direction = dr["DIRECTION"].ToString();
							parm.Ordinal = System.Convert.ToInt32(dr["ORDINAL_POSITION"].ToString());
							parm.ParamName = dr["PARAM_NAME"].ToString();
							parm.ParamType = dr["PARAM_TYPE"].ToString();
							try { parm.Precision = System.Convert.ToInt32(dr["PRECISION"].ToString()); }
							catch { parm.Precision = 0; }
							try { parm.Scale = System.Convert.ToInt32(dr["SCALE"].ToString()); }
							catch { parm.Scale = 0; }
							try { parm.Size = System.Convert.ToInt32(dr["SIZE"].ToString()); }
							catch { parm.Size = 0; }
							parm.SpName = dr["SP_NAME"].ToString();
							string _dir = dr["DIRECTION"].ToString().Trim();
							string _paramDir = "";
							switch (_dir)
							{
								case "IN":
									parm.Direction = "Input";
									break;
								case "OUT":
									parm.Direction = "Output";
									_paramDir = "out ";
									break;
								case "INOUT":
									parm.Direction = "InputOutput";
									_paramDir = "ref ";
									break;
								default:
									//?? this will probably never be hit
									parm.Direction = "ReturnValue";
									_paramDir = "out ";
									break;
							}
							try { parm.Precision = System.Convert.ToInt32(dr["PRECISION"].ToString()); }
							catch { parm.Precision = 0; }
							_params += tab + tab + tab + tab + "cmd.Parameters.Add(\"" + parm.ParamName + "\"," + parm.ParamDef() + ");" + nl;
							_params += tab + tab + tab + tab + "cmd.Parameters[\"" + parm.ParamName + "\"].Value = " + parm.VariableName() + ";" + nl;
							_params += tab + tab + tab + tab + "cmd.Parameters[\"" + parm.ParamName + "\"].Direction = System.Data.ParameterDirection." + parm.Direction + ";" + nl;
							_variablePrefix += tab + tab + parm.VariableType() + " " + parm.VariableName() + " = " + parm.ParamName.Replace("@", "").ToLower() + ";" + nl;
							if (_dir.Contains("OUT")) { _variablePostfix += tab + tab + tab + parm.VariableName() + " = (" + parm.VariableType() + ")cmd.Parameters[\"" + parm.ParamName + "\"].Value;" + nl; }
							_exeParms += _paramDir + parm.VariableType() + " " + parm.ParamName.Replace("@", "").ToLower() + ", ";
						}

						for (int i = 0; i < _tableCount; i++)
						{
							_variablePrefix += tab + tab + "System.Collections.Generic.List<I" + dataclassName + "_ResultSet" + i.ToString() +"Row> _" + dataclassName + "_ResultSet" + i.ToString() + " = new System.Collections.Generic.List<I" + dataclassName + "_ResultSet" + i.ToString() + "Row>();" + nl;
							_exeParms += "out System.Collections.Generic.List<I" + dataclassName + "_ResultSet" + i.ToString() + "Row> " + (dataclassName + "_ResultSet" + i.ToString()).ToLower() + ", ";
						}

						if (_exeParms.Length > 0) { _exeParms = _exeParms.Substring(0, _exeParms.Length - 2); }
						_method += _exeParms + ")" + nl;
						_method += tab + "{" + nl;

						_try += nl + tab + tab + "//code coments here" + nl + tab + tab + "try" + nl + tab + tab + "{" + nl;
						_code += tab + tab + tab + "//add or reference production connection string here" + nl;
						_code += tab + tab + tab + "string connectionString = \"" + dbP.BuildConnectionString() + "\";" + nl;
						_code += tab + tab + tab + "using (SqlConnection connection1 = new SqlConnection(connectionString))" + nl;
						_code += tab + tab + tab + "{" + nl;
						_code += tab + tab + tab + tab + "connection1.Open();" + nl;
						_code += tab + tab + tab + tab + "SqlCommand cmd = new SqlCommand(\"" + ObjName + "\", connection1);" + nl;
						_code += tab + tab + tab + tab + "cmd.CommandType = CommandType.StoredProcedure;" + nl;
						_code += tab + tab + tab + tab + "cmd.Parameters.Add(\"@RETURN_VALUE\", System.Data.SqlDbType.Int, 0);" + nl;
						_code += tab + tab + tab + tab + "cmd.Parameters[\"@RETURN_VALUE\"].Direction = System.Data.ParameterDirection.ReturnValue;" + nl;
						_code += tab + tab + tab + tab + "cmd.Parameters[\"@RETURN_VALUE\"].Value = RETURN_VALUE;" + nl;
						_code += _params;

						_code += tab + tab + tab + tab + "SqlDataReader rdr = cmd.ExecuteReader();" + nl;
						_code += tab + tab + tab + tab + "int _currentResultSet = 0;" + nl;
						_code += tab + tab + tab + tab + "do" + nl;
						_code += tab + tab + tab + tab + "{" + nl;
						_code += tab + tab + tab + tab + tab + "while (rdr.Read())" + nl;
						_code += tab + tab + tab + tab + tab + "{" + nl;
						_code += tab + tab + tab + tab + tab + tab + "switch(_currentResultSet)" + nl;
						_code += tab + tab + tab + tab + tab + tab + "{" + nl;
						for (int _currentResultSet = 0; _currentResultSet < _tableCount; _currentResultSet++)
						{
							_code += tab + tab + tab + tab + tab + tab + tab + "case " + _currentResultSet.ToString() + ":" + nl;
							if (returnColumns.Count > 0)
							{
								_code += tab + tab + tab + tab + tab + tab + tab + tab + "//read your results here" + nl;
								_code += tab + tab + tab + tab + tab + tab + tab + tab + "//review the text of the stored procedure for any additional results that may be returned" + nl;
								_code += tab + tab + tab + tab + tab + tab + tab + tab + (dataclassName) + "_ResultSet" + _currentResultSet.ToString() + "Row l_" + (dataclassName) + "_ResultSet" + _currentResultSet.ToString() + "Row = new " + (dataclassName) + "_ResultSet" + _currentResultSet.ToString() + "Row();" + nl;
								foreach (ColumnProperties cp in returnColumns)
								{
									if (cp.TableOrdinal == _currentResultSet)
									{
										_code += tab + tab + tab + tab + tab + tab + tab + tab + cp.Cast2NetClassCode("l_" + dataclassName + "_ResultSet" + cp.TableOrdinal.ToString()+"Row") + tab + tab + "// return field " + cp.Column + " [" + cp.Type + "]" + nl;
									}
								}
								_code += tab + tab + tab + tab + tab + tab + tab + tab + "_" + dataclassName + "_ResultSet" + _currentResultSet.ToString() + ".Add(l_" + (dataclassName) + "_ResultSet" + _currentResultSet.ToString() + "Row);" + nl;
							}
							else
							{
								_code += tab + tab + tab + tab + tab + tab + "// SAMPLE: string _variable = rdr[\"Name\"].ToString();" + nl;
							}
							_code += tab + tab + tab + tab + tab + tab + tab + tab + "break;" + nl;
						}

						_code += tab + tab + tab + tab + tab + tab + "}" + nl;
						_code += tab + tab + tab + tab + tab + tab + "_currentResultSet++;" + nl;

						//_code += tab + tab + tab + tab + "return _" +dataclassName + nl;
						_code += tab + tab + tab + tab + tab + "}" + nl;
						_code += tab + tab + tab + tab + "} while (rdr.NextResult());" + nl;

						_code += tab + tab + tab + tab + "//return value from stored procedure" + nl;
						_code += tab + tab + tab + tab + "RETURN_VALUE = ((int)(cmd.Parameters[\"@RETURN_VALUE\"].Value));" + nl;
						_code += _variablePostfix;
						if (_variablePostfix.Length <= 38) { _code += tab + tab + tab + tab + "//no OUT or INOUT parameters to return" + nl; }
						_code += tab + tab + tab + "}" + nl;
						string _return = "";
						for (int i = 0; i < _tableCount; i++)
						{
							_return += tab + tab + (dataclassName + "_ResultSet" + i.ToString()).ToLower() + " = _" + dataclassName + "_ResultSet" + i.ToString() + ";" + nl;
						}
						_return += tab + tab + "return RETURN_VALUE;" + nl;
						CodeHighlight(sbInterface.ToString() + nl + sbDTO.ToString() + nl + _method + _variablePrefix + _try + _code + tab + tab + "}" + nl + _catch + _return + nl + tab + "}" + nl + "}" + nl);
					}
					else
					{
						//do VB.Net code
						string _code = string.Empty;
						string _method = "Public Class " + dataaccessclassName + "_DataClient" + nl;
						_method += tab + "Public Function Execute(";

						string _try = string.Empty;
						string _catch = tab + tab + "Catch ex As Exception" + nl + tab + tab + tab + "'add error handling code here" + nl;
						_catch += tab + tab + "Finally" + nl + tab + tab + tab + "'close or dispose of any unmanaged resources here" + nl;
						string _params = string.Empty;
						string _variablePrefix = tab + tab + "'data access variables" + nl + tab + tab + "Dim RETURN_VALUE As int = 0" + nl;
						string _variablePostfix = tab + tab + tab + tab + "'return paramater values" + nl;
						string _exeParams = "";
						//get parameters - if any
						DataSet _ds = GetSPparameters(ObjName);
						foreach (DataRow dr in _ds.Tables[0].Rows)
						{
							spParam parm = new spParam();
							parm.Direction = dr["DIRECTION"].ToString();
							parm.Ordinal = System.Convert.ToInt32(dr["ORDINAL_POSITION"].ToString());
							parm.ParamName = dr["PARAM_NAME"].ToString();
							parm.ParamType = dr["PARAM_TYPE"].ToString();
							try { parm.Precision = System.Convert.ToInt32(dr["PRECISION"].ToString()); }
							catch { parm.Precision = 0; }
							try { parm.Scale = System.Convert.ToInt32(dr["SCALE"].ToString()); }
							catch { parm.Scale = 0; }
							try { parm.Size = System.Convert.ToInt32(dr["SIZE"].ToString()); }
							catch { parm.Size = 0; }
							parm.SpName = dr["SP_NAME"].ToString();
							string _dir = dr["DIRECTION"].ToString().Trim();
							string _paramDir = "";
							switch (_dir)
							{
								case "IN":
									parm.Direction = "Input";
									break;
								case "OUT":
									parm.Direction = "Output";
									_paramDir = "out ";
									break;
								case "INOUT":
									parm.Direction = "InputOutput";
									_paramDir = "ref ";
									break;
								default:
									//?? this will probably never be hit
									parm.Direction = "ReturnValue";
									_paramDir = "out ";
									break;
							}
							try { parm.Precision = System.Convert.ToInt32(dr["PRECISION"].ToString()); }
							catch { parm.Precision = 0; }
							_params += tab + tab + tab + tab + "cmd.Parameters.Add(\"" + parm.ParamName + "\"," + parm.ParamDef() + ")" + nl;
							_params += tab + tab + tab + tab + "cmd.Parameters(\"" + parm.ParamName + "\").Value = " + parm.VariableName() + nl;
							_params += tab + tab + tab + tab + "cmd.Parameters[\"" + parm.ParamName + "\"].Direction = System.Data.ParameterDirection." + parm.Direction + nl;
							_variablePrefix += tab + tab + "Dim " + parm.VariableName() + " as " + parm.VariableType() + " = " + parm.ParamName.Replace("@", "").ToLower() + nl;
							if (_dir.Contains("OUT"))
							{
								_variablePostfix += tab + tab + tab + parm.VariableName() + " = CType(" + "cmd.Parameters[\"" + parm.ParamName + "\"].Value, " + parm.VariableconversionType() + nl;
							}
							_exeParams += "ByVal " + (parm.ParamName.Replace("@", "")).ToLower() + " As " + parm.VariableType() + ", ";
						}
						for (int i = 0; i < _tableCount; i++)
						{
							_variablePrefix += tab + tab + "Dim _" + dataclassName + "_ResultSet" + i.ToString() + " As System.Collections.Generic.List(Of I" + dataclassName + "_ResultSet" + i.ToString() + "Row) = New System.Collections.Generic.List(Of I" + dataclassName + "_ResultSet" + i.ToString() + "Row)()" + nl;
							_exeParams += "ByRef " + (dataclassName + "_ResultSet" + i.ToString() + "row ").ToLower() + " As System.Collections.Generic.List(Of I" + (dataclassName + "_ResultSet" + i.ToString()) + "Row), ";
						}
						if (_exeParams.Length > 0) { _exeParams = _exeParams.Substring(0, _exeParams.Length - 2); }
						_method += _exeParams + ") As Integer" + nl;

						_try += nl + tab + tab + "'code coments here" + nl + tab + tab + "Try" + nl;
						_code += tab + tab + tab + "'add or reference production connection string here" + nl;
						_code += tab + tab + tab + "Dim connectionString as String = \"" + dbP.BuildConnectionString() + "\"" + nl;
						_code += tab + tab + tab + "Using connection1 as SqlConnection = New SqlConnection(connectionString)" + nl;
						_code += tab + tab + tab + tab + "connection1.Open()" + nl;
						_code += tab + tab + tab + tab + "Dim cmd as SqlCommand = New SqlCommand(\"" + ObjName + "\", connection1)" + nl;
						_code += tab + tab + tab + tab + "cmd.CommandType = CommandType.StoredProcedure" + nl;
						_code += tab + tab + tab + tab + "cmd.Parameters.Add(\"@RETURN_VALUE\", System.Data.SqlDbType.Int, 0)" + nl;
						_code += tab + tab + tab + tab + "cmd.Parameters[\"@RETURN_VALUE\"].Direction = System.Data.ParameterDirection.ReturnValue" + nl;
						_code += tab + tab + tab + tab + "cmd.Parameters[\"@RETURN_VALUE\"].Value = RETURN_VALUE" + nl;
						_code += _params;

						_code += tab + tab + tab + tab + "Dim rdr as SqlDataReader = cmd.ExecuteReader()" + nl;
						_code += tab + tab + tab + tab + "Dim _currentResultSet As Integer = 0" + nl;
						_code += tab + tab + tab + tab + "Do Until Not rdr.NextResult()" + nl;

						_code += tab + tab + tab + tab + tab + "While (rdr.Read())" + nl;
						_code += tab + tab + tab + tab + tab + tab + "Select Case _currentResultSet.ToString()" + nl;
						for (int _currentResultSet = 0; _currentResultSet < _tableCount; _currentResultSet++)
						{

							_code += tab + tab + tab + tab + tab + tab + tab + "Case \"" + _currentResultSet.ToString() + "\"" + nl;
							if (returnColumns.Count > 0)
							{
								_code += tab + tab + tab + tab + tab + tab + tab + tab + "'read your results here" + nl;
								_code += tab + tab + tab + tab + tab + tab + tab + tab + "'review the text of the stored procedure for results that may be returned" + nl;
								_code += tab + tab + tab + tab + tab + tab + tab + tab + "Dim l_" + dataclassName + "_ResultSet" + _currentResultSet.ToString() + "Row As " + dataclassName + "_ResultSet" + _currentResultSet.ToString() + "Row = New " + dataclassName + "_ResultSet" + _currentResultSet.ToString() + "Row()";
								foreach (ColumnProperties cp in returnColumns)
								{
									if (cp.TableOrdinal == _currentResultSet)
									{
										_code += tab + tab + tab + tab + tab + tab + tab + tab + cp.Cast2NetClassCode("l_" + dataclassName + "_ResultSet" + cp.TableOrdinal.ToString() + "Row").Replace(";", "") + tab + tab + "' return field " + cp.Column + " [" + cp.Type + "]" + nl;
									}
								}
								_code += tab + tab + tab + tab + tab + tab + tab + tab + "_" + dataclassName + "_ResultSet" + _currentResultSet.ToString() + ".Add(l_" + dataclassName + "_ResultSet" + _currentResultSet.ToString() + "Row)" + nl;
							}
							else
							{
								_code += tab + tab + tab + tab + tab + tab + tab + tab + "' SAMPLE: Dim _variable as String = rdr(\"Name\").ToString()" + nl;
							}
						}
						_code += tab + tab + tab + tab + tab + tab + "End Select" + nl;
						_code += tab + tab + tab + tab + tab + "End While" + nl;
						_code += tab + tab + tab + tab + tab + "_currentResultSet++" + nl;
						_code += tab + tab + tab + tab + "Loop" + nl;
						_code += tab + tab + tab + tab + "'return value from stored procedure" + nl;
						_code += tab + tab + tab + tab + "RETURN_VALUE = System.Convert.ToInt32(cmd.Parameters[\"@RETURN_VALUE\"].Value.ToString())" + nl;
						_code += _variablePostfix;
						if (_variablePostfix.Length <= 36) { _code += tab + tab + tab + tab + "'no OUT or INOUT parameters to return" + nl; }
						_code += tab + tab + tab + "End Using" + nl;
						string _return = "";
						for (int i = 0; i < _tableCount; i++)
						{
							_return += tab + tab + (dataclassName + "_ResultSet" + i.ToString() ).ToLower() + " = _" + dataclassName + "_ResultSet" + i.ToString() + nl;
						}
						_return += tab + tab + "Return RETURN_VALUE" + nl;
						CodeHighlight(sbInterface.ToString() + nl + sbDTO.ToString() + nl + _method + _variablePrefix + _try + _code + nl + _catch + tab + tab + "End Try" + nl + _return + nl + tab + "End Function" + nl + "End Class" + nl);
						//CodeHighlight(_variablePrefix + _try + _code + nl + _catch + tab + "End Try" + nl);
					}
				}
			}
			else //Spoil 
			{
				if (ValidConnection() && cboSP.Text != "")
				{
					if (this.rdoCSharp.Checked)
					{
						string _parmHeaderSig = "[ NonCommandParameter ] SqlConnection sqlConn, ";
						string _parmGenSig = "{";
						string _outVariables = tab + "//data access variables" + nl + tab + "int RETURN_VALUE = 0;" + nl;
						string _outSetters = tab + "//return value from stored procedure" + nl;
						_outSetters += tab + "RETURN_VALUE = System.Convert.ToInt32(command.Parameters[\"@RETURN_VALUE\"].Value.ToString());" + nl;
						string _code = string.Empty;
						//do C# code
						_code += " string _connectionString = \"" + dbP.BuildConnectionString() + "\";" + nl;
						_code += " SqlConnection sqlConn = new SqlConnection(_connectionString);" + nl;
						_code += nl;
						_code += " [SqlCommandMethod(CommandType.StoredProcedure,\"" + ObjName + "\")]" + nl;
						//get the parameters for the stored procedure
						List<spParam> _parms = this.GetSpParamList(cboSP.Text);
						foreach (spParam p in _parms)
						{
							_parmGenSig += p.VariableName().Replace("_parm_", string.Empty) + ", ";
							if ((p.Direction != "InputOutput") && (p.Direction != "Output"))
							{
								_parmHeaderSig += "[SqlParameter(\"" + p.ParamName + "\")] " + p.VariableType() + " " + p.VariableName().Replace("_parm_", string.Empty) + ", ";
							}
							else
							{
								if (p.Direction != "InputOutput")
								{
									_parmHeaderSig += "[SqlParameter(\"" + p.ParamName + "\")] out " + p.VariableType() + " " + p.VariableName().Replace("_parm_", string.Empty) + ", ";
								}
								else
								{
									_parmHeaderSig += "[SqlParameter(\"" + p.ParamName + "\")] ref " + p.VariableType() + " " + p.VariableName().Replace("_parm_", string.Empty) + ", ";
								}
								_outVariables += tab + p.VariableType() + " " + p.VariableName().Replace("_parm_", string.Empty) + " = new " + p.VariableType() + "();" + nl;
								_outSetters += tab + p.VariableName().Replace("_parm_", string.Empty) + " = (" + p.VariableType() + ")command.Parameters[\"" + p.ParamName + "\"].Value;" + nl;
							}
						}
						if (_parmGenSig == "{") { _parmGenSig += "}"; }
						else
						{
							_parmGenSig = _parmGenSig.Substring(0, _parmGenSig.Length - 2) + "}"; //remove trailing comma and space
						}
						_parmHeaderSig = _parmHeaderSig.Substring(0, _parmHeaderSig.Length - 2);    //remove trailing comma and space
						//build the code for SELECT

						switch (m_genType)
						{
							case eGenType.datareader:
								_code += " public DataReader " + ObjName + "( " + _parmHeaderSig + " )" + nl;
								_code += " {" + nl;
								_code += _outVariables + nl;
								_code += tab + "SqlCommand command = SqlCommandGenerator.GenerateCommand(sqlConn, null, new object[] " + _parmGenSig + ");" + nl;
								_code += tab + "SqlDataReader rdr = command.ExecuteReader();" + nl;
								_code += tab + "sqlConn.Close();" + nl;
								_code += tab + "return rdr;" + nl;
								break;
							case eGenType.dataset:
								_code += " public DataSet " + ObjName + "( " + _parmHeaderSig + " )" + nl;
								_code += " {" + nl;
								_code += _outVariables + nl;
								_code += tab + "SqlCommand command = SqlCommandGenerator.GenerateCommand(sqlConn, null, new object[] " + _parmGenSig + ");" + nl;
								_code += tab + "DataSet ds = new DataSet();" + nl;
								_code += tab + "SqlDataAdapter dataAdapter = new SqlDataAdapter(command);" + nl;
								_code += tab + "dataAdapter.Fill(ds);" + nl;
								_code += _outSetters;
								_code += tab + "sqlConn.Close();" + nl;
								_code += tab + "return ds;" + nl;
								break;
							case eGenType.nonquery:
							case eGenType.scalar:
								_code += " public int " + ObjName + "( " + _parmHeaderSig + " )" + nl;
								_code += " {" + nl;
								_code += _outVariables + nl;
								_code += tab + "SqlCommand command = SqlCommandGenerator.GenerateCommand(sqlConn, null, new object[] " + _parmGenSig + ");" + nl;
								_code += tab + "Object obj = cmd.ExecuteScalar();" + nl + nl;
								_code += tab + "//CAST SCALAR OBJECT TO DESIRED TYPE HERE" + nl;
								_code += tab + "return (int)obj;" + nl + nl;
								break;
						}
						_code += " }" + nl;
						CodeHighlight(_code);
					}
					else
					{
						//do VB.NET CODE
						string _parmHeaderSig = "< NonCommandParameter > connection As SqlConnection, ";
						string _parmGenSig = "{";
						string _outVariables = tab + " 'data access variables" + nl + tab + "Dim RETURN_VALUE As Integer= 0" + nl;
						string _outSetters = tab + " 'return value from stored procedure" + nl;
						_outSetters += tab + "RETURN_VALUE = System.Convert.ToInt32(command.Parameters(\"@RETURN_VALUE\").Value.ToString())" + nl;
						string _code = string.Empty;
						//do C# code
						_code += " Dim _connectionString As string = \"" + dbP.BuildConnectionString() + "\"" + nl;
						_code += " Dim sqlConn As SqlConnection = New SqlConnection(_connectionString)" + nl;
						_code += nl;
						_code += " <SqlCommandMethod(CommandType.StoredProcedure,\"" + ObjName + "\")>" + nl;
						//get the parameters for the stored procedure
						List<spParam> _parms = this.GetSpParamList(cboSP.Text);
						foreach (spParam p in _parms)
						{
							_parmGenSig += p.VariableName().Replace("_parm_", string.Empty) + ", ";
							if ((p.Direction != "InputOutput") && (p.Direction != "Output"))
							{
								_parmHeaderSig += "<SqlParameter(\"" + p.ParamName + "\")> ByVal " + p.VariableName().Replace("_parm_", string.Empty) + " As " + p.VariableType() + ", ";
							}
							else
							{
								if (p.Direction != "InputOutput")
								{
									_parmHeaderSig += "<SqlParameter(\"" + p.ParamName + "\")> ByRef " + p.VariableName().Replace("_parm_", string.Empty) + " As " + p.VariableType() + ", ";
								}
								else
								{
									_parmHeaderSig += "<SqlParameter(\"" + p.ParamName + "\")> ByRef " + p.VariableName().Replace("_parm_", string.Empty) + " As " + p.VariableType() + ", ";
								}
								_outVariables += tab + "Dim " + p.VariableName().Replace("_parm_", string.Empty) + " As " + p.VariableType() + " = New " + p.VariableType() + "()" + nl;
								_outSetters += tab + p.VariableName().Replace("_parm_", string.Empty) + " = CType(command.Parameters(\"" + p.ParamName + "\").Value, " + p.VariableType() + ")" + nl;
							}
						}
						_parmGenSig = _parmGenSig.Substring(0, _parmGenSig.Length - 2) + "}"; //remove trailing comma and space
						_parmHeaderSig = _parmHeaderSig.Substring(0, _parmHeaderSig.Length - 2);    //remove trailing comma and space
						switch (m_genType)
						{
							case eGenType.datareader:
								_code += " Public Function " + ObjName + "( " + _parmHeaderSig + " ) As DataReader" + nl;
								_code += _outVariables + nl;
								_code += tab + "Dim command As SqlCommand = SqlCommandGenerator.GenerateCommand(sqlConn, Nothing, new object() " + _parmGenSig + ")" + nl;
								_code += tab + "Dim rdr As SqlDataReader = command.ExecuteReader()" + nl;
								_code += tab + "sqlConn.Close()" + nl;
								_code += tab + "Return rdr" + nl;
								_code += " End Function" + nl;
								break;
							case eGenType.dataset:
								_code += " Public Function " + ObjName + "( " + _parmHeaderSig + " ) As DataSet" + nl;
								_code += _outVariables + nl;
								_code += tab + "Dim command As SqlCommand = SqlCommandGenerator.GenerateCommand(sqlConn, Nothing, New Object() " + _parmGenSig + ")" + nl;
								_code += tab + "Dim ds As DataSet = New DataSet()" + nl;
								_code += tab + "Dim dataAdapter As SqlDataAdapter = New SqlDataAdapter(command)" + nl;
								_code += tab + "dataAdapter.Fill(ds)" + nl;
								_code += _outSetters;
								_code += tab + "sqlConn.Close()" + nl;
								_code += tab + "Return ds" + nl;
								_code += " End Function" + nl;
								break;
							case eGenType.nonquery:
							case eGenType.scalar:
								_code += " Public Function " + ObjName + "( " + _parmHeaderSig + " ) As int" + nl;
								_code += _outVariables + nl;
								_code += tab + "Dim command As SqlCommand = SqlCommandGenerator.GenerateCommand(sqlConn, null, new object() " + _parmGenSig + ")" + nl;
								_code += tab + "Dim obj As Object = cmd.ExecuteScalar()" + nl + nl;
								_code += tab + "''CAST SCALAR OBJECT TO DESIRED TYPE HERE" + nl;
								_code += tab + "Return CType(obj, int)" + nl;
								_code += " End Function" + nl + nl;
								break;
						}
						CodeHighlight(_code);
					}
				}

			}
		}
		public bool ValidConnection()
		{
			bool bResult = false;
			if ((this.cboDatabases.Text.Length > 0) && (cboServers.Text.Length > 0) && (((txtUserName.Text.Length > 0) && (txtPassword.Text.Length > 0)) || (chkWindowsAuthentication.Checked)))
			{ return true; }
			else
			{ return false; }

		}
		private void RebuildLastQuery(ListBox lb)
		{
			switch (lb.Name.ToString())
			{
				case "listSelectSelect":
					this.rtbSelectSP.Rtf = sh.Highlight(BuildSelectSP());
					break;
				case "listInsertSelect":
					this.rtbDeleteSP.Rtf = sh.Highlight(BuildInsertSP());
					break;
				case "listUpdateSelect":
					this.rtbInsertSP.Rtf = sh.Highlight(BuildUpdateSP());
					break;
			}
		}
		public List<spParam> GetSpParamList(string spName)
		{
			//get selected parameters into List<spParm> array
			List<spParam> _parmList = new List<spParam>();
			DataSet _ds = GetSPparameters(spName);
			foreach (DataRow dr in _ds.Tables[0].Rows)
			{
				spParam parm = new spParam();
				parm.Direction = dr["DIRECTION"].ToString();
				parm.Ordinal = System.Convert.ToInt32(dr["ORDINAL_POSITION"].ToString());
				parm.ParamName = dr["PARAM_NAME"].ToString();
				parm.ParamType = dr["PARAM_TYPE"].ToString();
				try { parm.Precision = System.Convert.ToInt32(dr["PRECISION"].ToString()); }
				catch { parm.Precision = 0; }
				try { parm.Scale = System.Convert.ToInt32(dr["SCALE"].ToString()); }
				catch { parm.Scale = 0; }
				try { parm.Size = System.Convert.ToInt32(dr["SIZE"].ToString()); }
				catch { parm.Size = 0; }
				parm.SpName = dr["SP_NAME"].ToString();
				string _dir = dr["DIRECTION"].ToString().Trim();
				switch (_dir)
				{
					case "IN":
						parm.Direction = "Input";
						break;
					case "OUT":
						parm.Direction = "Output";
						break;
					case "INOUT":
						parm.Direction = "InputOutput";
						break;
					default:
						//?? this will probably never be hit
						parm.Direction = "ReturnValue";
						break;
				}
				_parmList.Add(parm);
			}
			return _parmList;
		}
		private System.Collections.Generic.List<ColumnProperties> TestSPWithDefaults(string _spName)
		{
			List<ColumnProperties> _colProperties = new List<ColumnProperties>();
			try
			{
				List<spParam> _parmList = new List<spParam>();
				DataSet _ds = GetSPparameters(dbTableParameters.StripSchema(cboSP.Text));
				foreach (DataRow dr in _ds.Tables[0].Rows)
				{
					spParam parm = new spParam();
					parm.Direction = dr["DIRECTION"].ToString();
					parm.Ordinal = System.Convert.ToInt32(dr["ORDINAL_POSITION"].ToString());
					parm.ParamName = dr["PARAM_NAME"].ToString();
					parm.ParamType = dr["PARAM_TYPE"].ToString();
					try { parm.Precision = System.Convert.ToInt32(dr["PRECISION"].ToString()); }
					catch { parm.Precision = 0; }
					try { parm.Scale = System.Convert.ToInt32(dr["SCALE"].ToString()); }
					catch { parm.Scale = 0; }
					try { parm.Size = System.Convert.ToInt32(dr["SIZE"].ToString()); }
					catch { parm.Size = 0; }
					parm.SpName = dr["SP_NAME"].ToString();
					string _dir = dr["DIRECTION"].ToString().Trim();
					switch (_dir)
					{
						case "IN":
							parm.Direction = "Input";
							break;
						case "OUT":
							parm.Direction = "Output";
							break;
						case "INOUT":
							parm.Direction = "InputOutput";
							break;
						default:
							//?? this will probably never be hit
							parm.Direction = "ReturnValue";
							break;
					}
					_parmList.Add(parm);
				}
				SqlCommand cmdSP = new SqlCommand(dbTableParameters.StripSchema(_spName), new SqlConnection(dbP.BuildConnectionString()));
				cmdSP.CommandType = CommandType.StoredProcedure;
				foreach (spParam spp in _parmList)
				{
					cmdSP.Parameters.Add(spp.ParamName, spp.ParamDef());
					ParameterDirection pd = new ParameterDirection();
					switch (spp.Direction)
					{
						case "Input":
							pd = ParameterDirection.Input;
							break;
						case "Output":
							pd = ParameterDirection.Output;
							break;
						case "InputOutput":
							pd = ParameterDirection.InputOutput;
							break;
						default:
							//?? this will probably never be hit
							pd = ParameterDirection.ReturnValue;
							break;
					}
					cmdSP.Parameters[spp.ParamName].Direction = pd;
					switch (spp.VariableType())
					{
						case "bool":
							cmdSP.Parameters[spp.ParamName].Value = "false";
							break;
						case "string":
						case "char":
							cmdSP.Parameters[spp.ParamName].Value = " ";
							break;
						case "decimal":
							//all numeric types
							cmdSP.Parameters[spp.ParamName].Value = 0;
							break;
						default:
							//all numeric types
							cmdSP.Parameters[spp.ParamName].Value = 0;
							break;
					}

				}
				SqlDataAdapter adapterSP = new SqlDataAdapter(cmdSP);
				DataSet dsSP = new DataSet();
				adapterSP.Fill(dsSP);
				int _currentTableNumber = -1;
				foreach (DataTable tbl in dsSP.Tables)
				{
					_currentTableNumber++;
					foreach (DataColumn dc in tbl.Columns)
					{
						ColumnProperties cp = new ColumnProperties();
						cp.Column = dc.ColumnName;
						cp.Type = dc.DataType.Name.ToString();
						cp.TableOrdinal = _currentTableNumber;
						_colProperties.Add(cp);
					}
				}
			}
			catch (Exception ex)
			{
				// one or more errors occured
			}
			return _colProperties;
		}
		public void ExtractFileResourceToFileSystem(string resourceName, string fileName, string path)
		{
			System.Reflection.Assembly a = System.Reflection.Assembly.Load("resources");
			using (System.IO.Stream stream1 = a.GetManifestResourceStream(a.GetName().Name + "." + resourceName))
			{
				int num1 = (int)stream1.Length;
				byte[] buffer1 = new byte[num1];
				stream1.Read(buffer1, 0, num1);
				using (System.IO.FileStream stream2 = new System.IO.FileStream(System.IO.Path.Combine(path, fileName), System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
				{
					stream2.Write(buffer1, 0, num1);
				}
			}
		}
		#endregion

		private void rdoTiersSingle_CheckedChanged(object sender, EventArgs e)
		{
			if (rdoTiersSingle.Checked || rdoTiersMultiple.Checked)
			{
				chkUseDataReader.Checked = true;
				chkUseDataSet.Enabled = false;
			}
			else
			{
				chkUseDataSet.Enabled = true;
			}
		}

		private void xppConnection_Paint(object sender, PaintEventArgs e)
		{

		}

		private void lblConnString_DoubleClick(object sender, EventArgs e)
		{
			CopyToClipboard(lblConnString.Text);
		}

		private void button7_Click(object sender, EventArgs e)
		{
			//get selected parameters into List<spParm> array
			List<spParam> _parmList = new List<spParam>();
			DataSet _ds = GetSPparameters(cboSP.Text);
			foreach (DataRow dr in _ds.Tables[0].Rows)
			{
				spParam parm = new spParam();
				parm.Direction = dr["DIRECTION"].ToString();
				parm.Ordinal = System.Convert.ToInt32(dr["ORDINAL_POSITION"].ToString());
				parm.ParamName = dr["PARAM_NAME"].ToString();
				parm.ParamType = dr["PARAM_TYPE"].ToString();
				try { parm.Precision = System.Convert.ToInt32(dr["PRECISION"].ToString()); }
				catch { parm.Precision = 0; }
				try { parm.Scale = System.Convert.ToInt32(dr["SCALE"].ToString()); }
				catch { parm.Scale = 0; }
				try { parm.Size = System.Convert.ToInt32(dr["SIZE"].ToString()); }
				catch { parm.Size = 0; }
				parm.SpName = dr["SP_NAME"].ToString();
				string _dir = dr["DIRECTION"].ToString().Trim();
				switch (_dir)
				{
					case "IN":
						parm.Direction = "Input";
						break;
					case "OUT":
						parm.Direction = "Output";
						break;
					case "INOUT":
						parm.Direction = "InputOutput";
						break;
					default:
						//?? this will probably never be hit
						parm.Direction = "ReturnValue";
						break;
				}
				_parmList.Add(parm);
			}
			frmSPPerf fP = new frmSPPerf(cboSP.Text, _parmList, dbP.ConnectionString);
			fP.Show();

		}

		private void xbtnShowComplexGenerator_Load(object sender, EventArgs e)
		{

		}

		private void xbtnShowComplexGenerator_Click(object sender, EventArgs e)
		{
			frmComplexGenerator fCG = new frmComplexGenerator(dbP.ConnectionString, dbP.DatabaseName, dbP.Server, dbP.UseWindowsAuthentication);
			fCG.Show();
		}






	}
}