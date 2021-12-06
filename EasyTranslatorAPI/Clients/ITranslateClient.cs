namespace EasyTranslatorAPI.Clients
{
    using EasyTranslatorAPI.Dtos;
    using System.Threading.Tasks;

    public interface ITranslateClient
    {
        public Task<ClientResponse> TranslateAsync(string sourceLanguage, string targetLanguage, string text);
    }
}
