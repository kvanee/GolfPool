﻿using System.Collections.Generic;
using System.ComponentModel;

namespace GolfPool.Models
{
    public class Team
    {
        public int TeamID { get; set; }


        [DisplayName("Team Name")]
        public string TeamName { get; set; }
        
        [DisplayName("Your Name")]
        public string OwnerName { get; set; }

        public bool Paid { get; set; }

        [DisplayName("Group 1")]
        public int Group1GolferID { get; set; }
        public virtual Golfer Group1Golfer { get; set; }

        [DisplayName("Group 2")]
        public int Group2GolferID { get; set; }
        public virtual Golfer Group2Golfer { get; set; }

        [DisplayName("Group 3")]
        public int Group3GolferID { get; set; }
        public virtual Golfer Group3Golfer { get; set; }

        [DisplayName("Group 4")]
        public int Group4GolferID { get; set; }
        public virtual Golfer Group4Golfer { get; set; }

        [DisplayName("Group 5")]
        public int Group5GolferID { get; set; }
        public virtual Golfer Group5Golfer { get; set; }

        [DisplayName("Group 6")]
        public int Group6GolferID { get; set; }
        public virtual Golfer Group6Golfer { get; set; }

        [DisplayName("Group 7")]
        public int Group7GolferID { get; set; }
        public virtual Golfer Group7Golfer { get; set; }

        [DisplayName("Group 8")]
        public int Group8GolferID { get; set; }
        public virtual Golfer Group8Golfer { get; set; }

        public Golfer[] Golfers
        {
            get
            {
                return new[]
                           {
                               Group1Golfer,
                               Group2Golfer, 
                               Group3Golfer, 
                               Group4Golfer,
                               Group5Golfer,
                               Group6Golfer,
                               Group7Golfer,
                               Group8Golfer,
                           };
            }
        }
    }
}