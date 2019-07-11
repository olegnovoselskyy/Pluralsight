using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book {
        //private List<double> grades = new List<double>(); // Could also be written like this
        private List<double> grades;

        public Book() {
            grades = new List<double>();
        }

        public void AddGrade(double grade) {

            grades.Add(grade);
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

          public void JiraTest() {
             Console.WriteLine("This is a test of the JIRA tracking software");
        }

                  public void DimaBranchTest() {
             Console.WriteLine("This is a test of the JIRA tracking software");
        }
    }
}