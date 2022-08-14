using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureCognitive
{
    internal class DTOs
    {
    }

    public class Language
    {
        public string name { get; set; }
        public string nativeName { get; set; }
        public string dir { get; set; }
    }

    public class TranslationsResponse
    {
        public List<Translation> translations { get; set; }
    }

    public class Translation
    {
        public string text { get; set; }
        public string to { get; set; }
    }
}
