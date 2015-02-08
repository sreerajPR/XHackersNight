
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
using TeamEferns.Shared;
using Newtonsoft.Json;

namespace TeamEferns.Droid
{
	[Activity (Label = "EventListActivity")]			
	public class EventListActivity : Activity
	{
		List<EventViewModel> items = new List<EventViewModel> ();
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.EventList);

			var con = ((Context)this);
			var shared = con.GetSharedPreferences ("Teameferns", FileCreationMode.WorldReadable);
			var value = shared.All.Where (x => x.Key == "UserPrefernces").FirstOrDefault ().Value.ToString();
			var prefList = JsonConvert.DeserializeObject<List<int>> (value);

			//items = MeetupAPI.GetJson (prefList,(12.96).ToString(),(77.56).ToString());
			PopulateTableView (prefList);

		}
		public async void PopulateTableView(List<int> prefList)
		{
			Toast.MakeText (this, "Results are being fetched", ToastLength.Long).Show ();

			var eventListViewModel=await MeetupAPI.GetJson (prefList,(12.96).ToString(),(77.56).ToString());
			RunOnUiThread (() => {
				var listView = FindViewById<ListView> (Resource.Id.eventList);
				listView.Adapter =  new EventAdapter (this, eventListViewModel);
			});

		}
	}
}

