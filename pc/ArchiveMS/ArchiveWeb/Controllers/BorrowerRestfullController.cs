using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContractMvcWeb.Attributes;
using ContractMvcWeb.Models;
using ContractMvcWeb.Models.Beans;

namespace ContractMvcWeb.Controllers
{
    [AuthorizeRestful]
    public class BorrowerRestfullController : Controller
    {

        public JsonResult QueryBorrowerByPage(string name , string idcard , string department , int pageidx , int pagesize=50){
            BorrowerContext db = new BorrowerContext();
    
            Page<Borrower> list = db.QueryByPage( name , idcard , department , pageidx, pagesize);

            Models.Result result = new Result((int)ResultCodeEnum.Success, "", list);

            JsonResult jsonresult = new JsonResult();
            jsonresult.Data = result;
            jsonresult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return jsonresult;
        }
     

        
    }
}
