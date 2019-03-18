using System;
using System.Collections.Generic;
using System.Text;

namespace spGenerator
{
    public enum whereCriteriaSQL
    {
        EQUALTO,
        GREATERTHAN,
        GREATERTHAN_or_EQUALTO,
        LESSTHAN,
        LESSTHAN_or_EQUALTO,
        LIKE
    }
    public class whereItem
    {
        public whereItem(string columnName, whereCriteriaSQL criteria)
        {
            _criteria = criteria;
            _colName = columnName;
        }

        private string _colName;

        public string ColName
        {
            get { return _colName; }
            set { _colName = value; }
        }
        private whereCriteriaSQL _criteria;

        public whereCriteriaSQL Criteria
        {
            get { return _criteria; }
            set { _criteria = value; }
        }
        public string SqlCriteriaString
        {
            get 
            {
                string _response = string.Empty;
                switch (_criteria)
                {
                    case whereCriteriaSQL.EQUALTO:
                        _response = "=";
                        break;
                    case whereCriteriaSQL.GREATERTHAN:
                        _response = ">";
                        break;
                    case whereCriteriaSQL.GREATERTHAN_or_EQUALTO:
                        _response = ">=";
                        break;
                    case whereCriteriaSQL.LESSTHAN:
                        _response = "<";
                        break;
                    case whereCriteriaSQL.LESSTHAN_or_EQUALTO:
                        _response = "<=";
                        break;
                    case whereCriteriaSQL.LIKE:
                        _response = "LIKE";
                        break;
                }
                return _response; 
            }
        }

    }
}
