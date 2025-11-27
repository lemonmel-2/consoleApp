using consoleApp.model;

namespace consoleApp.service
{
    public interface IUserService
    {
        public string Login(string userId, string pwd);
        
        public string Register(string userId, string pwd);

        public bool RecordNewScore(string userId, int score);

        public User[] GetLeaderboard();
    }
}