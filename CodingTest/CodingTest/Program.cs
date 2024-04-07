using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] amounts = { 30, 50, 60, 80, 140, 230, 370, 610, 980 };

            foreach (int amount in amounts)
            {
                var combinations = FindCombinations(amount);
                Console.WriteLine($"{combinations.Count()} combinations for {amount} EUR:");
                foreach (string combo in combinations)
                {
                    Console.WriteLine("- " + combo);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        static List<string> FindCombinations(int amount)
        {
            var combinations = new List<string>();
            int maxHundreds = amount / 100;

            for (int hundreds = 0; hundreds <= maxHundreds; hundreds++)
            {
                var remainingAfterHundreds = amount - hundreds * 100;
                var maxFifties = remainingAfterHundreds / 50;

                for (int fifties = 0; fifties <= maxFifties; fifties++)
                {
                    var remainingAfterFifties = remainingAfterHundreds - fifties * 50;

                    if (remainingAfterFifties % 10 == 0)
                    {
                        var tens = remainingAfterFifties / 10;
                        var result = FormatResult(hundreds, fifties, tens);
                        combinations.Add(result);
                    }
                }
            }
            return combinations;
        }

        static string FormatResult(int hundreds, int fifties, int tens)
        {
            var parts = new List<string>();
            if (hundreds > 0) parts.Add($"{hundreds} x 100 EUR");
            if (fifties > 0) parts.Add($"{fifties} x 50 EUR");
            if (tens > 0) parts.Add($"{tens} x 10 EUR");

            var result = string.Join(" + ", parts);
            return result.Trim();
        }
    }
}
