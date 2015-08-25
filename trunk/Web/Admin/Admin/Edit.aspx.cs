using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cms.Web.UI;
using Maticsoft.Common;

namespace Cms.Web.Admin.Manage
{
    public partial class Edit : ManagePage
    {
        public int Id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.Params["userid"] as string, out this.Id))
            {
                Response.Write("<script>alert('您要查看的信息参数不正确或不存在！');history.go(-1);</script>");
                return;
            }
            if (!Page.IsPostBack)
            {
                ShowInfo(this.Id);
            }
        }

        #region 赋值操作
        private void ShowInfo(int editID)
        {
            Cms.DAL.Admin dal = new Cms.DAL.Admin();
            Cms.Model.Admin model = new Cms.Model.Admin();
            model = dal.GetModelByID(editID);

            txtUserName.Text = model.UserName;
            txtRealName.Text = model.RealName;
            txtTelephone.Text = model.Telephone;
            txtAddress.Text = model.Address;
        }
        #endregion

        #region 保存修改
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Cms.DAL.Admin dal = new Cms.DAL.Admin();
            Cms.Model.Admin model = dal.GetModelByID(this.Id);

            string UserPwd = this.txtUserPwd.Text.ToString();
            if (UserPwd != null && UserPwd != "")
            {
                model.UserPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(UserPwd, "MD5"); ;
            }
            model.RealName = txtRealName.Text;
            model.Telephone = txtTelephone.Text;
            model.Address = txtAddress.Text;

            dal.Update(model);

            //保存日志
            MessageBox.Show(this, "管理员修改成功！");
        }
        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {
            ShowInfo(this.Id);
        }

    }
}