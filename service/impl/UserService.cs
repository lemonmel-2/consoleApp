using consoleApp.service;

namespace consoleApp.service.impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo = new UserRepo();
        public bool RecordNewScore(string userId, int score)
        {
            User user = _userRepo.GetUser(userId);
            if(score > user.HighestScore)
            {
                user.HighestScore = score;
                _userRepo.UpdateUser(user);
                return true;
            }
            return false;
        }

        public string Auth(string userId, string pwd)
        {
            User user = _userRepo.GetUser(userId);
            if (user != null && pwd == user.Pwd)
            {
                return user.UserId;
            }
            return null;
        }
        
        public User[] GetLeaderboard()
        {
            User[] users = _userRepo.GetTopUsers();
            return users;
        }
    }
}