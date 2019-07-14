using System;
using System.Collections.Generic;
using GradeBook;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
                                   
            var book = new Book("Book1");

            while (true)
            {
                Console.WriteLine("Please enter grades for your gradebook, enter 'Q' to abort");
                var input = Console.ReadLine();
                
                if (input == "Q" && book.Count() > 0)
                {
                    book.ShowStats();
                    break;
                }

                try 
                {                                                 
                    var parser = Convert.ToDouble(input);
                    book.AddGrade(parser);
                                  
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Well here's your problem! : {ex}");
                    Console.WriteLine("Caught you!");
                }
                finally 
                {
                    Console.WriteLine("Finally...");
                }                
            }


            
            // Just some bad attempt at humor
            // if (book.Count() == 0)
            // {
            //     Console.WriteLine("Ok my bad.... Jeez");
            // }           

            #region Old Code
            
            // book.AddGrade(23.4);
            // book.AddGrade(56.2);
            // book.AddGrade(78.4);
            // book.AddGrade(88.6);
            // book.AddGrade(88.4);
            // book.AddGrade(93.2);
            // book.AddGrade(98);
            // book.AddGrade(12.3);
            // book.AddGrade(11);
            // book.AddGrade(22.7);
            // book.AddGrade(14.2);
            // book.AddGrade(10.9);
            // book.AddGrade(67.4);
            // book.AddGrade(75);
            // book.ShowStats();

            // var numbers = new [] {34.5, 12.4, 11.3, 6};
            // var result = 0.0;
            // var count = 0;

            // foreach (var number in numbers) {
            //     count++;
            //     result += number;
            //     System.Console.WriteLine($"{count} loops elapsed...");
            // }
            //  Console.WriteLine($"Here is the result: {result}");
            // var grades = new List<double>() {34.5, 12.4, 11.3, 6};
            // grades.Add(56.8);
            // foreach (var grade in grades) {
            //     count++;
            //     result += grade;
            //     System.Console.WriteLine($"{count} loops elapsed...");
            // }
            //  Console.WriteLine($"Here is the average of all the grades: {result / grades.Count}");

             // numbers[0] = 56.8;
            // numbers[1] = 345.6764;
            // numbers[2] = 41.9; 

            // double x = 36.78;
            // double y = 246.45;

            // Console.WriteLine($"{numbers[0]} + {numbers[1]} + {numbers[2]} = {numbers[0] + numbers[1] + numbers[2]}");

            // if (args.Length > 0) {
            //     Console.WriteLine($"Hello, {args[0]}!, It's a pleasure to meet you.");
            // }
            // else {
            //     Console.WriteLine("I'm sorry, I didn't catch your name...");
            // }

            // Console.WriteLine("Please enter your name: ");

            // var name = Console.ReadLine();

            // Console.WriteLine($"Hello {name}!");
            #endregion 

           
        }
    }
}