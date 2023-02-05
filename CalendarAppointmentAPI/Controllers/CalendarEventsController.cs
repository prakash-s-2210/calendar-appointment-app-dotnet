using System.Text;
using CalendarEvents.Business;
using CalendarEvents.Models;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using CalendarEvents.Attributes;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CalendarEvents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarEventsController : ControllerBase
    {
        private readonly ICalendarEventsBL _calendarEventsBL;

        public  CalendarEventsController(ICalendarEventsBL calendarEventsBL)
        {
            _calendarEventsBL= calendarEventsBL;
        }

        

        [HttpGet]
        [Route("GetCalendarEvents")]
        [ServiceFilter(typeof(CustomAuth))]
        [ProducesResponseType(typeof(CalendarEvent), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCalendarEvents(Guid userId)
        {
            try
            {
                var checkUserEventsExist = await _calendarEventsBL.checkUserEventsExist(userId);
                if(checkUserEventsExist == true)
                {
                    var calendarEvents = await _calendarEventsBL.GetCalendarEvents(userId);
                    if(calendarEvents.Count != 0) 
                    {
                        return Ok(calendarEvents);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                 
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }   
        }
        
        [HttpPost]
        [Route("AddCalendarEvent")]
        [ServiceFilter(typeof(CustomAuth))]
        [ProducesResponseType(StatusCodes.Status201Created)]
         public async Task<IActionResult> AddCalendarEvent([FromBody]CalendarEvent addEvent, Guid userId)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var calendarEventTypeResult = await _calendarEventsBL.CheckCalendarEventFormat(addEvent);
                    if(calendarEventTypeResult == true)
                    {
                        var result = await _calendarEventsBL.AddCalendarEvent(userId, addEvent);

                        if(result == true)
                        {
                            return  CreatedAtAction(nameof(GetCalendarEvents), new { id = addEvent }, addEvent);
                        }
                        else if(result == false)
                        {
                            return Conflict("The event already exist in this time slot");
                        }
                        else                   
                        {
                            return NotFound();
                        }
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        
        [HttpPut]
        [Route("UpdateCalendarEvent")]
        [ServiceFilter(typeof(CustomAuth))]
         public async Task<IActionResult> UpdateCalendarEvent([FromBody]CalendarEvent calendarEvent, Guid userId)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var calendarEventTypeResult = await _calendarEventsBL.CheckCalendarEventFormat(calendarEvent);
                    if(calendarEventTypeResult == true)
                    {
                        var checkEventExist = await _calendarEventsBL.CheckCalendarEventExist(userId, calendarEvent);
                        if(checkEventExist == true)
                        {
                            var CalendarEvent = await _calendarEventsBL.UpdateCalendarEvent(userId, calendarEvent);
                            if(CalendarEvent == false)
                            {
                                return Conflict();
                            }
                            else
                            {
                                return Ok(calendarEvent);
                            }
                        }
                        else
                        {
                            return NotFound();
                        }
                    
                    }
                    else {
                        return BadRequest();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();  
                }
            }
            else 
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("DeleteCalendarEvent/{eventId}")]
        [ServiceFilter(typeof(CustomAuth))]
         public async Task<IActionResult> DeleteCalendarEvent(Guid eventId, Guid userId)
        {
            try
            {
                var checkEventIdExist = await _calendarEventsBL.CheckEventIdExist(eventId);
                if(checkEventIdExist == true)
                {
                    var CalendarEvent = await _calendarEventsBL.DeleteCalendarEvent(eventId,userId);
                    if(CalendarEvent == true)
                    {
                        return Ok(eventId);
                    }
                    else 
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}