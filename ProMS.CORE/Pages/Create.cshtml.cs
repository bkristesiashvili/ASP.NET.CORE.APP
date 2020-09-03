using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ProMS.CORE.Extensions;
using ProMS.CORE.Services.Languages;

namespace ProMS.CORE.Pages
{
    [Authorize(Roles ="Admin, Manager")]
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> _logger;

        public IReadOnlyDictionary<string, string> Translations { get; private set; }

        public string Root { get; private set; }

        public string PagePath { get; private set; }

        public CreateModel(ILogger<CreateModel> logger)
        {
            _logger = logger;

            PagePath = "/Dashboard";
        }
        public void OnGet()
        {
            Translations = HttpContext.InitializeLanguageService()[LanguageService.CurrentLanguage];

            Root = HttpContext.Request.GetRootUri(false, false).AbsoluteUri;
        }

        public IActionResult OnPostAsync()
        {
            Translations = HttpContext.InitializeLanguageService()[LanguageService.CurrentLanguage];

            Root = HttpContext.Request.GetRootUri(false, false).AbsoluteUri;

            return Page();
        }
    }
}