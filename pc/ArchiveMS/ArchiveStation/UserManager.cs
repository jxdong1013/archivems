using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.IO;
using ArchiveStation.Bean;

namespace ArchiveStation
{
    public class UserManager
    {
        public static UserBean LoadUsers()
        {
            string path = Application.StartupPath + "\\user.xml";
            if (File.Exists(path) == false)
            {
                return null;
            }
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(path);
            }
            catch { return null; }
            XmlNode root = doc.DocumentElement;
            if (root == null) return null;
            //List<UserBean> list = new List<UserBean>();
            UserBean userNNN = null;
            DateTime min = DateTime.MinValue;
            foreach (XmlElement ele in root.ChildNodes)
            {
                try
                {
                   UserBean  user = new UserBean();

                    user.userid = ele["id"] == null ? 0 : int.Parse(ele["id"].InnerText);
                    user.username = ele["name"] == null ? "" : ele["name"].InnerText;
                    //user.password = string.Empty;

                    string datestr = ele["date"] == null ? "" : ele["date"].InnerText;
                    DateTime date;
                    bool isDate = DateTime.TryParse(datestr, out date);
                    if (isDate==false )
                    {
                        date = DateTime.Now;
                    }

                    if (date.CompareTo(min) >= 0)
                    {
                        userNNN = user;
                        min = date;
                    }
                    else
                    {
                       //userNNN = 
                        
                    }

                }
                catch { }
            }
            return userNNN;
        }

        public static void SaveUser( UserBean user)
        {
            try
            {
                string path = Application.StartupPath + "\\user.xml";
                XmlDocument doc = new XmlDocument();
                XmlElement root = null;
                if (File.Exists(path) == false)
                {
                    root = doc.CreateElement("users");
                    doc.AppendChild(root);
                }
                else
                {
                    try
                    {
                        doc.Load(path);
                        root = doc.DocumentElement;
                    }
                    catch (System.Xml.XmlException xmlex)
                    {
                        LogHelper.WriteException(xmlex);
                        root = doc.CreateElement("users");
                        doc.AppendChild(root);
                    }
                }
                XmlNode node = root.SelectSingleNode("//user[name='" + user.username + "']");
                if (node != null)
                {
                    node["id"].InnerText = user.userid.ToString();
                    node["code"].InnerText = string.Empty;
                    node["name"].InnerText = user.username;
                    node["password"].InnerText = string.Empty;
                    node["date"].InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                   

                    doc.Save(path);
                    return;
                }
                else
                {
                    XmlElement ele = doc.CreateElement("user");
                    root.AppendChild(ele);
                    XmlElement cele = doc.CreateElement("id");
                    cele.InnerText = user.userid.ToString();
                    ele.AppendChild(cele);
                    cele = doc.CreateElement("code");
                    cele.InnerText = string.Empty;
                    ele.AppendChild(cele);
                    cele = doc.CreateElement("name");
                    cele.InnerText = user.username;
                    ele.AppendChild(cele);
                    cele = doc.CreateElement("password");
                    cele.InnerText = string.Empty;
                    ele.AppendChild(cele);
                    cele = doc.CreateElement("date");
                    cele.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    ele.AppendChild(cele);                     

                    doc.Save(path);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
            }
        }

        public static void Delete( UserBean user)
        {
            string path = Application.StartupPath + "\\user.xml";
            XmlDocument doc = new XmlDocument();
            XmlElement root = null;
            if (File.Exists(path) == false)
            {
                return;
            }
            else
            {
                try
                {
                    doc.Load(path);
                    root = doc.DocumentElement;
                }
                catch (System.Xml.XmlException xmlex)
                {
                    LogHelper.WriteException(xmlex);
                    return;
                }
            }
            XmlNode node = root.SelectSingleNode("//user[name='" + user.username + "']");
            if (node != null)
            {
                root.RemoveChild(node);
                doc.Save(path);
            }
        }
    }
}
