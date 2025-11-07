using System.Security.Cryptography.X509Certificates;

namespace ChatExample;

// ws är protokollet som står för websocket
// wss är samma sak som https, alltså TLS/SSL aktiverad.
/*
 *
 * Händelser/Events skickas mellan klienten och servern.
 * Varje event har ett eventName och en data-innehåll.
 *
 * Vi väljer själva vilka event namn som vi vill lyssna på samt skicka.
 * Vi väljer själva vilken datastruktur samt vilka events som vi ska ha.
 *
 *
 */

class Program
{
    static async Task Main(string[] args)
    {
        // Vi ansluter till Socket servern.
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

        while (true)
        {

            await SocketManager.SendMessage(ReadInput());
        }

    }
}