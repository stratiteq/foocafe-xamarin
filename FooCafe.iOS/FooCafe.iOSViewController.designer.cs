// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace FooCafe.iOS
{
	[Register ("FooCafe_iOSViewController")]
	partial class FooCafe_iOSViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITableView matchTableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (matchTableView != null) {
				matchTableView.Dispose ();
				matchTableView = null;
			}
		}
	}
}
