using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


//THE REGULAR EXPRESSIONS WERE GIVING ME ERRORS, LEAVE COMMENTED OUT FOR NOW


namespace SportsPro.Models
{
    public class Technician
    {
		public int TechnicianID { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter an email")]
        //Match the first string which can consist of any characters, followed by an @
        //Any characters, followed by dot, letters for the email domain name.
        //[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]$", ErrorMessage = "Make sure the email address is valid")]
        public string Email { get; set; } = string.Empty;
        //[RegularExpression(@"^\d}{10}$", ErrorMessage = "Please enter a valid 10-digit phone number")]
        [Required(ErrorMessage = "Please enter a phone number")]
        //"^" match the optional parameter of opening parenthesis, followed by 3 numbers, followed by another optional closing parenthesis.
        //Optional hyphen or period character, 3 more numbers, optional hyphen or dot, end in 4 
        public string Phone { get; set; } = string.Empty;
    }
}
