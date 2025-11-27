using System.Text.Json;
using consoleApp.@enum;
using consoleApp.exception;
using consoleApp.model;

public class UserRepo : IUserRepo
{
    private readonly List<User> userList;

    private readonly string filePath = "../consoleApp/repository/tempStorage/userDb.json";

    public UserRepo()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            userList = JsonSerializer.Deserialize<List<User>>(json)?? new List<User>();
        }
        else
        {
            SaveChanges();
        }
    }

    public void AddUser(User user)
    {
        userList.Add(user);
        SaveChanges();
    }

    public User[] GetTopUsers()
    {
        User[] users = userList.OrderByDescending(user => user.HighestScore).ToArray();
        return users;
    }

    public User GetUser(string userId)
    {
        User user = userList.FirstOrDefault(user => user.UserId == userId);
        return user;
    }

    public void UpdateUser(User user)
    {
        try
        {
            User selectUser = userList.FirstOrDefault(u => u.UserId == user.UserId);
            selectUser.HighestScore = user.HighestScore;
            selectUser.Items = user.Items;
            SaveChanges();
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("[UserRepo] User ID does not exist");
        }
    }

    private void SaveChanges()
    {
        try
        {
            string json = JsonSerializer.Serialize(userList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
        catch (IOException)
        {
            throw new GameException(ErrorCode.DATABASE_ERROR);
        }
    }
}