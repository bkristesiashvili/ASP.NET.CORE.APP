using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ProMS.CORE.Data;
using ProMS.CORE.Extensions;
using ProMS.CORE.Models.User;
using ProMS.CORE.Repository.Login;
using ProMS.CORE.Services.Languages;

namespace ProMS.CORE.Pages
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        private readonly ILogger<ProfileModel> _logger;
        private readonly LoginRepository _loginRepository;

        public IReadOnlyDictionary<string, string> Translations { get; private set; }

        public string Root { get; private set; }

        public string PagePath { get; private set; }

        public UserModel SignedUser { get; private set; }

        public int ProjectCount { get; private set; }

        public ProfileModel(ILogger<ProfileModel> logger, PmsDbContext context)
        {
            _logger = logger;

            _loginRepository = new LoginRepository(context);

            SignedUser = new UserModel();

            ProjectCount = 0;

            PagePath = "/Dashboard";
        }

        public IActionResult OnGet()
        {
            Translations = HttpContext.InitializeLanguageService()[LanguageService.CurrentLanguage];

            Root = HttpContext.Request.GetRootUri(false, false).AbsoluteUri;

            if (User.Identity.IsAuthenticated)
            {
                _loginRepository.LoadCurrentUser(User.FindFirst(ClaimTypes.Sid).Value);
                SignedUser = _loginRepository.CurrentUser;

                if (SignedUser.Projects != null)
                    ProjectCount = SignedUser.Projects.Count;
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            Translations = HttpContext.InitializeLanguageService()[LanguageService.CurrentLanguage];

            Root = HttpContext.Request.GetRootUri(false, false).AbsoluteUri;

            return Page();
        }
    }
}