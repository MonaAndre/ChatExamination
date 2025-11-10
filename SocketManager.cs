using System.Text.Json;

namespace ChatExamination;

using SocketIOClient;

public class SocketManager
{
    private static SocketIO _client;
    private static readonly string Path = "/sys25d";
    public static List<Message> messages;
    private static string _currentUsername;

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
            var messageJson = response.GetValue<JsonElement>();
            var message = JsonSerializer.Deserialize<Message>(messageJson.GetRawText());

            if (message != null)
            {
                messages.Add(message);
                Console.WriteLine(message.FormatMessage());
            }
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
    public static void SetCurrentUser(string username)
    {
        _currentUsername = username;
    }

    // Skicka meddelanden.
    public static async Task SendMessage(string messageText)
    {
        Message message = new Message
        {
            Sender = _currentUsername,
            Time = DateTime.Now,
            MessageText = messageText
        };
        
        var json = JsonSerializer.Serialize(message);
        await _client.EmitAsync(EventName, json);
        
        // Add to local message list and display
        messages.Add(message);
        Console.WriteLine(message.FormatMessage());
    }
}