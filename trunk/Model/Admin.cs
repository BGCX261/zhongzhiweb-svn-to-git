using System;
namespace Cms.Model
{
	/// <summary>
	/// Admin:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Admin
	{
		public Admin()
		{}
        #region Model
        private int _id;
        private string _username;
        private string _userpwd;
        private string _realname;
        private int _departID = 34;
        private int _roleID = 1;
        private int _staffID;
        private string _telephone;
        private string _address;
        private string _userBH;
        private DateTime? _logintime = DateTime.Now;
        /// <summary>
        /// 自增ID PK
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 登录用户名
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName
        {
            set { _realname = value; }
            get { return _realname; }
        }  
        /// <summary>
        /// 登录密码
        /// </summary>
        public string UserPwd
        {
            set { _userpwd = value; }
            get { return _userpwd; }
        }
        /// <summary>
        /// 部门ID
        /// </summary>
        public int DepartID
        {
            set { _departID = value; }
            get { return _departID; }
        }
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleID
        {
            set { _roleID = value; }
            get { return _roleID; }
        }
        /// <summary>
        /// 员工ID
        /// </summary>
        public int StaffID
        {
            set { _staffID = value; }
            get { return _staffID; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string Telephone
        {
            set { _telephone = value; }
            get { return _telephone; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 员工编号
        /// </summary>
        public string UserBH
        {
            set { _userBH = value; }
            get { return _userBH; }
        }
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime? LoginTime
        {
            set { _logintime = value; }
            get { return _logintime; }
        }
		#endregion Model

	}
}

