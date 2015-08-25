using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Cms.Web.UI;
using Maticsoft.Common;
using System.Data.OleDb;
using System.IO;

namespace Cms.Web.Admin.Products
{
    public partial class Import : ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public DataSet ExcelToDS(string Path) 
        { 
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;"; 
            OleDbConnection conn = new OleDbConnection(strConn); 
            conn.Open(); 
            string strExcel = ""; 
            OleDbDataAdapter myCommand = null; 
            DataSet ds = null; 
            strExcel = "select * from [sheet1$]"; 
            myCommand = new OleDbDataAdapter(strExcel, strConn); 
            ds = new DataSet(); 
            myCommand.Fill(ds, "table1");
            conn.Close();
            return ds; 
        }  

        #region 批量删除
        protected void btnretset_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(importFilePath.Text))
                return;

            string fullPath = HttpContext.Current.Server.MapPath(importFilePath.Text);
            if (File.Exists(fullPath))
                File.Delete(fullPath);

            importFilePath.Text = "";
        }

        protected void lbtnImport_Click(object sender, EventArgs e)
        {
            string fullPath = HttpContext.Current.Server.MapPath(importFilePath.Text);
            if (!File.Exists(fullPath))
            {
                //保存日志
                MessageBox.Show(this, "请上传导入文件！");
                return;
            }

            DataSet ds = ExcelToDS( fullPath );
            DataTable tb = ds.Tables[0];
            if (tb.Rows.Count > 0)
            {
                Cms.DAL.Channel dal = new Cms.DAL.Channel();
                Cms.DAL.ProductInfo proDAL = new Cms.DAL.ProductInfo();
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    DataRow proRow = tb.Rows[i];
                    string type = proRow["商品类型"].ToString();
                    string brand = proRow["商品品牌"].ToString();
                    string name = proRow["商品名称"].ToString();
                    string spec = proRow["商品型号"].ToString();
                    int procNum = int.Parse(proRow["数量"].ToString());

                    int typeID = dal.GetProductTypeID(type);
                    if (typeID == -1)
                        typeID = dal.AddProductType(type);

                    int brandID = dal.GetProductBrandID(brand, typeID);
                    if (brandID == -1)
                        brandID = dal.AddProductBrand(brand, typeID);

                    int nameID = dal.GetProductNameID(name, typeID, brandID);
                    if (nameID == -1)
                        nameID = dal.AddProductName(name, typeID, brandID);

                    int specID = 0;
                    if (!proDAL.Exists(spec, typeID, brandID, nameID))
                    {
                        Cms.Model.ProductInfo model = new Cms.Model.ProductInfo();
                        model.Specifications = spec;
                        model.ImgUrl = "";
                        model.SmallImgUrl = "";
                        model.Description = "";
                        model.Click = 0;
                        model.PubTime = DateTime.Now;
                        model.IsTop = 0;
                        model.TypeId = typeID;
                        model.BrandId = brandID;
                        model.NameId = nameID;

                        specID = proDAL.Add(model);
                    }

                    if (specID > 0)
                    {
                        proDAL.AddStock(typeID, brandID, nameID, specID, procNum, procNum);
                    }
                }
            }
            File.Delete( fullPath );

            //保存日志
            MessageBox.Show(this, "数据导入成功！");
        }
        #endregion
    }
}