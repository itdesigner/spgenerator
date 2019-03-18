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
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.DataVisualization.Charting.Utilities;
using System.Threading.Tasks;

namespace DS.SPGenerator
{
    public partial class frmSPPerf : Form
    {
        int _currentParmScrollPos;
        string _connectionString;
        private string _spText;
        private string _spName;
        private List<PerfPair> rawData;
        private DataTable dt;
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
        
        public frmSPPerf()
        {
            InitializeComponent();
        }
        public frmSPPerf(List<spParam> spp, string connection)
        {
            _currentParmScrollPos = 1;
            _parameters = spp;
            _connectionString = connection;
            InitializeComponent();
            //richTextBox1.Rtf = _spText;
        }
        public frmSPPerf(string spName, List<spParam> spp, string connection)
        {
            _spName = spName;
            _currentParmScrollPos = 1;
            _parameters = spp;
            _connectionString = connection;
            InitializeComponent();
            //richTextBox1.Text = _spText;
        }
        private void frmSPTest_Load(object sender, EventArgs e)
        {
            DisplayParameters();
            cboQueryType.Text = "Data Reader";
            this.Text = "Stored Procedure " + (!string.IsNullOrEmpty(_spName) ? "(" + _spName + ") " : "" ) + "Performance Analysis";
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
                    switch (parm.VariableType())
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
        #region message display methods
        private void DisplayMsg(string msg, int seconds)
        {
            this.timerMsg.Enabled = false;
            this.lblMsg.Text = msg;
            this.timerMsg.Interval = seconds * 1000;
            this.timerMsg.Enabled = true;
            lblMsg.Visible = true;
        }
        private void DisplayMsg(string msg)
        {
            this.lblMsg.Text = msg;
            lblMsg.Visible = true;
        }
        private void ClearMsg()
        {
            this.lblMsg.Text = "";
            lblMsg.Visible = false; ;
        }
        private void timerMsg_Tick(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            lblMsg.Visible = false;
            timerMsg.Enabled = false;
        }
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            DisplayMsg("Running Performance Tests...");
            Application.DoEvents();
            TestParameters param = new TestParameters();
            param.CallCount = (int)this.spinCallNumbers.Value;
            param.ConnectionString = _connectionString;
            param.ReuseConnection = chkReuseConnection.Checked;
            param.SpName = _spName;
            param.QueryType = cboQueryType.Text.ToString();
            param.ParallelExecution = chkParallel.Checked;
            param.CallDelay = (int)spinCallDelay.Value;
               
            List<SqlParameter> paramCollection = new List<SqlParameter>();
            try
            {
                foreach (spParam spp in _parameters)
                {
                    SqlParameter p = new SqlParameter(spp.ParamName, spp.ParamDef());
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
                    p.Direction = pd;
                    switch (spp.VariableType())
                    {
                        case "bool":
                            string _checked = "false";
                            System.Windows.Forms.CheckBox _cb = (System.Windows.Forms.CheckBox)pnlParameters.Controls[spp.ParamName];
                            if (_cb.Checked) { _checked = "true"; } else { _checked = "false"; }
                            p.Value = _checked;
                            break;
                        case "System.Xml.XmlDocument":
                            System.Xml.XmlDocument xDocParam = new System.Xml.XmlDocument();
                            xDocParam.LoadXml(((System.Windows.Forms.TextBox)pnlParameters.Controls[spp.ParamName]).Text);
                            p.Value = xDocParam;
                            break;
                        case "Byte[]":
                            p.Value = Base64Decode(((System.Windows.Forms.TextBox)pnlParameters.Controls[spp.ParamName]).Text);
                            break;
                        case "string":
                            p.Value = ((System.Windows.Forms.TextBox)pnlParameters.Controls[spp.ParamName]).Text;
                            break;
                        case "decimal":
                            p.Value =  System.Convert.ToDecimal(((System.Windows.Forms.TextBox)pnlParameters.Controls[spp.ParamName]).Text);
                            break;
                        default:
                            //all numeric types
                            p.Value =  System.Convert.ToInt32(((System.Windows.Forms.TextBox)pnlParameters.Controls[spp.ParamName]).Text);
                            break;
                    }
                    paramCollection.Add(p);
                }
                param.SpParameters = paramCollection;

                var task = Task.Factory.StartNew<TestResult>(() => RunTest(param));
                TestResult result = task.Result;

                // databinding to grid
                rawData = result.Results;
                dt = LoadTable(rawData);
                bindSource.DataSource = dt;
                bindSource.Filter = "Time >= " + spinThreshhold.Value.ToString();
                bindSource.ResetBindings(false);
                gridTestResults.DataSource = bindSource;
                gridTestResults.Refresh();
                gridTestResults.Columns[0].Width = 50;
                gridTestResults.Columns[1].Width = 80;

                ClearMsg();
                // update distribution chart if present
                if (rawData != null)
                {
                    UpdateGraph();
                }
                if (gridTestResults.RowCount > 0)
                {
                    groupBox2.Text = "Results (" + (gridTestResults.RowCount - 1).ToString() + " above Threshhold)";
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

        private void spinIntervals_ValueChanged(object sender, EventArgs e)
        {
            UpdateGraph();
        }
        public static double StandardDeviation(List<double> valueList)
        {
            double M = 0.0;
            double S = 0.0;
            int k = 1;
            foreach (double value in valueList)
            {
                double tmpM = M;
                M += (value - tmpM) / k;
                S += (value - tmpM) * (value - M);
                k++;
            }
            return Math.Sqrt(S / (k - 1));
        }
        public string Base64Encode(byte[] encbuff)
        {
            return Convert.ToBase64String(encbuff);
        }
        public byte[] Base64Decode(string str)
        {
            return Convert.FromBase64String(str);
        }
        public static string StripSchema(string objName)
        {
            char[] splits = { '.' };
            string[] splitString = objName.Split(splits);
            if (splitString.Length > 1) { return splitString[1]; } else { return objName; }
        }
        private TestResult RunTest(TestParameters param)
        {
            List<PerfPair> testPairs = new List<PerfPair>();

            int _runcount = param.CallCount;
            bool _resuseConn = param.ReuseConnection;
            decimal totalExeTime = 0;


            if (_resuseConn == true)
            {
                SqlConnection c = new SqlConnection(param.ConnectionString);
                System.Diagnostics.Stopwatch swC = new System.Diagnostics.Stopwatch();
                swC.Start();
                c.Open();
                swC.Stop();

                for (int i = 0; i < _runcount; i++)
                {
                    TimeSpan ts = RunSingleTest(c, param.SpParameters, param.SpName, param.QueryType);
                    totalExeTime += (decimal)ts.TotalMilliseconds;
                    testPairs.Add(new PerfPair(i, (decimal)ts.TotalMilliseconds));
                    if (param.CallDelay > 0) { System.Threading.Thread.Sleep(param.CallDelay); }
                }
                c.Close();
                c = null;
            }
            else
            {
                if (!param.ParallelExecution)
                {
                    for (int i = 0; i < _runcount; i++)
                    {
                        SqlConnection c = new SqlConnection(param.ConnectionString);
                        System.Diagnostics.Stopwatch swC = new System.Diagnostics.Stopwatch();
                        swC.Start();
                        c.Open();
                        swC.Stop();
                        TimeSpan ts = RunSingleTest(c, param.SpParameters, param.SpName, param.QueryType);
                        totalExeTime += (decimal)ts.TotalMilliseconds;
                        testPairs.Add(new PerfPair(i, (decimal)ts.TotalMilliseconds));
                        c.Close();
                        c = null;
                        if (param.CallDelay > 0) { System.Threading.Thread.Sleep(param.CallDelay); }
                    }
                }
                else
                {
                    Parallel.For(0, _runcount - 1, (i) =>
                    {
                        SqlConnection c = new SqlConnection(param.ConnectionString);
                        System.Diagnostics.Stopwatch swC = new System.Diagnostics.Stopwatch();
                        swC.Start();
                        c.Open();
                        swC.Stop();
                        TimeSpan ts = RunSingleTest(c, param.SpParameters, param.SpName, param.QueryType);
                        totalExeTime += (decimal)ts.TotalMilliseconds;
                        testPairs.Add(new PerfPair(i, (decimal)ts.TotalMilliseconds));
                        c.Close();
                        c = null;
                        if (param.CallDelay > 0) { System.Threading.Thread.Sleep(param.CallDelay); }
                    });
                }
            }
            TestResult result = new TestResult();
            result.Results = testPairs;
            result.AvgTime = totalExeTime / _runcount;
            result.TotalTime = totalExeTime;
            return result;
        }
        private TimeSpan RunSingleTest(SqlConnection conn, List<SqlParameter> paramCollection, string spname, string queryType)
        {
            int RETURN_VALUE = 0;
            TimeSpan ts = new TimeSpan();
            try
            {
                //executing a compiled stored proc 
                SqlCommand cmdSP = new SqlCommand(StripSchema(spname), conn);
                //SqlParameter[] ps = paramCollection.ToArray();
                foreach (SqlParameter p in paramCollection) { cmdSP.Parameters.Add(p); }
                cmdSP.CommandType = CommandType.StoredProcedure;

                if (queryType.ToUpper() == "DATA SET")
                {
                    // a dataset call
                    SqlDataAdapter adapterSP = new SqlDataAdapter(cmdSP);
                    DataSet dsSP = new DataSet();
                    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                    sw.Start();
                    adapterSP.Fill(dsSP);
                    sw.Stop();
                    ts = sw.Elapsed;
                }
                else
                {
                    // must be a datareader call
                    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                    sw.Start();
                    SqlDataReader reader = cmdSP.ExecuteReader();
                    do
                    {
                        while (reader.Read())
                        {

                        }

                    } while (reader.NextResult());
                    sw.Stop();
                    reader.Close();
                    cmdSP.Dispose();
                    ts = sw.Elapsed;
                }

                // now clear the parameters collection for reuse
                cmdSP.Parameters.Clear();
            }
            catch (SqlException sqlEx)
            {
                //lblMsg.Text = sqlEx.Message;
            }
            catch (Exception ex)
            {
                //lblMsg.Text = ex.Message;
            }
            return ts;
        }
        public void UpdateGraph()
        {
            if (rawData != null)
            {
                List<double> values = new List<double>();
                decimal total = 0;

                chart1.Series["RawData"].Points.Clear();
                chart1.Series["DataDistribution"].Points.Clear();
                for (int i = 0; i < rawData.Count; i++)
                {
                    chart1.Series["RawData"].Points.AddY(rawData[i].Time);
                }
                foreach (DataPoint dataPoint in chart1.Series["RawData"].Points)
                {
                    chart1.Series["DataDistribution"].Points.AddXY(dataPoint.YValues[0], 1);
                    values.Add(dataPoint.YValues[0]);
                    total += (decimal)dataPoint.YValues[0];
                }
                HistogramChartHelper histogramHelper = new HistogramChartHelper();

                // Specify number of segment intervals
                histogramHelper.SegmentIntervalNumber = (int)spinIntervals.Value;

                //don't show percentage values on right
                histogramHelper.ShowPercentOnSecondaryYAxis = false;

                // Create histogram series    
                histogramHelper.CreateHistogram(chart1, "RawData", "Histogram");
                // Set same X axis scale and interval in the single axis data distribution 
                // chart area as in the histogram chart area.
                chart1.ChartAreas["Default"].AxisX.Minimum = chart1.ChartAreas["HistogramArea"].AxisX.Minimum;
                chart1.ChartAreas["Default"].AxisX.Maximum = chart1.ChartAreas["HistogramArea"].AxisX.Maximum;
                chart1.ChartAreas["Default"].AxisX.Interval = chart1.ChartAreas["HistogramArea"].AxisX.Interval;

                txtStdDev.Text = StandardDeviation(values).ToString("0.0000");
                txtAve.Text = (total / values.Count).ToString("0.0000");
            }
        }
        private DataTable LoadTable(List<PerfPair> pairs)
        {
            DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("Call", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Time", System.Type.GetType("System.Decimal"));
            foreach (PerfPair pp in pairs)
            {
                if (pp != null)
                {
                    DataRow dr = dt.NewRow();
                    dr["Call"] = pp.Call;
                    dr["Time"] = pp.Time;
                    dt.Rows.Add(dr);
                }
            }
            return dt;

        }
        private void chkParallel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkParallel.Checked) { chkReuseConnection.Checked = false; }
        }

        private void chkReuseConnection_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReuseConnection.Checked) { chkParallel.Checked = false; }
        }

        private void spinThreshhold_ValueChanged(object sender, EventArgs e)
        {
            if (dt != null)
            {
                bindSource.DataSource = dt;
                bindSource.Filter = "Time >= " + spinThreshhold.Value.ToString();
                bindSource.ResetBindings(false);
                gridTestResults.DataSource = bindSource;
                gridTestResults.Refresh();
                groupBox2.Text = "Results (" + (gridTestResults.RowCount - 1).ToString() + " above Threshhold)";
            }
        }
    }
}