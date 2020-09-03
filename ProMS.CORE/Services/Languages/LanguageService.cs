using Microsoft.AspNetCore.Http;
using ProMS.CORE.Models.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProMS.CORE.Services.Languages
{
    public static class LanguageService 
    {
        private static HttpContext httpContext;

        private static PageLanguageModel _available_langs;


        /// <summary>
        /// Gets current language
        /// </summary>
        public static string CurrentLanguage
        {
            private set
            {
                if (httpContext == null)
                    throw new ArgumentNullException(nameof(httpContext));

                httpContext.Session.SetString("lang", value);
            }
            get => httpContext.Session.GetString("lang");
        }

        /// <summary>
        /// Gets users current page
        /// </summary>
        public static string CurrentPage
        {
            private set
            {
                if (httpContext == null)
                    throw new ArgumentNullException(nameof(httpContext));

                httpContext.Session.SetString("page", value);
            }
            get => httpContext.Session.GetString("page");
        }


        /// <summary>
        /// Initializes language service
        /// </summary>
        /// <param name="context"></param>
        public static PageLanguageModel InitializeLanguageService(this HttpContext context)
        {
            httpContext = context;

            _available_langs = new PageLanguageModel();

            if (string.IsNullOrEmpty(CurrentLanguage))
                CurrentLanguage = _available_langs.Languages[0];

            CurrentPage = context.Request.Path;

            return _available_langs;
        }

        /// <summary>
        /// Changes language of the page
        /// </summary>
        /// <param name="lang"></param>
        /// <param name="context"></param>
        public static void ChangeLanguage(this HttpContext context, string lang)
        {
            httpContext = context ?? throw new ArgumentNullException(nameof(context));

            if (!_available_langs.Languages.Contains(lang))
                return;

            CurrentLanguage = lang;
        }
    }
}
