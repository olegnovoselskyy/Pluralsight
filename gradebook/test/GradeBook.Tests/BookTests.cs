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
            book.AddGrade(67.9);
            book.AddGrade(13.4);

           // act
           var result = book.GetStats();
           

           // assert
            Assert.Equal(40.7, result.Average, 1);
            Assert.Equal(67.9, result.High, 1);
            Assert.Equal(13.4, result.Low, 1);
            Assert.Equal(25, 25);
          
        }
    }
}
