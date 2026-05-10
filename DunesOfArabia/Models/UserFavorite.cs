namespace DunesOfArabia.Models
{
    public class UserFavorite
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int DestinationId { get; set; }
    }
}