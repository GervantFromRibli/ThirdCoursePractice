using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagement.Web.Models
{
    public class ChangePassView
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Новый пароль")]
        public string Password { get; set; }
    }
}
