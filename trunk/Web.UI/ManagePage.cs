using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;
using Cms.Common;

namespace Cms.Web.UI
{
    public class ManagePage : System.Web.UI.Page
    {
        protected internal Cms.Model.WebSet webset;
        public ManagePage()
        {
            this.Load += new EventHandler(ManagePage_Load);
            webset = new Cms.DAL.WebSet().loadConfig(Server.MapPath(ConfigurationManager.AppSettings["Configpath"].ToString()));
        }

        void ManagePage_Load(object sender, EventArgs e)
        {
            if (Session["AdminNo"] == null || Session["AdminName"] == null)
            {
                Response.Write("<script>alert('对不起,您没有登录！');parent.location.href='../Login.aspx'</script>");
                Response.End();
            }
        }

        /// <summary>
        /// 遮罩提示窗口
        /// </summary>
        /// <param name="w">宽度</param>
        /// <param name="h">高度</param>
        /// <param name="msgtitle">窗口标题</param>
        /// <param name="msgbox">提示文字</param>
        /// <param name="url">返回地址</param>
        /// <param name="msgcss">CSS样式</param>
        protected void JscriptMsg(int w, int h, string msgtitle, string msgbox, string url, string msgcss)
        {
            string msbox = "";
            msbox += "<script type=\"text/javascript\">\n";
            msbox += "parent.jsmsg(" + w + "," + h + ",\"" + msgtitle + "\",\"" + msgbox + "\",\"" + url + "\",\"" + msgcss + "\")\n";
            msbox += "</script>\n";
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsMsg", msbox);
        }

        /// <summary>
        /// 添加编辑删除提示
        /// </summary>
        /// <param name="msgtitle">提示文字</param>
        /// <param name="url">返回地址</param>
        /// <param name="msgcss">CSS样式</param>
        protected void JscriptPrint(string msgtitle, string url, string msgcss)
        {
            string msbox = "";
            msbox += "<script type=\"text/javascript\">\n";
            msbox += "parent.jsprint(\"" + msgtitle + "\",\"" + url + "\",\"" + msgcss + "\")\n";
            msbox += "</script>\n";
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox);
        }

        /// <summary>
        /// 遮罩提示窗口
        /// </summary>
        /// <param name="w">宽</param>
        /// <param name="h">高</param>
        /// <param name="msgtitle">提示标题</param>
        /// <param name="msgbox">提示内容</param>
        /// <param name="url">转向地址,back表示后退,空表示不转向</param>
        /// <param name="msgcss">提示样式,成功：Success,错误：Error,警告：Warning</param>
        protected void jsLayMsg(int w, int h, string msgtitle, string msgbox, string url, string msgcss)
        {
            StringBuilder strbox = new StringBuilder();
            strbox.Append("$(function(){ jsLayMsg(" + w + ", " + h + ", {title:\"" + msgtitle + "\",msbox:\"" + msgbox + "\",mscss:\"" + msgcss + "\",url:\"" + url + "\"}); });");
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "LayMsg", strbox.ToString(), true);
        }

        /// <summary>
        /// 绑定类别DropDownList控制
        /// </summary>
        /// <param name="parentId">父类ID</param>
        /// /// <param name="firstItemTxt">第一项显示的文字</param>
        /// <param name="kindId">大类ID</param>
        /// <param name="ddl">要绑定的DropDownList控件</param>
        protected void NewsClassTreeBind(string firstItemTxt, DropDownList ddl)
        {
            Cms.DAL.Channel dal = new Cms.DAL.Channel();
            DataSet newsDS = dal.GetNewsClassList("");
            DataTable dt = newsDS.Tables[0];

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem(firstItemTxt, ""));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["ClassID"].ToString();
                string Title = dr["Title"].ToString().Trim();
                Title = "├ " + Title;
                ddl.Items.Add(new ListItem(Title, Id));
            }
        }
        /// <summary>
        /// 绑定类别DropDownList控制
        /// </summary>
        /// <param name="parentId">父类ID</param>
        /// /// <param name="firstItemTxt">第一项显示的文字</param>
        /// <param name="kindId">大类ID</param>
        /// <param name="ddl">要绑定的DropDownList控件</param>
        protected void ProductTypeTreeBind(string firstItemTxt, DropDownList ddl)
        {
            Cms.DAL.Channel dal = new Cms.DAL.Channel();
            DataSet newsDS = dal.GetProductTypeList("");
            DataTable dt = newsDS.Tables[0];

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem(firstItemTxt, ""));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["TypeId"].ToString();
                string Title = dr["ComoditiesType"].ToString().Trim();
                Title = "├ " + Title;
                ddl.Items.Add(new ListItem(Title, Id));
            }
        }
        /// <summary>
        /// 绑定类别DropDownList控制
        /// </summary>
        /// <param name="parentId">父类ID</param>
        /// /// <param name="firstItemTxt">第一项显示的文字</param>
        /// <param name="kindId">大类ID</param>
        /// <param name="ddl">要绑定的DropDownList控件</param>
        protected void ProductBrandTreeBind(string firstItemTxt, DropDownList ddl, string where)
        {
            Cms.DAL.Channel dal = new Cms.DAL.Channel();
            DataSet newsDS = dal.GetProductBrandList(where);
            DataTable dt = newsDS.Tables[0];

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem(firstItemTxt, ""));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["brandID"].ToString();
                string Title = dr["Brand"].ToString().Trim();
                Title = "├ " + Title;
                ddl.Items.Add(new ListItem(Title, Id));
            }
        }
        /// <summary>
        /// 绑定类别DropDownList控制
        /// </summary>
        /// <param name="parentId">父类ID</param>
        /// /// <param name="firstItemTxt">第一项显示的文字</param>
        /// <param name="kindId">大类ID</param>
        /// <param name="ddl">要绑定的DropDownList控件</param>
        protected void ProductNameTreeBind(string firstItemTxt, DropDownList ddl, string where)
        {
            Cms.DAL.Channel dal = new Cms.DAL.Channel();
            DataSet newsDS = dal.GetProductNameList(where);
            DataTable dt = newsDS.Tables[0];

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem(firstItemTxt, ""));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["ComoditiesNameID"].ToString();
                string Title = dr["ComoditiesName"].ToString().Trim();
                Title = "├ " + Title;
                ddl.Items.Add(new ListItem(Title, Id));
            }
        }
        #region

        //==================================以下为文件操作函数===================================
        /// <summary>
        /// 删除单个文件
        /// </summary>
        /// <param name="_filepath">文件相对路径</param>
        protected void DeleteFile(string _filepath)
        {
            if (string.IsNullOrEmpty(_filepath))
            {
                return;
            }
            string fullpath = Utils.GetMapPath(_filepath);
            if (File.Exists(fullpath))
            {
                File.Delete(fullpath);
            }
        }

        /// <summary>
        /// 生成缩略图的方法
        /// </summary>
        /// <param name="_filepath">文件相对路径</param>
        /// <returns></returns>
        protected string MakeThumbnail(string _filepath)
        {
            if (!string.IsNullOrEmpty(_filepath) && webset.IsThumbnail == 1)
            {
                string _filename = _filepath.Substring(_filepath.LastIndexOf("/") + 1);
                string _newpath = webset.WebFilePath;
                //检查保存的路径 是否有/开头结尾
                if (_newpath.StartsWith("/") == false)
                {
                    _newpath = "/" + _newpath;
                }
                if (_newpath.EndsWith("/") == false)
                {
                    _newpath = _newpath + "/";
                }
                _newpath = _newpath + "Thumbnail/";

                //检查是否有该路径没有就创建
                if (!Directory.Exists(Utils.GetMapPath(_newpath)))
                {
                    Directory.CreateDirectory(Utils.GetMapPath(_newpath));
                }
                //调用生成类方法
                ImageThumbnailMake.MakeThumbnail(_filepath, _newpath + _filename, webset.ProWidth, webset.ProHight, "Cut");

                return _newpath + _filename;
            }

            return _filepath;
        }

        /// <summary>
        /// 日志写入方法
        /// </summary>
        /// <param name="str"></param>
        protected void SaveLogs(string str)
        {
            if (webset.WebLogStatus == 0)
            {
                return;
            }
            //Cms.BLL.SystemLog bll = new Cms.BLL.SystemLog();
            //Cms.Model.SystemLog model = new Cms.Model.SystemLog();
            //if (Session["AdminName"] != null)
            //{
            //    model.UserName = Session["AdminName"].ToString();
            //}
            //if (HttpContext.Current.Request.UserHostAddress != null)
            //{
            //    model.IPAddress = HttpContext.Current.Request.UserHostAddress;
            //}
            //model.Title = str;
            //model.AddTime = DateTime.Now;
            //bll.Add(model);
        }

        /// <summary>
        /// 日志写入方法
        /// </summary>
        /// <param name="str"></param>
        public void SaveLogs(string username, string str)
        {
            if (webset.WebLogStatus == 0)
            {
                return;
            }
            //Cms.BLL.SystemLog bll = new Cms.BLL.SystemLog();
            //Cms.Model.SystemLog model = new Cms.Model.SystemLog();
            //model.UserName = username;
            //model.Title = str;
            //if (HttpContext.Current.Request.UserHostAddress != null)
            //{
            //    model.IPAddress = HttpContext.Current.Request.UserHostAddress;
            //}
            //model.AddTime = DateTime.Now;
            //bll.Add(model);
        }

        #endregion
    }
}