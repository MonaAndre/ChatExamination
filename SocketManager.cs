using System.Text.Json;

namespace ChatExamination;

using SocketIOClient;

public class SocketManager
{
    private static SocketIO _client;
    private static readonly string Path = "/sys25d";
    private static List<Message> messages;
    private static List<Event> events;
    private static string _currentUsername;
    private static bool _isCurrentlyTyping = false;

    // Här kan vi välja ett unikt event namn för meddelanden.
    private static readonly string MessagesEventName = "monas_chat";
    private static readonly string EventsEventName = "monas_events";
    private static readonly string TypingEventName = "monas_typing";

    static SocketManager()
    {
        messages = [];
        events = [];
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
        // event för meddelande
        _client.On(MessagesEventName, response =>
        {
            try
            {
                var message = ParseSocketData<Message>(response);
                if (message != null && message.Sender != _currentUsername)
                {
                    messages.Add(message);
                    Console.WriteLine(message.FormatMessage());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing message: {ex.Message}");
            }
        });
        // event för events (joinat chat och lämnat chat)
        _client.On(EventsEventName, response =>
        {
            try
            {
                var eventItem = ParseSocketData<Event>(response);
                if (eventItem != null)
                {
                    events.Add(eventItem);
                    Console.WriteLine(eventItem.FormatEvent());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing event: {ex.Message}");
            }
        });

        // event för att kolla om någon skriver meddelange
        _client.On(TypingEventName, response =>
        {
            try
            {
                var typing = ParseSocketData<TypingIndicator>(response);
                if (typing != null && typing.Sender != _currentUsername)
                {
                    if (typing.IsTyping)
                    {
                        Console.WriteLine(typing.FormatTyping());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing typing indicator: {ex.Message}");
            }
        });

        // Kod vi kan köra när vi etablerar en anslutning
        _client.OnConnected += async (sender, args) =>
        {
            Console.WriteLine("Connected!");
            await SendEvent(" joined the chat");
        };

        // Kod vi kan köra när vi tappar anslutningen
        _client.OnDisconnected += (sender, args) => { Console.WriteLine("Disconnected!"); };

        await _client.ConnectAsync();

        // Vi lägger en fördröjning på 2000ms (2s) för att se till att klienten har anslutit och satt upp allt.
        await Task.Delay(2000);
        Console.WriteLine($"Connected: {_client.Connected}");
    }

    // lägger in parsing av resposns data i en separat method för att inte upprepa samma parsing i varje event
    static T ParseSocketData<T>(SocketIOResponse response) where T : class
    {
        var rawData = response.GetValue<JsonElement>();
        T result = null;
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        if (rawData.ValueKind == JsonValueKind.Array && rawData.GetArrayLength() > 0)
        {
            var firstElement = rawData[0];

            if (firstElement.ValueKind == JsonValueKind.String)
            {
                var jsonString = firstElement.GetString()?.Trim();
                if (!string.IsNullOrEmpty(jsonString))
                {
                    result = JsonSerializer.Deserialize<T>(jsonString, options);
                }
            }
            else
            {
                result = JsonSerializer.Deserialize<T>(firstElement.GetRawText(), options);
            }
        }
        else if (rawData.ValueKind == JsonValueKind.Object)
        {
            result = JsonSerializer.Deserialize<T>(rawData.GetRawText(), options);
        }
        else if (rawData.ValueKind == JsonValueKind.String)
        {
            var jsonString = rawData.GetString()?.Trim();
            if (!string.IsNullOrEmpty(jsonString))
            {
                result = JsonSerializer.Deserialize<T>(jsonString, options);
            }
        }

        return result;
    }

    // Här kopplar vi ifrån socketio servern
    public static async Task DisconnectAsync(string reason = null)
    {
        if (_client == null) return;

        try
        {
            await SendEvent(" left the chat");
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

    // Sätter nuvarande användaren
    public static void SetCurrentUser(string username)
    {
        _currentUsername = username;
    }

    // Skicka meddelanden.
    public static async Task SendMessage(string messageText)
    {
        var message = new Message
        {
            Sender = _currentUsername,
            Time = DateTime.Now,
            MessageText = messageText
        };
        await _client.EmitAsync(MessagesEventName, message);
        messages.Add(message);
        Console.WriteLine(message.FormatMessage());
    }

    // Skicka event.
    private static async Task SendEvent(string eventText)
    {
        var eventItem = new Event
        {
            Sender = _currentUsername,
            Time = DateTime.Now,
            EventText = eventText
        };

        await _client.EmitAsync(EventsEventName, eventItem);
        Console.WriteLine(eventItem.FormatEvent());
    }

    //skicka event när jag skriver ett meddelande
    private static async Task SendTypingIndicator(bool isTyping)
    {
        var typing = new TypingIndicator
        {
            Sender = _currentUsername,
            IsTyping = isTyping,
            Time = DateTime.Now
        };

        await _client.EmitAsync(TypingEventName, typing);
        _isCurrentlyTyping = isTyping;
    }

    //ändra värde på indikator till true när man skriver
    public static void NotifyTyping()
    {
        if (!_isCurrentlyTyping)
        {
            _ = SendTypingIndicator(true);
        }
    }

    //ändra värde på indikator till false när man har skickat meddelande 
    public static void NotifyStopTyping()
    {
        if (_isCurrentlyTyping)
        {
            _ = SendTypingIndicator(false);
        }
    }
}