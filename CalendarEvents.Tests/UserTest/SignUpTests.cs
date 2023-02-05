using CalendarEvents.Business;
using CalendarEvents.Controllers;
using CalendarEvents.DataAccess;
using Microsoft.AspNetCore.Mvc;
using CalendarEvents.Models;
using FluentAssertions;
namespace CalendarEvents.Tests.UserTest
{
    public class SignUpTests
    {
        private readonly UserController _controller;
        private readonly IUserBL _userBL;
        private readonly IUserDAL _userDAL;
        public SignUpTests()
        {
            _userDAL = new UserDAL();
            _userBL = new UserBL(_userDAL);
            _controller = new UserController(_userBL);
        }
        // check get User Information as OkObjectResult
        // check get User Information type as required List<RegisteredUsers>
        // check get User information item match the list item
        // check get User information count the number of items in the list
        [Fact]
        public async Task GetUsersInformation_Return_OkResult()
        {
            //Arrange
            
            //Act
             var result = await _controller.GetUsersInformation();

            //Assert
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var User = okResult.Value.Should().BeAssignableTo<List<RegisteredUsers>>().Subject;
            Assert.Equal(new Guid("6d354fb0-d6e4-4f0a-9d62-39ebd7fad1b7"), User[4].userId);
            Assert.Equal("Sandy", User[4].firstName);
            Assert.Equal("S", User[4].lastName);
            Assert.Equal("sandy.s@disprz.com", User[4].emailId);
            Assert.Equal("SandyDisprz@123", User[4].password);
            Assert.Equal("", User[4].accessToken);
        }
        // check get event Information as OkObjectResult
        [Fact]
        public async Task GetEventsInformation_Return_OkResult()
        {
            //Arrange
            
            //Act
             var result = await _controller.GetEventsInformation();

            //Assert
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var Events = okResult.Value.Should().BeAssignableTo<List<CalendarEvent>>().Subject;
            Assert.Equal(new Guid("a016e5f4-7650-439d-8caf-41e433dfc89a"), Events[4].eventId);
            Assert.Equal("Problem-solving meeting", Events[4].title);
            Assert.Equal("Helping you bring different types of expertise and ideas together.", Events[4].addDescription);
            Assert.Equal(new DateTime(2023, 1, 30, 14, 30, 00), Events[4].startTime);
            Assert.Equal( new DateTime(2023, 1, 30, 15, 30, 00), Events[4].endTime);
            Assert.Equal("indigo", Events[4].label);
            Assert.Equal("Scheduled", Events[4].status);
        }
        // check get user events Information as OkObjectResult
        // check get user event information type as required Dictionary<Guid, List<Guid>>
        // check get user event information count the number of items in the list
        [Fact]
        public async Task GetUsersEventsInformation_Return_OkResult()
        {
            //Arrange
            
            //Act
             var result = await _controller.GetUsersEventsInformation();

            //Assert
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }

        // checks emailId exists  .
        // return created at action result

        [Fact]
        public async void Task_Add_RegisterUser_Return_CreatedAtActionResult()
        {
            //Arrange
           
            var userDetails = new RegisteredUsers() 
            { 
                userId = new Guid("00000000-0000-0000-0000-000000000000"),
                firstName = "Arun",
                lastName =  "V", 
                emailId = "arun.v@disprz.com",
                password = "ArunDisprz@123",
                accessToken = ""
            };
            //Act
            var result = await _controller.RegisterUser( userDetails);

            //Assert
            Assert.IsType<CreatedAtActionResult>(result);

            var okResult = result.Should().BeOfType<CreatedAtActionResult>().Subject;
            Assert.Equal(userDetails, okResult.Value);
        }
        [Fact]
        public async void Task_Add_RegisterUser_Return_ConflictResult()
        {
            //Arrange
           
            var userDetails = new RegisteredUsers() 
            { 
                userId = new Guid("00000000-0000-0000-0000-000000000000"),
                firstName = "Sandy",
                lastName =  "S", 
                emailId = "sandy.s@disprz.com",
                password = "SandyDisprz@123",
                accessToken = ""
            };
            //Act
            var result = await _controller.RegisterUser( userDetails);

            //Assert
            Assert.IsType<ConflictResult>(result);
        }
    }
}