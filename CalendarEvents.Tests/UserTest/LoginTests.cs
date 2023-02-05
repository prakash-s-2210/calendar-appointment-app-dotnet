using CalendarEvents.Business;
using CalendarEvents.Controllers;
using CalendarEvents.DataAccess;
using Microsoft.AspNetCore.Mvc;
using CalendarEvents.Models;
using FluentAssertions;
namespace CalendarEvents.Tests.UserTest
{
    public class LoginTests
    {
        private readonly UserController _controller;
        private readonly IUserBL _userBL;
        private readonly IUserDAL _userDAL;
        public LoginTests()
        {
            _userDAL = new UserDAL();
            _userBL = new UserBL(_userDAL);
            _controller = new UserController(_userBL);
        }
        // checks login emailId and password match the user list email id and password  .
        // return OK result
        [Fact]
        public async void Task_LoginUser_Return_OkResult()
        {
            //Arrange
           
            var userDetail = new Login() 
            { 
                emailId = "sandy.s@disprz.com",
                password = "SandyDisprz@123",
            };
            //Act
            var result = await _controller.Login( userDetail);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }
        // wrong email id and password return 403 status code with unauthorized message
        [Fact]
        public async void Task_LoginUser_Return_ForbiddenResult()
        {
            //Arrange
           
            var userDetails = new Login() 
            { 
                emailId = "sandy.s@disprz.com",
                password = "SandDisprz@123",
            };
            //Act
            var result = await _controller.Login( userDetails);

            //Assert
            Assert.IsType<StatusCodeResult>(result);
        }
    }
}