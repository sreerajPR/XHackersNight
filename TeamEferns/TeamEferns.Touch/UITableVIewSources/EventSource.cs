using System;
using UIKit;
using System.Collections.Generic;
using TeamEferns.Shared;
using Foundation;
using System.Linq;


namespace TeamEferns.Touch
{
	public class EventSource: UITableViewSource
	{
		List<EventViewModel> tableItems;
		string cellIdentifier = "TableCell";
		public EventSource (List<EventViewModel> items)
		{
			tableItems = items;
		}
		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return (nint)tableItems.Count;
		}
		public override nfloat GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return 100;
		}
		public override UITableViewCell GetCell (UITableView tableView,NSIndexPath indexPath)
		{

			var cell = tableView.DequeueReusableCell (cellIdentifier) as CustomEventCell;
				// if there are no cells to reuse, create a new one
				if (cell == null)
				cell = new CustomEventCell (cellIdentifier);
				cell.UpdateCell (tableItems.ElementAt (indexPath.Row).EventDate
					, tableItems.ElementAt (indexPath.Row).EventName, tableItems.ElementAt (indexPath.Row).EventLocation);
				cell.BackgroundColor = UIColor.FromRGB (145, 212, 222);
				return cell;

		}
	}
}

