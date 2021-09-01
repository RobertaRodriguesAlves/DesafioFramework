using System;
using System.Linq;
using API.Application.DTO;
using System.Threading.Tasks;
using System.Collections.Generic;
using API.Application.Service.Abstractions;

namespace API.Application.Service
{
    public class MathOperationsService : IMathOperationsService
    {
        private const byte _evenNumber = 2, _divisionRemainder = 0, _index = 0, _numberOfDivisors = 1, _firstDivisor = 1;
        public async Task<OperationsResponseDTO> Get(int number)
        {
            IEnumerable<int> divisors = GetDivisors(number).OrderBy(number => number).Distinct();
            List<int> primes = GetPrimes(divisors.ToList());
            var operationsDTO = new OperationsResponseDTO
            {
                Divisors = divisors,
                Primes = primes
            };
            return operationsDTO;
        }

        private static IEnumerable<int> GetDivisors(int number)
        {
            yield return _firstDivisor;
            foreach (var item in Enumerable.Range(_evenNumber, (int)Math.Sqrt(number) + 1))
            {
                if (number % item == _divisionRemainder)
                {
                    yield return item;
                    double divisor = number / item;
                    var divisorRounded = Math.Truncate(divisor);
                    if (divisorRounded != item) yield return (int)divisorRounded;
                }
            }
            yield return number;
        }

        private static List<int> GetPrimes(List<int> divisors)
        {
            if (RemovesNumberOne(divisors)) return divisors;
            divisors.RemoveAll(divisor => divisor % _evenNumber == _divisionRemainder && divisor != _evenNumber);
            for (int index = 0; index < divisors.Count; index++)
            {
                var verifyNumber = divisors[index];
                var square = verifyNumber * verifyNumber;
                divisors.RemoveAll(divisor => divisor >= square && divisor % verifyNumber == _divisionRemainder);
            }
            return divisors;
        }

        private static bool RemovesNumberOne(List<int> divisors)
        {
            divisors.RemoveAt(_index);
            if (divisors.Count.Equals(_numberOfDivisors))
                return true;
            return false;
        }
    }
}
