using Microsoft.EntityFrameworkCore;
using DunesOfArabia.Data;
using DunesOfArabia.Models;

namespace DunesOfArabia.Services
{
    // ═══════════════════════════════════════════════════════
    // ACTIVITY SERVICE
    // ═══════════════════════════════════════════════════════

    public interface IActivityService
    {
        Task<List<Activity>> GetAllAsync();
        Task<Activity?> GetByIdAsync(int id);
        Task<List<Activity>> GetByDestinationAsync(int destinationId);
        Task<List<Activity>> GetByDestinationIdAsync(int destinationId); // alias some pages call
        Task<Activity> CreateAsync(CreateActivityDto dto);
        Task<Activity?> UpdateAsync(int id, UpdateActivityDto dto);
        Task DeleteAsync(int id);
    }

    public class ActivityService : IActivityService
    {
        private readonly AppDbContext _db;
        public ActivityService(AppDbContext db) { _db = db; }

        public async Task<List<Activity>> GetAllAsync()
            => await _db.Activities.ToListAsync();

        public async Task<Activity?> GetByIdAsync(int id)
            => await _db.Activities.FindAsync(id);

        public async Task<List<Activity>> GetByDestinationAsync(int destinationId)
            => await _db.Activities
                .Where(a => a.DestinationId == destinationId)
                .ToListAsync();

        // Alias — some Blazor pages call GetByDestinationIdAsync
        public Task<List<Activity>> GetByDestinationIdAsync(int destinationId)
            => GetByDestinationAsync(destinationId);

        public async Task<Activity> CreateAsync(CreateActivityDto dto)
        {
            var activity = new Activity
            {
                DestinationId = dto.DestinationId,
                Name = dto.Name,
                Description = dto.Description,
                DurationHours = dto.DurationHours,
                PriceSAR = dto.PriceSAR,
                Category = dto.Category,
                ImageUrl = dto.ImageUrl
            };
            _db.Activities.Add(activity);
            await _db.SaveChangesAsync();
            return activity;
        }

        public async Task<Activity?> UpdateAsync(int id, UpdateActivityDto dto)
        {
            var activity = await _db.Activities.FindAsync(id);
            if (activity is null) return null;

            if (dto.Name is not null) activity.Name = dto.Name;
            if (dto.Description is not null) activity.Description = dto.Description;
            if (dto.DurationHours is not null) activity.DurationHours = dto.DurationHours.Value;
            if (dto.PriceSAR is not null) activity.PriceSAR = dto.PriceSAR.Value;
            if (dto.Category is not null) activity.Category = dto.Category;
            if (dto.ImageUrl is not null) activity.ImageUrl = dto.ImageUrl;

            await _db.SaveChangesAsync();
            return activity;
        }

        public async Task DeleteAsync(int id)
        {
            var activity = await _db.Activities.FindAsync(id);
            if (activity is null) return;
            _db.Activities.Remove(activity);
            await _db.SaveChangesAsync();
        }
    }

    public record CreateActivityDto(
        int DestinationId,
        string Name,
        string Description,
        decimal DurationHours,
        decimal PriceSAR,
        string Category,
        string ImageUrl
    );

    public record UpdateActivityDto(
        string? Name,
        string? Description,
        decimal? DurationHours,
        decimal? PriceSAR,
        string? Category,
        string? ImageUrl
    );


    // ═══════════════════════════════════════════════════════
    // ITINERARY SERVICE
    // ═══════════════════════════════════════════════════════

    public interface IItineraryService
    {
        Task<List<Itinerary>> GetByUserIdAsync(string userId);
        Task<Itinerary?> GetByIdAsync(int id);
        Task<Itinerary> CreateAsync(string userId, CreateItineraryDto dto);
        Task<Itinerary?> UpdateAsync(int id, UpdateItineraryDto dto);
        Task DeleteAsync(int id);
        Task<List<Itinerary>> GetAllAsync();
        Task<List<Itinerary>> GetUserItinerariesAsync(string userId);
        Task<Itinerary> CreateAsync(Itinerary itinerary);
        Task<Itinerary> SaveAsync(Itinerary itinerary);
        Task<bool> AddActivityAsync(int itineraryId, DailyActivity activity);
        Task<bool> AddPackingItemAsync(int itineraryId, PackingItem item);
        Task<bool> TogglePackingItemAsync(int itemId);
        Task<bool> DeleteAsync(int id, string userId);
    }

    public class ItineraryService : IItineraryService
    {
        private readonly AppDbContext _db;
        public ItineraryService(AppDbContext db) { _db = db; }

        public async Task<List<Itinerary>> GetAllAsync()
            => await _db.Itineraries
                .Include(i => i.Activities)
                .Include(i => i.PackingItems)
                .ToListAsync();

        public Task<List<Itinerary>> GetByUserIdAsync(string userId)
            => GetUserItinerariesAsync(userId);

        public async Task<List<Itinerary>> GetUserItinerariesAsync(string userId)
            => await _db.Itineraries
                .Include(i => i.Activities)
                .Include(i => i.PackingItems)
                .Where(i => i.UserId == userId)
                .ToListAsync();

        public async Task<Itinerary?> GetByIdAsync(int id)
            => await _db.Itineraries
                .Include(i => i.Activities)
                .Include(i => i.PackingItems)
                .FirstOrDefaultAsync(i => i.Id == id);

        public async Task<Itinerary> CreateAsync(string userId, CreateItineraryDto dto)
        {
            var itinerary = new Itinerary
            {
                UserId = userId,
                Title = dto.Title,
                DestinationId = dto.DestinationId,
                Travelers = dto.Travelers,
                TripType = dto.TripType,
                Interests = dto.Interests,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate
            };
            return await CreateAsync(itinerary);
        }

        public async Task<Itinerary> CreateAsync(Itinerary itinerary)
        {
            _db.Itineraries.Add(itinerary);
            await _db.SaveChangesAsync();
            return itinerary;
        }

        public async Task<Itinerary?> UpdateAsync(int id, UpdateItineraryDto dto)
        {
            var itinerary = await _db.Itineraries.FindAsync(id);
            if (itinerary is null) return null;

            if (dto.Title is not null) itinerary.Title = dto.Title;
            if (dto.Travelers is not null) itinerary.Travelers = dto.Travelers.Value;
            if (dto.TripType is not null) itinerary.TripType = dto.TripType;
            if (dto.Interests is not null) itinerary.Interests = dto.Interests;
            if (dto.StartDate is not null) itinerary.StartDate = dto.StartDate.Value;
            if (dto.EndDate is not null) itinerary.EndDate = dto.EndDate.Value;

            await _db.SaveChangesAsync();
            return itinerary;
        }

        public async Task<Itinerary> SaveAsync(Itinerary itinerary)
        {
            if (itinerary.Id == 0) _db.Itineraries.Add(itinerary);
            else _db.Itineraries.Update(itinerary);
            await _db.SaveChangesAsync();
            return itinerary;
        }

        public async Task DeleteAsync(int id)
        {
            var itinerary = await _db.Itineraries.FindAsync(id);
            if (itinerary is null) return;
            _db.Itineraries.Remove(itinerary);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id, string userId)
        {
            var itinerary = await _db.Itineraries
                .FirstOrDefaultAsync(i => i.Id == id && i.UserId == userId);
            if (itinerary is null) return false;
            _db.Itineraries.Remove(itinerary);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddActivityAsync(int itineraryId, DailyActivity activity)
        {
            if (await _db.Itineraries.FindAsync(itineraryId) is null) return false;
            activity.ItineraryId = itineraryId;
            _db.DailyActivities.Add(activity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddPackingItemAsync(int itineraryId, PackingItem item)
        {
            if (await _db.Itineraries.FindAsync(itineraryId) is null) return false;
            item.ItineraryId = itineraryId;
            _db.PackingItems.Add(item);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> TogglePackingItemAsync(int itemId)
        {
            var item = await _db.PackingItems.FindAsync(itemId);
            if (item is null) return false;
            item.IsPacked = !item.IsPacked;
            await _db.SaveChangesAsync();
            return true;
        }
    }

    public record CreateItineraryDto(
        string Title,
        int DestinationId,
        int Travelers,
        string TripType,
        List<string> Interests,
        DateTime StartDate,
        DateTime EndDate
    );

    public record UpdateItineraryDto(
        string? Title,
        int? Travelers,
        string? TripType,
        List<string>? Interests,
        DateTime? StartDate,
        DateTime? EndDate
    );


    // ═══════════════════════════════════════════════════════
    // USER FAVORITE SERVICE
    // ═══════════════════════════════════════════════════════

    public interface IUserFavoriteService
    {
        Task<List<UserFavorite>> GetUserFavoritesAsync(string userId);

        // Alias method for compatibility
        Task<List<UserFavorite>> GetFavoritesByUserAsync(string userId);

        Task<bool> AddFavoriteAsync(string userId, int destinationId);
        Task<bool> RemoveFavoriteAsync(string userId, int destinationId);
        Task<bool> IsFavoriteAsync(string userId, int destinationId);
    }

    public class UserFavoriteService : IUserFavoriteService
    {
        private readonly AppDbContext _db;

        public UserFavoriteService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<UserFavorite>> GetUserFavoritesAsync(string userId)
            => await _db.UserFavorites
                .Where(f => f.UserId == userId)
                .ToListAsync();

        // Alias implementation
        public Task<List<UserFavorite>> GetFavoritesByUserAsync(string userId)
            => GetUserFavoritesAsync(userId);

        public async Task<bool> AddFavoriteAsync(string userId, int destinationId)
        {
            if (await _db.UserFavorites.AnyAsync(
                    f => f.UserId == userId && f.DestinationId == destinationId))
                return false;

            _db.UserFavorites.Add(new UserFavorite
            {
                UserId = userId,
                DestinationId = destinationId
            });

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveFavoriteAsync(string userId, int destinationId)
        {
            var fav = await _db.UserFavorites
                .FirstOrDefaultAsync(
                    f => f.UserId == userId && f.DestinationId == destinationId);

            if (fav is null)
                return false;

            _db.UserFavorites.Remove(fav);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> IsFavoriteAsync(string userId, int destinationId)
            => await _db.UserFavorites
                .AnyAsync(
                    f => f.UserId == userId && f.DestinationId == destinationId);
    }

    // ═══════════════════════════════════════════════════════
    // COMPLAINT SERVICE
    // ═══════════════════════════════════════════════════════

    public interface IComplaintService
    {
        Task<List<Complaint>> GetUserComplaintsAsync(string userId);
        Task<List<Complaint>> GetAllComplaintsAsync();
        Task<Complaint> SubmitComplaintAsync(Complaint complaint);
        Task<bool> RespondAsync(int id, string adminResponse);
        Task<bool> ResolveAsync(int id);
    }

    public class ComplaintService : IComplaintService
    {
        private readonly AppDbContext _db;
        public ComplaintService(AppDbContext db) { _db = db; }

        public async Task<List<Complaint>> GetUserComplaintsAsync(string userId)
            => await _db.Complaints
                .Where(c => c.UserId == userId)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();

        public async Task<List<Complaint>> GetAllComplaintsAsync()
            => await _db.Complaints.OrderByDescending(c => c.CreatedAt).ToListAsync();

        public async Task<Complaint> SubmitComplaintAsync(Complaint complaint)
        {
            complaint.Status = "Open";
            complaint.CreatedAt = DateTime.UtcNow;
            _db.Complaints.Add(complaint);
            await _db.SaveChangesAsync();
            return complaint;
        }

        public async Task<bool> RespondAsync(int id, string adminResponse)
        {
            var complaint = await _db.Complaints.FindAsync(id);
            if (complaint is null) return false;
            complaint.AdminResponse = adminResponse;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ResolveAsync(int id)
        {
            var complaint = await _db.Complaints.FindAsync(id);
            if (complaint is null) return false;
            complaint.Status = "Resolved";
            complaint.ResolvedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}