using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TicketManagement.Web.Models
{
    public class LayoutViewModel
    {
        public List<LayoutCorrectViewModel> Layouts { get; set; }

        public PageViewModel PageViewModel { get; set; }

        public List<int> Ids { get; set; }

        public List<string> FilterVenueAddresses { get; set; }

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Адрес площадки")]
        public string VenueAddress { get; set; }
    }
}
