﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TicketManagement.Web.Models
{
    public class AreaViewModel
    {
        public List<AreaCorrectViewModel> Areas { get; set; }

        public PageViewModel PageViewModel { get; set; }

        public List<int> Ids { get; set; }

        public List<string> FilterLayoutDescriptions { get; set; }

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Описание слоя")]
        public string LayoutDescription { get; set; }

        [Display(Name = "Начальная координата X")]
        public int? StartCoordX { get; set; }

        [Display(Name = "Начальная координата Y")]
        public int? StartCoordY { get; set; }

        [Display(Name = "Конечная координата X")]
        public int? EndCoordX { get; set; }

        [Display(Name = "Конечная координата Y")]
        public int? EndCoordY { get; set; }
    }
}
