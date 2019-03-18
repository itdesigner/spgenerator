using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS.SPGenerator
{
    class TestParameters
    {
        public int CallCount { get; set; }
        public bool ReuseConnection { get; set; }
        public string ConnectionString { get; set; }
        public bool ParallelExecution { get; set; }
        public string SpName { get; set; }
        public string QueryType { get; set; }
        public List<System.Data.SqlClient.SqlParameter> SpParameters { get; set; }
        public int CallDelay { get; set; }
    }
    public class TestResult
    {
        public List<PerfPair> Results { get; set; }
        public decimal AvgTime { get; set; }
        public decimal TotalTime { get; set; }
    }
    public class PerfPair
    {
        public PerfPair() { Call = 0; Time = 0; }
        public PerfPair(int callNumber, decimal callTime) { Call = callNumber; Time = callTime; }
        public int Call { get; set; }
        public decimal Time { get; set; }
    }
}
