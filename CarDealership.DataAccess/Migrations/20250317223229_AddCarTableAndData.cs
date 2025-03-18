using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarDealership.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCarTableAndData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarModelId = table.Column<int>(type: "int", nullable: false),
                    MSRP = table.Column<int>(type: "int", nullable: false),
                    OurPrice = table.Column<int>(type: "int", nullable: false),
                    StockNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Miles = table.Column<int>(type: "int", nullable: false),
                    Drivetrain = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Used = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_CarModels_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CarModelId", "Color", "Drivetrain", "ImageUrl", "MSRP", "Miles", "OurPrice", "StockNumber", "Used", "VIN", "Year" },
                values: new object[,]
                {
                    { 1, 1, "Black", "AWD", null, 33000, 2, 32000, "25-1000", null, "EQ251200", "2025" },
                    { 2, 3, "Silver", "FWD", null, 28000, 3, 26000, "25-3000", null, "EQ253200", "2025" },
                    { 3, 3, "White", "FWD", null, 28000, 2, 26000, "25-3100", null, "EQ254200", "2025" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarModelId",
                table: "Cars",
                column: "CarModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
