using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProMS.CORE.Models.Languages
{
    public sealed class PageLanguageModel
    {
        private readonly IDictionary<string, IReadOnlyDictionary<string, string>> _Dictionary;

        /// <summary>
        /// Creates language model object
        /// </summary>
        public PageLanguageModel()
        {
            _Dictionary = new Dictionary<string, IReadOnlyDictionary<string, string>>();

            _Dictionary.Add("ge", InitializeLanguages("geo.json"));
            _Dictionary.Add("en", InitializeLanguages("eng.json"));
            _Dictionary.Add("ru", InitializeLanguages("rus.json"));

        }

        /// <summary>
        /// Read translations from lang files
        /// </summary>
        /// <param name="langfile"></param>
        /// <returns></returns>
        private IReadOnlyDictionary<string, string> InitializeLanguages(string langfile)
        {
            string pathdir = Directory.GetCurrentDirectory() + "\\langs\\" + langfile;

            IReadOnlyDictionary<string, string> result;

            using (StreamReader fileGeo = new StreamReader(File.OpenRead(pathdir)))
            {
                string data = fileGeo.ReadToEnd();

                result = JsonSerializer.Deserialize<IReadOnlyDictionary<string, string>>(data, new JsonSerializerOptions());
            }

            return result;
        }

        /// <summary>
        /// Gets all available languages
        /// </summary>
        public IReadOnlyList<string> Languages => _Dictionary.Keys.ToList();

        /// <summary>
        /// Gets current language translations
        /// </summary>
        /// <param name="key">language name</param>
        /// <returns>available translations</returns>
        public IReadOnlyDictionary<string, string> this[string key] => _Dictionary[key];
    }
}
