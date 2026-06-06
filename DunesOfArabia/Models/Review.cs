namespace DunesOfArabia.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        // Alias used by some pages as "UserName"
        public string UserName { get; set; } = string.Empty;

        public int DestinationId { get; set; }

        public int ActivityId { get; set; }

        public int StarRating { get; set; }

        // Alias used by some pages as "Rating"
        public int Rating => StarRating;

        public string Comment { get; set; } = string.Empty;

        // Alias used by some pages as "Text"
        public string Text => Comment;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Alias used by some pages as "CreatedDate"
        public DateTime CreatedDate => CreatedAt;
    }
}