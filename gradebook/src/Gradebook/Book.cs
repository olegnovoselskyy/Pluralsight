using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Book {
        private List<double> list = new List<double>();

        public void AddGrade(double grade) {

            list.Add(grade);
        }

        public int Count() {
            return list.Count;
        }

    }
}