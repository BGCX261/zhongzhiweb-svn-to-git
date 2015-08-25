using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cms.Web
{
    public partial class ProductView : System.Web.UI.Page
    {
        protected int specId;   //全局变量Id
        protected Cms.Model.ProductInfo model = new Cms.Model.ProductInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.Params["specId"] as string, out this.specId))
            {
                Response.Write("<script>alert('您要查看的信息参数不正确或不存在！'),location.href='ProductList.aspx';</script>");
                return;
            }

            Cms.DAL.ProductInfo dal = new Cms.DAL.ProductInfo();
            model = dal.GetModel(this.specId);//获得Id
            if (model == null)
            {
                Response.Write("<script>alert('您要查看的信息参数不正确或不存在！'),location.href='ProductList.aspx';</script>");
                return;
            }
            //浏览数+1
            dal.UpdateField(this.specId, "Click=Click+1");
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript'>menuEnable(2);</script>");
        }
        //取得产品标题
        protected string GetProductTitle()
        {
            return GetBrandTitle(this.model.BrandId) + " " + this.model.Specifications;
        }
        //取得产品分类名称
        protected string GetTypeTitle(int typeId)
        {
            Cms.DAL.Channel dal = new Cms.DAL.Channel();
            string title = dal.GetProductTypeTitle(typeId);
            if (string.IsNullOrEmpty( title ))
                title = "No Type";

            return title;
        }
        //取得产品品牌名称
        protected string GetBrandTitle(int brandId)
        {
            Cms.DAL.Channel dal = new Cms.DAL.Channel();
            string title = dal.GetProductBrandTitle(brandId);
            if (string.IsNullOrEmpty(title))
                title = "No Brand";

            return title;
        }
        //取得产品名字名称
        protected string GetNameTitle(int nameId)
        {
            Cms.DAL.Channel dal = new Cms.DAL.Channel();
            string title = dal.GetProductNameTitle(nameId);
            if (string.IsNullOrEmpty(title))
                title = "No Name";

            return title;
        }
    }
}