using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FooCafe.Shared;

namespace FooCafe.Droid
{
	[Activity (Label = "FooCafe.Droid", MainLauncher = true)]
	public class MainActivity : Activity
	{
		readonly MatchesViewModel vm = new MatchesViewModel();
		ListView listView;
		Adapter adapter;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			listView = FindViewById<ListView> (Resource.Id.matchListView);
			listView.Adapter = adapter = new Adapter (this, vm);
			// Get our button from the layout resource,
			// and attach an event to it
		}

		protected async override void OnResume ()
		{
			base.OnResume ();

			await vm.GetMatches();
			adapter.NotifyDataSetInvalidated();
		}
	}
}


