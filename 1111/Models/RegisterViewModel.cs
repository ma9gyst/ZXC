using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace _1111.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Дата рождения")]
        public DateTime Birthday { get; set; }


        [Required(ErrorMessage = "Please choose profile image")]
        [Display(Name = "Картинка")]
        public IFormFile Image { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }

        public bool HasImage()
        {
            return !String.IsNullOrWhiteSpace(Image.FileName);
        }

    }
}