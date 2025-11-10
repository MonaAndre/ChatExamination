namespace ChatExamination;

using SocketIOClient;

public class SocketManager
{
    private static SocketIO _client;
    private static readonly string Path = "/sys25d";
    public static List<string> messages;

    // Här kan vi välja ett unikt event namn för meddelanden.
    private static readonly string EventName = "monas_chat";

    static SocketManager()
    {
        messages = [];
    }

    // Här ska vi ansluta till socketio servern.
    public static async Task Connect()
    {
        // Vi skapar en instans av SocketIO och konfigurerar den med
        // våran server url och path.
        _client = new SocketIO("wss://api.leetcode.se", new SocketIOOptions
        {
            Path = Path
        });

        // Här nedan anger vi de events vi vill lyssna på
        // samt en handler för varje event som ska köras.
        _client.On(EventName, response =>
        {
            string receivedMessage = response.GetValue<string>();

            Console.WriteLine($"Received message: {receivedMessage}");
        });

        // Kod vi kan köra när vi etablerar en anslutning
        _client.OnConnected += (sender, args) => { Console.WriteLine("Connected!"); };

        // Kod vi kan köra när vi tappar anslutningen
        _client.OnDisconnected += (sender, args) => { Console.WriteLine("Disconnected!"); };


        await _client.ConnectAsync();

        // Vi lägger en fördröjning på 2000ms (2s) för att se till att klienten har anslutit och satt upp allt.
        await Task.Delay(2000);

        Console.WriteLine($"Connected: {_client.Connected}");
    }

    // Här kopplar vi ifrån socketio servern
    public static async Task DisconnectAsync(string reason = null)
    {
        if (_client == null) return;

        try
        {
            await _client.DisconnectAsync();
            _client.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during disconnect: {ex.Message}");
        }
        finally
        {
            _client = null;
            if (!string.IsNullOrWhiteSpace(reason))
                Console.WriteLine($"Disconnected: {reason}");
        }
    }

    // Skicka meddelanden.
    public static async Task SendMessage(string message)
    {
        await _client.EmitAsync(EventName, message);
        Console.WriteLine($"You said: {message}");
    }
}