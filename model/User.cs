public class User
{
    private string userId;

    private string pwd;

    private int highestScore;

    public User(string userId, string pwd)
    {
        this.userId = userId;
        this.pwd = pwd;
    }
    
    public string UserId { get => userId; set => userId = value; }
    public string Pwd { get => pwd; set => pwd = value; }
    public int HighestScore { get => highestScore; set => highestScore = value; }
}