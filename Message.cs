namespace ChatExamination;

public class Message:ChatItem
{
    public Message()
    {
    }

    public string MessageText { get; set; }

    public string FormatMessage()
    {
        return $"[{DateTime.Now}] {Sender}: {MessageText}";
    }
}