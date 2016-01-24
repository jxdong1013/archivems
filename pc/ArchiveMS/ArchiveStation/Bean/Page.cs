using System;
using System.Collections.Generic;
using System.Text;

namespace ArchiveStation.Bean
{
    public class Page<T> : PageBase
    {
        //public int PageIdx { get; set; }
        //public int PageSize { get; set; }
        //public int TotalRecords { get; set; }
        //public int TotalPages { get; set; }
        public string Key { get; set; }
        public List<T> Data { get; set; }
    }

    public class PageBase
    {
        public int PageIdx { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
    }
}
