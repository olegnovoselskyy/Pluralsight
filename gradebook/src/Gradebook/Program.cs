using System;
using System.Collections.Generic;
using GradeBook;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {

            IBook book = new DiskBook("Disk");
            book.Name = "New Name";

            EnterGrades(book);

        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Please enter grades for your gradebook, enter 'Q' to abort");
                var input = Console.ReadLine();

                if (input == "Q") //&& book.Count() > 0
                {
                
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
               // book.ShowStats();
        }
    }
}