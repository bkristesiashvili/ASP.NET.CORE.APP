using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ProMS.CORE.Data;
using ProMS.CORE.Extensions;
using ProMS.CORE.Repository.Login;
using ProMS.CORE.Services.Languages;

namespace ProMS.CORE.Pages
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;

        private readonly LoginRepository _loginRepository;

        public IReadOnlyDictionary<string, string> Translations { get; private set; }

        public string Root { get; private set; }

        public string PagePath { get; private set; }

        public string Message { get; private set; }

        [BindProperty(Name = "attempt", SupportsGet = true)]
        public bool AttemptTry { get; set; }

        public LoginModel(ILogger<LoginModel> logger, PmsDbContext context)
        {
            _logger = logger;

            PagePath = "\\";

            AttemptTry = true;

            _loginRepository = new LoginRepository(context);
        }

        public IActionResult OnGet()
        {
            Translations = HttpContext.InitializeLanguageService()[LanguageService.CurrentLanguage];

            Root = HttpContext.Request.GetRootUri(false, false).AbsoluteUri;

            if (User.Identity.IsAuthenticated)
                return Redirect("~/Dashboard");

            bool flag;

            if (!bool.TryParse(AttemptTry.ToString(), out flag) || !AttemptTry)
                Message = Translations["Error-Message"];

            return Page();
        }
    }
}