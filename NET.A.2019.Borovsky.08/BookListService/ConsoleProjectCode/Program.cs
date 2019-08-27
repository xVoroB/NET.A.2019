using System;

namespace BookService
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var book3 = new Book("978-0743273565", "F. Scott Fitzgerald", "The Great Gatsby", "Scribner", 1925, 180, 9.92);
            var book2 = new Book("978-0060935467", "Harper Lee", "To Kill a Mockingbird", "Harper Perennial", 1960, 336, 7.19);
            var book1 = new Book("978-1451673319", "Ray Bradbury", "Fahrenheit 451", "Simon & Schuster", 1953, 249, 8.29);
            

            Console.WriteLine(book1.CompareTo(book3, Tags.ISBN.ToString()));
            Console.WriteLine(book1.CompareTo(book2));

            var usualListService = new BookListService();
            usualListService.AddBook(book1);
            usualListService.AddBook(book2);
            usualListService.AddBook(book3);
            usualListService.SortBooksByTag(Tags.Author);
            usualListService.ShowBooks();

            usualListService.FindBookByTag(Tags.Price, 8.29);


            var binaryStorage = new BinaryStorage(@"D:\BinaryStorage\binary.dat");
            binaryStorage.AddBook(book1);
            binaryStorage.AddBook(book2);
            binaryStorage.AddBook(book3);
            binaryStorage.SortBooksByTag(Tags.Title);
            binaryStorage.ShowBooks();

            Console.ReadLine();
        }
    }
}
