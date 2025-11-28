public class Item
{
    public string ItemID {get; set;}
    public string Name {get; set;}

    public int Quantity {get; set;}

    public Item(string itemId, string name, int quantity)
    {
        this.ItemID = itemId;
        this.Name = name;
        this.Quantity = quantity;
    }

    public override string ToString()
    {
        return $"{ItemID} : {Name}";
    }
}