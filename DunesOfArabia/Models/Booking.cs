namespace DunesOfArabia.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int DestinationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } = "Pending";
        public decimal TotalPrice { get; set; }
        public string StripePaymentIntentId { get; set; } = string.Empty;
        public List<BookingDocument> Documents { get; set; } = new();
    }

    public class BookingDocument
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public string FileType { get; set; } = string.Empty;
        public DateTime UploadedAt { get; set; }

        // FIX #7: Added back-navigation property so EF Core can correctly
        // resolve the one-to-many relationship with Booking.
        // Without this, migrations may create the FK on the wrong table
        // or not create it at all.
        public Booking Booking { get; set; } = null!;
    }
}