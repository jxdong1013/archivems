using System;
using System.Collections.Generic;
using System.Text;

namespace ArchiveStation.Bean
{
    public class PrintBorrowBean
    {
        public BorrowerBean Borrower { get; set; }

        public List<ArchiveBean> ArchiveList { get; set; }
    }
}
