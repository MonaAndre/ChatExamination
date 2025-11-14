namespace ChatExamination;

public class Chat
{
    public async Task StartChat()
    {
        await SocketManager.Connect();

        static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        static string ReadInput()
        {
            string userMessage = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Backspace && userMessage.Length > 0)
                {
                    userMessage = userMessage.Substring(0, userMessage.Length - 1);
                    Console.Write("\b \b");
                }
                else if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
                {
                    userMessage += key.KeyChar;
                    Console.Write(key.KeyChar);
                    SocketManager.NotifyTyping();
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            ClearCurrentConsoleLine();
            SocketManager.NotifyStopTyping();
            return userMessage;
        }


        var isChatting = true;
        while (isChatting)
        {
            var userInputText = ReadInput();

            if (string.IsNullOrWhiteSpace(userInputText))
            {
                Console.Write("You can not send a empty message, to continue chat press enter");
                userInputText = ReadInput();
            }
            else
            {
                switch (userInputText)
                {
                    case "/quit":
                        Console.Clear();
                        await SocketManager.DisconnectAsync();
                        isChatting = false;
                        break;

                    case "/history 20":
                        OpenHistory();
                        break;

                    case "/help":
                        OpenChatHelper();
                        break;

                    default:
                        await SocketManager.SendMessage(userInputText);
                        break;
                }
            }
        }
    }

    private static void OpenChatHelper()
    {
        Console.WriteLine();
        Console.WriteLine("-----------------------------");
        Console.WriteLine("How To use this chat");
        Console.WriteLine(
            "1. You can send a new message all people in the chat can see who send it by username, time, and messege text");
        Console.WriteLine("2. You can not send empty message");
        Console.WriteLine("3. You can logout from the chat by typing /quit");
        Console.WriteLine("4. You can see 20 latest messages by typing /history 20");
        Console.WriteLine("4. You can open this halper by typing /help");
        Console.WriteLine("-----------------------------");
        Console.WriteLine("You can continue chatting");
    }

    private static void OpenHistory()
    {
        Console.WriteLine();
        Console.WriteLine("-----------------------------");
        Console.WriteLine("CHAT HISTORY 20 LATEST:");

        List<Message> messages = SocketManager.GetAllMessages();
        int total = messages.Count;
        int start = Math.Max(0, total - 20);

        for (int i = start; i < total; i++)
        {
            Console.WriteLine(messages[i].FormatMessage());
        }

        Console.WriteLine("-----------------------------");
        Console.WriteLine("You can continue chatting");
    }
}