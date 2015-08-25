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
	public partial class Contents
	{
		public Contents()
		{}
		#region  Method
        static public string SOLUTION_SUMMARY = "SolutionSummary";
        static public string HOME_LEFT_SUMMARY = "HomeLeftSummary";
        static public string ABOUT_COMPANY = "AboutCompany";
        static public string COMPANY_NAME = "CompanyName";
        static public string COMPANY_COPYRIGHT = "CompanyCopyRight";
        static public string COMPANY_LOGO = "CompanyLogo";
        static public string COMPANY_START_PAGE = "CompanyStartPage";
        static public string COMPANY_ADDRESS = "CompanyAddress";
        static public string COMPANY_WEBSITE = "CompanyWebSite";
        static public string COMPANY_TELEPHONE = "CompanyTelephone";
        static public string COMPANY_FAX = "CompanyFax";
        static public string COMPANY_POST_NUM = "CompanyPostNumber";
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string title)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) from CompanyInfo");
            strSql.Append(" where Title=@Title");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,50)
};
            parameters[0].Value = title;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public Cms.Model.Contents GetModel(string title)
        {
            if (this.Exists(title))
                return GetModelFromDB(title);

            Cms.Model.Contents model = new Cms.Model.Contents();
            model.Title = title;

            if (title == ABOUT_COMPANY)
            {
                model.Content = "众智电子技术服务有限责任公司是一家专业从事科技开发、应用软件开发、网络系统集成、多用户系统集成、多用途会议系统、楼宇智能、网络产品销售的高科技实体公司，公司本着\"技术为本，用户至上\"的宗旨，竭诚为客户提供应用软件开发、各类系统解决方案、咨询、施工等多项优质服务。";
            }
            else if (title == COMPANY_LOGO)
            {
                model.Content = "Images/logo.gif";
            }
            else if (title == COMPANY_START_PAGE)
            {
                model.Content = "Images/startpage.jpg";
            }
            else if (title == HOME_LEFT_SUMMARY)
            {
                model.Content = "众智推广三大领先优势";
                model.Content += "<br /><br />";
                model.Content += "1.客户覆盖面广 <br />";
                model.Content += "覆盖95%中国网民; 覆盖138个国家;全球最大的中文网站";
                model.Content += "<br />";
                model.Content += "2.按效果付费<br />";
                model.Content += "完全按照给企业带来的潜在的客户点击计费。";
                model.Content += "<br />";
                model.Content += "3.针对性强 <br />";
                model.Content += "轻松锁定目标客户根据企业潜在客户的搜索请求进行精准投放，准确性强、意向性高。";
            }
            else if (title == SOLUTION_SUMMARY)
            {
                model.Content = "众智电子技术服务有限责任公司是一家专业从事科技开发、应用软件开发、网络系统集成、多用户系统集成、多用途会议系统、楼宇智能、网络产品销售的高科技实体公司，公司本着\"技术为本，用户至上\"的宗旨，竭诚为客户提供应用软件开发、各类系统解决方案、咨询、施工等多项优质服务。";
            }
            else if (title == COMPANY_ADDRESS)
            {
                model.Content = "兰州城关区永昌路150号";
            }
            else if (title == COMPANY_WEBSITE)
            {
                model.Content = "www.xxxx.com";
            }
            else if (title == COMPANY_TELEPHONE)
            {
                model.Content = "0936-82822288(张掖分公司)";
            }
            else if (title == COMPANY_FAX)
            {
                model.Content = "XXX-XXXXXXXX转XXX";
            }
            else if (title == COMPANY_POST_NUM)
            {
                model.Content = "730000";
            }
            else if (title == COMPANY_NAME)
            {
                model.Content = "甘肃众智电子技术服务有限责任公司";
            }
            else if (title == COMPANY_COPYRIGHT)
            {
                model.Content = "CopyRight©SaintSoft工作室 Ver1.0 All Rights Reserved";
            }
            return model;
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        public bool ModifyModel(Cms.Model.Contents model)
        {
            if (this.Exists(model.Title))
            {
                return this.Update(model);
            }
            else
            {
                return this.Add(model) > 0;
            }
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(string title)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from CompanyInfo ");
            strSql.Append(" where Title=@Title");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,50)
};
            parameters[0].Value = title;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		protected Cms.Model.Contents GetModelFromDB(string title)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 Title,Content from CompanyInfo ");
            strSql.Append(" where Title=@Title");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,50)
};
            parameters[0].Value = title;

			Cms.Model.Contents model=new Cms.Model.Contents();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Title"]!=null && ds.Tables[0].Rows[0]["Title"].ToString()!="")
				{
					model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Content"]!=null && ds.Tables[0].Rows[0]["Content"].ToString()!="")
				{
					model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
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
        protected int Add(Cms.Model.Contents model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CompanyInfo(");
            strSql.Append("Title,Content)");
            strSql.Append(" values (");
            strSql.Append("@Title,@Content)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@Content", SqlDbType.NText)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.Content;

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
        protected bool Update(Cms.Model.Contents model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CompanyInfo set ");
            strSql.Append("Content=@Content");
            strSql.Append(" where Title=@Title");
            SqlParameter[] parameters = {
                    new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@Title", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.Content;
            parameters[1].Value = model.Title;

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

