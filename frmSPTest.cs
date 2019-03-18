using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using DS.SPGenerator.genCore;

namespace DS.SPGenerator
{
    public partial class frmSPTest : Form
    {
        int _currentParmScrollPos;
        int _currentResultsScrollPos;
        spType _eType;
        string _connectionString;
        private string _spText;
        private string _spName;
        public string SpText
        {
            get { return _spText; }
            set { _spText = value; }
        }
        List<spParam> _parameters;
        public List<spParam> Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
        
        public frmSPTest()
        {
            InitializeComponent();
        }
        public frmSPTest(string spText, List<spParam> spp, string connection,spType eType)
        {
            _spText = spText;
            _currentParmScrollPos = 1;
            _parameters = spp;
            _eType = eType;
            _connectionString = connection;
            InitializeComponent();
            richTextBox1.Rtf = _spText;
        }
        public frmSPTest(string spName, string spText, List<spParam> spp, string connection, spType eType)
        {
            _spName = spName;
            _spText = spText;
            _currentParmScrollPos = 1;
            _parameters = spp;
            _eType = eType;
            _connectionString = connection;
            InitializeComponent();
            richTextBox1.Text = _spText;
        }
        private void frmSPTest_Load(object sender, EventArgs e)
        {
            DisplayParameters();
            txtQueryTimeout.Text = "30";
            dgridResults.Visible = false;
            dgridResults.Top -= 78;
        }
            
         private void DisplayParameters()
        {
            pnlParameters.Controls.Clear();
            int y=20;int x1=15;int x2=200;
            if (Parameters.Count > 0)
            {
                //at least one parameter is present
                foreach (spParam parm in _parameters)
                {
                    Label _parmLabel = new Label();
                    _parmLabel.Text = parm.ParamName;
                    Control _parmControl=new Control();
                    switch (parm.ParamType)
                    {
                        case "int":
                        case "string":
                        case "char":
                        case "decimal":
                        case "float":
                        case "double":
                        case "System.Guid":
                        case "System.Xml.XmlDocument":
                        case "DateTime":
                        case "Byte[]":
                            TextBox _tbox = new TextBox();
                            _tbox.Name = parm.ParamName;
                            _parmControl = _tbox;
                            break;
                        case "bool":
                            CheckBox _cbox = new CheckBox();
                            _cbox.Name = parm.ParamName;
                            _parmControl = _cbox;
                            break;
                        default:
                            break;
                    }
                    _parmLabel.Top = y; _parmLabel.Left = x1; _parmLabel.Width = 180; _parmControl.Top = y; _parmControl.Left = x2;
                    if (parm.VariableType() != "DateTime")
                    {
                        this.toolTip1.SetToolTip(_parmControl, "Enter a value of type " + parm.VariableType());
                        this.helpProvider1.SetHelpString(_parmControl, "Enter a value of type " + parm.VariableType());
                    }
                    else
                    {
                        this.toolTip1.SetToolTip(_parmControl, "Enter a DateTime value in single quotes (' ')");
                        this.helpProvider1.SetHelpString(_parmControl, "Enter a DateTime value in single quotes (' ')");
                    }
                    pnlParameters.Controls.Add(_parmLabel); pnlParameters.Controls.Add(_parmControl);
                    y += 25;
                    
                    if (y > pnlParameters.Height)
                    {
                        pnlParameters.Height += 25;
                        vscrlParameters.Minimum = 0; vscrlParameters.Maximum = pnlParameters.Height-pnlBase.Height; vscrlParameters.Value = _currentParmScrollPos;
                        if (pnlParameters.Height > pnlBase.Height) { vscrlParameters.Visible = true;  } else { vscrlParameters.Visible = false; }
                    }
                }
            } 
            
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void vscrlParameters_Scroll(object sender, ScrollEventArgs e)
        {
            if (vscrlParameters.Value < 0) { vscrlParameters.Value = 0; }
            if (vscrlParameters.Value > vscrlParameters.Maximum) { vscrlParameters.Value = vscrlParameters.Maximum; }
            pnlParameters.Top = (-1) * vscrlParameters.Value;
            System.Diagnostics.Debug.WriteLine("MIN: " + vscrlParameters.Minimum.ToString() + "   MAX: " + vscrlParameters.Maximum.ToString() + "   VAL: " + vscrlParameters.Value.ToString() + "   CUR: " + _currentParmScrollPos.ToString() + "  PTOP: " + pnlParameters.Top.ToString() + "   PHEIGHT: " + pnlParameters.Height.ToString());
            _currentParmScrollPos = vscrlParameters.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _commandText=string.Empty;
            //clear the result set groupbox of all extra controls
            DataGridView dgv = dgridResults;
            pnlResults.Controls.Clear();
            pnlResults.Controls.Add(dgv);
            int _selstart=0;
            int _selEnd=0;
            switch (_eType)
            {
                    
                case spType.SELECT:
                    _selstart = richTextBox1.Text.IndexOf("SELECT");
                    if(richTextBox1.Text.Substring(_selstart).StartsWith("SELECT statements")) { _selstart = richTextBox1.Text.IndexOf("SELECT",_selstart+4);}
                    _selEnd = richTextBox1.Text.IndexOf("END");
                    _commandText = richTextBox1.Text.Substring(_selstart, _selEnd - _selstart);
                    break;
                case spType.INSERT:
                    _selstart = richTextBox1.Text.IndexOf("INSERT");
                    if (richTextBox1.Text.Substring(_selstart).StartsWith("INSERT statements")) { _selstart = richTextBox1.Text.IndexOf("INSERT", _selstart + 4); }
                    _selEnd = richTextBox1.Text.IndexOf("END");
                    _commandText = richTextBox1.Text.Substring(_selstart, _selEnd - _selstart);
                    //remove all lines for return identity value
                    _commandText = _commandText.Replace("DECLARE @RES int", "").Replace("SELECT @RES = @@IDENTITY", "").Replace("SELECT @RES As Id", "").Replace("RETURN @RES", "");
                    break;
                case spType.UPDATE:
                    _selstart = richTextBox1.Text.IndexOf("UPDATE");
                    if (richTextBox1.Text.Substring(_selstart).StartsWith("UPDATE statements")) { _selstart = richTextBox1.Text.IndexOf("UPDATE", _selstart + 4); }
                    _selEnd = richTextBox1.Text.IndexOf("END");
                    _commandText = richTextBox1.Text.Substring(_selstart, _selEnd - _selstart);
                    break;
                case spType.DELETE:
                    _selstart = richTextBox1.Text.IndexOf("DELETE");
                    if (richTextBox1.Text.Substring(_selstart).StartsWith("DELETE statements")) { _selstart = richTextBox1.Text.IndexOf("DELETE", _selstart + 4); }
                    _selEnd = richTextBox1.Text.IndexOf("END");
                    _commandText = richTextBox1.Text.Substring(_selstart, _selEnd - _selstart);
                    break;
                case spType.COMPILED:
                    break;
                default:
                    //do nothing
                    break;
            }
            try
            {
                foreach (spParam spp in _parameters)
                {
                    if (_eType != spType.COMPILED)
                    {
                        switch (spp.VariableType())
                        {
                            case "bool":
                                string _checked = "false";
                                System.Windows.Forms.CheckBox _cb = (System.Windows.Forms.CheckBox)pnlParameters.Controls[spp.ParamName];
                                if (_cb.Checked) { _checked = "true"; } else { _checked = "false"; }
                                _commandText = _commandText.Replace(spp.ParamName, _checked);
                                break;
                            case "System.Xml.XmlDocument":
                                //System.Xml.XmlDocument xDocParam = new System.Xml.XmlDocument();
                                //xDocParam.LoadXml(((System.Windows.Forms.TextBox)pnlParameters.Controls[spp.ParamName]).Text);
                                //_commandText = _commandText.Replace(spp.ParamName, xDocParam);
                                lblMsg.Text = "XmlDocuments are not supported as test arguments";
                                break;
                            case "Byte[]":
                                //System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                                //_commandText = _commandText.Replace(spp.ParamName, encoding.GetBytes(((System.Windows.Forms.TextBox)pnlParameters.Controls[spp.ParamName]).Text));
                                lblMsg.Text = "Byte arrays are not supported as test arguments";
                                break;
                            case "string":
                                _commandText = _commandText.Replace(spp.ParamName, "'" + ((System.Windows.Forms.TextBox)pnlParameters.Controls[spp.ParamName]).Text + "'");
                                break;
                            default:
                                //all numeric types
                                _commandText = _commandText.Replace(spp.ParamName, ((System.Windows.Forms.TextBox)pnlParameters.Controls[spp.ParamName]).Text);
                                break;
                        }
                    }
                }
                string connectionString = _connectionString;
                using (SqlConnection connection1 = new SqlConnection(connectionString))
                {
                    connection1.Open();
                    if (_eType != spType.COMPILED)
                    {
                        SqlCommand cmd = new SqlCommand(_commandText, connection1);
                        cmd.CommandType = CommandType.Text;
                        int _timeOut = 30;
                        try
                        {
                            _timeOut = System.Convert.ToInt32(txtQueryTimeout.Text);
                        }
                        catch { _timeOut = 30; txtQueryTimeout.Text = "30"; }
                        cmd.CommandTimeout = _timeOut;
                        switch (_eType)
                        {

                            case spType.SELECT:
                                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                                DataSet ds = new DataSet();
                                adapter.Fill(ds);
                                //dgridResults.DataSource = ds.Tables[0];
                                DataGridView lastGrid = dgridResults;
                                dgridResults.Visible = false;
                                dgridResults.Height = 72;
                                int _currentTableNumber = -1;
                                foreach (DataTable tbl in ds.Tables)
                                {
                                    _currentTableNumber++;
                                    DataGridView g = new DataGridView();
                                    g.Name = "Datagrid_" + _currentTableNumber.ToString();
                                    g.DataSource = tbl;
                                    g.Width = dgridResults.Width;
                                    g.Left = dgridResults.Left;
                                    if(ds.Tables.Count==1)
                                    {
                                        g.Height = 140;
                                    }
                                    else
                                    {
                                        g.Height = dgridResults.Height;
                                    }
                                    g.Top = lastGrid.Top + lastGrid.Height + 6;
                                    pnlResults.Controls.Add(g);
                                    lastGrid = g;
                                    if ((lastGrid.Top + lastGrid.Height+6) > pnlResults.Height)
                                    {
                                        pnlResults.Height += lastGrid.Height + 6;
                                        vscrlResults.Minimum = 0; vscrlResults.Maximum = pnlResults.Height - groupBox2.Height; vscrlResults.Value = _currentParmScrollPos;
                                        if (pnlResults.Height > groupBox2.Height) { vscrlResults.Visible = true; } else { vscrlResults.Visible = false; }
                                    }
                                }
                                //set the parameter in the group box to their new values - may not be needed if no OUT or INOUT directions
                                break;
                            case spType.INSERT:
                                Object obj = cmd.ExecuteScalar();
                                try
                                {
                                    int _scalrResult = (int)obj;
                                    lblMsg.Text = "INSERT Successful - " + _scalrResult.ToString() + " returned as result...";
                                }
                                catch (Exception innerException) { lblMsg.Text = "INSERT Successful - no result returned..."; }
                                break;
                            case spType.UPDATE:
                                cmd.ExecuteNonQuery();
                                lblMsg.Text = "UPDATE Successful...";
                                break;
                            case spType.DELETE:
                                cmd.ExecuteNonQuery();
                                lblMsg.Text = "DELETE Successful...";
                                break;
                        }

                    }
                    else
                    {
                        //executing a compiled stored proc from the code gen test button and not the spgen test button
                        SqlCommand cmdSP = new SqlCommand(dbTableParameters.StripSchema( _spName), connection1);
                        cmdSP.CommandType = CommandType.StoredProcedure;
                        foreach (spParam spp in _parameters)
                        {
                            cmdSP.Parameters.Add(spp.ParamName,spp.ParamDef());
                            ParameterDirection pd = new ParameterDirection();
                            switch(spp.Direction)
                            {
                                case "Input":
                                    pd=ParameterDirection.Input;
                                    break;
                                case "Output":
                                    pd=ParameterDirection.Output;
                                    break;
                                case "InputOutput":
                                    pd=ParameterDirection.InputOutput;
                                    break;
                                default:
                                    //?? this will probably never be hit
                                    pd=ParameterDirection.ReturnValue;
                                    break;
                            }
                            cmdSP.Parameters[spp.ParamName].Direction = pd;
                            switch (spp.VariableType())
                            {
                                case "bool":
                                    string _checked = "false";
                                    System.Windows.Forms.CheckBox _cb = (System.Windows.Forms.CheckBox)pnlParameters.Controls[spp.ParamName];
                                    if (_cb.Checked) { _checked = "true"; } else { _checked = "false"; }
                                    cmdSP.Parameters[spp.ParamName].Value = _checked;
                                    break;
                                case "System.Xml.XmlDocument":
                                    //System.Xml.XmlDocument xDocParam = new System.Xml.XmlDocument();
                                    //xDocParam.LoadXml(((System.Windows.Forms.TextBox)pnlParameters.Controls[spp.ParamName]).Text);
                                    //_commandText = _commandText.Replace(spp.ParamName, xDocParam);
                                    lblMsg.Text = "XmlDocuments are not supported as test arguments";
                                    break;
                                case "Byte[]":
                                    //System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                                    //_commandText = _commandText.Replace(spp.ParamName, encoding.GetBytes(((System.Windows.Forms.TextBox)pnlParameters.Controls[spp.ParamName]).Text));
                                    lblMsg.Text = "Byte arrays are not supported as test arguments";
                                    break;
                                case "string":
                                case "char":
                                    cmdSP.Parameters[spp.ParamName].Value = ((System.Windows.Forms.TextBox)pnlParameters.Controls[spp.ParamName]).Text;
                                    break;
                                case "decimal":
                                    //all numeric types
                                    cmdSP.Parameters[spp.ParamName].Value =  System.Convert.ToDecimal(((System.Windows.Forms.TextBox)pnlParameters.Controls[spp.ParamName]).Text);
                                    break;
                                default:
                                    //all numeric types
                                    cmdSP.Parameters[spp.ParamName].Value =  System.Convert.ToInt32(((System.Windows.Forms.TextBox)pnlParameters.Controls[spp.ParamName]).Text);
                                    break;
                            }

                        }
                        SqlDataAdapter adapterSP = new SqlDataAdapter(cmdSP);
                        DataSet dsSP = new DataSet();
                        adapterSP.Fill(dsSP);
                        dgridResults.DataSource = dsSP.Tables[0];
                        DataGridView lastGrid = dgridResults;
                        dgridResults.Height = 72;
                        int _currentTableNumber = -1;
                        foreach (DataTable tbl in dsSP.Tables)
                        {
                            _currentTableNumber++;
                            DataGridView g = new DataGridView();
                            g.Name = "Datagrid_" + _currentTableNumber.ToString();
                            g.DataSource = tbl;
                            g.Width = dgridResults.Width;
                            g.Left = dgridResults.Left;
                            if(dsSP.Tables.Count==1)
                            {
                                g.Height = 140;
                            }
                            else
                            {
                                g.Height = dgridResults.Height;
                            }
                            g.Top = lastGrid.Top + lastGrid.Height + 6;
                            pnlResults.Controls.Add(g);
                            lastGrid=g;
                            if ((lastGrid.Top + lastGrid.Height + 6) > pnlResults.Height)
                            {
                                pnlResults.Height += lastGrid.Height + 6;
                                vscrlResults.Minimum = 0; vscrlResults.Maximum = pnlResults.Height - groupBox2.Height; vscrlResults.Value = _currentParmScrollPos;
                                if (pnlResults.Height > groupBox2.Height) { vscrlResults.Visible = true; } else { vscrlResults.Visible = false; }
                            }
                        }
                        //set the parameter in the group box to their new values - may not be needed if no OUT or INOUT directions
                        foreach(SqlParameter p in cmdSP.Parameters)
                        {
                            if((p.Direction==ParameterDirection.InputOutput)||(p.Direction==ParameterDirection.Output))
                            {
                                switch (p.DbType)
                                {
                                    case DbType.AnsiString:
                                    case DbType.AnsiStringFixedLength:
                                    case DbType.String:
                                    case DbType.StringFixedLength:
                                        //string types
                                        ((System.Windows.Forms.TextBox)pnlParameters.Controls[p.ParameterName]).Text = cmdSP.Parameters[p.ParameterName].Value.ToString();
                                        break;
                                    case DbType.Boolean:
                                        //boolean types
                                        string _checked = "false";
                                        ((System.Windows.Forms.CheckBox)pnlParameters.Controls[p.ParameterName]).Checked = System.Convert.ToBoolean(cmdSP.Parameters[p.ParameterName].Value);
                                        break;
                                    case DbType.Decimal:
                                        //decimal types
                                        ((System.Windows.Forms.TextBox)pnlParameters.Controls[p.ParameterName]).Text = cmdSP.Parameters[p.ParameterName].Value.ToString();
                                        break;
                                    default:
                                        //all numeric types
                                        ((System.Windows.Forms.TextBox)pnlParameters.Controls[p.ParameterName]).Text = cmdSP.Parameters[p.ParameterName].Value.ToString();
                                        break;
                                }
                            }
                        }
                    }
                }

            }
            catch(SqlException sqlEx)
            {
                lblMsg.Text = sqlEx.Message;
            }
            catch(Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }

        private void vscrlResults_Scroll(object sender, ScrollEventArgs e)
        {
            if (vscrlResults.Value < 0) { vscrlResults.Value = 0; }
            if (vscrlResults.Value > vscrlResults.Maximum) { vscrlResults.Value = vscrlResults.Maximum; }
            pnlResults.Top = (-1) * vscrlResults.Value;
            System.Diagnostics.Debug.WriteLine("MIN: " + vscrlResults.Minimum.ToString() + "   MAX: " + vscrlResults.Maximum.ToString() + "   VAL: " + vscrlResults.Value.ToString() + "   CUR: " + _currentResultsScrollPos.ToString() + "  PTOP: " + pnlResults.Top.ToString() + "   PHEIGHT: " + pnlResults.Height.ToString());
            _currentResultsScrollPos = vscrlResults.Value;
        }

        private void pnlResults_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}