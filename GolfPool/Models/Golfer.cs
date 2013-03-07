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
    }
}