using System.ComponentModel.DataAnnotations;

namespace TicketManagement.Web.Models
{
    public class RegisterView
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        public string UserRole { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Language { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Wrong password")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}
