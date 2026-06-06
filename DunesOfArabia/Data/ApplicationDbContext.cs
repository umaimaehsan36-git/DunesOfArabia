using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DunesOfArabia.Models;
using System.Text.Json;

namespace DunesOfArabia.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Destination>     Destinations     => Set<Destination>();
        public DbSet<UserFavorite>    UserFavorites    => Set<UserFavorite>();
        public DbSet<Itinerary>       Itineraries      => Set<Itinerary>();
        public DbSet<DailyActivity>   DailyActivities  => Set<DailyActivity>();
        public DbSet<PackingItem>     PackingItems     => Set<PackingItem>();
        public DbSet<Booking>         Bookings         => Set<Booking>();
        public DbSet<BookingDocument> BookingDocuments => Set<BookingDocument>();
        public DbSet<Review>          Reviews          => Set<Review>();
        public DbSet<Activity>        Activities       => Set<Activity>();
        public DbSet<Complaint>       Complaints       => Set<Complaint>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ── PhoneNumber nullable ──────────────────────────────────────────
            modelBuilder.Entity<ApplicationUser>()
                .Property(u => u.PhoneNumber)
                .IsRequired(false);

            // ── ImageGallery List<string> → stored as JSON column ─────────────
            modelBuilder.Entity<Destination>()
                .Property(d => d.ImageGallery)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions?)null) ?? new List<string>()
                )
                .HasColumnType("nvarchar(max)");

            // ── CreatedDate — DB supplies the default ─────────────────────────
            modelBuilder.Entity<Destination>()
                .Property(d => d.CreatedDate)
                .HasDefaultValueSql("GETUTCDATE()");

            // ── Relationships ─────────────────────────────────────────────────

            modelBuilder.Entity<BookingDocument>()
                .HasOne(d => d.Booking)
                .WithMany(b => b.Documents)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DailyActivity>()
                .HasOne(a => a.Itinerary)
                .WithMany(i => i.Activities)
                .HasForeignKey(a => a.ItineraryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PackingItem>()
                .HasOne(p => p.Itinerary)
                .WithMany(i => i.PackingItems)
                .HasForeignKey(p => p.ItineraryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Activity>()
                .HasOne<Destination>()
                .WithMany()
                .HasForeignKey(a => a.DestinationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>()
                .HasOne<Destination>()
                .WithMany()
                .HasForeignKey(r => r.DestinationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserFavorite>()
                .HasOne<Destination>()
                .WithMany()
                .HasForeignKey(uf => uf.DestinationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Booking>()
                .HasOne<Destination>()
                .WithMany()
                .HasForeignKey(b => b.DestinationId)
                .OnDelete(DeleteBehavior.Cascade);

            // ── SEED: 18 Destinations ─────────────────────────────────────────
            // ALL non-nullable string fields must be set here.
            // BestSeason, Temperature, HighlightsJson were missing from the
            // original seed — EF requires them for HasData to be stable.
            var seedDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            modelBuilder.Entity<Destination>().HasData(

                new Destination
                {
                    Id             = 1,
                    Name           = "Riyadh",
                    Province       = "Central Region",
                    Category       = "Urban",
                    Rating         = 4.8,
                    Description    = "The modern capital blending innovation with rich cultural heritage and historic landmarks.",
                    ImageUrl       = "https://images.unsplash.com/photo-1586724237569-f3d0c1dee8c6?w=800",
                    Latitude       = 24.6877,
                    Longitude      = 46.7219,
                    Cost           = 800,
                    Climate        = "Hot, Arid",
                    VisaInfo       = "Tourist Visa Available",
                    BestSeason     = "November to February",
                    Temperature    = "20°C – 45°C",
                    HighlightsJson = "[]",
                    CreatedDate    = seedDate
                },
                new Destination
                {
                    Id             = 2,
                    Name           = "Jeddah",
                    Province       = "Red Sea Coast",
                    Category       = "Coastal",
                    Rating         = 4.7,
                    Description    = "Historic port city with beautiful coastline, vibrant culture, and world-class diving.",
                    ImageUrl       = "https://images.unsplash.com/photo-1539667284076-a4d98d9ac42b?w=800",
                    Latitude       = 21.4858,
                    Longitude      = 39.1925,
                    Cost           = 700,
                    Climate        = "Hot, Humid",
                    VisaInfo       = "Tourist Visa Available",
                    BestSeason     = "October to April",
                    Temperature    = "22°C – 40°C",
                    HighlightsJson = "[]",
                    CreatedDate    = seedDate
                },
                new Destination
                {
                    Id             = 3,
                    Name           = "AlUla",
                    Province       = "Al Madinah Region",
                    Category       = "Historical",
                    Rating         = 4.9,
                    Description    = "Ancient rock formations and UNESCO World Heritage sites in a stunning desert landscape.",
                    ImageUrl       = "https://images.unsplash.com/photo-1616236197457-53e96373d0b0?w=800",
                    Latitude       = 26.6100,
                    Longitude      = 37.9200,
                    Cost           = 1200,
                    Climate        = "Hot, Dry",
                    VisaInfo       = "Tourist Visa Available",
                    BestSeason     = "October to March",
                    Temperature    = "10°C – 38°C",
                    HighlightsJson = "[]",
                    CreatedDate    = seedDate
                },
                new Destination
                {
                    Id             = 4,
                    Name           = "Diriyah",
                    Province       = "Riyadh Province",
                    Category       = "Historical",
                    Rating         = 4.6,
                    Description    = "The birthplace of the Kingdom with beautifully preserved mud-brick architecture.",
                    ImageUrl       = "https://images.unsplash.com/photo-1578662996442-48f60103fc96?w=800",
                    Latitude       = 24.7344,
                    Longitude      = 46.5754,
                    Cost           = 500,
                    Climate        = "Hot, Arid",
                    VisaInfo       = "Tourist Visa Available",
                    BestSeason     = "November to February",
                    Temperature    = "18°C – 44°C",
                    HighlightsJson = "[]",
                    CreatedDate    = seedDate
                },
                new Destination
                {
                    Id             = 5,
                    Name           = "Hegra (Mada'in Saleh)",
                    Province       = "Al Madinah Region",
                    Category       = "Historical",
                    Rating         = 4.8,
                    Description    = "Saudi Arabia's first UNESCO World Heritage Site with breathtaking Nabataean tombs carved into sandstone.",
                    ImageUrl       = "https://images.unsplash.com/photo-1591604466107-ec97de577aff?w=800",
                    Latitude       = 26.7914,
                    Longitude      = 37.9529,
                    Cost           = 950,
                    Climate        = "Hot, Dry",
                    VisaInfo       = "Tourist Visa Available",
                    BestSeason     = "October to March",
                    Temperature    = "10°C – 38°C",
                    HighlightsJson = "[]",
                    CreatedDate    = seedDate
                },
                new Destination
                {
                    Id             = 6,
                    Name           = "Al Ula Old Town",
                    Province       = "Al Madinah Region",
                    Category       = "Historical",
                    Rating         = 4.5,
                    Description    = "A labyrinth of mud-brick houses dating back 2,000 years, abandoned and eerily preserved in the desert.",
                    ImageUrl       = "https://images.unsplash.com/photo-1526392060635-9d6019884377?w=800",
                    Latitude       = 26.5870,
                    Longitude      = 37.9168,
                    Cost           = 600,
                    Climate        = "Hot, Dry",
                    VisaInfo       = "Tourist Visa Available",
                    BestSeason     = "October to March",
                    Temperature    = "10°C – 38°C",
                    HighlightsJson = "[]",
                    CreatedDate    = seedDate
                },
                new Destination
                {
                    Id             = 7,
                    Name           = "Empty Quarter",
                    Province       = "Southern Saudi Arabia",
                    Category       = "Desert",
                    Rating         = 4.5,
                    Description    = "The world's largest continuous sand desert offering unparalleled adventure experiences.",
                    ImageUrl       = "https://images.unsplash.com/photo-1509316785289-025f5b846b35?w=800",
                    Latitude       = 20.0000,
                    Longitude      = 50.0000,
                    Cost           = 1100,
                    Climate        = "Extremely Hot, Arid",
                    VisaInfo       = "Tourist Visa Available",
                    BestSeason     = "November to February",
                    Temperature    = "15°C – 50°C",
                    HighlightsJson = "[]",
                    CreatedDate    = seedDate
                },
                new Destination
                {
                    Id             = 8,
                    Name           = "Wadi Rum",
                    Province       = "Tabuk Region",
                    Category       = "Desert",
                    Rating         = 4.7,
                    Description    = "Dramatic red-sand valleys and towering sandstone pillars stretching to the horizon.",
                    ImageUrl       = "https://images.unsplash.com/photo-1519671282429-b44b0de7773e?w=800",
                    Latitude       = 29.5755,
                    Longitude      = 35.4237,
                    Cost           = 900,
                    Climate        = "Hot, Dry",
                    VisaInfo       = "Tourist Visa Available",
                    BestSeason     = "October to April",
                    Temperature    = "10°C – 38°C",
                    HighlightsJson = "[]",
                    CreatedDate    = seedDate
                },
                new Destination
                {
                    Id             = 9,
                    Name           = "Al Nafud Desert",
                    Province       = "Northern Region",
                    Category       = "Desert",
                    Rating         = 4.3,
                    Description    = "Vast crescent-shaped dunes with striking reddish-orange sands unique to northern Arabia.",
                    ImageUrl       = "https://images.unsplash.com/photo-1542401886-65d6c61db217?w=800",
                    Latitude       = 28.0000,
                    Longitude      = 41.0000,
                    Cost           = 750,
                    Climate        = "Hot, Arid",
                    VisaInfo       = "Tourist Visa Available",
                    BestSeason     = "November to March",
                    Temperature    = "8°C – 42°C",
                    HighlightsJson = "[]",
                    CreatedDate    = seedDate
                },
                new Destination
                {
                    Id             = 10,
                    Name           = "Asir Mountains",
                    Province       = "Southwestern Saudi Arabia",
                    Category       = "Mountain",
                    Rating         = 4.7,
                    Description    = "Lush green mountains with a cooler climate, terraced farms, and breathtaking natural landscapes.",
                    ImageUrl       = "https://images.unsplash.com/photo-1464822759023-fed622ff2c3b?w=800",
                    Latitude       = 18.2164,
                    Longitude      = 42.5053,
                    Cost           = 650,
                    Climate        = "Mild, Temperate",
                    VisaInfo       = "Tourist Visa Available",
                    BestSeason     = "April to October",
                    Temperature    = "12°C – 30°C",
                    HighlightsJson = "[]",
                    CreatedDate    = seedDate
                },
                new Destination
                {
                    Id             = 11,
                    Name           = "Taif",
                    Province       = "Makkah Province",
                    Category       = "Mountain",
                    Rating         = 4.4,
                    Description    = "Mountain resort city famous for its rose gardens, cool summer retreats, and pleasant weather year-round.",
                    ImageUrl       = "https://images.unsplash.com/photo-1558618666-fcd25c85cd64?w=800",
                    Latitude       = 21.2703,
                    Longitude      = 40.4158,
                    Cost           = 400,
                    Climate        = "Mild",
                    VisaInfo       = "Tourist Visa Available",
                    BestSeason     = "March to October",
                    Temperature    = "15°C – 35°C",
                    HighlightsJson = "[]",
                    CreatedDate    = seedDate
                },
                new Destination
                {
                    Id             = 12,
                    Name           = "Farasan Islands",
                    Province       = "Jizan Region",
                    Category       = "Nature",
                    Rating         = 4.6,
                    Description    = "Pristine coral reefs, crystal-clear waters, and rare wildlife in a protected Red Sea marine reserve.",
                    ImageUrl       = "https://images.unsplash.com/photo-1559827260-dc66d52bef19?w=800",
                    Latitude       = 16.7000,
                    Longitude      = 41.9667,
                    Cost           = 850,
                    Climate        = "Hot, Humid",
                    VisaInfo       = "Tourist Visa Available",
                    BestSeason     = "October to April",
                    Temperature    = "24°C – 38°C",
                    HighlightsJson = "[]",
                    CreatedDate    = seedDate
                },
                new Destination
                {
                    Id             = 13,
                    Name           = "Al-Ahsa Oasis",
                    Province       = "Eastern Province",
                    Category       = "Nature",
                    Rating         = 4.3,
                    Description    = "The world's largest oasis with sprawling date palm gardens and natural artesian springs.",
                    ImageUrl       = "https://images.unsplash.com/photo-1501854140801-50d01698950b?w=800",
                    Latitude       = 25.3814,
                    Longitude      = 49.5864,
                    Cost           = 350,
                    Climate        = "Hot, Arid",
                    VisaInfo       = "Tourist Visa Available",
                    BestSeason     = "November to February",
                    Temperature    = "12°C – 45°C",
                    HighlightsJson = "[]",
                    CreatedDate    = seedDate
                },
                new Destination
                {
                    Id             = 14,
                    Name           = "Red Sea Project",
                    Province       = "Western Coast",
                    Category       = "Coastal",
                    Rating         = 4.8,
                    Description    = "Pristine islands and turquoise waters home to a new world-class luxury eco-tourism destination.",
                    ImageUrl       = "https://images.unsplash.com/photo-1505118380757-91f5f5632de0?w=800",
                    Latitude       = 28.0000,
                    Longitude      = 35.1500,
                    Cost           = 2200,
                    Climate        = "Hot, Humid",
                    VisaInfo       = "Tourist Visa Available",
                    BestSeason     = "October to April",
                    Temperature    = "22°C – 38°C",
                    HighlightsJson = "[]",
                    CreatedDate    = seedDate
                },
                new Destination
                {
                    Id             = 15,
                    Name           = "Yanbu",
                    Province       = "Al Madinah Region",
                    Category       = "Coastal",
                    Rating         = 4.2,
                    Description    = "A laid-back Red Sea city with beautiful coral reefs, clear waters, and a charming historic old town.",
                    ImageUrl       = "https://images.unsplash.com/photo-1544551763-46a013bb70d5?w=800",
                    Latitude       = 24.0893,
                    Longitude      = 38.0618,
                    Cost           = 500,
                    Climate        = "Hot, Humid",
                    VisaInfo       = "Tourist Visa Available",
                    BestSeason     = "October to April",
                    Temperature    = "20°C – 40°C",
                    HighlightsJson = "[]",
                    CreatedDate    = seedDate
                },
                new Destination
                {
                    Id             = 16,
                    Name           = "Jizan Corniche",
                    Province       = "Jizan Region",
                    Category       = "Coastal",
                    Rating         = 4.1,
                    Description    = "Vibrant waterfront promenade with fresh seafood, mangrove walks, and island day trips.",
                    ImageUrl       = "https://images.unsplash.com/photo-1507525428034-b723cf961d3e?w=800",
                    Latitude       = 16.8892,
                    Longitude      = 42.5511,
                    Cost           = 300,
                    Climate        = "Hot, Humid",
                    VisaInfo       = "Tourist Visa Available",
                    BestSeason     = "November to March",
                    Temperature    = "22°C – 38°C",
                    HighlightsJson = "[]",
                    CreatedDate    = seedDate
                },
                new Destination
                {
                    Id             = 17,
                    Name           = "Al Khobar",
                    Province       = "Eastern Province",
                    Category       = "Urban",
                    Rating         = 4.2,
                    Description    = "A modern city on the Arabian Gulf known for its waterfront promenade and cosmopolitan dining.",
                    ImageUrl       = "https://images.unsplash.com/photo-1477959858617-67f85cf4f1df?w=800",
                    Latitude       = 26.2172,
                    Longitude      = 50.1971,
                    Cost           = 550,
                    Climate        = "Hot, Humid",
                    VisaInfo       = "Tourist Visa Available",
                    BestSeason     = "November to March",
                    Temperature    = "18°C – 42°C",
                    HighlightsJson = "[]",
                    CreatedDate    = seedDate
                },
                new Destination
                {
                    Id             = 18,
                    Name           = "NEOM & Tabuk Region",
                    Province       = "Tabuk Region",
                    Category       = "Urban",
                    Rating         = 4.6,
                    Description    = "The future city of Saudi Arabia — a futuristic mega-project amidst dramatic desert and coastal scenery.",
                    ImageUrl       = "https://images.unsplash.com/photo-1486325212027-8081e485255e?w=800",
                    Latitude       = 28.0339,
                    Longitude      = 35.5136,
                    Cost           = 1800,
                    Climate        = "Hot, Arid",
                    VisaInfo       = "Tourist Visa Available",
                    BestSeason     = "October to April",
                    Temperature    = "15°C – 40°C",
                    HighlightsJson = "[]",
                    CreatedDate    = seedDate
                }
            );

            // ── SEED: 12 Activities ───────────────────────────────────────────
            modelBuilder.Entity<Activity>().HasData(

                new Activity
                {
                    Id            = 1,
                    Name          = "AlUla Heritage & Adventure Combo",
                    Category      = "Adventure",
                    DurationHours = 8M,
                    PriceSAR      = 350,
                    DestinationId = 3,
                    Description   = "Experience the best of AlUla with a combination of archaeological tours, desert adventures, and cultural immersion.",
                    ImageUrl      = "https://images.unsplash.com/photo-1616236197457-53e96373d0b0?w=900",
                    DifficultyLevel = "",
                    OperatorName  = "",
                    OperatorEmail = "",
                    OperatorPhone = "",
                    CancellationPolicy = ""
                },
                new Activity
                {
                    Id            = 2,
                    Name          = "Desert Safari",
                    Category      = "Adventure",
                    DurationHours = 5M,
                    PriceSAR      = 150,
                    DestinationId = 7,
                    Description   = "Thrilling off-road desert adventure through vast golden dunes with expert guides and traditional refreshments.",
                    ImageUrl      = "https://images.unsplash.com/photo-1509316785289-025f5b846b35?w=700",
                    DifficultyLevel = "",
                    OperatorName  = "",
                    OperatorEmail = "",
                    OperatorPhone = "",
                    CancellationPolicy = ""
                },
                new Activity
                {
                    Id            = 3,
                    Name          = "Rock Climbing",
                    Category      = "Adventure",
                    DurationHours = 3M,
                    PriceSAR      = 120,
                    DestinationId = 8,
                    Description   = "Scale spectacular sandstone formations and canyon walls with certified climbing instructors.",
                    ImageUrl      = "https://images.unsplash.com/photo-1504280390367-361c6d9f38f4?w=700",
                    DifficultyLevel = "",
                    OperatorName  = "",
                    OperatorEmail = "",
                    OperatorPhone = "",
                    CancellationPolicy = ""
                },
                new Activity
                {
                    Id            = 4,
                    Name          = "Dune Bashing",
                    Category      = "Adventure",
                    DurationHours = 2M,
                    PriceSAR      = 100,
                    DestinationId = 7,
                    Description   = "Heart-pumping 4x4 ride across towering dunes in the vast Empty Quarter desert.",
                    ImageUrl      = "https://images.unsplash.com/photo-1542401886-65d6c61db217?w=700",
                    DifficultyLevel = "",
                    OperatorName  = "",
                    OperatorEmail = "",
                    OperatorPhone = "",
                    CancellationPolicy = ""
                },
                new Activity
                {
                    Id            = 5,
                    Name          = "Heritage Walking Tour",
                    Category      = "Cultural",
                    DurationHours = 3M,
                    PriceSAR      = 90,
                    DestinationId = 4,
                    Description   = "Guided walk through Diriyah's ancient mud-brick At-Turaif district with a local historian.",
                    ImageUrl      = "https://images.unsplash.com/photo-1539667284076-a4d98d9ac42b?w=700",
                    DifficultyLevel = "",
                    OperatorName  = "",
                    OperatorEmail = "",
                    OperatorPhone = "",
                    CancellationPolicy = ""
                },
                new Activity
                {
                    Id            = 6,
                    Name          = "Traditional Souq Experience",
                    Category      = "Cultural",
                    DurationHours = 2M,
                    PriceSAR      = 70,
                    DestinationId = 2,
                    Description   = "Explore labyrinthine souqs, taste local spices, and shop handcrafted Saudi treasures.",
                    ImageUrl      = "https://images.unsplash.com/photo-1578662996442-48f60103fc96?w=700",
                    DifficultyLevel = "",
                    OperatorName  = "",
                    OperatorEmail = "",
                    OperatorPhone = "",
                    CancellationPolicy = ""
                },
                new Activity
                {
                    Id            = 7,
                    Name          = "Archaeological Site Visit",
                    Category      = "Cultural",
                    DurationHours = 4M,
                    PriceSAR      = 110,
                    DestinationId = 3,
                    Description   = "Walk among Nabataean tombs and ancient inscriptions at AlUla's UNESCO World Heritage sites.",
                    ImageUrl      = "https://images.unsplash.com/photo-1591604466107-ec97de577aff?w=700",
                    DifficultyLevel = "",
                    OperatorName  = "",
                    OperatorEmail = "",
                    OperatorPhone = "",
                    CancellationPolicy = ""
                },
                new Activity
                {
                    Id            = 8,
                    Name          = "Scuba Diving",
                    Category      = "Water",
                    DurationHours = 3M,
                    PriceSAR      = 200,
                    DestinationId = 12,
                    Description   = "Dive into pristine Red Sea coral reefs teeming with vibrant marine life and stunning underwater formations.",
                    ImageUrl      = "https://images.unsplash.com/photo-1564769611905-cd27ee64e59b?w=700",
                    DifficultyLevel = "",
                    OperatorName  = "",
                    OperatorEmail = "",
                    OperatorPhone = "",
                    CancellationPolicy = ""
                },
                new Activity
                {
                    Id            = 9,
                    Name          = "Snorkeling Adventure",
                    Category      = "Water",
                    DurationHours = 3M,
                    PriceSAR      = 90,
                    DestinationId = 12,
                    Description   = "Snorkel through crystal-clear waters above spectacular coral gardens and tropical fish.",
                    ImageUrl      = "https://images.unsplash.com/photo-1559827260-dc66d52bef19?w=700",
                    DifficultyLevel = "",
                    OperatorName  = "",
                    OperatorEmail = "",
                    OperatorPhone = "",
                    CancellationPolicy = ""
                },
                new Activity
                {
                    Id            = 10,
                    Name          = "Camel Trekking",
                    Category      = "Desert",
                    DurationHours = 2M,
                    PriceSAR      = 100,
                    DestinationId = 7,
                    Description   = "Ride through golden sands atop a camel as the desert sun paints the dunes a brilliant crimson.",
                    ImageUrl      = "https://images.unsplash.com/photo-1549880338-65ddcdfd017b?w=700",
                    DifficultyLevel = "",
                    OperatorName  = "",
                    OperatorEmail = "",
                    OperatorPhone = "",
                    CancellationPolicy = ""
                },
                new Activity
                {
                    Id            = 11,
                    Name          = "Stargazing Experience",
                    Category      = "Desert",
                    DurationHours = 2M,
                    PriceSAR      = 80,
                    DestinationId = 9,
                    Description   = "Witness a breathtaking canopy of stars far from city lights, deep in the Arabian desert.",
                    ImageUrl      = "https://images.unsplash.com/photo-1446941303997-2843d7b4d20f?w=700",
                    DifficultyLevel = "",
                    OperatorName  = "",
                    OperatorEmail = "",
                    OperatorPhone = "",
                    CancellationPolicy = ""
                },
                new Activity
                {
                    Id            = 12,
                    Name          = "Bedouin Camp Experience",
                    Category      = "Desert",
                    DurationHours = 8M,
                    PriceSAR      = 180,
                    DestinationId = 9,
                    Description   = "Spend an evening in a traditional Bedouin camp with dinner, cultural music, and desert tales.",
                    ImageUrl      = "https://images.unsplash.com/photo-1519671282429-b44b0de7773e?w=700",
                    DifficultyLevel = "",
                    OperatorName  = "",
                    OperatorEmail = "",
                    OperatorPhone = "",
                    CancellationPolicy = ""
                }
            );
        }
    }
}
