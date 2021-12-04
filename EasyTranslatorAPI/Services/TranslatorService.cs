using EasyTranslatorAPI.Clients;
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
    }
}
