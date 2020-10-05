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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Net.Mail;
using System.IO;

namespace _1111.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _env;
        //дл€ проверки на файла на картинку
        private List<string> allowedExtensions = new List<string> { ".gif", ".png", ".jpg", ".jpeg", ".bmp" };

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IUserService userService, IWebHostEnvironment webHost)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
            _env = webHost;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _userService.GetAllUsersAsync());
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model, IFormFile image)
        {

            if (allowedExtensions.FirstOrDefault(c => c == Path.GetExtension(image.FileName)) == null)
            {
                ModelState.AddModelError("ExtensionError", "Extension error");
            }
            AppUser userCheckName = await _userManager.FindByEmailAsync(model.Email);
            if (userCheckName != null)
            {
                if (model.Email == userCheckName.Email)
                {
                    ModelState.AddModelError("EmailError", "Email error");
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    Directory.CreateDirectory(Path.Combine(_env.WebRootPath, "uploads"));

                    //загружаем картинку
                    string path = $@"uploads\{model.Image.FileName}";
                    string uploadPath = Path.Combine(_env.WebRootPath, path);

                    using (var stream = new FileStream(uploadPath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }


                    // добавл€ем пользовател€
                    AppUser user = new AppUser
                    {
                        Email = model.Email,
                        UserName = model.Email,
                        Birthday = model.Birthday,
                        RegistrationDate = DateTime.Now,
                        SecurityStamp = Guid.NewGuid().ToString()

                    };


                    {
                        await _userService.CreateUserAsync(user);


                        //иначе не работает
                        Picture pic1 = new Picture { Name = model.Image.FileName, Extension = Path.GetExtension(model.Image.FileName), Author = model.Email, Path = path, User = user };
                        user.Pictures.Add(pic1);
                        await _userService.UpdateUserAsync(user);


                        // установка куки
                        await _signInManager.SignInAsync(user, false);
                        return RedirectToAction("Index", "Home");
                    }
                    // else
                    {
                        //foreach (var error in result.Errors)
                        {
                            //   ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmEmail(int id)
        {

            if (id != null)
            {
                AppUser user = await _userService.GetUser(id);

                MailAddress from = new MailAddress("somemail@yandex.ru", "Registration on zxc");
                MailAddress to = new MailAddress(user.Email);

                // создаем объект сообщени€
                MailMessage msg = new MailMessage(from, to);

                // тема письма
                msg.Subject = "Email подтверждение";
                // текст письма - включаем в него ссылку
                msg.Body = string.Format("ƒл€ завершени€ регистрации перейдите по ссылке:" +
                                "<a href=\"{0}\" title=\"ѕодтвердить регистрацию\">{0}</a>",
                    Url.Action("ConfirmEmail", "Account", new { Token = user.Id, Email = user.Email }, Request.Scheme));
                msg.IsBodyHtml = true;
                // адрес smtp-сервера, с которого мы и будем отправл€ть письмо
                SmtpClient smtp = new SmtpClient//("smtp.yandex.ru", 25);
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    // логин и пароль
                    Credentials = new System.Net.NetworkCredential("of.zxc.of@gmail.com", "QWE123q1`")
                };

                smtp.Send(msg);
            }
            return NotFound();
        }

        [AllowAnonymous]
        public string Confirm(string Email)
        {
            return "Ќа почтовый адрес " + Email + " ¬ам высланы дальнейшие" +
                    "инструкции по завершению регистрации";
        }

        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string Token, string Email)
        {
            AppUser user = await _userManager.FindByEmailAsync(Email);
            //если пользователь с таким email зарегестрирован
            if (user != null)
            {

                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Home", new { ConfirmedEmail = user.Email });
            }
            else
            {
                return RedirectToAction("Confirm", "Account", new { Email = "" });
            }
        }


        // public async Task<ActionResult> GetImage(int id)
        //  {

        //   var image = await _userService.GetUser(id);

        //}
    }
}