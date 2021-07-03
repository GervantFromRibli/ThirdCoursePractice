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
        public IActionResult Index(int page = 1, string description = null, string address = null, string type = null, string message = null)
        {
            int pageSize = 20;
            List<Venue> venues = _venueBLL.GetVenues() ?? new List<Venue>();
            List<int> Ids = venues.Select(item => item.Id).ToList();
            ViewBag.Message = message;
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
            var message = VerificationOfVenue(model);
            if (message != "Ok") 
            {
                ViewBag.Message = message;
                return RedirectToAction("Index", new { message });
            }
            else
            {
                _venueBLL.CreateVenue(model.Description, model.Address, model.Phone);
                return RedirectToAction("Index");
            }
        }

        public IActionResult DeleteVenue(int id)
        {
            _venueBLL.DeleteVenue(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateVenue(VenueViewModel model, string action = null)
        {
            if (action == "Удалить площадку" || action == "Delete venue" || action == "Выдаліць пляцоўку")
            {
                return DeleteVenue(model.Id);
            }
            model.Venues = _venueBLL.GetVenues() ?? new List<Venue>();
            var message = VerificationOfVenue(model);
            if (message != "Ok")
            {
                ViewBag.Message = message;
                return RedirectToAction("Index", new { message });
            }
            else
            {
                _venueBLL.UpdateVenue(model.Id, model.Description, model.Address, model.Phone);
                return RedirectToAction("Index");
            }
        }

        private string VerificationOfVenue(VenueViewModel model)
        {
            return _venueBLL.VerificationOfVenue(model.Id, model.Description, model.Address, model.Phone);
        }
    }
}
