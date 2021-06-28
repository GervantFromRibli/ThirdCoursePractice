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
    public class EventController : Controller
    {
        private readonly ILayoutBLL _layoutBLL;
        private readonly IEventBLL _eventBLL;

        public EventController(ApplicationContext applicationContext)
        {
            _layoutBLL = new LayoutBLL(applicationContext);
            _eventBLL = new EventBLL(applicationContext);
        }
        public IActionResult Index(int page = 1, string name = null, string layoutDescr = "Все", string type = null, string message = null)
        {
            int pageSize = 20;
            List<EventCorrectViewModel> eventCorrectViewModels = GetModels();

            List<string> descriptions = _layoutBLL.GetLayouts().Select(elem => elem.Description).ToList();
            descriptions.Add("Все");
            ViewBag.Message = message;
            if (name != null)
            {
                eventCorrectViewModels = eventCorrectViewModels.Where(item => item.Name.Contains(name)).ToList();
            }

            if (layoutDescr != "Все")
            {
                eventCorrectViewModels = eventCorrectViewModels.Where(item => item.LayoutDescription == layoutDescr).ToList();
            }

            if (type != null)
            {
                eventCorrectViewModels = type switch
                {
                    "Id" => eventCorrectViewModels.OrderBy(item => item.Id).ToList(),
                    "name" => eventCorrectViewModels.OrderBy(item => item.Name).ToList(),
                    "des" => eventCorrectViewModels.OrderBy(item => item.Description).ToList(),
                    "layoutDes" => eventCorrectViewModels.OrderBy(item => item.LayoutDescription).ToList(),
                    "start" => eventCorrectViewModels.OrderBy(item => item.StartDate).ToList(),
                    "end" => eventCorrectViewModels.OrderBy(item => item.EndDate).ToList(),
                    _ => eventCorrectViewModels.OrderBy(item => item.ImagePath).ToList()
                };
            }

            EventViewModel eventViewModel = new EventViewModel()
            {
                Events = eventCorrectViewModels.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                Ids = _eventBLL.GetEvents().Select(elem => elem.Id).ToList(),
                PageViewModel = new PageViewModel(eventCorrectViewModels.Count, page, pageSize),
                FilterLayoutDescriptions = descriptions
            };

            return View(eventViewModel);
        }

        [HttpPost]
        public IActionResult AddEvent(EventViewModel model)
        {
            model.Events = GetModels();
            model.Ids = model.Events.Select(item => item.Id).ToList();
            var message = VerificationOfEvent(model);
            if (message != "Ok") 
            {
                ViewBag.Message = message;
                return RedirectToAction("Index", new { message });
            }
            else
            {
                _eventBLL.CreateEvent(model.Name, model.Description, _layoutBLL.GetLayouts().Where(elem => elem.Description == model.LayoutDescription).First().Id, model.StartDate, model.EndDate, model.ImagePath);
                return RedirectToAction("Index");
            }
        }

        public IActionResult DeleteEvent(int id)
        {
            _eventBLL.DeleteEvent(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateEvent(EventViewModel model, string action = null)
        {
            if (action == "Удалить событие")
            {
                return DeleteEvent(model.Id);
            }
            model.Events = GetModels();
            model.Ids = model.Events.Select(item => item.Id).ToList();
            var message = VerificationOfEvent(model);
            if (message != "Ok")
            {
                ViewBag.Message = message;
                return RedirectToAction("Index", new { message });
            }
            else
            {
                _eventBLL.UpdateEvent(model.Id, model.Name, model.Description, _layoutBLL.GetLayouts().Where(elem => elem.Description == model.LayoutDescription).First().Id, model.StartDate, model.EndDate, model.ImagePath);
                return RedirectToAction("Index");
            }
        }

        private string VerificationOfEvent(EventViewModel model)
        {
            var names = model.Events.Select(elem => elem.Name);
            var descrs = model.Events.Select(elem => elem.Description);
            if (model.Description == null || model.Name == null || model.StartDate == null || model.EndDate == null)
            {
                return "Отсутствие значений в строках";
            }
            if (model.Description.Length == 0 || model.Description.Length > 100 || descrs.Contains(model.Description))
            {
                return "Неправильное описание";
            }
            if (model.Name.Length == 0 || model.Name.Length > 20 || names.Contains(model.Name))
            {
                return "Неправильное имя";
            }
            if (model.StartDate >= model.EndDate || model.StartDate <= DateTime.Now)
            {
                return "Неправильные даты";
            }
            return "Ok";
        }

        private List<EventCorrectViewModel> GetModels()
        {
            List<Layout> layouts = _layoutBLL.GetLayouts();
            List<Event> events = _eventBLL.GetEvents() ?? new List<Event>();

            List<EventCorrectViewModel> eventCorrectViewModels = new List<EventCorrectViewModel>();
            foreach (var elem in events)
            {
                eventCorrectViewModels.Add(new EventCorrectViewModel()
                {
                    Name = elem.Name,
                    Description = elem.Description,
                    Id = elem.Id,
                    LayoutDescription = layouts.Where(item => item.Id == elem.LayoutId).First().Description,
                    StartDate = elem.StartDate,
                    EndDate = elem.EndDate,
                    ImagePath = elem.ImagePath
                });
            }

            return eventCorrectViewModels;
        }
    }
}
