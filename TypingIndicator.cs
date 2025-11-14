namespace ChatExamination;

public class TypingIndicator : ChatItem
{
    public bool IsTyping { get; set; }

    public string FormatTyping()
    {
        return $"[{DateTime.Now}] {Sender}: is typing...";
    }
}