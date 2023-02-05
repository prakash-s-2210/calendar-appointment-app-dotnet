using CalendarEvents.Business;
using CalendarEvents.Controllers;
using CalendarEvents.DataAccess;
using Microsoft.AspNetCore.Mvc;
using CalendarEvents.Models;
using FluentAssertions;

namespace CalendarEvents.Tests.calendarEventsTest
{
    public class GetCalendarEventsTest
    {
        private readonly CalendarEventsController _controller;
        private readonly ICalendarEventsBL _calendarEventsBL;
        private readonly ICalendarEventsDAL _calednarEventsDAL;
        public GetCalendarEventsTest()
        {
            _calednarEventsDAL = new CalendarEventsDAL();
            _calendarEventsBL = new CalendarEventsBL(_calednarEventsDAL);
            _controller = new CalendarEventsController(_calendarEventsBL);
        }

        //  Get All Calendar Events Unit Tests 

        // check get calendar Events as OkObjectResult
        // check get calendar Events type as required List<CalendarEvent>
        // check get calendar Events  of first items match the list first item
        // check get calendar Events count the number of items in the list
        // check get login user id event information
        [Fact]
        public async Task GetCalendarEvents_Return_OkResult()
        {
            //Arrange
            var userId = new Guid("e0f38a81-a922-4996-ae40-e894762fd838");
            //Act
             var result = await _controller.GetCalendarEvents(userId);

            //Assert
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var Events = okResult.Value.Should().BeAssignableTo<List<CalendarEvent>>().Subject;
            Assert.Equal(new Guid("b8d81b99-9025-4f57-923c-e5dbf269532f"), Events[0].eventId);
            Assert.Equal("Team-building meeting", Events[0].title);
            Assert.Equal("Improving trust among teammates, Helping the group feel valued ", Events[0].addDescription);
            Assert.Equal(new DateTime(2023, 1, 27, 12, 30, 00), Events[0].startTime);
            Assert.Equal(new DateTime(2023, 1, 27, 13, 30, 00), Events[0].endTime);
            Assert.Equal("red", Events[0].label);
            Assert.Equal("Scheduled", Events[0].status);
            Assert.Equal(4, Events.Count);
            }
        [Fact]
        public async Task GetCalendarEvents_Return_NotFound()
        {
            //Arrange
            var userId = new Guid("6d354fb0-d6e4-4f0a-9d62-39ebd7fad1b7");
            //Act
             var result = await _controller.GetCalendarEvents(userId);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }
    
        // check bad request result by sending guid empty
        // non existing user ID
        [Fact]
        public async Task GetCalendarEvents_Return_BadRequestResult()
        {
            //Arrange
            
            var userId = new Guid("00000000-0000-0000-0000-000000000000");
            //Act
            var result = await _controller.GetCalendarEvents(userId);
            
            //Assert
            Assert.IsType<BadRequestResult>(result);
        }
    }
} 












// Get CalendarEvent By Id

// [Fact]
//         public async void Task_GetCalendarEventById_Return_OkResult()
//         {
//             //Arrange
//             ICalendarEventsDAL calendarEventsDAL = new CalendarEventsDAL();
//             ICalendarEventsBL calendarEventsBL = new CalendarEventsBL(calendarEventsDAL);
//             CalendarEventsController calendarEvents = new CalendarEventsController(calendarEventsBL);
//             var id = 2;

//             //Act
//             var result = await calendarEvents.GetCalendarEventById(id);

//             //Assert
//             Assert.IsType<OkObjectResult>(result);
//         }

//         [Fact]
//         public async void Task_GetCalendarEventById_Return_NotFoundResult()
//         {
//             //Arrange
//             ICalendarEventsDAL calendarEventsDAL = new CalendarEventsDAL();
//             ICalendarEventsBL calendarEventsBL = new CalendarEventsBL(calendarEventsDAL);
//             CalendarEventsController calendarEvents = new CalendarEventsController(calendarEventsBL);
//             var id = 4;

//             //Act
//             var result = await calendarEvents.GetCalendarEventById(id);

//             //Assert
//             Assert.IsType<NotFoundResult>(result);
//         }

//         [Fact]
//         public async Task Task_GetCalendarEventById_Return_BadRequestResult()
//         {
//             //Arrange
//             ICalendarEventsDAL calendarEventsDAL = new CalendarEventsDAL();
//             ICalendarEventsBL calendarEventsBL = new CalendarEventsBL(calendarEventsDAL);
//             CalendarEventsController calendarEvents = new CalendarEventsController(calendarEventsBL);
//             int? id = null;

//             //Act
//             var result = await calendarEvents.GetCalendarEventById(id);

//             //Assert
//             Assert.IsType<BadRequestResult>(result);
//         }

//         [Fact]
//         public async void Task_GetCalendarEventById_MatchResult()
//         {
//             //Arrange
//             ICalendarEventsDAL calendarEventsDAL = new CalendarEventsDAL();
//             ICalendarEventsBL calendarEventsBL = new CalendarEventsBL(calendarEventsDAL);
//             CalendarEventsController calendarEvents = new CalendarEventsController(calendarEventsBL);
//             int? id = 1;

//             //Act
//             var result = await calendarEvents.GetCalendarEventById(id);

//             //Assert
//             Assert.IsType<OkObjectResult>(result);

//             var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
//             var CalendarEvent = okResult.Value.Should().BeAssignableTo<List<CalendarEvent>>().Subject;

//             Assert.Equal(1, CalendarEvent[0].Id);
//             Assert.Equal("Daily Standup", CalendarEvent[0].Title);
//             Assert.Equal("Meeting", CalendarEvent[0].Description);
//         }
