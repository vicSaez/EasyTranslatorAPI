namespace EasyTranslatorAPI.Services
{
    using System.Threading.Tasks;
    using EasyTranslatorAPI.Dtos;

    public interface ITranslatorService
    {
        public Task<TranslationResponse> TranslateAsync(string sourceLanguage, string targetLanguage, string sourceText);
    }
}
