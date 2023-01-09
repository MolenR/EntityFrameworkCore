using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameWorkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingSPGetCoachName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE sp_GetTeamCoach
                                    @teamId int
                                AS
                                BEGIN
                                    SELECT * from Coaches where TeamId = @teamId
                                END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE [dbo].[sp_GetCoachName]");
        }
    }
}
