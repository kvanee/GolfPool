using System.Collections.Generic;
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

        [DisplayName("Group 1")]
        public int Group1PlayerID { get; set; }
        public Player Group1Player { get; set; }

        [DisplayName("Group 2")]
        public int Group2PlayerID { get; set; }
        public Player Group2Player { get; set; }

        [DisplayName("Group 3")]
        public int Group3PlayerID { get; set; }
        public Player Group3Player { get; set; }

        [DisplayName("Group 4")]
        public int Group4PlayerID { get; set; }
        public Player Group4Player { get; set; }

        [DisplayName("Group 5")]
        public int Group5PlayerID { get; set; }
        public Player Group5Player { get; set; }

        [DisplayName("Group 6")]
        public int Group6PlayerID { get; set; }
        public Player Group6Player { get; set; }

        [DisplayName("Group 7")]
        public int Group7PlayerID { get; set; }
        public Player Group7Player { get; set; }

        [DisplayName("Group 8")]
        public int Group8PlayerID { get; set; }
        public Player Group8Player { get; set; }

        [DisplayName("Group 9")]
        public int Group9PlayerID { get; set; }
        public Player Group9Player { get; set; }

        [DisplayName("Group 10")]
        public int Group10PlayerID { get; set; }
        public Player Group10Player { get; set; }
    }
}