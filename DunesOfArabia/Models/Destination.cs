namespace DunesOfArabia.Models
{
    public class Destination
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
<<<<<<< Updated upstream
=======

        // Stored as JSON string in DB via value converter in AppDbContext
        public List<string> ImageGallery { get; set; } = new();

>>>>>>> Stashed changes
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public decimal Cost { get; set; }
        public string Climate { get; set; } = string.Empty;
        public string VisaInfo { get; set; } = string.Empty;
<<<<<<< Updated upstream
=======

        public double Rating { get; set; }

        public string BestSeason { get; set; } = string.Empty;

        public string Temperature { get; set; } = string.Empty;

        public string HighlightsJson { get; set; } = string.Empty;

        // FIX: was = DateTime.UtcNow — dynamic default causes
        // PendingModelChangesWarning in EF seed. Default is now
        // handled by the DB column default set in AppDbContext.
        public DateTime CreatedDate { get; set; }
>>>>>>> Stashed changes
    }
}
