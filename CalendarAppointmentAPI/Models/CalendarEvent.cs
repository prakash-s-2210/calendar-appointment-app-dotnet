// using System.ComponentModel.DataAnnotations.Schema;
// using System.ComponentModel.DataAnnotations;
namespace CalendarEvents.Models
{
    public class CalendarEvent
    {
        public Guid eventId { get; set; }
        public string title { get; set; } = string.Empty;
        public string addDescription { get; set; } = string.Empty;
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string label { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
    }
}