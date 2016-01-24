using System;
using System.Collections.Generic;
using System.Text;

namespace ArchiveStation.Bean
{
    public class FloorBean
    {
        public int id { get; set; }
        public string name { get; set; }
        public string rfid { get; set; }
        public string number { get; set; }

    }

    public class FloorResult:BaseBean
    {
        public FloorBean Data { get; set; }
    }

    public class FloorPageResult : BaseBean
    {
        public Page<FloorBean> Data { get; set; }
    }
}
