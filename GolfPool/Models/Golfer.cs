using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolfPool.Models
{
    public class Golfer
    {
        public Golfer(string name, int playerGroupID)
        {
            FullName = name.Trim();
            GolferGroupID = playerGroupID;
        }

        public Golfer()
        {
        }

        public int GolferID { get; set; }

        public string FullName { get; set; }

        public int Rank { get; set; }

        public int Score { get; set; }

        public int GolferGroupID { get; set; }
        public GolferGroup GolferGroup { get; set; }

        public string Position { get; set; }

        [NotMapped]
        public string Day1 { get; set; }

        [NotMapped]
        public string Day2 { get; set; }
        
        [NotMapped]
        public string Day3 { get; set; }

        [NotMapped]
        public string Day4 { get; set; }

        [NotMapped]
        public string Today { get; set; }

        [NotMapped]
        public string Thru { get; set; }

        [NotMapped]
        public string LastUpdate { get; set; }

        public bool UpdateScore(int score)
        {
            if (Score != score)
            {
                Score = score;
                return true;
            }
            return false;
        }

        public bool UpdatePosition(string position)
        {
            position = position.Trim();
            if (Position != position)
            {
                Position = position;
                return true;
            }
            return false;
        }

        public void UpdateDay(int day, string value)
        {
            value = value.Trim();
            switch (day)
            {
                case 1:
                    Day1 = value;
                    break;
                case 2:
                    Day1 = value;
                    break;
                case 3:
                    Day1 = value;
                    break;
                case 4:
                    Day1 = value;
                    break;
            }
        }

        public bool UpdateToday(string today)
        {
            today = today.Trim();
            if (Today != today)
            {
                Today = today;
                return true;
            }
            return false;
        }

        public bool UpdateThru(string thru)
        {
            thru = thru.Trim();
            if (Thru != thru)
            {
                Thru = thru;
                return true;
            }
            return false;
        }
    }
}