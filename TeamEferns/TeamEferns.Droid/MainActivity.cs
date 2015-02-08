using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
//using Xamarin.Geolocation;
using System.Threading.Tasks;
//using Microsoft.WindowsAzure.MobileServices;
using Tasky.BL.Managers;
using TeamEferns.Shared;

namespace TeamEferns.Droid
{
	[Activity (Label = "TeamEferns.Droid", Icon = "@drawable/icon", MainLauncher = true)]
	public class MainActivity : Activity
	{

		//private MobileServiceUser user;
		//private MobileServiceClient client=new MobileServiceClient("https://apps.facebook.com/teamefern","425954570903299");

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);

			Button signup = FindViewById<Button> (Resource.Id.signin);

			signup.Click += async (sender, e) => {
				var detailActivity = new Intent (this, typeof(PreferencesActivity));
				StartActivity (detailActivity);
			};
			SyncDB ();

		}
		void SyncDB()
		{
			var categoryListCount = Manager.Getcategories ().Count;
			if (categoryListCount < 1) {
				ServerSync.SyncCategories ();
			}
		}

	}
}



