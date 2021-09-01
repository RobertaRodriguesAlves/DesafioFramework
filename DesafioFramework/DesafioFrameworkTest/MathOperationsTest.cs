using DesafioFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DesafioFrameworkTest
{
    public class MathOperationsTest
    {
        private MathOperations _mathOperations;
        private byte _verifyNumber = 0;

        [Fact]
        public void ShouldGetAllDivisors_WhenThe45NumberIsInformed()
        {
            var divisors = new List<int>() { 1, 3, 5, 9, 15, 45 };
            _verifyNumber = 45;
            _mathOperations = new MathOperations(_verifyNumber);

            IEnumerable<int> response = _mathOperations.GetDivisors().OrderBy(divisors => divisors).Distinct();
            Assert.Equal(response, divisors);
        }

        [Fact]
        public void ShouldGetAllPrimes_WhenAListIsInformed()
        {
            var divisors = new List<int>() { 1, 3, 5, 9, 15, 45 };
            var primes = new List<int>() { 3, 5 };
            _verifyNumber = 45;
            _mathOperations = new MathOperations(_verifyNumber);

            List<int> response = _mathOperations.GetPrimes(divisors);
            Assert.Equal(response, primes);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-4)]
        public void WhenANegativeOrZeroNumberIsInformed_ItShouldThrowsAnArgumentOutOfRangeException(int number)
        {
            _mathOperations = new MathOperations(number);
            Assert.Throws<ArgumentOutOfRangeException>(() => _mathOperations.UserInput);
        }
    }
}
