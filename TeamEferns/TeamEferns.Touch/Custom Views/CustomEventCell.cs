using System;
using UIKit;
using CoreGraphics;

namespace TeamEferns.Touch
{
	public class CustomEventCell:UITableViewCell
	{
		public UILabel eventDate, eventName, eventLocation;
		public CustomEventCell (string cellId): base (UITableViewCellStyle.Default, cellId)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Gray;
			ContentView.BackgroundColor = UIColor.Clear;
			eventName = new UILabel () {
				Font = UIFont.FromName("Arial", 15f),
				TextColor = UIColor.Red,
				BackgroundColor = UIColor.Clear,
				TextAlignment = UITextAlignment.Left,
				Lines=0,
				LineBreakMode=UILineBreakMode.WordWrap
			};
			eventLocation = new UILabel () {
				Font = UIFont.FromName("Arial", 11f),
				TextColor = UIColor.Black,
				BackgroundColor = UIColor.Clear

			};
			eventDate = new UILabel () {
				Font = UIFont.FromName("Arial", 11f),
				TextColor = UIColor.White,
				BackgroundColor = UIColor.Clear
			};

			ContentView.AddSubviews(new UIView[] {eventName, eventDate,eventLocation});
		}


		public void UpdateCell (string date, string name, string location)
		{
			eventDate.Text = date;
			eventName.Text = name;
			eventLocation.Text = location;
		}
		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			eventDate.Frame = new CGRect (10, 60, 100, 20);
			eventName.Frame = new CGRect (10, 6, 320, 50);
			eventLocation.Frame = new CGRect (120, 60, 200, 20);
		}
	}

}

