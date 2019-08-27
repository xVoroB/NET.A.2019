using System.IO;

namespace BookService
{
    class BinaryStorage : BookListService
    {

        public string FilePath { get; private set; }

        public BinaryStorage(string path)
        {
            FilePath = path;
            Import(path);
        }

        private void Import(string path)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
            {
                while (reader.PeekChar() > -1)
                {
                    string isbn = reader.ReadString();
                    string author = reader.ReadString();
                    string title = reader.ReadString();
                    string publisher = reader.ReadString();
                    int publishYear = reader.ReadInt32();
                    int pages = reader.ReadInt32();
                    double price = reader.ReadDouble();

                    base.AddBook(new Book(isbn, author, title, publisher, publishYear, pages, price));
                }
            }
        }
        public override void SortBooksByTag(Tags tag)
        {
            base.SortBooksByTag(tag);
            using (BinaryWriter writer = new BinaryWriter(File.Open(FilePath, FileMode.Truncate)))
            {
                writer.Seek(0, SeekOrigin.End);

                foreach (var book in Books)
                {
                    Write(book, FilePath, writer);
                }
            }
        }
        public override void AddBook(Book book)
        {
            base.AddBook(book);
            using(BinaryWriter writer = new BinaryWriter(File.Open(FilePath, FileMode.OpenOrCreate)))
            {
                writer.Seek(0, SeekOrigin.End);
                Write(book, FilePath, writer);
            }
        }

        public void Write(Book book, string path, BinaryWriter writer)
        {
            writer.Write(book.ISBN);
            writer.Write(book.Author);
            writer.Write(book.Title);
            writer.Write(book.Publisher);
            writer.Write(book.PublishYear);
            writer.Write(book.Pages);
            writer.Write(book.Price);
        }

        public override void RemoveBook(Book book)
        {
            base.RemoveBook(book);
            using (BinaryWriter writer = new BinaryWriter(File.Open(FilePath, FileMode.Truncate)))
            {
                writer.Seek(0, SeekOrigin.End);

                foreach (var item in Books)
                {
                    Write(item, FilePath, writer);
                }
            }
        }
    }
}
