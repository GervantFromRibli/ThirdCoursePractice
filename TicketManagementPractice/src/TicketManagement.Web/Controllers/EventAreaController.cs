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
    public class EventAreaController : Controller
    {
        private readonly IEventBLL _eventBLL;
        private readonly IEventAreaBLL _eventAreaBLL;

        public EventAreaController(ApplicationContext applicationContext)
        {
            _eventAreaBLL = new EventAreaBLL(applicationContext);
            _eventBLL = new EventBLL(applicationContext);
        }
        public IActionResult Index(int page = 1, string description = null, string eventName = "Все", string type = null, string message = null)
        {
            int pageSize = 20;
            List<EventAreaCorrectViewModel> eventAreaCorrectViewModels = GetModels();

            List<string> names = _eventBLL.GetEvents().Select(elem => elem.Name).ToList();
            names.Add("Все");
            ViewBag.Message = message;
            if (description != null)
            {
                eventAreaCorrectViewModels = eventAreaCorrectViewModels.Where(item => item.Description.Contains(description)).ToList();
            }

            if (eventName != "Все")
            {
                eventAreaCorrectViewModels = eventAreaCorrectViewModels.Where(item => item.EventName == eventName).ToList();
            }

            if (type != null)
            {
                eventAreaCorrectViewModels = type switch
                {
                    "Id" => eventAreaCorrectViewModels.OrderBy(item => item.Id).ToList(),
                    "des" => eventAreaCorrectViewModels.OrderBy(item => item.Description).ToList(),
                    "eventName" => eventAreaCorrectViewModels.OrderBy(item => item.EventName).ToList(),
                    "startX" => eventAreaCorrectViewModels.OrderBy(item => item.StartCoordX).ToList(),
                    "startY" => eventAreaCorrectViewModels.OrderBy(item => item.StartCoordY).ToList(),
                    "endX" => eventAreaCorrectViewModels.OrderBy(item => item.EndCoordX).ToList(),
                    "endY" => eventAreaCorrectViewModels.OrderBy(item => item.EndCoordY).ToList(),
                    _ => eventAreaCorrectViewModels.OrderBy(item => item.Price).ToList(),
                };
            }

            EventAreaViewModel eventAreaViewModel = new EventAreaViewModel()
            {
                EventAreas = eventAreaCorrectViewModels.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                Ids = _eventAreaBLL.GetEventAreas().Select(elem => elem.Id).ToList(),
                PageViewModel = new PageViewModel(eventAreaCorrectViewModels.Count, page, pageSize),
                FilterEventNames = names
            };

            return View(eventAreaViewModel);
        }

        [HttpPost]
        public IActionResult AddEventArea(EventAreaViewModel model)
        {
            model.EventAreas = GetModels();
            var message = VerificationOfEventArea(model);
            if (message != "Ok") 
            {
                ViewBag.Message = message;
                return RedirectToAction("Index", new { message });
            }
            else
            {
                _eventAreaBLL.CreateEventArea(_eventBLL.GetEvents().Where(elem => elem.Name == model.EventName).First().Id, model.Description, (int)model.StartCoordX, 
                    (int)model.StartCoordY, (int)model.EndCoordX, (int)model.EndCoordY, model.Price);
                return RedirectToAction("Index");
            }
        }

        public IActionResult DeleteEventArea(int id)
        {
            _eventAreaBLL.DeleteEventArea(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateEventArea(EventAreaViewModel model, string action = null)
        {
            if (action == "Удалить зону события")
            {
                return DeleteEventArea(model.Id);
            }
            model.EventAreas = GetModels();
            var message = VerificationOfEventArea(model);
            if (message != "Ok")
            {
                ViewBag.Message = message;
                return RedirectToAction("Index", new { message });
            }
            else
            {
                _eventAreaBLL.UpdateEventArea(model.Id, _eventBLL.GetEvents().Where(elem => elem.Name == model.EventName).First().Id, model.Description, (int)model.StartCoordX,
                    (int)model.StartCoordY, (int)model.EndCoordX, (int)model.EndCoordY, model.Price);
                return RedirectToAction("Index");
            }
        }

        private string VerificationOfEventArea(EventAreaViewModel model)
        {
            var descrs = model.EventAreas.Where(elem => elem.EventName == model.EventName).Select(elem => elem.Description);
            var eventId = _eventBLL.GetEvents().Where(elem => elem.Name == model.EventName).First().Id;
            if (model.Description == null || model.StartCoordX == null || model.StartCoordY == null || model.EndCoordY == null || model.EndCoordX == null)
            {
                return "Отсутствие значений в строках";
            }
            if (model.Description.Length == 0 || model.Description.Length > 100 || descrs.Contains(model.Description))
            {
                return "Неправильное описание";
            }
            if (model.StartCoordX >= model.EndCoordX || model.StartCoordY >= model.EndCoordY)
            {
                return "Неправильный порядок координат";
            }
            foreach (var area in _eventAreaBLL.GetEventAreas().Where(elem => elem.EventId == eventId) ?? new List<EventArea>())
            {
                if (model.StartCoordX > area.StartCoordX && model.StartCoordX < area.EndCoordX && model.StartCoordY > area.StartCoordY && model.StartCoordY < model.EndCoordY)
                {
                    return "Неправильная начальная координата; начальная координата не должна быть внутри другой зоны";
                }
                if (model.EndCoordX > area.StartCoordX && model.EndCoordX < area.EndCoordX && model.EndCoordY > area.StartCoordY && model.EndCoordY < model.EndCoordY)
                {
                    return "Неправильная конечная координата; конечная координата не должна быть внутри другой зоны";
                }
            }
            return "Ok";
        }

        private List<EventAreaCorrectViewModel> GetModels()
        {
            List<Event> events = _eventBLL.GetEvents();
            List<EventArea> eventAreas = _eventAreaBLL.GetEventAreas() ?? new List<EventArea>();

            List<EventAreaCorrectViewModel> eventAreaCorrectViewModels = new List<EventAreaCorrectViewModel>();
            foreach (var elem in eventAreas)
            {
                eventAreaCorrectViewModels.Add(new EventAreaCorrectViewModel()
                {
                    Description = elem.Description,
                    Id = elem.Id,
                    EventName = events.Where(item => item.Id == elem.EventId).First().Name,
                    StartCoordX = elem.StartCoordX,
                    EndCoordX = elem.EndCoordX,
                    StartCoordY = elem.StartCoordY,
                    EndCoordY = elem.EndCoordY,
                    Price = elem.Price
                });
            }

            return eventAreaCorrectViewModels;
        }
    }
}
