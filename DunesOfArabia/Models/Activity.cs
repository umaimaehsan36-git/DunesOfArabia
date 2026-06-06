namespace DunesOfArabia.Models
{
    public class Activity
    {
        public int Id { get; set; }

        public int DestinationId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal DurationHours { get; set; }

        // Alias used by some pages as "Duration"
        public decimal Duration => DurationHours;

        public decimal PriceSAR { get; set; }

        // Alias used by some pages as "Price"
        public decimal Price => PriceSAR;

        public string Category { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public double Rating { get; set; }

        public string DifficultyLevel { get; set; } = string.Empty;

        public int MaxParticipants { get; set; }

        public int MinAge { get; set; }

        public List<string> IncludedServices { get; set; } = new();

        public string CancellationPolicy { get; set; } = string.Empty;

        public string OperatorName { get; set; } = string.Empty;

        public string OperatorEmail { get; set; } = string.Empty;

        public string OperatorPhone { get; set; } = string.Empty;

        public List<string> AvailableTimes { get; set; } = new();
    }
}