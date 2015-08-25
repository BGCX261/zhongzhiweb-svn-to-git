using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cms.Web.UI;
using Maticsoft.Common;

namespace Cms.Web.Admin.Manage
{
    public partial class Add : ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //添加管理员
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Cms.Model.Admin model = new Cms.Model.Admin();
            Cms.DAL.Admin dal = new Cms.DAL.Admin();

            string userName = txtUserName.Text.Trim();
            string userPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(this.txtUserPwd.Text.ToString(), "MD5");
            //检测用户名是否存在
            if (dal.Exists(userName))
            {
                MessageBox.Show(this, "该用户名已经存在！");
                return;
            }

            model.UserName = userName;
            model.UserPwd = userPwd;
            model.RealName = txtRealName.Text;
            model.Telephone = txtTelephone.Text;
            model.Address = txtAddress.Text;

            dal.Add(model);
            //保存日志
            MessageBox.Show(this, "添加管理员成功！");
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            this.txtRealName.Text = "";
            this.txtUserPwd.Text = "";
            this.txtUserPwd1.Text = "";
            this.txtUserName.Text = "";
            this.txtTelephone.Text = "";
            this.txtAddress.Text = "";
        }
    }
}