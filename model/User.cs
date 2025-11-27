namespace consoleApp.model
{
    public class User
    {
        public string UserId { get; set; } 

        public string Pwd { get; set; } 

        public int HighestScore { get; set; } 

        public Dictionary<string, Item> Items { get; set; }

        public User(string userId, string pwd)
        {
            this.UserId = userId;
            this.Pwd = pwd;
            this.HighestScore = 0;
            this.Items = new Dictionary<string, Item>();
        }

        public User(string userId, string pwd, int highestScore)
        {
            this.UserId = userId;
            this.Pwd = pwd;
            this.HighestScore = highestScore;
            this.Items = new Dictionary<string, Item>();
        }
    }
}