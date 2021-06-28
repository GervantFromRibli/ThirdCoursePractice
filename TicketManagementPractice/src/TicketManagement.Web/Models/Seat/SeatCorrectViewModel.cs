using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagement.Web.Models
{
    public class SeatCorrectViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Описание зоны")]
        public string AreaDescription { get; set; }

        [Display(Name = "Ряд")]
        public int Row { get; set; }

        [Display(Name = "Место")]
        public int Number { get; set; }
    }
}
