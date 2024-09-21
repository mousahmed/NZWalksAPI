using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateMediumDiffiultyName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6b"),
                column: "Name",
                value: "Medium");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6b"),
                column: "Name",
                value: "Moderate");
        }
    }
}
