namespace DunesOfArabia.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int DestinationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } = "Pending";
        public decimal TotalPrice { get; set; }
        public string StripePaymentIntentId { get; set; }
        public List<BookingDocument> Documents { get; set; } = new();
    }

    public class BookingDocument
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}