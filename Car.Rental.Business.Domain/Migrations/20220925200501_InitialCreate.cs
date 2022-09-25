using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Car.Rental.Business.Domain.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "business");

            migrationBuilder.CreateTable(
                name: "Reservation",
                schema: "business",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(nullable: false),
                    VehicleId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    TotalPrix = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inspection",
                schema: "business",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationId = table.Column<int>(nullable: false),
                    OperatorId = table.Column<int>(nullable: false),
                    VehicleClean = table.Column<bool>(nullable: false),
                    FuelFilled = table.Column<bool>(nullable: false),
                    HasScratches = table.Column<bool>(nullable: false),
                    HasDamages = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inspection_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalSchema: "business",
                        principalTable: "Reservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inspection_ReservationId",
                schema: "business",
                table: "Inspection",
                column: "ReservationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inspection",
                schema: "business");

            migrationBuilder.DropTable(
                name: "Reservation",
                schema: "business");
        }
    }
}
