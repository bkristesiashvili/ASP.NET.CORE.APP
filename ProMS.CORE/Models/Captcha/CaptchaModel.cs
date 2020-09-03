using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProMS.CORE.Models.Captcha
{
    public sealed class CaptchaModel
    {
        /// <summary>
        /// Gets Sets captcha code
        /// </summary>
        public string CaptchaCode { get; set; }

        /// <summary>
        /// Gets Sets captcha data bytes
        /// </summary>
        public byte[] Data { get; set; }

        /// <summary>
        /// Gets captcha encoded data
        /// </summary>
        public string Encoded => Convert.ToBase64String(Data);
    }
}
