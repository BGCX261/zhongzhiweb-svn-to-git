using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Cms.Web.UI;
using Maticsoft.Common;

namespace Cms.Web.Admin.Solution
{
    public partial class Edit : ManagePage
    {
        public int SolutionID;
        protected Cms.Model.Solution model = new Cms.Model.Solution();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.Params["SolutionID"] as string, out this.SolutionID))
            {
                Response.Write("<script>alert('您要查看的信息参数不正确或不存在！');history.go(-1);</script>");
                return;
            }
            if (!Page.IsPostBack)
            {
                Cms.DAL.Solutions dal = new Cms.DAL.Solutions();
                model = dal.GetModel(SolutionID);
                ShowInfo();
            }
        }

        #region 赋值操作
        private void ShowInfo()
        {
            if (model != null)
            {
                this.caseTitle.Text = model.Title;
                this.description.Text = model.Description;
                this.solution.Text = model.SolutionPlan;
                this.SucCases.Text = model.SucCases;
                this.txtImgUrl.Text = model.ImageUrl;
                this.sortOrder.Text = model.SortOrder.ToString();
                isLock.SelectedValue = model.IsLock.ToString();
            }
        }
        #endregion

        //编辑操作
        protected void btnSave_Click(object sender, EventArgs e)
        {
            model.Id = this.SolutionID;
            model.Title = this.caseTitle.Text;
            model.Description = this.description.Text;
            model.SolutionPlan = this.solution.Text;
            model.SucCases = this.SucCases.Text;
            model.ImageUrl = this.txtImgUrl.Text;
            model.SortOrder = Convert.ToInt32(sortOrder.Text); ;
            model.IsLock = Convert.ToInt32(isLock.SelectedValue);

            Cms.DAL.Solutions dal = new Cms.DAL.Solutions();
            dal.Update(model);
            ////保存日志
            MessageBox.Show(this, "解决方案修改成功！");
        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            ShowInfo();
        }
    }
}