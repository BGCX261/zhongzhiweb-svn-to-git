using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Cms.Common;

namespace Cms.Web.UI
{
    public class Products
    {
        /// <summary>
        /// 热卖产品图片列表
        /// </summary>
        /// <returns></returns>
        public static string hotProdcutList()
        {
            Cms.DAL.ProductInfo dal = new Cms.DAL.ProductInfo();
            Cms.DAL.Channel chnDal = new Cms.DAL.Channel(); 
            StringBuilder strTxt = new StringBuilder();
            DataSet proSpecDS = dal.GetTopProductList(6, "IsTop > 0", " order by SpecificationsOrder");
            DataTable proSpecTBL = proSpecDS.Tables[0];
            if (proSpecTBL.Rows.Count > 0)
            {
                int colum = 1;
                for (int i = 0; i < proSpecTBL.Rows.Count; i++)
                {
                    DataRow proRow = proSpecTBL.Rows[i];
                    //标题
                    int brandId = int.Parse(proRow["BrandID"].ToString());
                    string title = chnDal.GetProductBrandTitle(brandId) + " " + proRow["Specifications"].ToString();
                    //内容
                    int nameId = int.Parse(proRow["ComoditiesNameId"].ToString());
                    string content = "商品名字：" + chnDal.GetProductNameTitle(nameId) + "<BR/>";

                    if (colum == 1)
                    {
                        strTxt.Append("<tr>");
                    }
                    strTxt.Append("<td width=\"310\" height=\"60\">");
                    strTxt.Append("<table cellpadding=\"1\" cellspacing=\"1\">");
                    strTxt.Append("<td>");
                    strTxt.Append("<a href=\"productView.aspx?specId=" + proRow["SpecificationsId"].ToString() + "\">");
                    strTxt.Append("<img src=\"Tools/Http_ImgLoad.ashx?w=80&h=60&gurl=" + proRow["SmallImgUrl"].ToString() + "\" height=\"60\" width=\"80\" border=\"1\"/>");
                    strTxt.Append("</a>");
                    strTxt.Append("</td>");
                    strTxt.Append("<td width=\"220\">");
                    strTxt.Append("<table cellpadding=\"1\" cellspacing=\"1\" style=\"position:relative;left:10px; width:210px; top: 0px;\">");
                    strTxt.Append("<tr>");
                    strTxt.Append("");
                    strTxt.Append("<td style=\"height:15px;\">");
                    strTxt.Append("<strong>" + title + "</strong>");
                    strTxt.Append("</td>");
                    strTxt.Append("</tr>");
                    strTxt.Append("<tr>");
                    strTxt.Append("<td align=\"left\" valign=\"top\">");
                    strTxt.Append(content + "[<a href=\"productView.aspx?specId=" + proRow["SpecificationsId"].ToString() + "\"><U>详细</U></a>]");
                    strTxt.Append("</td>");
                    strTxt.Append("</tr>");
                    strTxt.Append("</table>");
                    strTxt.Append("</td>");
                    strTxt.Append("</table>");
                    strTxt.Append("</td>");
                    if (colum == 2)
                    {
                        strTxt.Append("</tr>");
                        colum = 1;
                    }
                    else
                        ++colum;
                }
                if (colum == 2)
                {
                    strTxt.Append("</tr>");
                    colum = 1;
                }
            }
            else
                strTxt.Append("暂无热卖产品。");
            return strTxt.ToString();
        }
        #region  推荐产品
        public static string adviseProductList()
        {
            Cms.DAL.ProductInfo dal = new Cms.DAL.ProductInfo();
            Cms.DAL.Channel chnDal = new Cms.DAL.Channel();
            StringBuilder strTxt = new StringBuilder();
            DataSet proSpecDS = dal.GetTopProductList(5, "", " order by Click desc");
            DataTable proSpecTBL = proSpecDS.Tables[0];

            if (proSpecTBL.Rows.Count > 0)
            {
                strTxt.Append("<dl>");
                for (int j = 0; j < proSpecTBL.Rows.Count; j++)
                {
                    DataRow proRow = proSpecTBL.Rows[j];
                    int brandId = int.Parse(proRow["BrandID"].ToString());
                    string title = chnDal.GetProductBrandTitle(brandId) + " " + proRow["Specifications"].ToString();
                    strTxt.Append("<dd style=\"height: 22px;\">");
                    strTxt.Append("<a class=\"productClass02\" href=\"productView.aspx?specID=" + proRow["SpecificationsId"].ToString() + "\" style=\"position: relative; top: 5px; left: 15px;\">" + title + "</a>");
                    strTxt.Append("</dd>");
                }
                strTxt.Append("</dl>");
            }
            else
                strTxt.Append("暂无推荐产品！");

            return strTxt.ToString();
        }
        #endregion
    }
}