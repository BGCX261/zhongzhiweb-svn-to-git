using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cms.Web.Admin
{
    public partial class Top : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["AdminName"] == null || Session["AdminName"].ToString().Trim() == "")
                {
                    Response.Write("<script>alert('对不起,您没有登录！');parent.location.href='Login.aspx'</script>");
                    return;
                }
                else
                {
                    Cms.DAL.Admin dal = new DAL.Admin();
                    Cms.Model.Admin model = new Cms.Model.Admin();
                    model = dal.GetModelByName(Session["AdminName"].ToString());
                    if (model != null)
                    {
                        if (model.RealName.Length <= 6)
                            lblSignIn.Text = model.RealName;
                        else
                            lblSignIn.Text = model.RealName.Substring(0, 5) + "...";
                    }
                }
            }
        }
    }
}