using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NationalPark_API_C3.Migrations
{
    public partial class deleteforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_NationalParks_NationalParkId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_NationalParkId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "NationalParkId",
                table: "Bookings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NationalParkId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_NationalParkId",
                table: "Bookings",
                column: "NationalParkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_NationalParks_NationalParkId",
                table: "Bookings",
                column: "NationalParkId",
                principalTable: "NationalParks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
