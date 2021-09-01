using System;
using System.Linq;
using System.Collections.Generic;

namespace DesafioFramework
{
    public class MathOperations
    {
        private int _number;
        public int UserInput
        {
            get
            {
                if (_number <= 0) throw new ArgumentOutOfRangeException($"The number must be greater than 0.");
                return _number;
            }
            set { _number = value; }
        }
        private const byte _evenNumber = 2, _divisionRemainder = 0, index = 0, _numberOfDivisors = 1, _firstDivisor = 1;

        public MathOperations(int number)
        {
            _number = number;
        }

        public IEnumerable<int> GetDivisors()
        {
            yield return _firstDivisor;
            foreach (var item in Enumerable.Range(_evenNumber, (int)Math.Sqrt(UserInput) + 1))
            {
                if (_number % item == _divisionRemainder)
                {
                    yield return item;
                    double divisor = _number / item;
                    var divisorRounded = Math.Truncate(divisor);
                    if (divisorRounded != item) yield return (int)divisorRounded;
                }
            }
            yield return _number;
        }
        public List<int> GetPrimes(List<int> divisors)
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
            divisors.RemoveAt(index);
            if (divisors.Count.Equals(_numberOfDivisors))
                return true;
            return false;
        }
    }
}
