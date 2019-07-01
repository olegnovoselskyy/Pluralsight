using System;
using System.Collections.Generic;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {

            var numbers = new [] {34.5, 12.4, 11.3, 6};
            var result = 0.0;
            var count = 0;

            // foreach (var number in numbers) {
            //     count++;
            //     result += number;
            //     System.Console.WriteLine($"{count} loops elapsed...");
            // }
            //  Console.WriteLine($"Here is the result: {result}");
            var grades = new List<double>() {34.5, 12.4, 11.3, 6};
            grades.Add(56.8);
            foreach (var grade in grades) {
                count++;
                result += grade;
                System.Console.WriteLine($"{count} loops elapsed...");
            }
             Console.WriteLine($"Here is the average of all the grades: {result / count}");
            // numbers[0] = 56.8;
            // numbers[1] = 345.6764;
            // numbers[2] = 41.9; 

            // double x = 36.78;
            // double y = 246.45;

            // Console.WriteLine($"{numbers[0]} + {numbers[1]} + {numbers[2]} = {numbers[0] + numbers[1] + numbers[2]}");

            if (args.Length > 0) {
                Console.WriteLine($"Hello, {args[0]}!, It's a pleasure to meet you.");
            }
            else {
                Console.WriteLine("I'm sorry, I didn't catch your name...");
            }

            // Console.WriteLine("Please enter your name: ");

            // var name = Console.ReadLine();

            // Console.WriteLine($"Hello {name}!");
        }
    }
}
