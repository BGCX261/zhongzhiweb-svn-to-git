using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Cms.Common;

namespace Cms.Web.UI
{
    public class Solutions
    {
        #region  解决方案
        public static string solutionList()
        {
            Cms.DAL.Solutions dal = new Cms.DAL.Solutions();
            StringBuilder strTxt = new StringBuilder();
            DataSet ds = dal.GetList("IsLock = 0");
            DataTable tbl = ds.Tables[0];

            if (tbl.Rows.Count > 0)
            {
                for (int j = 0; j < tbl.Rows.Count; j++)
                {
                    DataRow row = tbl.Rows[j];
                    strTxt.Append("<table width=\"900\" height=\"200\" cellpadding=\"0\" cellspacing=\"0\" style=\"position:relative;left:50px;\">");
                    strTxt.Append("<tr>");
                    strTxt.Append("<td width=\"200\" align=\"right\" valign=\"top\">");
                    strTxt.Append("<img src=\"Tools/Http_ImgLoad.ashx?w=180&h=135&gurl=" + row["ImageUrl"].ToString() + "\" width=\"180\" height=\"135\" style=\"position:relative;top:20px;right:10px;\"/>"); 
                    strTxt.Append("</td>");
                    strTxt.Append("<td width=\"5\" valign=\"middle\">");
                    strTxt.Append("<img src=\"Images/vdivider.gif\" width=\"10\" height=\"150\"/>");
                    strTxt.Append("</td>");
                    strTxt.Append("<td width=\"695\" valign=\"top\">");
                    strTxt.Append("<div class=\"divider02\" width=\"100%\" style=\"position:relative;top:10px;\"></div>");
                    strTxt.Append("<div  style=\"position:relative;top:15px; left:25px;\">");
                    strTxt.Append("<ul>");
                    strTxt.Append("<li><span class=\"solutionText01\">" + row["CaseTitle"].ToString() + "：</span><span class=\"solutionText02\">" + row["Description"].ToString() + "</span></li>");
                    strTxt.Append("<li><span class=\"solutionText01\">解决方案：</span><span class=\"solutionText02\">" + row["Solution"].ToString() + "</span></li>");
                    if (!string.IsNullOrEmpty(row["SucCases"].ToString()))
                         strTxt.Append("<li><span class=\"solutionText01\">成功案例：</span><span class=\"solutionText02\">"+row["SucCases"].ToString()+"</span></li>");
                    strTxt.Append("</ul>");
                    strTxt.Append("</div>");
                    strTxt.Append("</td>");
                    strTxt.Append("</tr>");
                    strTxt.Append("</table>");
                }
            }
            else
                strTxt.Append("暂无解决方案！");

            return strTxt.ToString();
        }
        #endregion
    }
}
