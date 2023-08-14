namespace BooksApi.Models
{
    public class BookInput
    {
        public string Title { get; set; } = string.Empty;
        public Guid Author { get; set; }
    }
}
