using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedMoreDataToWalksTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Walks",
                columns: new[] { "Id", "Description", "DifficultyId", "LenghtInKm", "Name", "RegionId", "WalkImageUrl" },
                values: new object[,]
                {
                    { new Guid("a4d10f5a-1dfb-41bc-907c-2f23b7c5d7be"), "A circular track through Fiordland's stunning landscapes, including mountains, forests, and lakes.", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"), 60.0, "Kepler Track", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6f"), "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/canterbury/canterbury-region-landscape.jpg" },
                    { new Guid("bd02b96d-2bb8-4968-9a0f-5d0f4f79f621"), "An easy and scenic walk leading to stunning views of Mount Cook and Hooker Lake.", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6a"), 10.0, "Hooker Valley Track", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6d"), "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/auckland/auckland-region-landscape.jpg" },
                    { new Guid("c0e1d2b1-9fe2-4fb9-92b7-43f2bbd72d1c"), "A coastal track that takes you through golden beaches and lush native forests in Abel Tasman National Park.", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"), 60.0, "Abel Tasman Coast Track", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6e"), "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/wellington/wellington-region-landscape.jpg" },
                    { new Guid("c65a0f26-8a95-4c73-aef3-7312e9b0d2cd"), "A walk through Waipoua Forest, home to some of New Zealand's largest and oldest kauri trees.", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6a"), 5.0, "Waipoua Forest Walk", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6d"), "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/auckland/auckland-region-landscape.jpg" },
                    { new Guid("c7d6e9f2-239b-4cb2-80b2-77112b8f4d2a"), "This walk takes you around the beautiful Lake Tekapo, known for its crystal-clear waters and stunning mountain backdrop.", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"), 12.0, "Lake Tekapo Walk", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6d"), "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/canterbury/canterbury-region-landscape.jpg" },
                    { new Guid("cd1e9b2f-3da5-44d5-b2d1-6c9d1b3c6e48"), "A multi-day track offering a mix of coastal views, wetlands, and dense forest in New Zealand's West Coast region.", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"), 135.0, "West Coast Wilderness Trail", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6f"), "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/canterbury/canterbury-region-landscape.jpg" },
                    { new Guid("d6d4b174-d0a7-43b7-b7db-26dbf18b85b4"), "A coastal walk to the famous Cathedral Cove, with stunning beach views and unique rock formations.", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6a"), 3.0, "Cathedral Cove Walk", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6d"), "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/auckland/auckland-region-landscape.jpg" },
                    { new Guid("e720d9f8-1f68-4f7a-b9ea-6a2bfbfe6c67"), "A walk through Rakiura National Park on Stewart Island, offering unique wildlife and pristine landscapes.", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"), 38.0, "Rakiura Track", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6e"), "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/wellington/wellington-region-landscape.jpg" },
                    { new Guid("f4a8e1cc-2ef8-4df3-8fbd-4f1d86e48a0f"), "A multi-day track offering alpine views, lakes, and waterfalls in the Fiordland National Park.", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"), 32.0, "Routeburn Track", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6f"), "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/canterbury/canterbury-region-landscape.jpg" },
                    { new Guid("f8b7c0c8-1db9-4cb4-8a3f-8d8f7f6a9e25"), "A multi-day trek that circumnavigates the stunning Lake Waikaremoana, offering breathtaking lake views.", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6a"), 46.0, "Lake Waikaremoana Great Walk", new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6e"), "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/wellington/wellington-region-landscape.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("a4d10f5a-1dfb-41bc-907c-2f23b7c5d7be"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("bd02b96d-2bb8-4968-9a0f-5d0f4f79f621"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("c0e1d2b1-9fe2-4fb9-92b7-43f2bbd72d1c"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("c65a0f26-8a95-4c73-aef3-7312e9b0d2cd"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("c7d6e9f2-239b-4cb2-80b2-77112b8f4d2a"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("cd1e9b2f-3da5-44d5-b2d1-6c9d1b3c6e48"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("d6d4b174-d0a7-43b7-b7db-26dbf18b85b4"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("e720d9f8-1f68-4f7a-b9ea-6a2bfbfe6c67"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("f4a8e1cc-2ef8-4df3-8fbd-4f1d86e48a0f"));

            migrationBuilder.DeleteData(
                table: "Walks",
                keyColumn: "Id",
                keyValue: new Guid("f8b7c0c8-1db9-4cb4-8a3f-8d8f7f6a9e25"));
        }
    }
}
