using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using ContractMvcWeb.Attributes;
using ContractMvcWeb.Models;

namespace ContractMvcWeb.Controllers
{
    [AuthorizeRestful]
    public class ArchiveRestfullController : Controller
    {

        [HttpPost]
        public JsonResult ImportArchive(List<Models.Beans.Archive> list, int startLine = 0 , String operateman="")
        {
            ContractMvcWeb.Models.ArchiveContext db = new Models.ArchiveContext();
            Object data = db.BatchAddArchives( list, startLine , operateman );

            ContractMvcWeb.Models.Result result = new ContractMvcWeb.Models.Result((int)  ResultCodeEnum.Success ,"", data );
            
            JsonResult json = new JsonResult();
            json.Data = result;
            //json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return json; 
        }

        //public ActionResult EditArchive( int aid , int pageidx )
        //{                   
        //    ContractMvcWeb.Models.ArchiveDBContext db = new Models.ArchiveDBContext();
        //    ContractMvcWeb.Models.archive ar = db.GetArchiveById(aid);
        //    ar.pageidx = pageidx;
        //    return View("addarchive" , ar);
        //}

        //public ActionResult DeleteArchive(int id)
        //{
        //    ContractMvcWeb.Models.ArchiveDBContext db = new Models.ArchiveDBContext();
        //    db.DeleteArchive(id);
        //    return new RedirectResult("~/archive/archivelist");
        //}

        [HttpPost]
        public JsonResult AddArchive(ContractMvcWeb.Models.Beans.Archive model )
        {
            ContractMvcWeb.Models.ArchiveContext db = new Models.ArchiveContext();
            Result result = null;
            if (model.id > 0)
            {
                bool isok =  db.EditArchive(model);
                result= new Result( isok ? (int) ResultCodeEnum.Success : (int)ResultCodeEnum.Error, "",null);

            }
            else
            {
                bool isok =  db.AddArchive(model);
                result= new Result( isok ? (int) ResultCodeEnum.Success : (int)ResultCodeEnum.Error, "",null);
            }

            JsonResult json = new JsonResult();
            json.Data = result;

            return json;
        }

        [HttpGet]
        public JsonResult GetArchiveList( String manager , String title , String number , String floorrfid , string boxrfid , bool shownoposition = false ,  int pageidx = 0, int pagesize = 20 )
        {
            ContractMvcWeb.Models.ArchiveContext db = new Models.ArchiveContext();
            ContractMvcWeb.Models.Beans.Archive query = new Models.Beans.Archive();
            query.manager = manager;
            query.title = title;
            query.number = number;
            query.floorrfid = floorrfid;
            query.boxrfid = boxrfid;
            query.shownoposition = shownoposition;

            Models.Beans.Page<ContractMvcWeb.Models.Beans.Archive> list = db.QueryByPage(query, pageidx, pagesize);

            Models.Result result = new Result((int)ResultCodeEnum.Success, "", list);

            JsonResult jsonresult = new JsonResult();
            jsonresult.Data = result;
            jsonresult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return jsonresult;
        }


        public FileResult DownloadExcelTemplete()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "ExcelTemplate/";
            string fileName = "templete.xls";
            return File(new FileStream(path + fileName, FileMode.Open), "application/ms-excel", fileName);
        }

    }
}
