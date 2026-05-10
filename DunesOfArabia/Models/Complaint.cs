namespace DunesOfArabia.Models
{
    public class Complaint
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Status { get; set; } = "Open";
        public string Priority { get; set; } = "Normal";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ResolvedAt { get; set; }
        public string AdminResponse { get; set; }
    }
}