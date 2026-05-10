namespace DunesOfArabia.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public int DestinationId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // FIX #5: Changed from string to decimal so duration can be sorted,
        // filtered, and used in arithmetic (e.g. total trip hours).
        public decimal DurationHours { get; set; }

        public decimal PriceSAR { get; set; }
        public string Category { get; set; } = string.Empty;
    }
}