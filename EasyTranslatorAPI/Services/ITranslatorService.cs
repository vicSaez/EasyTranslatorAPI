using EasyTranslatorAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyTranslatorAPI.Services
{
    public interface ITranslatorService
    {
        string CheckService();

        public Task<string> TranslateTestSentence();

        public Task<TranslationResponse> TranslateAsync(string sourceLanguage, string targetLanguage, string sourceText);
    }
}
