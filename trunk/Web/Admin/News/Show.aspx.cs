using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cms.Web.Admin.News
{
    public partial class Show : System.Web.UI.Page
    {
        public string strid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["newsID"] != null && Request.Params["newsID"].Trim() != "")
                {
                    strid = Request.Params["newsID"];
                    int Id = (Convert.ToInt32(strid));
                    //赋值
                    ShowInfo(Id);
                }
            }
        }

        //赋值
        private void ShowInfo(int Id)
        {
            Cms.DAL.NewsInfo dal = new Cms.DAL.NewsInfo();
            Cms.Model.NewsInfo model = dal.GetModel(Id);
            this.lblId.Text = model.NewsID.ToString();
            this.lblTitle.Text = model.Title;
            this.lblAuthor.Text = model.Author;
            this.lblClassId.Text = model.ClassId.ToString();
            this.lblContent.Text =Cms.Common.Utils.ToTxt(model.Content);
            this.lblClick.Text = model.Click.ToString();
            this.lblIsLock.Text = model.IsLock.ToString();
            this.lblIsTop.Text = model.IsTop.ToString();
            this.lblPubTime.Text = model.PubTime.ToString();
        }

    }
}