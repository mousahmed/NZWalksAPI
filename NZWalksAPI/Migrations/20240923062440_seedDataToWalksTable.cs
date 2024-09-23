using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedDataToWalksTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Walks",
                columns: new[] { "Id", "Description", "DifficultyId", "LenghtInKm", "Name", "RegionId", "WalkImageUrl" },
                values: new object[,]
                {
                    { new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6a"), "This walk takes you from the Auckland Harbour Bridge to St Heliers Bay. It is a beautiful walk that takes you along the coast and through some of Auckland's most picturesque suburbs.", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6a"), 10.5, "Auckland Bridge to St Heliers", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6d"), "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/auckland/auckland-region-landscape.jpg" },
                    { new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6b"), "This walk takes you along the Wellington waterfront. It is a beautiful walk that takes you past some of Wellington's most iconic landmarks.", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6a"), 8.5, "Wellington Waterfront Walkway", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6e"), "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/wellington/wellington-region-landscape.jpg" },
                    { new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"), "This walk takes you to the summit of Mount Cook. It is a challenging walk that takes you through some of New Zealand's most stunning alpine scenery.", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"), 12.5, "Mount Cook", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6f"), "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/canterbury/canterbury-region-landscape.jpg" },
                    { new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6d"), "This walk takes you to the summit of Roy's Peak. It is a challenging walk that takes you through some of New Zealand's most stunning alpine scenery.", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"), 16.5, "Roy's Peak", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"), "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/otago/otago-region-landscape.jpg" },
                    { new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6e"), "This walk takes you through the Tongariro National Park. It is a challenging walk that takes you through some of New Zealand's most stunning alpine scenery.", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"), 19.5, "Tongariro Alpine Crossing", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6d"), "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/auckland/auckland-region-landscape.jpg" },
                    { new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6f"), "This walk takes you through the Fiordland National Park. It is a challenging walk that takes you through some of New Zealand's most stunning alpine scenery.", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"), 53.5, "Milford Track", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6e"), "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/wellington/wellington-region-landscape.jpg" },
                    { new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3fef"), "This walk takes you through the Marlborough Sounds. It is a challenging walk that takes you through some of New Zealand's most stunning alpine scenery.", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"), 71.5, "Queen Charlotte Track", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6f"), "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/canterbury/canterbury-region-landscape.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6a"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6b"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6d"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6e"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6f"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3fef"));
        }
    }
}
