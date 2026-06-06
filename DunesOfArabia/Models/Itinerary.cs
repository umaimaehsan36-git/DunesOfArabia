namespace DunesOfArabia.Models
{
    public class Itinerary
    {
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        // ADD THESE
        public int DestinationId { get; set; }

        public int Travelers { get; set; }

        public string TripType { get; set; } = string.Empty;

        public List<string> Interests { get; set; } = new();

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<DailyActivity> Activities { get; set; } = new();

        public List<PackingItem> PackingItems { get; set; } = new();
    }

    public class DailyActivity
    {
        public int Id { get; set; }

        public int ItineraryId { get; set; }

        public int DayNumber { get; set; }

        public string Description { get; set; } = string.Empty;

        public Itinerary Itinerary { get; set; } = null!;
    }
}