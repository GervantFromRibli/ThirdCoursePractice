using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TicketManagement.Models;

namespace TicketManagement.Web.Models
{
    public class VenueViewModel
    {
        public List<Venue> Venues { get; set; }

        public PageViewModel PageViewModel { get; set; }

        public List<int> Ids { get; set; }

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Телефон")]
        public string Phone { get; set; }
    }
}
