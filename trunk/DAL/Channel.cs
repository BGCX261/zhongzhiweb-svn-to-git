using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Cms.DAL
{
    /// <summary>
    /// 数据访问类:Channel
    /// </summary>
    public partial class Channel
    {
        public Channel()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该产品分类
        /// </summary>
        public bool ExistsProductType(int typeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ComoditiesType");
            strSql.Append(" where TypeId=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
            parameters[0].Value = typeID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 查找产品类型ID
        /// </summary>
        public int GetProductTypeID(string type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 TypeId from ComoditiesType");
            strSql.Append(" where ComoditiesType='" + type + "'");
            
            string typeID = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(typeID))
                return -1;

            return int.Parse(typeID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddProductType(string type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ComoditiesType(");
            strSql.Append("ComoditiesType)");
            strSql.Append(" values (");
            strSql.Append("@ComoditiesType)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ComoditiesType", SqlDbType.NVarChar,500)};
            parameters[0].Value = type;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 返回产品分类名称
        /// </summary>
        public string GetProductTypeTitle(int typeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ComoditiesType from ComoditiesType");
            strSql.Append(" where TypeId=" + typeID);
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title;
        }

        /// <summary>
        /// 获得产品分类列表
        /// </summary>
        public DataSet GetProductTypeList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TypeId,ComoditiesType");
            strSql.Append(" FROM ComoditiesType");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by TypeOrder");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 是否存在该产品品牌
        /// </summary>
        public bool ExistsProductBrand(int brandID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Brand");
            strSql.Append(" where brandID=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
            parameters[0].Value = brandID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回产品品牌名称
        /// </summary>
        public string GetProductBrandTitle(int brandID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 Brand from Brand");
            strSql.Append(" where brandID=" + brandID);
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title;
        }

        /// <summary>
        /// 查找产品品牌ID
        /// </summary>
        public int GetProductBrandID(string brand, int typeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 BrandId from Brand");
            strSql.Append(" where Brand='" + brand + "' AND TypeId='" + typeID + "'");

            string brandID = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(brandID))
                return -1;

            return int.Parse(brandID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddProductBrand(string brand, int typeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Brand(");
            strSql.Append("Brand, BrandOrder, TypeID, usTime)");
            strSql.Append(" values (");
            strSql.Append("@Brand, 0, @TypeID, @usTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Brand", SqlDbType.NVarChar,50),
                    new SqlParameter("@TypeID", SqlDbType.Int,4),
                    new SqlParameter("@usTime", SqlDbType.DateTime)};

            parameters[0].Value = brand;
            parameters[1].Value = typeID;
            parameters[2].Value = DateTime.Now;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 获得产品品牌列表
        /// </summary>
        public DataSet GetProductBrandList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BrandId, Brand");
            strSql.Append(" FROM Brand");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by BrandOrder");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 是否存在该产品名字
        /// </summary>
        public bool ExistsProductName(int comoditiesNameID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ComoditiesName");
            strSql.Append(" where ComoditiesNameID=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
            parameters[0].Value = comoditiesNameID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回产品名字名称
        /// </summary>
        public string GetProductNameTitle(int comoditiesNameID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 comoditiesName from ComoditiesName");
            strSql.Append(" where ComoditiesNameID=" + comoditiesNameID);
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title;
        }

        /// <summary>
        /// 查找产品名字ID
        /// </summary>
        public int GetProductNameID(string name, int typeID, int brandID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ComoditiesNameId from ComoditiesName");
            strSql.Append(" where ComoditiesName='" + name + "' AND TypeID='" + typeID + "' AND BrandID='" + brandID + "'");

            string nameID = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(nameID))
                return -1;

            return int.Parse(nameID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddProductName(string name, int typeID, int brandID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ComoditiesName(");
            strSql.Append("ComoditiesName, ComoditiesNameOrder, TypeID, BrandID)");
            strSql.Append(" values (");
            strSql.Append("@ComoditiesName, 0, @TypeID, @BrandID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ComoditiesName", SqlDbType.NVarChar,50),
                    new SqlParameter("@TypeID", SqlDbType.Int,4),
                    new SqlParameter("@BrandID", SqlDbType.Int,4)};

            parameters[0].Value = name;
            parameters[1].Value = typeID;
            parameters[2].Value = brandID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 获得产品名字列表
        /// </summary>
        public DataSet GetProductNameList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ComoditiesNameID, ComoditiesName");
            strSql.Append(" FROM ComoditiesName");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ComoditiesNameOrder");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 是否存在该活动栏目
        /// </summary>
        public bool ExistsNewsClass(int classID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from NewsClass");
            strSql.Append(" where classID=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
            parameters[0].Value = classID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回活动栏目名称
        /// </summary>
        public string GetNewsClassTitle(int classID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 Title from NewsClass");
            strSql.Append(" where classID=" + classID);
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title;
        }

        /// <summary>
        /// 获得活动栏目列表
        /// </summary>
        public DataSet GetNewsClassList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ClassID,Title,ClassOrder");
            strSql.Append(" FROM NewsClass");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by classOrder");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddNewsClass(Cms.Model.NewsClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into NewsClass(");
            strSql.Append("Title,ClassOrder)");
            strSql.Append(" values (");
            strSql.Append("@Title,@ClassOrder)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@ClassOrder", SqlDbType.Int,4)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.ClassOrder;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateNewsClass(Cms.Model.NewsClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update NewsClass set ");
            strSql.Append("Title=@Title,");
            strSql.Append("ClassOrder=@ClassOrder");
            strSql.Append(" where ClassID=@ClassID");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@ClassOrder", SqlDbType.Int,4),
					new SqlParameter("@ClassID", SqlDbType.Int,4)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.ClassOrder;
            parameters[2].Value = model.ClassID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除该栏目分类及所有属下分类数据
        /// </summary>
        public void DeleteNewsClass(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from NewsClass ");
            strSql.Append(" where ClassID = '" + Id + "' ");

            DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteNewsClassList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from NewsClass ");
            strSql.Append(" where ClassID in (" + Idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Cms.Model.NewsClass GetNewsClassModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ClassID,Title,ClassOrder from NewsClass ");
            strSql.Append(" where ClassID=@ClassID");
            SqlParameter[] parameters = {
					new SqlParameter("@ClassID", SqlDbType.Int,4)
};
            parameters[0].Value = Id;

            Cms.Model.NewsClass model = new Cms.Model.NewsClass();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ClassID"] != null && ds.Tables[0].Rows[0]["ClassID"].ToString() != "")
                {
                    model.ClassID = int.Parse(ds.Tables[0].Rows[0]["ClassID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Title"] != null && ds.Tables[0].Rows[0]["Title"].ToString() != "")
                {
                    model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ClassOrder"] != null && ds.Tables[0].Rows[0]["ClassOrder"].ToString() != "")
                {
                    model.ClassOrder = int.Parse(ds.Tables[0].Rows[0]["ClassOrder"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateNewsClassField(int Id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE NewsClass set " + strValue);
            strSql.Append(" WHERE ClassID = " + Id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        #endregion  Method
    }
}