using BooksApi.Models;

namespace BooksApi.Services
{
    public class Repository
    {
        private readonly List<Book> _books = new();
        private readonly List<Author> _authors = new();

        public Task<List<Book>> GetBooksAsync()
        {
            return Task.FromResult(_books);
        }

        public Task<Author?> GetAuthor(Guid authorId)
        {
            return Task.FromResult(_authors.Find(a => a.Id == authorId));
        }

        public Task AddAuthor(Author author)
        {
            _authors.Add(author);
            return Task.CompletedTask;
        }

        public Task AddBook(Book book)
        {
            _books.Add(book);
            return Task.CompletedTask;
        }
    }
}
