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
    public partial class ContactUS : ManagePage
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
            Cms.Model.Contents model = bll.GetModel(Cms.DAL.Contents.COMPANY_ADDRESS);
            this.address.Text = Cms.Common.Utils.ToTxt(model.Content);

            model = bll.GetModel(Cms.DAL.Contents.COMPANY_WEBSITE);
            this.website.Text = Cms.Common.Utils.ToTxt(model.Content);

            model = bll.GetModel(Cms.DAL.Contents.COMPANY_TELEPHONE);
            this.telephone.Text = Cms.Common.Utils.ToTxt(model.Content);

            model = bll.GetModel(Cms.DAL.Contents.COMPANY_FAX);
            this.fax.Text = Cms.Common.Utils.ToTxt(model.Content);

            model = bll.GetModel(Cms.DAL.Contents.COMPANY_POST_NUM);
            this.postnum.Text = Cms.Common.Utils.ToTxt(model.Content);
        }
        #endregion

        #region 内容管理
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Cms.DAL.Contents dal = new Cms.DAL.Contents();
            Cms.Model.Contents model = new Cms.Model.Contents();

            model.Title = Cms.DAL.Contents.COMPANY_ADDRESS;
            model.Content = Cms.Common.Utils.ToHtml(this.address.Text);
            dal.ModifyModel(model);

            model.Title = Cms.DAL.Contents.COMPANY_WEBSITE;
            model.Content = Cms.Common.Utils.ToHtml(this.website.Text);
            dal.ModifyModel(model);

            model.Title = Cms.DAL.Contents.COMPANY_TELEPHONE;
            model.Content = Cms.Common.Utils.ToHtml(this.telephone.Text);
            dal.ModifyModel(model);

            model.Title = Cms.DAL.Contents.COMPANY_FAX;
            model.Content = Cms.Common.Utils.ToHtml(this.fax.Text);
            dal.ModifyModel(model);

            model.Title = Cms.DAL.Contents.COMPANY_POST_NUM;
            model.Content = Cms.Common.Utils.ToHtml(this.postnum.Text);
            dal.ModifyModel(model);
            //保存日志
            MessageBox.Show(this, "公司简介编辑成功！");
        }
        #endregion

        protected void btnretset_Click(object sender, EventArgs e)
        {
            
        }

    }
}