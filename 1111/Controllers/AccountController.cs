using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using _1111.Models.ViewModels;
using Domain.Core.Entities;
using Infrastructure.Data.Entity_Framework.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _1111.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private List<string> AllowedExtensions = new List<string> { ".gif", ".png", ".jpg", ".jpeg", ".bmp" };
        private readonly IWebHostEnvironment _env;
        private readonly PictureRepositoryAsync _repository;
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
        public async Task<IActionResult> Register(RegisterViewModel model, Picture picture, IFormFile image)
        {
            if (AllowedExtensions.FirstOrDefault(c => c == Path.GetExtension(image.FileName)) == null)
            {
                ModelState.AddModelError("ExtensionError", "Extension error");
            }
            else
            {
              model.Picture = image.FileName;

                if (ModelState.IsValid)
                {
                    AppUser user = new AppUser
                    {
                        Email = model.Email,
                        UserName = model.Email,
                        Birthday = model.Birthday,
                        Picture = new Picture { Path = model.Picture, Extension = Path.GetExtension(model.Picture), Author = model.Email },
                        RegistrationDate = DateTime.Now
                    };

                    Directory.CreateDirectory(Path.Combine(_env.WebRootPath, "uploads"));

                    // добавляем пользователя
                    var result = await _userManager.CreateAsync(user, model.Password);
                    //загружаем картинку 
                    string path = $@"uploads\{picture.Name}{picture.Extension}";
                    string uploadPath = Path.Combine(_env.WebRootPath, path);

                    using (var stream = new FileStream(uploadPath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    picture.Path = path;
                    await _repository.CreateAsync(picture);
                    if (result.Succeeded)
                    {
                        // установка куки
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
            }
            return View(model);
        }
    }
}