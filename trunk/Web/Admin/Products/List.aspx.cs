using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Cms.Web.UI;
using Maticsoft.Common;

namespace Cms.Web.Admin.Products
{
    public partial class List : ManagePage
    {
        public int pcount = 0; //总条数
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["strWhereProduct"] = null;
                //数据绑定
                RptBind();
                //绑定类别
                ProductTypeTreeBind("所有类型", this.ddlTypeId);
                ddlBrandId.Enabled = false;
                ddlNameId.Enabled = false;
            }
        }

        #region 数据绑定
        public void RptBind()
        {
            string strWhere = "";
            if (Session["strWhereProduct"] != null && Session["strWhereProduct"].ToString() != "")
            {
                strWhere += Session["strWhereProduct"].ToString();
            }

            Cms.DAL.ProductInfo dal = new Cms.DAL.ProductInfo();
            DataSet ds = dal.GetProductList(strWhere);
            DataView dv = ds.Tables[0].DefaultView;
            //利用PAGEDDAGASOURCE类来分页
            PagedDataSource pds = new PagedDataSource();
            AspNetPager1.RecordCount = dv.Count;
            pcount = dv.Count;
            pds.DataSource = dv;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;
            //获得总条数
            pcount = dv.Count;
            //绑定数据
            rptList.DataSource = pds;
            rptList.DataBind();
        }
        #endregion

        #region 设置操作
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(((Label)e.Item.FindControl("lb_id")).Text);
            Cms.DAL.ProductInfo dal = new Cms.DAL.ProductInfo();
            Cms.Model.ProductInfo model = dal.GetModel(id);
            switch (e.CommandName.ToLower())
            {
                case "ibtntop":
                    if (model.IsTop == 1)
                        dal.UpdateField(id, "IsTop=0");
                    else
                        dal.UpdateField(id, "IsTop=1");
                    break;
            }
            RptBind();
        }
        #endregion

        protected string isUpVisible(string strIndex)
        {
            //int index = int.Parse(strIndex);
            //return (index != 0).ToString();
            return true.ToString();
        }

        #region 批量删除
        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            Cms.DAL.ProductInfo dal = new Cms.DAL.ProductInfo();
            bool hasDeleted = false;
            //批量删除
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((Label)rptList.Items[i].FindControl("lb_id")).Text);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                if (cb.Checked)
                {
                    //删除记录
                    hasDeleted = true;
                    dal.Delete(id);
                }
            }
            if (hasDeleted)
                MessageBox.Show(this, "批量删除成功！");
            else
                MessageBox.Show(this, "没有选中记录！");
            RptBind();
        }
        #endregion

        //翻页
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            RptBind();
        }

        #region 类型索引
        protected void ddlTypeId_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selType = this.ddlTypeId.SelectedValue;
            string strsql = "";
            if (selType != "")
            {
                strsql += " and TypeId='" + selType + "'";
                ProductBrandTreeBind("所有品牌", ddlBrandId, "TypeId='" + selType + "'");
                ddlBrandId.Enabled = true;
                ddlNameId.Enabled = false;
            }
            else
            {
                ddlBrandId.Enabled = false;
                ddlNameId.Enabled = false;
            }
            if (strsql != "")
            {
                Session["strWhereProduct"] = " (1=1) " + strsql;
            }
            else
            {
                Session["strWhereProduct"] = "";
            }
            //重新绑定数据
            RptBind();
        }
        #endregion

        #region 品牌索引
        protected void ddlBrandId_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selType = this.ddlTypeId.SelectedValue;
            string selBrand = this.ddlBrandId.SelectedValue;
            string strsql = "";
            if (selBrand != "")
            {
                strsql += " and TypeId='" + selType + "' AND BrandId='" + selBrand + "'";

                ProductNameTreeBind("所有名称", ddlNameId, "TypeId='" + selType + "' AND BrandId='" + selBrand + "'");
                ddlNameId.Enabled = true;
            }
            else
            {
                strsql += " and TypeId='" + selType + "'";
                ddlNameId.Enabled = false;
            }
            if (strsql != "")
            {
                Session["strWhereProduct"] = " (1=1) " + strsql;
            }
            else
            {
                Session["strWhereProduct"] = "";
            }
            //重新绑定数据
            RptBind();
        }
        #endregion

        #region 名称索引
        protected void ddlNameId_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selType = this.ddlTypeId.SelectedValue;
            string selBrand = this.ddlBrandId.SelectedValue;
            string selName = this.ddlNameId.SelectedValue;
            string strsql = "";
            if (selName != "")
            {
                strsql += " and TypeId='" + selType + "' AND BrandId='" + selBrand + "' AND ComoditiesNameID='" + selName + "'";
            }
            else
            {
                strsql += " and TypeId='" + selType + "' AND BrandId='" + selBrand + "'";
            }
            if (strsql != "")
            {
                Session["strWhereProduct"] = " (1=1) " + strsql;
            }
            else
            {
                Session["strWhereProduct"] = "";
            }
            //重新绑定数据
            RptBind();
        }
        #endregion

        #region 查询
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            string strsql = "";
            string SupplierName = this.txtKeywords.Text.Trim();
            if (SupplierName != "")
            {
                strsql += "Specifications like '%" + SupplierName + "%'";
            }
            else
            {
                return;
            }

            //匹配类型名
            Cms.DAL.Channel dal = new Cms.DAL.Channel();
            DataSet ds = dal.GetProductTypeList("ComoditiesType like '%" + SupplierName + "%'");
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                strsql += "OR TypeID in (";
                
                for (int i =0; i < dt.Rows.Count; ++i)
                {
                    DataRow dr = dt.Rows[i];
                    string Id = dr["TypeId"].ToString();
                    strsql += Id;
                    if (i != dt.Rows.Count - 1)
                        strsql += ",";
                }
                strsql += ")";
            }
            //匹配品牌名
            ds = dal.GetProductBrandList("Brand like '%" + SupplierName + "%'");
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                strsql += "OR BrandID in (";

                for (int i = 0; i < dt.Rows.Count; ++i)
                {
                    DataRow dr = dt.Rows[i];
                    string Id = dr["BrandID"].ToString();
                    strsql += Id;
                    if (i != dt.Rows.Count - 1)
                        strsql += ",";
                }
                strsql += ")";
            }

            ds = dal.GetProductNameList("ComoditiesName like '%" + SupplierName + "%'");
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                strsql += "OR ComoditiesNameID in (";

                for (int i = 0; i < dt.Rows.Count; ++i)
                {
                    DataRow dr = dt.Rows[i];
                    string Id = dr["ComoditiesNameID"].ToString();
                    strsql += Id;
                    if (i != dt.Rows.Count - 1)
                        strsql += ",";
                }
                strsql += ")";
            }
            if (strsql != "")
            {
                Session["strWhereProduct"] = strsql;
            }
            else
            {
                Session["strWhereProduct"] = "";
            }

            //重新绑定数据
            RptBind();
        }
        #endregion
    }
}