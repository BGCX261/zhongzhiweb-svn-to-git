using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Cms.Web.UI;
using Maticsoft.Common;

namespace Cms.Web.Admin.News
{
    public partial class Add : ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //绑定类别
                NewsClassTreeBind("所有类别", this.ddlClassId);
                showNullInfo();
            }
        }

        #region 添加
        protected void btnSave_Click(object sender, EventArgs e)
        {            
            string strErr = "";
            if (this.txtTitle.Text.Trim().Length == 0)
            {
                strErr += "新闻标题不能为空！\\n";
            }
            if (this.txtAuthor.Text.Trim().Length == 0)
            {
                strErr += "发布人不能为空！\\n";
            }
            if (this.NewsContent.Text.Trim().Length == 0)
            {
                strErr += "新闻内容不能为空！\\n";
            }
            if (!PageValidate.IsNumber(txtClick.Text))
            {
                strErr += "点击次数格式错误！\\n";
            }
            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }

            Cms.Model.NewsInfo model = new Cms.Model.NewsInfo();
            model.Title = this.txtTitle.Text;
            model.Author = this.txtAuthor.Text;
            model.ClassId = int.Parse(ddlClassId.SelectedValue);
            model.Content = Cms.Common.Utils.ToHtml(this.NewsContent.Text);
            model.Click = int.Parse(this.txtClick.Text);
            model.IsTop = 0;
            if (cblItem.Items[0].Selected == true)
            {
                model.IsTop = 1;
            }
            model.IsLock = 0;
            if (cblItem.Items[1].Selected == true)
            {
                model.IsLock = 1;
            }
            model.PubTime = DateTime.Parse(DateTime.Now.ToString());

            Cms.DAL.NewsInfo dal = new Cms.DAL.NewsInfo();
            int ReId = dal.Add(model);
            if (ReId > 0)
            {
                //保存日志
                MessageBox.Show(this, "新闻发布成功！");
            }
            else
            {
                MessageBox.Show(this, "发布过程中发生错误！");
                //Coolite.Ext.Web.Ext.MessageBox.Alert("提示", "发布过程中发生错误").Show();
            }
        }
        #endregion

        protected void btnReset_Click(object sender, EventArgs e)
        {
            showNullInfo();
        }
        protected void showNullInfo()
        {
            txtTitle.Text = "";
            txtAuthor.Text = "";
            ddlClassId.SelectedValue = "";
            NewsContent.Text = "";
            txtPubTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            txtClick.Text = "0";
            cblItem.Items[0].Selected = false;
            cblItem.Items[1].Selected = false;
        }
    }
}