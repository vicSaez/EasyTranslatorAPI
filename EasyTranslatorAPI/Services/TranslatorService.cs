namespace EasyTranslatorAPI.Services
{
    using System.Threading.Tasks;
    using EasyTranslatorAPI.Clients;
    using EasyTranslatorAPI.Dtos;
    using Microsoft.Extensions.Options;

    internal sealed class TranslatorService : ITranslatorService
    {
        private readonly ITranslateClient remoteTranslateClient;
        private readonly IOptions<EasyTranslatorConfig> easyTranslatorConfig;

        public TranslatorService(ITranslateClient remoteTranslateClient, IOptions<EasyTranslatorConfig> easyTranslatorConfig)
        {
            this.remoteTranslateClient = remoteTranslateClient;
            this.easyTranslatorConfig = easyTranslatorConfig;
        }

        public async Task<TranslationResponse> TranslateAsync(string sourceLanguage, string targetLanguage, string sourceText)
        {
            var clientResponse = await remoteTranslateClient.TranslateAsync(sourceLanguage, targetLanguage, sourceText);

            return new TranslationResponse()
            {
                TranslationStatus = clientResponse.StatusCode,
                SourceLanguage = sourceLanguage,
                TargetLanguage = targetLanguage,
                TargetText = clientResponse.IsTranslationSuccess ? clientResponse.TranslatedText : string.Empty,
                TranslationSuccess = clientResponse.IsTranslationSuccess,
                TranslationErrorText = clientResponse.IsTranslationSuccess ? string.Empty : clientResponse.ErrorText,
            };
        }
    }
}
