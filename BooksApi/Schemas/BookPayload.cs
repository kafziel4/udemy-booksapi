using BooksApi.Schemas;

namespace BooksApi.Models
{
    public class BookPayload : Payload
    {
        public Book? Record { get; set; }

        public BookPayload()
        {
        }

        public BookPayload(Book record)
        {
            Record = record;
        }

        public BookPayload(Book record, string? error) : base(error)
        {
            Record = record;
        }
    }
}
