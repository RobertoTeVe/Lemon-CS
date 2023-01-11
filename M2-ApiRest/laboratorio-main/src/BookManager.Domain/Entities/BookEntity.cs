namespace BookManager.Domain.Entities
{
    public class BookEntity
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; } = String.Empty;
        public DateTime? PublishedOn { get; set; }
        public string Description { get; set; } = String.Empty; 

        // Navigation Properties
        public AuthorEntity Author { get; set; }
    }
}
