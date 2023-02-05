using CalendarEvents.Models;
namespace CalendarEvents.Business
{
    public interface IUserBL
    {
        Task<List<RegisteredUsers>> GetUsersInformation();
        Task<List<CalendarEvent>> GetEventsInformation();
        Task<Dictionary<Guid, List<Guid>>> GetUsersEventsInformation();
        Task<bool> RegisterUser(RegisteredUsers userInformation);
        Task<string> verifyLoginInformation(Login loginInformation);
        Task<string> ClearUserAccessToken(Guid userId);
    }
}