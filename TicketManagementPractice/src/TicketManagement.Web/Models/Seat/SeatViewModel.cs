using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TicketManagement.Web.Models
{
    public class SeatViewModel
    {
        public List<SeatCorrectViewModel> Seats { get; set; }

        public PageViewModel PageViewModel { get; set; }

        public List<int> Ids { get; set; }

        public List<string> FilterAreaDescriptions { get; set; }

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Описание зоны")]
        public string AreaDescription { get; set; }

        [Display(Name = "Ряд")]
        public int? Row { get; set; }

        [Display(Name = "Место")]
        public int? Number { get; set; }
    }
}
