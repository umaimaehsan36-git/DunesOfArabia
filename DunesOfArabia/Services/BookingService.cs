using Microsoft.EntityFrameworkCore;
using DunesOfArabia.Data;
using DunesOfArabia.Models;

namespace DunesOfArabia.Services
{
    public interface IBookingService
    {
        Task<List<Booking>> GetByUserIdAsync(string userId);
        Task<List<Booking>> GetUserBookingsAsync(string userId);   // alias some pages call
        Task<List<Booking>> GetAllAsync();                         // alias some pages call
        Task<List<Booking>> GetAllBookingsAsync();
        Task<Booking?> GetByIdAsync(int id);
        Task<Booking> CreateAsync(string userId, CreateBookingDto dto);
        Task CancelAsync(int id);
        Task<bool> UpdateStatusAsync(int id, string status);
        Task<bool> CancelAsync(int id, string userId);
        Task<bool> AddDocumentAsync(int bookingId, BookingDocument document);
    }

    public class BookingService : IBookingService
    {
        private readonly AppDbContext _db;
        public BookingService(AppDbContext db) { _db = db; }

        public Task<List<Booking>> GetByUserIdAsync(string userId)
            => GetUserBookingsAsync(userId);

        public async Task<List<Booking>> GetUserBookingsAsync(string userId)
            => await _db.Bookings
                .Include(b => b.Destination)
                .Include(b => b.Documents)
                .Where(b => b.UserId == userId)
                .OrderByDescending(b => b.StartDate)
                .ToListAsync();

        // GetAllAsync — alias that some Blazor admin pages call
        public Task<List<Booking>> GetAllAsync()
            => GetAllBookingsAsync();

        public async Task<List<Booking>> GetAllBookingsAsync()
            => await _db.Bookings
                .Include(b => b.Destination)
                .Include(b => b.Documents)
                .OrderByDescending(b => b.StartDate)
                .ToListAsync();

        public async Task<Booking?> GetByIdAsync(int id)
            => await _db.Bookings
                .Include(b => b.Destination)
                .Include(b => b.Documents)
                .FirstOrDefaultAsync(b => b.Id == id);

        public async Task<Booking> CreateAsync(string userId, CreateBookingDto dto)
        {
            var booking = new Booking
            {
                UserId = userId,
                DestinationId = dto.DestinationId,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Status = "Pending"
            };
            _db.Bookings.Add(booking);
            await _db.SaveChangesAsync();
            return booking;
        }

        public async Task CancelAsync(int id)
        {
            var booking = await _db.Bookings.FindAsync(id);
            if (booking is null) return;
            booking.Status = "Cancelled";
            await _db.SaveChangesAsync();
        }

        public async Task<bool> UpdateStatusAsync(int id, string status)
        {
            var booking = await _db.Bookings.FindAsync(id);
            if (booking is null) return false;
            booking.Status = status;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CancelAsync(int id, string userId)
        {
            var booking = await _db.Bookings
                .FirstOrDefaultAsync(b => b.Id == id && b.UserId == userId);
            if (booking is null) return false;
            if (booking.Status == "Completed") return false;
            booking.Status = "Cancelled";
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddDocumentAsync(int bookingId, BookingDocument document)
        {
            if (await _db.Bookings.FindAsync(bookingId) is null) return false;
            document.BookingId = bookingId;
            document.UploadedAt = DateTime.UtcNow;
            _db.BookingDocuments.Add(document);
            await _db.SaveChangesAsync();
            return true;
        }
    }

    // ─────────────────────────────────────────────────────
    // DTO
    // ─────────────────────────────────────────────────────

    public record CreateBookingDto(
        int DestinationId,
        DateTime StartDate,
        DateTime EndDate
    );
}