using System;

namespace TeamEferns.Shared
{
	public class CategoryListVoewModel
	{
		public CategoryListVoewModel ()
		{
		}
		public int ServerID { get; set; }
		public string Name { get; set; }
		public string ShortName { get; set; }
		public bool selected{ get; set;}
	}
}

