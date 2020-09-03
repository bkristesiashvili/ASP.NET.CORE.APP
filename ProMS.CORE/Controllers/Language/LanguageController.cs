using ProMS.CORE.Services.Languages;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProMS.CORE.Controllers.Language
{
    [Route("lang")]
    public sealed class LanguageController : Controller
    {
        /// <summary>
        /// Creates language controller object
        /// </summary>
        /// <param name="langService"></param>
        public LanguageController()
        {
        }

        /// <summary>
        /// Changes language of the page
        /// </summary>
        /// <param name="langId"></param>
        /// <returns></returns>
        [HttpGet("{langid}")]
        public IActionResult Change(string langId)
        {
            HttpContext.ChangeLanguage(langId);

            return Redirect(LanguageService.CurrentPage);
        }
    }
}
