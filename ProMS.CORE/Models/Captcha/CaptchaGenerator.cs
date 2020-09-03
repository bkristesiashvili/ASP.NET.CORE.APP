using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProMS.CORE.Models.Captcha
{
    public class CaptchaGenerator
    {
        private const int MIN_SYMBOLS = 4;
        private const int MAX_SYMBOLS = 5;

        /// <summary>
        /// Gets captcha object
        /// </summary>
        public CaptchaModel Captcha { get; private set; }

        /// <summary>
        /// Creates captcha generator object
        /// </summary>
        public CaptchaGenerator() { }

        /// <summary>
        /// Generates new random captcha code
        /// </summary>
        public void GenerateNewCaptcha()
        {
            string Symbols = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            int len = RandomInt(MIN_SYMBOLS, MAX_SYMBOLS);

            StringBuilder captchaBuilder = new StringBuilder();

            for (int i = 0; i <= len; i++)
            {
                captchaBuilder.Append(Symbols[RandomInt(0, Symbols.Length)]);
            }

            using (Bitmap captchaImage = new Bitmap(150, 50))
            using (Graphics graphic = Graphics.FromImage(captchaImage))
            using (MemoryStream mstream = new MemoryStream())
            {
                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphic.SmoothingMode = SmoothingMode.HighQuality;
                graphic.CompositingQuality = CompositingQuality.HighQuality;

                graphic.Clear(Color.Transparent);

                int a = RandomInt(0, 190);
                int r = RandomInt(0, 230);
                int g = RandomInt(0, 230);
                int b = RandomInt(0, 230);

                Color start = Color.FromArgb(a, r, g, b);

                a = RandomInt(0, 190);
                r = RandomInt(0, 230);
                g = RandomInt(0, 230);
                b = RandomInt(0, 230);

                Color finish = Color.FromArgb(a, r, g, b);

                Rectangle imgRect = new Rectangle(0, 0, captchaImage.Width, captchaImage.Height);

                LinearGradientBrush lgBrush = new LinearGradientBrush(imgRect, start, finish, RandomAngle());

                HatchBrush hbrush = new HatchBrush(HatchStyle.LargeConfetti, Color.FromArgb(a, r, g, b));

                Font font = new Font("Sans", 20f);

                int n = RandomInt(10, 18);

                int x0 = 0, y0 = 0, x1 = 0, y1 = 0;

                for (int i = 0; i < n; i++)
                {
                    x0 = RandomInt(0, captchaImage.Width);
                    y0 = RandomInt(0, captchaImage.Height);
                    x1 = RandomInt(0, captchaImage.Width);
                    y1 = RandomInt(0, captchaImage.Height);

                    graphic.DrawLine(new Pen(hbrush), x0, y0, x1, y1);
                }

                int xCoord = (int)captchaImage.Width / 3 - 7;

                graphic.DrawString(captchaBuilder.ToString(), font, lgBrush, xCoord, 10);

                captchaImage.Save(mstream, ImageFormat.Png);

                Captcha = new CaptchaModel
                {
                    CaptchaCode = captchaBuilder.ToString(),
                    Data = mstream.ToArray()
                };

                graphic.Dispose();
                captchaImage.Dispose();
                mstream.Dispose();

                GC.SuppressFinalize(imgRect);
                GC.SuppressFinalize(captchaImage);
                GC.SuppressFinalize(graphic);
                GC.SuppressFinalize(lgBrush);
                GC.SuppressFinalize(hbrush);
                GC.SuppressFinalize(finish);
                GC.SuppressFinalize(start);
                GC.SuppressFinalize(mstream);
                GC.Collect();



            }
        }

        /// <summary>
        /// Generates random integer number
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private int RandomInt(int min = 0, int max = 0)
        {
            return new Random().Next(min, max);
        }

        /// <summary>
        /// Generates random Angle
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private float RandomAngle(int min = 0, int max = 360)
        {
            if (max > 360)
                max = max - 360;

            return (float)new Random().Next(min, max);
        }
    }
}
