using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using Cms.Common;

namespace Cms.Web
{
    public partial class SiteMap : System.Web.UI.Page
    {
        public string StrTitle = "";
        public string StrContent = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript'>menuEnable(5);</script>");
        }
        protected string outputProductSites()
        {
            Cms.DAL.Channel dal = new Cms.DAL.Channel();
            StringBuilder strTxt = new StringBuilder();
            DataSet brandDS = dal.GetProductBrandList("");
            DataTable tbl = brandDS.Tables[0];

            if (tbl.Rows.Count > 0)
            {
                for (int j = 0; j < tbl.Rows.Count; j++)
                {
                    DataRow dr = tbl.Rows[j];
                    if ((j + 1) % 6 == 0)
                        strTxt.Append("</br>");
                    strTxt.Append("<a class=\"siteLink\" href=\"ProductList.aspx?brandID=" + dr["BrandID"].ToString() + "\">" + dr["Brand"].ToString() + "</a>&nbsp;&nbsp;");
                }
            }
            else
                strTxt.Append("暂无品牌！");
            return strTxt.ToString();
        }
        protected string outputNewsSites()
        {
            Cms.DAL.Channel dal = new Cms.DAL.Channel();
            StringBuilder strTxt = new StringBuilder();
            DataSet newsDS = dal.GetNewsClassList("");
            DataTable tbl = newsDS.Tables[0];

            if (tbl.Rows.Count > 0)
            {
                for (int j = 0; j < tbl.Rows.Count; j++)
                {
                    DataRow dr = tbl.Rows[j];
                    if ((j + 1) % 6 == 0)
                        strTxt.Append("</br>");
                    strTxt.Append("<a class=\"siteLink\" href=\"News.aspx?classID=" + dr["ClassID"].ToString() + "\">" + dr["Title"].ToString() + "</a>&nbsp;&nbsp;");
                }
            }
            else
                strTxt.Append("暂无活动栏目！");
            return strTxt.ToString();
        }
    }
}