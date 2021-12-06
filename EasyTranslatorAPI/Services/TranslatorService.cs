namespace EasyTranslatorAPI.Services
{
    using System.Threading.Tasks;
    using EasyTranslatorAPI.Clients;
    using EasyTranslatorAPI.Dtos;

    internal sealed class TranslatorService : ITranslatorService
    {
        private readonly ITranslateClient remoteTranslateClient;

        public TranslatorService(ITranslateClient remoteTranslateClient)
        {
            this.remoteTranslateClient = remoteTranslateClient;
        }

        public async Task<TranslationResponse> TranslateAsync(string sourceLanguage, string targetLanguage, string sourceText)
        {
            return new TranslationResponse()
            {
                SourceLanguage = sourceLanguage,
                TargetLanguage = targetLanguage,
                TargetText = await remoteTranslateClient.TranslateAsync(sourceLanguage, targetLanguage, sourceText),
            };
        }
    }
}
