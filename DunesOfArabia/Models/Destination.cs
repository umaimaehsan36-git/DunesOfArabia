namespace DunesOfArabia.Models
{
    public class Destination
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Province { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public decimal Cost { get; set; }
        public string Climate { get; set; }
        public string VisaInfo { get; set; }
    }
}