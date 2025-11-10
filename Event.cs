namespace ChatExamination;

public class Event:ChatItem
{
   public string EventText {get; set;}
   public string FormatEvent()
   {
      return $"[{DateTime.Now}] {Sender}: {EventText}";
   }
}