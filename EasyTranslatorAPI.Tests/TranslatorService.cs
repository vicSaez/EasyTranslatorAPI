using EasyTranslatorAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace EasyTranslatorAPI.Tests
{
    public class TranslatorService
    {
        private readonly TranslateController _translateController;
        private Mock<TranslationResponse> _mockTranslationResponse;

        public TranslatorService()
        {
            _mockTranslationResponse = new Mock<TranslationResponse>();
            _translateController = new TranslateController(_mockTranslationResponse.Object);
        }

        [Fact]
        public void GetTest_ReturnsTranslationResponse()
        {

            // arrange

            var mockTranslationResponse = new TranslationResponse() { SourceLanguage="es", TargetLanguage="en", TargetText="It Works!" };

            _mockTranslationResponse.Object.SourceLanguage = "es";
            _mockTranslationResponse.Object.TargetLanguage = "en";
            _mockTranslationResponse.Object.TargetText = "It Works!";



            //act
            var result = _translateController.Get();

            //assert
            var model = Assert.IsAssignableFrom<ActionResult<TranslationResponse>>(result);

        }
    }
}
