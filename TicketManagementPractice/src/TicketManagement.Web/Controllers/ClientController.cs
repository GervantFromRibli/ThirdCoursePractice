using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagement.Web.Models;
using TicketManagement.BLL;
using Microsoft.AspNetCore.Authorization;
using TicketManagement.DAL;

namespace TicketManagement.Web.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private ITicketBLL _ticketBLL;
        private IEventSeatBLL _eventSeatBLL;
        private IEventAreaBLL _eventAreaBLL;
        private IEventBLL _eventBLL;

        public ClientController(ApplicationContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _ticketBLL = new TicketBLL(context);
            _eventSeatBLL = new EventSeatBLL(context);
            _eventAreaBLL = new EventAreaBLL(context);
            _eventBLL = new EventBLL(context);
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ClientView clientView = new ClientView()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                Language = user.Language,
                Surname = user.Surname,
                Balance = (int)user.Balance,
                Tickets = GetTicketModels(user.Id)
            };
            ViewBag.id = clientView.Id;
            ViewBag.balance = clientView.Balance;
            return View(clientView);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeData(ClientView view)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(view.Id);
                if (user != null)
                {
                    user.Email = view.Email;
                    user.Surname = view.Surname;
                    user.FirstName = view.FirstName;
                    user.Balance = view.Balance;
                    user.Language = view.Language;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        switch (view.Language)
                        {
                            case "Беларуская":
                                {
                                    Response.Cookies.Append(".AspNetCore.Culture", "c=be|uic=be");
                                    break;
                                }
                            case "Русский":
                                {
                                    Response.Cookies.Append(".AspNetCore.Culture", "c=ru|uic=ru");
                                    break;
                                }
                            default:
                                {
                                    Response.Cookies.Append(".AspNetCore.Culture", "c=en|uic=en");
                                    break;
                                }
                        }
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View("Index", view);
        }

        [HttpGet]
        public IActionResult ChangePassword(string id)
        {
            return View(new ChangePassView() { Id = id});
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassView view)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(view.Id);
                if (user != null)
                {
                    var _passwordValidator =
                        HttpContext.RequestServices.GetService(typeof(IPasswordValidator<User>)) as IPasswordValidator<User>;
                    var _passwordHasher =
                        HttpContext.RequestServices.GetService(typeof(IPasswordHasher<User>)) as IPasswordHasher<User>;

                    IdentityResult result =
                        await _passwordValidator.ValidateAsync(_userManager, user, view.Password);
                    if (result.Succeeded)
                    {
                        user.PasswordHash = _passwordHasher.HashPassword(user, view.Password);
                        await _userManager.UpdateAsync(user);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No user was found");
                }
            }
            return View(view);
        }

        private List<TicketInfoViewModel> GetTicketModels(string id)
        {
            List<TicketInfoViewModel> ticketInfoViewModels = new List<TicketInfoViewModel>();
            var tickets = _ticketBLL.GetTickets().Where(elem => elem.UserId == id).ToList();
            foreach (var ticket in tickets)
            {
                var seat = _eventSeatBLL.GetEventSeat(ticket.EventSeatId).Result;
                var area = _eventAreaBLL.GetEventArea(seat.EventAreaId).Result;
                var eventElem = _eventBLL.GetEvent(area.EventId).Result;
                ticketInfoViewModels.Add(new TicketInfoViewModel()
                {
                    EndDate = eventElem.EndDate,
                    AreaDescr = area.Description,
                    StartDate = eventElem.StartDate,
                    EventName = eventElem.Name,
                    Number = seat.Number,
                    Row = seat.Row
                });
            }
            return ticketInfoViewModels;
        }
    }
}
