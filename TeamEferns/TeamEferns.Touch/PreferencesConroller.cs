using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.Generic;
using Newtonsoft.Json;
using TeamEferns.Shared;
using Tasky.BL.Managers;
using System.Linq;

namespace TeamEferns.Touch
{
	partial class PreferencesConroller : UIViewController
	{

		public PreferencesConroller (IntPtr handle) : base (handle)
		{
		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			var categoryList = Manager.Getcategories ();
			var categoryListViewModel = new List<CategoryListVoewModel> ();
			var prefList = JsonConvert.DeserializeObject<List<int>> (UserPreferences.GetStoredValue.ToString ());
			foreach (var item in categoryList) {
				var categoryItem = new CategoryListVoewModel () {
					ServerID=item.ServerID,
					Name=item.Name,
					ShortName=item.ShortName,
					selected=prefList.Contains(item.ServerID)?true:false
				};
				categoryListViewModel.Add (categoryItem);
			}
			preferencesList.Source = new PreferneceSource (categoryListViewModel);
		}
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);


		}
		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		partial void saveButton_TouchUpInside (UIButton sender)
		{
			var prefList = (from p in PreferneceSource.tableItems
					where p.selected == true
				select p.ServerID).ToList();
			var prefJson= JsonConvert.SerializeObject(prefList);
			UserPreferences.GetStoredValue=prefJson;

		}
	}
}
