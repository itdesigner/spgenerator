namespace spGenerator.genCore
{
    using DS.Tst;
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class SyntaxHighlighter
    {
        static SyntaxHighlighter()
        {
            SyntaxHighlighter.dic = null;
            SyntaxHighlighter.re0 = new Regex(@"</font>(?<sp>\s*)<font", RegexOptions.Singleline);
            SyntaxHighlighter.re1 = new Regex(@"</font>\r\n<font", RegexOptions.Singleline);
        }
        public SyntaxHighlighter()
        {
            this.EscapeBlankSpaces = false;
            if (SyntaxHighlighter.dic == null)
            {
                SyntaxHighlighter.dic = new TstDictionary();
                string[] textArray1 = "AFTER|NOCOUNT|RETURNS|APPLICATION|FETCH|OPTCCVAL|CALL|FETCHBUFFER|OPTION|CLOSE|FOUND|QUERYTIME|CONCURRENCY|GET|READONLY|CONNECT|HOST|SCROLLOPTION|CONNECTION|IMMEDIATE|SECTION|CUR_BROWSE|INCLUDE|SQLCA|CUR_STANDARD|INDICATOR|SQLDA|CURRENT|KEYSET|SQLERROR|LOCKCC|SQLWARNING|CURSORTYPE|LOGINTIME|USER|DESCRIBE|MIXED|USING|DESCRIPTOR|NOT|WHENEVER|DISCONNECT|WORK|DYNAMIC|OPEN|FORWARD|OPTCC|ADD|EXCEPT|PERCENT|ALL|EXEC|PLAN|ALTER|EXECUTE|PRECISION|AND|EXISTS|PRIMARY|ANY|EXIT|PRINT|AS|PROC|ASC|FILE|XML|RAW|AUTO|PROCEDURE|AUTHORIZATION|FILLFACTOR|PUBLIC|BACKUP|FOR|RAISERROR|BEGIN|FOREIGN|READ|BETWEEN|FREETEXT|READTEXT|BREAK|FREETEXTTABLE|RECONFIGURE|BROWSE|FROM|REFERENCES|BULK|FULL|REPLICATION|BY|FUNCTION|RESTORE|CASCADE|GOTO|RESTRICT|CASE|GRANT|RETURN|CHECK|GROUP|REVOKE|CHECKPOINT|HAVING|HOLDLOCK|ROLLBACK|CLUSTERED|IDENTITY|ROWCOUNT|COALESCE|IDENTITY_INSERT|ROWGUIDCOL|COLLATE|IDENTITYCOL|RULE|COLUMN|IF|SAVE|COMMIT|IN|PARAMETERS|PIVOT|SCHEMA|COMPUTE|INDEX|SELECT|CONSTRAINT|INNER|CONTAINS|INSERT|SET|CONTAINSTABLE|INTERSECT|SETUSER|CONTINUE|INTO|SHUTDOWN|IS|SOME|CREATE|JOIN|STATISTICS|CROSS|KEY|KILL|TABLE|CURRENT_DATE|TEXTSIZE|CURRENT_TIME|LIKE|THEN|CURRENT_TIMESTAMP|LINENO|TO|LOAD|TOP|CURSOR|NATIONAL|TRAN|DATABASE|NOCHECK|TRANSACTION|DBCC|NONCLUSTERED|TRIGGER|DEALLOCATE|TRUNCATE|DECLARE|NULL|TSEQUAL|DEFAULT|NULLIF|UNION|DELETE|OF|UNIQUE|DENY|OFF|UPDATE|DESC|OFFSETS|UPDATETEXT|DISK|ON|USE|DISTINCT|DISTINCTROW|DISTRIBUTED|OPENDATASOURCE|VALUES|DOUBLE|OPENQUERY|VARYING|DROP|OPENROWSET|VIEW|DUMMY|OPENXML|WAITFOR|DUMP|WHEN|ELSE|OR|WHERE|END|ORDER|WHILE|ERRLVL|OUTER|WITH|ESCAPE|OVER|WRITETEXT|INSTEAD|CATCH|TRY".Split(new char[] { '|' });
                for (int num1 = 0; num1 < textArray1.Length; num1++)
                {
                    SyntaxHighlighter.dic.Add(textArray1[num1], "keyword");
                }
                string[] textArray2 = "CURRENT_USER|SESSION_USER|SYSTEM_USER|USER_NAME|USER_ID|PARSENAME|OBJECT_ID|OBJECT_NAME|AVG|MAX|BINARY_CHECKSUM|MIN|CHECKSUM|SUM|CHECKSUM_AGG|STDEV|COUNT|STDEVP|COUNT_BIG|VAR|GROUPING|VARP|ISNULL|ISDATE|ISNUMERIC|DATEADD|DATEDIFF|DATENAME|DATEPART|DAY|NEWID|GETDATE|GETUTCDATE|MONTH|YEAR|ABS|DEGREES|RAND|ACOS|EXP|ROUND|ASIN|FLOOR|SIGN|ATAN|LOG|SIN|ATN2|LOG10|SQUARE|CEILING|PI|SQRT|COS|POWER|TAN|COT|RADIANS|ASCII|SOUNDEX|PATINDEX|SPACE|CHARINDEX|REPLACE|STR|DIFFERENCE|QUOTENAME|STUFF|LEFTREPLICATE|SUBSTRING|LEN|REVERSE|UNICODE|LOWER|RIGHT|UPPER|@IDENTITY|@@IDENTITY|LTRIM|RTRIM|CONVERT".Split(new char[] { '|' });
                for (int num2 = 0; num2 < textArray2.Length; num2++)
                {
                    SyntaxHighlighter.dic.Add(textArray2[num2], "function");
                }
                string[] textArray3 = "BIGINT|BINARY|BIT|CHAR|DATETIME|DECIMAL|FLOAT|IMAGE|MONEY|NCHAR|NTEXT|NUMERIC|NVARCHAR|REAL|SMALLDATETIME|SMALLINT|SMALLMONEY|SQL_VARIANT|SYSNAME|TEXT|TIMESTAMP|TINYINT|UNIQUEIDENTIFIER|VARBINARY|VARCHAR".Split(new char[] { '|' });
                for (int num3 = 0; num3 < textArray3.Length; num3++)
                {
                    SyntaxHighlighter.dic.Add(textArray3[num3], "datatype");
                }
            }
        }
        public string Highlight(string originalText)
        {
            string text1 = originalText + " ";
            StringBuilder builder1 = new StringBuilder(@"{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fmodern\fprq1\fcharset0 Courier New;}{\f1\fswiss\fcharset0 Arial;}}{\colortbl ;\red0\green0\blue255;\red0\green0\blue0;\red255\green0\blue255;\red0\green128\blue0;\red255\green0\blue0;}{\*\generator Msftedit 5.41.15.1507;}\viewkind4\uc1\pard\sb100\sa100\f0\fs16");
            for (int num1 = 0; num1 < originalText.Length; num1++)
            {
                string text4;
                //green code comments
                if (text1[num1] == '/')
                {
                    if (text1[num1 + 1] == '*')
                    {
                        int num2 = num1 + 2;
                        while (num2 < originalText.Length)
                        {
                            if ((text1[num2] == '*') && (text1[num2 + 1] == '/'))
                            {
                                break;
                            }
                            num2++;
                        }
                        if (num2 >= originalText.Length)
                        {
                            num2 = originalText.Length - 3;
                        }
                        num2 += 2;
                        builder1.Append(@"\cf4 " + text1.Substring(num1, (num2 + 1) - num1) + @"\cf0");
                        num1 = num2 + 1;
                    }
                    else if (text1[num1+1] == '/')
                    {
                        int num3 = num1;
                        while ((num1 < (text1.Length - 1)) && (text1[num1] != '\r'))
                        {
                            num1++;
                        }
                        builder1.Append(string.Concat(new object[] { @"\cf4 ", text1.Substring(num3, num1 - num3), @"\cf0", text1[num1], System.Environment.NewLine }));
                        goto Label_04B1;

                    }
                    goto Label_04B1;
                }
                //green sqlcomments
                if (((text1[num1] == '-') && (text1[num1 + 1] == '-')) )
                {
                    int num3 = num1;
                    while ((num1 < (text1.Length - 1)) && (text1[num1] != '\r') && (text1[num1] != '\n'))
                    {
                        num1++;
                    }
                    builder1.Append(string.Concat(new object[] { @"\cf4 ", text1.Substring(num3, num1 - num3), @"\cf0", text1[num1] }));
                    goto Label_04B1;
                }
                //red - single quotes
                if (text1[num1] == '\'')
                {
                    int num4 = num1;
                    num1++;
                    while (num1 < text1.Length)
                    {
                        if ((text1[num1] == '\'') && (text1[num1 + 1] == '\''))
                        {
                            num1 += 2;
                        }
                        if ((text1[num1] == '\'') && (text1[num1 + 1] != '\''))
                        {
                            break;
                        }
                        num1++;
                    }
                    num1++;
                    if (num1 > text1.Length)
                    {
                        num1 = text1.Length - 1;
                    }
                    builder1.Append(string.Concat(new object[] { @"\cf5 ", text1.Substring(num4, num1 - num4), @"\cf0", text1[num1] }));
                    goto Label_04B1;
                }
                //red - double quotes
                if (text1[num1] == '\"')
                {
                    int num4 = num1;
                    num1++;
                    while (num1 < text1.Length)
                    {
                        if ((text1[num1] == '\"') && (text1[num1 + 1] == '\"'))
                        {
                            num1 += 2;
                        }
                        if ((text1[num1] == '\"') && (text1[num1 + 1] != '\"'))
                        {
                            break;
                        }
                        num1++;
                    }
                    num1++;
                    if (num1 > text1.Length)
                    {
                        num1 = text1.Length - 1;
                    }
                    builder1.Append(string.Concat(new object[] { @"\cf5 ", text1.Substring(num4, num1 - num4), @"\cf0", text1[num1] }));
                    goto Label_04B1;
                }
                //red NTEXT
                if ((text1[num1] == 'N') && (text1[num1 + 1] == '\''))
                {
                    int num5 = num1;
                    num1++;
                    num1++;
                    while (num1 < text1.Length)
                    {
                        if ((text1[num1] == '\'') && (text1[num1 + 1] != '\''))
                        {
                            break;
                        }
                        num1++;
                    }
                    num1++;
                    builder1.Append(string.Concat(new object[] { @"\cf5 ", text1.Substring(num5, num1 - num5), @"\cf0", text1[num1] }));
                    goto Label_04B1;
                }
                //black
                if (text1[num1] == '"')
                {
                    int num6 = num1;
                    num1++;
                    while (num1 < text1.Length)
                    {
                        if ((text1[num1] == '"') && (text1[num1 + 1] == '"'))
                        {
                            num1 += 2;
                        }
                        if ((text1[num1] == '"') && (text1[num1 + 1] != '"'))
                        {
                            break;
                        }
                        num1++;
                    }
                    num1++;
                    builder1.Append(string.Concat(new object[] { @"\cf0 ", text1.Substring(num6, num1 - num6), @"\cf0", text1[num1] }));
                    goto Label_04B1;
                }
                if (text1[num1] == '[')
                {
                    while (text1[num1] != ']')
                    {
                        builder1.Append(text1[num1]);
                        num1++;
                    }
                    builder1.Append(text1[num1]);
                    goto Label_04B1;
                }
                if (!char.IsLetterOrDigit(text1[num1]))
                {
                    goto Label_04A3;
                }
                int num7 = num1;
                while (char.IsLetterOrDigit(text1[num1]))
                {
                    num1++;
                }
                string text2 = text1.Substring(num7, num1 - num7);
                if (!SyntaxHighlighter.dic.ContainsKey(text2.ToUpper()))
                {
                    goto Label_0494;
                }
                if ((text4 = (string) SyntaxHighlighter.dic[text2.ToUpper()]) != null)
                {
                    text4 = string.IsInterned(text4);
                    if ((text4 != "keyword") && (text4 != "datatype"))
                    {
                        if (text4 == "function")
                        {
                            goto Label_046B;
                        }
                        goto Label_0490;
                    }
                    //blue
                    builder1.Append(@"\cf1 " + text2);
                    if (text1[num1] == ' ')
                    {
                        builder1.Append(text1[num1] + @"\cf0");
                    }
                    else
                    {
                        builder1.Append(@"\cf0" + text1[num1]);
                    }
                }
                goto Label_04B1;
            Label_046B:
                //pink
                builder1.Append(@"\cf3 " + text2);
                builder1.Append(@"\cf0");
                num1--;
                goto Label_04B1;
            Label_0490:;
                goto Label_04B1;
            Label_0494:
                num1--;
                bool _isNumeric = false; int _num = 0;
                try { _num = System.Convert.ToInt32(text2); _isNumeric = true; } catch { _isNumeric=false;}
                if(_isNumeric) { builder1.Append(" " + text2);} else { builder1.Append(text2); }
                goto Label_04B1;
            Label_04A3:
                builder1.Append(text1[num1]);
            Label_04B1:;
            }
            if (this.EscapeBlankSpaces)
            {
                text1 = SyntaxHighlighter.re0.Replace(builder1.ToString(), "${sp}</font><font");
                return SyntaxHighlighter.re1.Replace(text1, "\r\n</font><font");
            }
            builder1.Replace(Environment.NewLine, @"\line");
            return builder1.ToString() + @" \cf0\par\pard\f1\fs20\par}";
        }
        private static TstDictionary dic;
        public bool EscapeBlankSpaces;
        private const string keyword_functions = "CURRENT_USER|SESSION_USER|SYSTEM_USER|USER_NAME|USER_ID|PARSENAME|OBJECT_ID|OBJECT_NAME|AVG|MAX|BINARY_CHECKSUM|MIN|CHECKSUM|SUM|CHECKSUM_AGG|STDEV|COUNT|STDEVP|COUNT_BIG|VAR|GROUPING|VARP|ISNULL|ISDATE|ISNUMERIC|DATEADD|DATEDIFF|DATENAME|DATEPART|DAY|GETDATE|GETUTCDATE|MONTH|YEAR|ABS|DEGREES|RAND|ACOS|EXP|ROUND|ASIN|FLOOR|SIGN|ATAN|LOG|SIN|ATN2|LOG10|SQUARE|CEILING|PI|SQRT|COS|POWER|TAN|COT|RADIANS|ASCII|SOUNDEX|PATINDEX|SPACE|CHARINDEX|REPLACE|STR|DIFFERENCE|QUOTENAME|STUFF|LEFTREPLICATE|SUBSTRING|LEN|REVERSE|UNICODE|LOWER|RIGHT|UPPER|LTRIM|RTRIM|CONVERT";
        private const string keywords = "AFTER|NOCOUNT|RETURNS|APPLICATION|FETCH|OPTCCVAL|CALL|FETCHBUFFER|OPTION|CLOSE|FOUND|QUERYTIME|CONCURRENCY|GET|READONLY|CONNECT|HOST|SCROLLOPTION|CONNECTION|IMMEDIATE|SECTION|CUR_BROWSE|INCLUDE|SQLCA|CUR_STANDARD|INDICATOR|SQLDA|CURRENT|KEYSET|SQLERROR|LOCKCC|SQLWARNING|CURSORTYPE|LOGINTIME|USER|DESCRIBE|MIXED|USING|DESCRIPTOR|NOT|WHENEVER|DISCONNECT|WORK|DYNAMIC|OPEN|FORWARD|OPTCC|ADD|EXCEPT|PERCENT|ALL|EXEC|PLAN|ALTER|EXECUTE|PRECISION|AND|EXISTS|PRIMARY|ANY|EXIT|PRINT|AS|PROC|ASC|FILE|XML|RAW|AUTO|PROCEDURE|AUTHORIZATION|FILLFACTOR|PUBLIC|BACKUP|FOR|RAISERROR|BEGIN|FOREIGN|READ|BETWEEN|FREETEXT|READTEXT|BREAK|FREETEXTTABLE|RECONFIGURE|BROWSE|FROM|REFERENCES|BULK|FULL|REPLICATION|BY|FUNCTION|RESTORE|CASCADE|GOTO|RESTRICT|CASE|GRANT|RETURN|CHECK|GROUP|REVOKE|CHECKPOINT|HAVING|HOLDLOCK|ROLLBACK|CLUSTERED|IDENTITY|ROWCOUNT|COALESCE|IDENTITY_INSERT|ROWGUIDCOL|COLLATE|IDENTITYCOL|RULE|COLUMN|IF|SAVE|COMMIT|IN|SCHEMA|COMPUTE|INDEX|SELECT|CONSTRAINT|INNER|CONTAINS|INSERT|SET|CONTAINSTABLE|INTERSECT|SETUSER|CONTINUE|INTO|SHUTDOWN|IS|SOME|CREATE|JOIN|STATISTICS|CROSS|KEY|KILL|TABLE|CURRENT_DATE|TEXTSIZE|CURRENT_TIME|LIKE|THEN|CURRENT_TIMESTAMP|LINENO|TO|LOAD|TOP|CURSOR|NATIONAL|TRAN|DATABASE|NOCHECK|TRANSACTION|DBCC|NONCLUSTERED|TRIGGER|DEALLOCATE|TRUNCATE|DECLARE|NULL|TSEQUAL|DEFAULT|NULLIF|UNION|DELETE|OF|UNIQUE|DENY|OFF|UPDATE|DESC|OFFSETS|UPDATETEXT|DISK|ON|USE|DISTINCT|DISTINCTROW|DISTRIBUTED|OPENDATASOURCE|VALUES|DOUBLE|OPENQUERY|VARYING|DROP|OPENROWSET|VIEW|DUMMY|OPENXML|WAITFOR|DUMP|WHEN|ELSE|OR|WHERE|END|ORDER|WHILE|ERRLVL|OUTER|WITH|ESCAPE|OVER|WRITETEXT|INSTEAD|CATCH|TRY";
        private const string keywords_datatypes = "BIGINT|BINARY|BIT|CHAR|DATETIME|DECIMAL|FLOAT|IMAGE|INT|MONEY|NCHAR|NTEXT|NUMERIC|NVARCHAR|REAL|SMALLDATETIME|SMALLINT|SMALLMONEY|SQL_VARIANT|SYSNAME|TEXT|TIMESTAMP|TINYINT|UNIQUEIDENTIFIER|VARBINARY|VARCHAR";
        private static Regex re0;
        private static Regex re1;
    }
}

