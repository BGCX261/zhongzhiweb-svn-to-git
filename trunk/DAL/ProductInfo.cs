using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Cms.DAL
{
    /// <summary>
    /// 数据访问类:ProductInfo
    /// </summary>
    public partial class ProductInfo
    {
        public ProductInfo()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("SpecificationsId", "Specifications");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int comodID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Specifications");
            strSql.Append(" where SpecificationsId=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = comodID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string spec, int typeID, int brandID, int nameID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Specifications");
            strSql.Append(" where Specifications=@Specifications AND TypeID='" + typeID
                + "' AND BrandID='" + brandID + "' AND ComoditiesNameId='" + nameID + "'");

            SqlParameter[] parameters = {
					new SqlParameter("@Specifications", SqlDbType.VarChar,300)};
            parameters[0].Value = spec;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Cms.Model.ProductInfo GetModel(int specId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SpecificationsId,Specifications,TypeId,BrandId,ComoditiesNameId,ImageUrl,SmallImgUrl,Click,IsTop,PubTime,Description from Specifications ");
            strSql.Append(" where SpecificationsId=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = specId;

            Cms.Model.ProductInfo model = new Cms.Model.ProductInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SpecificationsId"] != null && ds.Tables[0].Rows[0]["SpecificationsId"].ToString() != "")
                {
                    model.SpecId = int.Parse(ds.Tables[0].Rows[0]["SpecificationsId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Specifications"] != null && ds.Tables[0].Rows[0]["Specifications"].ToString() != "")
                {
                    model.Specifications = ds.Tables[0].Rows[0]["Specifications"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TypeId"] != null && ds.Tables[0].Rows[0]["TypeId"].ToString() != "")
                {
                    model.TypeId = int.Parse(ds.Tables[0].Rows[0]["TypeId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BrandId"] != null && ds.Tables[0].Rows[0]["BrandId"].ToString() != "")
                {
                    model.BrandId = int.Parse(ds.Tables[0].Rows[0]["BrandId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ComoditiesNameId"] != null && ds.Tables[0].Rows[0]["ComoditiesNameId"].ToString() != "")
                {
                    model.NameId = int.Parse(ds.Tables[0].Rows[0]["ComoditiesNameId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ImageUrl"] != null && ds.Tables[0].Rows[0]["ImageUrl"].ToString() != "")
                {
                    model.ImgUrl = ds.Tables[0].Rows[0]["ImageUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SmallImgUrl"] != null && ds.Tables[0].Rows[0]["SmallImgUrl"].ToString() != "")
                {
                    model.SmallImgUrl = ds.Tables[0].Rows[0]["SmallImgUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Description"] != null && ds.Tables[0].Rows[0]["Description"].ToString() != "")
                {
                    model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Click"] != null && ds.Tables[0].Rows[0]["Click"].ToString() != "")
                {
                    model.Click = int.Parse(ds.Tables[0].Rows[0]["Click"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsTop"] != null && ds.Tables[0].Rows[0]["IsTop"].ToString() != "")
                {
                    model.IsTop = int.Parse(ds.Tables[0].Rows[0]["IsTop"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PubTime"] != null && ds.Tables[0].Rows[0]["PubTime"].ToString() != "")
                {
                    model.PubTime = DateTime.Parse(ds.Tables[0].Rows[0]["PubTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetProductList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TypeId,BrandId,ComoditiesNameId,SpecificationsID,Specifications,SmallImgUrl,IsTop,PubTime");
            strSql.Append(" FROM Specifications ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by usTime desc");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int Id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Specifications set " + strValue);
            strSql.Append(" WHERE SpecificationsID = " + Id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetTopProductList(int top, string strWhere, string order)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (top > 0)
            {
                strSql.Append(" top " + top.ToString());
            }
            strSql.Append(" SpecificationsID,Specifications,BrandID,ComoditiesNameId,SmallImgUrl,Description");
            strSql.Append(" FROM Specifications ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (order.Trim() != "")
                strSql.Append(order);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Cms.Model.ProductInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Specifications(");
            strSql.Append("Specifications,TypeId,BrandId,ComoditiesNameId,Description,ImageUrl,SmallImgUrl,Click,IsTop,PubTime)");
            strSql.Append(" values (");
            strSql.Append("@Specifications,@TypeId,@BrandId,@ComoditiesNameId,@Description,@ImageUrl,@SmallImgUrl,@Click,@IsTop,@PubTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@Specifications", SqlDbType.NVarChar,50),
                    new SqlParameter("@TypeId", SqlDbType.Int,4),
                    new SqlParameter("@BrandId", SqlDbType.Int,4),
                    new SqlParameter("@ComoditiesNameId", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.NText),
					new SqlParameter("@ImageUrl", SqlDbType.NVarChar,250),
                    new SqlParameter("@SmallImgUrl", SqlDbType.NVarChar,250),
					new SqlParameter("@Click", SqlDbType.Int,4),
					new SqlParameter("@IsTop", SqlDbType.Int,4),
					new SqlParameter("@PubTime", SqlDbType.DateTime)};
            parameters[0].Value = model.Specifications;
            parameters[1].Value = model.TypeId;
            parameters[2].Value = model.BrandId;
            parameters[3].Value = model.NameId;
            parameters[4].Value = model.Description;
            parameters[5].Value = model.ImgUrl;
            parameters[6].Value = model.SmallImgUrl;
            parameters[7].Value = model.Click;
            parameters[8].Value = model.IsTop;
            parameters[9].Value = model.PubTime;

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
        /// 增加一条数据
        /// </summary>
        public int AddStock(int typeID, int brandID, int nameID, int specID, int ProcNum, int TotalNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Stock(");
            strSql.Append("TypeId,BrandId,ComoditiesNameId,SpecificationsId,ProcNum,TotalNum)");
            strSql.Append(" values (");
            strSql.Append("@TypeId,@BrandId,@ComoditiesNameId,@SpecificationsId,@ProcNum,@TotalNum)");
            strSql.Append(";select @@IDENTITY");

            SqlParameter[] parameters = {
                    new SqlParameter("@TypeId", SqlDbType.Int,4),
                    new SqlParameter("@BrandId", SqlDbType.Int,4),
                    new SqlParameter("@ComoditiesNameId", SqlDbType.Int,4),
					new SqlParameter("@SpecificationsId", SqlDbType.Int,4),
					new SqlParameter("@ProcNum", SqlDbType.Int,4),
					new SqlParameter("@TotalNum", SqlDbType.Int,4)};

            parameters[0].Value = typeID;
            parameters[1].Value = brandID;
            parameters[2].Value = nameID;
            parameters[3].Value = specID;
            parameters[4].Value = ProcNum;
            parameters[5].Value = TotalNum;

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
        public bool Update(Cms.Model.ProductInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Specifications set ");
            strSql.Append("TypeId=@TypeId,");
            strSql.Append("BrandId=@BrandId,");
            strSql.Append("ComoditiesNameId=@ComoditiesNameId,");
            strSql.Append("Specifications=@Specifications,");
            strSql.Append("Description=@Description,");
            strSql.Append("ImageUrl=@ImageUrl,");
            strSql.Append("SmallImgUrl=@SmallImgUrl,");
            strSql.Append("Click=@Click,");
            strSql.Append("IsTop=@IsTop,");
            strSql.Append("PubTime=@PubTime");
            strSql.Append(" where SpecificationsID=@SpecificationsID");
            SqlParameter[] parameters = {
                    new SqlParameter("@TypeId", SqlDbType.Int,4),
                    new SqlParameter("@BrandId", SqlDbType.Int,4),
                    new SqlParameter("@ComoditiesNameId", SqlDbType.Int,4),
                    new SqlParameter("@Specifications", SqlDbType.NVarChar,50),
					new SqlParameter("@Description", SqlDbType.NText),
					new SqlParameter("@ImageUrl", SqlDbType.NVarChar,250),
                    new SqlParameter("@SmallImgUrl", SqlDbType.NVarChar,250),
					new SqlParameter("@Click", SqlDbType.Int,4),
					new SqlParameter("@IsTop", SqlDbType.Int,4),
					new SqlParameter("@PubTime", SqlDbType.DateTime),
					new SqlParameter("@SpecificationsID", SqlDbType.Int,4)};
            parameters[0].Value = model.TypeId;
            parameters[1].Value = model.BrandId;
            parameters[2].Value = model.NameId;
            parameters[3].Value = model.Specifications;
            parameters[4].Value = model.Description;
            parameters[5].Value = model.ImgUrl;
            parameters[6].Value = model.SmallImgUrl;
            parameters[7].Value = model.Click;
            parameters[8].Value = model.IsTop;
            parameters[9].Value = model.PubTime;
            parameters[10].Value = model.SpecId;
            
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Specifications ");
            strSql.Append(" where SpecificationsID=@SpecificationsID");
            SqlParameter[] parameters = {
					new SqlParameter("@SpecificationsID", SqlDbType.Int,4)};
            parameters[0].Value = Id;

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
        #endregion  Method
    }
}

