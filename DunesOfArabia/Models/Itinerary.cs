namespace DunesOfArabia.Models
{
    public class Itinerary
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
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
        public string Description { get; set; }
    }
}