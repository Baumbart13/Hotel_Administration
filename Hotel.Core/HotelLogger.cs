using NLog;
using NLog.Targets;

namespace Hotel.Core;

public class HotelLogger : TargetWithLayout
{
    public struct Message
    {
        public string Content { get; set; }
        public LogLevel Level { get; set; }
    }
        
    public List<Message> Messages { get; set; }

    public HotelLogger()
    {
        Messages = new List<Message>();
    }

    protected override void Write(LogEventInfo logEvent)
    {
        var logMessage = Layout.Render(logEvent);
            
        Messages.Add(new Message
        {
            Content = logMessage,
            Level = logEvent.Level,
        });
    }
}