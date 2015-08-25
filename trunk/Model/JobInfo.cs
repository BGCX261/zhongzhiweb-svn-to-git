using System;
namespace Cms.Model
{
    /// <summary>
    /// JobInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class JobInfo
    {
        public JobInfo()
        { }
        #region Model
        private int _id;
        private string _jposition;
        private int _jheadCount;
        private string _jResponsibility;
        private string _jrequire;
        private int? _islock;
        private int _jobOrder;
        /// <summary>
        /// 自增ID PK
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 岗位职称
        /// </summary>
        public string Position
        {
            set { _jposition = value; }
            get { return _jposition; }
        }
        /// <summary>
        /// 招聘人数
        /// </summary>
        public int HeadCount
        {
            set { _jheadCount = value; }
            get { return _jheadCount; }
        }
        /// <summary>
        /// 招聘要求
        /// </summary>
        public string Requirement
        {
            set { _jrequire = value; }
            get { return _jrequire; }
        }
        /// <summary>
        /// 招聘要求
        /// </summary>
        public string Responsibility
        {
            set { _jResponsibility = value; }
            get { return _jResponsibility; }
        }
        /// <summary>
        /// 是否锁定
        /// </summary>
        public int? IsLock
        {
            set { _islock = value; }
            get { return _islock; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int JobOrder
        {
            set { _jobOrder = value; }
            get { return _jobOrder; }
        }
        #endregion Model
    }
}