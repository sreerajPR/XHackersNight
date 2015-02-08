using System;
using System.Collections.Generic;
using TeamEferns.Shared;
using System.Threading.Tasks;
using System.Linq;

namespace Tasky.BL.Managers
{
	public static class Manager
	{
		static Manager ()
		{
		}


		public static int SaveCategory (Categories item)
		{
			return cardkeepdup.DAL.UserRepository.SaveCategory(item);
		}
		public static List<Categories> Getcategories ()
		{
			return cardkeepdup.DAL.UserRepository.GetCategories ().ToList();
		}

	}
}