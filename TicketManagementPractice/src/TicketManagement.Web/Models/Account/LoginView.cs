using System.ComponentModel.DataAnnotations;

namespace TicketManagement.Web.Models
{
    public class LoginView
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
