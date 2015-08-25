using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Cms.Web
{
    public partial class Manager : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string getInvoiceTitle()
        {
            Cms.DAL.Contents dal = new Cms.DAL.Contents();
            Cms.Model.Contents model = dal.GetModel(Cms.DAL.Contents.COMPANY_NAME);
            return model.Content;
        }

        public string getLogoImage()
        {
            Cms.DAL.Contents dal = new Cms.DAL.Contents();
            Cms.Model.Contents model = dal.GetModel(Cms.DAL.Contents.COMPANY_LOGO);
            return model.Content;
        }
        public string getStartPage()
        {
            Cms.DAL.Contents dal = new Cms.DAL.Contents();
            Cms.Model.Contents model = dal.GetModel(Cms.DAL.Contents.COMPANY_START_PAGE);
            return model.Content;
        }
    }
}