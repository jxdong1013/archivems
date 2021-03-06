﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Collections;
using Newtonsoft.Json;
using ArchiveStation.Bean;

namespace ArchiveStation
{
    public class HttpUtilWrapper
    {
        public T Login<T>(String username, String password)
        {
            try
            {
                string url = Bean.Variable.RootUrl() + "/Account/LoginRestfull";
                String data = String.Format("userName={0}&password={1}", username, password);
                String responseContent = "";
                WebHeaderCollection header = new WebHeaderCollection();
                HttpUtil util = new HttpUtil();
                HttpStatusCode statusCode = util.Post( Variable.globelCookieContainer, url, data, "application/x-www-form-urlencoded", "POST", ref  responseContent, ref header);
                if (statusCode != HttpStatusCode.OK)
                {
                    return default(T);
                }

                T entity = JsonConvert.DeserializeObject<T>(responseContent);

                return entity;
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                return default(T);
            }

        }

        public BaseBean ChangePwd(string username , string oldpwd, string newpwd)
        {
            try
            {
                string url = Bean.Variable.RootUrl() + "/UserRestfull/ChangePwd";
                String data = String.Format("username={0}&oldpassword={1}&newpassword={2}", username, oldpwd, newpwd);
                String responseContent = "";
                WebHeaderCollection header = new WebHeaderCollection();
                HttpUtil util = new HttpUtil();
                HttpStatusCode statusCode = util.Post(Variable.globelCookieContainer, url, data, "application/x-www-form-urlencoded", "POST", ref  responseContent, ref header);
                if (statusCode != HttpStatusCode.OK)
                {
                    //BaseBean result = new BaseBean();
                    //result.Code = (int)Constant.ResultCodeEnum.Error;
                    //result.Message = "返回HTTP代码"+statusCode;
                    //return result;
                    return null;
                }

                BaseBean entity = JsonConvert.DeserializeObject<BaseBean>(responseContent);

                return entity;
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                return null;
            }
        }

        //TODO
        public void DownloadTemplete()
        {
             try
            {

            }
             catch (Exception ex)
             {
                 LogHelper.WriteException(ex);
                 //return null;
             }

        }

        public ImportArchiveResult ImportArchive(List<Bean.ArchiveBean> list, int startLine , String username)
        {
            try
            {
                string url = Bean.Variable.RootUrl() + "/ArchiveRestfull/ImportArchive";

                String json = JsonConvert.SerializeObject(list);

                String data = String.Format("{{list:{0},startLine:{1},operateman:\"{2}\"}}", json, startLine , username);
                String responseContent = "";
                WebHeaderCollection header = new WebHeaderCollection();
                HttpUtil util = new HttpUtil();
                HttpStatusCode statusCode = util.Post( Variable.globelCookieContainer, url, data, "application/json", "POST", ref  responseContent, ref header);
                if (statusCode != HttpStatusCode.OK)
                {
                    return null;
                }

                ImportArchiveResult entity = JsonConvert.DeserializeObject<ImportArchiveResult>(responseContent);

                return entity;
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                return null;
            }
        }

        public ArchivePageResult QueryArchiveByPage(Page<Bean.ArchiveBean> page)
        {
            try
            {
                string url = Bean.Variable.RootUrl() + "/ArchiveRestfull/GetArchiveList";
                String paramsStr = String.Format("?manager={0}&title={1}&number={2}&boxrfid={3}&shownoposition={4}&pageidx={5}&pagesize={6}", page.Key, page.Key, page.Key, page.Key, page.showNoPosition , page.PageIdx, page.PageSize);
                url += paramsStr;
                HttpUtil util = new HttpUtil();
                String responseContent = "";
                WebHeaderCollection header = new WebHeaderCollection();

                HttpStatusCode statusCode = util.Post(Variable.globelCookieContainer,
                    url, "", "application/x-www-form-urlencoded", "Get",
                    ref responseContent, ref header);
                if (statusCode != HttpStatusCode.OK)
                {
                    return null;
                }
                ArchivePageResult result = JsonConvert.DeserializeObject<ArchivePageResult>(responseContent);

                return result;
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                return null;
            }
        }

        public FloorPageResult QueryFloorByPage(Page<Bean.FloorBean> page)
        {
            try
            {
                string url = Bean.Variable.RootUrl() + "/LabelRestfull/GetFloorLabelList";
                String paramsStr = String.Format("?name={0}&rfid={1}&pageidx={2}&pagesize={3}", page.Key, page.Key, page.PageIdx,page.PageSize);
                url += paramsStr;
                HttpUtil util = new HttpUtil();
                String responseContent = "";
                WebHeaderCollection header = new WebHeaderCollection();

                HttpStatusCode statusCode = util.Post(Variable.globelCookieContainer,
                    url, "", "application/x-www-form-urlencoded", "Get",
                    ref responseContent, ref header);
                if (statusCode != HttpStatusCode.OK)
                {
                    return null;
                }
                FloorPageResult result = JsonConvert.DeserializeObject<FloorPageResult>(responseContent);

                return result;
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                return null;
            }
        }

        public ArchiveResult DeleteArchives(List<int> archiveIds)
        {
            try
            {
                string url = Bean.Variable.RootUrl() + "/ArchiveRestfull/DeleteArchives";

                String jsonParam = JsonConvert.SerializeObject(archiveIds);
                String paramstr = String.Format("{{archiveids:{0}}}", jsonParam);
                HttpUtil util = new HttpUtil();
                String responseContent = "";
                WebHeaderCollection header = new WebHeaderCollection();

                HttpStatusCode statusCode = util.Post(Variable.globelCookieContainer,
                    url, paramstr, "application/json", "POST",
                    ref responseContent, ref header);
                if (statusCode != HttpStatusCode.OK)
                {
                    return null;
                }
                ArchiveResult result = JsonConvert.DeserializeObject<ArchiveResult>(responseContent);

                return result;
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                return null;
            }
        }

        public FloorResult EditFloorLabel(FloorBean bean)
        {
            try
            {
                string url = Bean.Variable.RootUrl() + "/LabelRestfull/EditFloorLabel";

                String jsonParam = JsonConvert.SerializeObject(bean);
                String paramstr = String.Format("{{model:{0}}}", jsonParam);
                HttpUtil util = new HttpUtil();
                String responseContent = "";
                WebHeaderCollection header = new WebHeaderCollection();

                HttpStatusCode statusCode = util.Post(Variable.globelCookieContainer,
                    url, paramstr, "application/json", "POST",
                    ref responseContent, ref header);
                if (statusCode != HttpStatusCode.OK)
                {
                    return null;
                }
                FloorResult result = JsonConvert.DeserializeObject<FloorResult>(responseContent);

                return result;
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                return null;
            }
        }

        public FloorResult DeleteFloorLabel(FloorBean bean)
        {
            try
            {
                string url = Bean.Variable.RootUrl() + "/LabelRestfull/DeleteFloorLabel";

                String paramstr = String.Format("?rfid={0}", bean.rfid );
                url += paramstr;
                HttpUtil util = new HttpUtil();
                String responseContent = "";
                WebHeaderCollection header = new WebHeaderCollection();

                HttpStatusCode statusCode = util.Post(Variable.globelCookieContainer,
                    url, "", "application/x-www-form-urlencoded", "Get",  ref responseContent, ref header);
                if (statusCode != HttpStatusCode.OK)
                {
                    return null;
                }
                FloorResult result = JsonConvert.DeserializeObject<FloorResult>(responseContent);

                return result;
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                return null;
            }
        }

        public BoxPageResult QueryBoxByPage(Page<Bean.BoxBean> page)
        {
            try
            {
                string url = Bean.Variable.RootUrl() + "/LabelRestfull/GetBoxLabelList";
                String paramsStr = String.Format("?name={0}&rfid={1}&floorrfid={2}&pageidx={3}&pagesize={4}", page.Key, page.Key, page.Key , page.PageIdx, page.PageSize);
                url += paramsStr;
                HttpUtil util = new HttpUtil();
                String responseContent = "";
                WebHeaderCollection header = new WebHeaderCollection();

                HttpStatusCode statusCode = util.Post(Variable.globelCookieContainer,
                    url, "", "application/x-www-form-urlencoded", "Get",
                    ref responseContent, ref header);
                if (statusCode != HttpStatusCode.OK)
                {
                    return null;
                }
                BoxPageResult result = JsonConvert.DeserializeObject<BoxPageResult>(responseContent);

                return result;
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                return null;
            }
        }

        public BoxResult EditBoxLabel(BoxBean bean)
        {
            try
            {
                string url = Bean.Variable.RootUrl() + "/LabelRestfull/EditBoxLabel";

                String jsonParam = JsonConvert.SerializeObject(bean);
                String paramstr = String.Format("{{model:{0}}}", jsonParam);
                HttpUtil util = new HttpUtil();
                String responseContent = "";
                WebHeaderCollection header = new WebHeaderCollection();

                HttpStatusCode statusCode = util.Post(Variable.globelCookieContainer,
                    url, paramstr, "application/json", "POST",
                    ref responseContent, ref header);
                if (statusCode != HttpStatusCode.OK)
                {
                    return null;
                }
                BoxResult result = JsonConvert.DeserializeObject<BoxResult>(responseContent);

                return result;
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                return null;
            }
        }


        public BoxResult DeleteBoxLabel(BoxBean bean)
        {
            try
            {
                string url = Bean.Variable.RootUrl() + "/LabelRestfull/DeleteBoxLabel";

                String paramstr = String.Format("?id={0}", bean.id);
                url += paramstr;
                HttpUtil util = new HttpUtil();
                String responseContent = "";
                WebHeaderCollection header = new WebHeaderCollection();

                HttpStatusCode statusCode = util.Post(Variable.globelCookieContainer,
                    url, "", "application/x-www-form-urlencoded", "Get", ref responseContent, ref header);
                if (statusCode != HttpStatusCode.OK)
                {
                    return null;
                }
                BoxResult result = JsonConvert.DeserializeObject<BoxResult>(responseContent);

                return result;
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                return null;
            }
        }


        public ArchiveResult ArchiveToBox(List<int> archiveIds, int boxid)
        {
            try
            {
                string url = Bean.Variable.RootUrl() + "/LabelRestfull/ArchiveToBox";

                String jsonParam = JsonConvert.SerializeObject( archiveIds );
                String paramstr = String.Format("{{archiveids:{0}, boxid:{1}}}", jsonParam, boxid );
                HttpUtil util = new HttpUtil();
                String responseContent = "";
                WebHeaderCollection header = new WebHeaderCollection();

                HttpStatusCode statusCode = util.Post(Variable.globelCookieContainer,
                    url, paramstr, "application/json", "POST",
                    ref responseContent, ref header);
                if (statusCode != HttpStatusCode.OK)
                {
                    return null;
                }
                ArchiveResult result = JsonConvert.DeserializeObject<ArchiveResult>(responseContent);

                return result;
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                return null;
            }
        }

        public BaseBean BoxToFloor(string floorrfid, string boxrfid , bool isadd )
        {
            try
            {
                string url = Bean.Variable.RootUrl() + "/LabelRestfull/UploadBoxListOfFloor";
                String paramstr = String.Format("?floorrfid={0}&boxrfids={1}&isadd={2}", floorrfid, boxrfid,isadd);
                url += paramstr;

                HttpUtil util = new HttpUtil();
                String responseContent = "";
                WebHeaderCollection header = new WebHeaderCollection();

                HttpStatusCode statusCode = util.Post(Variable.globelCookieContainer,
                    url, "", "application/x-www-form-urlencoded", "Get",
                    ref responseContent, ref header);
                if (statusCode != HttpStatusCode.OK)
                {
                    return null;
                }
                BaseBean result = JsonConvert.DeserializeObject<BaseBean>(responseContent);

                return result;
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                return null;
            }
        }

        public UserPageResult GetUser(Page<Bean.UserBean> page)
        {
            try
            {
                string url = Bean.Variable.RootUrl() + "/UserRestfull/GetUserList";
                String paramsStr = String.Format("?name={0}&pageidx={1}&pagesize={2}", page.Key, page.PageIdx, page.PageSize);
                url += paramsStr;
                HttpUtil util = new HttpUtil();
                String responseContent = "";
                WebHeaderCollection header = new WebHeaderCollection();

                HttpStatusCode statusCode = util.Post(Variable.globelCookieContainer,
                    url, "", "application/x-www-form-urlencoded", "Get",
                    ref responseContent, ref header);
                if (statusCode != HttpStatusCode.OK)
                {
                    return null;
                }
                UserPageResult result = JsonConvert.DeserializeObject<UserPageResult>(responseContent);

                return result;
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                return null;
            }
        }
        
        public UserResult AddUser(UserBean bean)
        {
            try
            {
                string url = Bean.Variable.RootUrl() + "/UserRestfull/AddUser";

                String jsonParam = JsonConvert.SerializeObject(bean);
                String paramstr = String.Format("{{user:{0}}}", jsonParam);
                HttpUtil util = new HttpUtil();
                String responseContent = "";
                WebHeaderCollection header = new WebHeaderCollection();

                HttpStatusCode statusCode = util.Post(Variable.globelCookieContainer,
                    url, paramstr, "application/json", "POST",
                    ref responseContent, ref header);
                if (statusCode != HttpStatusCode.OK)
                {
                    return null;
                }
                UserResult result = JsonConvert.DeserializeObject<UserResult>(responseContent);

                return result;
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                return null;
            }
        }

        public UserResult EditUser(UserBean bean)
        {
            try
            {
                string url = Bean.Variable.RootUrl() + "/UserRestfull/EditUser";

                String jsonParam = JsonConvert.SerializeObject(bean);
                String paramstr = String.Format("{{model:{0}}}", jsonParam);
                HttpUtil util = new HttpUtil();
                String responseContent = "";
                WebHeaderCollection header = new WebHeaderCollection();

                HttpStatusCode statusCode = util.Post(Variable.globelCookieContainer,
                    url, paramstr, "application/json", "POST",
                    ref responseContent, ref header);
                if (statusCode != HttpStatusCode.OK)
                {
                    return null;
                }
                UserResult result = JsonConvert.DeserializeObject<UserResult>(responseContent);

                return result;
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                return null;
            }
        }

        public UserResult DeleteUser(int userid)
        {
            try
            {
                string url = Bean.Variable.RootUrl() + "/UserRestfull/DeleteUser";

                String paramstr = String.Format("?userid={0}", userid);
                url += paramstr;
                HttpUtil util = new HttpUtil();
                String responseContent = "";
                WebHeaderCollection header = new WebHeaderCollection();

                HttpStatusCode statusCode = util.Post(Variable.globelCookieContainer,
                    url, "", "application/x-www-form-urlencoded", "Get",
                    ref responseContent, ref header);
                if (statusCode != HttpStatusCode.OK)
                {
                    return null;
                }
                UserResult result = JsonConvert.DeserializeObject<UserResult>(responseContent);

                return result;
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rfid"></param>
        /// <returns></returns>
        public ArchiveListResult Borrow_GetArchiveListOfBox(string rfid , int status )
        {
            try
            {
                string url = Bean.Variable.RootUrl() + "/BorrowRestfull/GetArchiveListOfBox?boxrfid=" + rfid+"&status="+status;
                         
                HttpUtil util = new HttpUtil();
                String responseContent = "";
                WebHeaderCollection header = new WebHeaderCollection();
                HttpStatusCode statusCode = util.Post(Variable.globelCookieContainer,
                    url, "", "application/x-www-form-urlencoded", "Get",
                    ref responseContent, ref header);
                if (statusCode != HttpStatusCode.OK)
                {
                    return null;
                }
                ArchiveListResult result = JsonConvert.DeserializeObject<ArchiveListResult>(responseContent);

                return result;
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                return null;
            }
        }



        public BorrowerPageResult QueryBorrowerByPage(Page<BorrowerBean> page )
        {
            try
            {
                string url = Bean.Variable.RootUrl() + "/BorrowerRestfull/QueryBorrowerByPage";
                String paramsStr = String.Format("?name={0}&idcard={1}&department={2}&pageidx={3}&pagesize={4}", page.Key, page.Key, page.Key,  page.PageIdx, page.PageSize);
                url += paramsStr;
                HttpUtil util = new HttpUtil();
                String responseContent = "";
                WebHeaderCollection header = new WebHeaderCollection();

                HttpStatusCode statusCode = util.Post(Variable.globelCookieContainer,
                    url, "", "application/x-www-form-urlencoded", "Get",
                    ref responseContent, ref header);
                if (statusCode != HttpStatusCode.OK)
                {
                    return null;
                }
                BorrowerPageResult result = JsonConvert.DeserializeObject<BorrowerPageResult>(responseContent);

                return result;
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                return null;
            }
        }



        public BorrowResult Borrow(BorrowParameter parameter)
        {
            try
            {
                string url = Bean.Variable.RootUrl() + "/BorrowRestfull/Borrow";
                String jsonParam = JsonConvert.SerializeObject(parameter);
                String paramstr = String.Format("{{parameter:{0}}}", jsonParam);  // String.Format("{{boxs:'{0}',name:{1},idcard:{2},department:{3},operatename:{4},operatorid:{5}}}", parameter.boxids, parameter.name , parameter.idcard, parameter.department,parameter.operatename,parameter.operateid);
                HttpUtil util = new HttpUtil();
                String responseContent = "";
                WebHeaderCollection header = new WebHeaderCollection();
                HttpStatusCode statusCode = util.Post(Variable.globelCookieContainer,
                    url, paramstr, "application/json", "POST",
                    ref responseContent, ref header);
                if (statusCode != HttpStatusCode.OK)
                {
                    return null;
                }
                BorrowResult result = JsonConvert.DeserializeObject<BorrowResult>(responseContent);

                return result;
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                return null;
            }
        }


        public BorrowLogPageResult QueryBorrowLogByPage( PageObject<BorrowLogBean> page )
        {
            try
            {
                string url = Bean.Variable.RootUrl() + "/BorrowRestfull/QueryBorrowLogByPage";
                string json = JsonConvert.SerializeObject( page.Key );
                //String paramsStr = String.Format("?name={0}&idcard={1}&department={2}&pageidx={3}&pagesize={4}", page.Key, page.Key, page.Key, page.PageIdx, page.PageSize);
                string parameterStr = string.Format("{{parameter:{0}, pageidx:{1},pagesize:{2}}}", json, page.PageIdx , page.PageSize);
                //url += paramsStr;
                HttpUtil util = new HttpUtil();
                String responseContent = "";
                WebHeaderCollection header = new WebHeaderCollection();

                HttpStatusCode statusCode = util.Post(Variable.globelCookieContainer,
                    url, parameterStr , "application/json", "POST",
                    ref responseContent, ref header);
                if (statusCode != HttpStatusCode.OK)
                {
                    return null;
                }
                BorrowLogPageResult result = JsonConvert.DeserializeObject<BorrowLogPageResult>(responseContent);

                return result;
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                return null;
            }
        }
    

        public BaseBean Return(BorrowParameter parameter){
            try
            {
                string url = Bean.Variable.RootUrl() + "/BorrowRestfull/Return";
                String jsonParam = JsonConvert.SerializeObject(parameter);
                String paramstr = String.Format("{{parameter:{0}}}", jsonParam);  // String.Format("{{boxs:'{0}',name:{1},idcard:{2},department:{3},operatename:{4},operatorid:{5}}}", parameter.boxids, parameter.name , parameter.idcard, parameter.department,parameter.operatename,parameter.operateid);
                HttpUtil util = new HttpUtil();
                String responseContent = "";
                WebHeaderCollection header = new WebHeaderCollection();
                HttpStatusCode statusCode = util.Post(Variable.globelCookieContainer,
                    url, paramstr, "application/json", "POST",
                    ref responseContent, ref header);
                if (statusCode != HttpStatusCode.OK)
                {
                    return null;
                }
                BorrowResult result = JsonConvert.DeserializeObject<BorrowResult>(responseContent);

                return result;
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                return null;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="rfid"></param>
        /// <returns></returns>
        public BorrowListResult Borrow_GetArchiveListByBorrower(int borrowerid)
        {
            try
            {
                string url = Bean.Variable.RootUrl() + "/BorrowRestfull/GetArchiveListOfBorrower?borrowerid=" +borrowerid;

                HttpUtil util = new HttpUtil();
                String responseContent = "";
                WebHeaderCollection header = new WebHeaderCollection();
                HttpStatusCode statusCode = util.Post(Variable.globelCookieContainer,
                    url, "", "application/x-www-form-urlencoded", "Get",
                    ref responseContent, ref header);
                if (statusCode != HttpStatusCode.OK)
                {
                    return null;
                }
                BorrowListResult result = JsonConvert.DeserializeObject<BorrowListResult>(responseContent);

                return result;
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                return null;
            }
        }


    }
}
