﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManagement.Web.Models;

namespace TicketManagement.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterView model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email, UserName = model.Email, Balance = 0, FirstName = model.FirstName, Surname = model.Surname, Language = model.Language };
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                if (!await _roleManager.RoleExistsAsync(model.UserRole))
                {
                    await _roleManager.CreateAsync(new IdentityRole(model.UserRole));
                }
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.UserRole);
                    // установка куки
                    await _signInManager.SignInAsync(user, false);
                    return Json(new { success = true, url = Url.Action("Index", "Home")});
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return PartialView(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginView model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return Json(new { success = true, url = Url.Action("Index", "Home") });
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}