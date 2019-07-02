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

    }
}