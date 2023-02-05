using CalendarEvents.Business;
using CalendarEvents.Controllers;
using CalendarEvents.DataAccess;
using Microsoft.AspNetCore.Mvc;
using CalendarEvents.Models;
using FluentAssertions;

namespace CalendarAppointmentApp.Tests.calendarEventsTest
{
    public class AddCalendarEventsTest
    {
        private readonly CalendarEventsController _controller;
        private readonly ICalendarEventsBL _calendarEventsBL;
        private readonly ICalendarEventsDAL _calednarEventsDAL;
        public AddCalendarEventsTest()
        {
            _calednarEventsDAL = new CalendarEventsDAL();
            _calendarEventsBL = new CalendarEventsBL(_calednarEventsDAL);
            _controller = new CalendarEventsController(_calendarEventsBL);
        }
        // Add New Calendar Event return 201 status code
// checks start time and end time  .
// check start date equals to current date
// leaves conflict checking for cancelled event for conflict checking
// leaves conflict checking for other date for conflict
// check only for login user and add the event 
// it add event id and event object in the event list
// it add event id to the user id who is logged in

        [Fact]
        public async void Task_Add_ValidData_Return_CreatedAtActionResult()
        {
            //Arrange
           
            var CalendarEvent = new CalendarEvent() { 
                eventId = new Guid("00000000-0000-0000-0000-000000000000"),
                title =  "Daily stand up", 
                addDescription = "A meeting regarding a project progress.",
                startTime = new DateTime(2023, 1, 15, 16, 30, 00),
                endTime = new DateTime(2023, 1, 15, 17, 30, 00),
                label = "blue",
                status = "Scheduled"
                };
            var userId = new Guid("e0f38a81-a922-4996-ae40-e894762fd838");
            //Act
            var result = await _controller.AddCalendarEvent(CalendarEvent, userId);

            //Assert
            Assert.IsType<CreatedAtActionResult>(result);

            var okResult = result.Should().BeOfType<CreatedAtActionResult>().Subject;
            Assert.Equal(CalendarEvent, okResult.Value);
        }
// check response has a created event title
        [Fact]
        public async void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            //Arrange
           
            var CalendarEvent = new CalendarEvent() { 
                eventId = new Guid("00000000-0000-0000-0000-000000000000"),
                title =  "Daily stand up", 
                addDescription = "A meeting regarding a project progress.",
                startTime = new DateTime(2023, 1, 31, 11, 45, 00),
                endTime = new DateTime(2023, 1, 31, 11, 45, 00),
                label = "blue",
                status = "Scheduled"
                };
            var userId = new Guid("e0f38a81-a922-4996-ae40-e894762fd838");
            //Act
            var createdResponse = await _controller.AddCalendarEvent(CalendarEvent, userId) ;
            //Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
            var okResult = createdResponse.Should().BeOfType<CreatedAtActionResult>().Subject;
            var Events = okResult.Value.Should().BeAssignableTo<CalendarEvent>().Subject;
            Assert.Equal("Daily stand up", Events.title);
        }
// created a event for a user but user has existing event startTime conflict
        [Fact]
        public async void Task_Add_startTimeExistBetweenTimeSlots_Return_ConflictResult()
        {
            //Arrange
           
            var CalendarEvent = new CalendarEvent() { 
                eventId = new Guid("00000000-0000-0000-0000-000000000000"),
                title =  "Daily stand up", 
                addDescription = "A meeting regarding a project progress.",
                startTime = new DateTime(2023, 1, 26, 10, 45, 00),
                endTime = new DateTime(2023, 1, 26, 11, 45, 00),
                label = "blue",
                status = "Scheduled"
                };
            var userId = new Guid("e0f38a81-a922-4996-ae40-e894762fd838");
            //Act
            var result = await _controller.AddCalendarEvent(CalendarEvent, userId);

            //Assert
            Assert.IsType<ConflictResult>(result);
        }
// created a event for a user but user has existing event equal to startTime conflict     
        [Fact]
        public async void Task_Add_EqualToStartTimeExistBetweenTimeSlots_Return_ConflictResult()
        {
            //Arrange
           
            var CalendarEvent = new CalendarEvent() { 
                eventId = new Guid("00000000-0000-0000-0000-000000000000"),
                title =  "Daily stand up", 
                addDescription = "A meeting regarding a project progress.",
                startTime = new DateTime(2023, 1, 27, 12, 30, 00),
                endTime = new DateTime(2023, 1, 27, 13, 45, 00),
                label = "blue",
                status = "Scheduled"
                };
            var userId = new Guid("e0f38a81-a922-4996-ae40-e894762fd838");
            //Act
            var result = await _controller.AddCalendarEvent(CalendarEvent, userId);

            //Assert
            Assert.IsType<ConflictResult>(result);
        }
// created a event for a user but user has existing event endTime conflict
        [Fact]
        public async void Task_Add_EndTimeExistBetweenTimeSlots_Return_ConflictResult()
        {
            //Arrange
           
            var CalendarEvent = new CalendarEvent() { 
                eventId = new Guid("00000000-0000-0000-0000-000000000000"),
                title =  "Daily stand up", 
                addDescription = "A meeting regarding a project progress.",
                startTime = new DateTime(2023, 1, 28, 13, 45, 00),
                endTime = new DateTime(2023, 1, 28, 14, 45, 00),
                label = "blue",
                status = "Scheduled"
                };
            var userId = new Guid("e0f38a81-a922-4996-ae40-e894762fd838");
            //Act
            var result = await _controller.AddCalendarEvent(CalendarEvent, userId);

            //Assert
            Assert.IsType<ConflictResult>(result);
        }
// created a event for a user but user has existing event equal to end time conflict     
        [Fact]
        public async void Task_Add_EqualToEndTimeExistBetweenTimeSlots_Return_ConflictResult()
        {
            //Arrange
           
            var CalendarEvent = new CalendarEvent() { 
                eventId = new Guid("00000000-0000-0000-0000-000000000000"),
                title =  "Daily stand up", 
                addDescription = "A meeting regarding a project progress.",
                startTime = new DateTime(2023, 1, 25, 10, 15, 00),
                endTime = new DateTime(2023, 1, 25, 11, 30, 00),
                label = "blue",
                status = "Scheduled"
                };
            var userId = new Guid("e0f38a81-a922-4996-ae40-e894762fd838");
            //Act
            var result = await _controller.AddCalendarEvent(CalendarEvent, userId);

            //Assert
            Assert.IsType<ConflictResult>(result);
        }       
// created a event for a user but user has existing event out of range conflict
        [Fact]
        public async void Task_Add_ExistingStartTimeAndEndTimeExistsBetweenAddingTimeSlots_Return_ConflictResult()
        {
            //Arrange
           
            var CalendarEvent = new CalendarEvent() { 
                eventId = new Guid("00000000-0000-0000-0000-000000000000"),
                title =  "Daily stand up", 
                addDescription = "A meeting regarding a project progress.",
                startTime = new DateTime(2023, 1, 30, 14, 15, 00),
                endTime = new DateTime(2023, 1, 30, 15, 45, 00),
                label = "blue",
                status = "Scheduled"
                };
            var userId = new Guid("e0f38a81-a922-4996-ae40-e894762fd838");
            //Act
            var result = await _controller.AddCalendarEvent(CalendarEvent, userId);

            //Assert
            Assert.IsType<ConflictResult>(result);
        }
//passing different date to create event 
        [Fact]
        public async void Task_Add_ValidDate_Return_BadRequestResult()
        {
            //Arrange
           
            var CalendarEvent = new CalendarEvent() { 
                eventId = new Guid("00000000-0000-0000-0000-000000000000"),
                title =  "Daily stand up", 
                addDescription = "A meeting regarding a project progress.",
                startTime = new DateTime(2023, 1, 27, 10, 45, 00),
                endTime = new DateTime(2023, 1, 26, 11, 45, 00),
                label = "blue",
                status = "Scheduled"
                };
            var userId = new Guid("e0f38a81-a922-4996-ae40-e894762fd838");
            //Act
            var result = await _controller.AddCalendarEvent(CalendarEvent, userId);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }
// passing startTime greater than end time  
        [Fact]
        public async void Task_Add_ValidTime_Return_BadRequestResult()
        {
            //Arrange
           
            var CalendarEvent = new CalendarEvent() { 
                eventId = new Guid("00000000-0000-0000-0000-000000000000"),
                title =  "Daily stand up", 
                addDescription = "A meeting regarding a project progress.",
                startTime = new DateTime(2023, 1, 26, 11, 46, 00),
                endTime = new DateTime(2023, 1, 26, 11, 45, 00),
                label = "blue",
                status = "Scheduled"
                };
            var userId = new Guid("e0f38a81-a922-4996-ae40-e894762fd838");
            //Act
            var result = await _controller.AddCalendarEvent(CalendarEvent, userId);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }
// Invalid user access the event list
        [Fact]
        public async void InvalidUser_AddCalendarEvent_Return_BadRequestResult()
        {
            //Arrange
           
            var CalendarEvent = new CalendarEvent() { 
                eventId = new Guid("00000000-0000-0000-0000-000000000000"),
                title =  "Daily stand up", 
                addDescription = "A meeting regarding a project progress.",
                startTime = new DateTime(2023, 1, 26, 11, 46, 00),
                endTime = new DateTime(2023, 1, 26, 11, 45, 00),
                label = "blue",
                status = "Scheduled"
                };
            var userId = new Guid("e0f38a81-a922-4996-ae40-e894762fd828");
            //Act
            var result = await _controller.AddCalendarEvent(CalendarEvent, userId);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }

// add invalid status for creating calendar event
        [Fact]
        public async void AddInvalidStatus_Return_BadRequestResult()
        {
            //Arrange
           
            var CalendarEvent = new CalendarEvent() { 
                eventId = new Guid("00000000-0000-0000-0000-000000000000"),
                title =  "Daily stand up", 
                addDescription = "A meeting regarding a project progress.",
                startTime = new DateTime(2023, 1, 26, 11, 46, 00),
                endTime = new DateTime(2023, 1, 26, 11, 45, 00),
                label = "blue",
                status = "Cancelled"
                };
            var userId = new Guid("e0f38a81-a922-4996-ae40-e894762fd828");
            //Act
            var result = await _controller.AddCalendarEvent(CalendarEvent, userId);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }
    }
} 