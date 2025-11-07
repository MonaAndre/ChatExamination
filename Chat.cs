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
            string userMessage = Console.ReadLine();
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            ClearCurrentConsoleLine();
            return userMessage;
        }

        bool isChatting = true;
        while (isChatting)
        {
            string userInputText = ReadInput();
            if (userInputText == "/quit")
            {
                Console.Clear();
                Console.WriteLine("Disconnected!");
                isChatting = false;
            }
            else
            {
                await SocketManager.SendMessage(userInputText);
            }
        }
    }
}