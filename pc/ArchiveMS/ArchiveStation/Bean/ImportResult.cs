using System;
using System.Collections.Generic;
using System.Text;

namespace ArchiveStation.Bean
{
    public class ImportResult
    {

        public int TotalCount { get; set; }
        public int AddCount { get; set; }
        public int UpdateCount { get; set; }
        public int FailureCount { get; set; }
        public List<ExcelErrorLine> ErrorList { get; set; }

        public class ExcelErrorLine
        {
            public ExcelErrorLine(string line, string msg) { Line = line; Error = msg; }
            public string Line { get; set; }
            public string Error { get; set; }

        }
    }
}
