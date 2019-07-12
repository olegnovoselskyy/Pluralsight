using System;
using Xunit;
 

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAverageGrade()
        {   


            // arrange
            var book = new Book("TestGrades");
            book.AddGrade(78.9);
            book.AddGrade(99.6);
            book.AddGrade(45.3);

            // act
            var result = book.GetStats();
           
            // assert

            // Equal checks if two values equal each other...
            // We usually check for the expected value and the actual
            Assert.Equal(99.6, result.high, 1);
            Assert.Equal(45.3, result.low, 1);
            Assert.Equal(74.6, result.average, 1);

          
        }
    }
}
