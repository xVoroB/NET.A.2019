using System;

namespace BookService
{
    class Book : IComparable
    {
        #region Fields

        string isbn, author, title, publisher;
        int publishYear, pages;
        double price;

        #endregion

        #region Props
        public string ISBN
        {
            get
            {
                return isbn;
            }
            set
            {
                if (IsValid.ISBN(value))
                {
                    isbn = value;
                }
                else
                {
                    throw new ArgumentException("Invalid ISBN");
                }
            }
        }

        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                if (IsValid.Author(value))
                {
                    author = value;
                }
                else
                {
                    throw new ArgumentException("Author");
                }
            }
        }

        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (IsValid.Price(value))
                {
                    price = value;
                }
                else
                {
                    throw new ArgumentException("Invalid price");
                }
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (IsValid.Title(value))
                {
                    title = value;
                }

                else
                {
                    throw new ArgumentException("Invalid title");
                }
            }
        }

        public string Publisher
        {
            get
            {
                return publisher;
            }
            set
            {
                if (IsValid.Publisher(value))
                {
                    publisher = value;
                }
                else
                {
                    throw new ArgumentException("Invalid publisher");
                }
            }
        }

        public int PublishYear
        {
            get
            {
                return publishYear;
            }
            set
            {
                if (IsValid.PublishYear(value))
                {
                    publishYear = value;
                }
                else
                {
                    throw new ArgumentException("Invalid publish year");
                }
            }
        }

        public int Pages
        {
            get
            {
                return pages;
            }
            set
            {
                if (IsValid.Pages(value))
                {
                    pages = value;
                }
                else
                {
                    throw new ArgumentException("Invalid number of pages");
                }
            }
        }

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public Book(string isbn, string author, string title, string publisher, int publishYear, int pages, double price)
        {
            ISBN = isbn;
            Author = author;
            Title = title;
            Publisher = publisher;
            PublishYear = publishYear;
            Pages = pages;
            Price = price;
        }

        #region Overrided "object" methods and operators
        /// <summary>
        /// Converting book to string
        /// </summary>
        public override string ToString()
        {
            return ("ISBN:" + ISBN + "\n" +
                    "Author:" + Author + "\n" +
                    "Title:" + Title + "\n" +
                    "Publisher:" + Publisher + "\n" +
                    "Publication year:" + PublishYear + "\n" +
                    "Pages:" + Pages + "\n" +
                    "Price:" + Price + "\n" +
                    "-----");
        }

        /// <summary>
        /// Convering book to string with provided format
        /// </summary>
        public string ToString(string format)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "F";
            }
            format = format.ToUpper();

            switch (format)
            {
                case "AT":
                    return Author + ", " + Title;
                case "ATPPY":
                    return Author + ", " +
                            Title + ", " +
                            Publisher + ", " +
                            PublishYear.ToString();
                case "IAT":
                    return ISBN + ", " +
                            Author + ", " +
                            Title;
                case "IATPPYPA":
                    return "ISBN: " + ISBN + ", " +
                            Author + ", " +
                            Title + ", " +
                            Publisher + ", " +
                            PublishYear + ", " +
                            Pages.ToString();
                case "IATPPYPAPR":
                    return "ISBN: " + ISBN + ", " +
                            Author + ", " +
                            Title + ", " +
                            Publisher + ", " +
                            PublishYear.ToString() + ", " +
                            Pages.ToString() + ", " +
                            Price.ToString();
                case "F":
                    goto case "IATPPYPAPR";
                default:
                    throw new FormatException("Invalid format");
            }
        }


        /// <summary>
        /// Overrided "Equals" method
        /// </summary>
        /// <param name="obj"> Object to compare </param>
        public override bool Equals(object obj)
        {
            Book book = (Book)obj;
            return book.ISBN == ISBN;
        }

        /// <summary>
        /// Overrided "GetHashCode" method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Overrided operator "=="
        /// </summary>
        public static bool operator ==(Book book1, Book book2)
        {
            return book1.Equals(book2);
        }

        /// <summary>
        /// Overrided operator "!="
        /// </summary>
        public static bool operator !=(Book book1, Book book2)
        {
            return !book1.Equals(book2);
        }

        #endregion


        #region IComparable interface methods
        public int CompareTo(object o)
        {
            Book book = o as Book;
            return ISBN.CompareTo(book.ISBN);
        }

        public int CompareTo(object o, string prop)
        {
            Book book = o as Book;
            return Tag(this, prop).ToString().CompareTo(Tag(book, prop).ToString());
        }

        #endregion

        /// <summary>
        /// Method used to see current book's tag value
        /// </summary>
        /// <param name="book"> Current book </param>
        /// <param name="prop"> Property name </param>
        /// <returns> Tag value </returns>
        public object Tag(Book book, string prop)
        {
            return book.GetType().GetProperty(prop).GetValue(book);
        }
    }

}
