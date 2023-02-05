using CalendarEvents.Models;

namespace CalendarEvents.DataAccess
{
    public interface ICalendarEventsDAL
    {
        Task<bool> CheckUserEventsExist(Guid userId);
        Task<List<CalendarEvent>> GetCalendarEvents(Guid userId);

        // Task<List<CalendarEvent>?> GetCalendarEventById(int? id);
        // Task<CalendarEvent> GetCalendarEventById(int id);

        Task<bool> AddCalendarEvent(Guid userId, CalendarEvent calendarEvent);
        Task<bool> CheckCalendarEventExist(Guid userId, CalendarEvent calendarEvent);

        Task<bool> UpdateCalendarEvent(Guid userId, CalendarEvent calendarEvent);
        
        Task<bool> CheckEventIdExist(Guid eventId);
        Task<bool> DeleteCalendarEvent(Guid eventId, Guid userId);

    }
}