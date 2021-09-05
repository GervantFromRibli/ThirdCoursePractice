using System.ComponentModel.DataAnnotations;

namespace TicketManagement.Web.Models
{
    public class ChangePassView
    {
        public string Id { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
