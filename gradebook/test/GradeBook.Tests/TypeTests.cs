using System;
using Xunit;
 

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void ValkueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(out x, 15);

            Assert.Equal(15, x);
        }

        private int SetInt(out int x, int y)
        {
            x = y;
            return x; 
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CsharpPassByRef()
        {  
            var book1 = GetBook("Book 1");
            GetRefBookSetName(out book1, "New Name"); // can also use 'out' insteaf of 'ref' the C# compilier thinks that the 'out' param ahs not been initliazed

            Assert.Equal("New Name", book1.Name);
        }

        private void GetRefBookSetName(out Book book, string name) // ref does not need to be initiliazed
        {
            book = new Book(name);
        }

        [Fact]
        public void CsharpIsPassByValue()
        {  
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }


        [Fact]
        public void CanSetNameFromReference()
        {  
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
            Assert.Equal("New Name", book1.Name);
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

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
             Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {  
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.Same(book1, book2);
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }


        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
