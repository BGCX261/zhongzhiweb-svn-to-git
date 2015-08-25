using System;
namespace Cms.Model
{
    /// <summary>
    /// NewsInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class NewsInfo
    {
        public NewsInfo()
        { }
        #region Model
        private int _newsID;
        private string _title;
        private string _author;
        private int _classid;
        private string _content;
        private int _click = 0;
        private int _istop = 0;
        private int _isLock = 0;
        private DateTime _pubtime = DateTime.Now;
        /// <summary>
        /// 自增ID PK
        /// </summary>
        public int NewsID
        {
            set { _newsID = value; }
            get { return _newsID; }
        }
        /// <summary>
        /// 新闻标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 发布人
        /// </summary>
        public string Author
        {
            set { _author = value; }
            get { return _author; }
        }
        /// <summary>
        /// 所属类别
        /// </summary>
        public int ClassId
        {
            set { _classid = value; }
            get { return _classid; }
        }
        /// <summary>
        /// 新闻内容
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 点击次数
        /// </summary>
        public int Click
        {
            set { _click = value; }
            get { return _click; }
        }
        /// <summary>
        /// 是否置顶
        /// </summary>
        public int IsTop
        {
            set { _istop = value; }
            get { return _istop; }
        }
        /// <summary>
        /// 是否可见
        /// </summary>
        public int IsLock
        {
            set { _isLock = value; }
            get { return _isLock; }
        }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime PubTime
        {
            set { _pubtime = value; }
            get { return _pubtime; }
        }
        #endregion Model

    }
}