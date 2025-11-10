namespace ChatExamination;

public class Message:ChatItem
{
    public string MessageText { get; set; }

    public string FormatMessage()
    {
        return $"[{Time:HH:mm:ss}] {Sender}: {MessageText}";
    }
}