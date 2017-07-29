using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
            //ContractMvcWeb.Models.Beans.InventoryLabelInfo model =  con.GetInventoryLabelInfo("4534534");

           //List<ContractMvcWeb.Models.Beans.InventoryBoxLabel> list = con.GetInventoryBoxListOfFloorRfid("11111");

            ContractMvcWeb.Models.ArchiveContext c = new ContractMvcWeb.Models.ArchiveContext();
            ContractMvcWeb.Models.Beans.Archive query =new ContractMvcWeb.Models.Beans.Archive();
            query.manager = "";
            query.title = "";
            query.number = "";
            query.floorrfid = "";
            query.boxrfid = "";
            query.shownoposition = false;
           
            ContractMvcWeb.Models.Beans.Page<ContractMvcWeb.Models.Beans.Archive> list =    c.QueryByPage(query, 1, 20);


        }
    }
}
