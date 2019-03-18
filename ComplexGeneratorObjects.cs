using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DS.SPGenerator
{
    public class Relation : IEquatable<Relation>, ICloneable
    {
        public string SourceTable { get; set; }
        public string DestTable { get; set; }
        public int SourceIndex { get; set; }
        public int DestIndex { get; set; }
        public string SourceTableAlias { get; set; }
        public string DestTableAlias { get; set; }
        public List<PointPair> DrawingPoints { get; set; }
        public List<Point> Points { get; set; }
        public bool UserDefined { get; set; }
        public bool DBDefined { get; set; }
        public string DestColumn { get; set; }
        public string SourceColumn { get; set; }
        public JoinStyle JoinStyle { get; set; }
        public ConnectorSide SourceSide { get; set; }
        public ConnectorSide DestSide { get; set; }


        private void initialize()
        {
            SourceTable = string.Empty;
            DestTable = string.Empty;
            SourceIndex = -1;
            DestIndex = -1;
            SourceTableAlias = string.Empty;
            DestTableAlias = string.Empty;
            DrawingPoints = new List<PointPair>();
            Points = new List<Point>();
            UserDefined = false;
            DBDefined = false;
            JoinStyle = JoinStyle.INNER;
        }
        public Relation() { initialize(); }
        public Relation(string sourceTable, string sourceTableAlias, int sourceInex, string destTable, string destTableAlias, int destIndex)
        {
            initialize();
            SourceTable = sourceTable;
            SourceTableAlias = sourceTableAlias;
            SourceIndex = sourceInex;
            DestTable = destTable;
            DestTableAlias = destTableAlias;
            DestIndex = destIndex;
        }
        public Relation(string sourceTable, string sourceTableAlias, int sourceInex, string destTable, string destTableAlias, int destIndex, bool userdefined, bool dbdefined)
        {
            initialize();
            SourceTable = sourceTable;
            SourceTableAlias = sourceTableAlias;
            SourceIndex = sourceInex;
            DestTable = destTable;
            DestTableAlias = destTableAlias;
            DestIndex = destIndex;
            DBDefined = dbdefined;
            UserDefined = userdefined;
        }
        public Relation(string sourceTable, string sourceTableAlias, int sourceInex, string sourceColumn, string destTable, string destTableAlias, int destIndex, string destColumn, bool userdefined, bool dbdefined)
        {
            initialize();
            SourceTable = sourceTable;
            SourceTableAlias = sourceTableAlias;
            SourceIndex = sourceInex;
            DestTable = destTable;
            DestTableAlias = destTableAlias;
            DestIndex = destIndex;
            DBDefined = dbdefined;
            UserDefined = userdefined;
            DestColumn = destColumn;
            SourceColumn = sourceColumn;
        }
        public override string ToString()
        {
            return SourceTable + "." + SourceColumn + "[" + SourceIndex.ToString() + "] => " + DestTable + "." + DestColumn + "[" + DestIndex.ToString() + "]";
        }
        public bool Equals(Relation other)
        {
            if (this.DestTable == other.DestTable && this.DestColumn == other.DestColumn && this.DestTableAlias == other.DestTableAlias && this.DestIndex == other.DestIndex &&
                this.SourceTable == other.SourceTable && this.SourceColumn == other.SourceColumn && this.SourceTableAlias == other.SourceTableAlias && this.SourceIndex == other.SourceIndex)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public object Clone()
        {
            Relation r = new Relation();
            r.SourceTable = this.SourceTable;
            r.DestTable = this.DestTable;
            r.SourceIndex = this.SourceIndex;
            r.DestIndex = this.DestIndex;
            r.SourceTableAlias = this.SourceTableAlias;
            r.DestTableAlias = this.DestTableAlias;
            r.SourceColumn = this.SourceColumn;
            r.DestColumn = this.DestColumn;
            r.DrawingPoints = new List<PointPair>();
            if (this.DrawingPoints != null)
            {
                foreach (PointPair pp in this.DrawingPoints)
                {
                    r.DrawingPoints.Add(new PointPair(new Point(pp.StartingPoint.X, pp.StartingPoint.Y), new Point(pp.EndingPoint.X, pp.EndingPoint.Y)));
                }
            }
            r.Points = new List<Point>();
            if (this.Points != null)
            {
                foreach (Point p in this.Points)
                {
                    r.Points.Add(new Point(p.X, p.Y));
                }
            }
            r.UserDefined = this.UserDefined;
            r.DBDefined = this.DBDefined;
            r.JoinStyle = this.JoinStyle;
            return r;
        }
    }
    public class RelationGroup : ICloneable
    {
        public int ID { get; set; }
        public List<Relation> Members { get; set; }
        public List<AliasTable> Tables { get; set; }
        public int Count
        {
            get
            {
                if (Members == null) { Members = new List<Relation>(); }
                return Members.Count;
            }
        }
        public JoinStyle JoinType { get; set; }

        private void initialize()
        {
            ID = -1;
            Members = new List<Relation>();
            Tables = new List<AliasTable>();
            JoinType = JoinStyle.INNER;
        }
        public RelationGroup() { initialize(); }
        public RelationGroup(int id, List<Relation> members, List<AliasTable> tables, JoinStyle joinType)
        {
            initialize();
            ID = id;
            Members = members;
            Tables = tables;
            JoinType = joinType;
        }
        public object Clone()
        {
            RelationGroup rg = new RelationGroup();
            List<Relation> relations = new List<Relation>();
            List<AliasTable> tables = new List<AliasTable>();
            foreach (Relation r in this.Members) { relations.Add((Relation)r.Clone()); }
            foreach (AliasTable a in this.Tables) { tables.Add((AliasTable)a.Clone()); }
            rg.ID = this.ID;
            rg.JoinType = this.JoinType;
            return rg;
        }
    }
    public class PointPair : IEquatable<PointPair>
    {
        public System.Drawing.Point StartingPoint { get; set; }
        public System.Drawing.Point EndingPoint { get; set; }
        private void initialize()
        {
            StartingPoint = new System.Drawing.Point(0, 0);
            EndingPoint = new System.Drawing.Point(0, 0);
        }
        public PointPair() { initialize(); }
        public PointPair(System.Drawing.Point start, System.Drawing.Point end)
        {
            initialize();
            StartingPoint = start;
            EndingPoint = end;
        }
        public override string ToString()
        {
            return "[START(" + StartingPoint.X.ToString() + "," + StartingPoint.Y.ToString() + ") => END(" + EndingPoint.X.ToString() + "," + EndingPoint.Y.ToString() + ")]";
        }
        public bool Equals(PointPair other)
        {
            if (this.StartingPoint.X == other.StartingPoint.X && this.StartingPoint.Y == other.StartingPoint.Y &&
                this.EndingPoint.X == other.EndingPoint.X && this.EndingPoint.Y == other.EndingPoint.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class AliasField : IEquatable<AliasField>
    {
        public string Table { get; set; }
        public string TableAlias { get; set; }
        public string Column { get; set; }
        public string Alias { get; set; }
        public FilterCriteria Filter { get; set; }
        public bool Select { get; set; }
        public string DataType { get; set; }
        public SortDirection SortDirection { get; set; }
        public int SortOrder { get; set; }
        public DS.SPGenerator.genCore.ColumnProperties ColumnProperties { get; set; }

        private void initialize()
        {
            Table = string.Empty;
            TableAlias = string.Empty;
            Column = string.Empty;
            Alias = string.Empty;
            Filter = FilterCriteria.NONE;
            Select = false;
            DataType = string.Empty;
            SortDirection = SPGenerator.SortDirection.NONE;
            SortOrder = 0;
            ColumnProperties = new genCore.ColumnProperties();
        }
        public AliasField()
        {
            initialize();
        }
        public AliasField(string table, string tableAlias, string column, string alias)
        {
            initialize();
            Table = table;
            TableAlias = tableAlias;
            Column = column;
            Alias = alias;
        }
        public bool Equals(AliasField other)
        {
            if (this.Table == other.Table && this.Alias == other.Alias && this.TableAlias == other.TableAlias && this.Column == other.Column)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class AliasTable : IEquatable<AliasTable>, ICloneable
    {
        public string Table { get; set; }
        public string Alias { get; set; }

        private void initialize()
        {
            Table = string.Empty;
            Alias = string.Empty;
        }
        public AliasTable()
        {
            initialize();
        }
        public AliasTable(string table, string alias)
        {
            initialize();
            Table = table;
            Alias = alias;
        }
        public override string ToString()
        {
            return Table + ((!string.IsNullOrEmpty(Alias)) ? " (" + Alias + ")" : "");
        }
        public bool Equals(AliasTable other)
        {
            if (this.Table == other.Table && this.Alias == other.Alias)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public object Clone()
        {
            AliasTable a = new AliasTable();
            a.Table = this.Table;
            a.Alias = this.Alias;
            return a;
        }
    }
    public enum JoinStyle
    {
        UNKNOWN,
        INNER,
        SOURCE,
        DESTINATION,
        OUTER
    }
    public enum ConnectorSide
    {
        RIGHT,
        LEFT

    }
    public enum FilterCriteria
    {
        EQUALS,
        GREATERTHAN,
        GREATERTHANOREQUALTO,
        LESSTHAN,
        LESSTHANOREQUALTO,
        LIKE,
        NONE
    }
    public class FilterPair
    {
        public FilterCriteria Criteria { get; set; }
        public string DisplayString { get; set; }
        private void initialize() { Criteria = FilterCriteria.NONE; DisplayString = ""; }
        public FilterPair() { initialize(); }
        public FilterPair(FilterCriteria criteria, string display)
        {
            initialize();
            Criteria = criteria;
            DisplayString = display;
        }
    }
    public enum SortDirection
    {
        NONE,
        ASC,
        DESC
    }
    public class SortPair
    {
        public SortDirection SortOrder { get; set; }
        public string DisplayString { get; set; }
        private void initialize() { SortOrder = SortDirection.NONE; DisplayString = ""; }
        public SortPair() { initialize(); }
        public SortPair(SortDirection sort, string display)
        {
            initialize();
            SortOrder = sort;
            DisplayString = display;
        }
    }
    public class SortOrder : IEquatable<SortOrder>
    {
        private void initialize() { Order = 0; }
        public SortOrder() { initialize(); }
        public SortOrder(int order)
        {
            initialize();
            Order = order;
        }
        public int Order { get; set; }
        public string Display
        {
            get 
            {
                string r = string.Empty;
                if (Order > 0) { r = Order.ToString(); }
                return r;
            }
            set { }
            
        }
        public bool Equals(SortOrder other)
        {
            if (this.Order == other.Order)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
