using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TicketManagement.BLL;
using TicketManagement.DAL;
using TicketManagement.Models;
using TicketManagement.Web.Models;

namespace TicketManagement.Web.Controllers
{
    [Authorize(Roles = "Менеджер событий")]
    public class EventSeatController : Controller
    {
        private readonly IEventSeatBLL _eventSeatBLL;
        private readonly IEventAreaBLL _eventAreaBLL;

        public EventSeatController(ApplicationContext applicationContext)
        {
            _eventAreaBLL = new EventAreaBLL(applicationContext);
            _eventSeatBLL = new EventSeatBLL(applicationContext);
        }
        public IActionResult Index(int page = 1, string eventAreaDescr = "Все", string type = null, string message = null)
        {
            int pageSize = 20;
            List<EventSeatCorrectViewModel> eventSeatCorrectViewModels = GetModels();

            List<string> descriptions = _eventAreaBLL.GetEventAreas().Select(elem => elem.Description).ToList();
            descriptions.Add("Все");
            ViewBag.Message = message;

            if (eventAreaDescr != "Все")
            {
                eventSeatCorrectViewModels = eventSeatCorrectViewModels.Where(item => item.EventAreaDescription == eventAreaDescr).ToList();
            }

            if (type != null)
            {
                eventSeatCorrectViewModels = type switch
                {
                    "Id" => eventSeatCorrectViewModels.OrderBy(item => item.Id).ToList(),
                    "eventAreaDes" => eventSeatCorrectViewModels.OrderBy(item => item.EventAreaDescription).ToList(),
                    "row" => eventSeatCorrectViewModels.OrderBy(item => item.Row).ToList(),
                    "numb" => eventSeatCorrectViewModels.OrderBy(item => item.Number).ToList(),
                    _ => eventSeatCorrectViewModels.OrderBy(item => item.State).ToList(),
                };
            }

            EventSeatViewModel eventSeatViewModel = new EventSeatViewModel()
            {
                EventSeats = eventSeatCorrectViewModels.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                Ids = _eventSeatBLL.GetEventSeats().Select(elem => elem.Id).ToList(),
                PageViewModel = new PageViewModel(eventSeatCorrectViewModels.Count, page, pageSize),
                FilterEventAreaDescriptions = descriptions
            };

            return View(eventSeatViewModel);
        }

        [HttpPost]
        public IActionResult AddEventSeat(EventSeatViewModel model)
        {
            model.EventSeats = GetModels();
            var message = VerificationOfEventSeat(model);
            if (message != "Ok") 
            {
                ViewBag.Message = message;
                return RedirectToAction("Index", new { message });
            }
            else
            {
                _eventSeatBLL.CreateEventSeat(_eventAreaBLL.GetEventAreas().Where(elem => elem.Description == model.EventAreaDescription).First().Id, (int)model.Row, (int)model.Number, model.State);
                return RedirectToAction("Index");
            }
        }

        public IActionResult DeleteEventSeat(int id)
        {
            _eventSeatBLL.DeleteEventSeat(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateEventSeat(EventSeatViewModel model, string action = null)
        {
            if (action == "Удалить место события")
            {
                return DeleteEventSeat(model.Id);
            }
            model.EventSeats = GetModels();
            var message = VerificationOfEventSeat(model);
            if (message != "Ok")
            {
                ViewBag.Message = message;
                return RedirectToAction("Index", new { message });
            }
            else
            {
                _eventSeatBLL.UpdateEventSeat(model.Id, _eventAreaBLL.GetEventAreas().Where(elem => elem.Description == model.EventAreaDescription).First().Id, (int)model.Row, (int)model.Number, model.State);
                return RedirectToAction("Index");
            }
        }

        private string VerificationOfEventSeat(EventSeatViewModel model)
        {
            var seats = model.EventSeats.Where(elem => elem.EventAreaDescription == model.EventAreaDescription).ToList() ?? new List<EventSeatCorrectViewModel>();
            var area = _eventAreaBLL.GetEventAreas().Where(elem => elem.Description == model.EventAreaDescription).First();
            if (model.Row == null || model.Number == null || model.State == null)
            {
                return "Отсутствие значений в строках";
            }
            var rowCoord = area.StartCoordY + model.Row;
            var numberCoord = area.StartCoordX + model.Number;
            if (rowCoord > area.EndCoordY || numberCoord > area.EndCoordX)
            {
                return "Место находится за границами зоны";
            }
            foreach (var seat in seats)
            {
                if (model.Row == seat.Row && model.Number == seat.Number)
                {
                    return "Уже существует данное место";
                }
            }
            return "Ok";
        }

        private List<EventSeatCorrectViewModel> GetModels()
        {
            List<EventSeat> seats = _eventSeatBLL.GetEventSeats() ?? new List<EventSeat>();
            List<EventArea> areas = _eventAreaBLL.GetEventAreas();

            List<EventSeatCorrectViewModel> eventSeatCorrectViewModels = new List<EventSeatCorrectViewModel>();
            foreach (var elem in seats)
            {
                eventSeatCorrectViewModels.Add(new EventSeatCorrectViewModel()
                {
                    Id = elem.Id,
                    EventAreaDescription = areas.Where(item => item.Id == elem.EventAreaId).First().Description,
                    Row = elem.Row,
                    Number = elem.Number,
                    State = elem.State
                });
            }

            return eventSeatCorrectViewModels;
        }
    }
}
