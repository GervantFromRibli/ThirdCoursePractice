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
    [Authorize(Roles = "Менеджер площадок")]
    public class LayoutController : Controller
    {
        private readonly ILayoutBLL _layoutBLL;
        private readonly IVenueBLL _venueBLL;

        public LayoutController(ApplicationContext applicationContext)
        {
            _layoutBLL = new LayoutBLL(applicationContext);
            _venueBLL = new VenueBLL(applicationContext);
        }
        public IActionResult Index(int page = 1, string description = null, string venueAddress = "Все", string type = null, string message = null)
        {
            int pageSize = 20;
            List<LayoutCorrectViewModel> layoutCorrectViewModels = GetModels();

            List<string> addresses = _venueBLL.GetVenues().Select(elem => elem.Address).ToList();
            addresses.Add("Все");
            ViewBag.Message = message;
            if (description != null)
            {
                layoutCorrectViewModels = layoutCorrectViewModels.Where(item => item.Description.Contains(description)).ToList();
            }

            if (venueAddress != "Все")
            {
                layoutCorrectViewModels = layoutCorrectViewModels.Where(item => item.VenueAddress == venueAddress).ToList();
            }

            if (type != null)
            {
                layoutCorrectViewModels = type switch
                {
                    "Id" => layoutCorrectViewModels.OrderBy(item => item.Id).ToList(),
                    "des" => layoutCorrectViewModels.OrderBy(item => item.Description).ToList(),
                    _ => layoutCorrectViewModels.OrderBy(item => item.VenueAddress).ToList(),
                };
            }

            LayoutViewModel layoutViewModel = new LayoutViewModel()
            {
                Layouts = layoutCorrectViewModels.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                Ids = _venueBLL.GetVenues().Select(elem => elem.Id).ToList(),
                PageViewModel = new PageViewModel(layoutCorrectViewModels.Count, page, pageSize),
                FilterVenueAddresses = addresses
            };

            return View(layoutViewModel);
        }

        [HttpPost]
        public IActionResult AddLayout(LayoutViewModel model)
        {
            model.Layouts = GetModels();
            model.Ids = model.Layouts.Select(item => item.Id).ToList();
            var message = VerificationOfLayout(model);
            if (message != "Ok") 
            {
                ViewBag.Message = message;
                return RedirectToAction("Index", new { message });
            }
            else
            {
                _layoutBLL.CreateLayout(_venueBLL.GetVenues().Where(elem => elem.Address == model.VenueAddress).First().Id, model.Description);
                return RedirectToAction("Index");
            }
        }

        public IActionResult DeleteLayout(int id)
        {
            _layoutBLL.DeleteLayout(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateLayout(LayoutViewModel model, string action = null)
        {
            if (action == "Удалить слой")
            {
                return DeleteLayout(model.Id);
            }
            model.Layouts = GetModels();
            model.Ids = model.Layouts.Select(item => item.Id).ToList();
            var message = VerificationOfLayout(model);
            if (message != "Ok")
            {
                ViewBag.Message = message;
                return RedirectToAction("Index", new { message });
            }
            else
            {
                _layoutBLL.UpdateLayout(model.Id, _venueBLL.GetVenues().Where(elem => elem.Address == model.VenueAddress).First().Id, model.Description);
                return RedirectToAction("Index");
            }
        }

        private string VerificationOfLayout(LayoutViewModel model)
        {
            var descrs = model.Layouts.Select(elem => elem.Description);
            if (model.Description == null)
            {
                return "Отсутствие значений в строках";
            }
            if (model.Description.Length == 0 || model.Description.Length > 100 || descrs.Contains(model.Description))
            {
                return "Неправильное описание";
            }
            return "Ok";
        }

        private List<LayoutCorrectViewModel> GetModels()
        {
            List<Layout> layouts = _layoutBLL.GetLayouts() ?? new List<Layout>();
            List<int> Ids = layouts.Select(item => item.Id).ToList();
            List<Venue> venues = _venueBLL.GetVenues();

            List<LayoutCorrectViewModel> layoutCorrectViewModels = new List<LayoutCorrectViewModel>();
            foreach (var elem in layouts)
            {
                layoutCorrectViewModels.Add(new LayoutCorrectViewModel()
                {
                    Description = elem.Description,
                    Id = elem.Id,
                    VenueAddress = venues.Where(item => item.Id == elem.VenueId).First().Address
                });
            }

            return layoutCorrectViewModels;
        }
    }
}
