using EasyTranslatorAPI.Clients;
using EasyTranslatorAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyTranslatorAPI.Services
{
    public class TranslatorService:ITranslatorService
    {
        private ITranslateClient _remoteTranslateClient;

        public TranslatorService(ITranslateClient remoteTranslateClient)
        {
            _remoteTranslateClient = remoteTranslateClient;
        }
        public string CheckService()
        { 
            if (_remoteTranslateClient != null)
            {
                return "Service Ok";
            }
            return "Service KO";
            
        }

        public async Task<string> TranslateTestSentence()
        {
            return await _remoteTranslateClient.TranslateAsync("auto", "en", "buenos días");
        }

        public async Task<TranslationResponse> TranslateAsync(string sourceLanguage, string targetLanguage, string sourceText)
        {
            return new TranslationResponse()
            {
                SourceLanguage = sourceLanguage,
                TargetLanguage = targetLanguage,
                TargetText = await _remoteTranslateClient.TranslateAsync(sourceLanguage, targetLanguage, sourceText)
            };
        }
    }
}
