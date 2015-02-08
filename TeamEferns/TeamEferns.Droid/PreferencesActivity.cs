
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Tasky.BL.Managers;

namespace TeamEferns.Droid
{
	[Activity (Label = "PreferencesActivity")]			
	public class PreferencesActivity : Activity
	{
		List<CategoryViewModel> items = new List<CategoryViewModel> ();
		public static List<int> categoryIds = new List<int> ();
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Preferences);

			var categoryList = Manager.Getcategories ();
			var categoryListViewModel = new List<CategoryViewModel> ();
			//var prefList = JsonConvert.DeserializeObject<List<int>> (UserPreferences.GetStoredValue.ToString ());
			foreach (var item in categoryList) {
				var categoryItem = new CategoryViewModel () {
					CategoryId=item.ID,
					CategoryName=item.Name,
					CategoryShortName=item.ShortName
				};
				items.Add (categoryItem);
			}


			var listView = FindViewById<ListView> (Resource.Id.categoryList);
			listView.Adapter =  new CategoryAdapter (this, items);
			Button proceed = FindViewById<Button> (Resource.Id.save);

			proceed.Click += delegate {
				var con = ((Context)this);
				var shared = con.GetSharedPreferences ("Teameferns", FileCreationMode.WorldWriteable);
				var edit = shared.Edit ();
				var JsonString=JsonConvert.SerializeObject(categoryIds);
				edit.PutString("UserPrefernces", JsonString);
				edit.Commit ();
				categoryIds = new List<int> ();
				var detailActivity = new Intent (this, typeof(EventListActivity));
				StartActivity (detailActivity);
			};
		}
	}
}

