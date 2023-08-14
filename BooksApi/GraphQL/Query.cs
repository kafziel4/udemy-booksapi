using BooksApi.Models;
using BooksApi.Services;

namespace BooksApi.GraphQL
{
    public class Query
    {
        public Task<List<Book>> GetBooks([Service] Repository repository) =>
            repository.GetBooksAsync();
    }
}
