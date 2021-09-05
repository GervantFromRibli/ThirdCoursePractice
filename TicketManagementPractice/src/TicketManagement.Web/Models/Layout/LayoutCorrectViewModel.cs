using System.ComponentModel.DataAnnotations;

namespace TicketManagement.Web.Models
{
    public class LayoutCorrectViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Адрес площадки")]
        public string VenueAddress { get; set; }
    }
}
