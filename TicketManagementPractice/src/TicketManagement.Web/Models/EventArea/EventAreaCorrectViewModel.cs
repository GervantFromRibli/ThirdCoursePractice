using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagement.Web.Models
{
    public class EventAreaCorrectViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Название события")]
        public string EventName { get; set; }

        [Display(Name = "Начальная координата X")]
        public int StartCoordX { get; set; }

        [Display(Name = "Начальная координата Y")]
        public int StartCoordY { get; set; }

        [Display(Name = "Конечная координата X")]
        public int EndCoordX { get; set; }

        [Display(Name = "Конечная координата Y")]
        public int EndCoordY { get; set; }

        [Display(Name = "Цена")]
        public decimal Price { get; set; }
    }
}
