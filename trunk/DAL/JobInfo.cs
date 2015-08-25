using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Cms.DAL
{
	/// <summary>
	/// 数据访问类:JobInfo
	/// </summary>
	public partial class JobInfo
	{
		public JobInfo()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperSQL.GetMaxID("JobId", "JobList"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int jobID)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) from JobList");
            strSql.Append(" where JobId=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
            parameters[0].Value = jobID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select JobID,Position,Requirement,Responsibility,HeadCount,IsLock ");
            strSql.Append(" FROM JobList ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append(" order by JobOrder");
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Cms.Model.JobInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into JobList(");
            strSql.Append("Position,Requirement,Responsibility,HeadCount,IsLock,JobOrder)");
            strSql.Append(" values (");
            strSql.Append("@Position,@Requirement,@Responsibility,@HeadCount,@IsLock,@JobOrder)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Position", SqlDbType.NVarChar,50),
					new SqlParameter("@Requirement", SqlDbType.NText),
					new SqlParameter("@Responsibility", SqlDbType.NText),
					new SqlParameter("@HeadCount", SqlDbType.Int,4),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@JobOrder", SqlDbType.Int,4)};
            parameters[0].Value = model.Position;
            parameters[1].Value = model.Requirement;
            parameters[2].Value = model.Responsibility;
            parameters[3].Value = model.HeadCount;
            parameters[4].Value = model.IsLock;
            parameters[5].Value = model.JobOrder;

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
        public bool Update(Cms.Model.JobInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update JobList set ");
            strSql.Append("Position=@Position,");
            strSql.Append("Requirement=@Requirement,");
            strSql.Append("Responsibility=@Responsibility,");
            strSql.Append("HeadCount=@HeadCount,");
            strSql.Append("IsLock=@IsLock,");
            strSql.Append("JobOrder=@JobOrder");
            strSql.Append(" where JobID=@JobID");
            SqlParameter[] parameters = {
					new SqlParameter("@Position", SqlDbType.NVarChar,50),
					new SqlParameter("@Requirement", SqlDbType.NText),
					new SqlParameter("@Responsibility", SqlDbType.NText),
					new SqlParameter("@HeadCount", SqlDbType.Int,4),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@JobOrder", SqlDbType.Int,4),
                    new SqlParameter("@JobID", SqlDbType.Int,4)};
            parameters[0].Value = model.Position;
            parameters[1].Value = model.Requirement;
            parameters[2].Value = model.Responsibility;
            parameters[3].Value = model.HeadCount;
            parameters[4].Value = model.IsLock;
            parameters[5].Value = model.JobOrder;
            parameters[6].Value = model.Id;

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
            strSql.Append("update JobList set " + strValue);
            strSql.Append(" where JobID=" + Id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from JobList ");
            strSql.Append(" where JobID=@JobID");
            SqlParameter[] parameters = {
					new SqlParameter("@JobID", SqlDbType.Int,4)
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
            strSql.Append("delete from JobList ");
            strSql.Append(" where JobID in (" + Idlist + ")  ");
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
        public Cms.Model.JobInfo GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 JobID,Position,Requirement,Responsibility,HeadCount,IsLock,JobOrder from JobList ");
            strSql.Append(" where JobID=@JobID");
            SqlParameter[] parameters = {
					new SqlParameter("@JobID", SqlDbType.Int,4)
};
            parameters[0].Value = Id;

            Cms.Model.JobInfo model = new Cms.Model.JobInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["JobID"] != null && ds.Tables[0].Rows[0]["JobID"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["JobID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Position"] != null && ds.Tables[0].Rows[0]["Position"].ToString() != "")
                {
                    model.Position = ds.Tables[0].Rows[0]["Position"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Requirement"] != null && ds.Tables[0].Rows[0]["Requirement"].ToString() != "")
                {
                    model.Requirement = ds.Tables[0].Rows[0]["Requirement"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Responsibility"] != null && ds.Tables[0].Rows[0]["Responsibility"].ToString() != "")
                {
                    model.Responsibility = ds.Tables[0].Rows[0]["Responsibility"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HeadCount"] != null && ds.Tables[0].Rows[0]["HeadCount"].ToString() != "")
                {
                    model.HeadCount = int.Parse(ds.Tables[0].Rows[0]["HeadCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsLock"] != null && ds.Tables[0].Rows[0]["IsLock"].ToString() != "")
                {
                    model.IsLock = int.Parse(ds.Tables[0].Rows[0]["IsLock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["JobOrder"] != null && ds.Tables[0].Rows[0]["JobOrder"].ToString() != "")
                {
                    model.JobOrder = int.Parse(ds.Tables[0].Rows[0]["JobOrder"].ToString());
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

