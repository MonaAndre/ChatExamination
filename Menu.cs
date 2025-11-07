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
            Console.WriteLine("2. Exit");
            Console.WriteLine();
            string userActionChoise = Console.ReadLine();
            switch (int.Parse(userActionChoise))
            {
                case 1:
                   await StartApp();
                    break;
                case 2:
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
        Environment.Exit(0);
    }
}