using System.Collections.Generic;

namespace API.Application.DTO
{
    public class OperationsResponseDTO
    {
        public IEnumerable<int> Divisors { get; set; }
        public List<int> Primes { get; set; } = new List<int>();
    }
}
