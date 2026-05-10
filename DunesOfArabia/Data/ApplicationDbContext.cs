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

        public DbSet<Destination> Destinations { get; set; }
        public DbSet<UserFavorite> UserFavorites { get; set; }
        public DbSet<Itinerary> Itineraries { get; set; }
        public DbSet<DailyActivity> DailyActivities { get; set; }
        public DbSet<PackingItem> PackingItems { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        // Only keep if this class exists
        public DbSet<BookingDocument> BookingDocuments { get; set; }

        public DbSet<Review> Reviews { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Complaint> Complaints { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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