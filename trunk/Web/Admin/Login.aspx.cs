using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Maticsoft.Common;

namespace Cms.Web.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        Cms.DAL.Admin dal = new DAL.Admin();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.ViewState["GUID"] = System.Guid.NewGuid().ToString();
                this.lblGUID.Text = this.ViewState["GUID"].ToString();
            }
        }

        protected void logindl_Click(object sender, ImageClickEventArgs e)
        {
            if ((Session["CheckCode"] != null) && (Session["CheckCode"].ToString() != ""))
            {
                #region 记录登录次数
                if (Session["AdminLoginSun"] == null)
                {
                    Session["AdminLoginSun"] = 1;
                }
                else
                {
                    Session["AdminLoginSun"] = Convert.ToInt32(Session["AdminLoginSun"]) + 1;
                }
                //判断登录
                if (Session["AdminLoginSun"] != null && Convert.ToInt32(Session["AdminLoginSun"]) > 3)
                {
                    this.logindl.Enabled = false;
                    this.txtCode.Text = "";
                    this.txtName.Enabled = false;
                    this.txtPwd.Enabled = false;
                    MessageBox.Show(this, "对不起，你错误登录了三次，系统登录锁定！");
                }
                #endregion

                string UserName = txtName.Text.Trim();
                string UserPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(this.txtPwd.Text.ToString(), "MD5");

                if (UserName.Equals("") || UserPwd.Equals(""))
                {
                    MessageBox.Show(this, "请输入您要登录用户名或密码！");
                }
                else
                {
                    if (Session["CheckCode"].ToString().ToLower() != this.txtCode.Text.ToLower())
                    {
                        MessageBox.Show(this, "您输入的验证码不正确，请重新输入！");
                        this.txtCode.Text = "";
                        Session["CheckCode"] = null;
                        return;
                    }
                    else
                    {
                        Session["CheckCode"] = null;
                    }
                    if (dal.chkAdminLogin(UserName, UserPwd))
                    {
                        Cms.Model.Admin model = new Cms.Model.Admin();
                        model = dal.GetModelByName(UserName);
                        Session["AdminNo"] = model.Id;
                        Session["AdminName"] = model.UserName;
                        //设置超时时间
                        Session.Timeout = 120;
                        Session["AdminLoginSun"] = null;
                        Response.Redirect("Frame.aspx");
                    }
                    else
                    {
                        MessageBox.Show(this, "您输入的用户名或密码不正确，请重新输入！");
                        //保存日志
                        new Web.UI.ManagePage().SaveLogs(UserName, "[用户登录] 状态：登录失败！");
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "请输入验证码！");
            }
        }

        protected void logincancel_Click(object sender, ImageClickEventArgs e)
        {
            this.txtName.Text = "";
            this.txtPwd.Text = "";
        }

    }
}