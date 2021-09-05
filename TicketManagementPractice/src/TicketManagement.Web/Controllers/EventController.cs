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
            ViewBag.Message = message ?? "";
            if (name != null)
            {
                eventCorrectViewModels = eventCorrectViewModels.Where(item => item.Name.Contains(name)).ToList();
            }

            if (layoutDescr != "Все" && layoutDescr != "All" && layoutDescr != "Усе")
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
        public async Task<IActionResult> AddEvent(EventViewModel model)
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
                await _eventBLL.CreateEvent(model.Name, model.Description, _layoutBLL.GetLayouts().Where(elem => elem.Description == model.LayoutDescription).First().Id, model.StartDate, model.EndDate, model.ImagePath);
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> DeleteEvent(int id)
        {
            await _eventBLL.DeleteEvent(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEvent(EventViewModel model, string action = null)
        {
            if (action == "Удалить событие" || action == "Delete event" || action == "Выдаліць падзею")
            {
                return await DeleteEvent(model.Id);
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
                await _eventBLL.UpdateEvent(model.Id, model.Name, model.Description, _layoutBLL.GetLayouts().Where(elem => elem.Description == model.LayoutDescription).First().Id, model.StartDate, model.EndDate, model.ImagePath);
                return RedirectToAction("Index");
            }
        }

        private string VerificationOfEvent(EventViewModel model)
        {
            return _eventBLL.VerificationOfEvent(model.Id, model.Name, model.Description, model.StartDate, model.EndDate, _layoutBLL.GetLayouts().First(elem => elem.Description == model.LayoutDescription).Id);
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
