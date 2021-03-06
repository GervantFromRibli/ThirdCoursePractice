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
    public class AreaController : Controller
    {
        private readonly ILayoutBLL _layoutBLL;
        private readonly IAreaBLL _areaBLL;

        public AreaController(ApplicationContext applicationContext)
        {
            _layoutBLL = new LayoutBLL(applicationContext);
            _areaBLL = new AreaBLL(applicationContext);
        }
        public IActionResult Index(int page = 1, string description = null, string layoutDescr = "Все", string type = null, string message = null)
        {
            int pageSize = 20;
            List<AreaCorrectViewModel> areaCorrectViewModels = GetModels();

            List<string> descriptions = _layoutBLL.GetLayouts().Select(elem => elem.Description).ToList();
            ViewBag.Message = message ?? "";
            if (description != null)
            {
                areaCorrectViewModels = areaCorrectViewModels.Where(item => item.Description.Contains(description)).ToList();
            }

            if (layoutDescr != "Все" && layoutDescr != "All" && layoutDescr != "Усе")
            {
                areaCorrectViewModels = areaCorrectViewModels.Where(item => item.LayoutDescription == layoutDescr).ToList();
            }

            if (type != null)
            {
                areaCorrectViewModels = type switch
                {
                    "Id" => areaCorrectViewModels.OrderBy(item => item.Id).ToList(),
                    "des" => areaCorrectViewModels.OrderBy(item => item.Description).ToList(),
                    "layoutDes" => areaCorrectViewModels.OrderBy(item => item.LayoutDescription).ToList(),
                    "startX" => areaCorrectViewModels.OrderBy(item => item.StartCoordX).ToList(),
                    "startY" => areaCorrectViewModels.OrderBy(item => item.StartCoordY).ToList(),
                    "endX" => areaCorrectViewModels.OrderBy(item => item.EndCoordX).ToList(),
                    _ => areaCorrectViewModels.OrderBy(item => item.EndCoordY).ToList(),
                };
            }

            AreaViewModel areaViewModel = new AreaViewModel()
            {
                Areas = areaCorrectViewModels.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                Ids = _areaBLL.GetAreas().Select(elem => elem.Id).ToList(),
                PageViewModel = new PageViewModel(areaCorrectViewModels.Count, page, pageSize),
                FilterLayoutDescriptions = descriptions
            };

            return View(areaViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddArea(AreaViewModel model)
        {
            model.Areas = GetModels();
            var message = VerificationOfArea(model);
            if (message != "Ok") 
            {
                ViewBag.Message = message;
                return RedirectToAction("Index", new { message });
            }
            else
            {
                await _areaBLL.CreateArea(_layoutBLL.GetLayouts().Where(elem => elem.Description == model.LayoutDescription).First().Id, model.Description, (int)model.StartCoordX, 
                    (int)model.StartCoordY, (int)model.EndCoordX, (int)model.EndCoordY);
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> DeleteArea(int id)
        {
            await _areaBLL.DeleteArea(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateArea(AreaViewModel model, string action = null)
        {
            if (action == "Удалить зону" || action == "Delete area" || action == "Выдаліць зону")
            {
                return await DeleteArea(model.Id);
            }
            model.Areas = GetModels();
            var message = VerificationOfArea(model);
            if (message != "Ok")
            {
                ViewBag.Message = message;
                return RedirectToAction("Index", new { message });
            }
            else
            {
                await _areaBLL.UpdateArea(model.Id, _layoutBLL.GetLayouts().Where(elem => elem.Description == model.LayoutDescription).First().Id, model.Description, (int)model.StartCoordX,
                    (int)model.StartCoordY, (int)model.EndCoordX, (int)model.EndCoordY);
                return RedirectToAction("Index");
            }
        }

        private string VerificationOfArea(AreaViewModel model)
        {
            return _areaBLL.VerificationOfArea(model.Id, model.Description, model.StartCoordX, model.StartCoordY, model.EndCoordX, model.EndCoordY,
                _layoutBLL.GetLayouts().First(elem => elem.Description == model.LayoutDescription).Id);
        }

        private List<AreaCorrectViewModel> GetModels()
        {
            List<Layout> layouts = _layoutBLL.GetLayouts();
            List<Area> areas = _areaBLL.GetAreas() ?? new List<Area>();

            List<AreaCorrectViewModel> areaCorrectViewModels = new List<AreaCorrectViewModel>();
            foreach (var elem in areas)
            {
                areaCorrectViewModels.Add(new AreaCorrectViewModel()
                {
                    Description = elem.Description,
                    Id = elem.Id,
                    LayoutDescription = layouts.Where(item => item.Id == elem.LayoutId).First().Description,
                    StartCoordX = elem.StartCoordX,
                    EndCoordX = elem.EndCoordX,
                    StartCoordY = elem.StartCoordY,
                    EndCoordY = elem.EndCoordY
                });
            }

            return areaCorrectViewModels;
        }
    }
}
