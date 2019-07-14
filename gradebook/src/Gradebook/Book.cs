using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public interface IBook
    {
        void AddGrade(double grade);
        void SetName(IBook book, string name);
        Statistics GetStats();

        string Name {get; set;}
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook 
    {
        public Book(string name) : base(name) { }

        public virtual event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public virtual Statistics GetStats()
        {
            throw new NotImplementedException();
        }

        public virtual void SetName(IBook book, string name)
        {
            throw new NotImplementedException();
        }
    }

    public class InMemoryBook : Book
    {

        public const string OWNER = "Dima";

        //private List<double> grades = new List<double>(); // Could also be written like this
        private List<double> grades;

        public InMemoryBook(string name) : base(name) {            
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(char letter) {
            switch(letter) {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(90);
                    break;

                case 'D':
                    AddGrade(80);
                    break;
                
                default:
                    AddGrade(0);
                    break;
            }       
        }

        public override void AddGrade(double grade) {
            
            if (grade <= 100 && grade >= 0) {
                grades.Add(grade);
                if(GradeAdded != null){
                    GradeAdded(this, new EventArgs());
                }
            }
            else {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public void ShowStats() {
            var stats = new Statistics();

            var count = stats.Count(grades);
            var average = stats.GetAverageGrade(grades);
            var high = stats.GetHighestGrade(grades);
            var low = stats.GetLowestGrade(grades);

             Console.WriteLine($"There are {count} grades recorded. The average is {average:N2}, the highest grade is {high} and the lowest is {low}");
        }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStats()
        {
            var result = new Statistics();
            result.average = result.GetAverageGrade(grades);
            result.high = result.GetHighestGrade(grades);
            result.low = result.GetLowestGrade(grades);

            result.letter = result.ConvertToLetterGrade(result.average);
            return result;
        }

        public override void SetName(IBook book, string name)
        {
            if(!String.IsNullOrEmpty(name)) {
                book.Name = name;
            }
            else {
                throw new NullReferenceException($"Invalid {nameof(name)}");
            }

        }
    }
}