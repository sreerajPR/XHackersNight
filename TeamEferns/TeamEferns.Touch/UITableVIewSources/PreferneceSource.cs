using System;
using UIKit;
using System.Collections.Generic;
using TeamEferns.Shared;
using Foundation;
using System.Linq;

namespace TeamEferns.Touch
{
	public class PreferneceSource: UITableViewSource
	{
		public static List<CategoryListVoewModel> tableItems;
		string cellIdentifier = "TableCell";
		public PreferneceSource (List<CategoryListVoewModel> items)
		{
			tableItems = items;
		}
		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return (nint)tableItems.Count;
		}
		public override UITableViewCell GetCell (UITableView tableView,NSIndexPath indexPath)
		{

			var cell = tableView.DequeueReusableCell (cellIdentifier) as CustomPreferenceCell;
			// if there are no cells to reuse, create a new one
			if (cell == null)
				cell = new CustomPreferenceCell (cellIdentifier);
			cell.UpdateCell (tableItems.ElementAt (indexPath.Row).Name,tableItems.ElementAt(indexPath.Row).selected);
			cell.BackgroundColor = UIColor.FromRGB (145, 212, 222);
			cell.preferenceChoice.ValueChanged+= delegate(object sender, EventArgs e) {
				var UISwitch= sender as UISwitch;
				if(UISwitch.On)
				{
					tableItems[indexPath.Row].selected=true;
				}
				else
				{
					tableItems[indexPath.Row].selected=false;
				}
			};
			return cell;

		}
	}
}

