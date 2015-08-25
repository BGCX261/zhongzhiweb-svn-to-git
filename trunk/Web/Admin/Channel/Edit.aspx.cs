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
    public partial class Edit : ManagePage
    {
        private Cms.DAL.Channel dal = new Cms.DAL.Channel();
        private Cms.Model.NewsClass model = new Cms.Model.NewsClass();
        public int classId;    //ID
        protected void Page_Load(object sender, EventArgs e)
        {
            //取得栏目传参
            if (int.TryParse(Request.Params["classId"], out classId))
            {
                model = dal.GetNewsClassModel(classId);
                if (!Page.IsPostBack)
                {
                    //数据绑定
                    ShowInfo();
                }
            }
            else
            {
                Response.Write("<script>alert('您要修改类别的种类不明确或参数不正确！');history.go(-1);</script>");
            }
        }

        //绑定数据
        private void ShowInfo()
        {
            this.txtTitle.Text = model.Title;
            this.txtSortId.Text = model.ClassOrder.ToString();
        }

        //保存修改
        protected void btnSave_Click(object sender, EventArgs e)
        {
            model.Title = txtTitle.Text.Trim();
            model.ClassOrder = int.Parse(txtSortId.Text.Trim());
            //修改栏目
            dal.UpdateNewsClass(model);
            //保存日志
            MessageBox.Show(this, "栏目修改成功！");
            //Coolite.Ext.Web.Ext.MessageBox.Alert("提示", "类别修改成功").Show();
        }

    }
}