using System;
using System.Collections.Generic;
using GradeBook;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {

            IBook book = new DiskBook("Grades");
            book.GradeAdded += OnGradeAdded;

            Console.WriteLine("Name your book");
            var bookname = Console.ReadLine();

            try
            {
                book.SetName(book, bookname);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }

            EnterGrades(book);

            var stats = book.GetStats();

            Console.WriteLine($"{InMemoryBook.OWNER}'s {book.Name} book:");
            Console.WriteLine($"The highest grade is: {stats.high}");
            Console.WriteLine($"The lowest grade is: {stats.low}");
            Console.WriteLine($"The average grade is: {stats.average:N1}");
            Console.WriteLine($"The letter grade is: {stats.letter}");



            #region Old Code
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

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    book.GetStats();
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.Write(ex.Message);
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }

            }
        }

        static void OnGradeAdded(object sender, EventArgs e){
            Console.WriteLine("Grade Added");
        }
    }
}
