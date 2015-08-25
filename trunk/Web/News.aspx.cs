using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Cms.Web
{
    public partial class News : System.Web.UI.Page
    {
        public int pcount = 0; //总条数
        public int classId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.Params["classId"] as string, out this.classId))
            {
                this.classId = 0;
            }

            if (!Page.IsPostBack)
            {
                RptBind("");
            }
            if ((Request.Params["classId"] != null) && (Request.Params["classId"].ToString() != ""))
            {
                int strId = Convert.ToInt32(Request.Params["classId"]);
                RptBind("ClassId=" + strId + "");
            }
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript'>menuEnable(4);</script>");
        }

        #region 列表绑定
        private void RptBind(string strWhere)
        {
            Cms.DAL.NewsInfo dal = new Cms.DAL.NewsInfo();
            if (String.IsNullOrEmpty(strWhere))
                strWhere = "IsLock = 0";
            else
                strWhere += " AND IsLock = 0";

            DataSet ds = dal.GetList(strWhere);
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
            if (this.pcount == 0)
            {
                this.lbmsg.Visible = true;
                this.lbmsg.Text = "暂时没有新闻";
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