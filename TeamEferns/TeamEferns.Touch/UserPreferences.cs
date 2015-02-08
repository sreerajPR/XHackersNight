using System;
using Foundation;

namespace TeamEferns.Touch
{
	public class UserPreferences
	{
		public static String GetStoredValue
		{
			get { 
				string value = NSUserDefaults.StandardUserDefaults.StringForKey("UserPreferences"); 
				if (value == null)
					return "";
				else
					return value;
			}
			set {
				NSUserDefaults.StandardUserDefaults.SetString(value.ToString (), "UserPreferences"); 
				NSUserDefaults.StandardUserDefaults.Synchronize ();
			}
		}
	}
}

