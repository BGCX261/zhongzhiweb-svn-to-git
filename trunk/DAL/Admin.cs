using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references

namespace Cms.DAL
{
    /// <summary>
    /// 数据访问类:Admin
    /// </summary>
    public partial class Admin
    {
        public Admin()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("userid", "UserInfo");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UserInfo");
            strSql.Append(" where userid=@userid");
            SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 检查用户名是否重复
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public bool Exists(string UserName)
        {
            string strSql = "select count(*) from UserInfo where username=@username";
            SqlParameter[] parameters = {
                new SqlParameter("@username",SqlDbType.NVarChar,30)};
            parameters[0].Value = UserName;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 检查登录用户
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="UserPwd">密码</param>
        /// <returns></returns>
        public bool chkAdminLogin(string UserName, string UserPwd)
        {
            string strSql = "select count(*) from UserInfo where username=@username and password=@password and roleid = '1'";
            SqlParameter[] parameters = {
                new SqlParameter("@username",SqlDbType.NVarChar,30),
                new SqlParameter("@password", SqlDbType.NVarChar,50)};
            parameters[0].Value = UserName;
            parameters[1].Value = UserPwd;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Cms.Model.Admin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Staff(");
            strSql.Append("StaffName,StaffTel,StaffAddres)");
            strSql.Append(" values (");
            strSql.Append("@StaffName,@StaffTel,@StaffAddres)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffName", SqlDbType.VarChar,50),
					new SqlParameter("@StaffTel", SqlDbType.VarChar,50),
					new SqlParameter("@StaffAddres", SqlDbType.VarChar,50)};
            parameters[0].Value = model.RealName;
            parameters[1].Value = model.Telephone;
            parameters[2].Value = model.Address;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                model.StaffID =  Convert.ToInt32(obj);
            }

            strSql = new StringBuilder();
            strSql.Append("insert into UserInfo(");
            strSql.Append("username,password,realname2,departmentId,roleid,StaffId,userbh)");
            strSql.Append(" values (");
            strSql.Append("@username,@password,@realname2,@departmentId,@roleid,@StaffId,@userbh)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parametersUser = {
					new SqlParameter("@username", SqlDbType.NVarChar,50),
					new SqlParameter("@password", SqlDbType.Char,32),
					new SqlParameter("@realname2", SqlDbType.NVarChar,50),
					new SqlParameter("@departmentId", SqlDbType.Int,4),
					new SqlParameter("@roleid", SqlDbType.Int,4),
					new SqlParameter("@StaffId", SqlDbType.Int,4),
					new SqlParameter("@userbh", SqlDbType.NVarChar,50)};
            parametersUser[0].Value = model.UserName;
            parametersUser[1].Value = model.UserPwd;
            parametersUser[2].Value = model.RealName;
            parametersUser[3].Value = model.DepartID;
            parametersUser[4].Value = model.RoleID;
            parametersUser[5].Value = model.StaffID;
            parametersUser[6].Value = model.UserBH;

            obj = DbHelperSQL.GetSingle(strSql.ToString(), parametersUser);
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
        public bool Update(Cms.Model.Admin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Staff set ");
            strSql.Append("StaffName=@StaffName,");
            strSql.Append("StaffTel=@StaffTel,");
            strSql.Append("StaffAddres=@StaffAddres");
            strSql.Append(" where StaffId=@StaffId");

            SqlParameter[] parameters = {
					new SqlParameter("@StaffName", SqlDbType.VarChar,50),
					new SqlParameter("@StaffTel", SqlDbType.VarChar,50),
					new SqlParameter("@StaffAddres", SqlDbType.VarChar,50),
					new SqlParameter("@StaffId", SqlDbType.Int,4),};
            parameters[0].Value = model.RealName;
            parameters[1].Value = model.Telephone;
            parameters[2].Value = model.Address;
            parameters[3].Value = model.StaffID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
            }
            else
            {
                return false;
            }

            strSql = new StringBuilder();
            strSql.Append("update UserInfo set ");
            strSql.Append("username=@username,");
            strSql.Append("password=@password,");
            strSql.Append("realname2=@realname2,");
            strSql.Append("departmentId=@departmentId,");
            strSql.Append("roleid=@roleid,");
            strSql.Append("StaffId=@StaffId,");
            strSql.Append("userbh=@userbh");
            strSql.Append(" where userid=@userid");

            SqlParameter[] parametersUser = {
					new SqlParameter("@username", SqlDbType.NVarChar,50),
					new SqlParameter("@password", SqlDbType.Char,32),
					new SqlParameter("@realname2", SqlDbType.NVarChar,50),
					new SqlParameter("@departmentId", SqlDbType.Int,4),
					new SqlParameter("@roleid", SqlDbType.Int,4),
					new SqlParameter("@StaffId", SqlDbType.Int,4),
					new SqlParameter("@userbh", SqlDbType.NVarChar,50),
                    new SqlParameter("@userid", SqlDbType.Int,4)};
            parametersUser[0].Value = model.UserName;
            parametersUser[1].Value = model.UserPwd;
            parametersUser[2].Value = model.RealName;
            parametersUser[3].Value = model.DepartID;
            parametersUser[4].Value = model.RoleID;
            parametersUser[5].Value = model.StaffID;
            parametersUser[6].Value = model.UserBH;
            parametersUser[7].Value = model.Id;

            rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parametersUser);
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
            Cms.Model.Admin model = GetModelByID(Id);
            if (model == null)
                return false;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from UserInfo ");
            strSql.Append(" where userid=@userid");
            SqlParameter[] parametersUser = {
					new SqlParameter("@userid", SqlDbType.Int,4)};
            parametersUser[0].Value = Id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parametersUser);
            if (rows > 0)
            {
            }
            else
            {
                return false;
            }

            strSql = new StringBuilder();

            strSql.Append("delete from Staff ");
            strSql.Append(" where StaffId=@StaffId");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffId", SqlDbType.Int,4)};
            parameters[0].Value = model.StaffID;

            rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 根据用户名取得一行数据给Model
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public Cms.Model.Admin GetModelByName(string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 userid,username,password,realname2,departmentId,roleid,StaffId,userbh from UserInfo ");
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,30)
                                        };
            parameters[0].Value = UserName;

            Cms.Model.Admin model = new Cms.Model.Admin();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["userid"] != null && ds.Tables[0].Rows[0]["userid"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["username"] != null && ds.Tables[0].Rows[0]["username"].ToString() != "")
                {
                    model.UserName = ds.Tables[0].Rows[0]["username"].ToString();
                }
                if (ds.Tables[0].Rows[0]["password"] != null && ds.Tables[0].Rows[0]["password"].ToString() != "")
                {
                    model.UserPwd = ds.Tables[0].Rows[0]["password"].ToString();
                }
                if (ds.Tables[0].Rows[0]["realname2"] != null && ds.Tables[0].Rows[0]["realname2"].ToString() != "")
                {
                    model.RealName = ds.Tables[0].Rows[0]["realname2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["departmentId"] != null && ds.Tables[0].Rows[0]["departmentId"].ToString() != "")
                {
                    model.DepartID = int.Parse(ds.Tables[0].Rows[0]["departmentId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["roleid"] != null && ds.Tables[0].Rows[0]["roleid"].ToString() != "")
                {
                    model.RoleID = int.Parse(ds.Tables[0].Rows[0]["roleid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StaffId"] != null && ds.Tables[0].Rows[0]["StaffId"].ToString() != "")
                {
                    model.StaffID = int.Parse(ds.Tables[0].Rows[0]["StaffId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["userbh"] != null && ds.Tables[0].Rows[0]["userbh"].ToString() != "")
                {
                    model.UserBH = ds.Tables[0].Rows[0]["userbh"].ToString();
                }

                strSql = new StringBuilder();
                strSql.Append("select  top 1 StaffName,StaffTel,StaffAddres from Staff ");
                strSql.Append(" where StaffId=@StaffId ");
                SqlParameter[] parametersStaff = {
					new SqlParameter("@StaffId", SqlDbType.Int,4)};
                parametersStaff[0].Value = model.StaffID;

                DataSet dsStaff = DbHelperSQL.Query(strSql.ToString(), parametersStaff);
                if (dsStaff.Tables[0].Rows.Count > 0)
                {
                    if (dsStaff.Tables[0].Rows[0]["StaffTel"] != null && dsStaff.Tables[0].Rows[0]["StaffTel"].ToString() != "")
                    {
                        model.Telephone = dsStaff.Tables[0].Rows[0]["StaffTel"].ToString();
                    }
                    if (dsStaff.Tables[0].Rows[0]["StaffAddres"] != null && dsStaff.Tables[0].Rows[0]["StaffAddres"].ToString() != "")
                    {
                        model.Address = dsStaff.Tables[0].Rows[0]["StaffAddres"].ToString();
                    }
                    return model;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据用户ID取得一行数据给Model
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public Cms.Model.Admin GetModelByID(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 userid,username,password,realname2,departmentId,roleid,StaffId,userbh from UserInfo ");
            strSql.Append(" where userid=@userid ");
            SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.Int,30)
                                        };
            parameters[0].Value = ID;

            Cms.Model.Admin model = new Cms.Model.Admin();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["userid"] != null && ds.Tables[0].Rows[0]["userid"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["username"] != null && ds.Tables[0].Rows[0]["username"].ToString() != "")
                {
                    model.UserName = ds.Tables[0].Rows[0]["username"].ToString();
                }
                if (ds.Tables[0].Rows[0]["password"] != null && ds.Tables[0].Rows[0]["password"].ToString() != "")
                {
                    model.UserPwd = ds.Tables[0].Rows[0]["password"].ToString();
                }
                if (ds.Tables[0].Rows[0]["realname2"] != null && ds.Tables[0].Rows[0]["realname2"].ToString() != "")
                {
                    model.RealName = ds.Tables[0].Rows[0]["realname2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["departmentId"] != null && ds.Tables[0].Rows[0]["departmentId"].ToString() != "")
                {
                    model.DepartID = int.Parse(ds.Tables[0].Rows[0]["departmentId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["roleid"] != null && ds.Tables[0].Rows[0]["roleid"].ToString() != "")
                {
                    model.RoleID = int.Parse(ds.Tables[0].Rows[0]["roleid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StaffId"] != null && ds.Tables[0].Rows[0]["StaffId"].ToString() != "")
                {
                    model.StaffID = int.Parse(ds.Tables[0].Rows[0]["StaffId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["userbh"] != null && ds.Tables[0].Rows[0]["userbh"].ToString() != "")
                {
                    model.UserBH = ds.Tables[0].Rows[0]["userbh"].ToString();
                }

                strSql = new StringBuilder();
                strSql.Append("select  top 1 StaffName,StaffTel,StaffAddres from Staff ");
                strSql.Append(" where StaffId=@StaffId ");
                SqlParameter[] parametersStaff = {
					new SqlParameter("@StaffId", SqlDbType.Int,4)};
                parametersStaff[0].Value = model.StaffID;

                DataSet dsStaff = DbHelperSQL.Query(strSql.ToString(), parametersStaff);
                if (dsStaff.Tables[0].Rows.Count > 0)
                {
                    if (dsStaff.Tables[0].Rows[0]["StaffTel"] != null && dsStaff.Tables[0].Rows[0]["StaffTel"].ToString() != "")
                    {
                        model.Telephone = dsStaff.Tables[0].Rows[0]["StaffTel"].ToString();
                    }
                    if (dsStaff.Tables[0].Rows[0]["StaffAddres"] != null && dsStaff.Tables[0].Rows[0]["StaffAddres"].ToString() != "")
                    {
                        model.Address = dsStaff.Tables[0].Rows[0]["StaffAddres"].ToString();
                    }
                    return model;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select userid,username,password,realname2,a.departmentId,roleid,a.StaffId,userbh,StaffTel,StaffAddres ");
            strSql.Append(" FROM UserInfo AS a INNER JOIN Staff AS b ON a.StaffId = b.StaffId ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere + " AND roleid = '1'");
            }
            else
                strSql.Append(" where roleid = '1'");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  Method
    }
}