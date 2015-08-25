using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace Cms.Web
{
    public partial class ProductList : System.Web.UI.Page
    {
        public int pcount = 0; //总条数
        public int typeID;
        public int brandID;
        public int nameID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.Params["typeID"] as string, out this.typeID))
            {
                this.typeID = 0;
            }
            if (!int.TryParse(Request.Params["brandID"] as string, out this.brandID))
            {
                this.brandID = 0;
            }
            if (!int.TryParse(Request.Params["nameID"] as string, out this.nameID))
            {
                this.nameID = 0;
            }
            if (!Page.IsPostBack)
            {
                this.lbmsg.Visible = false;
                RptBind("");
            }
            if ((Request.Params["typeID"] != null) && (Request.Params["typeID"].ToString() != ""))
            {
                int strTypeId = Convert.ToInt32(Request.Params["typeID"]);
                StringBuilder strTxt = new StringBuilder();
                strTxt.Append("typeID=" + strTypeId + "");
                if ((Request.Params["brandID"] != null) && (Request.Params["brandID"].ToString() != ""))
                {
                    int strBrandId = Convert.ToInt32(Request.Params["brandID"]);
                    strTxt.Append(" And brandID=" + strBrandId + "");
                    if ((Request.Params["nameID"] != null) && (Request.Params["nameID"].ToString() != ""))
                    {
                         int strNameId = Convert.ToInt32(Request.Params["nameID"]);
                        strTxt.Append(" And ComoditiesNameID=" + strNameId + "");
                    }
                }
                RptBind( strTxt.ToString() );
            }
            ClientScript.RegisterStartupScript(this.GetType(), "",  "<script type='text/javascript'>menuEnable(2);</script>");
        }
        #region 列表绑定
        private void RptBind(string strWhere)
        {
            Cms.DAL.ProductInfo dal = new Cms.DAL.ProductInfo();
            DataSet ds = dal.GetProductList(strWhere);
            DataView dv = ds.Tables[0].DefaultView;
            //利用PAGEDDAGASOURCE类来分页
            PagedDataSource pds = new PagedDataSource();
            AspNetPager1.RecordCount = dv.Count;
            pds.DataSource = dv;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;
            //获得总条数
            pcount = dv.Count;
            if (this.pcount < 0)
            {
                this.lbmsg.Visible = true;
                this.lbmsg.Text = "暂时没有产品";
            }
            //绑定数据
            rptList.DataSource = pds;
            rptList.DataBind();
        }
        #endregion

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            RptBind("");
        }
    }
}