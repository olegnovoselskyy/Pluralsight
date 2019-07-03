using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Book {
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
                if (grade > highGrade) {
                    highGrade = grade;
                }
            }
            return highGrade;
        }

        public double GetLowestGrade() {
            var lowGrade = double.MaxValue;

            foreach (var grade in grades) {
                if (grade < lowGrade) {
                    lowGrade = grade;
                }
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
    }
}