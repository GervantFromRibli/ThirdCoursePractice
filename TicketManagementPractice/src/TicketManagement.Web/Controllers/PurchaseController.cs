using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagement.BLL;
using TicketManagement.DAL;
using TicketManagement.Models;
using TicketManagement.Web.Models;

namespace TicketManagement.Web.Controllers
{
    [Authorize(Roles = "Базовый пользователь")]
    public class PurchaseController : Controller
    {
        private readonly IEventBLL _eventBLL;
        private readonly IEventAreaBLL _eventAreaBLL;
        private readonly IEventSeatBLL _eventSeatBLL;
        private readonly ITicketBLL _ticketBLL;
        private readonly UserManager<User> _userManager;
        public PurchaseController(UserManager<User> userManager, ApplicationContext applicationContext)
        {
            _eventBLL = new EventBLL(applicationContext);
            _eventAreaBLL = new EventAreaBLL(applicationContext);
            _eventSeatBLL = new EventSeatBLL(applicationContext);
            _ticketBLL = new TicketBLL(applicationContext);
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index(int id, string message = null)
        {
            PurchaseViewModel purchaseViewModel = GetModels(id);
            ViewBag.Message = message;
            return View(purchaseViewModel);
        }

        private PurchaseViewModel GetModels(int id)
        {
            var areas = _eventAreaBLL.GetEventAreas().Where(elem => elem.EventId == id);
            int rowMin = areas.Select(elem => elem.StartCoordY).Min();
            int numbMin = areas.Select(elem => elem.StartCoordX).Min();
            int rowMax = areas.Select(elem => elem.EndCoordY).Max();
            int numbMax = areas.Select(elem => elem.EndCoordX).Max();
            List<PurchaseSeatViewModel> purchaseSeatViewModels = new List<PurchaseSeatViewModel>();
            foreach (var elem in areas)
            {
                var seats = _eventSeatBLL.GetEventSeats().Where(item => item.EventAreaId == elem.Id);
                foreach (var seat in seats)
                {
                    purchaseSeatViewModels.Add(new PurchaseSeatViewModel()
                    {
                        Id = seat.Id,
                        State = seat.State,
                        NumbIndex = elem.StartCoordX - numbMin + seat.Number,
                        RowIndex = elem.StartCoordY - rowMin + seat.Row
                    });
                }
            }
            PurchaseViewModel purchaseViewModel = new PurchaseViewModel()
            {
                Event = _eventBLL.GetEvent(id).Result,
                NumbCount = numbMax - numbMin,
                RowCount = rowMax - rowMin,
                PurchaseSeatViewModels = purchaseSeatViewModels
            };
            return purchaseViewModel;
        }

        public async Task<IActionResult> BuyTicket(int seatId)
        {
            var seat = _eventSeatBLL.GetEventSeat(seatId).Result;
            var area = _eventAreaBLL.GetEventArea(seat.EventAreaId).Result;
            var @event = _eventBLL.GetEvent(area.EventId).Result;
            await _eventSeatBLL.UpdateEventSeat(seatId, seat.EventAreaId, seat.Row, seat.Number, "Занято");
            BuyTicketViewModel buyTicketViewModel = new BuyTicketViewModel()
            {
                Id = seatId,
                AreaDescription = area.Description,
                EventName = @event.Name,
                Number = seat.Number,
                Price = area.Price,
                Row = seat.Row
            };
            return View(buyTicketViewModel);
        }

        public async Task<IActionResult> BuyNewTicket(int id, string userName, string confirm)
        {
            var user = _userManager.FindByNameAsync(userName).Result;
            var seat = _eventSeatBLL.GetEventSeat(id).Result;
            var area = _eventAreaBLL.GetEventArea(seat.EventAreaId).Result;
            if (confirm == "Нет" || confirm == "No")
            {
                var eventElem = _eventBLL.GetEvents().Where(elem => elem.Id == area.EventId).First();
                return await RemoveBooking(id, eventElem.Id);
            }
            else if (user.Balance < area.Price)
            {
                var eventElem = _eventBLL.GetEvents().Where(elem => elem.Id == area.EventId).First();
                return await RemoveBooking(id, eventElem.Id, "Error");
            }
            else
            {
                await _ticketBLL.CreateTicket(id, user.Id);
                await _eventSeatBLL.UpdateEventSeat(id, seat.EventAreaId, seat.Row, seat.Number, "Куплено");
                user.Balance -= area.Price;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", new { id = area.EventId });
            }
        }

        public async Task<IActionResult> RemoveBooking(int id, int eventId, string message = null)
        {
            var ticket = _ticketBLL.GetTickets().Where(elem => elem.EventSeatId == id);
            if (!ticket.Any())
            {
                var seat = _eventSeatBLL.GetEventSeat(id).Result;
                await _eventSeatBLL.UpdateEventSeat(id, seat.EventAreaId, seat.Row, seat.Number, "Свободно");
            }
            return RedirectToAction("Index", new { id = eventId, message });
        }
    }
}
