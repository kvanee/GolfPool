using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace GolfPool.Models
{
    public class PlayerAdministration 
    {
        private string NameWorldRankRegex = @"<a target=""_parent"" href=""/players/bio.sps.*Rank=(?<rank>[0-9]*).*>(?<name>.*)</a>";
        //http://www.masters.com/en_US/players/invitees_2013.html
        public IEnumerable<Player> GetPlayers()
        {
            var webClient = new WebClient();
            webClient.BaseAddress = "http://www.masters.com/en_US/players/invitees_2013.html";
            var page = webClient.DownloadString("");
            var regex = new Regex(@"<div class=""item""><b>(?<name>[a-zA-Zø ]*)</b>");
            var matches = regex.Matches(page);
            foreach (Match match in matches)
            {
                var name = match.Groups["name"].Value;
                yield return new Player(name, 1);
            }
        }

        public IEnumerable<Player> GetWorldRankings(IList<Player> players)
        {
            var webClient = new WebClient();
            webClient.BaseAddress = "http://www.officialworldgolfranking.com";
            webClient.QueryString.Add("region","world");
            webClient.QueryString.Add("PageCount","1");

            var names = players.Select(x => x.FullName).ToList();

            int pageCountLimit = 31;
            int pageCount = 0;
            while (names.Count > 0 && pageCount < pageCountLimit)
            {
                pageCount++;
                webClient.QueryString["PageCount"] = pageCount.ToString();
                var page = webClient.DownloadString("/rankings/default.sps");
                var regex = new Regex(NameWorldRankRegex);

                var matches = regex.Matches(page);
                foreach (Match match in matches)
                {
                    var name = match.Groups["name"].Value;
                    var player = players.SingleOrDefault(x => string.Compare(x.FullName, name, StringComparison.InvariantCultureIgnoreCase) == 0);
                    if (player != null)
                    {
                        player.Rank = Convert.ToInt32(match.Groups["rank"].Value);
                        yield return player;
                        names.Remove(name);
                    }
                }
            }
            if (names.Count > 0)
            {
                Console.WriteLine("Couldnt find all names");
            }
        }
    }
}
