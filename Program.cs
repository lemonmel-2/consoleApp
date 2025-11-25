// See https://aka.ms/new-console-template for more information
using consoleApp.controller;

GameController gameController = new GameController();

bool loggedIn = false;
while (!loggedIn)
{
    Console.WriteLine("Please login/register by enter [yourName][space][yourPassword]");
    string authInfo = Console.ReadLine();
    loggedIn = gameController.Auth(authInfo);
    if (!loggedIn)
    {
        Console.WriteLine("Invalid credential :( Try again!");
    }
}

bool program = true;
while (program)
{
    Console.WriteLine("=====GAME MENU=====");
    Console.WriteLine("1. Record score");
    Console.WriteLine("2. Show user item");
    Console.WriteLine("3. Add new item");
    Console.WriteLine("4. Show leaderboard");
    Console.WriteLine("5. Exit");
    string choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            Console.WriteLine("What's the new score?");
            string score = Console.ReadLine();
            try
            {
                int scoreNumber = int.Parse(score);
                gameController.RecordScore(scoreNumber);
            }
            catch(System.FormatException)
            {
                Console.WriteLine("Invalid number!");
            }
            break;
        case "2":
            gameController.ShowItem();
            break;
        case "3":
            gameController.AddItem();
            break;
        case "4":
            gameController.ShowLeaderboard();
            break;
        case "5":
            program = false;
            break;
        default:
            Console.WriteLine("Invalid Choice");
            break;
    }
}