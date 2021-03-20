using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.WebApi.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Обовязкове поле"), EmailAddress(ErrorMessage ="Не валідна пошта")]
        public string Email { get; set; }

        //[RegularExpression(pattern: "", ErrorMessage = "")]
        [Required(ErrorMessage = "Обовязкове поле")]
        public string Password { get; set; }
    }
}
