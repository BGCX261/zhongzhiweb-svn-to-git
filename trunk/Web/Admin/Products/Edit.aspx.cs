using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Cms.Web.UI;
using Maticsoft.Common;

namespace Cms.Web.Admin.Products
{
    public partial class Edit : ManagePage
    {
        protected int specId;   //全局变量Id
        protected Cms.Model.ProductInfo model = new Cms.Model.ProductInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.Params["specId"] as string, out this.specId))
            {
                Response.Write("<script>alert('您要查看的信息参数不正确或不存在！');history.go(-1);</script>");
                return;
            }

            Cms.DAL.ProductInfo dal = new Cms.DAL.ProductInfo();
            model = dal.GetModel(this.specId);//获得Id
            if (model == null)
            {
                Response.Write("<script>alert('您要查看的信息参数不正确或不存在！');history.go(-1);</script>");
                return;
            }
            if (!Page.IsPostBack)
            {
                //赋值
                showInfo();
            }
        }

        #region 保存产品
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (model == null)
                return;

            string strErr = "";
            if (!PageValidate.IsDateTime(txtPubTime.Text))
            {
                strErr += "发布时间格式错误！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }
            if (this.ddlTypeId.SelectedValue == "")
            {
                MessageBox.Show(this, "请选择商品类型！");
                return;
            }
            if (this.ddlBrandId.SelectedValue == "")
            {
                MessageBox.Show(this, "请选择商品品牌！");
                return;
            }
            if (this.ddlNameId.SelectedValue == "")
            {
                MessageBox.Show(this, "请选择商品名称！");
                return;
            }

            Cms.DAL.ProductInfo dal = new Cms.DAL.ProductInfo();
            model.Specifications = txtSpec.Text.Trim();
            model.ImgUrl = txtImgUrl.Text.Trim();
            model.SmallImgUrl = txtImgUrl.Text.Trim();
            model.Description = Cms.Common.Utils.ToHtml(ProductDetail.Text);
            model.Click = int.Parse(txtClick.Text.Trim());
            model.PubTime = DateTime.Parse(txtPubTime.Text);
            model.IsTop = 0;
            if (cblItem.Items[0].Selected == true)
            {
                model.IsTop = 1;
            }
            model.TypeId = int.Parse(this.ddlTypeId.SelectedValue.Trim());
            model.BrandId = int.Parse(this.ddlBrandId.SelectedValue.Trim());
            model.NameId = int.Parse(this.ddlNameId.SelectedValue.Trim());

            bool rel = dal.Update(model);
            if (rel)
            {
                MessageBox.Show(this, "产品型号信息修改成功！");
                //Coolite.Ext.Web.Ext.MessageBox.Alert("提示", "产品型号信息修改成功").Show();
            }
            else
            {
                MessageBox.Show(this, "发布过程中发生错误！");
                //Coolite.Ext.Web.Ext.MessageBox.Alert("提示", "发布过程中发生错误").Show();
            }
        }
        #endregion
        protected void showInfo()
        {
            if (model == null)
                return;

            txtSpec.Text = model.Specifications;
            txtImgUrl.Text = model.ImgUrl;
            ProductDetail.Text = Cms.Common.Utils.ToTxt(model.Description);
            txtClick.Text = model.Click.ToString();
            txtPubTime.Text = model.PubTime.ToString("yyyy-MM-dd HH:mm:ss");
            cblItem.Items[0].Selected = false;
            if (model.IsTop != 0)
                cblItem.Items[0].Selected = true;

            //绑定类别
            ProductTypeTreeBind("所有类型", this.ddlTypeId);
            this.ddlTypeId.SelectedValue = model.TypeId.ToString();
            ProductBrandTreeBind("所有品牌", ddlBrandId, "TypeId='" + model.TypeId + "'");
            this.ddlBrandId.SelectedValue = model.BrandId.ToString();
            ProductNameTreeBind("所有名称", ddlNameId, "TypeId='" + model.TypeId + "' AND BrandId='" + model.BrandId + "'");
            this.ddlNameId.SelectedValue = model.NameId.ToString();
        }
        protected void btnreset_Click(object sender, EventArgs e)
        {
            showInfo();
        }

        #region 类型索引
        protected void ddlTypeId_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selType = this.ddlTypeId.SelectedValue;
            if (selType != "")
            {
                ProductBrandTreeBind("所有品牌", ddlBrandId, "TypeId='" + selType + "'");
                ddlBrandId.Enabled = true;
                ddlNameId.Enabled = false;
            }
            else
            {
                ddlBrandId.Enabled = false;
                ddlNameId.Enabled = false;
            }
        }
        #endregion

        #region 品牌索引
        protected void ddlBrandId_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selType = this.ddlTypeId.SelectedValue;
            string selBrand = this.ddlBrandId.SelectedValue;
            if (selBrand != "")
            {
                ProductNameTreeBind("所有名称", ddlNameId, "TypeId='" + selType + "' AND BrandId='" + selBrand + "'");
                ddlNameId.Enabled = true;
            }
            else
            {
                ddlNameId.Enabled = false;
            }
        }
        #endregion
    }
}