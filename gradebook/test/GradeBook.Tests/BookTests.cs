using System;
using Xunit;
 

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {  

            // var x = 12;
            // var y = 15;
            // Assert.Equal(15, y);

           // arrange
           var book = new Book();
            book.AddGrade(78.9);
            book.AddGrade(99.6);
            book.AddGrade(45.3);

           // act
           var result = book.GetStats();
           

           // assert
            Assert.Equal(85.6, result.Average);
            Assert.Equal(75.6, result.High);
            Assert.Equal(35.6, result.Low);
          
        }
    }
}
