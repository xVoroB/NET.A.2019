using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService
{
    class BookFormat : IFormatProvider, ICustomFormatter
    {
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (!(arg is Book))
            {
                try
                {
                    HandleOtherFormats(format, arg);
                }
                catch (FormatException)
                {
                    throw new FormatException("Format is invalid");
                }
            }

            format = format.ToUpper();

            Book book = arg as Book;

            if (string.IsNullOrEmpty(format))
            {
                return book.ToString();
            }

            switch (format)
            {
                case "IA":
                    return "ISBN: " + book.ISBN + ", " +
                            book.Author;
                case "TPY":
                    return book.Title + ", " +
                            book.PublishYear;
                case "TPR":
                    return book.Title + ", " +
                            book.Price.ToString();
                case "TPA":
                    return book.Title + ", " +
                            book.Pages.ToString();
                default:
                    try
                    {
                        HandleOtherFormats(format, arg);
                    }
                    catch (FormatException)
                    {
                        throw new FormatException("Format is invalid");
                    }
                    break;
            }

            return book.ToString();
        }

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
            {
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            }

            else if (arg != null)
            {
                return arg.ToString();
            }

            return "";
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            return null;
        }
    }
}
