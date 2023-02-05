using System.ComponentModel.DataAnnotations;

namespace CalendarEvents.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Please enter a valid email address")]
        [EmailAddress (ErrorMessage = "Invalid Email Address")]
        public string emailId { get; set; } = string.Empty;
        [Required (ErrorMessage ="Please enter a password")]
        [DataType(DataType.Password)]
        
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",ErrorMessage ="Invalid password")]
        public string password {get; set;} = string.Empty;    
    }
}