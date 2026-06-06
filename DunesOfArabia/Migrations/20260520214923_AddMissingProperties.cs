using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DunesOfArabia.Migrations
{
    /// <inheritdoc />
    public partial class AddMissingProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackingItems_Itineraries_ItineraryId",
                table: "PackingItems");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Destinations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Destinations",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<string>(
                name: "ImageGallery",
                table: "Destinations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "CancellationPolicy", "Category", "Description", "DestinationId", "DestinationId1", "DifficultyLevel", "DurationHours", "ImageUrl", "IncludedServices", "MaxParticipants", "MinAge", "Name", "OperatorEmail", "OperatorName", "OperatorPhone", "PriceSAR", "Rating" },
                values: new object[] { 6, "", "Cultural", "Explore labyrinthine souqs, taste local spices, and shop handcrafted Saudi treasures.", 2, null, "", 2m, "https://images.unsplash.com/photo-1578662996442-48f60103fc96?w=700", "", 20, 0, "Traditional Souq Experience", "", "", "", 70m, 0.0 });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BestSeason", "Category", "Climate", "Cost", "CreatedAt", "CreatedDate", "Description", "HighlightsJson", "ImageGallery", "ImageUrl", "Latitude", "Longitude", "Name", "Province", "Rating", "Temperature" },
                values: new object[] { "November to February", "Urban", "Hot, Arid", 800m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "The modern capital blending innovation with rich cultural heritage and historic landmarks.", "[]", "[]", "https://images.unsplash.com/photo-1586724237569-f3d0c1dee8c6?w=800", 24.6877, 46.721899999999998, "Riyadh", "Central Region", 4.7999999999999998, "20°C – 45°C" });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BestSeason", "Category", "Climate", "Cost", "CreatedAt", "CreatedDate", "Description", "HighlightsJson", "ImageGallery", "ImageUrl", "Latitude", "Longitude", "Name", "Province", "Rating", "Temperature" },
                values: new object[] { "October to April", "Coastal", "Hot, Humid", 700m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Historic port city with beautiful coastline, vibrant culture, and world-class diving.", "[]", "[]", "https://images.unsplash.com/photo-1539667284076-a4d98d9ac42b?w=800", 21.485800000000001, 39.192500000000003, "Jeddah", "Red Sea Coast", 4.7000000000000002, "22°C – 40°C" });

            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "Id", "BestSeason", "Category", "Climate", "Cost", "CreatedAt", "CreatedDate", "Description", "HighlightsJson", "ImageGallery", "ImageGalleryJson", "ImageUrl", "Latitude", "Longitude", "Name", "Province", "Rating", "Temperature", "VisaInfo" },
                values: new object[,]
                {
                    { 3, "October to March", "Historical", "Hot, Dry", 1200m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ancient rock formations and UNESCO World Heritage sites in a stunning desert landscape.", "[]", "[]", "", "https://images.unsplash.com/photo-1616236197457-53e96373d0b0?w=800", 26.609999999999999, 37.920000000000002, "AlUla", "Al Madinah Region", 4.9000000000000004, "10°C – 38°C", "Tourist Visa Available" },
                    { 4, "November to February", "Historical", "Hot, Arid", 500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "The birthplace of the Kingdom with beautifully preserved mud-brick architecture.", "[]", "[]", "", "https://images.unsplash.com/photo-1578662996442-48f60103fc96?w=800", 24.734400000000001, 46.575400000000002, "Diriyah", "Riyadh Province", 4.5999999999999996, "18°C – 44°C", "Tourist Visa Available" },
                    { 5, "October to March", "Historical", "Hot, Dry", 950m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Saudi Arabia's first UNESCO World Heritage Site with breathtaking Nabataean tombs carved into sandstone.", "[]", "[]", "", "https://images.unsplash.com/photo-1591604466107-ec97de577aff?w=800", 26.791399999999999, 37.9529, "Hegra (Mada'in Saleh)", "Al Madinah Region", 4.7999999999999998, "10°C – 38°C", "Tourist Visa Available" },
                    { 6, "October to March", "Historical", "Hot, Dry", 600m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "A labyrinth of mud-brick houses dating back 2,000 years, abandoned and eerily preserved in the desert.", "[]", "[]", "", "https://images.unsplash.com/photo-1526392060635-9d6019884377?w=800", 26.587, 37.916800000000002, "Al Ula Old Town", "Al Madinah Region", 4.5, "10°C – 38°C", "Tourist Visa Available" },
                    { 7, "November to February", "Desert", "Extremely Hot, Arid", 1100m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "The world's largest continuous sand desert offering unparalleled adventure experiences.", "[]", "[]", "", "https://images.unsplash.com/photo-1509316785289-025f5b846b35?w=800", 20.0, 50.0, "Empty Quarter", "Southern Saudi Arabia", 4.5, "15°C – 50°C", "Tourist Visa Available" },
                    { 8, "October to April", "Desert", "Hot, Dry", 900m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Dramatic red-sand valleys and towering sandstone pillars stretching to the horizon.", "[]", "[]", "", "https://images.unsplash.com/photo-1519671282429-b44b0de7773e?w=800", 29.575500000000002, 35.423699999999997, "Wadi Rum", "Tabuk Region", 4.7000000000000002, "10°C – 38°C", "Tourist Visa Available" },
                    { 9, "November to March", "Desert", "Hot, Arid", 750m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Vast crescent-shaped dunes with striking reddish-orange sands unique to northern Arabia.", "[]", "[]", "", "https://images.unsplash.com/photo-1542401886-65d6c61db217?w=800", 28.0, 41.0, "Al Nafud Desert", "Northern Region", 4.2999999999999998, "8°C – 42°C", "Tourist Visa Available" },
                    { 10, "April to October", "Mountain", "Mild, Temperate", 650m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Lush green mountains with a cooler climate, terraced farms, and breathtaking natural landscapes.", "[]", "[]", "", "https://images.unsplash.com/photo-1464822759023-fed622ff2c3b?w=800", 18.2164, 42.505299999999998, "Asir Mountains", "Southwestern Saudi Arabia", 4.7000000000000002, "12°C – 30°C", "Tourist Visa Available" },
                    { 11, "March to October", "Mountain", "Mild", 400m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mountain resort city famous for its rose gardens, cool summer retreats, and pleasant weather year-round.", "[]", "[]", "", "https://images.unsplash.com/photo-1558618666-fcd25c85cd64?w=800", 21.270299999999999, 40.415799999999997, "Taif", "Makkah Province", 4.4000000000000004, "15°C – 35°C", "Tourist Visa Available" },
                    { 12, "October to April", "Nature", "Hot, Humid", 850m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Pristine coral reefs, crystal-clear waters, and rare wildlife in a protected Red Sea marine reserve.", "[]", "[]", "", "https://images.unsplash.com/photo-1559827260-dc66d52bef19?w=800", 16.699999999999999, 41.966700000000003, "Farasan Islands", "Jizan Region", 4.5999999999999996, "24°C – 38°C", "Tourist Visa Available" },
                    { 13, "November to February", "Nature", "Hot, Arid", 350m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "The world's largest oasis with sprawling date palm gardens and natural artesian springs.", "[]", "[]", "", "https://images.unsplash.com/photo-1501854140801-50d01698950b?w=800", 25.381399999999999, 49.586399999999998, "Al-Ahsa Oasis", "Eastern Province", 4.2999999999999998, "12°C – 45°C", "Tourist Visa Available" },
                    { 14, "October to April", "Coastal", "Hot, Humid", 2200m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Pristine islands and turquoise waters home to a new world-class luxury eco-tourism destination.", "[]", "[]", "", "https://images.unsplash.com/photo-1505118380757-91f5f5632de0?w=800", 28.0, 35.149999999999999, "Red Sea Project", "Western Coast", 4.7999999999999998, "22°C – 38°C", "Tourist Visa Available" },
                    { 15, "October to April", "Coastal", "Hot, Humid", 500m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "A laid-back Red Sea city with beautiful coral reefs, clear waters, and a charming historic old town.", "[]", "[]", "", "https://images.unsplash.com/photo-1544551763-46a013bb70d5?w=800", 24.089300000000001, 38.061799999999998, "Yanbu", "Al Madinah Region", 4.2000000000000002, "20°C – 40°C", "Tourist Visa Available" },
                    { 16, "November to March", "Coastal", "Hot, Humid", 300m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Vibrant waterfront promenade with fresh seafood, mangrove walks, and island day trips.", "[]", "[]", "", "https://images.unsplash.com/photo-1507525428034-b723cf961d3e?w=800", 16.889199999999999, 42.551099999999998, "Jizan Corniche", "Jizan Region", 4.0999999999999996, "22°C – 38°C", "Tourist Visa Available" },
                    { 17, "November to March", "Urban", "Hot, Humid", 550m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "A modern city on the Arabian Gulf known for its waterfront promenade and cosmopolitan dining.", "[]", "[]", "", "https://images.unsplash.com/photo-1477959858617-67f85cf4f1df?w=800", 26.217199999999998, 50.197099999999999, "Al Khobar", "Eastern Province", 4.2000000000000002, "18°C – 42°C", "Tourist Visa Available" },
                    { 18, "October to April", "Urban", "Hot, Arid", 1800m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "The future city of Saudi Arabia — a futuristic mega-project amidst dramatic desert and coastal scenery.", "[]", "[]", "", "https://images.unsplash.com/photo-1486325212027-8081e485255e?w=800", 28.033899999999999, 35.513599999999997, "NEOM & Tabuk Region", "Tabuk Region", 4.5999999999999996, "15°C – 40°C", "Tourist Visa Available" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "CancellationPolicy", "Category", "Description", "DestinationId", "DestinationId1", "DifficultyLevel", "DurationHours", "ImageUrl", "IncludedServices", "MaxParticipants", "MinAge", "Name", "OperatorEmail", "OperatorName", "OperatorPhone", "PriceSAR", "Rating" },
                values: new object[,]
                {
                    { 1, "", "Adventure", "Experience the best of AlUla with a combination of archaeological tours, desert adventures, and cultural immersion.", 3, null, "", 8m, "https://images.unsplash.com/photo-1616236197457-53e96373d0b0?w=900", "", 20, 0, "AlUla Heritage & Adventure Combo", "", "", "", 350m, 0.0 },
                    { 2, "", "Adventure", "Thrilling off-road desert adventure through vast golden dunes with expert guides and traditional refreshments.", 7, null, "", 5m, "https://images.unsplash.com/photo-1509316785289-025f5b846b35?w=700", "", 20, 0, "Desert Safari", "", "", "", 150m, 0.0 },
                    { 3, "", "Adventure", "Scale spectacular sandstone formations and canyon walls with certified climbing instructors.", 8, null, "", 3m, "https://images.unsplash.com/photo-1504280390367-361c6d9f38f4?w=700", "", 20, 0, "Rock Climbing", "", "", "", 120m, 0.0 },
                    { 4, "", "Adventure", "Heart-pumping 4x4 ride across towering dunes in the vast Empty Quarter desert.", 7, null, "", 2m, "https://images.unsplash.com/photo-1542401886-65d6c61db217?w=700", "", 20, 0, "Dune Bashing", "", "", "", 100m, 0.0 },
                    { 5, "", "Cultural", "Guided walk through Diriyah's ancient mud-brick At-Turaif district with a local historian.", 4, null, "", 3m, "https://images.unsplash.com/photo-1539667284076-a4d98d9ac42b?w=700", "", 20, 0, "Heritage Walking Tour", "", "", "", 90m, 0.0 },
                    { 7, "", "Cultural", "Walk among Nabataean tombs and ancient inscriptions at AlUla's UNESCO World Heritage sites.", 3, null, "", 4m, "https://images.unsplash.com/photo-1591604466107-ec97de577aff?w=700", "", 20, 0, "Archaeological Site Visit", "", "", "", 110m, 0.0 },
                    { 8, "", "Water", "Dive into pristine Red Sea coral reefs teeming with vibrant marine life and stunning underwater formations.", 12, null, "", 3m, "https://images.unsplash.com/photo-1564769611905-cd27ee64e59b?w=700", "", 20, 0, "Scuba Diving", "", "", "", 200m, 0.0 },
                    { 9, "", "Water", "Snorkel through crystal-clear waters above spectacular coral gardens and tropical fish.", 12, null, "", 3m, "https://images.unsplash.com/photo-1559827260-dc66d52bef19?w=700", "", 20, 0, "Snorkeling Adventure", "", "", "", 90m, 0.0 },
                    { 10, "", "Desert", "Ride through golden sands atop a camel as the desert sun paints the dunes a brilliant crimson.", 7, null, "", 2m, "https://images.unsplash.com/photo-1549880338-65ddcdfd017b?w=700", "", 20, 0, "Camel Trekking", "", "", "", 100m, 0.0 },
                    { 11, "", "Desert", "Witness a breathtaking canopy of stars far from city lights, deep in the Arabian desert.", 9, null, "", 2m, "https://images.unsplash.com/photo-1446941303997-2843d7b4d20f?w=700", "", 20, 0, "Stargazing Experience", "", "", "", 80m, 0.0 },
                    { 12, "", "Desert", "Spend an evening in a traditional Bedouin camp with dinner, cultural music, and desert tales.", 9, null, "", 8m, "https://images.unsplash.com/photo-1519671282429-b44b0de7773e?w=700", "", 20, 0, "Bedouin Camp Experience", "", "", "", 180m, 0.0 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PackingItems_Itineraries_ItineraryId",
                table: "PackingItems",
                column: "ItineraryId",
                principalTable: "Itineraries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackingItems_Itineraries_ItineraryId",
                table: "PackingItems");

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "ImageGallery",
                table: "Destinations");

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BestSeason", "Category", "Climate", "Cost", "Description", "HighlightsJson", "ImageUrl", "Latitude", "Longitude", "Name", "Province", "Rating", "Temperature" },
                values: new object[] { "", "Historical", "Hot, Dry", 500m, "Ancient city with Nabatean ruins", "", "alula.jpg", 26.609999999999999, 37.920000000000002, "AlUla", "Medina", 0.0, "" });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BestSeason", "Category", "Climate", "Cost", "Description", "HighlightsJson", "ImageUrl", "Latitude", "Longitude", "Name", "Province", "Rating", "Temperature" },
                values: new object[] { "", "Nature", "Hot", 200m, "Dramatic cliff with panoramic views", "", "edge.jpg", 24.670000000000002, 45.670000000000002, "Edge of the World", "Riyadh", 0.0, "" });

            migrationBuilder.AddForeignKey(
                name: "FK_PackingItems_Itineraries_ItineraryId",
                table: "PackingItems",
                column: "ItineraryId",
                principalTable: "Itineraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
