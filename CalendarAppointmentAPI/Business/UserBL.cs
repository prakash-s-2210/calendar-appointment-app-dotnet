using CalendarEvents.DataAccess;
using CalendarEvents.Models;
namespace CalendarEvents.Business
{
    public class UserBL : IUserBL 
    {
        private readonly IUserDAL _userDAL;
        public UserBL(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }
        public async Task<List<RegisteredUsers>> GetUsersInformation()
        {
            return await _userDAL.GetUsersInformation();
        }
        public async Task<List<CalendarEvent>> GetEventsInformation()
        {
            return await _userDAL.GetEventsInformation();
        }
        public async Task<Dictionary<Guid, List<Guid>>> GetUsersEventsInformation()
        {
            return await _userDAL.GetUsersEventsInformation();
        }
        public  Task<bool> RegisterUser(RegisteredUsers userInformation)
        {
           return  _userDAL.RegisterUser(userInformation);
        }
        public Task<string> verifyLoginInformation(Login loginInformation)
        {
            return _userDAL.verifyLoginInformation(loginInformation);
        }
        public async Task<string> ClearUserAccessToken(Guid userId){
            return await _userDAL.ClearUserAccessToken(userId);
        }
    }
}