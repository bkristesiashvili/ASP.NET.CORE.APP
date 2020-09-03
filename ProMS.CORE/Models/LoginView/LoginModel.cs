using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProMS.CORE.Models.LoginView
{
    public sealed class LoginModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [MaxLength(5)]
        [DataType(DataType.Text)]
        [StringLength(5)]
        [Display(Name = "Captcha")]
        public string Captcha { get; set; }

        [Display(Name = "RememberMe")]
        public bool RememberMe { get; set; }
    }
}
