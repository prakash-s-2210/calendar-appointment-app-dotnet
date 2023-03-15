using CalendarEvents.Models;
namespace CalendarEvents.CalendarAppointmentApp
{
    public class Users
    {
        public static List<RegisteredUsers> userDetails = new List<RegisteredUsers>()
        {
            new RegisteredUsers(){
                userId = new Guid("e0f38a81-a922-4996-ae40-e894762fd838"),
                firstName = "Prakash",
                lastName =  "S", 
                emailId = "prakash.s@gmail.com",
                password = "Prakash@123",
                accessToken = ""
            },
            new RegisteredUsers(){
                userId = new Guid("7b613837-cdb1-42f6-80c8-382b0844bf59"),
                firstName = "Santhosh",
                lastName =  "T", 
                emailId = "santhosh.t@gmail.com",
                password = "Santhosh@123",
                accessToken = ""
            },
            new RegisteredUsers(){
                userId = new Guid("d2810ec0-ee64-4d69-b8b1-702e8b3ee591"),
                firstName = "Makesh",
                lastName =  "R", 
                emailId = "makesh.r@gmail.com",
                password = "Makesh@123",
                accessToken = ""
            },
            new RegisteredUsers(){
                userId = new Guid("1626c368-e3ea-464f-be8c-2430a6116515"),
                firstName = "Jeyasurya",
                lastName =  "R", 
                emailId = "jeyasurya.r@gmail.com",
                password = "Jeyasurya@123",
                accessToken = ""
            },
            new RegisteredUsers(){
                userId = new Guid("6d354fb0-d6e4-4f0a-9d62-39ebd7fad1b7"),
                firstName = "Sandy",
                lastName =  "S", 
                emailId = "sandy.s@gmail.com",
                password = "Sandy@123",
                accessToken = ""
            }
        };  
    }
    public class RegisterUserResponse
    {
        public bool IsSuccess {get; set;}
        public string Message { get; set; } = string.Empty;
    }
}

































// public Dictionary<Guid, RegisteredUsers> UserInformations(){
//             RegisteredUsers Prakash = new RegisteredUsers(){
//                 firstName = "Prakash",
//                 lastName =  "S", 
//                 emailId = "prakash.s@disprz.com",
//                 password = "Prakash@123",
//                 accessToken = ""
//             };
//             RegisteredUsers Santhosh = new RegisteredUsers(){
//                 firstName = "Santhosh",
//                 lastName =  "T", 
//                 emailId = "santhosh.t@disprz.com",
//                 password = "Santhosh@123",
//                 accessToken = ""
//             };
//             RegisteredUsers Makesh = new RegisteredUsers(){
//                 firstName = "Makesh",
//                 lastName =  "R", 
//                 emailId = "makesh.r@disprz.com",
//                 password = "Makesh@123",
//                 accessToken = ""
//             };
//             RegisteredUsers Jeyasurya = new RegisteredUsers(){
//                 firstName = "Jeyasurya",
//                 lastName =  "R", 
//                 emailId = "jeyasurya.r@disprz.com",
//                 password = "Jeyasurya@123",
//                 accessToken = ""
//             };
//             RegisteredUsers Sandy = new RegisteredUsers(){
//                 firstName = "Sandy",
//                 lastName =  "S", 
//                 emailId = "sandy.s@disprz.com",
//                 password = "Sandy@123",
//                 accessToken = ""
//             };
//             Dictionary<Guid, RegisteredUsers>  Users= new Dictionary<Guid, RegisteredUsers>();
//             Users.Add(new Guid("e0f38a81-a922-4996-ae40-e894762fd838"), Prakash);
//             Users.Add(new Guid("7b613837-cdb1-42f6-80c8-382b0844bf59"), Santhosh);
//             Users.Add(new Guid("d2810ec0-ee64-4d69-b8b1-702e8b3ee591"), Makesh);  
//             Users.Add(new Guid("1626c368-e3ea-464f-be8c-2430a6116515"), Jeyasurya);   
//             Users.Add(new Guid("6d354fb0-d6e4-4f0a-9d62-39ebd7fad1b7"), Sandy);
//             return Users;
//         }