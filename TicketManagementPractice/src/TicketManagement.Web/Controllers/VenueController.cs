using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using TicketManagement.BLL;
using TicketManagement.DAL;
using TicketManagement.Models;
using TicketManagement.Web.Models;

namespace TicketManagement.Web.Controllers
{
    [Authorize(Roles = "Менеджер площадок")]
    public class VenueController : Controller
    {
        private readonly IVenueBLL _venueBLL;

        public VenueController(ApplicationContext applicationContext)
        {
            _venueBLL = new VenueBLL(applicationContext);
        }
        public IActionResult Index(int page = 1, string description = null, string address = null, string type = null)
        {
            int pageSize = 20;
            List<Venue> venues = _venueBLL.GetVenues() ?? new List<Venue>();
            List<int> Ids = venues.Select(item => item.Id).ToList();

            if (description != null)
            {
                venues = venues.Where(item => item.Description.Contains(description)).ToList();
            }

            if (address != null)
            {
                venues = venues.Where(item => item.Address.Contains(address)).ToList();
            }

            if (type != null)
            {
                venues = type switch
                {
                    "Id" => venues.OrderBy(item => item.Id).ToList(),
                    "des" => venues.OrderBy(item => item.Description).ToList(),
                    "addr" => venues.OrderBy(item => item.Address).ToList(),
                    _ => venues.OrderBy(item => item.Phone).ToList(),
                };
            }

            VenueViewModel venueViewModel = new VenueViewModel()
            {
                Venues = venues.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                Ids = Ids,
                PageViewModel = new PageViewModel(venues.Count, page, pageSize)
            };

            return View(venueViewModel);
        }

        [HttpPost]
        public IActionResult AddVenue(VenueViewModel model)
        {
            model.Venues = _venueBLL.GetVenues() ?? new List<Venue>();
            ViewData["Message"] = "";
            model.Ids = model.Venues.Select(item => item.Id).ToList();
            var message = VerificationOfVenue(model);
            if (message != "Ok") 
            {
                ViewData["Message"] += message;
                return View("Index", model);
            }
            else
            {
                _venueBLL.CreateVenue(model.Description, model.Address, model.Phone);
                return RedirectToAction("Index");
            }
        }

        public IActionResult DeleteVenue(int id)
        {
            ViewData["Message"] = "";
            _venueBLL.DeleteVenue(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateEmployee(VenueViewModel model, string action = null)
        {
            if (action != null)
            {
                return DeleteVenue(model.Id);
            }
            model.Venues = _venueBLL.GetVenues() ?? new List<Venue>();
            ViewData["Message"] = "";
            model.Ids = model.Venues.Select(item => item.Id).ToList();
            var message = VerificationOfVenue(model);
            if (message != "Ok")
            {
                ViewData["Message"] += message;
                return View("Index", model);
            }
            else
            {
                _venueBLL.UpdateVenue(model.Id, model.Description, model.Address, model.Phone);
                return RedirectToAction("Index");
            }
        }

        private string VerificationOfVenue(VenueViewModel model)
        {
            var addrs = model.Venues.Select(elem => elem.Address);
            var descrs = model.Venues.Select(elem => elem.Description);
            if (model.Address == null || model.Description == null || model.Phone == null)
            {
                return "Отсутствие значений в строках";
            }
            if (addrs.Contains(model.Address) || model.Address.Length == 0 || model.Address.Length > 60)
            {
                return "Неправильный адрес";
            }
            if (model.Description.Length == 0 || model.Description.Length > 100 || descrs.Contains(model.Description))
            {
                return "Неправильное описание";
            }
            if (model.Phone.Length < 5 || model.Phone.Length > 15)
            {
                return "Неправильный ввод телефона";
            }
            return "Ok";
        }
    }
}
