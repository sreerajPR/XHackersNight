using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using Tasky.BL.Managers;
using TeamEferns.Shared;

namespace TeamEferns.Touch
{
	partial class LoginViewController : UIViewController
	{
		public LoginViewController (IntPtr handle) : base (handle)
		{
		}

		partial void UIButton6_TouchUpInside (UIButton sender)
		{
			// Code for FB Authentication
		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			SyncDB ();
		}
		void SyncDB()
		{
			var categoryListCount = Manager.Getcategories ().Count;
			if (categoryListCount < 1) {
				ServerSync.SyncCategories ();
			}
		}
	}
}
