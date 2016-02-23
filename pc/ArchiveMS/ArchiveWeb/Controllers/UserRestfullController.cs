using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using ContractMvcWeb.Attributes;
using ContractMvcWeb.Models.Beans;
using ContractMvcWeb.Models;
using System.Web.Security;

namespace ContractMvcWeb.Controllers
{
    //[MyAuthorize(Roles ="admin")]
    [AuthorizeRestful]
    public class UserRestfullController : Controller
    {       

        [HttpPost]
        public JsonResult AddUser(ContractMvcWeb.Models.Beans.User user)
        {
            JsonResult jsonResult = new JsonResult();
            Result result = null;


            ContractMvcWeb.Models.AccountContext dbContext = new Models.AccountContext();
            bool exist = dbContext.ExistUserName(user.username );
            if (exist)
            {
                result = new Result((int)ResultCodeEnum.Error, "用户名已经存在!", null);
                jsonResult.Data = result;
                return jsonResult;
            }

            int row = dbContext.AddUser(user);
            result = new Result(row > 0 ? (int)ResultCodeEnum.Success : (int)ResultCodeEnum.Error, row > 0 ? "新增成功" : "新增失败", null);
            jsonResult.Data = result;
            return jsonResult;
        }

        [HttpPost]
        public JsonResult EditUser(User model)
        {
            ContractMvcWeb.Models.AccountContext dbContext = new Models.AccountContext();
            JsonResult jsonResult = new JsonResult();
            Result result = null;

            if (string.IsNullOrEmpty(model.username))
            {
                result = new Result( (int)ResultCodeEnum.Error , "请输入用户名",null);
                jsonResult.Data = result;
                return jsonResult;
            }

            bool isExist = dbContext.ExistUserName(model.username, model.userid);
            if (isExist)
            {
                result = new Result((int)ResultCodeEnum.Error, "用户名已经存在", null);
                jsonResult.Data = result;
                return jsonResult;
            }
            

            bool isSuccess = dbContext.EditUser(model);
            result = new Result(isSuccess ? (int)ResultCodeEnum.Success : (int)ResultCodeEnum.Error, isSuccess ? "更新成功" : "更新失败", null);
            jsonResult.Data = result;

            return jsonResult;
        }

        [HttpGet]
        public JsonResult DeleteUser(int userid)
        {
            ContractMvcWeb.Models.AccountContext dbContext = new Models.AccountContext();
            string msg = string.Empty;
            bool isok = dbContext.DeleteUser(userid);
            JsonResult jsonResult = new JsonResult();
            Result result = new Result(isok ? (int)ResultCodeEnum.Success : (int)ResultCodeEnum.Error, "", null);
            jsonResult.Data = result;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult ChangePassword(Models.Beans.LocalPasswordModel model)
        {
            ContractMvcWeb.Models.AccountContext dbContext = new Models.AccountContext();
            string msg = string.Empty;
            bool  issuccess =  dbContext.ChangePassword(model, User.Identity.Name , out msg );
            if(issuccess == false ){
                ModelState.AddModelError("", msg );
            }
            return View();
        }

        [HttpPost]
        public JsonResult ChangePwd(string username , string oldpassword, string newpassword)
        {
            JsonResult json = new JsonResult();
            Result result =null;

            ContractMvcWeb.Models.AccountContext dbContext = new Models.AccountContext();
            string msg = string.Empty;
            LocalPasswordModel model = new LocalPasswordModel();
            
            model.OldPassword = oldpassword;
            model.NewPassword = newpassword;
            model.ConfirmPassword = newpassword;

            bool issuccess = dbContext.ChangePassword(model, username , out msg);
            if (issuccess == false)
            {
                result = new Result((int)ResultCodeEnum.Error, msg,null);

            }
            else
            {
                result = new Result((int)ResultCodeEnum.Success, "修改密码成功", null);
            }

            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            json.Data = result;
            return json;
        }


        [HttpGet]
        public JsonResult GetUserList(String name, int pageidx = 0, int pagesize = 20)
        {
            ContractMvcWeb.Models.AccountContext db = new Models.AccountContext();
            ContractMvcWeb.Models.Beans.User query = new Models.Beans.User();
            query.username = name;
            query.realname = name;
            query.phone = name;

            Models.Beans.Page<ContractMvcWeb.Models.Beans.User> list = db.QueryByPage(query, pageidx, pagesize);

            Models.Result result = new Result((int)ResultCodeEnum.Success, "", list);

            JsonResult jsonresult = new JsonResult();
            jsonresult.Data = result;
            jsonresult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return jsonresult;
        }

    }
}
