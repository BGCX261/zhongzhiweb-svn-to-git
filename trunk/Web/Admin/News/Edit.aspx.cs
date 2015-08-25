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
    public partial class Edit : ManagePage
    {
        public int Id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.Params["newsID"] as string, out this.Id))
            {
                Response.Write("<script>alert('您要查看的信息参数不正确或不存在！');history.go(-1);</script>");
                return;
            }
            if (!Page.IsPostBack)
            {
                //绑定类别
                NewsClassTreeBind("所有类别", this.ddlClassId);
                //赋值
                ShowInfo(this.Id);
            }
        }

        #region 赋值操作
        private void ShowInfo(int _id)
        {
            Cms.DAL.NewsInfo dal = new Cms.DAL.NewsInfo();
            Cms.Model.NewsInfo model = dal.GetModel(_id);

            txtTitle.Text = model.Title;
            txtAuthor.Text = model.Author;
            ddlClassId.SelectedValue = model.ClassId.ToString();
            NewsContent.Text = Cms.Common.Utils.ToTxt(model.Content);
            txtPubTime.Text = model.PubTime.ToString("yyyy-MM-dd HH:mm:ss");
            txtClick.Text = model.Click.ToString();
            cblItem.Items[0].Selected = model.IsTop > 0;
            cblItem.Items[1].Selected = model.IsLock > 0;
        }
        #endregion

        #region 修改操作
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Cms.DAL.NewsInfo dal = new Cms.DAL.NewsInfo();
            Cms.Model.NewsInfo model = new Cms.Model.NewsInfo();

            model.NewsID = Id;
            model.Title = txtTitle.Text.Trim();
            model.Author = txtAuthor.Text.Trim();
            model.ClassId = int.Parse(ddlClassId.SelectedValue);
            model.Content = Cms.Common.Utils.ToHtml(NewsContent.Text);
            model.PubTime = DateTime.Parse(txtPubTime.Text);
            model.Click = int.Parse(txtClick.Text.Trim());
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
            dal.Update(model);

            //保存日志
            MessageBox.Show(this, "新闻编辑成功！");
        }
        #endregion

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ShowInfo(Id);
        }
    }
}