using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DunesOfArabia.Migrations
{
    /// <inheritdoc />
    public partial class AddTripBuddyChatRecipientId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecipientId",
                table: "TripBuddyMessages",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RequesterName",
                table: "TripBuddyJoinRequests",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipientId",
                table: "TripBuddyMessages");

            migrationBuilder.DropColumn(
                name: "RequesterName",
                table: "TripBuddyJoinRequests");
        }
    }
}
