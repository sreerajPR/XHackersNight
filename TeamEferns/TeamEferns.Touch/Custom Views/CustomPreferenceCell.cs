using System;
using UIKit;
using CoreGraphics;

namespace TeamEferns.Touch
{
	public class CustomPreferenceCell:UITableViewCell
	{
		public UILabel preferenceName;
		public UISwitch preferenceChoice;
		public CustomPreferenceCell (string cellId): base (UITableViewCellStyle.Default, cellId)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Gray;
			ContentView.BackgroundColor = UIColor.Clear;
			preferenceName = new UILabel () {
				Font = UIFont.FromName("Arial", 15f),
				TextColor = UIColor.White,
				BackgroundColor = UIColor.Clear,
				TextAlignment = UITextAlignment.Center
			};
			preferenceChoice = new UISwitch ();

			ContentView.AddSubviews(new UIView[] {preferenceName, preferenceChoice});
		}
		public void UpdateCell (string preferenceNamestring,bool isOn)
		{
			preferenceName.Text = preferenceNamestring;
			preferenceChoice.On = isOn;
		}
		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			preferenceName.Frame = new CGRect (10, 6, 200, 40);
			preferenceChoice.Frame = new CGRect (220, 6, 50, 40);
		}

	}
}

