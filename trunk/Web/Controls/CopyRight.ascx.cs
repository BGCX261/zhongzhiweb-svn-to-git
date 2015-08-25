using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Cms.Web.Controls
{
    public partial class CopyRight1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string getCopyRight()
        {
            Cms.DAL.Contents dal = new Cms.DAL.Contents();
            Cms.Model.Contents model = dal.GetModel(Cms.DAL.Contents.COMPANY_COPYRIGHT);
            return model.Content;
        }
    }
}