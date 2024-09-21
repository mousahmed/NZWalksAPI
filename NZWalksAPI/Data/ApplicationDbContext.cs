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

        }
    }
}