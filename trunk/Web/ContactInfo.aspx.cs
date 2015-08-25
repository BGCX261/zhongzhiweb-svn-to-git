using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Cms.Web
{
    public partial class ContactInfo : System.Web.UI.Page
    {
        public string StrTitle = "";
        public string StrContent = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript'>menuEnable(5);</script>");
        }
        public string getCompanyAddress()
        {
            Cms.DAL.Contents dal = new Cms.DAL.Contents();
            Cms.Model.Contents model = dal.GetModel(Cms.DAL.Contents.COMPANY_ADDRESS);
            return model.Content;
        }
        public string getCompanyWebSite()
        {
            Cms.DAL.Contents dal = new Cms.DAL.Contents();
            Cms.Model.Contents model = dal.GetModel(Cms.DAL.Contents.COMPANY_WEBSITE);
            return model.Content;
        }
        public string getTelephone()
        {
            Cms.DAL.Contents dal = new Cms.DAL.Contents();
            Cms.Model.Contents model = dal.GetModel(Cms.DAL.Contents.COMPANY_TELEPHONE);
            return model.Content;
        }
        public string getFax()
        {
            Cms.DAL.Contents dal = new Cms.DAL.Contents();
            Cms.Model.Contents model = dal.GetModel(Cms.DAL.Contents.COMPANY_FAX);
            return model.Content;
        }
        public string getPostNumber()
        {
            Cms.DAL.Contents dal = new Cms.DAL.Contents();
            Cms.Model.Contents model = dal.GetModel(Cms.DAL.Contents.COMPANY_POST_NUM);
            return model.Content;
        }
    }
}