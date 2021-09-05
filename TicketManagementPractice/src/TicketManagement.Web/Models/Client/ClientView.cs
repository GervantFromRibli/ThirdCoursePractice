using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TicketManagement.Web.Models
{
    public class ClientView
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Language { get; set; }

        [Required]
        public int Balance { get; set; }

        public List<TicketInfoViewModel> Tickets { get; set; }
    }
}
