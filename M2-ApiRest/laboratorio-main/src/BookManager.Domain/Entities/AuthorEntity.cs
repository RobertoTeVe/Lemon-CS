using System.Diagnostics;

namespace BookManager.Domain.Entities
{
    public class AuthorEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public DateTime? Birth { get; set; }
        public string CountryCode { get; set; } = String.Empty;

        // Navigation properties
        public List<BookEntity> Books { get; set; } = new();
    }
}
