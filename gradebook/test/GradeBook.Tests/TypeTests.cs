using System;
using Xunit;
 

namespace GradeBook.Tests
{

    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        int count = 0;
        [Fact]
        public void WriteLogDelegateCanPointToMethod() 
        {
            WriteLogDelegate log = ReturnMessage;

            log += ReturnMessage;
            log += ReturnCount;

            var result = log("Hello!");

            Assert.Equal(3, count);

        }

        string ReturnMessage(string message)
        {
            count++;
            return message;
        }

         string ReturnCount(string message)
        {
            count++;
            return message;
        }

        [Fact]
        public void StringsBehaveLikeValueTypes() 
        {
            string name = "Oleg";
            name = MakeUppercase(name);

            Assert.Equal("OLEG", name);
        }

        private string MakeUppercase(string name)
        {
            return name.ToUpper();
        }

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

        private void GetRefBookSetName(out InMemoryBook book, string name) // ref does not need to be initiliazed
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CsharpIsPassByValue()
        {  
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
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

        private void SetName(InMemoryBook book, string name)
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


        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
