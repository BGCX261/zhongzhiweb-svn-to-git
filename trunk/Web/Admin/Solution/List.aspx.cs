using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Cms.Web.UI;
using Maticsoft.Common;

namespace Cms.Web.Admin.Solution
{
    public partial class List : ManagePage
    {
        public int pcount = 0; //总条数

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //数据绑定
                RptBind("");
            }
        }

        #region 数据绑定
        public void RptBind(string strWhere)
        {
            Cms.DAL.Solutions dal = new Cms.DAL.Solutions();
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
            if (this.pcount > 0)
            {
                this.lbtnDel.Enabled = true;
            }
            else
            {
                this.lbtnDel.Enabled = false;
            }
            //绑定数据
            rptList.DataSource = pds;
            rptList.DataBind();
        }
        #endregion

        #region 批量删除
        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            Cms.DAL.Solutions bll = new DAL.Solutions();
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
                    bll.Delete(id);
                }
            }
            if (hasDeleted)
                MessageBox.Show(this, "批量删除成功！");
            else
                MessageBox.Show(this, "没有选中记录！");
            RptBind("");
        }
        #endregion

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            RptBind("");
        }

        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(((Label)e.Item.FindControl("lb_id")).Text);
            Cms.DAL.Solutions dal = new Cms.DAL.Solutions();
            Cms.Model.Solution model = dal.GetModel(id);
            switch (e.CommandName.ToLower())
            {
                case "ibtnlock":
                    if (model.IsLock == 1)
                        dal.UpdateField(id, "IsLock=0");
                    else
                        dal.UpdateField(id, "IsLock=1");
                    break;
            }
            RptBind("");
        }
    }
}