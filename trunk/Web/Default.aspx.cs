using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

namespace Cms.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.searchBtn.Click += new ImageClickEventHandler(this.siteSearch);
        }
        //private void siteSearch(object sender, System.EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(this.searchBox.Text.ToString()))
        //    {
        //        Response.Write("<script>location.href='http://www.baidu.com/s?si=" + ConfigurationManager.AppSettings["CompanyWebSite"] + "&cl=3&ct=2097152&tn=baidulocal&word=" + this.searchBox.Text.ToString() + "';</script>");
        //    }
        //}

        public string getCompanyDescription()
        {
            Cms.DAL.Contents dal = new Cms.DAL.Contents();
            Cms.Model.Contents model = dal.GetModel(Cms.DAL.Contents.HOME_LEFT_SUMMARY);
            return model.Content;
        }
    }
}