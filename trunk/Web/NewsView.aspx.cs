using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cms.Web
{
    public partial class NewsView : System.Web.UI.Page
    {
        protected int newsId;   //全局变量Id
        protected Cms.Model.NewsInfo model = new Cms.Model.NewsInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.Params["newsID"] as string, out this.newsId))
            {
                Response.Write("<script>alert('您要查看的信息参数不正确或不存在！'),location.href='News.aspx';</script>");
                return;
            }

            Cms.DAL.NewsInfo dal = new Cms.DAL.NewsInfo();
            model = dal.GetModel(this.newsId);//获得Id
            if (model == null)
            {
                Response.Write("<script>alert('您要查看的信息参数不正确或不存在！'),location.href='News.aspx';</script>");
                return;
            }
            ////浏览数+1
            dal.UpdateField(this.newsId, "Click=Click+1");
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript'>menuEnable(4);</script>");
        }

    }
}