namespace BookAPI.Books.DTO
{
    public class CreateBookRequest
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public DateTime Publish_Date { get; set; }
    }
}
