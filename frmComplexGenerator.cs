using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DS.SPGenerator
{
    public partial class frmComplexGenerator : Form
    {
        #region passed variables
        private string db = string.Empty;
        private string srvr = string.Empty;
        private bool useWA = true;
        private string _connectionString = string.Empty;
        #endregion

        #region local variables
        private bool transitionedSize = false;
        Size lastSZ;
        private Point pLastClicked;
        private List<Relation> relations;
        List<DS.UIControls.Tables.TableDisplayPanel> tables;
        private List<Relation> dbrelations;
        private BindingList<AliasField> alia;
        private List<AliasTable> table_alia;
        private int highestSortOrder = 1;
        private int X = 40; private int Y = 40;
        private int BeginingRowIndex = -1;
        private Rectangle drawingPanelRectangle;
        private Rectangle drawingPanelDisplayPortRectangle;
        DS.SPGenerator.genCore.SyntaxHighlighter sh;
        private bool block_build=false;
        private bool field_loading = false;
        private bool fields_loading = false;
        private string procHeader = "CREATE PROCEDURE [dbo].[$COMPLEXSPNAME$]" + System.Environment.NewLine + "$PARAMETERS$" + System.Environment.NewLine + "AS" + System.Environment.NewLine + "BEGIN" + System.Environment.NewLine + 
                                    "    -- SET NOCOUNT ON added to prevent extra result sets from" + System.Environment.NewLine + "    -- interfering with SELECT statements" + System.Environment.NewLine + "    SET NOCOUNT ON;" + System.Environment.NewLine;
        private string procFooter = "END";
        DS.UIControls.Tables.TableDisplayPanel clickedPanel;
        #endregion

        #region ctor
        public frmComplexGenerator()
        {
            InitializeComponent();
            initialize();
        }
        public frmComplexGenerator(string connectionstring, string dbname, string server, bool usewa)
        {
            InitializeComponent();
            initialize();
            _connectionString = connectionstring;
            db = dbname;
            srvr = server;
            useWA = usewa;
            lblDB.Text = server.ToUpper() + " - " + dbname.ToUpper();
            txtComplexSPName.Text = "USP_" + db + "_Select";
        }
        private void initialize()
        {
            relations = new List<Relation>();
            dbrelations = new List<Relation>();
            tables = new List<DS.UIControls.Tables.TableDisplayPanel>();
            alia = new BindingList<AliasField>();
            table_alia = new List<AliasTable>();
            pLastClicked = new Point(0, 0);
            drawingPanelRectangle = new Rectangle(panel1.Location, panel1.Size);
            drawingPanelDisplayPortRectangle = new Rectangle(panel1.Location, panel1.Size);
            sh = new genCore.SyntaxHighlighter();
            LoadFilterCriteria();
            LoadSortCriteria();
            LoadDefaultSortOrders();
            lblMsg.Text = string.Empty;
        }
        #endregion

        #region context popup menu events
        private List<Relation> CleanDBRelations(List<Relation> relations)
        {
            List<Relation> rpks = new List<Relation>();
            List<Relation> rfks = new List<Relation>();
            List<Relation> rs = new List<Relation>();
            // get the pk fields
            foreach (Relation r in relations)
            {
                if (string.IsNullOrEmpty(r.DestTable))
                {
                    rpks.Add(r);
                }
                else
                {
                    rfks.Add(r);
                }
            }
            // now we have seperated the pk and fk relation sides - start iterating thru the fks and adding them to the final 
            // results using values from pk to identify index
            foreach (Relation r in rfks)
            {
                //get the name source table name and column
                string tname = r.SourceTable;
                string cname = r.SourceColumn;
                // now go through the pks collection to find a) if it exists and b) the column index position / table alias
                foreach (Relation rpk in rpks)
                {
                    if (rpk.SourceTable == tname && rpk.SourceColumn == cname)
                    {
                        r.SourceIndex = rpk.SourceIndex;
                        r.SourceTableAlias = rpk.SourceTableAlias;
                        break;
                    }
                }
                // either we have it or we don't because the source table has not be selected to load
                if (r.SourceIndex > -1)
                {
                    r.DBDefined = true;
                    r.UserDefined = false;
                    rs.Add(r);
                }
            }
            return rs;
        }
        private void addTablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Relation> temp_relations = new List<Relation>();
            List<string> choices = new List<string>();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(_connectionString);
            System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand();
            comm.Connection = conn;
            string sql = "SELECT T.TABLE_NAME AS TABLE_NAME FROM INFORMATION_SCHEMA.TABLES T LEFT JOIN sys.extended_properties E ON object_id(T.TABLE_SCHEMA + '.[' + T.TABLE_NAME + ']') = E.major_id AND E.minor_id = 0 AND E.class=1 AND E.name = 'MS_Description' WHERE T.TABLE_TYPE = 'BASE TABLE' ORDER BY T.TABLE_SCHEMA + '.' + T.TABLE_NAME";
            comm.CommandText = sql;
            comm.CommandType = CommandType.Text;
            DataSet DSt = new DataSet();
            System.Data.SqlClient.SqlDataAdapter DA = new System.Data.SqlClient.SqlDataAdapter(comm);
            conn.Open();
            DA.Fill(DSt);
            conn.Close();
            foreach (DataRow dr in DSt.Tables[0].Rows)
            {
                choices.Add(dr["TABLE_NAME"].ToString());
            }
            // create a copy of the tble alias collection
            List<AliasTable> usedTA = new List<AliasTable>();
            foreach (AliasTable a in table_alia)
            {
                usedTA.Add(new AliasTable(a.Table, a.Alias));
            }

            frmTableSelector ts = new frmTableSelector(choices, usedTA);
            ts.StartPosition = FormStartPosition.CenterParent;
            if (ts.ShowDialog() == DialogResult.OK)
            {
                // add each selected table to the screen
                foreach (AliasTable s in ts.Selected)
                {
                    if (!table_alia.Contains(s))
                    {
                        table_alia.Add(s);
                        DS.SPGenerator.genCore.dbTableParameters t = new DS.SPGenerator.genCore.dbTableParameters();
                        t.DatabaseName = db;
                        t.Server = srvr;
                        t.Table = s.Table;
                        t.Alias = s.Alias;
                        t.UseWindowsAuthentication = useWA;
                        if (t.IsValid())
                        {
                            DS.UIControls.Tables.TableDisplayPanel td = LoadTable(t);
                            if (td.Tag != null)
                            {
                                try
                                {
                                    List<Relation> rs = (List<Relation>)td.Tag;
                                    temp_relations.AddRange(rs);
                                }
                                catch (Exception ex) { }
                            }
                            //td.BorderStyle = BorderStyle.FixedSingle;
                            td.BorderColor = Color.SteelBlue;
                            td.BorderWidth = 2;
                            td.Moveable = true;
                            td.Sizeable = true;
                            td.CornerRadius = 12;
                            td.GradientEndColor = Color.White;
                            td.GradientStartColor = Color.White;
                            td.Top = Y;
                            td.Left = X;
                            td.Width = 200;
                            td.Height = 300;
                            X += 40;
                            Y += 40;
                            td.Visible = true;
                            td.AllowDrop = true;
                            td.TableName = t.Table;
                            td.Alias = t.Alias;
                            tables.Add(td);
                            this.panel1.Controls.Add(td);
                            td.BringToFront();
                        }
                    }
                }
                // now remove the ones that are no longer applicable - i.e. removed using the selector
                for (int k = table_alia.Count - 1; k >= 0;k-- )
                {
                    AliasTable d = table_alia[k];
                    if (!ts.Selected.Contains(d))
                    {
                        //remove the associated TDP
                        for (int i = tables.Count - 1; i >= 0; i--)
                        {
                            if (tables[i].TableName == d.Table && tables[i].Alias == d.Alias) { panel1.Controls.Remove(tables[i]); tables.RemoveAt(i); }
                        }
                        // remove all relations referencing this table
                        for (int i = relations.Count - 1; i >= 0; i--)
                        {
                            Relation r = relations[i];
                            if ((r.SourceTable == d.Table && r.SourceTableAlias == d.Alias) || (r.DestTable == d.Table && r.DestTableAlias == d.Alias))
                            {
                                // this relation references this table - remove the relation
                                relations.RemoveAt(i);
                            }
                        }
                    }
                }

            }
            // now we have all the tables loaded and we have a temporary set of table relations from the DB
            dbrelations = CleanDBRelations(temp_relations);
            relations.AddRange(dbrelations);
            ts.Close();
            CheckDrawingPanelSize();
        }
        private void removeRelationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaintEventArgs pe = new PaintEventArgs(this.panel1.CreateGraphics(), this.panel1.ClientRectangle);
            Relation r = new Relation();
            if (IsMapLine(pLastClicked, out r))
            {
                // relation line delete selected from popup menu - remove the line
                relations.Remove(r);
                DrawRelations(pe);
                BuildQuery();
            }
        }
        private void selectAllRowsFromSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaintEventArgs pe = new PaintEventArgs(this.panel1.CreateGraphics(), this.panel1.ClientRectangle);
            Relation r = new Relation();
            if (IsMapLine(pLastClicked, out r))
            {
                SetJoinStyle(ref r);
                DrawRelations(pe);
                BuildQuery();
            }
        }
        private void selectAllRowsFromDestinationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaintEventArgs pe = new PaintEventArgs(this.panel1.CreateGraphics(), this.panel1.ClientRectangle);
            Relation r = new Relation();
            if (IsMapLine(pLastClicked, out r))
            {
                SetJoinStyle(ref r);
                DrawRelations(pe);
                BuildQuery();
            }
        }
        private void SetJoinStyle(ref Relation r)
        {
            if (selectAllRowsFromSourceToolStripMenuItem.Checked)
            {
                if (selectAllRowsFromDestinationToolStripMenuItem.Checked)
                {
                    r.JoinStyle = JoinStyle.OUTER;
                }
                else
                {
                    r.JoinStyle = JoinStyle.SOURCE;
                }
            }
            else
            {
                if (selectAllRowsFromDestinationToolStripMenuItem.Checked)
                {
                    r.JoinStyle = JoinStyle.DESTINATION;
                }
                else
                {
                    r.JoinStyle = JoinStyle.INNER;
                }
            }
        }
        #endregion

        #region drawing helpers
        private void UpdateRelationDrawingPoints()
        {
            try
            {
                foreach (Relation r in relations)
                {
                    //get the source and destination table display panels
                    DS.UIControls.Tables.TableDisplayPanel source = null;
                    DS.UIControls.Tables.TableDisplayPanel destination = null;
                    foreach (DS.UIControls.Tables.TableDisplayPanel tdp in tables)
                    {
                        //find the source and destination tables
                        if (tdp.CaptionText == r.SourceTable + " " + r.SourceTableAlias) { source = tdp; }
                        if (tdp.CaptionText == r.DestTable + " " + r.DestTableAlias) { destination = tdp; }
                        if (source != null && destination != null) { break; }

                    }
                    //we should have source and destination panels + index data at this point - if not exit
                    if (source != null && destination != null && r.DestIndex > -1 && r.SourceIndex > -1)
                    {
                        Point s = new Point();
                        Point d = new Point();

                        if (source.Left + source.Width < destination.Left)
                        {
                            //this assumes that the source tdp is completely to the left of the destination tdp
                            s = new Point(source.Left + source.Width, 54 + source.Top + source.Sections[0].Items[r.SourceIndex].ConnectorPoints.Y);
                            d = new Point(destination.Left, 54 + destination.Top + destination.Sections[0].Items[r.DestIndex].ConnectorPoints.Y);
                            r.SourceSide = ConnectorSide.RIGHT;
                            r.DestSide = ConnectorSide.LEFT;
                            //find out the total x distance between source (right) and destination (left)

                            r.Points.Clear();
                            r.DrawingPoints.Clear();
                            Point d1 = new Point(s.X + 10, s.Y);
                            r.DrawingPoints.Add(new PointPair(s, d1));
                            Point d2 = new Point(d.X - 10, d.Y);
                            r.DrawingPoints.Add(new PointPair(d, d2));
                            r.DrawingPoints.Add(new PointPair(d2, d1));
                            r.Points.AddRange(new Point[] { s, d1, d2, d });
                        }
                        else if (source.Left > destination.Left + destination.Width)
                        {
                            //this assumes that the source tdp is to the right of the destination tdp
                            s = new Point(source.Left, 54 + source.Top + source.Sections[0].Items[r.SourceIndex].ConnectorPoints.Y);
                            d = new Point(destination.Left + destination.Width, 54 + destination.Top + destination.Sections[0].Items[r.DestIndex].ConnectorPoints.Y);
                            r.SourceSide = ConnectorSide.LEFT;
                            r.DestSide = ConnectorSide.RIGHT;
                            r.Points.Clear();
                            r.DrawingPoints.Clear();
                            Point d1 = new Point(s.X - 10, s.Y);
                            r.DrawingPoints.Add(new PointPair(s, d1));
                            Point d2 = new Point(d.X + 10, d.Y);
                            r.DrawingPoints.Add(new PointPair(d, d2));
                            r.DrawingPoints.Add(new PointPair(d2, d1));
                            r.Points.AddRange(new Point[] { s, d1, d2, d });
                        }
                        else if ((source.Left > destination.Left) && (source.Left < (destination.Left + destination.Width)))
                        {
                            // connect the left sides?
                            s = new Point(source.Left, 54 + source.Top + source.Sections[0].Items[r.SourceIndex].ConnectorPoints.Y);
                            d = new Point(destination.Left, 54 + destination.Top + destination.Sections[0].Items[r.DestIndex].ConnectorPoints.Y);
                            //save 3 seperate line segments
                            r.SourceSide = ConnectorSide.LEFT;
                            r.DestSide = ConnectorSide.LEFT;
                            r.Points.Clear();
                            r.DrawingPoints.Clear();
                            Point d1 = new Point(s.X - 25 - (source.Left - destination.Left), s.Y);
                            r.DrawingPoints.Add(new PointPair(s, d1));
                            Point d2 = new Point(d1.X, d.Y);
                            r.DrawingPoints.Add(new PointPair(d1, d2));
                            r.DrawingPoints.Add(new PointPair(d2, d));
                            r.Points.AddRange(new Point[] { s, d1, d2, d });
                        }
                        else
                        {
                            // connect the right sides?
                            s = new Point(source.Left + source.Width, 54 + source.Top + source.Sections[0].Items[r.SourceIndex].ConnectorPoints.Y);
                            d = new Point(destination.Left + destination.Width, 54 + destination.Top + destination.Sections[0].Items[r.DestIndex].ConnectorPoints.Y);
                            //draw 3 seperate line segments
                            r.SourceSide = ConnectorSide.RIGHT;
                            r.DestSide = ConnectorSide.RIGHT;
                            r.Points.Clear();
                            r.DrawingPoints.Clear();
                            Point d1 = new Point(s.X + 25 + ((destination.Left + destination.Width) - (source.Left + source.Width)), s.Y);
                            r.DrawingPoints.Add(new PointPair(s, d1));
                            Point d2 = new Point(d1.X, d.Y);
                            r.DrawingPoints.Add(new PointPair(d1, d2));
                            r.DrawingPoints.Add(new PointPair(d2, d));
                            r.Points.AddRange(new Point[] { s, d1, d2, d });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
        private void DrawRelation(Relation r, Color c, int w, PaintEventArgs e)
        {
            System.Drawing.Graphics formGraphics = e.Graphics;
            System.Drawing.Pen myPen;
            myPen = new System.Drawing.Pen(c, w);
            System.Drawing.Brush myBrush;
            myBrush = new System.Drawing.SolidBrush(c);
            if (r.JoinStyle == JoinStyle.SOURCE || r.JoinStyle == JoinStyle.OUTER)
            {
                Point p = new Point(r.Points[0].X, r.Points[0].Y);
                if (r.SourceSide == ConnectorSide.LEFT) { p.Offset(-12, -6); }
                if (r.SourceSide == ConnectorSide.RIGHT) { p.Offset(0, -6); }

                formGraphics.FillEllipse(myBrush, new Rectangle(p, new Size(12, 12)));
            }
            if (r.JoinStyle == JoinStyle.DESTINATION || r.JoinStyle == JoinStyle.OUTER)
            {
                Point p = new Point(r.Points[r.Points.Count - 1].X, r.Points[r.Points.Count - 1].Y);
                if (r.DestSide == ConnectorSide.LEFT) { p.Offset(-12, -6); }
                if (r.DestSide == ConnectorSide.RIGHT) { p.Offset(0, -6); }

                formGraphics.FillEllipse(myBrush, new Rectangle(p, new Size(12, 12)));
            }
            formGraphics.DrawLines(myPen, r.Points.ToArray());
            myPen.Dispose();
            formGraphics.Dispose();
        }
        private void DrawRelations(PaintEventArgs e)
        {

            //draw the connectors
            //first check if there are any tables
            if (tables == null || tables.Count < 2) { return; }
            //next check if there are any relations
            if (relations == null || relations.Count < 1)
            {
                System.Drawing.Graphics formGraphics = this.panel1.CreateGraphics();
                formGraphics.Clear(Color.White);
                return;
            }
            //update relations coordinates
            UpdateRelationDrawingPoints();
            //only redraw if any of the points are in the clipping region
            Point upperLeft = new Point();
            Point lowerRight = new Point();
            bool first = true;
            foreach (Relation r in relations)
            {
                foreach (Point p in r.Points)
                {
                    if (first) { upperLeft = p; first = false; }
                    if (p.X <= upperLeft.X) { upperLeft.X = p.X; }
                    if (p.Y <= upperLeft.Y) { upperLeft.Y = p.Y; }
                    if (p.X >= lowerRight.X) { lowerRight.X = p.X; }
                    if (p.Y >= lowerRight.Y) { lowerRight.Y = p.Y; }
                }
            }

            foreach (DS.UIControls.Tables.TableDisplayPanel tdp in tables)
            {
                if (tdp.Left <= upperLeft.X) { upperLeft.X = tdp.Left; }
                if (tdp.Top <= upperLeft.Y) { upperLeft.Y = tdp.Top; }
                if (tdp.Left + tdp.Width >= lowerRight.X) { lowerRight.X = tdp.Left + tdp.Width; }
                if (tdp.Top + tdp.Height >= lowerRight.Y) { lowerRight.Y = tdp.Top + tdp.Height; }
            }
            Rectangle relationArea = new Rectangle(upperLeft, new Size(lowerRight.X - upperLeft.X, lowerRight.Y - upperLeft.Y));
            if (e.ClipRectangle.IntersectsWith(relationArea))
            {
                //if we are here we have at least 2 tables and a relation - need to draw
                //System.Drawing.Graphics formGraphics = e.Graphics;
                System.Drawing.Graphics formGraphics = this.panel1.CreateGraphics();
                formGraphics.Clear(Color.White);

                System.Drawing.Pen myPen;
                myPen = new System.Drawing.Pen(System.Drawing.Color.Black, 3);
                System.Drawing.Brush myBrush;
                myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                System.Drawing.Pen dbPen;
                dbPen = new System.Drawing.Pen(System.Drawing.Color.LightGray, 4);
                foreach (Relation r in relations)
                {
                    if (r.DBDefined)
                    {
                        formGraphics.DrawLines(dbPen, r.Points.ToArray());
                    }
                    else
                    {
                        formGraphics.DrawLines(myPen, r.Points.ToArray());
                    }
                    if (r.JoinStyle == JoinStyle.SOURCE || r.JoinStyle == JoinStyle.OUTER)
                    {
                        Point p = new Point(r.Points[0].X, r.Points[0].Y);
                        if (r.SourceSide == ConnectorSide.LEFT) { p.Offset(-12, -6); }
                        if (r.SourceSide == ConnectorSide.RIGHT) { p.Offset(0, -6); }
                        formGraphics.FillEllipse(myBrush, new Rectangle(p, new Size(12, 12)));
                    }
                    if (r.JoinStyle == JoinStyle.DESTINATION || r.JoinStyle == JoinStyle.OUTER)
                    {
                        Point p = new Point(r.Points[r.Points.Count - 1].X, r.Points[r.Points.Count - 1].Y);
                        if (r.DestSide == ConnectorSide.LEFT) { p.Offset(-12, -6); }
                        if (r.DestSide == ConnectorSide.RIGHT) { p.Offset(0, -6); }
                        formGraphics.FillEllipse(myBrush, new Rectangle(p, new Size(12, 12)));
                    }
                }
                myPen.Dispose();
                formGraphics.Dispose();
            }
        }
        private void panelDrawing_Paint(object sender, PaintEventArgs e)
        {
            DrawRelations(e);
            this.chkJoinFromClause.BringToFront();
        }
        private void panelDrawing_MouseClick(object sender, MouseEventArgs e)
        {
            PaintEventArgs pe = new PaintEventArgs(this.panel1.CreateGraphics(), this.panel1.ClientRectangle);
            Point p = new Point(e.X, e.Y);
            pLastClicked = p;

            Relation r = new Relation();
            labelRel.Visible = false;
            if (IsMapLine(p, out r))
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    //set the text for the menu items
                    addOrRemoveTablesToolStripMenuItem.Visible = false;
                    toolStripMenuItem1.Visible = false;
                    selectAllRowsFromDestinationToolStripMenuItem.Visible = true;
                    selectAllRowsFromSourceToolStripMenuItem.Visible = true;
                    removeRelationToolStripMenuItem.Visible = true;
                    selectAllRowsFromSourceToolStripMenuItem.Text = "Select All Rows from " + r.SourceTable;
                    selectAllRowsFromDestinationToolStripMenuItem.Text = "Select All Rows from " + r.DestTable;
                    if (r.JoinStyle == JoinStyle.SOURCE || r.JoinStyle == JoinStyle.OUTER) { selectAllRowsFromSourceToolStripMenuItem.Checked = true; }
                    if (r.JoinStyle == JoinStyle.DESTINATION || r.JoinStyle == JoinStyle.OUTER) { selectAllRowsFromDestinationToolStripMenuItem.Checked = true; }
                    if (r.JoinStyle == JoinStyle.INNER) { selectAllRowsFromSourceToolStripMenuItem.Checked = false; selectAllRowsFromDestinationToolStripMenuItem.Checked = false; }
                    // show the popup menu
                    Point pnt = p;
                    //pnt.Offset(new Point(30, 30));
                    this.menuManageRelations.Show(this.panel1, pnt);
                }
                else
                {
                    int x = Math.Abs(r.Points[0].X - r.Points[r.Points.Count - 1].X) / 2 + Math.Min(r.Points[0].X, r.Points[r.Points.Count - 1].X);
                    int y = Math.Abs(r.Points[0].Y - r.Points[r.Points.Count - 1].Y) / 2 + Math.Min(r.Points[0].Y, r.Points[r.Points.Count - 1].Y);

                    this.labelRel.Text = r.SourceTable + "." + r.SourceColumn + " => " + r.DestTable + "." + r.DestColumn;
                    Point pnt = new Point(x, y);
                    pnt.Offset(new Point(-1 * this.labelRel.Width / 2, 0));
                    ShowRelation(r, pnt);

                    // relation line clicked normally - redraw in color/highlight
                    DrawRelation(r, Color.Maroon, 4, pe);
                }
            }
            else
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    //set the text for the menu items
                    addOrRemoveTablesToolStripMenuItem.Visible = true;
                    toolStripMenuItem1.Visible = false;
                    selectAllRowsFromDestinationToolStripMenuItem.Visible = false;
                    selectAllRowsFromSourceToolStripMenuItem.Visible = false;
                    removeRelationToolStripMenuItem.Visible = false;
                    Point pnt = p;
                    //pnt.Offset(new Point(30, 30));
                    this.menuManageRelations.Show(this.panel1, pnt);
                }
                DrawRelations(pe);
            }
        }
        #endregion

        #region map line helpers
        private double Hypotenuse(double x, double y)
        {
            double res = -1;
            try
            {
                double i = x * x + y * y;
                res = Math.Sqrt(i);
            }
            catch (Exception ex) { }
            return res;
        }
        private bool IsMapLine(Point pt, out Relation relation)
        {
            bool _result = false;
            relation = new Relation();
            foreach (Relation r in relations)
            {
                foreach (PointPair p in r.DrawingPoints)
                {
                    double normalLength = Hypotenuse(p.EndingPoint.X - p.StartingPoint.X, p.EndingPoint.Y - p.StartingPoint.Y);
                    double distance = Math.Abs((double)((pt.X - p.StartingPoint.X) * (p.EndingPoint.Y - p.StartingPoint.Y) - (pt.Y - p.StartingPoint.Y) * (p.EndingPoint.X - p.StartingPoint.X))) / normalLength;
                    if (distance <= 3) { _result = true; relation = r; break; }
                }
            }

            return _result;
        }
        private void ShowRelation(Relation r, Point p)
        {
            this.labelRel.Text = r.SourceTable + "." + r.SourceColumn + " => " + r.DestTable + "." + r.DestColumn;
            this.labelRel.Location = p;
            this.labelRel.Visible = true;
            labelRel.BringToFront();
            timerLabel.Enabled = true;
        }
        private void timerLabel_Tick(object sender, EventArgs e)
        {
            labelRel.Visible = false;
            this.timerLabel.Enabled = false;
        }
        #endregion

        #region display table 
        private DS.UIControls.Tables.TableDisplayPanel LoadTable(DS.SPGenerator.genCore.dbTableParameters table)
        {
            List<Relation> table_relations = new List<Relation>();
            DS.UIControls.Tables.TableDisplayPanel tdp = new DS.UIControls.Tables.TableDisplayPanel();
            tdp.CaptionText = table.Table + " " + table.Alias;
            tdp.TableName = table.Table;
            tdp.Alias = table.Alias;
            tdp.CaptionDescText = "[" + table.Server + " - " + table.DatabaseName + "]";
            tdp.Moveable = true;
            tdp.Sizeable = true;
            tdp.CaptionFont = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tdp.BorderColor = Color.SlateGray;
            tdp.CornerRadius = 30;
            tdp.PanelBackgroundType = UIControls.Panels.CaptionBrushType.Solid;
            tdp.GradientStartColor = Color.LightGray;
            tdp.ShadowDepth = 8;
            tdp.ShadowColor = Color.Black;
            tdp.ShadowEnabled = true;
            tdp.CaptionImage = global::DS.SPGenerator.Properties.Resources.table;
            tdp.Sections.Clear();
            DS.UIControls.Tables.TableDisplaySection tdFields = new DS.UIControls.Tables.TableDisplaySection(tdp);
            //tdFields.HeaderText = "Fields";
            tdFields.Font = new Font("Arial", 8, FontStyle.Bold);
            tdFields.TableName = table.Table + "|" + table.Alias;
            tdFields.SectionDragDropped += new DS.UIControls.Tables.TableDisplaySection.SectionDragDropEventHandler(tdFields_SectionDragDropped);
            tdFields.SectionScrolled += new DS.UIControls.Tables.TableDisplaySection.SectionScrollEventHandler(tdFields_SectionScrolled);
            tdFields.GlacialList.Font = new Font("Arial", 8, FontStyle.Regular);
            int position = -1;
            IDictionaryEnumerator en = table.Columns.GetEnumerator();
            while (en.MoveNext())
            {
                position++;
                DS.SPGenerator.genCore.ColumnProperties cp = (DS.SPGenerator.genCore.ColumnProperties)en.Value;
                DS.UIControls.Boxes.GlacialList.GLItem gi2 = new DS.UIControls.Boxes.GlacialList.GLItem();
                gi2 = tdFields.Items.Add("");
                //check placeholder
                gi2.SubItems[0].Font = new Font(new FontFamily("Arial"), 8, FontStyle.Regular);
                gi2.SubItems[0].FontColor = Color.Gray;
                //Name

                if (cp.PriKey)
                {
                    gi2.SubItems[1].Text = cp.Column + " [PK]";
                    gi2.SubItems[1].Font = new Font(new FontFamily("Arial"), 8, FontStyle.Bold);
                    gi2.SubItems[1].FontColor = Color.Black;
                    table_relations.Add(new Relation(table.Table, table.Alias, position, cp.Column, "", "", -1, "", false, true));
                }
                else
                {
                    if (cp.ForeignKeyProperties.IsFK)
                    {
                        gi2.SubItems[1].Text = cp.Column + " [FK]";
                        gi2.SubItems[1].Font = new Font(new FontFamily("Arial"), 8, FontStyle.Bold);
                        gi2.SubItems[1].FontColor = Color.DarkGreen;
                        table_relations.Add(new Relation(cp.ForeignKeyProperties.RefTable, "", -1, cp.ForeignKeyProperties.RefField, table.Table, table.Alias, position, cp.ForeignKeyProperties.ColumnName, false, true));
                    }
                    else
                    {
                        gi2.SubItems[1].Text = cp.Column;
                        gi2.SubItems[1].Font = new Font(new FontFamily("Arial"), 8, FontStyle.Regular);
                        gi2.SubItems[1].FontColor = Color.Black;
                    }
                }

                //type
                if (cp.Type.ToUpper() == "NUMERIC" || cp.Type.ToUpper() == "DECIMAL" || cp.Type.ToUpper() == "DOUBLE")
                {
                    gi2.SubItems[2].Text = cp.Type + " (" + cp.Precision.ToString() + "," + cp.Scale.ToString() + ")";
                }
                else
                {
                    gi2.SubItems[2].Text = cp.Type;
                }
                gi2.SubItems[2].Tag = cp;
                gi2.Tag = cp;
                gi2.SubItems[2].Font = new Font(new FontFamily("Arial"), 8, FontStyle.Regular);
                gi2.SubItems[2].FontColor = Color.Gray;
                gi2.ChangedEvent += new DS.UIControls.Boxes.GlacialList.ChangedEventHandler(gi2_ChangedEvent);
            }
            tdp.Sections.Add(tdFields);
            tdp.BuildSections();
            tdp.Tag = table_relations;
            tdp.Move += new EventHandler(tdp_Move);
            tdp.CaptionRightClick += tdp_CaptionRightClick;
            //tdp.SectionCollapsedChanged += tdp_SectionCollapsedChanged;
            return tdp;
        }

        //void tdp_SectionCollapsedChanged(object sender, UIControls.Tables.CollapsedEventArgs e)
        //{
        //    try
        //    {
        //        UIControls.Tables.TableDisplayPanel tdp = (UIControls.Tables.TableDisplayPanel)sender;
        //        if (tdp != null)
        //        {
        //            tdp.Height = 50 + e.NewSize.Height;
        //            //tdp.ClientSize = e.NewSize;
        //        }
        //    }
        //    catch (Exception ex) { }
        //}
        void tdp_CaptionRightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // show remove or alias prompt?
                Point p = new Point(e.X,e.Y);
                clickedPanel = (DS.UIControls.Tables.TableDisplayPanel)sender;
                if (clickedPanel != null)
                {
                    if (clickedPanel.ShowDataTypes) { showDataTypesToolStripMenuItem.Checked = true; } else { showDataTypesToolStripMenuItem.Checked = false; }
                }
                contextmenuTDP.Show((Control)sender, p);

            }
        }
        void tdp_Move(object sender, EventArgs e)
        {
            CheckDrawingPanelSize();
        }
        void gi2_ChangedEvent(object source, DS.UIControls.Boxes.GlacialList.ChangedEventArgs e)
        {
            // a change in the table items list occurred - reload the field list
            LoadFields();
        }
        void tdFields_SectionScrolled()
        {
            PaintEventArgs e = new PaintEventArgs(this.CreateGraphics(), this.ClientRectangle);
            DrawRelations(e);
        }
        void tdFields_SectionDragDropped(string sourceTable, string sourceTableAlias, int sourceIndex, string sourceColumn, string destinationTable, string destinationTableAlias, int destinationIndex, string destinationColumn)
        {
            // dragdrop linking event occurred
            // add linking to the relations collection
            if (!string.IsNullOrEmpty(sourceTable) && !string.IsNullOrEmpty(destinationTable) && sourceIndex >= 0 && destinationIndex >= 0)
            {
                if (sourceTable == destinationTable && sourceTableAlias == destinationTableAlias && sourceIndex == destinationIndex) { return; }
                relations.Add(new Relation(sourceTable, sourceTableAlias, sourceIndex, sourceColumn, destinationTable, destinationTableAlias, destinationIndex, destinationColumn, true, false));
            }
            this.panel1.Invalidate();
            BuildQuery();
        }
        private void CheckDrawingPanelSize()
        {
            Rectangle drawingPanelDisplayRect = new Rectangle(panel1.Location, panel1.Size);
            #region determine current drawing rectangle
            // calculate actual rectangle for the drawing panel as it exists at this moment
            Point upperLeft = new Point();
            Point lowerRight = new Point();
            if (tables != null && tables.Count > 0)
            {
                // pick an arbitrary table as the starting point
                upperLeft = tables[0].Location;
                lowerRight = tables[0].Location;
            }
            bool first = true;
            foreach (Relation r in relations)
            {
                foreach (Point p in r.Points)
                {
                    if (first) { upperLeft = p; first = false; }
                    if (p.X <= upperLeft.X) { upperLeft.X = p.X; }
                    if (p.Y <= upperLeft.Y) { upperLeft.Y = p.Y; }
                    if (p.X >= lowerRight.X) { lowerRight.X = p.X; }
                    if (p.Y >= lowerRight.Y) { lowerRight.Y = p.Y; }
                }
            }

            foreach (DS.UIControls.Tables.TableDisplayPanel tdp in tables)
            {
                if (tdp.Left <= upperLeft.X) { upperLeft.X = tdp.Left; }
                if (tdp.Top <= upperLeft.Y) { upperLeft.Y = tdp.Top; }
                if (tdp.Left + tdp.Width >= lowerRight.X) { lowerRight.X = tdp.Left + tdp.Width; }
                if (tdp.Top + tdp.Height >= lowerRight.Y) { lowerRight.Y = tdp.Top + tdp.Height; }
            }
            #endregion
            Rectangle relationArea = new Rectangle(upperLeft, new Size(lowerRight.X - upperLeft.X, lowerRight.Y - upperLeft.Y));
            #region compare to current drawing display port rectangle
            // compare this to the current size of the drawing panel
            // could it all fit in the current panel rectangle
            if (relationArea.Width <= drawingPanelDisplayRect.Width && relationArea.Height <= drawingPanelDisplayRect.Height)
            {
                // it could fit - determine if it is currently scrolled so that it does fit
                if (relationArea.Top >= 0 && relationArea.Top + relationArea.Height <= drawingPanelDisplayRect.Height && relationArea.Left >= 0 && relationArea.Left + relationArea.Width <= drawingPanelDisplayRect.Width)
                {
                    // it all fits and is completely within the default drawing panel positioned at 0,0
                    // reset display port rectangle to default drawing panel rectangle
                    drawingPanelDisplayPortRectangle = drawingPanelDisplayRect;
                    // TODO: remove scrollbars
                    System.Diagnostics.Debug.WriteLine("DRAWING AREA ENTIRELY WITHIN DEFAULT PANEL RECTANGLE");
                }
                else
                {
                    // even though it could fit - it is currently scrolled beyond the default boundaries
                    // TODO: add scrollbars if necessary and reset the display port rectangle 
                    System.Diagnostics.Debug.WriteLine("DRAWING AREA FITS WITHIN DEFAULT PANEL RECTANGLE BUT OFFSET");
                }
            }
            else
            {
                //  current relation area is too big to fit - draw scroll bars appropriately
                // TODO: add scrollbars if necessary and reset the display port rectangle 
                System.Diagnostics.Debug.WriteLine("DRAWING AREA DOES NOTFITS WITHIN DEFAULT PANEL RECTANGLE"); ;
            }
            //Rectangle drawingPanelDisplayPortRectangle
            #endregion

        }
        #endregion

        #region grid events/methods
        private void LoadFields()
        {
            fields_loading = true;
            List<string> selectFields = new List<string>();
            List<AliasTable> tableFields = new List<AliasTable>();
            foreach (DS.UIControls.Tables.TableDisplayPanel t in tables)
            {
                string tableName = t.TableName;
                string alias = t.Alias;
                tableFields.Add(new AliasTable(tableName, alias));
                foreach (DS.UIControls.Boxes.GlacialList.GLItem item in t.Sections[0].Items)
                {
                    if (item.SubItems[0].Checked)
                    {
                        if (string.IsNullOrEmpty(alias))
                        {
                            selectFields.Add(tableName + "." + item.SubItems[1].Text.Replace(" [PK]", "").Replace(" [FK]", ""));
                        }
                        else
                        {
                            selectFields.Add(alias + "." + item.SubItems[1].Text.Replace(" [PK]", "").Replace(" [FK]", ""));
                        }
                        AliasField af = new AliasField(tableName, alias, item.SubItems[1].Text.Replace(" [PK]", "").Replace(" [FK]", ""), "");
                        af.Filter = FilterCriteria.NONE;
                        af.Select = true;
                        af.DataType = ((DS.SPGenerator.genCore.ColumnProperties)item.Tag).ColumnDefinition();
                        af.ColumnProperties = (DS.SPGenerator.genCore.ColumnProperties)item.Tag;
                        bool alreadyexists = false;
                        for (int i = 0; i < alia.Count; i++)
                        {
                            if (alia[i].Table == af.Table && alia[i].Column == af.Column) 
                            { 
                                alreadyexists = true;
                                break; 
                            }
                        }
                        if (!alreadyexists)
                        {
                            field_loading = true;
                            alia.Add(af);
                            field_loading = false;
                        }
                    }
                    else
                    {
                        // item is not checked - make sure it does not exist in the alia list - if it does - remove it
                        AliasField af = new AliasField(tableName, alias, item.SubItems[1].Text.Replace(" [PK]", "").Replace(" [FK]", ""), "");
                        for (int i = 0; i < alia.Count; i++)
                        {
                            if (alia[i].Table == af.Table && alia[i].Column == af.Column) { alia.RemoveAt(i); break; }
                        }
                    }
                }
            }
            block_build=true;
            gridCriteria.DataSource = null;
            gridCriteria.DataSource = alia;
            block_build=false;
            fields_loading = false;
            BuildQuery();
        }
        private void gridCriteria_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Left || e.RowIndex < 0 || e.ColumnIndex >= 0 || BeginingRowIndex < 0) return;
                if (BeginingRowIndex > e.RowIndex)
                {
                    // reorder the items in the alia List
                    AliasField af = alia[BeginingRowIndex];
                    alia.RemoveAt(BeginingRowIndex);
                    alia.Insert(e.RowIndex, af);
                }
                else
                {
                    AliasField af = alia[BeginingRowIndex];
                    alia.RemoveAt(BeginingRowIndex);
                    alia.Insert(e.RowIndex - 1, af);
                }
                gridCriteria.Refresh();
                gridCriteria.Rows[e.RowIndex].Selected = true;
            }
            catch (Exception ex) { }
        }
        private void gridCriteria_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Left || e.RowIndex < 0 || e.ColumnIndex >= 0) return;
                BeginingRowIndex = e.RowIndex;
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.ToString()); }
        }
        void gridCriteria_CellEndEdit(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 7) 
                { 
                    ManageSortOrders((AliasField)alia[e.RowIndex]);
                    block_build = true;
                    gridCriteria.DataSource = null;
                    gridCriteria.DataSource = alia;
                    block_build = false;
                }
                BuildQuery();
            }
            catch (Exception ex) { }
        }
        void gridCriteria_RowsRemoved(object sender, System.Windows.Forms.DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                BuildQuery();
            }
            catch (Exception ex) { }
        }
        void gridCriteria_RowsAdded(object sender, System.Windows.Forms.DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                BuildQuery();
            }
            catch (Exception ex) { }
        }
        private void LoadFilterCriteria()
        {
            bindingsourceFilters.Add(new FilterPair(FilterCriteria.NONE, " "));
            bindingsourceFilters.Add(new FilterPair(FilterCriteria.EQUALS, "="));
            bindingsourceFilters.Add(new FilterPair(FilterCriteria.GREATERTHAN, ">"));
            bindingsourceFilters.Add(new FilterPair(FilterCriteria.GREATERTHANOREQUALTO, ">="));
            bindingsourceFilters.Add(new FilterPair(FilterCriteria.LESSTHAN, "<"));
            bindingsourceFilters.Add(new FilterPair(FilterCriteria.LESSTHANOREQUALTO, "<="));
            bindingsourceFilters.Add(new FilterPair(FilterCriteria.LIKE, "LIKE"));
        }
        private void LoadSortCriteria()
        {
            bindingsourceSorts.Add(new SortPair(SPGenerator.SortDirection.NONE, " "));
            bindingsourceSorts.Add(new SortPair(SPGenerator.SortDirection.ASC, "ASC"));
            bindingsourceSorts.Add(new SortPair(SPGenerator.SortDirection.DESC, "DESC"));
        }
        private void LoadDefaultSortOrders()
        {
            bindingsourceSortOrder.Add(new SPGenerator.SortOrder(0));
            bindingsourceSortOrder.Add(new SPGenerator.SortOrder(1));
        }
        private void ManageSortOrders(AliasField af)
        {
            // if this is NONE - check that all the other sort orders are consistent for display
            if (af.SortOrder == 0)
            {
                // set the sort direction to none
                af.SortDirection = SPGenerator.SortDirection.NONE;
                // iterate thru the entire alia collection and ensure that any specified sort orders start with 1 and are consecutive
                var affectedSortOrders = alia.Where(a => a.SortDirection != SPGenerator.SortDirection.NONE && a.SortOrder >= 1).OrderBy(a => a.SortOrder);
                if (affectedSortOrders != null && affectedSortOrders.Count() > 0)
                {
                    int i = 0;
                    foreach (AliasField f in affectedSortOrders)
                    {
                        if (f.Column != af.Column || f.Alias != af.Alias)
                        {
                            i++;
                            f.SortOrder = i;
                        }
                    }
                    i++;
                    highestSortOrder = i;
                }
                bindingsourceSortOrder.Remove(new SPGenerator.SortOrder(highestSortOrder + 1));
            }
            else
            {
                // add the next incremented sortOrder item

                if (af.SortDirection == SPGenerator.SortDirection.NONE) { af.SortDirection = SPGenerator.SortDirection.ASC; }
                // check if this current value for this aliasfield was already used
                var affectedSortOrders2 = alia.Where(a => a.SortDirection != SPGenerator.SortDirection.NONE && a.SortOrder >= af.SortOrder).OrderBy(a => a.SortOrder);
                if (affectedSortOrders2 != null && affectedSortOrders2.Count() > 0)
                {
                    // shuffle the current previously set item and all higher items down in the sort order
                    foreach (AliasField f in affectedSortOrders2)
                    {
                        if (highestSortOrder == f.SortOrder)
                        {
                            highestSortOrder++;
                            bindingsourceSortOrder.Add(new SPGenerator.SortOrder(highestSortOrder));
                        }
                        if (f.Table != af.Table || f.TableAlias != af.TableAlias || f.Column != af.Column || f.Alias != af.Alias)
                        {
                            f.SortOrder++;
                        }
                    }
                }
                else
                {
                    // add the next incremented sortOrder item
                    highestSortOrder++;
                    bindingsourceSortOrder.Add(new SPGenerator.SortOrder(highestSortOrder));
                    // no affected pre-existing sorts affected - this is new and at the bottom of the sort stack
                }
                // now check that there are no gaps - could be caused by changing a pre-existing sorder to one lower if it wasn't initially the highest
                var affectedSortOrders3 = alia.Where(a => a.SortDirection != SPGenerator.SortDirection.NONE && a.SortOrder >= 1).OrderBy(a => a.SortOrder);
                if (affectedSortOrders3 != null && affectedSortOrders3.Count() > 0)
                {
                    int i = 0;
                    foreach (AliasField f in affectedSortOrders3)
                    {
                        i++;
                        f.SortOrder = i;
                    }
                    i++;
                    highestSortOrder = i;
                    for (int k = bindingsourceSortOrder.Count - 1; k >= 0; k--)
                    {
                        if (((SortOrder)bindingsourceSortOrder[k]).Order > highestSortOrder) { bindingsourceSortOrder.RemoveAt(k); }
                    }
                }

            }
            BuildQuery();
        }
        private string FilterCriteriaToString(FilterCriteria fc)
        {
            string result = string.Empty;
            switch (fc)
            {
                case FilterCriteria.EQUALS:
                    result = "=";
                    break;
                case FilterCriteria.GREATERTHAN:
                    result = ">";
                    break;
                case FilterCriteria.GREATERTHANOREQUALTO:
                    result = ">=";
                    break;
                case FilterCriteria.LESSTHAN:
                    result = "<";
                    break;
                case FilterCriteria.LESSTHANOREQUALTO:
                    result = "<=";
                    break;
                case FilterCriteria.LIKE:
                    result = " LIKE ";
                    break;
                case FilterCriteria.NONE:
                default:
                    result = "";
                    break;
            }
            return result;
        }
        private void gridCriteria_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            gridCriteria.CommitEdit(DataGridViewDataErrorContexts.Commit);
            //ManageSortOrders()
        }
        private void bindingsourceFields_CurrentItemChanged(object sender, EventArgs e)
        {
            if (!field_loading)
            {
                ManageSortOrders((AliasField)bindingsourceFields.Current);
            }
        }
        #endregion

        #region query building
        private void BuildQuery()
        {
            if(block_build || field_loading){ return; }
            List<string> wheres = new List<string>();

            if (!this.chkJoinFromClause.Checked)
            {
                this.rtbComplexSP.Rtf = sh.Highlight(BuildQueryStringSimple(alia, relations));
            }
            else
            {
                rtbComplexSP.Rtf = sh.Highlight(BuildQueryString(alia, relations));
            }
        }
        private string BuildQueryStringSimple(BindingList<AliasField> selections, List<Relation> relations)
        {
            if (selections == null || selections.Count < 1) { return ""; }

            List<string> selects = new List<string>();
            List<string> wheres = new List<string>();
            List<string> whereParams = new List<string>();
            StringBuilder sb = new StringBuilder();
            List<AliasTable> tables = new List<AliasTable>();
            
            #region build sp parameters block and where clause list - selections-based
            string header = procHeader;
            StringBuilder sbParams = new StringBuilder();
            bool hasParams = false;
            foreach (AliasField af in selections)
            {
                if (af.Select)
                {
                    AliasTable at = new AliasTable(af.Table, af.TableAlias);
                    selects.Add("        " + ((string.IsNullOrEmpty(af.TableAlias)) ? af.Table : af.TableAlias) + "." + af.Column + ((!string.IsNullOrEmpty(af.Alias)) ? " AS " + af.Alias : ""));
                    if (!tables.Contains(at)) { tables.Add(at); }
                }
                if (af.Filter != FilterCriteria.NONE)
                {
                    hasParams = true;
                    sbParams.AppendLine("    @" + af.Column + " " + af.DataType + ",");
                    whereParams.Add(((string.IsNullOrEmpty(af.TableAlias)) ? af.Table : af.TableAlias) + "." + af.Column + " " + FilterCriteriaToString(af.Filter) + " @" + af.Column);
                }
            }
            if (hasParams)
            {
                sbParams.Insert(0, "(" + System.Environment.NewLine);
                sbParams.Remove(sbParams.Length - 3, 1);
                sbParams.Append(")");
            }
            header = procHeader.Replace("$COMPLEXSPNAME$", txtComplexSPName.Text).Replace("$PARAMETERS$", sbParams.ToString());
            sb.AppendLine(header);
            #endregion

            if (selections != null && selections.Count > 0)
            {
                sb.AppendLine("    SELECT");
                for(int i=0;i<selects.Count;i++)
                {
                    sb.AppendLine(selects[i] + ((i == selects.Count - 1) ? "" : ","));
                }
            }
            sb.AppendLine("    FROM");
            foreach (Relation r in relations)
            {
                AliasTable ts = new AliasTable(r.SourceTable, r.SourceTableAlias);
                AliasTable td = new AliasTable(r.DestTable, r.DestTableAlias);
                if (!tables.Contains(ts)) { tables.Add(ts); }
                if (!tables.Contains(td)) { tables.Add(td); }
                string st = ((string.IsNullOrEmpty(r.SourceTableAlias)) ? r.SourceTable : r.SourceTableAlias);
                string dt = ((string.IsNullOrEmpty(r.DestTableAlias)) ? r.DestTable : r.DestTableAlias);
                wheres.Add(st + "." + r.SourceColumn + " = " + dt + "." + r.DestColumn);
            }
            foreach (AliasTable f in tables)
            {
                sb.AppendLine("        " + f.Table + ((!string.IsNullOrEmpty(f.Alias)) ? " " + f.Alias : "") + ", ");
            }
            sb = sb.Remove(sb.Length - 4, 2);

            if ((wheres != null && wheres.Count > 0) || (whereParams != null && whereParams.Count > 0))
            {
                sb.AppendLine("    WHERE");
                foreach (string w in wheres)
                {
                    sb.AppendLine("        " + w + " AND ");

                }
                foreach (string w in whereParams)
                {
                    sb.AppendLine("        " + w + " AND ");

                }
                sb = sb.Remove(sb.Length - 7, 7);
            }
            #region build ORDER BY clause - selections-based
            if (selections != null && selections.Count > 0)
            {
                var orderbys = alia.Where(a => a.SortDirection != SPGenerator.SortDirection.NONE && a.SortOrder >= 1).OrderBy(a => a.SortOrder);
                if (orderbys != null && orderbys.Count() > 0)
                {
                    sb.AppendLine("    ORDER BY");
                    foreach (AliasField o in orderbys)
                    {
                        string otext = string.Empty;
                        switch (o.SortDirection)
                        {
                            case SPGenerator.SortDirection.ASC:
                                otext = "ASC";
                                break;
                            case SPGenerator.SortDirection.DESC:
                                otext = "DESC";
                                break;
                        }
                        sb.AppendLine("        " + ((!string.IsNullOrEmpty(o.Alias)) ? o.Alias : ((string.IsNullOrEmpty(o.TableAlias)) ? o.Table : o.TableAlias) + "." + o.Column) + " " + otext + ", ");
                    }
                    sb = sb.Remove(sb.Length - 4, 2);
                }
            }
            #endregion
            sb.AppendLine(System.Environment.NewLine + procFooter);
            return sb.ToString();
        }
        private string BuildQueryString(BindingList<AliasField> selections, List<Relation> relations)
        {
            if (selections == null || selections.Count < 1) { return ""; }

            StringBuilder sb = new StringBuilder();
            //List<AliasTable> tables = new List<AliasTable>();
            List<string> wheres = new List<string>();

            #region build sp parameters block and where clause list - selections-based
            string header = procHeader;
            StringBuilder sbParams = new StringBuilder();
            bool hasParams = false;
            foreach(AliasField af in selections)
            {
                if (af.Filter != FilterCriteria.NONE)
                {
                    hasParams = true;
                    sbParams.AppendLine("    @" + af.Column + " " + af.DataType + ",");
                    wheres.Add(((string.IsNullOrEmpty(af.TableAlias)) ? af.Table : af.TableAlias) + "." + af.Column + " " + FilterCriteriaToString(af.Filter) + " @" + af.Column);
                }
            }
            if (hasParams)
            {
                sbParams.Insert(0, "(" + System.Environment.NewLine);
                sbParams.Remove(sbParams.Length - 3, 1);
                sbParams.Append(")");
            }
            header= procHeader.Replace("$COMPLEXSPNAME$", txtComplexSPName.Text).Replace("$PARAMETERS$", sbParams.ToString());
            sb.AppendLine(header);
            #endregion

            #region build SELECT clause - selections-based
            if (selections != null && selections.Count > 0)
            {
                sb.AppendLine("    SELECT");
                foreach (AliasField sel in selections)
                {
                    if (sel.Select)
                    {
                        AliasTable at = new AliasTable(sel.Table, sel.TableAlias);
                        sb.AppendLine("        " + ((string.IsNullOrEmpty(sel.TableAlias)) ? sel.Table : sel.TableAlias) + "." + sel.Column + ((!string.IsNullOrEmpty(sel.Alias)) ? " AS " + sel.Alias : "") + ", ");
                        
                    }
                }
                sb = sb.Remove(sb.Length - 4, 2);
            }
            #endregion

            #region build FROM clause
            sb.AppendLine("    FROM ");

            List<AliasTable> distinct_tables = new List<AliasTable>();
            List<Relation> allRelations = new List<Relation>();
            List<Relation> allInnerRelations = new List<Relation>();

            #region process relations into a new collection and identify distinct tables
            foreach (Relation r in relations)
            {
                AliasTable ts = new AliasTable(r.SourceTable, r.SourceTableAlias);
                AliasTable td = new AliasTable(r.DestTable, r.DestTableAlias);
                if (!distinct_tables.Contains(ts)) { distinct_tables.Add(ts); }
                if (!distinct_tables.Contains(td)) { distinct_tables.Add(td); }
                allRelations.Add((Relation)r.Clone());
            }
            #endregion

            #region INNER JOIN partial processing - Relation-based

            #region split out all inner joins for grouping
            for (int i = allRelations.Count - 1; i >= 0; i--)
            {
                Relation r = allRelations[i];
                if (r.JoinStyle == JoinStyle.INNER) { allInnerRelations.Add(r); allRelations.RemoveAt(i); }
            }
            // now all inner join relation have been removed to their own collection from the allRelations list - leaving with all other relation types only
            #endregion

            #region process inner join relations into families
            // define master list to hold all groups/families of inner join type relations
            int groupID = -1;
            List<RelationGroup> groupedInnerRelations = new List<RelationGroup>();
            bool done = false;
            while (!done)
            {
                bool exhaustedList = false;
                RelationGroup rg = new RelationGroup();
                while (!exhaustedList)
                {
                    bool itemsAdded = false;
                    for (int i = allInnerRelations.Count - 1; i >= 0; i--)
                    {
                        if (rg.Count == 0)
                        {
                            // if nothing has been added to the group yet - 
                            // this must be the first item - automatically add it
                            Relation current = allInnerRelations[i];
                            rg.Members.Add(current);
                            AliasTable ts = new AliasTable(current.SourceTable, current.SourceTableAlias);
                            AliasTable td = new AliasTable(current.DestTable, current.DestTableAlias);
                            if (!rg.Tables.Contains(ts)) { rg.Tables.Add(ts); }
                            if (!rg.Tables.Contains(td)) { rg.Tables.Add(td); }
                            // remove the original entry
                            allInnerRelations.RemoveAt(i);
                            itemsAdded = true;
                        }
                        else
                        {
                            // items are already in the list - see if the current master item matches one of the items in the group
                            Relation c = allInnerRelations[i];
                            var cnt = rg.Members.Where(r => (r.SourceTable == c.SourceTable && r.SourceTableAlias == c.SourceTableAlias) || (r.SourceTable == c.DestTable && r.SourceTableAlias == c.DestTableAlias) || (r.DestTable == c.SourceTable && r.DestTableAlias == c.SourceTableAlias) || (r.DestTable == c.DestTable && r.DestTableAlias == c.DestTableAlias)).Count();
                            if (cnt >= 1)
                            {
                                // this matches something already in the group - add it
                                rg.Members.Add(c);
                                AliasTable ts = new AliasTable(c.SourceTable, c.SourceTableAlias);
                                AliasTable td = new AliasTable(c.DestTable, c.DestTableAlias);
                                if (!rg.Tables.Contains(ts)) { rg.Tables.Add(ts); }
                                if (!rg.Tables.Contains(td)) { rg.Tables.Add(td); }
                                // remove the original entry
                                allInnerRelations.RemoveAt(i);
                                itemsAdded = true;
                            }
                            else
                            {
                                //no match found in the current group - skip and continue with the rest of the items in the list
                            }
                        }
                    }
                    if (!itemsAdded) { exhaustedList = true; }
                }
                if (rg.Count != 0) { rg.JoinType = JoinStyle.INNER; groupedInnerRelations.Add(rg); }
                if (allInnerRelations == null || allInnerRelations.Count == 0) { done = true; }
            }
            // now all the inner join collections have been created - figure out how the inner jon groups are related
            #endregion

            #endregion

            #region OTHER JOIN partial processing - Relation-based

            // remaining items in the allRelations collection are all joins that are NOT inner joins
            // define master list to hold all groups/families of inner join type relations
            List<RelationGroup> groupedOtherRelations = new List<RelationGroup>();
            done = false;
            while (!done)
            {
                bool exhaustedList = false;
                RelationGroup rg = new RelationGroup();
                while (!exhaustedList)
                {
                    bool itemsAdded = false;
                    for (int i = allRelations.Count - 1; i >= 0; i--)
                    {
                        if (rg.Count == 0)
                        {
                            // if nothing has been added to the group yet - 
                            // this must be the first item - automatically add it
                            Relation current = allRelations[i];
                            rg.Members.Add(current);
                            AliasTable ts = new AliasTable(current.SourceTable, current.SourceTableAlias);
                            AliasTable td = new AliasTable(current.DestTable, current.DestTableAlias);
                            if (!rg.Tables.Contains(ts)) { rg.Tables.Add(ts); }
                            if (!rg.Tables.Contains(td)) { rg.Tables.Add(td); }
                            // remove the original entry
                            allRelations.RemoveAt(i);
                            itemsAdded = true;
                        }
                        else
                        {
                            // items are already in the group - see if the current master item matches one of the items in the group
                            Relation c = allRelations[i];
                            var cnt = rg.Members.Where(r => (r.SourceTable == c.SourceTable && r.SourceTableAlias == c.SourceTableAlias) || (r.SourceTable == c.DestTable && r.SourceTableAlias == c.DestTableAlias) || (r.DestTable == c.SourceTable && r.DestTableAlias == c.SourceTableAlias) || (r.DestTable == c.DestTable && r.DestTableAlias == c.DestTableAlias)).Count();
                            if (cnt >= 1)
                            {
                                // this matches something already in the group - add it
                                rg.Members.Add(c);
                                AliasTable ts = new AliasTable(c.SourceTable, c.SourceTableAlias);
                                AliasTable td = new AliasTable(c.DestTable, c.DestTableAlias);
                                if (!rg.Tables.Contains(ts)) { rg.Tables.Add(ts); }
                                if (!rg.Tables.Contains(td)) { rg.Tables.Add(td); }
                                // remove the original entry
                                allRelations.RemoveAt(i);
                                itemsAdded = true;
                            }
                            else
                            {
                                //no match found in the current group - skip and continue with the rest of the items in the list
                            }
                        }
                    }
                    if (!itemsAdded) { exhaustedList = true; }
                }
                if (rg.Count != 0)
                {
                    rg.JoinType = JoinStyle.UNKNOWN;
                    groupedOtherRelations.Add(rg);
                }
                if (allRelations == null || allRelations.Count == 0) { done = true; }
            }
            // now all other relations have been grouped into families and are exhausted
            //for a final check it will be necessary to add any remaining tables with selected fields in as a CROSSJOIN
            // if no fields are selected - leave out of query statement?
            #endregion

            #region ISOLATED TABLE BY ITSELF or CROSSJOIN partial processing
            List<AliasTable> isolated_tables = new List<AliasTable>();
            foreach (AliasField sel in alia)
            {
                if (sel.Select)
                {
                    AliasTable at = new AliasTable(sel.Table, sel.TableAlias);
                    if (!distinct_tables.Contains(at))
                    {
                        // either by itself of part of a crossjoin query
                        if (!isolated_tables.Contains(at)) { isolated_tables.Add(at); }
                    }
                }
            }
            #endregion

            #region process RelationGroups into a valid FROM partial clause
            if ((groupedInnerRelations != null && groupedInnerRelations.Count > 0) || (groupedOtherRelations != null && groupedOtherRelations.Count > 0))
            {
                SimpleTreeNode<RelationGroup> joinStructure = BuildJoinTree(groupedInnerRelations, groupedOtherRelations);
                sb.Append(BuildJoin(joinStructure));
            }
            #endregion

            #region process isolated tables into the FROm partial clause
            StringBuilder sbISOLATED = new StringBuilder();
            if (isolated_tables != null && isolated_tables.Count > 0)
            {
                //is there only a single table? 
                bool first = true;
                if (distinct_tables.Count > 0) { first = false; }
                foreach (AliasTable it in isolated_tables)
                {
                    if (first)
                    {
                        sbISOLATED.AppendLine("        " + it.Table + ((string.IsNullOrEmpty(it.Alias)) ? "" : " " + it.Alias) + " ");
                    }
                    else
                    {
                        sbISOLATED.AppendLine("        CROSS JOIN " + it.Table + ((string.IsNullOrEmpty(it.Alias)) ? "" : " " + it.Alias) + " ");
                    }
                    first = false;
                }
                sb.Append(sbISOLATED.Remove(sbISOLATED.Length - 3, 1));
            }
            #endregion
            #endregion

            #region process where clause items - Selection-based
            if (wheres != null && wheres.Count > 0)
            {
                sb.AppendLine("    WHERE");
                foreach (string w in wheres)
                {
                    sb.AppendLine("        " + w + " AND ");

                }
                sb = sb.Remove(sb.Length - 7, 7);
            }
            #endregion

            #region build ORDER BY clause - selections-based
            if (selections != null && selections.Count > 0)
            {
                var orderbys = alia.Where(a => a.SortDirection != SPGenerator.SortDirection.NONE && a.SortOrder >= 1).OrderBy(a => a.SortOrder);
                if (orderbys != null && orderbys.Count() > 0)
                {
                    sb.AppendLine("    ORDER BY");
                    foreach (AliasField o in orderbys)
                    {
                        string otext = string.Empty;
                        switch(o.SortDirection)
                        {
                            case SPGenerator.SortDirection.ASC:
                                otext = "ASC";
                                break;
                            case SPGenerator.SortDirection.DESC:
                                otext = "DESC";
                                break;
                        }
                        sb.AppendLine("        " + ((!string.IsNullOrEmpty(o.Alias)) ? o.Alias : ((string.IsNullOrEmpty(o.TableAlias)) ? o.Table : o.TableAlias) + "." + o.Column ) + " " + otext + ", ");
                    }
                    sb = sb.Remove(sb.Length - 4, 2);
                }
            }
            #endregion

            sb.AppendLine(System.Environment.NewLine + procFooter);
            return sb.ToString();
        }
        SimpleTreeNode<RelationGroup> BuildJoinTree(List<RelationGroup> innerGroups, List<RelationGroup> otherGroups)
        {
            List<RelationGroup> combinedGroups = new List<RelationGroup>();
            foreach (RelationGroup g in innerGroups) { combinedGroups.Add(g); }
            foreach (RelationGroup g in otherGroups) { combinedGroups.Add(g); }

            SimpleTreeNode<RelationGroup> node = new SimpleTreeNode<RelationGroup>();
            node.Value = combinedGroups[0];
            combinedGroups.RemoveAt(0);
            BuildTree(ref combinedGroups, ref node);
            return node;
        }
        private void BuildTree(ref List<RelationGroup> remainingGroups, ref SimpleTreeNode<RelationGroup> parentNode)
        {
            foreach (Relation c in parentNode.Value.Members)
            {
                for (int i = remainingGroups.Count - 1; i >= 0; i--)
                {
                    if (remainingGroups.Count == 0) { return; }
                    var cnt = remainingGroups[i].Members.Where(r => (r.SourceTable == c.SourceTable && r.SourceTableAlias == c.SourceTableAlias) || (r.SourceTable == c.DestTable && r.SourceTableAlias == c.DestTableAlias) || (r.DestTable == c.SourceTable && r.DestTableAlias == c.SourceTableAlias) || (r.DestTable == c.DestTable && r.DestTableAlias == c.DestTableAlias)).Count();
                    if (cnt > 0)
                    {
                        SimpleTreeNode<RelationGroup> node = new SimpleTreeNode<RelationGroup>();
                        node.Value = remainingGroups[i];
                        remainingGroups.RemoveAt(i);
                        parentNode.Children.Add(node);
                        BuildTree(ref remainingGroups, ref node);
                    }
                }
            }
        }
        private string BuildJoin(SimpleTreeNode<RelationGroup> node)
        {
            StringBuilder sb = new StringBuilder();
            //write first node
            JoinBuilder(ref node, ref sb);
            //loop through each child
            return sb.ToString();
        }
        private void JoinBuilder(ref SimpleTreeNode<RelationGroup> node, ref StringBuilder joinText)
        {
            // write the current node to the stringbuilder

            switch (node.Value.JoinType)
            {
                case JoinStyle.INNER:
                    #region all inner join processing logic
                    StringBuilder sbDL = new StringBuilder();
                    List<AliasTable> used_tablesINNER = new List<AliasTable>();
                    bool first = true;
                    // order the nodes if there is a parent node
                    if (node.Parent != null)
                    {
                        for (int i = node.Value.Members.Count - 1; i >= 0; i--)
                        {
                            Relation r = node.Value.Members[i];
                            var scINNER = node.Parent.Value.Tables.Where(t => t.Table == r.SourceTable && t.Alias == r.SourceTableAlias).Count();
                            var dcINNER = node.Parent.Value.Tables.Where(t => t.Table == r.DestTable && t.Alias == r.DestTableAlias).Count();
                            if ((scINNER > 0 || dcINNER > 0) && (i > 0))
                            {
                                node.Value.Members.RemoveAt(i);
                                node.Value.Members.Insert(0, r);
                            }
                        }
                        foreach (AliasTable at in node.Parent.Value.Tables)
                        {
                            used_tablesINNER.Add((AliasTable)at.Clone());
                        }
                    }
                    foreach (Relation r in node.Value.Members)
                    {
                        var source_countINNER = used_tablesINNER.Where(t => t.Table == r.SourceTable && t.Alias == r.SourceTableAlias).Count();
                        var dest_countINNER = used_tablesINNER.Where(t => t.Table == r.DestTable && t.Alias == r.DestTableAlias).Count();
                        if (first && source_countINNER == 0 && dest_countINNER == 0)
                        {
                            sbDL.AppendLine("        " + r.SourceTable + ((!string.IsNullOrEmpty(r.SourceTableAlias)) ? " " + r.SourceTableAlias : ""));
                            if (!used_tablesINNER.Contains(new AliasTable(r.SourceTable, r.SourceTableAlias))) { used_tablesINNER.Add(new AliasTable(r.SourceTable, r.SourceTableAlias)); }
                        }

                        if (dest_countINNER > 0)
                        {
                            sbDL.AppendLine("        INNER JOIN " + r.SourceTable + ((!string.IsNullOrEmpty(r.SourceTableAlias)) ? " " + r.SourceTableAlias : "") +
                                    " ON " + ((string.IsNullOrEmpty(r.SourceTableAlias)) ? r.SourceTable : r.SourceTableAlias) + "." + r.SourceColumn + " = " +
                                    ((string.IsNullOrEmpty(r.DestTableAlias)) ? r.DestTable : r.DestTableAlias) + "." + r.DestColumn);
                            if (!used_tablesINNER.Contains(new AliasTable(r.SourceTable, r.SourceTableAlias))) { used_tablesINNER.Add(new AliasTable(r.SourceTable, r.SourceTableAlias)); }
                        }
                        else
                        {
                            sbDL.AppendLine("        INNER JOIN " + r.DestTable + ((!string.IsNullOrEmpty(r.DestTableAlias)) ? " " + r.DestTableAlias : "") +
                                    " ON " + ((string.IsNullOrEmpty(r.SourceTableAlias)) ? r.SourceTable : r.SourceTableAlias) + "." + r.SourceColumn + " = " +
                                    ((string.IsNullOrEmpty(r.DestTableAlias)) ? r.DestTable : r.DestTableAlias) + "." + r.DestColumn);
                            if (!used_tablesINNER.Contains(new AliasTable(r.DestTable, r.DestTableAlias))) { used_tablesINNER.Add(new AliasTable(r.DestTable, r.DestTableAlias)); }
                        }
                        first = false;
                    }
                    joinText.Append(sbDL.ToString());
                    #endregion
                    break;
                default:
                    // examine the parent to determine whether it contains this relation groups source or destination value
                    // iterate thru each relation in the group
                    StringBuilder sbDL2 = new StringBuilder();
                    List<AliasTable> used_tables = new List<AliasTable>();

                    if (node.Parent != null)
                    {
                        foreach (AliasTable at in node.Parent.Value.Tables)
                        {
                            used_tables.Add((AliasTable)at.Clone());
                        }
                    }
                    for (int i = node.Value.Members.Count - 1; i >= 0; i--)
                    {
                        Relation r = node.Value.Members[i];
                        var scINNER = used_tables.Where(t => t.Table == r.SourceTable && t.Alias == r.SourceTableAlias).Count();
                        var dcINNER = used_tables.Where(t => t.Table == r.DestTable && t.Alias == r.DestTableAlias).Count();
                        if ((scINNER > 0 || dcINNER > 0) && (i > 0))
                        {
                            node.Value.Members.RemoveAt(i);
                            node.Value.Members.Insert(0, r);
                        }
                    }

                    foreach (Relation r in node.Value.Members)
                    {
                        if (node.Parent == null)
                        {
                            // nothing to compare it to - just write it out
                            var source_count = used_tables.Where(t => t.Table == r.SourceTable && t.Alias == r.SourceTableAlias).Count();
                            var dest_count = used_tables.Where(t => t.Table == r.DestTable && t.Alias == r.DestTableAlias).Count();

                            if (r.JoinStyle == JoinStyle.SOURCE)
                            {
                                if (source_count == 0 && dest_count == 0) { sbDL2.AppendLine("    " + r.SourceTable + ((string.IsNullOrEmpty(r.SourceTableAlias)) ? "" : " " + r.SourceTableAlias)); }
                                if (dest_count > 0)
                                {
                                    sbDL2.AppendLine("        RIGHT OUTER JOIN " + r.SourceTable + ((string.IsNullOrEmpty(r.SourceTableAlias)) ? "" : " " + r.SourceTableAlias) + " ON " + ((string.IsNullOrEmpty(r.SourceTableAlias)) ? r.SourceTable : r.SourceTableAlias) + "." + r.SourceColumn + " = " + ((string.IsNullOrEmpty(r.DestTableAlias)) ? r.DestTable : r.DestTableAlias) + "." + r.DestColumn);
                                }
                                else
                                {
                                    sbDL2.AppendLine("        LEFT OUTER JOIN " + r.DestTable + ((string.IsNullOrEmpty(r.DestTableAlias)) ? "" : " " + r.DestTableAlias) + " ON " + ((string.IsNullOrEmpty(r.SourceTableAlias)) ? r.SourceTable : r.SourceTableAlias) + "." + r.SourceColumn + " = " + ((string.IsNullOrEmpty(r.DestTableAlias)) ? r.DestTable : r.DestTableAlias) + "." + r.DestColumn);
                                }
                                if (!used_tables.Contains(new AliasTable(r.SourceTable, r.SourceTableAlias))) { used_tables.Add(new AliasTable(r.SourceTable, r.SourceTableAlias)); }
                                if (!used_tables.Contains(new AliasTable(r.DestTable, r.DestTableAlias))) { used_tables.Add(new AliasTable(r.DestTable, r.DestTableAlias)); }
                            }
                            else if (r.JoinStyle == JoinStyle.DESTINATION)
                            {
                                if (source_count == 0 && dest_count == 0) { sbDL2.AppendLine("    " + r.SourceTable + ((string.IsNullOrEmpty(r.SourceTableAlias)) ? "" : " " + r.SourceTableAlias)); }
                                if (dest_count > 0)
                                {
                                    sbDL2.AppendLine("        LEFT OUTER JOIN " + r.SourceTable + ((string.IsNullOrEmpty(r.SourceTableAlias)) ? "" : " " + r.SourceTableAlias) + " ON " + ((string.IsNullOrEmpty(r.SourceTableAlias)) ? r.SourceTable : r.SourceTableAlias) + "." + r.SourceColumn + " = " + ((string.IsNullOrEmpty(r.DestTableAlias)) ? r.DestTable : r.DestTableAlias) + "." + r.DestColumn);
                                }
                                else
                                {
                                    sbDL2.AppendLine("        RIGHT OUTER JOIN " + r.DestTable + ((string.IsNullOrEmpty(r.DestTableAlias)) ? "" : " " + r.DestTableAlias) + " ON " + ((string.IsNullOrEmpty(r.SourceTableAlias)) ? r.SourceTable : r.SourceTableAlias) + "." + r.SourceColumn + " = " + ((string.IsNullOrEmpty(r.DestTableAlias)) ? r.DestTable : r.DestTableAlias) + "." + r.DestColumn);
                                }
                                if (!used_tables.Contains(new AliasTable(r.SourceTable, r.SourceTableAlias))) { used_tables.Add(new AliasTable(r.SourceTable, r.SourceTableAlias)); }
                                if (!used_tables.Contains(new AliasTable(r.DestTable, r.DestTableAlias))) { used_tables.Add(new AliasTable(r.DestTable, r.DestTableAlias)); }

                            }
                            else if (r.JoinStyle == JoinStyle.OUTER)
                            {
                                if (source_count == 0 && dest_count == 0) { sbDL2.AppendLine("    " + r.SourceTable + ((string.IsNullOrEmpty(r.SourceTableAlias)) ? "" : " " + r.SourceTableAlias)); }
                                if (dest_count > 0)
                                {
                                    sbDL2.AppendLine("        FULL OUTER JOIN " + r.SourceTable + ((string.IsNullOrEmpty(r.SourceTableAlias)) ? "" : " " + r.SourceTableAlias) + " ON " + ((string.IsNullOrEmpty(r.SourceTableAlias)) ? r.SourceTable : r.SourceTableAlias) + "." + r.SourceColumn + " = " + ((string.IsNullOrEmpty(r.DestTableAlias)) ? r.DestTable : r.DestTableAlias) + "." + r.DestColumn);
                                }
                                else
                                {
                                    sbDL2.AppendLine("        FULL OUTER JOIN " + r.DestTable + ((string.IsNullOrEmpty(r.DestTableAlias)) ? "" : " " + r.DestTableAlias) + " ON " + ((string.IsNullOrEmpty(r.SourceTableAlias)) ? r.SourceTable : r.SourceTableAlias) + "." + r.SourceColumn + " = " + ((string.IsNullOrEmpty(r.DestTableAlias)) ? r.DestTable : r.DestTableAlias) + "." + r.DestColumn);
                                }
                                if (!used_tables.Contains(new AliasTable(r.SourceTable, r.SourceTableAlias))) { used_tables.Add(new AliasTable(r.SourceTable, r.SourceTableAlias)); }
                                if (!used_tables.Contains(new AliasTable(r.DestTable, r.DestTableAlias))) { used_tables.Add(new AliasTable(r.DestTable, r.DestTableAlias)); }

                            }
                        }
                        else
                        {
                            //now check whether the source or the destination table is referenced in the nodes parent
                            var source_count = used_tables.Where(t => t.Table == r.SourceTable && t.Alias == r.SourceTableAlias).Count();
                            var dest_count = used_tables.Where(t => t.Table == r.DestTable && t.Alias == r.DestTableAlias).Count();
                            if (source_count > 0)
                            {
                                // the source table in this relation is in the parent group
                                // no need to write the table as it is already imlied in the source block already written
                                if (r.JoinStyle == JoinStyle.DESTINATION)
                                {
                                    sbDL2.AppendLine("        RIGHT OUTER JOIN " + r.DestTable + ((string.IsNullOrEmpty(r.DestTableAlias)) ? "" : " " + r.DestTableAlias) + " ON " + ((string.IsNullOrEmpty(r.SourceTableAlias)) ? r.SourceTable : r.SourceTableAlias) + "." + r.SourceColumn + " = " + ((string.IsNullOrEmpty(r.DestTableAlias)) ? r.DestTable : r.DestTableAlias) + "." + r.DestColumn);
                                }
                                else if (r.JoinStyle == JoinStyle.SOURCE)
                                {
                                    sbDL2.AppendLine("        LEFT OUTER JOIN " + r.DestTable + ((string.IsNullOrEmpty(r.DestTableAlias)) ? "" : " " + r.DestTableAlias) + " ON " + ((string.IsNullOrEmpty(r.SourceTableAlias)) ? r.SourceTable : r.SourceTableAlias) + "." + r.SourceColumn + " = " + ((string.IsNullOrEmpty(r.DestTableAlias)) ? r.DestTable : r.DestTableAlias) + "." + r.DestColumn);
                                }
                                else if (r.JoinStyle == JoinStyle.OUTER)
                                {
                                    sbDL2.AppendLine("        FULL OUTER JOIN " + r.DestTable + ((string.IsNullOrEmpty(r.DestTableAlias)) ? "" : " " + r.DestTableAlias) + " ON " + ((string.IsNullOrEmpty(r.SourceTableAlias)) ? r.SourceTable : r.SourceTableAlias) + "." + r.SourceColumn + " = " + ((string.IsNullOrEmpty(r.DestTableAlias)) ? r.DestTable : r.DestTableAlias) + "." + r.DestColumn);
                                }
                                if (!used_tables.Contains(new AliasTable(r.DestTable, r.DestTableAlias))) { used_tables.Add(new AliasTable(r.DestTable, r.DestTableAlias)); }
                            }
                            else if (dest_count > 0)
                            {
                                // the destination table in this relation is in the parent group
                                // will need to reverse the source and destination values and modify the join stype
                                if (r.JoinStyle == JoinStyle.DESTINATION)
                                {
                                    sbDL2.AppendLine("        LEFT OUTER JOIN " + r.SourceTable + ((string.IsNullOrEmpty(r.SourceTableAlias)) ? "" : " " + r.SourceTableAlias) + " ON " + ((string.IsNullOrEmpty(r.SourceTableAlias)) ? r.SourceTable : r.SourceTableAlias) + "." + r.SourceColumn + " = " + ((string.IsNullOrEmpty(r.DestTableAlias)) ? r.DestTable : r.DestTableAlias) + "." + r.DestColumn);
                                }
                                else if (r.JoinStyle == JoinStyle.SOURCE)
                                {
                                    sbDL2.AppendLine("        RIGHT OUTER JOIN " + r.SourceTable + ((string.IsNullOrEmpty(r.SourceTableAlias)) ? "" : " " + r.SourceTableAlias) + " ON " + ((string.IsNullOrEmpty(r.SourceTableAlias)) ? r.SourceTable : r.SourceTableAlias) + "." + r.SourceColumn + " = " + ((string.IsNullOrEmpty(r.DestTableAlias)) ? r.DestTable : r.DestTableAlias) + "." + r.DestColumn);
                                }
                                else if (r.JoinStyle == JoinStyle.OUTER)
                                {
                                    sbDL2.AppendLine("        FULL OUTER JOIN " + r.SourceTable + ((string.IsNullOrEmpty(r.SourceTableAlias)) ? "" : " " + r.SourceTableAlias) + " ON " + ((string.IsNullOrEmpty(r.SourceTableAlias)) ? r.SourceTable : r.SourceTableAlias) + "." + r.SourceColumn + " = " + ((string.IsNullOrEmpty(r.DestTableAlias)) ? r.DestTable : r.DestTableAlias) + "." + r.DestColumn);
                                }
                                if (!used_tables.Contains(new AliasTable(r.SourceTable, r.SourceTableAlias))) { used_tables.Add(new AliasTable(r.SourceTable, r.SourceTableAlias)); }
                            }
                        }
                    }
                    joinText.Append(sbDL2.ToString());
                    break;
            }
            if (node.Children != null && node.Children.Count > 0)
            {
                for (int i = 0; i < node.Children.Count; i++)
                {
                    SimpleTreeNode<RelationGroup> child = node.Children[i];
                    JoinBuilder(ref child, ref joinText);
                }
            }
        }
        #endregion
        
        #region command buttons and general operations
        private void cmdTest_Click(object sender, EventArgs e)
        {
            //get selected parameters into List<spParm> array
            List<spParam> _parmList = new List<spParam>();
            foreach (AliasField af in alia)
            {
                spParam _parm = new spParam();
                if (af.Filter!=FilterCriteria.NONE)
                {
                    _parm.ParamName = "@" + af.Column; _parm.ParamType = af.ColumnProperties.VariableTypeCSharp();
                    _parmList.Add(_parm);
                }
                else
                {
                    //do nothing - go to next selected item
                }
            }
            frmSPTest fT = new frmSPTest(rtbComplexSP.Rtf, _parmList, _connectionString, DS.SPGenerator.genCore.spType.SELECT);
            fT.Show();
        }
        private void cmdCopyToClipboard_Click(object sender, EventArgs e)
        {
            CopyToClipboard(this.rtbComplexSP.Text);
        }
        private void cmdPublish_Click(object sender, EventArgs e)
        {
            if (DS.SPGenerator.genCore.SqlHelper.PublishText(this.rtbComplexSP.Text, _connectionString)) { DisplayMsg("Stored Procedure Published successfully", 4); } else { DisplayMsg("Stored Procedure Publish failed...", 4); };
        }
        private void DisplayMsg(string msg, int seconds)
        {
            this.tmrMsg.Enabled = false;
            this.lblMsg.Text = msg;
            this.tmrMsg.Interval = seconds * 1000;
            this.tmrMsg.Enabled = true;

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
        private void tmrMsg_Tick(object sender, EventArgs e)
        {
            lblMsg.Text = string.Empty;
            tmrMsg.Enabled = false;
        }
        private void txtComplexSPName_Leave(object sender, EventArgs e)
        {
            BuildQuery();
        }
        private void chkJoinFromClause_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                BuildQuery();
            }
            catch (Exception ex) { }
        }
        private void splitContainer2_SplitterMoving(object sender, SplitterCancelEventArgs e)
        {
            if (splitContainer2.Panel2.Width < 415) { lblDB.Visible = false; } else { lblDB.Visible = true; }
        }
        #endregion

        private void changeAliasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                UIControls.Tables.TableDisplayPanel tdp = null;
                if (clickedPanel != null) { tdp = clickedPanel; }
                if (tdp != null)
                {
                    string alias = DS.UIControls.Boxes.InputPrompt.Show("Provide or change an Alias for this table '" + tdp.TableName + "'" + System.Environment.NewLine + "or leave blank for no Alias...", "Table Alias", null, FormStartPosition.CenterParent);
                    if (alias != null)
                    {

                        for (int i = table_alia.Count - 1; i >= 0; i--)
                        {
                            if (table_alia[i].Table == tdp.TableName && table_alia[i].Alias == tdp.Alias) { table_alia[i].Alias = alias; break; }
                        }
                        for (int i = alia.Count - 1; i >= 0; i--)
                        {
                            if (alia[i].Table == tdp.TableName && alia[i].TableAlias == tdp.Alias) { alia[i].TableAlias = alias; }
                        }
                        for (int i = dbrelations.Count - 1; i >= 0; i--)
                        {
                            if (dbrelations[i].SourceTable == tdp.TableName && dbrelations[i].SourceTableAlias == tdp.Alias) { dbrelations[i].SourceTableAlias = alias; }
                            if (dbrelations[i].DestTable == tdp.TableName && dbrelations[i].DestTableAlias == tdp.Alias) { dbrelations[i].DestTableAlias = alias; }
                        }
                        for (int i = relations.Count - 1; i >= 0; i--)
                        {
                            if (relations[i].SourceTable == tdp.TableName && relations[i].SourceTableAlias == tdp.Alias) { relations[i].SourceTableAlias = alias; }
                            if (relations[i].DestTable == tdp.TableName && relations[i].DestTableAlias == tdp.Alias) { relations[i].DestTableAlias = alias; }
                        }
                        tdp.Alias = alias;
                        tdp.CaptionText = tdp.TableName + " " + tdp.Alias;
                    }
                    LoadFields();
                }
            }
            catch (Exception ex) { }
        }

        private void removeTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                UIControls.Tables.TableDisplayPanel tdp = null;
                if (clickedPanel != null) { tdp = clickedPanel; }
                if (clickedPanel != null)
                {
                    // now remove the ones that are no longer applicable - i.e. removed using the selector
                    for (int k = table_alia.Count - 1; k >= 0; k--)
                    {
                        //remove the associated TDP
                        for (int i = tables.Count - 1; i >= 0; i--)
                        {
                            if (tables[i].TableName == tdp.TableName && tables[i].Alias == tdp.Alias) { panel1.Controls.Remove(tables[i]); tables.RemoveAt(i); }
                        }
                        // remove all relations referencing this table
                        for (int i = relations.Count - 1; i >= 0; i--)
                        {
                            Relation r = relations[i];
                            if ((r.SourceTable == tdp.TableName && r.SourceTableAlias == tdp.Alias) || (r.DestTable == tdp.TableName && r.DestTableAlias == tdp.Alias))
                            {
                                // this relation references this table - remove the relation
                                relations.RemoveAt(i);
                            }
                        }
                    }
                    for (int i = alia.Count - 1; i >= 0; i--)
                    {
                        if (alia[i].Table == tdp.TableName && alia[i].TableAlias == tdp.Alias) { alia.RemoveAt(i); }
                    }
                    for (int i = table_alia.Count - 1; i >= 0; i--)
                    {
                        if (table_alia[i].Table == tdp.TableName && table_alia[i].Alias == tdp.Alias) { table_alia.RemoveAt(i); }
                    }
                    panel1.Invalidate();
                    CheckDrawingPanelSize();
                    LoadFields();
                }
            }
            catch (Exception ex) { }

        }

        private void showDataTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clickedPanel != null)
            {
                if (clickedPanel.ShowDataTypes == true)
                {
                    // need to start hiding the data type columns
                    foreach (UIControls.Tables.TableDisplaySection tds in clickedPanel.Sections)
                    {
                        foreach (UIControls.Boxes.GlacialList.GLItem item in tds.GlacialList.Items)
                        {
                            item.SubItems.RemoveAt(2);
                        }
                        tds.GlacialList.Columns.Remove(2);
                    }
                    
                }
                else
                {
                    // need to start showing the data type columns
                    foreach (UIControls.Tables.TableDisplaySection tds in clickedPanel.Sections)
                    {
                        DS.UIControls.Boxes.GlacialList.GLColumn glColumn3 = new UIControls.Boxes.GlacialList.GLColumn();
                        glColumn3.ActivatedEmbeddedType = DS.UIControls.Boxes.GlacialList.GLActivatedEmbeddedTypes.None;
                        glColumn3.CheckBoxes = false;
                        glColumn3.ImageIndex = -1;
                        glColumn3.Name = "fieldType";
                        glColumn3.NumericSort = false;
                        glColumn3.Text = "Type";
                        glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
                        glColumn3.Width = 90;
                        tds.GlacialList.Columns.Add(glColumn3);
                        foreach (UIControls.Boxes.GlacialList.GLItem item in tds.GlacialList.Items)
                        {
                            DS.SPGenerator.genCore.ColumnProperties cp = (DS.SPGenerator.genCore.ColumnProperties)item.Tag;
                            if (cp.Type.ToUpper() == "NUMERIC" || cp.Type.ToUpper() == "DECIMAL" || cp.Type.ToUpper() == "DOUBLE")
                            {
                                item.SubItems[2].Text = cp.Type + " (" + cp.Precision.ToString() + "," + cp.Scale.ToString() + ")";
                            }
                            else
                            {
                                item.SubItems[2].Text = cp.Type;
                            }
                            item.SubItems[2].Tag = cp;
                        }
                        
                    }
                }
                clickedPanel.ShowDataTypes = !clickedPanel.ShowDataTypes;
                clickedPanel.Invalidate();
            }
        }

    }
}
