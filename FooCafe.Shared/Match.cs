using System;

namespace FooCafe.Shared
{
	public class Match
	{
		public Match ()
		{
		}

		public string ChannelName {
			get;
			set;
		}
		public bool IsLive {
			get;
			set;
		}

		public string LeagueName {
			get;
			set;
		}

		public int MatchId {
			get;
			set;
		}

		public DateTime StartDate {
			get;
			set;
		}

		public string Title {
			get;
			set;
		}

		public string TitleFormated {
			get {
				return string.Format ("{0}: {1}", StartDate.ToString ("d/M HH:mm"), Title);
			}
		}
	}
}

