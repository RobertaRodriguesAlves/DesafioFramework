using Xunit;
using API.Application.DTO;
using System.Threading.Tasks;
using API.Application.Service;
using System.Collections.Generic;

namespace API.Application.Test.Service
{
    public class MathOperationsServiceTest
    {
        private MathOperationsService _mathOperationsService;
        public MathOperationsServiceTest()
        {
            _mathOperationsService = new MathOperationsService();
        }

        private byte _verifyNumber = 0;

        [Fact]
        public async Task ShouldGetAllDivisorsAndPrimes_WhenTheNumber45IsInformed()
        {
            var divisors = new List<int>() { 1, 3, 5, 9, 15, 45 };
            var primes = new List<int>() { 3, 5 };
               
            _verifyNumber = 45;
            OperationsResponseDTO response = await _mathOperationsService.Get(_verifyNumber);

            Assert.Equal(divisors, response.Divisors);
            Assert.Equal(primes, response.Primes);            
        }

        [Fact]
        public async Task ShouldGetAllDivisorsAndPrimes_WhenTheNumber2IsInformed()
        {
            var divisors = new List<int>() { 1, 2 };
            var primes = new List<int>() { 2 };

            _verifyNumber = 2;
            OperationsResponseDTO response = await _mathOperationsService.Get(_verifyNumber);

            Assert.Equal(divisors, response.Divisors);
            Assert.Equal(primes, response.Primes);
        }
    }
}
