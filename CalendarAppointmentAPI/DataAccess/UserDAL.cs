using CalendarEvents.Models;
using CalendarEvents.CalendarAppointmentApp;
using  System.Threading.Tasks;
using System.Linq;
using System.Text;
namespace CalendarEvents.DataAccess
{
    public class UserDAL : IUserDAL
    {
        Users users = new Users();
        
        Events events =  new Events();
        UsersEventsId usersEventsId = new UsersEventsId();
        public async Task<List<RegisteredUsers>>GetUsersInformation()
        {
            return await Task.FromResult(Users.userDetails);
        }

        public async Task<List<CalendarEvent>>GetEventsInformation()
        {
            return await Task.FromResult(Events.eventDetails);
        }
        public async Task<Dictionary<Guid, List<Guid>>>GetUsersEventsInformation()
        {
            return await Task.FromResult(UsersEventsId.usersEventsList);
        }
        public  Task<bool> RegisterUser(RegisteredUsers userInformation)
        {
            var checkEmailIdExist = Users.userDetails.FirstOrDefault(x=>x.emailId == userInformation.emailId);
            if(checkEmailIdExist == null)
            {
                userInformation.userId = Guid.NewGuid();
                Users.userDetails.Add(userInformation);
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        public Task<string> verifyLoginInformation(Login loginInformation)
        {
            if(Users.userDetails.Any(x => x.emailId == loginInformation.emailId && x.password == loginInformation.password))
            {
                var loginUserInformation = Users.userDetails.FirstOrDefault(x=>x.emailId == loginInformation.emailId);
                if(loginUserInformation != null)
                {
                    var userId = loginUserInformation.userId;
                    var token = userId+" "+Guid.NewGuid();
                    var textBytes = Encoding.UTF8.GetBytes(token);
                    var base64String = Convert.ToBase64String(textBytes);
                    var accessToken = base64String;
                    var userDetails = Users.userDetails.FirstOrDefault(x => x.emailId == loginInformation.emailId);
                    if(userDetails != null)
                    {
                        userDetails.accessToken = accessToken;
                        return Task.FromResult(accessToken);
                    }
                    else
                        return Task.FromResult("");
                }
                else
                  return Task.FromResult("");
            }
            else
                return Task.FromResult("");
        }

        public bool checkTokenIsValid(Guid userId, string accessToken)
        {
            var checkUserId = Users.userDetails.FirstOrDefault(x => x.userId ==userId);
            var checkAccessToken = Users.userDetails.FirstOrDefault(x => x.accessToken == accessToken);
            if(checkUserId != null && checkAccessToken != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<string> ClearUserAccessToken(Guid userId)
        {
            var userInformation = Users.userDetails.FirstOrDefault(x=>x.userId == userId);
            if(userInformation != null)
            {
                userInformation.accessToken = "";
                return await Task.FromResult(userInformation.accessToken);
            }
            else
            {
                return await Task.FromResult("access token is not found");
            }
        }
    }
}