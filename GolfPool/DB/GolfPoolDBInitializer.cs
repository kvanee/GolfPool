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
        }
    }
}