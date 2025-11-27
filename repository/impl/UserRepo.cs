using consoleApp.model;

public class UserRepo : IUserRepo
{
    readonly List<User> userList = new List<User>
            {
                new User("user1", "000000", 10000),
                new User("user2", "000000", 20000),
                new User("user3", "000000", 30000),
                new User("user4", "000000", 40000),
            };
    public void AddUser(User user)
    {
        userList.Add(user);
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
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("[UserRepo] User ID does not exist");
        }
    }
}