using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Cms.Common;

namespace Cms.Web.UI
{
    public class JobInfo
    {
        #region 最新活动
        public static string jobList()
        {
            Cms.DAL.JobInfo dal = new Cms.DAL.JobInfo();
            StringBuilder strTxt = new StringBuilder();
            DataSet ds = dal.GetList("IsLock = 0");
            DataTable tbl = ds.Tables[0];

            if (tbl.Rows.Count > 0)
            {
                for (int j = 0; j < tbl.Rows.Count; j++)
                {
                    DataRow row = tbl.Rows[j];
                    strTxt.Append("<p style=\"font-size:14px;color:#808080;\"><strong style=\"font-size:14px;color:#505050;\">" + row["Position"].ToString() + "</strong><br />");
                    if (!string.IsNullOrEmpty(row["Responsibility"].ToString()))
                    {
                        strTxt.Append("工作职责：<br />");
                        strTxt.Append(row["Responsibility"].ToString());
                        strTxt.Append("<br />");
                    }
                    if (!string.IsNullOrEmpty(row["Requirement"].ToString()))
                    {
                        strTxt.Append("任职要求：<br />");
                        strTxt.Append(row["Requirement"].ToString());
                        strTxt.Append("<br />");
                    }
                    if (!string.IsNullOrEmpty(row["HeadCount"].ToString()))
                    {
                        strTxt.Append("招聘人数：" + row["HeadCount"].ToString());
                        strTxt.Append("<br />");
                    }
                    strTxt.Append("<br /><p>");
                }
            }
            else
                strTxt.Append("暂无招聘信息！");
            return strTxt.ToString();
        }  
        #endregion
    }
}
