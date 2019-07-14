using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Statistics
    {
        public double average = 0.0;
        public double high = double.MaxValue;
        public double low = double.MinValue;
        public char letter;

        public int Count(List<double> grades) {
            return grades.Count;
        }

        public double GetHighestGrade(List<double> grades) {
            var highGrade = double.MinValue;

            foreach (var grade in grades) {

                highGrade = Math.Max(grade, highGrade);
            }
            return highGrade;
        }

        public double GetLowestGrade(List<double> grades) {
            var lowGrade = double.MaxValue;

            foreach (var grade in grades) {

                lowGrade = Math.Min(grade, lowGrade);
            }
            return lowGrade;
        }

         public double GetAverageGrade(List<double> grades) {
            var average = 0.0;

            foreach (var grade in grades) {
                average += grade;
            }
            return average / grades.Count;
        }

        public char ConvertToLetterGrade(double average)
        {
            switch (average)
            {
                case var d when d >= 90.0:
                     return 'A';
                case var d when d >= 80.0:
                    return 'B';
                case var d when d >= 70.0:
                    return 'C';
                case var d when d >= 60.0:
                    return 'D';
                default:
                    return 'F';
            }
        }
    }
}