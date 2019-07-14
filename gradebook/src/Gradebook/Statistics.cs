using System;
using System.Collections.Generic;

namespace GradeBook 
{
    public class Statistics
    {
        public double Average = 0.0;
        public double High = 0.0;
        public double Low = 0.0;
        public char Letter;

        public int Count(List<double> grades) 
        {
            
            return grades.Count;
        }

        public double GetHighestGrade(List<double> grades) 
        {
            var highGrade = double.MinValue;

            foreach (var grade in grades) {

                highGrade = Math.Max(grade, highGrade);

                // if (grade > highGrade) {
                //     highGrade = grade;
                // }
            }
            return highGrade;
        }

        public double GetLowestGrade(List<double> grades) 
        {
            var lowGrade = double.MaxValue;

            foreach (var grade in grades) {

                lowGrade = Math.Min(grade, lowGrade);

                // if (grade < lowGrade) {
                //     lowGrade = grade;
                // }
            }
            return lowGrade;
        }

        public double GetAverageGrade(List<double> grades) 
        {
            var average = 0.0;

            foreach (var grade in grades) {
                average += grade;
            }
                       
            return average / grades.Count;
        }
    }
}