using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cms.Web.Admin.Products
{
    public partial class Show : System.Web.UI.Page
    {
        public string strid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["specID"] != null && Request.Params["specID"].Trim() != "")
                {
                    strid = Request.Params["specID"];
                    int Id = (Convert.ToInt32(strid));
                    //赋值
                    ShowInfo(Id);
                }
            }
        }

        //赋值
        private void ShowInfo(int Id)
        {
            Cms.DAL.ProductInfo dal = new Cms.DAL.ProductInfo();
            Cms.Model.ProductInfo model = dal.GetModel(Id);
            Cms.DAL.Channel chnDal = new Cms.DAL.Channel();

            this.lblId.Text = model.SpecId.ToString();
            this.lblType.Text = chnDal.GetProductTypeTitle(model.TypeId);
            this.lblBrand.Text = chnDal.GetProductBrandTitle(model.BrandId);
            this.lblName.Text = chnDal.GetProductNameTitle(model.NameId);
            this.lblSpec.Text = model.Specifications;
            this.lblContent.Text =Cms.Common.Utils.ToTxt(model.Description);
            this.lblClick.Text = model.Click.ToString();
            this.lblIsTop.Text = model.IsTop.ToString();
            this.lblPubTime.Text = model.PubTime.ToString();
        }
        protected string getImgUrl()
        {
            if (!String.IsNullOrEmpty(strid))
            {
                int Id = (Convert.ToInt32(strid));
                Cms.DAL.ProductInfo dal = new Cms.DAL.ProductInfo();
                Cms.Model.ProductInfo model = dal.GetModel(Id);
                if (model != null)
                    return model.ImgUrl;
                else
                    return "";
            }
            return "";
        }
    }
}