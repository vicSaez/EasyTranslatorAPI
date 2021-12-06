namespace EasyTranslatorAPI.Clients
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text.Json;
    using System.Threading.Tasks;
    using System.Web;
    using EasyTranslatorAPI.Dtos;
    using Microsoft.Extensions.Options;

    internal sealed class GoogleTranslateClient : ITranslateClient
    {
        private readonly IOptions<EasyTranslatorConfig> easyTranslatorConfig;
        private readonly HttpClient httpClient;

        public GoogleTranslateClient(IOptions<EasyTranslatorConfig> easyTranslatorConfig)
        {
            this.easyTranslatorConfig = easyTranslatorConfig;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(easyTranslatorConfig.Value.GoogleTranslateBaseUrl),
            };
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ClientResponse> TranslateAsync(string sourceLanguage, string targetLanguage, string text)
        {
            var clientResponse = new ClientResponse();

            var urlAction = $"t?client=dict-chrome-ex&sl={sourceLanguage}&tl={targetLanguage}&q={HttpUtility.UrlEncode(text)}";
            HttpResponseMessage response = await httpClient.GetAsync(urlAction);
            clientResponse.StatusCode = response.StatusCode;
            clientResponse.IsTranslationSuccess = response.IsSuccessStatusCode;
            if (response.IsSuccessStatusCode)
            {
                var googleTranslateResponse =
                    await JsonSerializer.DeserializeAsync<GoogleTranslateResponse>(await response.Content.ReadAsStreamAsync());
                clientResponse.TranslatedText = googleTranslateResponse.sentences[0].trans;
            }
            else
            {
                clientResponse.ErrorText = "Google Translate Response was not 200 OK.";
            }

            return clientResponse;
        }
    }
}
