using consoleApp.model;
using consoleApp.service;
using consoleApp.service.impl;

namespace consoleApp.controller
{
    public class GameController
    {
        private readonly IItemService _itemService = new ItemService();

        private readonly IUserService _userService = new UserService();

        private string userId;

        public bool Auth(string authInfo)
        {
            string[] auth = authInfo.Split(" ");
            userId = _userService.Auth(auth[0], auth[1]);
            return userId != null;
        }

        public void RecordScore(int score)
        {
           bool breakRecord =  _userService.RecordNewScore(userId, score);
            if (breakRecord)
            {
                Console.WriteLine("New highest record achieved! :"+score);
            }
        }

        public void ShowItem()
        {
            Item[] items = _itemService.GetItems(userId);
            Console.WriteLine("Your Backpack:");
            foreach(Item item in items)
            {
                Console.WriteLine(item);
            }
        }

        public void AddItem()
        {
            Item newItem = _itemService.GenerateItem();
            _itemService.AddItem(userId, newItem);
            Console.WriteLine("Congratulation! You received a "+newItem);
        }

        public void ShowLeaderboard()
        {
            User[] users = _userService.GetLeaderboard();
            Console.WriteLine("==========LEADERBOARD=========");
            Console.WriteLine($"{"USER", -15} {"HIGHEST RECORD"}");
            foreach(User user in users)
            {
                Console.WriteLine($"{user.UserId, -15} {user.HighestScore, 14}");
            }
        }


    }
}
