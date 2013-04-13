using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using GolfPool.DB;
using GolfPool.Hubs;

namespace GolfPool.Models
{
    public class PlayerAdministration 
    {
        private string NameWorldRankRegex = @"<a target=""_parent"" href=""/players/bio.sps.*Rank=(?<rank>[0-9]*)(?s).*?>(?<name>.*?)</a>";
        //http://www.masters.com/en_US/players/invitees_2013.html

        public static string sourceURL = "http://ca.sports.yahoo.com/golf/pga/leaderboard";

        public static string headRegexStr = "<thead>(?s).*?</thead>";
        public static string activeRegex = "<tr(?s).*?<td .*?>(?<position>.*?)</td>(?s).*?<a .*?>(?<name>.*?)</a>(?s).*?<td .*?>(?<day1>.*?)</td>(?s).*?<td .*?>(?<day2>.*?)</td>(?s).*?<td .*?>(?<day3>.*?)</td>(?s).*?<td .*?>(?<day4>.*?)</td>(?s).*?<td .*?>(?<today>.*?)</td>(?s).*?<td .*?>(?<thru>.*?)</td>(?s).*?<td .*?>(?<score>.*?)</td>(?s).*?<td .*?>(?<strokes>.*?)</td>(?s).*?</tr>";
        public static string preRegex = "<tr(?s).*?<td(?s).*?<a .*?>(?<name>.*?)</a>(?s).*?<td .*?>(?<day1>.*?)</td>(?s).*?<td .*?>(?<day2>.*?)</td>(?s).*?<td .*?>(?<day3>.*?)</td>(?s).*?<td .*?>(?<day4>.*?)</td>(?s).*?<td .*?>(?<today>.*?)</td>(?s).*?<td .*?>(?<thru>.*?)</td>(?s).*?<td .*?>(?<score>.*?)</td>(?s).*?</tr>";
        public static string postRegex = "<tr(?s).*?<td .*?>(?<position>.*?)</td>(?s).*?<a .*?>(?<name>.*?)</a>(?s).*?<td .*?>(?<day1>.*?)</td>(?s).*?<td .*?>(?<day2>.*?)</td>(?s).*?<td .*?>(?<day3>.*?)</td>(?s).*?<td .*?>(?<day4>.*?)</td>(?s).*?<td .*?>(?<today>.*?)</td>(?s).*?<td .*?>(?<score>.*?)</td>(?s).*?</tr>";

        public IEnumerable<Golfer> GetPlayers()
        {
            var webClient = new WebClient();
            webClient.BaseAddress = "http://www.masters.com/en_US/players/invitees_2013.html";
            //var page = webClient.DownloadString("");
            var page =
                @"<div id=""inviteesList""><div class=""inviteesListColumn"" style=""margin-right:22px;""><div class=""item""><b>Thomas Bjørn</b> (18)<br>Denmark</div><div class=""item""><b>Keegan Bradley</b> (4,14,15,16,17,18)<br>United States of America</div><div class=""item""><b>Angel Cabrera</b> (1)<br>Argentina</div><div class=""item""><b>K.J. Choi</b> (5,18)<br>Korea</div><div class=""item""><b>Stewart Cink</b> (3)<br>United States of America</div><div class=""item""><b>Tim Clark</b> (5)<br>South Africa</div><div class=""item""><b>Darren Clarke</b> (3)<br>Northern Ireland</div><div class=""item""># <b>George Coetzee</b> (18)<br>South Africa</div><div class=""item""># <b>Nicolas Colsaerts</b> (18)<br>Belgium</div><div class=""item""><b>Fred Couples</b> (1,11)<br>United States of America</div><div class=""item""><b>Ben Crenshaw</b> (1)<br>United States of America</div><div class=""item""><b>Ben Curtis</b> (15,16)<br>United States of America</div><div class=""item""><b>Jason Day</b> (18)<br>Australia</div><div class=""item""><b>Luke Donald</b> (15,17,18)<br>England</div><div class=""item""># <b>Jamie Donaldson</b> (18)<br>Wales</div><div class=""item""><b>Jason Dufner</b> (12,15,16,17,18)<br>United States of America</div><div class=""item"">#* <b>Alan Dunbar</b> (7)<br>Northern Ireland</div><div class=""item""><b>Ernie Els</b> (3,15,17,18)<br>South Africa</div><div class=""item""><b>Gonzalo Fernandez-Castano</b> (18)<br>Spain</div><div class=""item""><b>Rickie Fowler</b> (15,16,17,18)<br>United States of America</div><div class=""item"">#* <b>Steven Fox</b> (6-A)<br>United States of America</div><div class=""item""><b>Hiroyuki Fujita</b> (18)<br>Japan</div><div class=""item""><b>Jim Furyk</b> (11,12,15,17,18)<br>United States of America</div><div class=""item""><b>Sergio Garcia</b> (11,15,16,17,18)<br>Spain</div><div class=""item""><b>Robert Garrigus</b> (15,17,18)<br>United States of America</div><div class=""item""><b>Brian Gay</b> (16)<br>United States of America</div><div class=""item""><b>Lucas Glover</b> (2)<br>United States of America</div><div class=""item""># <b>Branden Grace</b> (18)<br>South Africa</div><div class=""item"">#* <b>Tianlang Guan</b> (8)<br>China</div><div class=""item""><b>Bill Haas</b> (18)<br>United States of America</div><div class=""item""><b>Peter Hanson</b> (11,18)<br>Sweden</div><div class=""item""><b>Padraig Harrington</b> (3,4,11,12)<br>Ireland</div><div class=""item""># <b>Russell Henley</b> (16)<br>United States of America</div><div class=""item""># <b>John Huh</b> (15,17)<br>United States of America</div><div class=""item""><b>Trevor Immelman</b> (1)<br>South Africa</div><div class=""item"">^ <b>Ryo Ishikawa</b> <br>Japan</div><div class=""item""><b>Dustin Johnson</b> (15,16,17,18)<br>United States of America</div><div class=""item""><b>Zach Johnson</b> (1,15,16,17,18)<br>United States of America</div><div class=""item""><b>Martin Kaymer</b> (4,18)<br>Germany</div><div class=""item""><b>Matt Kuchar</b> (5,11,15,17,18)<br>United States of America</div><div class=""item""><b>Bernhard Langer</b> (1)<br>Germany</div><div class=""item""><b>Paul Lawrie</b> (18)<br>Scotland</div><div class=""item""><b>Marc Leishman</b> (16)<br>Australia</div><div class=""item""><b>Sandy Lyle</b> (1)<br>Scotland</div></div><div class=""inviteesListColumn""><div class=""item""># <b>David Lynn</b> (14,18)<br>England</div><div class=""item""><b>Hunter Mahan</b> (11,15,17,18)<br>United States of America</div><div class=""item""><b>Matteo Manassero</b> (18)<br>Italy</div><div class=""item""><b>Graeme McDowell</b> (2,11,12,18)<br>Northern Ireland</div><div class=""item""><b>Rory McIlroy</b> (2,4,15,16,17,18)<br>Northern Ireland</div><div class=""item""><b>John Merrick</b> (16)<br>United States of America</div><div class=""item""><b>Phil Mickelson</b> (1,11,15,16,17,18)<br>United States of America</div><div class=""item""><b>Larry Mize</b> (1)<br>United States of America</div><div class=""item""><b>Francesco Molinari</b> (18)<br>Italy</div><div class=""item""><b>Ryan Moore</b> (15,17,18)<br>United States of America</div><div class=""item""><b>Kevin Na</b> (11)<br>United States of America</div><div class=""item""><b>Mark O'Meara</b> (1)<br>United States of America</div><div class=""item""><b>Jose Maria Olazabal</b> (1)<br>Spain</div><div class=""item""># <b>Thorbjørn Olesen</b> (18)<br>Denmark</div><div class=""item""><b>Louis Oosthuizen</b> (3,11,15,17,18)<br>South Africa</div><div class=""item""># <b>John Peterson</b> (12)<br>United States of America</div><div class=""item""><b>Carl Pettersson</b> (14,15,16,17,18)<br>Sweden</div><div class=""item""># <b>Scott Piercy</b> (15,16,17,18)<br>United States of America</div><div class=""item""># <b>Ted Potter Jr.</b> (16)<br>United States of America</div><div class=""item""><b>Ian Poulter</b> (11,14,18)<br>England</div><div class=""item""><b>Justin Rose</b> (11,14,15,17,18)<br>England</div><div class=""item""><b>Charl Schwartzel</b> (1,18)<br>South Africa</div><div class=""item""><b>Adam Scott</b> (11,13,15,17,18)<br>Australia</div><div class=""item""><b>John Senden</b> (17,18)<br>Australia</div><div class=""item""><b>Webb Simpson</b> (2,15,17,18)<br>United States of America</div><div class=""item""><b>Vijay Singh</b> (1)<br>Fiji</div><div class=""item"">* <b>Nathan Smith</b> (10)<br>United States of America</div><div class=""item""><b>Brandt Snedeker</b> (13,15,16,17,18)<br>United States of America</div><div class=""item""><b>Craig Stadler</b> (1)<br>United States of America</div><div class=""item""><b>Steve Stricker</b> (15,17,18)<br>United States of America</div><div class=""item""><b>Michael Thompson</b> (12)<br>United States of America</div><div class=""item""><b>David Toms</b> (12,18)<br>United States of America</div><div class=""item""><b>Bo Van Pelt</b> (15,17,18)<br>United States of America</div><div class=""item"">#* <b>T. J. Vogel</b> (9)<br>United States of America</div><div class=""item""><b>Nick Watney</b> (15,16,17,18)<br>United States of America</div><div class=""item""><b>Bubba Watson</b> (1,5,17,18)<br>United States of America</div><div class=""item""><b>Tom Watson</b> (1)<br>United States of America</div><div class=""item"">#* <b>Michael Weaver</b> (6-B)<br>United States of America</div><div class=""item""><b>Mike Weir</b> (1)<br>Canada</div><div class=""item""><b>Lee Westwood</b> (11,15,17,18)<br>England</div><div class=""item"">^# <b>Thaworn Wiratchant</b> <br>Thailand</div><div class=""item""><b>Tiger Woods</b> (1,2,13,15,16,17,18)<br>United States of America</div><div class=""item""><b>Ian Woosnam</b> (1)<br>Wales</div><div class=""item""><b>Y.E. Yang</b> (4)<br>Korea</div></div></div>";
            var regex = new Regex(@"<div class=""item""><b>(?<name>[a-zA-Zø ]*)</b>");
            var matches = regex.Matches(page);
            foreach (Match match in matches)
            {
                var name = match.Groups["name"].Value;
                yield return new Golfer(name, 1);
            }
        }

        public IEnumerable<Golfer> GetWorldRankings(IList<Golfer> players)
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

        public static void UpdateScoresFromSource(bool force)
        {
            try
            {
                var now = TimeZoneInfo.ConvertTime(DateTime.Now,
                                                           TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time"));
                var repository = new Repository(new GolfPoolEntities());
                var webClient = new WebClient();
                webClient.BaseAddress = sourceURL;
                var page = webClient.DownloadString("");
                var startIndex = page.IndexOf("leaderboardtable");
                page = page.Substring(startIndex, page.Length- startIndex);
                UpdateGolfers(force, page, repository, now);
                repository.Save();
                LeaderboardHub.UpdateLastUpdateDisplay(now);
            }
            catch (Exception e)
            {
            }
        }

        public static void UpdateGolfers(bool force, string page, IRepository repository, DateTime now)
        {
            
            var golfers = repository.All<Golfer>().ToDictionary(x => x.FullName, x => x);
            
            
            var regex = DetermineRegex(page);
            var matches = regex.Matches(page);
            foreach (Match match in matches)
            {
                var name = match.Groups["name"].Value.Trim().Trim('*');
                if (golfers.ContainsKey(name))
                {
                    var dirty = false;
                    var golfer = golfers[name];
                    int score;
                    string scoreText = match.Groups["score"].Value.Trim();
                    if (int.TryParse(scoreText, out score))
                    {
                        dirty |= golfer.UpdateScore(score);
                    }
                    else if (scoreText == "E" || scoreText == "-")
                    {
                        dirty |= golfer.UpdateScore(0);
                    }
                    else if ((scoreText == "CUTT" || match.Groups["day3"].Value == "CUTT" || match.Groups["day3"].Value == "MC") && match.Groups["strokes"] != null)
                    {
                        int strokes;
                        string strokesText = match.Groups["strokes"].Value.Trim();
                        if (int.TryParse(strokesText, out strokes))
                        {
                            //160 = 72 + 8 * 2 (+8 for last two days)
                            dirty |= golfer.UpdateScore(strokes + 160);
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(match.Groups["position"].Value))
                    {
                        dirty |= golfer.UpdatePosition(match.Groups["position"].Value);
                    }
                    if (!string.IsNullOrWhiteSpace(match.Groups["today"].Value))
                    {
                        dirty |= golfer.UpdateToday(match.Groups["today"].Value);
                    }
                    if (!string.IsNullOrWhiteSpace(match.Groups["thru"].Value))
                    {
                        dirty |= golfer.UpdateThru(match.Groups["thru"].Value);
                    }
                    for (int i = 1; i <= 4; i++)
                    {
                        golfer.UpdateDay(i, match.Groups["day" + i].Value);
                    }
                    if (dirty || force)
                    {
                        golfer.LastUpdate = now.ToShortTimeString() + " " + now.ToShortDateString();
                        sendUpdate(golfer, repository);
                    }
                }
            }
        }

        public static Regex DetermineRegex(string page)
        {
            var theadRegex = new Regex(headRegexStr);

            var head = theadRegex.Match(page).Value;

            if (head.Contains("earnings"))
                return new Regex(postRegex);

            if (head.Contains("position"))
                return new Regex(activeRegex);

            return new Regex(preRegex);
        }

        private static void sendUpdate(Golfer golfer, IRepository repository)
        {
            repository.Update(golfer);
            LeaderboardHub.UpdateScore(golfer);
        }
    }
}
