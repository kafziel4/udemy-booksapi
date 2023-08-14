namespace BooksApi.Schemas
{
    public class Payload
    {
        public string? Error { get; set; } = null;

        public Payload()
        {
        }

        public Payload(string? error)
        {
            Error = error;
        }
    }
}
