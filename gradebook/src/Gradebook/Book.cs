using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class Book {
        public string Name { get; private set;}

        public const string OWNER = "Dima's";

        //private List<double> grades = new List<double>(); // Could also be written like this
        private List<double> grades;

        public Book(string name) {            
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

        public void AddGrade(double grade) {
            
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

        public event GradeAddedDelegate GradeAdded;

        public Statistics GetStats() {
            var result = new Statistics();
            result.average =  GetAverageGrade();
            result.high = GetHighestGrade();
            result.low = GetLowestGrade();
            switch(result.average){
                case var d when d >= 90.0:
                    result.letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.letter = 'D';
                    break;
                default:
                    result.letter = 'F';
                    break;
            }

            //for(var i = 0; i < grades.Count;  i += 1) {
            //    //Jumping Statements                
            //    //if(grades[i] == 42.1){
            //    //    goto done;
            //    //}
            //    
            //    //if(grades[i] == 42.1){
            //    //    break;
            //    //}
            //    
            //    //if(grades[i] == 42.1){
            //    //    continue;
            //    //}

            //    result.low = Math.Min(grades[i], result.low);
            //    result.low = Math.Max(grades[i], result.high);
            //    result.average += grades[i];
            //
            //};
            //result.average /= grades.Count;
            //done:
            return result;
        }

        public void SetName(Book book, string name)
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