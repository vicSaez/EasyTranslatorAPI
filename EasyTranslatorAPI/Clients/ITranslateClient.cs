using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyTranslatorAPI.Clients
{
    public interface ITranslateClient
    {
        public Task<string> TranslateAsync(string sourceLanguage, string targetLanguage, string text);
    }
}
