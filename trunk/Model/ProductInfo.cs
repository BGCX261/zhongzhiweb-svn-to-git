using System;
namespace Cms.Model
{
	/// <summary>
	/// ProductInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProductInfo
	{
		public ProductInfo()
		{}
		#region Model
		private int _specId;
        private string _specifications;
        private int _typeId;
        private int _brandId;
        private int _nameId;
		private string _imgurl;
        private string _smallImgUrl;
        private string _description;
		private int _click=0;
		private int _istop=0;
		private DateTime _pubtime = DateTime.Now;
		/// <summary>
		/// 自增ID PK
		/// </summary>
		public int SpecId
		{
            set { _specId = value; }
            get { return _specId; }
		}
        //类型ID
        public int TypeId
        {
            set { _typeId = value; }
            get { return _typeId; }
        }
        //品牌ID
        public int BrandId
        {
            set { _brandId = value; }
            get { return _brandId; }
        }
        //名字
        public int NameId
        {
            set { _nameId = value; }
            get { return _nameId; }
        }
		/// <summary>
		/// 产品标题
		/// </summary>
        public string Specifications
		{
            set { _specifications = value; }
            get { return _specifications; }
		}
		/// <summary>
		/// 图片路径
		/// </summary>
		public string ImgUrl
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
		}
        /// <summary>
        /// 缩略图路径
        /// </summary>
        public string SmallImgUrl
        {
            set { _smallImgUrl = value; }
            get { return _smallImgUrl; }
        }
		/// <summary>
		/// 详细介绍
		/// </summary>
        public string Description
		{
            set { _description = value; }
			get{return _description;}
		}
		/// <summary>
		/// 点击次数
		/// </summary>
		public int Click
		{
			set{ _click=value;}
			get{return _click;}
		}
		/// <summary>
		/// 是否置顶
		/// </summary>
		public int IsTop
		{
			set{ _istop=value;}
			get{return _istop;}
		}
		/// <summary>
		/// 发布时间
		/// </summary>
		public DateTime PubTime
		{
			set{ _pubtime=value;}
			get{return _pubtime;}
		}
		#endregion Model

	}
}

