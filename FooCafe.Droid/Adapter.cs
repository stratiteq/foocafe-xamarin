using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FooCafe.Shared;

namespace FooCafe.Droid
{
	public class Adapter : BaseAdapter<Match>
	{
		readonly LayoutInflater inflater;
		MatchesViewModel vm;

		public Adapter (Context context, MatchesViewModel vm)
		{
			inflater = (LayoutInflater)context.GetSystemService (Context.LayoutInflaterService);
			this.vm = vm;
		}

		public override long GetItemId (int position)
		{
			return vm.Matches [position].MatchId;
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			if (convertView == null) {
				convertView = inflater.Inflate (Resource.Layout.MatchListItem, null);
			}

			var currentMatch = this [position];
			var title = convertView.FindViewById<TextView> (Resource.Id.titleLabel);
			var channel = convertView.FindViewById<TextView> (Resource.Id.channelLabel);

			title.Text = currentMatch.TitleFormated;
			channel.Text = currentMatch.ChannelName;

			return convertView;
		}

		public override int Count {
			get {
				return vm.Matches == null ? 0 : vm.Matches.Length;
			}
		}

		public override Match this [int index] {
			get {
				return vm.Matches [index];
			}
		}
	}
}

