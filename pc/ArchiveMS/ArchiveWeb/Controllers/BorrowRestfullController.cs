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
    public class BorrowRestfullController : Controller
    {
         /// <summary>
         /// 获得档案盒下的所有在库的档案
         /// </summary>
         /// <param name="rfid"></param>
         /// <returns></returns>
         public JsonResult GetArchiveListOfBox(string boxrfid , int status =0 )
         {
             try
             {
                 ContractMvcWeb.Models.LabelContext db = new Models.LabelContext();
                 List<Archive> archiveList = db.GetArchiveListOfBox(boxrfid ,  status );

                 Models.Result result = new Result((int)ResultCodeEnum.Success, "", archiveList );

                 JsonResult jsonresult = new JsonResult();
                 jsonresult.Data = result;
                 jsonresult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                 return jsonresult;
             }
             catch (Exception ex)
             {
                 JsonResult jsonresult = new JsonResult();
                 Result result = new Result((int)ResultCodeEnum.Error, "服务器发送内部错误", null);
                 jsonresult.Data = result;
                 jsonresult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                 return jsonresult;
             }
         }

         /// <summary>
         /// 查询当前人借阅的档案列表
         /// </summary>
         /// <param name="borrowerid"></param>
         /// <returns></returns>
         public JsonResult GetArchiveListOfBorrower( int borrowerid)
         {
             BorrowContext borrowContext = new BorrowContext();
             List<BorrowLogBean> list =  borrowContext.GetArchiveListByBorrower(borrowerid, (int)Constant.ArchiveStatusEnum.借出 );
             Models.Result result = new Result((int)ResultCodeEnum.Success, "", list);

             JsonResult jsonresult = new JsonResult();
             jsonresult.Data = result;
             jsonresult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
             return jsonresult;
         }

         [HttpPost]
         public JsonResult Borrow(BorrowParameter parameter)
         {
             try
             {
                 JsonResult jsonresult = new JsonResult();
                 Result result = null;

                 if (parameter == null)
                 {
                     result = new Result((int)ResultCodeEnum.Error,"Post数据空",null);
                     jsonresult.Data = result;
                     jsonresult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                     return jsonresult;
                 }

                 if (string.IsNullOrEmpty(parameter.archiveids))
                 {
                     result = new Result((int)ResultCodeEnum.Error, "缺少档案信息", null);
                     jsonresult.Data = result;
                     jsonresult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                     return jsonresult; 
                 }
                 if (string.IsNullOrEmpty(parameter.name) || string.IsNullOrEmpty(parameter.idcard ))
                 {
                     result = new Result((int)ResultCodeEnum.Error, "缺少借阅人信息", null);
                     jsonresult.Data = result;
                     jsonresult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                     return jsonresult; 
                 }
                 

                 string[] archiveidlist= parameter.archiveids.Split( new string[]{","},  StringSplitOptions.RemoveEmptyEntries);
                 if (archiveidlist == null || archiveidlist.Length < 1)
                 {
                     result = new Result((int)ResultCodeEnum.Error, "缺少档案信息", null);
                     jsonresult.Data = result;
                     jsonresult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                     return jsonresult;                         
                 }


                 ArchiveContext archiveContext = new ArchiveContext();

                 List<Archive> archives = new List<Archive>();
                 string errorInfo = string.Empty;
                 foreach (string archiveid in archiveidlist.ToList())
                 {
                     int aid = Convert.ToInt32(archiveid);
                     Archive model = archiveContext.GetModelEx(aid);
                     if (model == null)
                     {
                         continue;
                     }
                     if (model.status != (int)Constant.ArchiveStatusEnum.在库)
                     {
                         if (!string.IsNullOrEmpty(errorInfo))
                         {
                             errorInfo += Environment.NewLine;
                         }
                         errorInfo += string.Format( "档案:{0} {1}不在库",model.title , model.number);
                     }

                     archives.Add(model);
                 }
                 if (!string.IsNullOrEmpty(errorInfo))
                 {
                     result = new Result((int)ResultCodeEnum.Error , errorInfo , null);
                     jsonresult.Data = result;
                     jsonresult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                     return jsonresult;      
                 }
                  
                 
                 BorrowerContext borrowerContext = new BorrowerContext();
                 Borrower borrower = borrowerContext.GetModelByIdCard( parameter.idcard );
                 int borrowerid = 0;
                 if (borrower == null)
                 {
                     borrower = new Borrower();
                     borrower.name = parameter.name;
                     borrower.idcard = parameter.idcard;
                     borrower.department = parameter.department;
                     borrowerid = borrowerContext.Add(borrower);
                 }
                 else
                 {
                     borrowerid = borrower.borrowerid;
                 }
                 
                 BorrowContext borrowContext = new BorrowContext();
                 DateTime borrowDate = DateTime.Now;
                 borrowContext.Borrow(archiveidlist.ToList(), borrowerid, parameter.operatename, parameter.operateid, borrowDate );
                 borrower.borrowdate = borrowDate;
                 borrower.operatename = parameter.operatename;
                 result = new Result((int)ResultCodeEnum.Success, "", getPrintEntity(borrower, archives));
                 jsonresult.Data = result;
                 jsonresult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                 return jsonresult;            

             }
             catch (Exception ex)
             {                
                 JsonResult jsonresult = new JsonResult();
                 Result result = new Result((int)ResultCodeEnum.Error, "服务器发生内部错误", null);
                 jsonresult.Data = result;
                 jsonresult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                 return jsonresult;
             }
         }

         protected PrintBorrowBean getPrintEntity( Borrower borrower , List<Archive> archives )
         {
             PrintBorrowBean printBean = new PrintBorrowBean();
             printBean.Borrower = borrower;
             printBean.ArchiveList = archives;

             return printBean;
         }


         [HttpPost]
         public JsonResult Return(BorrowParameter parameter)
         {
             JsonResult jsonresult = new JsonResult();
             Result result = null;

             if (parameter == null)
             {
                 result = new Result((int)ResultCodeEnum.Error, "Post数据空", null);
                 jsonresult.Data = result;
                 jsonresult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                 return jsonresult;
             }

             if (string.IsNullOrEmpty(parameter.archiveids))
             {
                 result = new Result((int)ResultCodeEnum.Error, "缺少档案信息", null);
                 jsonresult.Data = result;
                 jsonresult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                 return jsonresult;
             }

             string[] archiveidlist = parameter.archiveids.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
             if (archiveidlist == null || archiveidlist.Length < 1)
             {
                 result = new Result((int)ResultCodeEnum.Error, "缺少档案信息", null);
                 jsonresult.Data = result;
                 jsonresult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                 return jsonresult;
             }


             ArchiveContext archiveContext = new ArchiveContext();

             string errorInfo = string.Empty;
             //List<int> returner = new List<int>();
             foreach (string archiveid in archiveidlist.ToList())
             {
                 int aid = Convert.ToInt32(archiveid);
                 Archive model = archiveContext.GetModel(aid);
                 if (model.status != (int)Constant.ArchiveStatusEnum.借出)
                 {
                     if (!string.IsNullOrEmpty(errorInfo))
                     {
                         errorInfo += Environment.NewLine;
                     }
                     errorInfo += string.Format("档案:{0} {1} 已经入库", model.title, model.number);
                 }

                 //returner.Add(model.);

             }
             if (!string.IsNullOrEmpty(errorInfo))
             {
                 result = new Result((int)ResultCodeEnum.Error, errorInfo, null);
                 jsonresult.Data = result;
                 jsonresult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                 return jsonresult;
             }

             BorrowContext borrowContext = new BorrowContext();
             borrowContext.Return( archiveidlist.ToList(),  parameter.operatename, parameter.operateid);
             result = new Result((int)ResultCodeEnum.Success, "", null);
             jsonresult.Data = result;
             jsonresult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
             return jsonresult;            


         }


          [HttpPost]
         public JsonResult QueryBorrowLogByPage( BorrowLogBean parameter , int pageidx , int pagesize=20)
         {
             JsonResult jsonresult = new JsonResult();                       

             BorrowContext context = new BorrowContext();
             Page<BorrowLogBean> data = context.Log(parameter, pageidx, pagesize);

             Models.Result result = new Result((int)ResultCodeEnum.Success, "", data);
             jsonresult.Data = result;
             jsonresult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
             return jsonresult;

         }
     }
}
