using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using TeamEferns.Shared;

namespace cardkeepdup.DAL
{

	public class UserRepository {
		Database db = null;
		protected static string dbLocation;		
		protected static UserRepository me;		

		static UserRepository ()
		{
			me = new UserRepository();
		}

		protected UserRepository()
		{
			// set the db location
			dbLocation = DatabaseFilePath;

			// instantiate the database	
			db = new Database(dbLocation);
		}

		public static string DatabaseFilePath {
			get { 
				var sqliteFilename = "TaskDB.db3";
				#if SILVERLIGHT
				// Windows Phone expects a local path, not absolute
				var path = sqliteFilename;
				#else



				#if __ANDROID__
				// Just use whatever directory SpecialFolder.Personal returns
				string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); ;
				#else
				// we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
				// (they don't want non-user-generated data in Documents)
				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
				string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
				#endif

				var path = Path.Combine (libraryPath, sqliteFilename);
				#endif		

				return path;	
			}
		}

//		public static Users GetUser(int id)
//		{
//			return me.db.GetItem<Users>(id);
//		}
//
//
//		public static IEnumerable<Users> GetUsers ()
//		{
//			return me.db.GetItems<Users>();
//		}

		public static IEnumerable<Categories> GetCategories ()
		{
			return me.db.GetItems<Categories>();
		}

		public static int SaveCategory (Categories item)
		{
			return me.db.SaveItem<Categories>(item);
		}

//		public static int DeleteUser(int id)
//		{
//			return me.db.DeleteItem<Users>(id);
//		}

	}

}

