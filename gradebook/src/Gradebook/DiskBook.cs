using System;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using(var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
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
