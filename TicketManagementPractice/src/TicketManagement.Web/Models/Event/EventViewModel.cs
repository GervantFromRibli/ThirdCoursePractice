using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TicketManagement.Web.Models
{
    public class EventViewModel
    {
        public List<EventCorrectViewModel> Events { get; set; }

        public PageViewModel PageViewModel { get; set; }

        public List<int> Ids { get; set; }

        public List<string> FilterLayoutDescriptions { get; set; }

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Описание слоя")]
        public string LayoutDescription { get; set; }

        [Display(Name = "Начало события")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Конец события")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Путь к изображению")]
        public string ImagePath { get; set; }
    }
}
