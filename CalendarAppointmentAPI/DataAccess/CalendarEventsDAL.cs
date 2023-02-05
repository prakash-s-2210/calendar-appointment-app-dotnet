using CalendarEvents.Models;
using CalendarEvents.CalendarAppointmentApp;
using  System.Threading.Tasks;
using System.Linq;
using System.Text;

namespace CalendarEvents.DataAccess
{
    public class CalendarEventsDAL : ICalendarEventsDAL
    {  
        public async Task<bool> CheckUserEventsExist(Guid userId)
        {
            var userEventsList = UsersEventsId.usersEventsList.FirstOrDefault(x => x.Key == userId);
            var events = userEventsList.Value;
            if(events.Any())
            {
                return await Task.FromResult(true);
            }
            else{
                return await Task.FromResult(false);
            }
        }
        
        public async Task<List<CalendarEvent>> GetCalendarEvents(Guid userId)
        {
            var calendarEvents = new List<CalendarEvent>();
            var userEventsList = UsersEventsId.usersEventsList.FirstOrDefault(x => x.Key == userId);
            var events = userEventsList.Value;
            {
            for (int i = 0; i < events.Count; i++) 
            {
                var getCalendarEvent = Events.eventDetails.FirstOrDefault(x=>x.eventId == events[i]);
                if(getCalendarEvent != null && getCalendarEvent.status!= "Cancelled"){
                    calendarEvents.Add(getCalendarEvent);
                }
                else{}
            }
            return await Task.FromResult(calendarEvents);
            }
                        
        }
        // public async Task<CalendarEvent> GetCalendarEventById(int id)
        // {
        //     return await Task.FromResult(CalendarEvents.FirstOrDefault(x => x.Id == id)); 
            
            
        // }

        public async Task<bool> AddCalendarEvent(Guid userId, CalendarEvent calendarEvent)
        {
            var userEventsList = UsersEventsId.usersEventsList.FirstOrDefault(x => x.Key == userId);
            var events = userEventsList.Value;
            for (int i = 0; i < events.Count; i++) 
            {
                var checkEventsForConflict = Events.eventDetails.FirstOrDefault(x=>x.eventId == events[i]);
                if((checkEventsForConflict != null) && (checkEventsForConflict.startTime.Date == calendarEvent.startTime.Date) && (checkEventsForConflict.status != "Cancelled")) 
                {
                    if((calendarEvent.startTime >= checkEventsForConflict.startTime && calendarEvent.startTime <= checkEventsForConflict.endTime) ||
                       (calendarEvent.endTime >= checkEventsForConflict.startTime && calendarEvent.endTime<= checkEventsForConflict.endTime) ||
                       (calendarEvent.startTime <= checkEventsForConflict.startTime && calendarEvent.endTime >= checkEventsForConflict.endTime) 
                    )
                    {
                        return await  Task.FromResult(false);
                    } 
                    else{}
                }
                else{}
            }
                var newEventId = Guid.NewGuid();
                calendarEvent.eventId = newEventId ;
                Events.eventDetails.Add(calendarEvent);
                userEventsList.Value.Add(newEventId);
                return await Task.FromResult(true);
        }

            
        public async Task<bool> CheckCalendarEventExist(Guid userId, CalendarEvent calendarEvent)
        {
            var a = Events.eventDetails.FirstOrDefault(x => x.eventId == calendarEvent.eventId);
            var userEventsList = UsersEventsId.usersEventsList.FirstOrDefault(x => x.Key == userId);
            var events = userEventsList.Value;
            if((events.Any()) && (a!=null))
            {
            return await Task.FromResult(true);
            }
            else{
                return await Task.FromResult(false);
            }
        }
        public async Task<bool> UpdateCalendarEvent(Guid userId, CalendarEvent calendarEvent)
        {
            var userEventsList = UsersEventsId.usersEventsList.FirstOrDefault(x => x.Key == userId);
            var events = userEventsList.Value;
            for (int i = 0; i < events.Count; i++) 
            {
                var checkEventsForConflict = Events.eventDetails.FirstOrDefault(x=>x.eventId == events[i]);
                if((checkEventsForConflict != null) && (checkEventsForConflict.startTime.Date == calendarEvent.startTime.Date) && (checkEventsForConflict.status != "Cancelled") && (checkEventsForConflict.eventId != calendarEvent.eventId)) 
                {
                    if((calendarEvent.startTime >= checkEventsForConflict.startTime && calendarEvent.startTime <= checkEventsForConflict.endTime) ||
                       (calendarEvent.endTime >= checkEventsForConflict.startTime && calendarEvent.endTime<= checkEventsForConflict.endTime) ||
                       (calendarEvent.startTime <= checkEventsForConflict.startTime && calendarEvent.endTime >= checkEventsForConflict.endTime))
                    {
                        return await Task.FromResult(false);
                    } 
                    else{}
                }
                else{}
            }
            var getIndex= Events.eventDetails.FindIndex(x => x.eventId == calendarEvent.eventId);
            Events.eventDetails[getIndex] = calendarEvent;
            return await Task.FromResult(true);  
        }
            
        public async Task<bool> CheckEventIdExist(Guid eventId)
        {
            var eventIdExist = Events.eventDetails.FirstOrDefault(x => x.eventId == eventId);
            if(eventIdExist != null)
            {
                return await Task.FromResult(true);
            }
            else
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<bool> DeleteCalendarEvent(Guid eventId, Guid userId)
        {
            var userEventsList = UsersEventsId.usersEventsList.FirstOrDefault(x => x.Key == userId);
            var events = userEventsList.Value;
            for (int i = 0; i < events.Count; i++) 
            {
                Console.WriteLine(events[i]);
                Console.WriteLine(eventId);
                Console.WriteLine(events[i] == eventId);
                if(eventId == events[i] ){
                    var calendarEvent = Events.eventDetails.FirstOrDefault(a => a.eventId == eventId);
                    Console.WriteLine(calendarEvent); 
                    if(calendarEvent != null){
                        calendarEvent.status = "Cancelled";
                        Console.WriteLine("211100");
                        return await Task.FromResult(true);     
                    }
                    else{}
                }
                else{}
            }
            return await Task.FromResult(false);
        }                               
    }
}
