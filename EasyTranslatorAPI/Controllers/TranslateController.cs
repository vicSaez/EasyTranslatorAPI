namespace EasyTranslatorAPI.Controllers
{
    using System.Threading.Tasks;
    using EasyTranslatorAPI.Services;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/v1/[controller]")]
    [ApiController]
    public class TranslateController : ControllerBase
    {
        private ITranslatorService translatorService;

        public TranslateController(ITranslatorService translatorService)
        {
            this.translatorService = translatorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(string sourceLanguage, string targetLanguage, string sourceText)
        {
            var translationResponse = await translatorService.TranslateAsync(sourceLanguage, targetLanguage, sourceText);
            return Ok(translationResponse);
        }
    }
}
