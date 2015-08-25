using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using Cms.Web.UI;

namespace Cms.Web.Admin.Solution
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
            if (this.caseTitle.Text.Trim().Length == 0)
            {
                strErr += "案例名称不能为空！\\n";
            }
            if (this.description.Text.Trim().Length == 0)
            {
                strErr += "案例描述不能为空！\\n";
            }
            if (this.solution.Text.Trim().Length == 0)
            {
                strErr += "解决方案不能为空！\\n";
            }
            if (this.txtImgUrl.Text.Trim().Length == 0)
            {
                strErr += "案例图片不能为空！\\n";
            }
            
            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }

            Cms.Model.Solution model = new Cms.Model.Solution();
            model.Title = this.caseTitle.Text;
            model.Description = this.description.Text;
            model.SolutionPlan = this.solution.Text;
            model.SucCases = this.SucCases.Text;
            model.ImageUrl = this.txtImgUrl.Text;
            model.SortOrder = Convert.ToInt32(sortOrder.Text); ;
            model.IsLock = Convert.ToInt32(isLock.SelectedValue);

            Cms.DAL.Solutions dal = new Cms.DAL.Solutions();
            int ReId = dal.Add(model);
            if (ReId > 0)
            {
                MessageBox.Show(this, "案例增加成功！");
                //Coolite.Ext.Web.Ext.MessageBox.Alert("提示", "产品型号信息修改成功").Show();
            }
            else
            {
                MessageBox.Show(this, "添加过程中发生错误！");
                //Coolite.Ext.Web.Ext.MessageBox.Alert("提示", "发布过程中发生错误").Show();
            }
        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            this.caseTitle.Text = "";
            this.description.Text = "";
            this.solution.Text = "";
            this.SucCases.Text = "";
            this.txtImgUrl.Text = "";
            this.sortOrder.Text = "0";
            this.isLock.SelectedValue = "0";
        }

    }
}