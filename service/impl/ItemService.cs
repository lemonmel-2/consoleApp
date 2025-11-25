using consoleApp.model;

namespace consoleApp.service.impl
{
    public class ItemService : IItemService
    {
        private readonly IUserRepo _userRepo = new UserRepo();
        public void AddItem(string userId, Item item)
        {
            User user = _userRepo.GetUser(userId);
            user.Items.Add(item);
            _userRepo.UpdateUser(user);
        }

        public Item GenerateItem()
        {
            // TODO: logic to generate item
            Item item = new Item(null, null, null);
            return item;
        }

        public Item[] GetItems(string userId)
        {
            User user = _userRepo.GetUser(userId);
            return user.Items.ToArray();
        }
    }
}