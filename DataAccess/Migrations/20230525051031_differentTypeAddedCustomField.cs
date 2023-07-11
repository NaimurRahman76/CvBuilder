using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class differentTypeAddedCustomField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FieldValue",
                table: "CustomFields");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "CustomFields");

            migrationBuilder.AddColumn<DateTime>(
                name: "FieldValueDate",
                table: "CustomFields",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FieldValueString",
                table: "CustomFields",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FiledValueNumber",
                table: "CustomFields",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FieldValueDate",
                table: "CustomFields");

            migrationBuilder.DropColumn(
                name: "FieldValueString",
                table: "CustomFields");

            migrationBuilder.DropColumn(
                name: "FiledValueNumber",
                table: "CustomFields");

            migrationBuilder.AddColumn<string>(
                name: "FieldValue",
                table: "CustomFields",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "CustomFields",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
