using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DunesOfArabia.Migrations
{
    /// <inheritdoc />
    public partial class AddComplaintCategoryAndDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DestinationId",
                table: "Reviews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "DailyActivities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Complaints",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Complaints",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "DailyActivities");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Complaints");

            migrationBuilder.AlterColumn<int>(
                name: "DestinationId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
