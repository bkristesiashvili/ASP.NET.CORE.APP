using ProMS.CORE.Services.Captcha;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProMS.CORE.Controllers
{
    [Route("captcha")]
    public sealed class CaptchaController : Controller
    {
        /// <summary>
        /// Creates captcha controller object
        /// </summary>
        /// <param name="captchasvc"></param>
        public CaptchaController()
        {
        }

        /// <summary>
        /// Generates new captcha image
        /// </summary>
        /// <returns></returns>
        [HttpGet("img")]
        public IActionResult GetCaptchaImage()
        {
            var data = HttpContext.InitializeCaptchaService().Data;

            MemoryStream mstream = new MemoryStream(data);

            return File(mstream.ToArray(), "image/png");
        }
    }
}
