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
            Console.WriteLine();
            string userActionChoise = Console.ReadLine();
            switch (int.Parse(userActionChoise))
            {
                case 1:
                    User CurrentUser = User.LoginUser();
                    if (CurrentUser?.isLoggedIn == true)
                    {
                        SocketManager.SetCurrentUser(CurrentUser.Username);
                        Console.WriteLine("To exit the chat, type \"/quit\"");
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

    public async Task StartApp()
    {
        Chat _chat = new Chat();
        await _chat.StartChat();
    }

    public void CloseApp()
    {
        Console.WriteLine("You closed the application");
        Environment.Exit(0);
    }
}