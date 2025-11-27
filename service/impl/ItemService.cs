using consoleApp.@enum;
using consoleApp.exception;
using consoleApp.model;

namespace consoleApp.service.impl
{
    public class ItemService : IItemService
    {
        private static IUserRepo _userRepo = new UserRepo();

        private static Random rand = new Random();
        private static Dictionary<string, string> itemsLibrary = new Dictionary<string, string>()
        {
            {"invader001", "purple invader"},
            {"invader002", "blue invader"},
            {"invader003", "pink invader"},
            {"food001", "burger"},
            {"food002", "carrot"}
        };


        public void AddItem(string userId, string itemId)
        {
            try
            {
                 User user = _userRepo.GetUser(userId);
                Dictionary<string, Item> userItems = user.Items;
                if(userItems.ContainsKey(itemId))
                {
                    user.Items[itemId].Quantity += 1;
                }
                else
                {
                    Item item = new Item(itemId, itemsLibrary[itemId], 1);
                    user.Items.Add(itemId, item);
                }
                _userRepo.UpdateUser(user);
            }
            catch(KeyNotFoundException)
            {
                throw new GameException(ErrorCode.INVALID_ITEM);
            }
        }

        public Item GenerateItem(string userId)
        {
            var keyList = new List<string>(itemsLibrary.Keys);
            string randomKey = keyList[rand.Next(keyList.Count)];
            Item item = new(randomKey, itemsLibrary[randomKey], 0);
            return item;
        }

        public Item[] GetItems(string userId)
        {
            User user = _userRepo.GetUser(userId);
            return user.Items.Values.ToArray();
        }
    }
}