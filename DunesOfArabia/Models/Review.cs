namespace DunesOfArabia.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int DestinationId { get; set; }
        public int StarRating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}