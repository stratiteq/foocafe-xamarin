using System;
using System.Threading.Tasks;

namespace FooCafe.Shared
{
	public class MatchesViewModel
	{
		public Match[] Matches { get; set; }

		public MatchesViewModel ()
		{
		}

		public async Task GetMatches() {
			var client = new ServiceClient<Match[]> ("http://todaysmatches.azurewebsites.net/api/matches/get");
			Matches = await client.GetResult ();
		}
	}
}

