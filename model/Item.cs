public class Item
{
    public string Name {get; set;}

    public string Category {get; set;}

    public string Src {get; set;}

    public Item(string name, string category, string src)
    {
        this.Name = name;
        this.Category = category;
        this.Src = src;
    }

    public override string ToString()
    {
        return $"{Name} - {Category}";
    }
}