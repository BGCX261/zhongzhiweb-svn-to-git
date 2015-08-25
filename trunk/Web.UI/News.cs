using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Cms.Common;

namespace Cms.Web.UI
{
    public class News
    {
        #region 最新活动
        public static string latestNewsList()
        {
            Cms.DAL.NewsInfo dal = new Cms.DAL.NewsInfo();
            StringBuilder strTxt = new StringBuilder();
            DataSet ds = dal.GetList(5, "IsTop > 0 AND IsLock = 0", " PubTime desc");
            DataTable tbl = ds.Tables[0];

            if (tbl.Rows.Count > 0)
            {
                strTxt.Append("<dl>");
                for (int j = 0; j < tbl.Rows.Count; j++)
                {
                    DataRow row = tbl.Rows[j];
                    strTxt.Append("<dd style=\"height: 24px;\">");
                    strTxt.Append("<a class=\"productClass02\" href=\"NewsView.aspx?newsID=" + row["newsID"].ToString() + "\" style=\"position: relative;top: 5px; left: 15px;\">" + row["Title"].ToString() + "</a>");
                    strTxt.Append("</dd>");
                }
                strTxt.Append("</dl>");
            }
            else
                strTxt.Append("暂无活动！");
            return strTxt.ToString();
        }
        #endregion
    }
}
