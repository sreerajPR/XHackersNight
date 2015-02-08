using System;
using Android.Content;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Android.App;

namespace TeamEferns.Droid
{
	public class CategoryViewModel
	{
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
		public string CategoryShortName { get; set; }
	}
	public class CategoryAdapter: BaseAdapter<CategoryViewModel>
	{
		Activity context;
		List<CategoryViewModel> Items;
		LayoutInflater inflater;
		public CategoryAdapter (Activity c, List<CategoryViewModel> ItemsList): base()
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
		public override CategoryViewModel this[int position]
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
				view = context.LayoutInflater.Inflate(Resource.Layout.CategoryListView, null);

			view.FindViewById<CheckBox>(Resource.Id.chkList).Text = item.CategoryName.ToString();
			view.FindViewById<CheckBox> (Resource.Id.chkList).Click += async (sender, e) => {
				if (view.FindViewById<CheckBox> (Resource.Id.chkList).Checked) 
				{
					PreferencesActivity.categoryIds.Add(item.CategoryId);
				} 
				else 
				{
					PreferencesActivity.categoryIds.Remove(item.CategoryId);
				}

			};

			return view;
		}
	}
}

