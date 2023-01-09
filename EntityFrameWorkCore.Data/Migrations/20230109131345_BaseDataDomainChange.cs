using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameWorkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class BaseDataDomainChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Matches",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Matches",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Leagues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Leagues",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Leagues",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Leagues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Coaches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Coaches",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Coaches",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Coaches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedBy", "CreatedDate", "LastModifiedDate", "ModifiedBy" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedBy", "CreatedDate", "LastModifiedDate", "ModifiedBy" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedBy", "CreatedDate", "LastModifiedDate", "ModifiedBy" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Leagues");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Leagues");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Leagues");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Leagues");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Coaches");
        }
    }
}
