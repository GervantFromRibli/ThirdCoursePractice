﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagement.Web.Models
{
    public class EventCorrectViewModel
    {
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
