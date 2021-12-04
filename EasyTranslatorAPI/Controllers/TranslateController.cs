using EasyTranslatorAPI.Dtos;
using EasyTranslatorAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EasyTranslatorAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TranslateController : ControllerBase
    {
        private ITranslatorService _translatorService;

        public TranslateController(ITranslatorService translatorService)
        {
            _translatorService = translatorService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string sourceLanguage, string targetLanguage, string sourceText)
        {
            var translationResponse = await _translatorService.TranslateAsync(sourceLanguage,targetLanguage, sourceText);




            return Ok(translationResponse);

        }




    }
}
