using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{

    public delegate void GradeAddedDelegate(object sender, EventArgs args);


    public class NamedObject 
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public virtual string Name { get; set; }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStats();
        string Name { get; set; }
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public Statistics GetStats()
        {
            throw new NotImplementedException();
        }
    }
    public class InMemoryBook : Book {
        //private List<double> grades = new List<double>(); // Could also be written like this
        private List<double> grades;

        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        public override void AddGrade(double grade) 
        {

            if (grade >= 0 && grade <= 100) 
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else 
            {
                Console.WriteLine("Invalid value.");
            }
        }

        public int Count() {
            return grades.Count;
        }

        public double GetHighestGrade() {
            var highGrade = double.MinValue;

            foreach (var grade in grades) {

                highGrade = Math.Max(grade, highGrade);

                // if (grade > highGrade) {
                //     highGrade = grade;
                // }
            }
            return highGrade;
        }

        public double GetLowestGrade() {
            var lowGrade = double.MaxValue;

            foreach (var grade in grades) {

                lowGrade = Math.Min(grade, lowGrade);

                // if (grade < lowGrade) {
                //     lowGrade = grade;
                // }
            }
            return lowGrade;
        }

         public double GetAverageGrade() {
            var average = 0.0;

            foreach (var grade in grades) {
                average += grade;
            }
                       
            return average / grades.Count;
        }

        public void ShowStats() {
             var count = Count();
            var average = GetAverageGrade();
            var high = GetHighestGrade();
            var low = GetLowestGrade();

             Console.WriteLine($"There are {count} grades recorded. The average is {average:N2}, the highest grade is {high} and the lowest is {low}");
        }

          public Statistics GetStats() { 

            var stats = new Statistics();          
            stats.Average = GetAverageGrade();
            stats.High = GetHighestGrade();
            stats.Low = GetLowestGrade();

            switch (stats.Average) 
            {
                case var d when d >= 90.0:
                    stats.Letter = 'A';
                    break;

                case var d when d >= 80.0:
                    stats.Letter = 'B';
                    break;

                case var d when d >= 70.0:
                    stats.Letter = 'C';
                    break;

                case var d when d >= 60.0:
                    stats.Letter = 'D';
                    break;

                default:
                    stats.Letter = 'F';
                    break;
            }

            return stats;
        }


          public void JiraTest() {
             Console.WriteLine("This is a test of the JIRA trackiong software");
        }

         public void  BranchTest() {
             Console.WriteLine("This is a test of the branches");
        }

        public event GradeAddedDelegate GradeAdded;

    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
           File.AppendText($"");        
        }

        public Statistics GetStats()
        {
            throw new NotImplementedException();
        }
    }

}