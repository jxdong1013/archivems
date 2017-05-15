using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArchiveTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //ContractMvcWeb.Controllers.LabelRestfullController control = new ContractMvcWeb.Controllers.LabelRestfullController();
            //System.Web.    control.GetInventoryLabelInfo("4534534");
            ContractMvcWeb.Models.LabelContext con = new ContractMvcWeb.Models.LabelContext();
            ContractMvcWeb.Models.Beans.InventoryLabelInfo model =  con.GetInventoryLabelInfo("4534534");
        }
    }
}
