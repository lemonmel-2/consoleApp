namespace consoleApp.service
{
    public interface IItemService
    {
        public Item[] GetItems(String userId);

        public Item GenerateItem();

        public void AddItem(String userId, Item item);

    }
}