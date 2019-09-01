using NUnit.Framework;
using BookService;

namespace Tests
{
    public class Tests
    {
        [TestCase(ExpectedResult = "F. Scott Fitzgerald, The Great Gatsby")]
        public string ToStringTest1()
        {
            var book = new Book("978-0743273565", "F. Scott Fitzgerald", "The Great Gatsby", "Scribner", 1925, 180, 9.92);
            return book.ToString("AT");
        }


        [TestCase(ExpectedResult = "ISBN: 978-0060935467, Harper Lee, To Kill a Mockingbird, Harper Perennial, 1960, 336, 7,19")]
        public string ToStringTest2()
        {
            var book = new Book("978-0060935467", "Harper Lee", "To Kill a Mockingbird", "Harper Perennial", 1960, 336, 7.19);
            return book.ToString("F");
        }

        [TestCase(ExpectedResult = "ISBN: 978-1451673319, Ray Bradbury, Fahrenheit 451")]
        public string ToStringTest3()
        {
            var book = new Book("978-1451673319", "Ray Bradbury", "Fahrenheit 451", "Simon & Schuster", 1953, 249, 8.29);
            return book.ToString("IAT");
        }

    }
}