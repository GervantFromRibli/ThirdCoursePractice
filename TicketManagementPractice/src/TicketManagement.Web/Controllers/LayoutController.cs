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
            ViewBag.Message = message ?? "";
            if (description != null)
            {
                layoutCorrectViewModels = layoutCorrectViewModels.Where(item => item.Description.Contains(description)).ToList();
            }

            if (venueAddress != "Все" && venueAddress != "All" && venueAddress != "Усе")
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
        public async Task<IActionResult> AddLayout(LayoutViewModel model)
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
                await _layoutBLL.CreateLayout(_venueBLL.GetVenues().Where(elem => elem.Address == model.VenueAddress).First().Id, model.Description);
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> DeleteLayout(int id)
        {
            await _layoutBLL.DeleteLayout(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLayout(LayoutViewModel model, string action = null)
        {
            if (action == "Удалить слой" || action == "Delete layout" || action == "Выдаліць пласт")
            {
                return await DeleteLayout(model.Id);
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
                await _layoutBLL.UpdateLayout(model.Id, _venueBLL.GetVenues().Where(elem => elem.Address == model.VenueAddress).First().Id, model.Description);
                return RedirectToAction("Index");
            }
        }

        private string VerificationOfLayout(LayoutViewModel model)
        {
            return _layoutBLL.VerificationOfLayout(model.Id, model.Description, _venueBLL.GetVenues().First(elem => elem.Address == model.VenueAddress).Id);
        }

        private List<LayoutCorrectViewModel> GetModels()
        {
            List<Layout> layouts = _layoutBLL.GetLayouts() ?? new List<Layout>();
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
