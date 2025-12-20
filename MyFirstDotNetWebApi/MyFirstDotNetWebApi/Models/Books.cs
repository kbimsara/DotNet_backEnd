namespace MyFirstDotNetWebApi.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public DateTime PublishedDate { get; set; } = DateTime.Now;
    }
}
