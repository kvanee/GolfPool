using System.Data.Entity;
using GolfPool.Models;

namespace GolfPool.DB
{

    public class GolfPoolDBInitializer : DropCreateDatabaseIfModelChanges<GolfPoolEntities> 
    {
        protected override void Seed(GolfPoolEntities context)
        {
            var emptyGroup = new PlayerGroup("NA", 0, 0);
            context.PlayerGroups.Add(emptyGroup);
            context.PlayerGroups.Add(new PlayerGroup("Group 1 (1-5)", 1, 5));
            context.PlayerGroups.Add(new PlayerGroup("Group 2 (6-10)", 6, 10));
            context.PlayerGroups.Add(new PlayerGroup("Group 3 (11-20)", 11, 20));
            context.PlayerGroups.Add(new PlayerGroup("Group 4 (21-30)", 21, 30));
            context.PlayerGroups.Add(new PlayerGroup("Group 5 (31-40)", 31, 40));
            context.PlayerGroups.Add(new PlayerGroup("Group 6 (41-50)", 41, 50));
            context.PlayerGroups.Add(new PlayerGroup("Group 7 (51-60)", 51, 60));
            context.PlayerGroups.Add(new PlayerGroup("Group 8 (61-70)", 61, 70));
            context.PlayerGroups.Add(new PlayerGroup("Group 9 (71-100)", 71, 100));
            context.PlayerGroups.Add(new PlayerGroup("Group 10 (100+)", 101, int.MaxValue));
            context.SaveChanges();

//            var playerNames = new[]
//                {
//
//                    "Thomas Bjørn               ",
//                    "Keegan Bradley             ",
//                    "Angel Cabrera              ",
//                    "K.J. Choi                  ",
//                    "Stewart Cink               ",
//                    "Tim Clark                  ",
//                    "Darren Clarke              ",
//                    "George Coetzee             ",
//                    "Nicolas Colsaerts          ",
//                    "Fred Couples               ",
//                    "Ben Crenshaw               ",
//                    "Ben Curtis                 ",
//                    "Jason Day                  ",
//                    "Luke Donald                ",
//                    "Jamie Donaldson            ",
//                    "Jason Dufner               ",
//                    "Alan Dunbar                ",
//                    "Ernie Els                  ",
//                    "Gonzalo Fernandez-Castano  ",
//                    "Rickie Fowler              ",
//                    "Steven Fox                 ",
//                    "Hiroyuki Fujita            ",
//                    "Jim Furyk                  ",
//                    "Sergio Garcia              ",
//                    "Robert Garrigus            ",
//                    "Brian Gay                  ",
//                    "Lucas Glover               ",
//                    "Branden Grace              ",
//                    "Tianlang Guan              ",
//                    "Bill Haas                  ",
//                    "Peter Hanson               ",
//                    "Padraig Harrington         ",
//                    "Russell Henley             ",
//                    "John Huh                   ",
//                    "Trevor Immelman            ",
//                    "Ryo Ishikawa               ",
//                    "Dustin Johnson             ",
//                    "Zach Johnson               ",
//                    "Martin Kaymer              ",
//                    "Matt Kuchar                ",
//                    "Bernhard Langer            ",
//                    "Paul Lawrie                ",
//                    "Marc Leishman              ",
//                    "Sandy Lyle                 ",
//                    "David Lynn                 ",
//                    "Hunter Mahan               ",
//                    "Matteo Manassero           ",
//                    "Graeme McDowell            ",
//                    "Rory McIlroy               ",
//                    "John Merrick               ",
//                    "Phil Mickelson             ",
//                    "Larry Mize                 ",
//                    "Francesco Molinari         ",
//                    "Ryan Moore                 ",
//                    "Kevin Na                   ",
//                    "Mark O'Meara               ",
//                    "Jose Maria Olazabal        ",
//                    "Thorbjørn Olesen           ",
//                    "Louis Oosthuizen           ",
//                    "John Peterson              ",
//                    "Carl Pettersson            ",
//                    "Scott Piercy               ",
//                    "Ted Potter Jr.             ",
//                    "Ian Poulter                ",
//                    "Justin Rose                ",
//                    "Charl Schwartzel           ",
//                    "Adam Scott                 ",
//                    "John Senden                ",
//                    "Webb Simpson               ",
//                    "Vijay Singh                ",
//                    "Nathan Smith               ",
//                    "Brandt Snedeker            ",
//                    "Craig Stadler              ",
//                    "Steve Stricker             ",
//                    "Michael Thompson           ",
//                    "David Toms                 ",
//                    "Bo Van Pelt                ",
//                    "T. J. Vogel                ",
//                    "Nick Watney                ",
//                    "Bubba Watson               ",
//                    "Tom Watson                 ",
//                    "Michael Weaver             ",
//                    "Mike Weir                  ",
//                    "Lee Westwood               ",
//                    "Thaworn Wiratchant         ",
//                    "Tiger Woods                ",
//                    "Ian Woosnam                ",
//                    "Y.E. Yang                  "
//                };
//
//            playerNames.ToArray();
//
//            foreach (var playerName in playerNames)
//            {
//                context.Players.Add(new Player(playerName, emptyGroup.PlayerGroupID));
//            }
//
//            context.SaveChanges();
        }
    }
}