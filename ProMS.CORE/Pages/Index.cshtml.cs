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
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IReadOnlyDictionary<string,string> Translations { get; private set; }

        public string Root { get; private set; }

        public string PagePath { get; private set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;

            PagePath = "\\";
        }

        public IActionResult OnGet()
        {
            Translations = HttpContext.InitializeLanguageService()[LanguageService.CurrentLanguage];

            Root = HttpContext.Request.GetRootUri(false, false).AbsoluteUri;

            if (User.Identity.IsAuthenticated)
                return Redirect("~/Dashboard");

            return Page();
        }
    }
}
