using System;
using System.Collections.Generic;
using System.Text;

namespace ArchiveStation.Bean
{
    public class BoxBean
    {
        public int id { get; set; }
        public string name { get; set; }
        public string rfid { get; set; }
        public string number { get; set; }

        public string floorrfid { get; set; }
        public string floorname { get; set; }

        public int status { get; set; }

        public string statusname { get; set; }

        public int count { get; set; }
    }
    public class BoxResult : BaseBean
    {
        public BoxBean Data { get; set; }
    }

    public class BoxPageResult : BaseBean
    {
        public Page<BoxBean> Data { get; set; }
    }
}
