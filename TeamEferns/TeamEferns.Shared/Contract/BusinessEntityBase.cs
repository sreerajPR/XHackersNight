using System;
using Tasky.DL.SQLite;
namespace Tasky.BL.Contracts 
{
	public abstract class BusinessEntityBase : IBusinessEntity {
		public BusinessEntityBase ()
		{
		}

		/// <summary>
		/// Gets or sets the Database ID.
		/// </summary>
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string prof_id { get; set; }
	}
}

