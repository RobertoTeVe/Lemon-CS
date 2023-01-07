using System.Diagnostics;

namespace BookManager.Domain.Entities
{
    public class AuthorEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Last name could be none, because there are books which author is unknown thus we can have an author in our db called "Anonymus"
        /// </summary>
        public string? LastName { get; set; }
        public DateTime? Birth { get; set; }
        public string? CountryCode { get; set; }

        // Navigation properties
        public List<BookEntity> Books { get; set; } = new();
    }
}
