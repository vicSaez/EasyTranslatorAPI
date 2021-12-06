namespace EasyTranslatorAPI.Dtos
{
    using System.Net;

    public class ClientResponse
    {
        public HttpStatusCode StatusCode { get; set; }

        public string ErrorText { get; set; }

        public string TranslatedText { get; set; }

        public bool IsTranslationSuccess { get; set; }
    }
}
