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
            if (userInputText == "/quit")
            {
                Console.Clear();
                await SocketManager.DisconnectAsync();
                isChatting = false;
            }
            else if (string.IsNullOrWhiteSpace(userInputText))
            {
                Console.Write("You can not send a empty message, to continue chat press enter");
                userInputText = ReadInput();
            }
            else
            {
                await SocketManager.SendMessage(userInputText);
            }
        }
    }
}