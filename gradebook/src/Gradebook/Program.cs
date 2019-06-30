using System;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {

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
