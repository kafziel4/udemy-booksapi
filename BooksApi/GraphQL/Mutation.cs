using BooksApi.Exceptions;
using BooksApi.Models;
using BooksApi.Services;

namespace BooksApi.GraphQL
{
    public class Mutation
    {
        public async Task<AuthorPayload> AddAuthor(AuthorInput input, [Service] Repository repository)
        {
            var author = new Author { Id = Guid.NewGuid(), Name = input.Name };
            await repository.AddAuthor(author);
            return new AuthorPayload(author);
        }

        public async Task<BookPayload> AddBook(BookInput input, [Service] Repository repository)
        {
            var author = await repository.GetAuthor(input.Author) ??
                throw new AuthorNotFoundException("Author not found");
            var book = new Book { Id = Guid.NewGuid(), Title = input.Title, Author = author };
            await repository.AddBook(book);
            return new BookPayload(book);
        }
    }
}
