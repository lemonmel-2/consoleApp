// See https://aka.ms/new-console-template for more information
using consoleApp.controller;
using consoleApp.exception;

GameController gameController = new GameController();

bool loggedIn = false;
while (!loggedIn)
{
    Console.WriteLine("Please login/register by enter [Number][space][yourName][space][yourPassword]");
    Console.WriteLine("Example for login: 1 user1 000000");
    Console.WriteLine("Example for register: 2 user1 000000");
    try
    {
        string authInfo = Console.ReadLine();
        loggedIn = gameController.Auth(authInfo);
        Console.WriteLine("==Hello! Welcome to the game==");
    }
    catch(Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

bool program = true;
while (program)
{
    Console.WriteLine("==========GAME MENU===========");
    Console.WriteLine("1. Record score");
    Console.WriteLine("2. Show user item");
    Console.WriteLine("3. Generate random item");
    Console.WriteLine("4. Add new item");
    Console.WriteLine("5. Show leaderboard");
    Console.WriteLine("6. Exit");
    string choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            try
            {
                Console.WriteLine("What's the new score?");
                string score = Console.ReadLine();
                gameController.RecordScore(score);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case "2":
            gameController.ShowItem();
            break;
        case "3":
            string itemId = gameController.GenerateItem();
            Console.WriteLine(itemId + " is generated");
            break;
        case "4":
            try
            {
                Console.WriteLine("What's the new item?");
                string item = Console.ReadLine();
                gameController.AddItem(item);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case "5":
            gameController.ShowLeaderboard();
            break;
        case "6":
            program = false;
            break;
        default:
            Console.WriteLine("Invalid Choice");
            break;
    }
}