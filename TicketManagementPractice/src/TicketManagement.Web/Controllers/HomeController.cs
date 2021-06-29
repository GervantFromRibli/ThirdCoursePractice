using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TicketManagement.BLL;
using TicketManagement.DAL;
using TicketManagement.Models;
using TicketManagement.Web.Models;

namespace TicketManagement.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEventBLL _eventBLL;
        private readonly IEventAreaBLL _eventAreaBLL;
        private readonly IEventSeatBLL _eventSeatBLL;

        public HomeController(ILogger<HomeController> logger, ApplicationContext applicationContext)
        {
            _logger = logger;
            _eventBLL = new EventBLL(applicationContext);
            _eventAreaBLL = new EventAreaBLL(applicationContext);
            _eventSeatBLL = new EventSeatBLL(applicationContext);
        }

        [HttpGet]
        public IActionResult Index(int page = 1, string name = null, string description = null)
        {
            int pageSize = 16;
            List<EventShowViewModel> events = GetModels();
            if (description != null)
            {
                events = events.Where(item => item.Description.Contains(description)).ToList();
            }

            if (name != null)
            {
                events = events.Where(item => item.Name.Contains(name)).ToList();
            }

            HomeViewModel homeViewModel = new HomeViewModel()
            {
                Events = events.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                PageViewModel = new PageViewModel(events.Count, page, pageSize)
            };

            return View(homeViewModel);
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            if (_eventBLL.GetEvents().Where(elem => elem.Id == id).Count() > 0)
            {
                return RedirectToAction("Index", "Purchase", new { id });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        private List<EventShowViewModel> GetModels()
        {
            List<Event> events = _eventBLL.GetEvents() ?? new List<Event>();
            List<EventShowViewModel> eventShowViewModels = new List<EventShowViewModel>();
            foreach (var elem in events)
            {
                var eventAreas = _eventAreaBLL.GetEventAreas().Where(item => item.EventId == elem.Id).Select(item => item.Id);
                var eventSeats = _eventSeatBLL.GetEventSeats().Where(item => eventAreas.Contains(item.EventAreaId)).Count();
                if (eventSeats > 0)
                {
                    eventShowViewModels.Add(new EventShowViewModel()
                    {
                        Id = elem.Id,
                        Count = eventSeats,
                        Description = elem.Description,
                        Name = elem.Name,
                        ImageUrl = elem.ImagePath
                    });
                }
            }
            return eventShowViewModels;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
