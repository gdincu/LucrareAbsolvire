using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChargingPointLocations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargingPointLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChargingPointTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargingPointTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChargingPoints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PictureUrl = table.Column<string>(nullable: true),
                    ChargingPointLocationId = table.Column<int>(nullable: false),
                    ChargingPointTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargingPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChargingPoints_ChargingPointLocations_ChargingPointLocationId",
                        column: x => x.ChargingPointLocationId,
                        principalTable: "ChargingPointLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChargingPoints_ChargingPointTypes_ChargingPointTypeId",
                        column: x => x.ChargingPointTypeId,
                        principalTable: "ChargingPointTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChargingPoints_ChargingPointLocationId",
                table: "ChargingPoints",
                column: "ChargingPointLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ChargingPoints_ChargingPointTypeId",
                table: "ChargingPoints",
                column: "ChargingPointTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChargingPoints");

            migrationBuilder.DropTable(
                name: "ChargingPointLocations");

            migrationBuilder.DropTable(
                name: "ChargingPointTypes");
        }
    }
}
