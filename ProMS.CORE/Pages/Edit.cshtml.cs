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
    [Authorize(Roles = "Admin, Manager")]
    public class EditModel : PageModel
    {
        private readonly ILogger<EditModel> _logger;

        public IReadOnlyDictionary<string, string> Translations { get; private set; }

        public string Root { get; private set; }

        public string PagePath { get; private set; }

        public EditModel(ILogger<EditModel> logger)
        {
            _logger = logger;

            PagePath = "/Dashboard";
        }

        public IActionResult OnGet(int projectid)
        {
            Translations = HttpContext.InitializeLanguageService()[LanguageService.CurrentLanguage];

            Root = HttpContext.Request.GetRootUri(false, false).AbsoluteUri;

            return Page();
        }

        public IActionResult OnPostAsync(string projectFile)
        {
            Translations = HttpContext.InitializeLanguageService()[LanguageService.CurrentLanguage];

            Root = HttpContext.Request.GetRootUri(false, false).AbsoluteUri;

            return Page();
        }
    }
}