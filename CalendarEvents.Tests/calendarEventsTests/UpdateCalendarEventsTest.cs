using CalendarEvents.Business;
using CalendarEvents.Controllers;
using CalendarEvents.DataAccess;
using Microsoft.AspNetCore.Mvc;
using CalendarEvents.Models;
using FluentAssertions;

namespace CalendarEvents.Tests.calendarEventsTest
{
    public class UpdateCalendarEventsTest
    {
        private readonly CalendarEventsController _controller;
        private readonly ICalendarEventsBL _calendarEventsBL;
        private readonly ICalendarEventsDAL _calednarEventsDAL;
        public UpdateCalendarEventsTest()
        {
            _calednarEventsDAL = new CalendarEventsDAL();
            _calendarEventsBL = new CalendarEventsBL(_calednarEventsDAL);
            _controller = new CalendarEventsController(_calendarEventsBL);
        }
        // Update Existing Calendar Event

// update the event return ok result
        [Fact]
        public async void Task_UpdateCalendarEvent_Return_OkResult()
        {
            //Arrange
            var calendarEvent = new CalendarEvent()
            
            {
                eventId = new Guid("9ac8b274-88b7-4232-af82-161c22d83c54"),
                title = "Decision-making meeting",
                addDescription =  "Decision-making meeting include making a hiring decision and approving a design.", 
                startTime = new DateTime(2023, 1, 27, 13, 45, 00),
                endTime = new DateTime(2023, 1, 27, 14, 30, 00),
                label = "gray",
                status = "Scheduled"
            };
            var userId = new Guid("7b613837-cdb1-42f6-80c8-382b0844bf59");
            //Act
            var updatedCalendarEvent = await _controller.UpdateCalendarEvent(calendarEvent, userId);

            //Assert
            Assert.IsType<OkObjectResult>(updatedCalendarEvent);
        }
// Cancelled status return bad request result
        [Fact]
        public async void Task_Update_InValidStatus_Return_BadRequestResult()
        {
            //Arrange
            var calendarEvent = new CalendarEvent()
            {
                eventId = new Guid("0cc49aab-96b0-4186-b508-09e016006d10"),
                title = "Check-in meeting",
                addDescription =  "The meeting is used to monitor task progress against an expected outcome.", 
                startTime = new DateTime(2023, 1, 25, 12, 30, 00),
                endTime = new DateTime(2023, 1, 25, 13, 30, 00),
                label = "gray",
                status = "Cancelled"
            };
            var userId = new Guid("7b613837-cdb1-42f6-80c8-382b0844bf59");
            //Act
            var updatedCalendarEvent = await _controller.UpdateCalendarEvent(calendarEvent, userId);

            //Assert
            Assert.IsType<BadRequestResult>(updatedCalendarEvent);
        }
// Invalid event id return NotFound result
        [Fact]
        public async void Task_Update_InValidEventId_Return_NotFoundResult()
        {
            //Arrange
            var calendarEvent = new CalendarEvent()
            {
                eventId = new Guid("0cc49aab-96b0-4186-b508-09e016005d10"),
                title = "Check-in meeting",
                addDescription =  "The meeting is used to monitor task progress against an expected outcome.", 
                startTime = new DateTime(2023, 1, 25, 12, 30, 00),
                endTime = new DateTime(2023, 1, 25, 13, 30, 00),
                label = "gray",
                status = "Scheduled"
            };
            var userId = new Guid("7b613837-cdb1-42f6-80c8-382b0844bf59");
            //Act
            var updatedCalendarEvent = await _controller.UpdateCalendarEvent(calendarEvent, userId);

            //Assert
            Assert.IsType<NotFoundResult>(updatedCalendarEvent);
        }
// request data empty list gives bad request result
        [Fact]
        public async void Task_Update_NullRequestData_Return_BadRequestResult()
        {
            //Arrange
            var calendarEvent = new CalendarEvent()
            {
                
            };
            var userId = new Guid("7b613837-cdb1-42f6-80c8-382b0844bf59");
            //Act
            var updatedCalendarEvent = await _controller.UpdateCalendarEvent(calendarEvent, userId);

            //Assert
            Assert.IsType<BadRequestResult>(updatedCalendarEvent);
        }

// Invalid date return bad request result
        [Fact]
        public async void Task_Update_InValidDate_Return_BadRequestResult()
        {
            //Arrange
            var calendarEvent = new CalendarEvent()
            {
                eventId = new Guid("9ac8b274-88b7-4232-af82-161c22d83c54"),
                title = "Decision-making meeting",
                addDescription =  "Decision-making meeting include making a hiring decision and approving a design.", 
                startTime = new DateTime(2023, 1, 27, 10, 30, 00),
                endTime = new DateTime(2023, 1, 26, 11, 30, 00),
                label = "gray",
                status = "Scheduled"
            };
            var userId = new Guid("7b613837-cdb1-42f6-80c8-382b0844bf59");
            //Act
            var updatedCalendarEvent = await _controller.UpdateCalendarEvent(calendarEvent, userId);

            //Assert
            Assert.IsType<BadRequestResult>(updatedCalendarEvent);
        }
    
// startTime greater than the end time return the bad request result
        [Fact]
        public async void Task_Update_InValidStartTimeAndEndTime_Return_BadRequestResult()
        {
            //Arrange
            var calendarEvent = new CalendarEvent()
            {
                eventId = new Guid("9ac8b274-88b7-4232-af82-161c22d83c54"),
                title = "Decision-making meeting",
                addDescription =  "Decision-making meeting include making a hiring decision and approving a design.", 
                startTime = new DateTime(2023, 1, 26, 11, 31, 00),
                endTime = new DateTime(2023, 1, 26, 11, 30, 00),
                label = "gray",
                status = "Scheduled"
            };
            var userId = new Guid("7b613837-cdb1-42f6-80c8-382b0844bf59");
            //Act
            var updatedCalendarEvent = await _controller.UpdateCalendarEvent(calendarEvent, userId);

            //Assert
            Assert.IsType<BadRequestResult>(updatedCalendarEvent);
        }
// start time and end time update at the same existing time
        [Fact]
        public async void Task_Update_StartTimeAndEndTimeConflictAtSameTime_Return_Conflict()
        {
            //Arrange
            var calendarEvent = new CalendarEvent()
            
            {
                eventId = new Guid("9ac8b274-88b7-4232-af82-161c22d83c54"),
                title = "Decision-making meeting",
                addDescription =  "Decision-making meeting include making a hiring decision and approving a design.", 
                startTime = new DateTime(2023, 1, 27, 12, 30, 00),
                endTime = new DateTime(2023, 1, 27, 13, 30, 00),
                label = "gray",
                status = "Scheduled"
            };
            var userId = new Guid("7b613837-cdb1-42f6-80c8-382b0844bf59");
            //Act
            var updatedCalendarEvent = await _controller.UpdateCalendarEvent(calendarEvent, userId);

            //Assert
            Assert.IsType<ConflictResult>(updatedCalendarEvent);
        }

// start time exists between
        [Fact]
        public async void Task_Update_StartTimeExistsBetweenConflict_Return_Conflict()
        {
            //Arrange
            var calendarEvent = new CalendarEvent()
            
            {
                eventId = new Guid("9ac8b274-88b7-4232-af82-161c22d83c54"),
                title = "Decision-making meeting",
                addDescription =  "Decision-making meeting include making a hiring decision and approving a design.", 
                startTime = new DateTime(2023, 1, 27, 12,45 , 00),
                endTime = new DateTime(2023, 1, 27, 13, 45, 00),
                label = "gray",
                status = "Scheduled"
            };
            var userId = new Guid("7b613837-cdb1-42f6-80c8-382b0844bf59");
            //Act
            var updatedCalendarEvent = await _controller.UpdateCalendarEvent(calendarEvent, userId);

            //Assert
            Assert.IsType<ConflictResult>(updatedCalendarEvent);
        }
// end time exist between 
        [Fact]
        public async void Task_Update_EndTimeConflict_Return_Conflict()
        {
            //Arrange
            var calendarEvent = new CalendarEvent()
            
            {
                eventId = new Guid("9ac8b274-88b7-4232-af82-161c22d83c54"),
                title = "Decision-making meeting",
                addDescription =  "Decision-making meeting include making a hiring decision and approving a design.", 
                startTime = new DateTime(2023, 1, 27, 11, 30, 00),
                endTime = new DateTime(2023, 1, 27, 12, 30, 00),
                label = "gray",
                status = "Scheduled"
            };
            var userId = new Guid("7b613837-cdb1-42f6-80c8-382b0844bf59");
            //Act
            var updatedCalendarEvent = await _controller.UpdateCalendarEvent(calendarEvent, userId);

            //Assert
            Assert.IsType<ConflictResult>(updatedCalendarEvent);
        }
//  time exist out of range 
        [Fact]
        public async void Task_Update_OutOfRangeConflict_Return_Conflict()
        {
            //Arrange
            var calendarEvent = new CalendarEvent()
            
            {
                eventId = new Guid("9ac8b274-88b7-4232-af82-161c22d83c54"),
                title = "Decision-making meeting",
                addDescription =  "Decision-making meeting include making a hiring decision and approving a design.", 
                startTime = new DateTime(2023, 1, 27, 12, 25, 00),
                endTime = new DateTime(2023, 1, 27, 13, 35, 00),
                label = "gray",
                status = "Scheduled"
            };
            var userId = new Guid("7b613837-cdb1-42f6-80c8-382b0844bf59");
            //Act
            var updatedCalendarEvent = await _controller.UpdateCalendarEvent(calendarEvent, userId);

            //Assert
            Assert.IsType<ConflictResult>(updatedCalendarEvent);
        }
// start Time equal to the existing start Time
        [Fact]
        public async void Task_Update_StartTimeEqualToExistingStartTimeConflict_Return_Conflict()
        {
            //Arrange
            var calendarEvent = new CalendarEvent()
            
            {
                eventId = new Guid("9ac8b274-88b7-4232-af82-161c22d83c54"),
                title = "Decision-making meeting",
                addDescription =  "Decision-making meeting include making a hiring decision and approving a design.", 
                startTime = new DateTime(2023, 1, 27, 12, 30, 00),
                endTime = new DateTime(2023, 1, 27, 13, 35, 00),
                label = "gray",
                status = "Scheduled"
            };
            var userId = new Guid("7b613837-cdb1-42f6-80c8-382b0844bf59");
            //Act
            var updatedCalendarEvent = await _controller.UpdateCalendarEvent(calendarEvent, userId);

            //Assert
            Assert.IsType<ConflictResult>(updatedCalendarEvent);
        }
// end Time equal to the existing end Time
        [Fact]
        public async void Task_Update_endTimeEqualToExistingEndTimeConflict_Return_Conflict()
        {
            //Arrange
            var calendarEvent = new CalendarEvent()
            
            {
                eventId = new Guid("9ac8b274-88b7-4232-af82-161c22d83c54"),
                title = "Decision-making meeting",
                addDescription =  "Decision-making meeting include making a hiring decision and approving a design.", 
                startTime = new DateTime(2023, 1, 27, 12, 29, 00),
                endTime = new DateTime(2023, 1, 27, 13, 30, 00),
                label = "gray",
                status = "Scheduled"
            };
            var userId = new Guid("7b613837-cdb1-42f6-80c8-382b0844bf59");
            //Act
            var updatedCalendarEvent = await _controller.UpdateCalendarEvent(calendarEvent, userId);

            //Assert
            Assert.IsType<ConflictResult>(updatedCalendarEvent);
        }
    }
}