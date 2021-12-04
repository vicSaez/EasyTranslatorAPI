using EasyTranslatorAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyTranslatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private ITranslatorService _translatorService;

        public TestController (ITranslatorService translatorService)
        {
            _translatorService = translatorService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var translation = new TranslationResponse() { TargetText="Target Text", SourceLanguage ="Source Language", TargetLanguage ="TargetLanguage" };

        



        
            translation.TargetText = await _translatorService.TranslateTestSentence();

            return Ok(translation);
        }
    }
}
