namespace GolfPool.Models
{
    public class Player
    {
        public Player(string name, int playerGroupID)
        {
            FullName = name.Trim();
            PlayerGroupID = playerGroupID;
        }

        public Player()
        {
        }

        public int PlayerID { get; set; }

        public string FullName { get; set; }

        public int Rank { get; set; }

        public int PlayerGroupID { get; set; }
        public PlayerGroup PlayerGroup { get; set; }
    }
}