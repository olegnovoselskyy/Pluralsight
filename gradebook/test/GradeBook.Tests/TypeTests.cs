using System;
using Xunit;
 

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void SetBookName()
        {   
           var book1 = GetBook("Book 1");
           SetName(book1, "New Name");

           Assert.Equal("New Name", book1.Name);     
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {   
           var book1 = GetBook("Book 1");
           var book2 = GetBook("Book 2");

           var testBook1 = new Book("Book 1");
           var testBook2 = new Book("Book 2");

           Assert.Equal(testBook1.Name, book1.Name);
           Assert.Equal(testBook2.Name, book2.Name);  
           Assert.NotSame(book1, book2);         
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {   
           var book1 = GetBook("Book 1");
           var book2 = book1;

           Assert.Same(book1, book2);     
           Assert.True(Object.ReferenceEquals(book1, book2));   
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
