using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyTranslatorAPI
{
    public class TranslationResponse
    {
        public string TargetText { get; set; }

        public string TargetLanguage { get; set; }

        public string SourceLanguage { get; set; }
    }
}
