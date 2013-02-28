using System.Collections.Generic;
using System.Data.Entity;
using System.Web;
using GolfPool.Models;

namespace GolfPool.DB
{
    public class GolfPoolEntities : DbContext
    {
        public DbSet<PlayerGroup> PlayerGroups { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }

        public static void RecreateAndSeedDB()
        {

            //TODO: Remove after development
            Database.SetInitializer(new GolfPoolDBInitializer());
        }


    }
}