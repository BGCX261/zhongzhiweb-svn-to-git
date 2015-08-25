using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Cms.Web.UI;
using Maticsoft.Common;

namespace Cms.Web.Admin.Job
{
    public partial class Edit : ManagePage
    {
        public int JobID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.Params["JobID"] as string, out this.JobID))
            {
                Response.Write("<script>alert('您要查看的信息参数不正确或不存在！');history.go(-1);</script>");
                return;
            }
            if (!Page.IsPostBack)
            {
                ShowInfo(this.JobID);
            }
        }

        #region 赋值操作
        private void ShowInfo(int Id)
        {
            Cms.DAL.JobInfo dal = new Cms.DAL.JobInfo();
            Cms.Model.JobInfo model = dal.GetModel(Id);
            this.position.Text = Cms.Common.Utils.ToTxt(model.Position);
            this.headCount.Text = model.HeadCount.ToString();
            this.requirement.Text = Cms.Common.Utils.ToTxt(model.Requirement);
            this.responsibility.Text = Cms.Common.Utils.ToTxt(model.Responsibility);
            this.jobOrder.Text = model.JobOrder.ToString();
            jobIsLock.SelectedValue = model.IsLock.ToString();
        }
        #endregion

        //编辑操作
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Cms.Model.JobInfo model = new Cms.Model.JobInfo();
            model.Id = this.JobID;
            model.Position = Cms.Common.Utils.ToHtml(this.position.Text);
            model.Responsibility = Cms.Common.Utils.ToHtml(this.responsibility.Text);
            model.HeadCount = int.Parse(this.headCount.Text);
            model.Requirement = Cms.Common.Utils.ToHtml(this.requirement.Text);
            model.IsLock = Convert.ToInt32(jobIsLock.SelectedValue);
            model.JobOrder = int.Parse(this.jobOrder.Text);

            Cms.DAL.JobInfo dal = new Cms.DAL.JobInfo();
            dal.Update(model);
            ////保存日志
            MessageBox.Show(this, "招聘编辑成功！");
        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            ShowInfo(this.JobID);
        }
    }
}