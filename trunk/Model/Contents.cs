using System;
namespace Cms.Model
{
	/// <summary>
	/// Contents:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Contents
	{
		public Contents()
		{}
		#region Model
		private string _title;
		private string _content;
		/// <summary>
		/// 内容标题
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 详细介绍
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		#endregion Model

	}
}

