using System;
namespace Cms.Model
{
	/// <summary>
	/// Channel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class NewsClass
	{
		public NewsClass()
		{}
		#region Model
		private int _classID;
		private string _title;
		private int _classOrder=0;
		/// <summary>
		/// 
		/// </summary>
		public int ClassID
		{
            set { _classID = value; }
            get { return _classID; }
		}
		/// <summary>
		/// 栏目名称
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 排序数字
		/// </summary>
		public int ClassOrder
		{
            set { _classOrder = value; }
            get { return _classOrder; }
		}
		#endregion Model

	}
}

