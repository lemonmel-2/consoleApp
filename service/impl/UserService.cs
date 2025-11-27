using consoleApp.@enum;
using consoleApp.exception;
using consoleApp.model;
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
            if (user == null)
            {
                throw new GameException(ErrorCode.USER_NOT_EXIST);
            }
            else if(user.Pwd != pwd)
            {
                throw new GameException(ErrorCode.INCORRECT_PASSWORD);
            }

            return userId;
        }
        
        public User[] GetLeaderboard()
        {
            User[] users = _userRepo.GetTopUsers();
            return users;
        }
    }
}