using NLog;
using System;

namespace BookService
{
    public class Book : IComparable
    {
        #region Fields

        string isbn, author, title, publisher;
        int publishYear, pages;
        double price;
        readonly Logger log = LogManager.GetCurrentClassLogger();

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
                    log.Info("ISBN was added");
                }
                else
                {
                    log.Warn("Wrong ISBN " + value);
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
                    log.Info("Author was added");
                }
                else
                {
                    log.Warn("Wrong author " + value);
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
                    log.Info("Price was added");
                }
                else
                {
                    log.Warn("Wrong price " + value);
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
                    log.Info("Title was added");
                }
                else
                {
                    log.Warn("Wrong title " + value);
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
                    log.Info("Price was added");
                }
                else
                {
                    log.Warn("Wrong price " + value);
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
                    log.Info("Publish year was added");
                }
                else
                {
                    log.Warn("Wrong publish year " + value);
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
                    log.Info("Number of pages was added");
                }
                else
                {
                    log.Warn("Wrong number of pages " + value);
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
                    return "ISBN: " + ISBN + ", " +
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
                    log.Warn("Wrong format type");
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
