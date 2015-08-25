using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Cms.Web.UI;
using System.Text;
using Maticsoft.Common;

namespace Cms.Web.Admin.Manage
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
            Cms.DAL.Admin bll = new Cms.DAL.Admin();
            DataSet ds = bll.GetList(strWhere);
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

            //禁止编辑第一个元素
            int userID = int.Parse(Session["AdminNo"].ToString());
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((Label)rptList.Items[i].FindControl("lb_id")).Text);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                if (id == 1)
                {
                    cb.Enabled = false;
                    cb.Visible = false;
                }
                else if (userID != 1 && userID != id)
                {
                    cb.Enabled = false;
                }
            }
        }
        #endregion

        #region 批量删除
        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            Cms.DAL.Admin dal = new DAL.Admin();
            //批量删除
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((Label)rptList.Items[i].FindControl("lb_id")).Text);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("cb_id");
                if (cb.Checked)
                {
                    //删除记录
                    dal.Delete(id);
                }
            }
            MessageBox.Show(this, "批量删除成功！");
            RptBind("");
        }
        #endregion

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            RptBind("");
        }
        protected string getOperation(string id)
        {
            if (Session["AdminNo"] == null || Session["AdminNo"].ToString().Trim() == "")
            {
               Response.Write("<script>alert('对不起,您没有登录！');parent.location.href='Login.aspx'</script>");
               return "";
            }

            int userID = int.Parse(Session["AdminNo"].ToString());
            StringBuilder str = new StringBuilder();
            if (userID == 1 || Session["AdminNo"].ToString() == id)
            {
                str.Append("<span><a href=\"Edit.aspx?userid=" + id +"\">编辑</a></span>");
            }
            else
            {
                str.Append("无权限");
            }
            return str.ToString();
        }
    }
}