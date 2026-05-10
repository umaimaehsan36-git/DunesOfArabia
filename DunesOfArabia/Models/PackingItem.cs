namespace DunesOfArabia.Models
{
    public class PackingItem
    {
        public int Id { get; set; }
        public int ItineraryId { get; set; }
        public string ItemName { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}