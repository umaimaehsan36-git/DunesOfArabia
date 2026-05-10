using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DunesOfArabia.Models;

namespace DunesOfArabia.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Destination> Destinations => Set<Destination>();
        public DbSet<UserFavorite> UserFavorites => Set<UserFavorite>();
        public DbSet<Itinerary> Itineraries => Set<Itinerary>();
        public DbSet<DailyActivity> DailyActivities => Set<DailyActivity>();
        public DbSet<PackingItem> PackingItems => Set<PackingItem>();
        public DbSet<Booking> Bookings => Set<Booking>();
        public DbSet<BookingDocument> BookingDocuments => Set<BookingDocument>();
        public DbSet<Review> Reviews => Set<Review>();
        public DbSet<Activity> Activities => Set<Activity>();
        public DbSet<Complaint> Complaints => Set<Complaint>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // IMPORTANT FIX: Configure PhoneNumber as nullable to prevent NULL insert errors
            modelBuilder.Entity<ApplicationUser>()
                .Property(u => u.PhoneNumber)
                .IsRequired(false);

            // FIX: HasOne(d => d.Booking) instead of HasOne<Booking>()
            // prevents EF from generating duplicate shadow FK BookingId1
            modelBuilder.Entity<BookingDocument>()
                .HasOne(d => d.Booking)
                .WithMany(b => b.Documents)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            // FIX: HasOne(a => a.Itinerary) instead of HasOne<Itinerary>()
            // prevents EF from generating duplicate shadow FK ItineraryId1
            modelBuilder.Entity<DailyActivity>()
                .HasOne(a => a.Itinerary)
                .WithMany(i => i.Activities)
                .HasForeignKey(a => a.ItineraryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Itinerary -> PackingItem (one-to-many)
            modelBuilder.Entity<PackingItem>()
                .HasOne<Itinerary>()
                .WithMany(i => i.PackingItems)
                .HasForeignKey(p => p.ItineraryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Activity -> Destination (many-to-one)
            modelBuilder.Entity<Activity>()
                .HasOne<Destination>()
                .WithMany()
                .HasForeignKey(a => a.DestinationId)
                .OnDelete(DeleteBehavior.Cascade);

            // Review -> Destination (many-to-one)
            modelBuilder.Entity<Review>()
                .HasOne<Destination>()
                .WithMany()
                .HasForeignKey(r => r.DestinationId)
                .OnDelete(DeleteBehavior.Cascade);

            // UserFavorite -> Destination (many-to-one)
            modelBuilder.Entity<UserFavorite>()
                .HasOne<Destination>()
                .WithMany()
                .HasForeignKey(uf => uf.DestinationId)
                .OnDelete(DeleteBehavior.Cascade);

            // Booking -> Destination (many-to-one)
            modelBuilder.Entity<Booking>()
                .HasOne<Destination>()
                .WithMany()
                .HasForeignKey(b => b.DestinationId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed data
            modelBuilder.Entity<Destination>().HasData(
                new Destination
                {
                    Id = 1,
                    Name = "AlUla",
                    Province = "Medina",
                    Category = "Historical",
                    Description = "Ancient city with Nabatean ruins",
                    ImageUrl = "alula.jpg",
                    Latitude = 26.61,
                    Longitude = 37.92,
                    Cost = 500,
                    Climate = "Hot, Dry",
                    VisaInfo = "Tourist Visa Available"
                },
                new Destination
                {
                    Id = 2,
                    Name = "Edge of the World",
                    Province = "Riyadh",
                    Category = "Nature",
                    Description = "Dramatic cliff with panoramic views",
                    ImageUrl = "edge.jpg",
                    Latitude = 24.67,
                    Longitude = 45.67,
                    Cost = 200,
                    Climate = "Hot",
                    VisaInfo = "Tourist Visa Available"
                }
            );
        }
    }
}