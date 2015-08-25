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
    public partial class Add : ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //绑定类别
                showInfo();
            }
            else
            {
                this.ProductImg.ImageUrl = txtImgUrl.Text.Trim();
            }
        }

        #region 保存产品
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Cms.Model.ProductInfo model = new Cms.Model.ProductInfo();

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

            int ReId = dal.Add(model);
            if (ReId > 0)
            {
                MessageBox.Show(this, "产品型号信息添加成功！");
                //Coolite.Ext.Web.Ext.MessageBox.Alert("提示", "产品型号信息修改成功").Show();
            }
            else
            {
                MessageBox.Show(this, "添加过程中发生错误！");
                //Coolite.Ext.Web.Ext.MessageBox.Alert("提示", "发布过程中发生错误").Show();
            }
        }
        #endregion
        protected void showInfo()
        {
            txtSpec.Text = "";
            txtImgUrl.Text = "";
            ProductDetail.Text = "";
            txtClick.Text = "0";
            txtPubTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            cblItem.Items[0].Selected = false;

            //绑定类别
            ProductTypeTreeBind("所有类型", this.ddlTypeId);
            ddlBrandId.Enabled = false;
            ddlNameId.Enabled = false;
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