using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Cms.DAL
{
	/// <summary>
	/// 数据访问类:Contents
	/// </summary>
	public partial class Solutions
	{
		public Solutions()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID("SolutionId", "Solutions"); 
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select SolutionId,CaseTitle,Description,Solution,SucCases,ImageUrl,IsLock ");
            strSql.Append(" FROM Solutions ");
			if(strWhere.Trim() !="" )
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append(" order by sortorder");
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Cms.Model.Solution model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Solutions(");
            strSql.Append("CaseTitle,Description,Solution,SucCases,ImageUrl,IsLock,SortOrder)");
            strSql.Append(" values (");
            strSql.Append("@CaseTitle,@Description,@Solution,@SucCases,@ImageUrl,@IsLock,@SortOrder)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@CaseTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@Description", SqlDbType.NText),
					new SqlParameter("@Solution", SqlDbType.NText),
					new SqlParameter("@SucCases", SqlDbType.NText),
                    new SqlParameter("@ImageUrl", SqlDbType.NVarChar,250),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@SortOrder", SqlDbType.Int,4)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.SolutionPlan;
            parameters[3].Value = model.SucCases;
            parameters[4].Value = model.ImageUrl;
            parameters[5].Value = model.IsLock;
            parameters[6].Value = model.SortOrder;

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
        public bool Update(Cms.Model.Solution model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Solutions set ");
            strSql.Append("CaseTitle=@CaseTitle,");
            strSql.Append("Description=@Description,");
            strSql.Append("Solution=@Solution,");
            strSql.Append("SucCases=@SucCases,");
            strSql.Append("ImageUrl=@ImageUrl,");
            strSql.Append("IsLock=@IsLock,");
            strSql.Append("SortOrder=@SortOrder");
            strSql.Append(" where solutionID=@solutionID");
            SqlParameter[] parameters = {
					new SqlParameter("@CaseTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@Description", SqlDbType.NText),
					new SqlParameter("@Solution", SqlDbType.NText),
					new SqlParameter("@SucCases", SqlDbType.NText),
                    new SqlParameter("@ImageUrl", SqlDbType.NVarChar,250),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@SortOrder", SqlDbType.Int,4),
                    new SqlParameter("@solutionID", SqlDbType.Int,4)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.SolutionPlan;
            parameters[3].Value = model.SucCases;
            parameters[4].Value = model.ImageUrl;
            parameters[5].Value = model.IsLock;
            parameters[6].Value = model.SortOrder;
            parameters[7].Value = model.Id;

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
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int Id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Solutions set " + strValue);
            strSql.Append(" where solutionID=" + Id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Solutions ");
            strSql.Append(" where solutionID=@solutionID");
            SqlParameter[] parameters = {
					new SqlParameter("@solutionID", SqlDbType.Int,4)
};
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
            strSql.Append("delete from Solutions ");
            strSql.Append(" where solutionID in (" + Idlist + ")  ");
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
        public Cms.Model.Solution GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SolutionID,CaseTitle,Description,Solution,SucCases,ImageUrl,IsLock,SortOrder from Solutions ");
            strSql.Append(" where SolutionID=@SolutionID");
            SqlParameter[] parameters = {
					new SqlParameter("@SolutionID", SqlDbType.Int,4)
};
            parameters[0].Value = Id;

            Cms.Model.Solution model = new Cms.Model.Solution();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SolutionID"] != null && ds.Tables[0].Rows[0]["SolutionID"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["SolutionID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CaseTitle"] != null && ds.Tables[0].Rows[0]["CaseTitle"].ToString() != "")
                {
                    model.Title = ds.Tables[0].Rows[0]["CaseTitle"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Solution"] != null && ds.Tables[0].Rows[0]["Solution"].ToString() != "")
                {
                    model.SolutionPlan = ds.Tables[0].Rows[0]["Solution"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Description"] != null && ds.Tables[0].Rows[0]["Description"].ToString() != "")
                {
                    model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SucCases"] != null && ds.Tables[0].Rows[0]["SucCases"].ToString() != "")
                {
                    model.SucCases = ds.Tables[0].Rows[0]["SucCases"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ImageUrl"] != null && ds.Tables[0].Rows[0]["ImageUrl"].ToString() != "")
                {
                    model.ImageUrl = ds.Tables[0].Rows[0]["ImageUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IsLock"] != null && ds.Tables[0].Rows[0]["IsLock"].ToString() != "")
                {
                    model.IsLock = int.Parse(ds.Tables[0].Rows[0]["IsLock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SortOrder"] != null && ds.Tables[0].Rows[0]["SortOrder"].ToString() != "")
                {
                    model.SortOrder = int.Parse(ds.Tables[0].Rows[0]["SortOrder"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
		#endregion  Method
	}
}

