using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Cms.Web.UI;
using Maticsoft.Common;

namespace Cms.Web.Admin.Channel
{
    public partial class Add : ManagePage
    {
        private Cms.DAL.Channel dal = new Cms.DAL.Channel();
        private Cms.Model.NewsClass model = new Cms.Model.NewsClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            txtSortId.Text = "0";
        }

        //添加
        protected void btnSave_Click(object sender, EventArgs e)
        {
            model.Title = this.txtTitle.Text.Trim();
            model.ClassOrder = int.Parse(txtSortId.Text.Trim());
            dal.AddNewsClass(model);
            //保存日志
            MessageBox.Show(this, "增加栏目成功！");
        }
    }
}