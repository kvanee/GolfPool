using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GolfPool.Models
{
    public class PlayerGroup
    {
        public static readonly int Group1ID = 2;
        public static readonly int Group2ID = 3;
        public static readonly int Group3ID = 4;
        public static readonly int Group4ID = 5;
        public static readonly int Group5ID = 6;
        public static readonly int Group6ID = 7;
        public static readonly int Group7ID = 8;
        public static readonly int Group8ID = 9;
        public static readonly int Group9ID = 10;
        public static readonly int Group10ID = 11;

        public PlayerGroup(string name, int rangeStart, int rangeEnd)
        {
            this.Name = name;
            this.RangeStart = rangeStart;
            this.RangeEnd = rangeEnd;
        }

        public PlayerGroup()
        {
        }

        public string Name { get; set; }

        public int RangeStart { get; set; }

        public int RangeEnd { get; set; }

        public int PlayerGroupID { get; set; }

        
    }
}