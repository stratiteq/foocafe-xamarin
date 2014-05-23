using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using FooCafe.Shared;

namespace FooCafe.iOS
{
	public class TableSource : UITableViewSource
	{
		const string CellName = "MatchCell";
		MatchesViewModel vm;

		public TableSource (MatchesViewModel vm)
		{
			this.vm = vm;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return vm.Matches == null ? 0 : vm.Matches.Length;
		}

		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			var currentMatch = vm.Matches [indexPath.Row];
			var cell = tableView.DequeueReusableCell (CellName);
			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Subtitle, CellName);
				cell.Accessory = UITableViewCellAccessory.None;
			}

			cell.TextLabel.Text = currentMatch.TitleFormated;
			cell.DetailTextLabel.Text = currentMatch.ChannelName;
			return cell;
		}
	}
}

