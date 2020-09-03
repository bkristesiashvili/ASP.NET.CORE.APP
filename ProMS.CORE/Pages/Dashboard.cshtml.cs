using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ProMS.CORE.Extensions;
using ProMS.CORE.Services.Languages;

namespace ProMS.CORE.Pages
{
    [Authorize]
    public class DashboardModel : PageModel
    {
        private readonly ILogger<DashboardModel> _logger;

        public IReadOnlyDictionary<string, string> Translations { get; private set; }

        public string Root { get; private set; }

        public string PagePath { get; private set; }

        public DashboardModel(ILogger<DashboardModel> loger)
        {
            _logger = loger;

            PagePath = "/Dashboard";
        }

        public void OnGet()
        {
            Translations = HttpContext.InitializeLanguageService()[LanguageService.CurrentLanguage];

            Root = HttpContext.Request.GetRootUri(false, false).AbsoluteUri;

            var text = User.FindFirst(ClaimTypes.Name).Value;
        }

        public async Task<IActionResult> OnPostAsync(string Search)
        {
            Translations = HttpContext.InitializeLanguageService()[LanguageService.CurrentLanguage];

            Root = HttpContext.Request.GetRootUri(false, false).AbsoluteUri;

            await Task.FromResult(Search);

            return Page();
        }
    }
}