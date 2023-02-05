using CalendarEvents.Models;

namespace CalendarEvents.Business
{
    public interface ICalendarEventsBL
    {   
        Task<bool> checkUserEventsExist(Guid userId);
        Task<List<CalendarEvent>> GetCalendarEvents(Guid userId);

        // Task<CalendarEvent>GetCalendarEventById(int id);


        Task<bool> CheckCalendarEventFormat(CalendarEvent addEvent);
        
        Task<bool> AddCalendarEvent(Guid userId, CalendarEvent addEvent);


        Task<bool>CheckCalendarEventExist(Guid userId, CalendarEvent calendarEvent);
        
        Task<bool> UpdateCalendarEvent(Guid userId, CalendarEvent calendarEvent);

        Task<bool> CheckEventIdExist(Guid eventId);
        Task<bool> DeleteCalendarEvent(Guid eventId, Guid userId);

    }
}