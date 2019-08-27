using System;
using System.Collections.Generic;

namespace BookService
{
    class CacheStorage
    {
        protected readonly List<Book> Books;

        /// <summary>
        /// Constructor
        /// </summary>
        public CacheStorage()
        {
            Books = new List<Book>();
        }

        /// <summary>
        /// 
        /// </summary>
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

        public virtual void ShowBooks()
        {
            foreach (var item in Books)
            {
                Console.WriteLine(item);
            }
        }

        public virtual void FindBookByTag(Tags tag, object search)
        {

            foreach (Book item in Books)
            {
                var value = item.Tag(item, tag.ToString());

                if (value.ToString() == search.ToString())
                {
                    Console.WriteLine(item.Title);
                }
            }
        }

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
