using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Cms.Web.UI;
using Maticsoft.Common;

namespace Cms.Web.Admin.Contents
{
    public partial class HomePage : ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //赋值
                ShowInfo();
            }
        }

        #region 赋值操作
        private void ShowInfo()
        {
            Cms.DAL.Contents bll = new Cms.DAL.Contents();
            Cms.Model.Contents model = bll.GetModel(Cms.DAL.Contents.HOME_LEFT_SUMMARY);
            this.leftSummary.Text = Cms.Common.Utils.ToTxt(model.Content);

            this.logoImgUrl.Text = getLogoImage();
            this.startImgUrl.Text = getStartPage();
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
        #endregion

        #region 内容管理
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Cms.DAL.Contents dal = new Cms.DAL.Contents();
            Cms.Model.Contents model = new Cms.Model.Contents();

            model.Title = Cms.DAL.Contents.COMPANY_LOGO;
            model.Content = Cms.Common.Utils.ToHtml(this.logoImgUrl.Text);
            dal.ModifyModel(model);

            model.Title = Cms.DAL.Contents.COMPANY_START_PAGE;
            model.Content = Cms.Common.Utils.ToHtml(this.startImgUrl.Text);
            dal.ModifyModel(model);

            model.Title = Cms.DAL.Contents.HOME_LEFT_SUMMARY;
            model.Content = Cms.Common.Utils.ToHtml(leftSummary.Text);
            dal.ModifyModel(model);

            //保存日志
            MessageBox.Show(this, "公司首页编辑成功！");
        }
        #endregion

        protected void btnretset_Click(object sender, EventArgs e)
        {
            
        }

    }
}