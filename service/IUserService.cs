namespace consoleApp.service
{
    public interface IUserService
    {
        public string Auth(string userId, string pwd);

        public bool RecordNewScore(string userId, int score);

        public User[] GetLeaderboard();
    }
}