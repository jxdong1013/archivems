﻿using System;
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
            JsonResult json = null;
            bool isExist = db.ExistBoxLabel(model.rfid);
            if (isExist)
            {
                result = new Result((int)ResultCodeEnum.Error, "标签已经被注册为档案盒标签，请使用其他标签", null);
                json = new JsonResult();
                json.Data = result;
                return json;
            }

            if (model.id > 0)
            {
                isExist = db.ExistFloorLabel(model.rfid, model.id);
                if (isExist)
                {
                    result = new Result((int)ResultCodeEnum.Error, "标签已经被注册，请使用其他标签", null);
                }
                else
                {
                    isExist = db.ExistFloorLabelByName(model.name, model.id);
                    if (isExist)
                    {
                        result = new Result((int)ResultCodeEnum.Error, "名称已经被使用，请使用别的名称", null);
                    }
                    else
                    {
                        bool isok = db.EditFloorLabel(model);
                        result = new Result(isok ? (int)ResultCodeEnum.Success : (int)ResultCodeEnum.Error, isok ? "更新成功" : "更新失败", null);
                    }
                }
            }
            else
            {               
                isExist = db.ExistFloorLabel(model.rfid);
                if (isExist)
                {
                    result = new Result((int)ResultCodeEnum.Error, "标签已经被注册，请使用其他标签", null);
                }
                else
                {
                    isExist = db.ExistFloorLabelByName(model.name);
                    if (isExist)
                    {
                        result = new Result((int)ResultCodeEnum.Error, "名称已经被使用，请使用别的名称", null);
                    }
                    else
                    {
                        bool isok = db.AddFloorLabel(model);
                        result = new Result(isok ? (int)ResultCodeEnum.Success : (int)ResultCodeEnum.Error, isok ? "新增成功" : "新增失败", null);
                    }
                }
            }

            json = new JsonResult();
            json.Data = result;
            return json;
        }

        [HttpGet]
        public JsonResult DeleteFloorLabel( string rfid)
        {
            ContractMvcWeb.Models.LabelContext db = new Models.LabelContext();
            Result result = null;

            bool isExistBoxLabel = db.ExistBoxsOfFloorLabel( rfid);
            if (isExistBoxLabel)
            {
                result = new Result((int)ResultCodeEnum.Error, "请先删除盒标签再操作。", null);
            }
            else
            {
                bool isok = db.DeleteFloorLabel(rfid);
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
            JsonResult json = null;

            bool isExist = db.ExistFloorLabel(model.rfid);
            if (isExist)
            {
                result = new Result((int)ResultCodeEnum.Error, "标签已经被注册为层架标签，请使用其他标签", null);
                json = new JsonResult();
                json.Data = result;
                return json;
            }

            if (model.id > 0)
            {
                isExist = db.ExistBoxLabel(model.rfid, model.id);
                if (isExist)
                {
                    result = new Result((int)ResultCodeEnum.Error, "标签已经被注册，请使用其他标签", null);
                }
                else
                {
                    isExist = db.ExistBoxLabelByName(model.name, model.id);
                    if (isExist)
                    {
                        result = new Result((int)ResultCodeEnum.Error, "名称已经被使用，请使用别的名称", null);
                    }
                    else
                    {
                        bool isok = db.EditBoxLabel(model);
                        result = new Result(isok ? (int)ResultCodeEnum.Success : (int)ResultCodeEnum.Error, isok ? "更新成功" : "更新失败", null);
                    }
                }
            }
            else
            {
                isExist = db.ExistBoxLabel(model.rfid);
                if (isExist)
                {
                    result = new Result((int)ResultCodeEnum.Error, "标签已经被注册，请使用其他标签", null);
                }
                else
                {
                    isExist = db.ExistBoxLabelByName(model.name);
                    if (isExist)
                    {
                        result = new Result((int)ResultCodeEnum.Error, "名称已经被使用，请使用别的名称", null);
                    }
                    else
                    {
                        bool isok = db.AddBoxLabel(model);
                        result = new Result(isok ? (int)ResultCodeEnum.Success : (int)ResultCodeEnum.Error, isok ? "新增成功" : "新增失败", null);
                    }
                }
            }

            json = new JsonResult();
            json.Data = result;

            return json;
        }


        [HttpGet]
        public JsonResult DeleteBoxLabel(int id)
        {
            ContractMvcWeb.Models.LabelContext db = new Models.LabelContext();
            Result result = null;

            bool isExistArchive = db.ExistArchivesOfBoxLabel(id);
            if (isExistArchive)
            {
                result = new Result((int)ResultCodeEnum.Error, "请先删除档案再操作。", null);
            }
            else
            {
                bool isok = db.DeleteBoxLabel(id);
                result = new Result(isok ? (int)ResultCodeEnum.Success : (int)ResultCodeEnum.Error, isok ? "删除成功" : "删除失败", null);
            }

            JsonResult jsonResult = new JsonResult();
            jsonResult.Data = result;
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return jsonResult;
        }

        [HttpGet]
        public JsonResult GetBoxLabelList(String name, String boxrfid, string  floorrfid, int pageidx = 0, int pagesize = 20)
        {
            ContractMvcWeb.Models.LabelContext db = new Models.LabelContext();
            ContractMvcWeb.Models.Beans.BoxLabel query = new Models.Beans.BoxLabel();
            query.name = name;
            query.rfid = boxrfid;
            query.floorrfid = floorrfid;

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

        [HttpGet]
        public JsonResult GetBoxListOfFloor(string floorrfid)
        {
            ContractMvcWeb.Models.LabelContext db = new LabelContext();
            List< Models.Beans.BoxLabel> list = db.GetBoxListOfFloor(floorrfid );

            JsonResult jsonResult = new JsonResult();
            Result result = new Result( (int)ResultCodeEnum.Success , "获取数据成功" , list);
            jsonResult.Data = result;
            return jsonResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="floorrfid"></param>
        /// <param name="boxrfids"></param>
        /// <param name="isAdd">=true，则 删除其他 标签</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult UploadBoxListOfFloor(string floorrfid, string boxrfids , bool isadd = false )
        {
            ContractMvcWeb.Models.LabelContext db = new LabelContext();
            bool isok = db.UploadBoxListOfFloor(floorrfid, boxrfids , isadd );
            JsonResult jsonResult = new JsonResult();
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            Result result = new Result(isok ? (int)ResultCodeEnum.Success : (int)ResultCodeEnum.Error, isok ? "定位成功" : "定位失败", null);
            jsonResult.Data = result;
            return jsonResult;

        }

        [HttpGet]
        public JsonResult GetLabelInfoByRFID(string rfid)
        {
            ContractMvcWeb.Models.LabelContext db = new LabelContext();
            Models.Beans.LabelInfo info= db.GetLabelInfoByRFID(rfid);

            JsonResult jsonResult = new JsonResult();
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            Result result = new Result( info !=null ? (int)ResultCodeEnum.Success : (int)ResultCodeEnum.Error, info!=null ? "查询成功" : "查无此标签", info);
            jsonResult.Data = result;
            return jsonResult;
        }

        [HttpGet]
        public JsonResult GetInventoryLabelInfo(string rfid)
        {
            ContractMvcWeb.Models.LabelContext db = new LabelContext();
            Models.Beans.InventoryLabelInfo info = db.GetInventoryLabelInfo(rfid);

            JsonResult jsonResult = new JsonResult();
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            Result result = new Result(info != null ? (int)ResultCodeEnum.Success : (int)ResultCodeEnum.Error, info != null ? "查询成功" : "查无此标签", info);
            jsonResult.Data = result;
            return jsonResult;

        }


   
    
        [HttpPost]
        public JsonResult UploadInventoryInfo(Models.Beans.InventoryList data)
        {
            try
            {
                JsonResult jsonResult = new JsonResult();
                Result result;
                if (data == null)
                {
                    jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                    result = new Result( (int)ResultCodeEnum.Error, "参数空",null);
                    jsonResult.Data = result;
                    return jsonResult;                    
                }
                


                ContractMvcWeb.Models.LabelContext db = new LabelContext();
                bool isok = db.UploadInventoryInfo(data);               
                jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                result = new Result(isok ? (int)ResultCodeEnum.Success : (int)ResultCodeEnum.Error, isok ? "上传盘点信息成功" : "上传盘点信息失败", null);
                jsonResult.Data = result;
                return jsonResult;
            }
            catch (Exception ex)
            {
                String msg = ex.Message;
                msg += ex.StackTrace;

                JsonResult jsonResult = new JsonResult();
                jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                Result result = new Result( (int)ResultCodeEnum.Error, "服务端发生错误"+ msg ,null);
                jsonResult.Data = result;
                return jsonResult;
            }

        }
    }
}
