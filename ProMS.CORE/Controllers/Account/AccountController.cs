using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProMS.CORE.Data;
using ProMS.CORE.Models.LoginView;
using ProMS.CORE.Models.User;
using ProMS.CORE.Repository.Login;
using ProMS.CORE.Services.Captcha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProMS.CORE.Controllers.Account
{
    [Route("Users")]
    public sealed class AccountController: Controller
    {
        private readonly ILogger<AccountController> _logger;

        private readonly LoginRepository _loginRepository;

        private readonly double MAX_AGE = 5.0d;

        /// <summary>
        /// Creates account controller object 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="captchasvc"></param>
        public AccountController(ILogger<AccountController> logger, PmsDbContext context)
        {
            _logger = logger;

            _loginRepository = new LoginRepository(context);
        }

        /// <summary>
        /// Handles login action to the web
        /// </summary>
        /// <param name="captcha"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public IActionResult Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
                return RedirectToPage("/login", new { attempt = false });

            if(!HttpContext.ValidateCaptcha(loginModel.Captcha))
                return RedirectToPage("/login", new { attempt = false });

            bool loginSuccess = _loginRepository.Login(loginModel.Username, loginModel.Password);

            if (!loginSuccess)
                return RedirectToPage("/login", new { attempt = false });

            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, _loginRepository.CurrentUser.Username));
            claims.Add(new Claim(ClaimTypes.Email, _loginRepository.CurrentUser.Email));
            claims.Add(new Claim(ClaimTypes.Role, _loginRepository.CurrentUser.RoleMember));
            claims.Add(new Claim(ClaimTypes.DateOfBirth, _loginRepository.CurrentUser.DoB));
            claims.Add(new Claim(ClaimTypes.Sid, _loginRepository.CurrentUser.Id.ToString()));

            var identity = new ClaimsIdentity(claims
                            , CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);

            var principal = new ClaimsPrincipal(identity);

            DateTime maxage = DateTime.UtcNow.AddMinutes(30);

            if (loginModel.RememberMe)
                maxage = DateTime.UtcNow.AddDays(MAX_AGE);

            HttpContext.SignInAsync(principal, new AuthenticationProperties
            {
                IsPersistent = loginModel.RememberMe,
                ExpiresUtc = maxage
            });

            return Redirect("~/Dashboard");
        }

        /// <summary>
        /// Redirect to login page
        /// </summary>
        /// <returns></returns>
        [HttpPost("secure")]
        [Authorize]
        public IActionResult SecureDashboard()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("~/Login");
        }
    }
}
