using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using Cms.Web.UI;

namespace Cms.Web.Admin.Job
{
    public partial class Add : ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        //添加招聘
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (this.position.Text.Trim().Length == 0)
            {
                strErr += "岗位职称不能为空！\\n";
            }
            if (this.headCount.Text.Trim().Length == 0)
            {
                strErr += "招聘人数不能为空！\\n";
            }
            if (this.requirement.Text.Trim().Length == 0)
            {
                strErr += "招聘要求不能为空！\\n";
            }
            if (this.responsibility.Text.Trim().Length == 0)
            {
                strErr += "岗位职责不能为空！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }

            Cms.Model.JobInfo model = new Cms.Model.JobInfo();
            model.Position = Cms.Common.Utils.ToHtml(this.position.Text);
            model.Responsibility = Cms.Common.Utils.ToHtml(this.responsibility.Text);
            model.HeadCount = int.Parse(this.headCount.Text);
            model.Requirement = Cms.Common.Utils.ToHtml(this.requirement.Text);
            model.JobOrder = Convert.ToInt32(jobOrder.Text); ;
            model.IsLock = Convert.ToInt32(jobIsLock.SelectedValue);

            Cms.DAL.JobInfo dal = new Cms.DAL.JobInfo();
            dal.Add(model);
            //保存日志
            MessageBox.Show(this, "招聘增加成功！");
        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            this.position.Text = "";
            this.responsibility.Text = "";
            this.headCount.Text = "";
            this.requirement.Text = "";
            this.jobOrder.Text = "0";
            this.jobIsLock.SelectedValue = "0";
        }

    }
}