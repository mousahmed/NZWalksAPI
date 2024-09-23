using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Walk> Walks { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>().HasData(
                new Region
                {
                    Id = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6d"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/auckland/auckland-region-landscape.jpg"
                },
                new Region
                {
                    Id = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6e"),
                    Name = "Wellington",
                    Code = "WLG",
                    RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/wellington/wellington-region-landscape.jpg"
                },
                new Region
                {
                    Id = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6f"),
                    Name = "Canterbury",
                    Code = "CAN",
                    RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/canterbury/canterbury-region-landscape.jpg"
                },
                new Region
                {
                    Id = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"),
                    Name = "Otago",
                    Code = "OTA",
                    RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/otago/otago-region-landscape.jpg"
                }
            );

            modelBuilder.Entity<Difficulty>().HasData(
                new Difficulty
                {
                    Id = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6a"),
                    Name = "Easy",

                },
                new Difficulty
                {
                    Id = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6b"),
                    Name = "Medium",
                },
                new Difficulty
                {
                    Id = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"),
                    Name = "Hard",
                }
            );

            modelBuilder.Entity<Walk>().HasData(
                new Walk
                {
                    Id = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6a"),
                    Name = "Auckland Bridge to St Heliers",
                    Description = "This walk takes you from the Auckland Harbour Bridge to St Heliers Bay. It is a beautiful walk that takes you along the coast and through some of Auckland's most picturesque suburbs.",
                    LenghtInKm = 10.5,
                    WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/auckland/auckland-region-landscape.jpg",
                    DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6a"),
                    RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6d")
                },
                new Walk
                {
                    Id = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6b"),
                    Name = "Wellington Waterfront Walkway",
                    Description = "This walk takes you along the Wellington waterfront. It is a beautiful walk that takes you past some of Wellington's most iconic landmarks.",
                    LenghtInKm = 8.5,
                    WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/wellington/wellington-region-landscape.jpg",
                    DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6a"),
                    RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6e")
                },
                new Walk
                {
                    Id = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"),
                    Name = "Mount Cook",
                    Description = "This walk takes you to the summit of Mount Cook. It is a challenging walk that takes you through some of New Zealand's most stunning alpine scenery.",
                    LenghtInKm = 12.5,
                    WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/canterbury/canterbury-region-landscape.jpg",
                    DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"),
                    RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6f")
                },
                new Walk
                {
                    Id = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6d"),
                    Name = "Roy's Peak",
                    Description = "This walk takes you to the summit of Roy's Peak. It is a challenging walk that takes you through some of New Zealand's most stunning alpine scenery.",
                    LenghtInKm = 16.5,
                    WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/otago/otago-region-landscape.jpg",
                    DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"),
                    RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c")
                },
                new Walk
                {
                    Id = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6e"),
                    Name = "Tongariro Alpine Crossing",
                    Description = "This walk takes you through the Tongariro National Park. It is a challenging walk that takes you through some of New Zealand's most stunning alpine scenery.",
                    LenghtInKm = 19.5,
                    WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/auckland/auckland-region-landscape.jpg",
                    DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"),
                    RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6d")
                },
                new Walk
                {
                    Id = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6f"),
                    Name = "Milford Track",
                    Description = "This walk takes you through the Fiordland National Park. It is a challenging walk that takes you through some of New Zealand's most stunning alpine scenery.",
                    LenghtInKm = 53.5,
                    WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/wellington/wellington-region-landscape.jpg",
                    DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"),
                    RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6e")
                },
                new Walk
                {
                    Id = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3fef"),
                    Name = "Queen Charlotte Track",
                    Description = "This walk takes you through the Marlborough Sounds. It is a challenging walk that takes you through some of New Zealand's most stunning alpine scenery.",
                    LenghtInKm = 71.5,
                    WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/canterbury/canterbury-region-landscape.jpg",
                    DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"),
                    RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6f")
                },
                new Walk
                {
                    Id = new Guid("c7d6e9f2-239b-4cb2-80b2-77112b8f4d2a"),
                    Name = "Lake Tekapo Walk",
                    Description = "This walk takes you around the beautiful Lake Tekapo, known for its crystal-clear waters and stunning mountain backdrop.",
                    LenghtInKm = 12.0,
                    WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/canterbury/canterbury-region-landscape.jpg",
                    DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"),
                    RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6d")
                },
                new Walk
                {
                    Id = new Guid("f8b7c0c8-1db9-4cb4-8a3f-8d8f7f6a9e25"),
                    Name = "Lake Waikaremoana Great Walk",
                    Description = "A multi-day trek that circumnavigates the stunning Lake Waikaremoana, offering breathtaking lake views.",
                    LenghtInKm = 46.0,
                    WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/wellington/wellington-region-landscape.jpg",
                    DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6a"),
                    RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6e")
                },
                new Walk
                {
                    Id = new Guid("d6d4b174-d0a7-43b7-b7db-26dbf18b85b4"),
                    Name = "Cathedral Cove Walk",
                    Description = "A coastal walk to the famous Cathedral Cove, with stunning beach views and unique rock formations.",
                    LenghtInKm = 3.0,
                    WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/auckland/auckland-region-landscape.jpg",
                    DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6a"),
                    RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6d")
                },
                new Walk
                {
                    Id = new Guid("f4a8e1cc-2ef8-4df3-8fbd-4f1d86e48a0f"),
                    Name = "Routeburn Track",
                    Description = "A multi-day track offering alpine views, lakes, and waterfalls in the Fiordland National Park.",
                    LenghtInKm = 32.0,
                    WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/canterbury/canterbury-region-landscape.jpg",
                    DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"),
                    RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6f")
                },
                new Walk
                {
                    Id = new Guid("c0e1d2b1-9fe2-4fb9-92b7-43f2bbd72d1c"),
                    Name = "Abel Tasman Coast Track",
                    Description = "A coastal track that takes you through golden beaches and lush native forests in Abel Tasman National Park.",
                    LenghtInKm = 60.0,
                    WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/wellington/wellington-region-landscape.jpg",
                    DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"),
                    RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6e")
                },
                new Walk
                {
                    Id = new Guid("c65a0f26-8a95-4c73-aef3-7312e9b0d2cd"),
                    Name = "Waipoua Forest Walk",
                    Description = "A walk through Waipoua Forest, home to some of New Zealand's largest and oldest kauri trees.",
                    LenghtInKm = 5.0,
                    WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/auckland/auckland-region-landscape.jpg",
                    DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6a"),
                    RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6d")
                },
                new Walk
                {
                    Id = new Guid("a4d10f5a-1dfb-41bc-907c-2f23b7c5d7be"),
                    Name = "Kepler Track",
                    Description = "A circular track through Fiordland's stunning landscapes, including mountains, forests, and lakes.",
                    LenghtInKm = 60.0,
                    WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/canterbury/canterbury-region-landscape.jpg",
                    DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"),
                    RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6f")
                },
                new Walk
                {
                    Id = new Guid("bd02b96d-2bb8-4968-9a0f-5d0f4f79f621"),
                    Name = "Hooker Valley Track",
                    Description = "An easy and scenic walk leading to stunning views of Mount Cook and Hooker Lake.",
                    LenghtInKm = 10.0,
                    WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/auckland/auckland-region-landscape.jpg",
                    DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6a"),
                    RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6d")
                },
                new Walk
                {
                    Id = new Guid("cd1e9b2f-3da5-44d5-b2d1-6c9d1b3c6e48"),
                    Name = "West Coast Wilderness Trail",
                    Description = "A multi-day track offering a mix of coastal views, wetlands, and dense forest in New Zealand's West Coast region.",
                    LenghtInKm = 135.0,
                    WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/canterbury/canterbury-region-landscape.jpg",
                    DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"),
                    RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6f")
                },
                new Walk
                {
                    Id = new Guid("e720d9f8-1f68-4f7a-b9ea-6a2bfbfe6c67"),
                    Name = "Rakiura Track",
                    Description = "A walk through Rakiura National Park on Stewart Island, offering unique wildlife and pristine landscapes.",
                    LenghtInKm = 38.0,
                    WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/wellington/wellington-region-landscape.jpg",
                    DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"),
                    RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6e")
                }

                );

        }
    }
}