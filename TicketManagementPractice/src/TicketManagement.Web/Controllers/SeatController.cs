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
    public class SeatController : Controller
    {
        private readonly ISeatBLL _seatBLL;
        private readonly IAreaBLL _areaBLL;

        public SeatController(ApplicationContext applicationContext)
        {
            _seatBLL = new SeatBLL(applicationContext);
            _areaBLL = new AreaBLL(applicationContext);
        }
        public IActionResult Index(int page = 1, string areaDescr = "Все", string type = null, string message = null)
        {
            int pageSize = 20;
            List<SeatCorrectViewModel> seatCorrectViewModels = GetModels();

            List<string> descriptions = _areaBLL.GetAreas().Select(elem => elem.Description).ToList();
            ViewBag.Message = message ?? "";

            if (areaDescr != "Все" && areaDescr != "All" && areaDescr != "Усе")
            {
                seatCorrectViewModels = seatCorrectViewModels.Where(item => item.AreaDescription == areaDescr).ToList();
            }

            if (type != null)
            {
                seatCorrectViewModels = type switch
                {
                    "Id" => seatCorrectViewModels.OrderBy(item => item.Id).ToList(),
                    "areaDes" => seatCorrectViewModels.OrderBy(item => item.AreaDescription).ToList(),
                    "row" => seatCorrectViewModels.OrderBy(item => item.Row).ToList(),
                    _ => seatCorrectViewModels.OrderBy(item => item.Number).ToList(),
                };
            }

            SeatViewModel seatViewModel = new SeatViewModel()
            {
                Seats = seatCorrectViewModels.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                Ids = _seatBLL.GetSeats().Select(elem => elem.Id).ToList(),
                PageViewModel = new PageViewModel(seatCorrectViewModels.Count, page, pageSize),
                FilterAreaDescriptions = descriptions
            };

            return View(seatViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddSeat(SeatViewModel model)
        {
            model.Seats = GetModels();
            var message = VerificationOfSeat(model);
            if (message != "Ok") 
            {
                ViewBag.Message = message;
                return RedirectToAction("Index", new { message });
            }
            else
            {
                await _seatBLL.CreateSeat(_areaBLL.GetAreas().Where(elem => elem.Description == model.AreaDescription).First().Id, (int)model.Row, (int)model.Number);
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> DeleteSeat(int id)
        {
            await _seatBLL.DeleteSeat(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSeat(SeatViewModel model, string action = null)
        {
            if (action == "Удалить место" || action == "Delete seat" || action == "Выдаліць месца")
            {
                return await DeleteSeat(model.Id);
            }
            model.Seats = GetModels();
            var message = VerificationOfSeat(model);
            if (message != "Ok")
            {
                ViewBag.Message = message;
                return RedirectToAction("Index", new { message });
            }
            else
            {
                await _seatBLL.UpdateSeat(model.Id, _areaBLL.GetAreas().Where(elem => elem.Description == model.AreaDescription).First().Id, (int)model.Row, (int)model.Number);
                return RedirectToAction("Index");
            }
        }

        private string VerificationOfSeat(SeatViewModel model)
        {
            return _seatBLL.VerificationOfSeat(model.Id, model.AreaDescription, model.Row, model.Number);
        }

        private List<SeatCorrectViewModel> GetModels()
        {
            List<Seat> seats = _seatBLL.GetSeats() ?? new List<Seat>();
            List<Area> areas = _areaBLL.GetAreas();

            List<SeatCorrectViewModel> seatCorrectViewModels = new List<SeatCorrectViewModel>();
            foreach (var elem in seats)
            {
                seatCorrectViewModels.Add(new SeatCorrectViewModel()
                {
                    Id = elem.Id,
                    AreaDescription = areas.Where(item => item.Id == elem.AreaId).First().Description,
                    Row = elem.Row,
                    Number = elem.Number
                });
            }

            return seatCorrectViewModels;
        }
    }
}
