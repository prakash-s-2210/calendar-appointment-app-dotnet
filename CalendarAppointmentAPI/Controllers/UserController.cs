using  Microsoft.AspNetCore.Mvc;
using CalendarEvents.Business;
using Microsoft.AspNetCore.Authorization;
using CalendarEvents.Models;
using CalendarEvents.Attributes;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CalendarEvents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL _userBL;
        public  UserController(IUserBL userBL)
        {
            _userBL= userBL;
        }
        [HttpGet]
        [Route("UsersInformation")]
        [ProducesResponseType(typeof(RegisteredUsers), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUsersInformation()
        {
            try
            {
                var users = await _userBL.GetUsersInformation();
                if(users.Any()) 
                {
                    return Ok(users);
                } 
                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }

        [HttpGet]
        [Route("EventsInformation")]
        [ProducesResponseType(typeof(RegisteredUsers), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEventsInformation()
        {
            try
            {
                var events = await _userBL.GetEventsInformation();
                if(events.Any()) 
                {
                    return Ok(events);
                } 
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }
        

        [HttpGet]
        [Route("UsersEventsInformation")]
        [ProducesResponseType(typeof(RegisteredUsers), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUsersEventsInformation()
        {
            try
            {
                var events = await _userBL.GetUsersEventsInformation();
                if(events.Any()) 
                {
                    return Ok(events);
                } 
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }   
        }
        

        [HttpPost]
        [Route("RegisterUser")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
         public async Task<IActionResult> RegisterUser([FromBody]RegisteredUsers userInformation)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var result = await _userBL.RegisterUser(userInformation);
                     if(result == true)
                     {
                        return  CreatedAtAction(nameof(GetUsersInformation), new { id = userInformation.emailId }, userInformation);
                     }
                     else
                     {
                        return Conflict("The email id is already existed");
                     }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]Login loginInformation)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var login = await _userBL.verifyLoginInformation(loginInformation);

                    if(login != "")
                    {
                        var cookieOptions = new CookieOptions
                       { 
                            HttpOnly = true,
                            Secure = true,
                            Expires = DateTime.Now.AddDays(10),
                            Domain = "localhost",
                            SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None,
                            Path = "/"
                            
                        };
                        Response.Cookies.Append("accessToken", login, cookieOptions);
                        return Ok("authorised");
                    }
                    else 
                    {
                        return BadRequest("The email id and password entered by the user are incorrect");
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
        [Route("Logout")]
        [ServiceFilter(typeof(CustomAuth))]
        public async Task<IActionResult> Logout(Guid userId)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var clearUserAccessToken = await _userBL.ClearUserAccessToken(userId);

                    if(clearUserAccessToken == "")
                    {
                        var cookieOptions = new CookieOptions
                       { 
                            HttpOnly = true,
                            Secure = true,
                            Expires = DateTime.Now.AddDays(10),
                            Domain = "localhost",
                            SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None,
                            Path = "/"
                            
                        };
                        Response.Cookies.Append("accessToken", clearUserAccessToken, cookieOptions);
                        return Ok("Successfully logged out");
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
            else 
            {
                return BadRequest();
            }  
        }
    }

}
