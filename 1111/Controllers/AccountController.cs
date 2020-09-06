using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _1111.Models;
using Microsoft.AspNetCore.Identity;
using Domain.Core.Entities;
using _1111.ViewModels;

namespace _1111.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser { Email = model.Email, UserName = model.Email, Year = model.Year };
                /*
                { 
                Picture = "data:image/jpeg;base64,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",
                RegistrationDate = (1976, 1, 1),
                Year = 1976
                    };
            */
        // ��������� ������������
        var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // ��������� ����
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
    }
}