using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class addDataToTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6a"), "Easy" },
                    { new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6b"), "Moderate" },
                    { new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"), "OTA", "Otago", "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/otago/otago-region-landscape.jpg" },
                    { new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6d"), "AKL", "Auckland", "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/auckland/auckland-region-landscape.jpg" },
                    { new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6e"), "WLG", "Wellington", "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/wellington/wellington-region-landscape.jpg" },
                    { new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6f"), "CAN", "Canterbury", "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/canterbury/canterbury-region-landscape.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6a"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6b"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6f"));
        }
    }
}
