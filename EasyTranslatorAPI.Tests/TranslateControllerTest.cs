using EasyTranslatorAPI.Controllers;
using EasyTranslatorAPI.Dtos;
using EasyTranslatorAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EasyTranslatorAPI.Tests
{
    public class TranslateControllerTest
    {
        private readonly TranslateController _translateController;
        //private Mock<TranslationResponse> _mockTranslationResponse;
        private Mock<ITranslatorService> _mockTranslatorService;

        public TranslateControllerTest()
        {
            _mockTranslatorService = new Mock<ITranslatorService>();
            _translateController = new TranslateController(_mockTranslatorService.Object);
        }



        [Fact]
        public async void GetTest_ReturnsOKResultResponse()
        {
            //arrange
            _mockTranslatorService.Setup(m => m.TranslateAsync("es", "en", "Funciona!")).ReturnsAsync(new TranslationResponse() { SourceLanguage = "es", TargetLanguage = "en", TargetText = "It Works!" });

            //act
            var result = await _translateController.Get("es", "en", "Funciona!");

            //assert

            var model = Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }



        [Fact]
        public async void GetTest_ReturnsTranslationResponse()
        {

            //arrange
            _mockTranslatorService.Setup(m => m.TranslateAsync("es", "en", "Funciona!")).ReturnsAsync(new TranslationResponse(){ SourceLanguage ="es", TargetLanguage="en", TargetText= "It Works!" });

            //act
            var okResult = await _translateController.Get("es","en","Funciona!") as OkObjectResult;

            //assert
            var model = Assert.IsAssignableFrom<TranslationResponse>(okResult.Value);

        }
    }
}
