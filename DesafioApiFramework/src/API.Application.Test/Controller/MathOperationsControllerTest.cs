using Moq;
using Xunit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using API.Application.Controllers;
using API.Application.Service.Abstractions;

namespace API.Application.Test.Controller
{
    public class MathOperationsControllerTest
    {
        private Mock<IMathOperationsService> _mathOperationsService;
        private MathOperationsController _mathOperationsController;
        public MathOperationsControllerTest()
        {
            _mathOperationsService = new Mock<IMathOperationsService>();
            _mathOperationsController = new MathOperationsController(_mathOperationsService.Object);
        }

        [Fact]
        public async Task WhenTheNumberIsInformed_ItShouldRespondWithOK()
        {
            _mathOperationsService.Setup(config => config.Get(It.IsAny<int>())).ReturnsAsync(new DTO.OperationsResponseDTO
            {
                Divisors = new List<int> { 1, 5 },
                Primes = new List<int> { 5 }
            });
            var verifyNumber = 5;
            var controllerGetMethodResult = await _mathOperationsController.Get(verifyNumber);
            Assert.True(controllerGetMethodResult is OkObjectResult);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public async Task WhenANegativeNumberOrZero_AndANumberBiggerThanTheLimitOfInt32IsInformed_ItShouldRespondWithBadRequest(int number)
        {
            var controllerResponse = await _mathOperationsController.Get(number);
            Assert.IsType<BadRequestObjectResult>(controllerResponse);
        }
    }
}
