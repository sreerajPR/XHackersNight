using System;
using Android.Content;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Android.App;
using TeamEferns.Shared;

namespace TeamEferns.Droid
{

	public class EventAdapter: BaseAdapter<EventViewModel>
	{
		Activity context;
		List<EventViewModel> Items;
		LayoutInflater inflater;
		public EventAdapter (Activity c, List<EventViewModel> ItemsList): base()
		{

			this.context = c;
			this.Items = ItemsList;
		}

		public override int Count {
			get { return Items.Count; }
		}

		public override Java.Lang.Object GetItem (int position)
		{
			return null;
		}
		public override EventViewModel this[int position]
		{
			get { return Items [position]; }
		}

		public override long GetItemId (int position)
		{
			return 0;
		}

		// create a new ImageView for each item referenced by the Adapter
		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			var item = this[position];
			View view = convertView;
			if (view == null) // no view to re-use, create new
				view = context.LayoutInflater.Inflate(Resource.Layout.EventListView, null);

			view.FindViewById<TextView>(Resource.Id.eventDate).Text = item.EventDate.ToString();
			view.FindViewById<TextView>(Resource.Id.eventName).Text = item.EventName;
			view.FindViewById<TextView>(Resource.Id.eventLocation).Text = item.EventLocation.ToString();

			view.Click += delegate(object sender, EventArgs e) {
				EventDetailsActivity.EventDate=item.EventDate.ToString();
				EventDetailsActivity.EventName=item.EventName.ToString();
				EventDetailsActivity.EventLocation=item.EventLocation.ToString();
				//EventDetailsActivity.EventDescription="";

				var detailActivity = new Intent (context, typeof(EventDetailsActivity));
				context.StartActivity (detailActivity);

			};
			return view;
		}
	}
}

