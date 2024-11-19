using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERM.Migrations
{
    /// <inheritdoc />
    public partial class updateSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GlobalTypeCategories",
                columns: table => new
                {
                    GlobalTypeCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ClinicId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalTypeCategories", x => x.GlobalTypeCategoryId);
                    table.ForeignKey(
                        name: "FK_GlobalTypeCategories_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "ClinicId");
                });

            migrationBuilder.CreateTable(
                name: "GlobalTypes",
                columns: table => new
                {
                    GlobalTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GlobalTypeCategoryId = table.Column<int>(type: "int", nullable: true),
                    ClinicId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalTypes", x => x.GlobalTypeId);
                    table.ForeignKey(
                        name: "FK_GlobalTypes_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "ClinicId");
                    table.ForeignKey(
                        name: "FK_GlobalTypes_GlobalTypeCategories_GlobalTypeCategoryId",
                        column: x => x.GlobalTypeCategoryId,
                        principalTable: "GlobalTypeCategories",
                        principalColumn: "GlobalTypeCategoryId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GlobalTypeCategories_ClinicId",
                table: "GlobalTypeCategories",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalTypes_ClinicId",
                table: "GlobalTypes",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalTypes_GlobalTypeCategoryId",
                table: "GlobalTypes",
                column: "GlobalTypeCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GlobalTypes");

            migrationBuilder.DropTable(
                name: "GlobalTypeCategories");
        }
    }
}
