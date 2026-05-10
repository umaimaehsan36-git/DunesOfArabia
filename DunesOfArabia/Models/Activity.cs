namespace DunesOfArabia.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public int DestinationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DurationHours { get; set; }
        public decimal PriceSAR { get; set; }
        public string Category { get; set; }
    }
}