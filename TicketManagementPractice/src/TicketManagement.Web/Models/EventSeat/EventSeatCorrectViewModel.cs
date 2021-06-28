using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagement.Web.Models
{
    public class EventSeatCorrectViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Описание зоны события")]
        public string EventAreaDescription { get; set; }

        [Display(Name = "Ряд")]
        public int Row { get; set; }

        [Display(Name = "Место")]
        public int Number { get; set; }

        [Display(Name = "Состояние")]
        public string State { get; set; }
    }
}
