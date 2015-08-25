using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Cms.DAL
{
    /// <summary>
    /// 数据访问类:NewsInfo
    /// </summary>
    public partial class NewsInfo
    {
        public NewsInfo()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("NewsID", "NewsInfo");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int newsId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from NewsInfo");
            strSql.Append(" where NewsID=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = newsId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int newsId, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update NewsInfo set " + strValue);
            strSql.Append(" where NewsID=" + newsId);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Cms.Model.NewsInfo GetModel(int newsId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 NewsId,Title,Author,ClassId,Content,Click,IsLock,IsTop,PubTime from NewsInfo ");
            strSql.Append(" where NewsID=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
            parameters[0].Value = newsId;

            Cms.Model.NewsInfo model = new Cms.Model.NewsInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["NewsID"] != null && ds.Tables[0].Rows[0]["NewsID"].ToString() != "")
                {
                    model.NewsID = int.Parse(ds.Tables[0].Rows[0]["NewsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Title"] != null && ds.Tables[0].Rows[0]["Title"].ToString() != "")
                {
                    model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Author"] != null && ds.Tables[0].Rows[0]["Author"].ToString() != "")
                {
                    model.Author = ds.Tables[0].Rows[0]["Author"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ClassId"] != null && ds.Tables[0].Rows[0]["ClassId"].ToString() != "")
                {
                    model.ClassId = int.Parse(ds.Tables[0].Rows[0]["ClassId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Content"] != null && ds.Tables[0].Rows[0]["Content"].ToString() != "")
                {
                    model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Click"] != null && ds.Tables[0].Rows[0]["Click"].ToString() != "")
                {
                    model.Click = int.Parse(ds.Tables[0].Rows[0]["Click"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsLock"] != null && ds.Tables[0].Rows[0]["IsLock"].ToString() != "")
                {
                    model.IsLock = int.Parse(ds.Tables[0].Rows[0]["IsLock"].ToString());
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
        /// 增加一条数据
        /// </summary>
        public int Add(Cms.Model.NewsInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into NewsInfo(");
            strSql.Append("Title,Author,ClassId,Content,Click,IsLock,IsTop,PubTime)");
            strSql.Append(" values (");
            strSql.Append("@Title,@Author,@ClassId,@Content,@Click,@IsLock,@IsTop,@PubTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@Author", SqlDbType.NVarChar,50),
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@Click", SqlDbType.Int,4),
                    new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@IsTop", SqlDbType.Int,4),
					new SqlParameter("@PubTime", SqlDbType.DateTime)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.Author;
            parameters[2].Value = model.ClassId;
            parameters[3].Value = model.Content;
            parameters[4].Value = model.Click;
            parameters[5].Value = model.IsLock;
            parameters[6].Value = model.IsTop;
            parameters[7].Value = model.PubTime;

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
        public bool Update(Cms.Model.NewsInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update NewsInfo set ");
            strSql.Append("Title=@Title,");
            strSql.Append("Author=@Author,");
            strSql.Append("ClassId=@ClassId,");
            strSql.Append("Content=@Content,");
            strSql.Append("Click=@Click,");
            strSql.Append("IsLock=@IsLock,");
            strSql.Append("IsTop=@IsTop,");
            strSql.Append("PubTime=@PubTime");
            strSql.Append(" where NewsId=@NewsId");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@Author", SqlDbType.NVarChar,50),
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@Click", SqlDbType.Int,4),
                    new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@IsTop", SqlDbType.Int,4),
					new SqlParameter("@PubTime", SqlDbType.DateTime),
					new SqlParameter("@NewsId", SqlDbType.Int,4)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.Author;
            parameters[2].Value = model.ClassId;
            parameters[3].Value = model.Content;
            parameters[4].Value = model.Click;
            parameters[5].Value = model.IsLock;
            parameters[6].Value = model.IsTop;
            parameters[7].Value = model.PubTime;
            parameters[8].Value = model.NewsID;

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
            strSql.Append("delete from NewsInfo ");
            strSql.Append(" where NewsId=@NewsId");
            SqlParameter[] parameters = {
					new SqlParameter("@NewsId", SqlDbType.Int,4)};
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

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from NewsInfo ");
            strSql.Append(" where NewsId in (" + Idlist + ")  ");
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select NewsId,Title,Author,ClassId,Content,Click,IsLock,IsTop,PubTime ");
            strSql.Append(" FROM NewsInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (top > 0)
            {
                strSql.Append(" top " + top.ToString());
            }
            strSql.Append(" NewsId,Title,Author,ClassId,Content,Click,IsLock,IsTop,PubTime ");
            strSql.Append(" FROM NewsInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
    }
}