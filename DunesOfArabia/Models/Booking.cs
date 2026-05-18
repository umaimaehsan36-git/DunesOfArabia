namespace DunesOfArabia.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        public int DestinationId { get; set; }

        // Navigation property — loaded via .Include() in BookingService
        public Destination? Destination { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Status { get; set; } = "Pending";

        public int NumberOfTravelers { get; set; } = 1;

        public decimal Subtotal { get; set; }

        public decimal Tax { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal DiscountAmount { get; set; }

        public string PaymentMethod { get; set; } = string.Empty;

        public string StripePaymentIntentId { get; set; } = string.Empty;

        // Alias used by some pages as "TransactionId"
        public string TransactionId => StripePaymentIntentId;

        public string ConfirmationNumber { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Province { get; set; } = string.Empty;

        public string PostalCode { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Alias used by some pages as "CreatedDate"
        public DateTime CreatedDate => CreatedAt;

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
        public Booking Booking { get; set; } = null!;
    }
}