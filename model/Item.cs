public class Item
{
    private string name;

    private string category;

    private string src;

    public Item(string name, string category, string src)
    {
        this.Name = name;
        this.Category = category;
        this.Src = src;
    }

    public string Name { get => name; set => name = value; }
    public string Category { get => category; set => category = value; }
    public string Src { get => src; set => src = value; }
}