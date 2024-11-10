namespace GraphQLDemo.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public int Price { get; set; }
        public Description Description { get; set; } = new();
    }
}
