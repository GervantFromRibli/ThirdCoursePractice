using System.ComponentModel.DataAnnotations;

namespace TicketManagement.Web.Models
{
    public class EventShowViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Кол-во мест")]
        public int Count { get; set; }

        public string ImageUrl { get; set; }
    }
}
