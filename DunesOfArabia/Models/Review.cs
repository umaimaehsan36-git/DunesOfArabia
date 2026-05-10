namespace DunesOfArabia.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int DestinationId { get; set; }
        public int StarRating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}