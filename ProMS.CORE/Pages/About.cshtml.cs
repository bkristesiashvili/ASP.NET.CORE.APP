using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ProMS.CORE.Extensions;
using ProMS.CORE.Services.Languages;

namespace ProMS.CORE.Pages
{
    public class AboutModel : PageModel
    {
        private readonly ILogger<AboutModel> _logger;

        public IReadOnlyDictionary<string, string> Translations { get; private set; }
        public string Root { get; private set; }

        public string PagePath { get; private set; }

        public AboutModel(ILogger<AboutModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Translations = HttpContext.InitializeLanguageService()[LanguageService.CurrentLanguage];

            Root = HttpContext.Request.GetRootUri(false, false).AbsoluteUri;

            if (User.Identity.IsAuthenticated)
                PagePath = "/Dashboard";
            else
                PagePath = "\\";
        }
    }
}
