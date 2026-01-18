using System;
using System.IO;
using System.Text.Json;

namespace Lesson13
{
    public class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Enter number of fractions: ");
            int count = int.Parse(Console.ReadLine());

            Fraction[] fractions = new Fraction[count];

            for (int i = 0; i < count; i++)
            {
                Console.Write("Enter numerator: ");
                int numerator = int.Parse(Console.ReadLine());

                Console.Write("Enter denominator: ");
                int denominator = int.Parse(Console.ReadLine());

                fractions[i] = new Fraction
                {
                    Numerator = numerator,
                    Denominator = denominator
                };
            }

            string filePath = "fractions.json";

            string serializedData = JsonSerializer.Serialize(fractions);
            File.WriteAllText(filePath, serializedData);

            string loadedData = File.ReadAllText(filePath);
            Fraction[] loadedFractions = JsonSerializer.Deserialize<Fraction[]>(loadedData);

            Console.WriteLine("Loaded fractions:");
            foreach (var fraction in loadedFractions)
            {
                Console.WriteLine($"{fraction.Numerator}/{fraction.Denominator}");
            }
        }
    }
}
