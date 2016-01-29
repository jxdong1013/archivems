using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContractMvcWeb.Attributes;
using ContractMvcWeb.Models;

namespace ContractMvcWeb.Controllers
{
    [AuthorizeRestful]
    public class LabelRestfullController : Controller
    {

        [HttpPost]
        public JsonResult EditFloorLabel(ContractMvcWeb.Models.Beans.FloorLabel model )
        {
            ContractMvcWeb.Models.LabelContext db = new Models.LabelContext();
            Result result = null;
            if (model.id > 0)
            {
                bool isExist = db.ExistFloorLabel(model.rfid, model.id);
                if (isExist)
                {
                    result = new Result((int)ResultCodeEnum.Error, "标签已经被注册，请使用其他标签", null);
                }
                else
                {
                    bool isok = db.EditFloorLabel(model);
                    result = new Result(isok ? (int)ResultCodeEnum.Success : (int)ResultCodeEnum.Error, isok ?"更新成功": "更新失败", null);
                }
            }
            else
            {
               
                bool isExist = db.ExistFloorLabel(model.rfid);
                if (isExist)
                {
                    result = new Result((int)ResultCodeEnum.Error, "标签已经被注册，请使用其他标签", null);
                }
                else
                {
                    bool isok = db.AddFloorLabel(model);
                    result = new Result(isok ? (int)ResultCodeEnum.Success : (int)ResultCodeEnum.Error, isok? "新增成功": "新增失败", null);
                }
            }

            JsonResult json = new JsonResult();
            json.Data = result;

            return json;
        }

        [HttpGet]
        public JsonResult DeleteFloorLabel(int id)
        {
            ContractMvcWeb.Models.LabelContext db = new Models.LabelContext();
            Result result = null;

            bool isExistBoxLabel = db.ExistBoxsOfFloorLabel(id);
            if (isExistBoxLabel)
            {
                result = new Result((int)ResultCodeEnum.Error, "请先删除盒标签再操作。", null);
            }
            else
            {
                bool isok = db.DeleteFloorLabel(id);
                result = new Result( isok ? (int)ResultCodeEnum.Success : (int) ResultCodeEnum.Error, isok ?"删除成功":"删除失败",null);
            }

            JsonResult jsonResult = new JsonResult();
            jsonResult.Data = result;
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return jsonResult;
        }

        [HttpGet]
        public JsonResult GetFloorLabelList( String name , String rfid , int pageidx = 0, int pagesize = 20 )
        {
            ContractMvcWeb.Models.LabelContext db = new Models.LabelContext();
            ContractMvcWeb.Models.Beans.FloorLabel query = new Models.Beans.FloorLabel();
            query.name = name;
            query.rfid = rfid;
            
            Models.Beans.Page<ContractMvcWeb.Models.Beans.FloorLabel> list = db.QueryFloorByPage(query, pageidx, pagesize);

            Models.Result result = new Result((int)ResultCodeEnum.Success, "", list);

            JsonResult jsonresult = new JsonResult();
            jsonresult.Data = result;
            jsonresult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return jsonresult;
        }

        [HttpPost]
        public JsonResult EditBoxLabel(ContractMvcWeb.Models.Beans.BoxLabel model)
        {
            ContractMvcWeb.Models.LabelContext db = new Models.LabelContext();
            Result result = null;
            if (model.id > 0)
            {
                bool isExist = db.ExistBoxLabel(model.rfid, model.id);
                if (isExist)
                {
                    result = new Result((int)ResultCodeEnum.Error, "标签已经被注册，请使用其他标签", null);
                }
                else
                {
                    bool isok = db.EditBoxLabel(model);
                    result = new Result(isok ? (int)ResultCodeEnum.Success : (int)ResultCodeEnum.Error, isok? "更新成功": "更新失败", null);
                }
            }
            else
            {
                bool isExist = db.ExistBoxLabel(model.rfid);
                if (isExist)
                {
                    result = new Result((int)ResultCodeEnum.Error, "标签已经被注册，请使用其他标签", null);
                }
                else
                {
                    bool isok = db.AddBoxLabel(model);
                    result = new Result(isok ? (int)ResultCodeEnum.Success : (int)ResultCodeEnum.Error, isok ?"新增成功": "新增失败", null);
                }
            }

            JsonResult json = new JsonResult();
            json.Data = result;

            return json;
        }
        
        [HttpGet]
        public JsonResult GetBoxLabelList(String name, String rfid, int pageidx = 0, int pagesize = 20)
        {
            ContractMvcWeb.Models.LabelContext db = new Models.LabelContext();
            ContractMvcWeb.Models.Beans.BoxLabel query = new Models.Beans.BoxLabel();
            query.name = name;
            query.rfid = rfid;

            Models.Beans.Page<ContractMvcWeb.Models.Beans.BoxLabel> list = db.QueryBoxByPage(query, pageidx, pagesize);

            Models.Result result = new Result((int)ResultCodeEnum.Success, "", list);

            JsonResult jsonresult = new JsonResult();
            jsonresult.Data = result;
            jsonresult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return jsonresult;
        }

        [HttpPost]
        public JsonResult ArchiveToBox(List<int> archiveids, int boxid)
        {
            ContractMvcWeb.Models.LabelContext db = new LabelContext();
            bool isok = db.ArchiveToBox(archiveids, boxid);

            JsonResult jsonResult = new JsonResult();
            Result result = new Result(isok ? (int)ResultCodeEnum.Success : (int)ResultCodeEnum.Error, isok ? "归盒操作成功" : "归盒操作失败", null);
            jsonResult.Data = result;
            return jsonResult;
        }
    }
}
