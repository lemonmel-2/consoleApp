using consoleApp.@enum;
using consoleApp.exception;
using consoleApp.model;
using consoleApp.service;
using consoleApp.service.impl;

namespace consoleApp.controller
{
    public class GameController
    {
        private static IItemService _itemService = new ItemService();

        private static IUserService _userService = new UserService();

        private string userId;

        public bool Auth(string authInfo)
        {
            try
            {
                string[] auth = authInfo.Split(" ");
                userId = _userService.Auth(auth[0], auth[1]);
                return true;
            }
            catch(IndexOutOfRangeException)
            {
                throw new GameException(ErrorCode.PARAM_ILLEGAL);
            }
        }

        public void RecordScore(string score)
        {
            try
            {
                int scoreNumber = int.Parse(score);
                bool breakRecord =  _userService.RecordNewScore(userId, scoreNumber);
                if (breakRecord)
                {
                    Console.WriteLine("New highest record achieved! :"+score);
                }
            }
            catch(FormatException)
            {
                throw new GameException(ErrorCode.PARAM_ILLEGAL);
            }
        }

        public void ShowItem()
        {
            Item[] items = _itemService.GetItems(userId);
            Console.WriteLine("==========INVENTORY===========");
            if(items.Length == 0)
            {
                Console.WriteLine("you have nothing in your backpack :(");
            }
            else
            {
                Console.WriteLine($"{"ITEM", -20} {"QUANTITY"}");
                foreach(Item item in items)
                {
                    Console.WriteLine($"{item.Name, -20} {item.Quantity}");
                }
            }
        }

        public string GenerateItem()
        {
            Item newItem = _itemService.GenerateItem(userId);
            return newItem.ItemID;
        }

        public void AddItem(string itemId)
        {
            if(itemId == null)
            {
                throw new GameException(ErrorCode.PARAM_ILLEGAL);
            }
            _itemService.AddItem(userId, itemId);
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
