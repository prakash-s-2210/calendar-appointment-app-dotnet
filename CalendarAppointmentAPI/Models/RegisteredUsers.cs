using System.ComponentModel.DataAnnotations;

namespace CalendarEvents.Models
{
    public class RegisteredUsers
    {
        
        public Guid userId { get; set; }
        // public Guid id { get; set; }
        [Required(ErrorMessage ="Please enter a first name")]
        public string firstName { get; set; } = string.Empty;
        
        [Required(ErrorMessage ="Please enter a last name")]
        public string lastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a valid email address")]
        [EmailAddress (ErrorMessage = "Invalid Email Address")]
        public string emailId { get; set; } = string.Empty;
        [Required (ErrorMessage ="Please enter a password")]
        [DataType(DataType.Password)]
        
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",ErrorMessage ="Invalid password")]
        public string password {get; set;} = string.Empty;
        // [Required(ErrorMessage ="Please enter a confirm password")]
        // [DataType(DataType.Password)]
        // [Compare("password")]
        // public string confirmPassword { get; set; } = string.Empty;  
        public string accessToken {get; set;} = string.Empty;
             
    }
}