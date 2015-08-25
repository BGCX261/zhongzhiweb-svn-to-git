using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Cms.Web
{
    public partial class Solution : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript'>menuEnable(3);</script>");
        }
        public string getSolutionSummary()
        {
            Cms.DAL.Contents dal = new Cms.DAL.Contents();
            Cms.Model.Contents model = dal.GetModel(Cms.DAL.Contents.SOLUTION_SUMMARY);
            return model.Content;
        }
    }
}