using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cms.Web.Admin
{
    public partial class Relogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["AdminNo"] = null;
            Session["AdminName"] = null;

            Session.Remove("AdminName");
            Response.Redirect("Login.aspx");
        }
    }
}