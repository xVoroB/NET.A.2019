using System;
using System.Collections.Generic;

namespace BookService
{
    class BookListService
    {
        /// <summary>
        /// List of books
        /// </summary>
        protected readonly List<Book> Books;

        /// <summary>
        /// Constructor
        /// </summary>
        public BookListService()
        {
            Books = new List<Book>();
        }

        /// <summary>
        /// Method to add book
        /// </summary>
        /// <param name="book"> Book to add </param>
        public virtual void AddBook(Book book)
        {
            foreach (var item in Books)
            {
                if (item.Equals(book))
                {
                    throw new ArgumentException("There is already this book in library");
                }
            }
            Books.Add(book);
        }

        /// <summary>
        /// Method to remove book
        /// </summary>
        /// <param name="book"> Book to remove </param>
        public virtual void RemoveBook(Book book)
        {
            bool exists = false;
            foreach (var item in Books)
            {
                if (item.Equals(book))
                {
                    exists = true;
                }
            }
            if (exists)
            {
                Books.Remove(book);
            }
            else
            {
                throw new ArgumentException("There is no such book in library");
            }
        }

        /// <summary>
        /// Method to print all books in list to console
        /// </summary>
        public void ShowBooks()
        {
            foreach (var item in Books)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Method to find book by its tag
        /// </summary>
        /// <param name="tag"> Tag to find </param>
        /// <param name="search"> Value of tag </param>
        public void FindBookByTag(Tags tag, object search)
        {

            foreach (Book item in Books)
            {
                var value = item.Tag(item, tag.ToString());

                if (value.ToString() == search.ToString())
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        /// <summary>
        /// Method to sort books by some tag
        /// </summary>
        /// <param name="tag"> Tag to sort by </param>
        public virtual void SortBooksByTag(Tags tag)
        {
            for (int i = 0; i < Books.Count - 1; i++)
            {
                for (int k = i + 1; k < Books.Count; k++)
                {
                    if (Books[i].CompareTo(Books[k], tag.ToString()) > 0)
                    {
                        Book book = Books[k];
                        Books[k] = Books[i];
                        Books[i] = book;
                    }
                }
            }
        }
    }
}
