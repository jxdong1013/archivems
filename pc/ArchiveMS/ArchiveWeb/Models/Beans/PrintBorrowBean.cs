using System;
using System.Collections.Generic;
using System.Text;

namespace ContractMvcWeb.Models.Beans
{
    public class PrintBorrowBean
    {
        public Borrower Borrower { get; set; }

        public List<Archive> ArchiveList { get; set; }
    }
}
