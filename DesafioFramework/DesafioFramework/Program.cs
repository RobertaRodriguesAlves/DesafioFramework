using System;
using System.IO;
using System.Linq;

namespace DesafioFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Write("Digite um número: ");
                    var operations = new MathOperations(int.Parse(Console.ReadLine()));
                    var divisors = operations.GetDivisors().OrderBy(number => number).Distinct().ToList();
                    Console.WriteLine($"\nNúmero de Entrada: {operations.UserInput}");
                    Console.WriteLine($"Números Divisores: {string.Join(" ", divisors)}");
                    Console.WriteLine($"Divisores Primos: {string.Join(" ", operations.GetPrimes(divisors))}");
                    Console.WriteLine("-----------------------------------------------------------------------");
                }
                catch (ArgumentOutOfRangeException e)
                {
                    FormatErrorMessage(e.ParamName);
                }
                catch (Exception e)
                {
                    FormatErrorMessage(e.Message);
                }
                Console.ReadKey();
            }

            void FormatErrorMessage(string errormessage)
            {
                TextWriter errorWriter = Console.Error;
                Console.ForegroundColor = ConsoleColor.Red;
                errorWriter.WriteLine(errormessage);
                Console.ResetColor();
            }
        }
    }
}
