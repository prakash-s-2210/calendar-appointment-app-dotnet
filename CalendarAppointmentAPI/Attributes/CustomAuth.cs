using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using CalendarEvents.DataAccess;
using System.Text;

namespace CalendarEvents.Attributes
{
    public class CustomAuth : ActionFilterAttribute
{
    readonly IUserDAL _userDAL;
    public CustomAuth(IUserDAL userDAL)
    {
        _userDAL = userDAL;
    }
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var cookieValue = context.HttpContext.Request.Cookies["accessToken"];
        if(cookieValue != "" )
        {
            var base64EncodedBytes = Convert.FromBase64String(cookieValue);
            var accessTokenValue = Encoding.UTF8.GetString(base64EncodedBytes);
            var array = accessTokenValue.Split(' ');
            var a = array[0];
            var userId = new Guid(a);
            var b = array[1];
            var Guid = new Guid(b);
            var checkTokenIsValid =  _userDAL.checkTokenIsValid(userId, cookieValue);
            if(checkTokenIsValid == true)
            {
                context.ActionArguments["userId"] = userId;
            }
            else
            {
                var error = new { message = "Unauthorised User", statusCode = 403 };
                context.Result = new JsonResult(error) { StatusCode = 403 };
            }
        }
        else 
        {
            var error = new { message = "Unauthorised User", statusCode = 403 };
            // context.Result = new JsonResult(error) { StatusCode = 403 }; 
            context.Result = new BadRequestObjectResult("unauthorised");
        }
    }
}
}



