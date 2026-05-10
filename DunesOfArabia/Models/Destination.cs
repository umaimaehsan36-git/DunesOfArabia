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
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public decimal Cost { get; set; }
        public string Climate { get; set; } = string.Empty;
        public string VisaInfo { get; set; } = string.Empty;
    }
}