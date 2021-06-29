using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagement.BLL;
using TicketManagement.DAL;
using TicketManagement.Web.Models;

namespace TicketManagement.Web.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly IEventBLL _eventBLL;
        private readonly IEventAreaBLL _eventAreaBLL;
        private readonly IEventSeatBLL _eventSeatBLL;
        public PurchaseController(ApplicationContext applicationContext)
        {
            _eventBLL = new EventBLL(applicationContext);
            _eventAreaBLL = new EventAreaBLL(applicationContext);
            _eventSeatBLL = new EventSeatBLL(applicationContext);
        }
        [HttpGet]
        public IActionResult Index(int id)
        {
            var eventElem = _eventBLL.GetEvent(id).Result;
            List<PurchaseAreaViewModel> purchaseAreaViewModels = GetModels(id);
            PurchaseViewModel purchaseViewModel = new PurchaseViewModel()
            {
                Event = eventElem,
                PurchaseAreaViewModels = purchaseAreaViewModels
            };
            return View(purchaseViewModel);
        }

        private List<PurchaseAreaViewModel> GetModels(int id)
        {
            var areas = _eventAreaBLL.GetEventAreas().Where(elem => elem.EventId == id);
            List<PurchaseAreaViewModel> purchaseAreaViewModels = new List<PurchaseAreaViewModel>();
            foreach (var elem in areas)
            {
                purchaseAreaViewModels.Add(new PurchaseAreaViewModel()
                {
                    Description = elem.Description,
                    EndCoordX = elem.EndCoordX,
                    EndCoordY = elem.EndCoordY,
                    EventSeats = _eventSeatBLL.GetEventSeats().Where(item => item.EventAreaId == elem.Id).ToList(),
                    Price = elem.Price,
                    StartCoordX = elem.StartCoordX,
                    StartCoordY = elem.StartCoordY
                });
            }
            return purchaseAreaViewModels;
        }
    }
}
