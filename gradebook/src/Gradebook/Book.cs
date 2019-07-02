using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Book {
        public List<double> list = new List<double>();

        public void AddGrade(double grade) {

            list.Add(grade);
        }

        public int Count() {
            return list.Count;
        }

    }
}