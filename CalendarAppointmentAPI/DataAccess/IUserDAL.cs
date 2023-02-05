using CalendarEvents.Models;
namespace CalendarEvents.DataAccess
{
    public interface IUserDAL
    {
        Task<List<RegisteredUsers>> GetUsersInformation();
        Task<List<CalendarEvent>> GetEventsInformation();
        Task<Dictionary<Guid, List<Guid>>> GetUsersEventsInformation();
        Task<bool> RegisterUser(RegisteredUsers userInformation);
        Task<string> verifyLoginInformation(Login loginInformation);
        bool checkTokenIsValid(Guid userId, string accessToken);
        Task<string> ClearUserAccessToken(Guid userId);
    }
}