using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagement.Web.Models;
using TicketManagement.BLL;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace TicketManagement.Web.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private ITicketBLL _ticketBLL;

        public ClientController(ApplicationContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _ticketBLL = new TicketBLL(context);
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
                Tickets = _ticketBLL.GetUserTickets(user.Id)
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
                    ModelState.AddModelError(string.Empty, "Пользователь не найден");
                }
            }
            return View(view);
        }
    }
}
