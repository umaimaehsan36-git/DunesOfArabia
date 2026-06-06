using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DunesOfArabia.Migrations
{
    /// <inheritdoc />
    public partial class AddMissingModelProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsCompleted",
                table: "PackingItems",
                newName: "IsPacked");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserFavorites",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "DestinationId1",
                table: "UserFavorites",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DestinationId1",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "Itineraries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Interests",
                table: "Itineraries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<int>(
                name: "Travelers",
                table: "Itineraries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TripType",
                table: "Itineraries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BestSeason",
                table: "Destinations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HighlightsJson",
                table: "Destinations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageGalleryJson",
                table: "Destinations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Temperature",
                table: "Destinations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmationNumber",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DestinationId1",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfTravelers",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Subtotal",
                table: "Bookings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Tax",
                table: "Bookings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "CancellationPolicy",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DestinationId1",
                table: "Activities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DifficultyLevel",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IncludedServices",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MaxParticipants",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinAge",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OperatorEmail",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OperatorName",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OperatorPhone",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Activities",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BestSeason", "HighlightsJson", "ImageGalleryJson", "Temperature" },
                values: new object[] { "", "", "", "" });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BestSeason", "HighlightsJson", "ImageGalleryJson", "Temperature" },
                values: new object[] { "", "", "", "" });

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_DestinationId1",
                table: "UserFavorites",
                column: "DestinationId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_UserId",
                table: "UserFavorites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_DestinationId1",
                table: "Reviews",
                column: "DestinationId1");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Itineraries_DestinationId",
                table: "Itineraries",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_DestinationId1",
                table: "Bookings",
                column: "DestinationId1");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_DestinationId1",
                table: "Activities",
                column: "DestinationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Destinations_DestinationId1",
                table: "Activities",
                column: "DestinationId1",
                principalTable: "Destinations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Destinations_DestinationId1",
                table: "Bookings",
                column: "DestinationId1",
                principalTable: "Destinations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Itineraries_Destinations_DestinationId",
                table: "Itineraries",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Destinations_DestinationId1",
                table: "Reviews",
                column: "DestinationId1",
                principalTable: "Destinations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavorites_AspNetUsers_UserId",
                table: "UserFavorites",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavorites_Destinations_DestinationId1",
                table: "UserFavorites",
                column: "DestinationId1",
                principalTable: "Destinations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Destinations_DestinationId1",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Destinations_DestinationId1",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Itineraries_Destinations_DestinationId",
                table: "Itineraries");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Destinations_DestinationId1",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavorites_AspNetUsers_UserId",
                table: "UserFavorites");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavorites_Destinations_DestinationId1",
                table: "UserFavorites");

            migrationBuilder.DropIndex(
                name: "IX_UserFavorites_DestinationId1",
                table: "UserFavorites");

            migrationBuilder.DropIndex(
                name: "IX_UserFavorites_UserId",
                table: "UserFavorites");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_DestinationId1",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Itineraries_DestinationId",
                table: "Itineraries");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_DestinationId1",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Activities_DestinationId1",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "DestinationId1",
                table: "UserFavorites");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "DestinationId1",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "Itineraries");

            migrationBuilder.DropColumn(
                name: "Interests",
                table: "Itineraries");

            migrationBuilder.DropColumn(
                name: "Travelers",
                table: "Itineraries");

            migrationBuilder.DropColumn(
                name: "TripType",
                table: "Itineraries");

            migrationBuilder.DropColumn(
                name: "BestSeason",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "HighlightsJson",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "ImageGalleryJson",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "ConfirmationNumber",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "DestinationId1",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "NumberOfTravelers",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Subtotal",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CancellationPolicy",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "DestinationId1",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "DifficultyLevel",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "IncludedServices",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "MaxParticipants",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "MinAge",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "OperatorEmail",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "OperatorName",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "OperatorPhone",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Activities");

            migrationBuilder.RenameColumn(
                name: "IsPacked",
                table: "PackingItems",
                newName: "IsCompleted");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserFavorites",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
