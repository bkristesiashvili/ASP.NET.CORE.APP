using Microsoft.AspNetCore.Http;
using ProMS.CORE.Models.Captcha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProMS.CORE.Services.Captcha
{
    public static class CaptchaService 
    {
        private static HttpContext httpContext;

        private static CaptchaGenerator _generator;


        private static string CaptchaCode
        {
            set
            {
                if (httpContext == null)
                    throw new ArgumentNullException(nameof(httpContext));

                httpContext.Session.SetString("captcha", value);
            }
            get => httpContext.Session.GetString("captcha");
        }

        public static CaptchaModel InitializeCaptchaService(this HttpContext context)
        {
            try
            {
                httpContext = context ?? throw new ArgumentNullException(nameof(context));

                _generator = new CaptchaGenerator();
                _generator.GenerateNewCaptcha();

                CaptchaCode = _generator.Captcha.CaptchaCode;

                return _generator.Captcha;
            }
            catch
            {
                return null;
            }
        }

        public static bool ValidateCaptcha(this HttpContext context, string userCaptcha)
        {
            try
            {
                httpContext = context ?? throw new ArgumentNullException(nameof(context));

                bool flag = userCaptcha == CaptchaCode;

                if (flag)
                    context.Session.Remove("captcha");

                return flag;
            }
            catch
            {
                return false;
            }
        }
    }
}
