namespace EasyTranslatorAPI.Clients
{
    using System.Threading.Tasks;

    public interface ITranslateClient
    {
        public Task<string> TranslateAsync(string sourceLanguage, string targetLanguage, string text);
    }
}
