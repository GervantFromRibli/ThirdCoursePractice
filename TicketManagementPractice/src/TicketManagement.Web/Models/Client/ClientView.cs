using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TicketManagement.Models;

namespace TicketManagement.Web.Models
{
    public class ClientView
    {
        [Required]
        public string Id { get; set; }
        [Required]
        [Display(Name = "Ваш Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Ваша фамилия")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Ваше имя")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Язык")]
        public string Language { get; set; }

        [Required]
        [Display(Name = "Баланс($)")]
        public int Balance { get; set; }

        public List<Ticket> Tickets { get; set; }
    }
}
