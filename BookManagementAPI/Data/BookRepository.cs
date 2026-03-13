using BookManagementAPI.Models;

namespace BookManagementAPI.Data
{
    public class BookRepository
    {
        private static List<Book> books = new List<Book>();

        public List<Book> GetAll()
        {
            return books;
        }

        public Book? GetById(int id)
{
    return books.FirstOrDefault(b => b.Id == id);
}

        public void Add(Book book)
        {
            if (books.Count == 0)
                book.Id = 1;
            else
                book.Id = books.Max(b => b.Id) + 1;

            books.Add(book);
        }

        public void Update(int id, Book updatedBook)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book != null)
            {
                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                book.Isbn = updatedBook.Isbn;
                book.PublicationDate = updatedBook.PublicationDate;
            }
        }

        public void Delete(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book != null)
            {
                books.Remove(book);
            }
        }
    }
}