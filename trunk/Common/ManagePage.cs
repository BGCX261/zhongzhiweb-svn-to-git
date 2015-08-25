using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace Cms.Common
{
    public class ManagePage 
    {
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
            Cms.BLL.SystemLog bll = new Cms.BLL.SystemLog();
            Cms.Model.SystemLog model = new Cms.Model.SystemLog();
            if (Session["AdminName"] != null)
            {
                model.UserName = Session["AdminName"].ToString();
            }
            if (HttpContext.Current.Request.UserHostAddress != null)
            {
                model.IPAddress = HttpContext.Current.Request.UserHostAddress;
            }
            model.Title = str;
            model.AddTime = DateTime.Now;
            bll.Add(model);
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
            Cms.BLL.SystemLog bll = new Cms.BLL.SystemLog();
            Cms.Model.SystemLog model = new Cms.Model.SystemLog();
            model.UserName = username;
            model.Title = str;
            if (HttpContext.Current.Request.UserHostAddress != null)
            {
                model.IPAddress = HttpContext.Current.Request.UserHostAddress;
            }
            model.AddTime = DateTime.Now;
            bll.Add(model);
        }     

        #endregion

    }
}