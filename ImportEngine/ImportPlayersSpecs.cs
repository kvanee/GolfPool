using System;
using System.IO;
using System.Text.RegularExpressions;
using GolfPool.DB;
using GolfPool.Models;
using NUnit.Framework;
using SpecsFor;

namespace ImportEngine
{
    public class ImportPlayersSpecs : SpecsFor<PlayerAdministration>
    {
//        [Test]
//        public void I_should_be_able_to_get_players_world_ranking()
//        {
//            //SUT.GetWorldRankings(new[] { new Player("Tiger Woods", TODO), });
//        }
//
//        [Test]
//        public void I_should_be_able_to_drop_and_create_db()
//        {
//            GolfPoolEntities.RecreateAndSeedDB();
//            var repo = new Repository(new GolfPoolEntities());
//            repo.Insert(new GolferGroup());
//            repo.Save();
//
//        }
    }

    public class UpdateScoresSpecs : SpecsFor<PlayerAdministration>
    {
//        [Test]
//        public void I_should_be_able_to_import_during_the_tournament()
//        {
//            string file = File.ReadAllText(@".\ActiveTournamentSample.txt");
//            var startIndex = file.IndexOf("leaderboardtable");
//            file = file.Substring(startIndex, file.Length - startIndex);
//            Test(file);
//        }
//
//        [Test]
//        public void I_should_be_able_to_import_before_the_tournament()
//        {
//            string file = File.ReadAllText(@".\PreTournamentSample.txt");
//            var startIndex = file.IndexOf("leaderboardtable");
//            file = file.Substring(startIndex, file.Length - startIndex);
//            Test(file);
//        }
//
//        [Test]
//        public void I_should_be_able_to_import_after_the_tournament()
//        {
//            string file = File.ReadAllText(@".\PostTournamentSample.txt");
//            var startIndex = file.IndexOf("leaderboardtable");
//            file = file.Substring(startIndex, file.Length - startIndex);
//            Test(file);
//        }
//
//        public void Test(string file)
//        {
//            var regex = PlayerAdministration.DetermineRegex(file);
//            var matches = regex.Matches(file);
//            foreach (Match match in matches)
//            {
//                Console.WriteLine("Name " + match.Groups["name"].Value.Trim().Trim('*'));
//                Console.WriteLine("score " + match.Groups["score"]);
//                Console.WriteLine("position " + match.Groups["position"].Value);
//                Console.WriteLine("today " + match.Groups["today"].Value);
//                Console.WriteLine("thru " + match.Groups["thru"].Value);
//                for (int i = 1; i <= 4; i++)
//                {
//                    Console.WriteLine("day " + i + match.Groups["day" + i].Value);
//                }
//                break;
//            }
//        }
//
//        [Test]
//        public void I_should_be_able_to_drop_and_create_db()
//        {
//            GolfPoolEntities.RecreateAndSeedDB();
//            var repo = new Repository(new GolfPoolEntities());
//            repo.Insert(new GolferGroup());
//            repo.Save();
//
//        }
    }
}