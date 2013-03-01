using System.Data.Entity;
using GolfPool.Models;

namespace GolfPool.DB
{

    public class GolfPoolDBInitializer : DropCreateDatabaseAlways<GolfPoolEntities> 
    {
        protected override void Seed(GolfPoolEntities context)
        {
            var emptyGroup = new GolferGroup("NA", 0, 0);
            context.GolferGroups.Add(emptyGroup);
            context.GolferGroups.Add(new GolferGroup("Group 1 (1-5)", 1, 5));
            context.GolferGroups.Add(new GolferGroup("Group 2 (6-10)", 6, 10));
            context.GolferGroups.Add(new GolferGroup("Group 3 (11-20)", 11, 20));
            context.GolferGroups.Add(new GolferGroup("Group 4 (21-30)", 21, 30));
            context.GolferGroups.Add(new GolferGroup("Group 5 (31-40)", 31, 40));
            context.GolferGroups.Add(new GolferGroup("Group 6 (41-50)", 41, 50));
            context.GolferGroups.Add(new GolferGroup("Group 7 (51-100)", 51, 100));
            context.GolferGroups.Add(new GolferGroup("Group 8 (100+)", 101, int.MaxValue));
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