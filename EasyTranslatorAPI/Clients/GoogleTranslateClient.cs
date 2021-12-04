using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace EasyTranslatorAPI.Clients
{
    public class GoogleTranslateClient:ITranslateClient
    {
        private string baseUrl = "https://clients5.google.com/translate_a/";


        public async Task<string> TranslateAsync (string sourceLanguage, string targetLanguage, string text)
        {
            var translation = "";

            var urlAction = "t?client=dict-chrome-ex&sl=" + sourceLanguage + "&tl=" + targetLanguage + "&q=" + HttpUtility.UrlEncode(text);
            using (var client=new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method
                HttpResponseMessage response = await client.GetAsync(urlAction);
                if (response.IsSuccessStatusCode)
                {
                    GoogleTranslateResponse googleTranslateResponse = await JsonSerializer.DeserializeAsync<GoogleTranslateResponse>(await response.Content.ReadAsStreamAsync()); ;
                    translation = googleTranslateResponse.sentences[0].trans;
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }

            }

            return translation;
        }



    }
}
