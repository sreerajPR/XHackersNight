
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

namespace TeamEferns.Droid
{
	[Activity (Label = "EventDetailsActivity")]			
	public class EventDetailsActivity : Activity
	{
		public static string EventName;
		public static string EventDate;
		public static string EventLocation;
		public static string EventDescription;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.EventDetails);
			FindViewById<TextView>(Resource.Id.eventDate).Text = EventDate;
			FindViewById<TextView>(Resource.Id.eventName).Text = EventName;
			FindViewById<TextView>(Resource.Id.eventLocation).Text = EventLocation;
			//FindViewById<TextView>(Resource.Id.eventDescription).Text = EventDescription;
			// Create your application here
		}
	}
}

