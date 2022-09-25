using Microsoft.EntityFrameworkCore.Migrations;

namespace Car.Rental.Business.Domain.Migrations
{
    public partial class FixingInspectionReservationRelationsihip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Inspection_ReservationId",
                schema: "business",
                table: "Inspection");

            migrationBuilder.CreateIndex(
                name: "IX_Inspection_ReservationId",
                schema: "business",
                table: "Inspection",
                column: "ReservationId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Inspection_ReservationId",
                schema: "business",
                table: "Inspection");

            migrationBuilder.CreateIndex(
                name: "IX_Inspection_ReservationId",
                schema: "business",
                table: "Inspection",
                column: "ReservationId");
        }
    }
}
