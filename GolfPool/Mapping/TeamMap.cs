using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using GolfPool.Models;

namespace GolfPool.Mapping
{
    public class TeamMap : EntityTypeConfiguration<Team>
    {
        public TeamMap()
        {
            HasRequired(x => x.Group1Golfer).WithMany().HasForeignKey(x => x.Group1GolferID);
            HasRequired(x => x.Group2Golfer).WithMany().HasForeignKey(x => x.Group2GolferID);
            HasRequired(x => x.Group3Golfer).WithMany().HasForeignKey(x => x.Group3GolferID);
            HasRequired(x => x.Group4Golfer).WithMany().HasForeignKey(x => x.Group4GolferID);
            HasRequired(x => x.Group5Golfer).WithMany().HasForeignKey(x => x.Group5GolferID);
            HasRequired(x => x.Group6Golfer).WithMany().HasForeignKey(x => x.Group6GolferID);
            HasRequired(x => x.Group7Golfer).WithMany().HasForeignKey(x => x.Group7GolferID);
            HasRequired(x => x.Group8Golfer).WithMany().HasForeignKey(x => x.Group8GolferID);
        }
    }
}