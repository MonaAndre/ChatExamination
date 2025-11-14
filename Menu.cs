using System.Diagnostics;

namespace ChatExamination;

public class Menu
{
    public async Task OpenMenu()
    {
        while (true)
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Log in to the chat");
            Console.WriteLine("2. Register new user");
            Console.WriteLine("3. Exit");

            int userActionChoice;
            while (true)
            {
                Console.Write("Write a number from 1 to 3: ");
                string ? input = Console.ReadLine();

                if (int.TryParse(input, out userActionChoice) && userActionChoice >= 1 && userActionChoice <= 3)
                    break;

                Console.WriteLine("Invalid input. Please enter 1, 2 or 3.\n");
            }

            switch (userActionChoice)
            {
                case 1:
                    var currentUser = User.LoginUser();
                    if (currentUser?.isLoggedIn == true)
                    {
                        SocketManager.SetCurrentUser(currentUser.Username);
                        Console.WriteLine();
                        Console.WriteLine("To exit the chat, type \"/quit\"");
                        Console.WriteLine("To get help with how does chat works, type \"/help\"");
                        Console.WriteLine("To se up to 20 last messages, type \"/history 20\"");
                        await StartApp();
                    }
                    else
                    {
                        Console.WriteLine("Could not login");
                    }

                    break;
                case 2:
                    User.RegisterUser();
                    break;

                case 3:
                    CloseApp();
                    break;
            }
        }
    }

    private static async Task StartApp()
    {
        var chat = new Chat();
        await chat.StartChat();
    }

    private static void CloseApp()
    {
        Console.WriteLine("You closed the application");
        Environment.Exit(0);
    }
}