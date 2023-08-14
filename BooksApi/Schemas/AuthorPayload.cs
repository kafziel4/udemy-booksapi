using BooksApi.Schemas;

namespace BooksApi.Models
{
    public class AuthorPayload : Payload
    {
        public Author? Record { get; set; }

        public AuthorPayload()
        {
        }

        public AuthorPayload(Author record)
        {
            Record = record;
        }

        public AuthorPayload(Author record, string? error) : base(error)
        {
            Record = record;
        }
    }
}
