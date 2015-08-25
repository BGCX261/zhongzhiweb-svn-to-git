using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Model
{
    /// <summary>
    /// JobInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Solution
    {
        public Solution()
        { }
        #region Model
        private int _id;
        private string _caseTitle;
        private string _description;
        private string _solution;
        private string _SucCases;
        private string _imageUrl;
        private int? _islock;
        private int _sortOrder;
        /// <summary>
        /// 自增ID PK
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 安例标题
        /// </summary>
        public string Title
        {
            set { _caseTitle = value; }
            get { return _caseTitle; }
        }
        /// <summary>
        /// 案例描述
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 解决方案
        /// </summary>
        public string SolutionPlan
        {
            set { _solution = value; }
            get { return _solution; }
        }
        /// <summary>
        /// 成功案例
        /// </summary>
        public string SucCases
        {
            set { _SucCases = value; }
            get { return _SucCases; }
        }
        /// <summary>
        /// 案例图片
        /// </summary>
        public string ImageUrl
        {
            set { _imageUrl = value; }
            get { return _imageUrl; }
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
        public int SortOrder
        {
            set { _sortOrder = value; }
            get { return _sortOrder; }
        }
        #endregion Model
    }
}
