using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cms.Web.Admin
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["AdminNo"] == null || Session["AdminName"] == null)
                {
                    Response.Clear();
                    Response.Write("<script language=javascript>window.alert('您没有权限进入本页！\\n请登录或与管理员联系！');history.back();</script>");
                    Response.End();
                }
            }
        }
    }

}