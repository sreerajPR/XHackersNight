// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace TeamEferns.Touch
{
	[Register ("PreferencesConroller")]
	partial class PreferencesConroller
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel eMail { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel firstName { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lastName { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel location { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView preferencesList { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIScrollView preferencesScroll { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton saveButton { get; set; }

		[Action ("saveButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void saveButton_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (eMail != null) {
				eMail.Dispose ();
				eMail = null;
			}
			if (firstName != null) {
				firstName.Dispose ();
				firstName = null;
			}
			if (lastName != null) {
				lastName.Dispose ();
				lastName = null;
			}
			if (location != null) {
				location.Dispose ();
				location = null;
			}
			if (preferencesList != null) {
				preferencesList.Dispose ();
				preferencesList = null;
			}
			if (preferencesScroll != null) {
				preferencesScroll.Dispose ();
				preferencesScroll = null;
			}
			if (saveButton != null) {
				saveButton.Dispose ();
				saveButton = null;
			}
		}
	}
}
