using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameWorkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedConfigEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Coaches",
                columns: new[] { "Id", "Name", "TeamId" },
                values: new object[] { 4, "Jurgen Klopp", 6 });

            migrationBuilder.InsertData(
                table: "Leagues",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Eredivisie" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "LeagueId", "Name" },
                values: new object[] { 10, 4, "Ajax" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
