using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Cms.Common;

namespace Cms.Web.UI
{
    public class Channel
    {
        #region  产品类别
        public static string productClassList()
        {
            Cms.DAL.Channel dal = new Cms.DAL.Channel();            
            StringBuilder strTxt = new StringBuilder();
            DataSet proTypeDS = dal.GetProductTypeList("");
            DataTable proTypeTBL = proTypeDS.Tables[0];

            if (proTypeTBL.Rows.Count > 0)
            {
                for (int i = 0; i < proTypeTBL.Rows.Count; i++)
                {
                    // 产品分类
                    DataRow typeRow = proTypeTBL.Rows[i];
                    strTxt.Append("<dl>");
                    strTxt.Append("<dt class=\"productGroup01\" style=\"height: 26px;\">");
                    strTxt.Append("<a class=\"productClass01\" href=\"ProductList.aspx?typeID=" + typeRow["TypeId"].ToString() + "\" style=\"position: relative; top: 5px; left: 10px;\">" + typeRow["ComoditiesType"].ToString() + "</a>");
                    strTxt.Append("</dt>");

                    //产品品牌
                    DataSet proBrandDS = dal.GetProductBrandList("TypeID = " + typeRow["TypeId"].ToString());
                    DataTable proBrandTBL = proBrandDS.Tables[0];
                    for (int j = 0; j < proBrandTBL.Rows.Count; j++)
                    {
                        DataRow brandRow = proBrandTBL.Rows[j];
                        strTxt.Append("<dd>");
                        strTxt.Append("<dl>");
                        strTxt.Append("<dt class=\"productGroup02\" style=\"height: 22px;\">");
                        strTxt.Append("<a class=\"productClass02\" href=\"ProductList.aspx?typeID=" + typeRow["TypeId"].ToString() + "&brandID=" + brandRow["brandID"].ToString() + "\" style=\"position: relative; top: 5px; left: 20px;\"><strong>" + brandRow["Brand"].ToString() + "</strong></a>");
                        strTxt.Append("</dt>");
                        //产品名称
                        DataSet proNameDS = dal.GetProductNameList("TypeID = " + typeRow["TypeId"].ToString() + "AND brandID = " + brandRow["brandID"].ToString());
                        DataTable proNameTBL = proNameDS.Tables[0];
                        for (int k = 0; k < proNameTBL.Rows.Count; k++)
                        {
                            DataRow nameRow = proNameTBL.Rows[k];
                            strTxt.Append("<dd style=\"height: 22px;\">");
                            strTxt.Append("<a class=\"productClass03\" href=\"ProductList.aspx?typeID=" + typeRow["TypeId"].ToString() + "&brandID=" + brandRow["brandID"].ToString() + "&nameID=" + nameRow["ComoditiesNameID"].ToString() + "\" style=\"position: relative; top: 5px; left: 30px;\">" + nameRow["ComoditiesName"].ToString() + "</a>");
                            strTxt.Append("</dd>");
                        }
                        if (j < proBrandTBL.Rows.Count - 1)
                        {
                            strTxt.Append("<dd class=\"productGroup03\"></dd>");
                        }
                        strTxt.Append("<dl>");
                        strTxt.Append("</dd>");
                    }
                    strTxt.Append("</dl>");
                }
            }
            else
                strTxt.Append("暂无产品分类！");

            return strTxt.ToString();
        }
        #endregion

        #region 活动类别
        public static string newsClassList()
        {
            Cms.DAL.Channel dal = new Cms.DAL.Channel();            
            StringBuilder strTxt = new StringBuilder();
            DataSet newsDS = dal.GetNewsClassList("");
            DataTable tbl = newsDS.Tables[0];

            if (tbl.Rows.Count > 0)
            {
                strTxt.Append("<dl>");
                for (int j = 0; j < tbl.Rows.Count; j++)
                {
                    DataRow dr = tbl.Rows[j];
                    strTxt.Append("<dd style=\"background-color: rgb(239,239,239); height: 26px;\">");
                    strTxt.Append("<a class=\"channelClass01\" href=\"News.aspx?classID=" + dr["ClassID"].ToString() + "\" style=\"position: relative;top: 8px; left: 15px;\">" + dr["Title"].ToString() + "</a>");
                    strTxt.Append("</dd>");
                }
                strTxt.Append("</dl>");
            }
            else
                strTxt.Append("暂无活动栏目！");
            return strTxt.ToString();
        }
        #endregion

        #region 概况栏目
        public static string aboutList()
        {
            StringBuilder strTxt = new StringBuilder();
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Title", typeof(string));
            tbl.Columns.Add("Url", typeof(string));
            object[] aValues = { "公司简介", "About.aspx" };
            tbl.LoadDataRow(aValues, true);
            object[] aValues1 = { "招聘信息", "Jobs.aspx" };
            tbl.LoadDataRow(aValues1, true);
            object[] aValues2 = { "站点地图", "SiteMap.aspx" };
            tbl.LoadDataRow(aValues2, true);
            object[] aValues3 = { "联系我们", "ContactInfo.aspx" };
            tbl.LoadDataRow(aValues3, true);
            
            if (tbl.Rows.Count > 0)
            {
                strTxt.Append("<dl>");
                for (int j = 0; j < tbl.Rows.Count; j++)
                {
                    DataRow dr2 = tbl.Rows[j];
                    strTxt.Append("<dd style=\"background-color: rgb(239,239,239); height: 26px;\">");
                    strTxt.Append("<a class=\"channelClass01\" href=\""+ dr2["Url"].ToString() +"\" style=\"position: relative;top: 5px; left: 15px;\">" + dr2["Title"].ToString() + "</a>");
                    strTxt.Append("</dd>");
                }
                strTxt.Append("</dl>");
            }
            else
                strTxt.Append("暂无栏目！");
            return strTxt.ToString();
        }
        #endregion

        #region 产品标题名称
        public static string ViewProductListTitle(int typeId, int brandID, int nameID)
        {
            StringBuilder strTxt = new StringBuilder();
            Cms.DAL.Channel dal = new Cms.DAL.Channel();
            if (dal.ExistsProductType(typeId))
            {
                if (dal.ExistsProductBrand(brandID))
                {
                    strTxt.Append("<a class=\"navLink\" href=\"ProductList.aspx?typeID=" + typeId.ToString() + "\">" + dal.GetProductTypeTitle(typeId) + "</a>");
                    if (dal.ExistsProductName(nameID))
                    {
                        strTxt.Append("><a class=\"navLink\" href=\"ProductList.aspx?typeID=" + typeId.ToString() + "&brandID=" + brandID.ToString() + "\">" + dal.GetProductBrandTitle(brandID) + "</a>");
                        strTxt.Append(">" + dal.GetProductNameTitle(nameID));
                    }
                    else
                        strTxt.Append(">" + dal.GetProductBrandTitle(brandID));
                }
                else
                    strTxt.Append(dal.GetProductTypeTitle(typeId));
            }
            else
                strTxt.Append( "所有列表");
            return strTxt.ToString();
        }
        #endregion

        #region 输出活动栏目名称
        public static string ViewNewsListTitle(int classId)
        {
            StringBuilder strTxt = new StringBuilder();
            Cms.DAL.Channel dal = new Cms.DAL.Channel();
            if (dal.ExistsNewsClass(classId))
            {
                strTxt.Append(dal.GetNewsClassTitle(classId));
            }
            else
                strTxt.Append("所有列表");

            return strTxt.ToString();
        }
        #endregion
    }
}