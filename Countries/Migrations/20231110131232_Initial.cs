using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Countries.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dificultad = table.Column<int>(type: "int", nullable: false),
                    Duracion = table.Column<int>(type: "int", nullable: false),
                    Temporada = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capitals = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubRegion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Area = table.Column<double>(type: "float", nullable: false),
                    Population = table.Column<int>(type: "int", nullable: false),
                    Continents = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Flags = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryActivities",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    CountryTid = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryActivities", x => new { x.CountryId, x.ActivityId });
                    table.ForeignKey(
                        name: "FK_CountryActivities_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryActivities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryActivities_ActivityId",
                table: "CountryActivities",
                column: "ActivityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryActivities");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
