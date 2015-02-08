using Tasky.BL.Contracts;
using Tasky.DL.SQLite;
using System;

namespace TeamEferns.Shared
{
	public class Categories: IBusinessEntity
	{
		public Categories ()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public int ServerID { get; set; }
		public string Name { get; set; }
		public string ShortName { get; set; }
	}
}

