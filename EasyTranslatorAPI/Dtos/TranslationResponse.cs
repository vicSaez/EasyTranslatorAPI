namespace EasyTranslatorAPI.Dtos
{
    using System.Net;

    public class TranslationResponse
    {
        public string TargetText { get; set; }

        public string TargetLanguage { get; set; }

        public string SourceLanguage { get; set; }

        public bool TranslationSuccess { get; set; }

        public HttpStatusCode TranslationStatus { get; set; }

        public string TranslationErrorText { get; set; }
    }
}
