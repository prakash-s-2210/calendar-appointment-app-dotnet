using CalendarEvents.DataAccess;
using CalendarEvents.Models;

namespace CalendarEvents.Business
{
    public class CalendarEventsBL : ICalendarEventsBL
    {
        private readonly ICalendarEventsDAL _calendarEventsDAL;
        public CalendarEventsBL(ICalendarEventsDAL calendarEventsDAL)
        {
            _calendarEventsDAL = calendarEventsDAL;
        }
        public async Task<bool> checkUserEventsExist(Guid userId)
        {
            return await _calendarEventsDAL.CheckUserEventsExist(userId);
        }
        public  async Task<List<CalendarEvent>> GetCalendarEvents(Guid userId)
        {
             return await _calendarEventsDAL.GetCalendarEvents(userId);
        }
        // public async Task<CalendarEvent> GetCalendarEventById(int id)
        // {
        //    return await _calendarEventsDAL.GetCalendarEventById(id);
        // }
        public async Task<bool> CheckCalendarEventFormat(CalendarEvent addEvent)
        {
           if((addEvent.startTime <= addEvent.endTime) && (addEvent.startTime.Date == addEvent.endTime.Date)&&(addEvent.status == "Scheduled" ))
           {
            return await Task.FromResult(true);
           }
           else
           {
            return await Task.FromResult(false);
           }
        }
        
        public async Task<bool> AddCalendarEvent(Guid userId, CalendarEvent addEvent)
        {
           return  await _calendarEventsDAL.AddCalendarEvent(userId, addEvent);
        }

        public async Task<bool> CheckCalendarEventExist(Guid userId, CalendarEvent calendarEvent)
        {
            return await _calendarEventsDAL.CheckCalendarEventExist(userId, calendarEvent);
        }
        public async Task<bool> UpdateCalendarEvent(Guid userId, CalendarEvent calendarEvent)
        {
            return await _calendarEventsDAL.UpdateCalendarEvent(userId, calendarEvent);
        }


        public async Task<bool> CheckEventIdExist(Guid eventID)
        {
            return await _calendarEventsDAL.CheckEventIdExist(eventID);
        }
        public async Task<bool> DeleteCalendarEvent(Guid eventId, Guid userId)
        {
            return await _calendarEventsDAL.DeleteCalendarEvent(eventId, userId);
        }
    }
}