
namespace BookManager.Application.Models
{
    public class Author
    {
        public string Name { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public DateTime? Birth { get; set; }
        public string CountryCode { get; set; } = String.Empty;
    }
}
