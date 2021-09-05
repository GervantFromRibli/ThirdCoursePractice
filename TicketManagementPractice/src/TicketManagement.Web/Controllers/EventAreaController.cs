using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            ViewBag.Message = message ?? "";
            if (description != null)
            {
                eventAreaCorrectViewModels = eventAreaCorrectViewModels.Where(item => item.Description.Contains(description)).ToList();
            }

            if (eventName != "Все" && eventName != "All" && eventName != "Усе")
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
        public async Task<IActionResult> AddEventArea(EventAreaViewModel model)
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
                await _eventAreaBLL.CreateEventArea(_eventBLL.GetEvents().Where(elem => elem.Name == model.EventName).First().Id, model.Description, (int)model.StartCoordX, 
                    (int)model.StartCoordY, (int)model.EndCoordX, (int)model.EndCoordY, model.Price);
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> DeleteEventArea(int id)
        {
            await _eventAreaBLL.DeleteEventArea(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEventArea(EventAreaViewModel model, string action = null)
        {
            if (action == "Удалить зону события" || action == "Delete event area" || action == "Выдаліць зону падзеі")
            {
                return await DeleteEventArea(model.Id);
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
                await _eventAreaBLL.UpdateEventArea(model.Id, _eventBLL.GetEvents().Where(elem => elem.Name == model.EventName).First().Id, model.Description, (int)model.StartCoordX,
                    (int)model.StartCoordY, (int)model.EndCoordX, (int)model.EndCoordY, model.Price);
                return RedirectToAction("Index");
            }
        }

        private string VerificationOfEventArea(EventAreaViewModel model)
        {
            return _eventAreaBLL.VerificationOfEventArea(model.Id, model.Description, model.StartCoordX, model.StartCoordY, model.EndCoordX, model.EndCoordY, _eventBLL.GetEvents().First(elem => elem.Name == model.EventName).Id);
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
