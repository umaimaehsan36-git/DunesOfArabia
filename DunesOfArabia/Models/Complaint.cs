namespace DunesOfArabia.Models
{
    public class Complaint
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Status { get; set; } = "Open";
        public string Priority { get; set; } = "Normal";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ResolvedAt { get; set; }

        // FIX #6: Changed to string? so null means "no response yet"
        // vs empty string which is ambiguous. EF Core stores it as NULL
        // in the database until an admin actually replies.
        public string? AdminResponse { get; set; }
    }
}