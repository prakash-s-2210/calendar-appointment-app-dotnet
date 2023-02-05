using CalendarEvents.Business;
using CalendarEvents.Controllers;
using CalendarEvents.DataAccess;
using Microsoft.AspNetCore.Mvc;
using CalendarEvents.Models;
using FluentAssertions;

namespace CalendarEvents.Tests.calendarEventsTest
{
    public class DeleteCalendarEventsTest
    {
        private readonly CalendarEventsController _controller;
        private readonly ICalendarEventsBL _calendarEventsBL;
        private readonly ICalendarEventsDAL _calednarEventsDAL;
        public DeleteCalendarEventsTest()
        {
            _calednarEventsDAL = new CalendarEventsDAL();
            _calendarEventsBL = new CalendarEventsBL(_calednarEventsDAL);
            _controller = new CalendarEventsController(_calendarEventsBL);
        }
//  delete calendarEvent return OK result and event Id matches
        [Fact]
        public async void Task_Delete_CalendarEvent_Return_OkResult()
        {
            //Arrange
            var eventID  = new Guid("9ac8b274-88b7-4232-af82-161c22d83c54");
            var userId = new Guid("e0f38a81-a922-4996-ae40-e894762fd838");

            //Act
            var result = await _controller.DeleteCalendarEvent(eventID, userId);

            //Assert
            // Assert.IsType<OkResult>(result);
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var Events = okResult.Value.Should().BeAssignableTo<Guid>().Subject;
            Assert.Equal(new Guid("9ac8b274-88b7-4232-af82-161c22d83c54"), Events);
        }

        [Fact]
        public async void Task_Delete_CalendarEvent_Return_NotFoundResult()
        {
            //Arrange
            var eventID  = new Guid("9ac8b273-88b7-4232-af82-161c22d83c54");
            var userId = new Guid("e0f38a81-a922-4996-ae40-e894762fd838");

            //Act
            var result = await _controller.DeleteCalendarEvent(eventID, userId);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Task_DeleteCalendarEvent_Return_BadRequestResult()
        {
            //Arrange
            var eventID  = new Guid("9ac8b274-88b7-4232-af82-161c22d83c54");
            var userId = new Guid("e0f38a81-a952-4996-ae40-e894762fd838");

            //Act
            var data = await _controller.DeleteCalendarEvent(eventID, userId);

            //Assert
            Assert.IsType<BadRequestResult>(data);
        }
    }
}