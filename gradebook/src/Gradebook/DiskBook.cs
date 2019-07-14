using System;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override void AddGrade(double grade)
        {
            var writer = File.AppendText($"{Name}.txt");
            writer.WriteLine(grade);
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
