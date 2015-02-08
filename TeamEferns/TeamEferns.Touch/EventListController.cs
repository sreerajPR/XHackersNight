using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using TeamEferns.Shared;
using System.Collections.Generic;
using Newtonsoft.Json;
using MonoTouch.Dialog;

namespace TeamEferns.Touch
{
	partial class EventListController : UITableViewController
	{

		public EventListController (IntPtr handle) : base (handle)
		{
		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			var prefList = JsonConvert.DeserializeObject<List<int>> (UserPreferences.GetStoredValue.ToString ());
			PopulateTableView (prefList);
		}
		public async void PopulateTableView(List<int> prefList)
		{
			var loadingOverlay = new LoadingOverlay(View.Bounds);
			View.Add(loadingOverlay);
			var eventListViewModel=await MeetupAPI.GetJson (prefList,(12.96).ToString(),(77.56).ToString());
			TableView.Source = new EventSource (eventListViewModel);
			loadingOverlay.RemoveFromSuperview ();
		}
	}
}
