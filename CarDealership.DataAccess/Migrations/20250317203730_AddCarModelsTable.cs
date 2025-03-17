using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarDealership.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCarModelsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Engine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarMakeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarModels_CarMakes_CarMakeId",
                        column: x => x.CarMakeId,
                        principalTable: "CarMakes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "Id", "CarMakeId", "Description", "Engine", "Name", "Trim" },
                values: new object[,]
                {
                    { 1, 1, null, "1.5L 4-cylinder", "Equinox", "RS" },
                    { 2, 1, null, "1.5L 4-cylinder", "Equinox", "Activ" },
                    { 3, 1, null, "1.5L 4-cylinder", "Equinox", "LT" },
                    { 4, 1, null, "TurboMax", "Silverado 1500", "RST" },
                    { 5, 1, null, "5.3L V8", "Silverado 1500", "Trail Boss" },
                    { 6, 1, null, "TurboMax", "Silverado 1500", "LT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_CarMakeId",
                table: "CarModels",
                column: "CarMakeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarModels");
        }
    }
}
