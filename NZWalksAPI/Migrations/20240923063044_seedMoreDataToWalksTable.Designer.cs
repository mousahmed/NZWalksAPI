﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NZWalksAPI.Data;

#nullable disable

namespace NZWalksAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240923063044_seedMoreDataToWalksTable")]
    partial class seedMoreDataToWalksTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NZWalksAPI.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6a"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6b"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("NZWalksAPI.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6d"),
                            Code = "AKL",
                            Name = "Auckland",
                            RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/auckland/auckland-region-landscape.jpg"
                        },
                        new
                        {
                            Id = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6e"),
                            Code = "WLG",
                            Name = "Wellington",
                            RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/wellington/wellington-region-landscape.jpg"
                        },
                        new
                        {
                            Id = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6f"),
                            Code = "CAN",
                            Name = "Canterbury",
                            RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/canterbury/canterbury-region-landscape.jpg"
                        },
                        new
                        {
                            Id = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"),
                            Code = "OTA",
                            Name = "Otago",
                            RegionImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/otago/otago-region-landscape.jpg"
                        });
                });

            modelBuilder.Entity("NZWalksAPI.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LenghtInKm")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6a"),
                            Description = "This walk takes you from the Auckland Harbour Bridge to St Heliers Bay. It is a beautiful walk that takes you along the coast and through some of Auckland's most picturesque suburbs.",
                            DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6a"),
                            LenghtInKm = 10.5,
                            Name = "Auckland Bridge to St Heliers",
                            RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6d"),
                            WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/auckland/auckland-region-landscape.jpg"
                        },
                        new
                        {
                            Id = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6b"),
                            Description = "This walk takes you along the Wellington waterfront. It is a beautiful walk that takes you past some of Wellington's most iconic landmarks.",
                            DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6a"),
                            LenghtInKm = 8.5,
                            Name = "Wellington Waterfront Walkway",
                            RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6e"),
                            WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/wellington/wellington-region-landscape.jpg"
                        },
                        new
                        {
                            Id = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"),
                            Description = "This walk takes you to the summit of Mount Cook. It is a challenging walk that takes you through some of New Zealand's most stunning alpine scenery.",
                            DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"),
                            LenghtInKm = 12.5,
                            Name = "Mount Cook",
                            RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6f"),
                            WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/canterbury/canterbury-region-landscape.jpg"
                        },
                        new
                        {
                            Id = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6d"),
                            Description = "This walk takes you to the summit of Roy's Peak. It is a challenging walk that takes you through some of New Zealand's most stunning alpine scenery.",
                            DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"),
                            LenghtInKm = 16.5,
                            Name = "Roy's Peak",
                            RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"),
                            WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/otago/otago-region-landscape.jpg"
                        },
                        new
                        {
                            Id = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6e"),
                            Description = "This walk takes you through the Tongariro National Park. It is a challenging walk that takes you through some of New Zealand's most stunning alpine scenery.",
                            DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"),
                            LenghtInKm = 19.5,
                            Name = "Tongariro Alpine Crossing",
                            RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6d"),
                            WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/auckland/auckland-region-landscape.jpg"
                        },
                        new
                        {
                            Id = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6f"),
                            Description = "This walk takes you through the Fiordland National Park. It is a challenging walk that takes you through some of New Zealand's most stunning alpine scenery.",
                            DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"),
                            LenghtInKm = 53.5,
                            Name = "Milford Track",
                            RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6e"),
                            WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/wellington/wellington-region-landscape.jpg"
                        },
                        new
                        {
                            Id = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3fef"),
                            Description = "This walk takes you through the Marlborough Sounds. It is a challenging walk that takes you through some of New Zealand's most stunning alpine scenery.",
                            DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"),
                            LenghtInKm = 71.5,
                            Name = "Queen Charlotte Track",
                            RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6f"),
                            WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/canterbury/canterbury-region-landscape.jpg"
                        },
                        new
                        {
                            Id = new Guid("c7d6e9f2-239b-4cb2-80b2-77112b8f4d2a"),
                            Description = "This walk takes you around the beautiful Lake Tekapo, known for its crystal-clear waters and stunning mountain backdrop.",
                            DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"),
                            LenghtInKm = 12.0,
                            Name = "Lake Tekapo Walk",
                            RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6d"),
                            WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/canterbury/canterbury-region-landscape.jpg"
                        },
                        new
                        {
                            Id = new Guid("f8b7c0c8-1db9-4cb4-8a3f-8d8f7f6a9e25"),
                            Description = "A multi-day trek that circumnavigates the stunning Lake Waikaremoana, offering breathtaking lake views.",
                            DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6a"),
                            LenghtInKm = 46.0,
                            Name = "Lake Waikaremoana Great Walk",
                            RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6e"),
                            WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/wellington/wellington-region-landscape.jpg"
                        },
                        new
                        {
                            Id = new Guid("d6d4b174-d0a7-43b7-b7db-26dbf18b85b4"),
                            Description = "A coastal walk to the famous Cathedral Cove, with stunning beach views and unique rock formations.",
                            DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6a"),
                            LenghtInKm = 3.0,
                            Name = "Cathedral Cove Walk",
                            RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6d"),
                            WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/auckland/auckland-region-landscape.jpg"
                        },
                        new
                        {
                            Id = new Guid("f4a8e1cc-2ef8-4df3-8fbd-4f1d86e48a0f"),
                            Description = "A multi-day track offering alpine views, lakes, and waterfalls in the Fiordland National Park.",
                            DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"),
                            LenghtInKm = 32.0,
                            Name = "Routeburn Track",
                            RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6f"),
                            WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/canterbury/canterbury-region-landscape.jpg"
                        },
                        new
                        {
                            Id = new Guid("c0e1d2b1-9fe2-4fb9-92b7-43f2bbd72d1c"),
                            Description = "A coastal track that takes you through golden beaches and lush native forests in Abel Tasman National Park.",
                            DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"),
                            LenghtInKm = 60.0,
                            Name = "Abel Tasman Coast Track",
                            RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6e"),
                            WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/wellington/wellington-region-landscape.jpg"
                        },
                        new
                        {
                            Id = new Guid("c65a0f26-8a95-4c73-aef3-7312e9b0d2cd"),
                            Description = "A walk through Waipoua Forest, home to some of New Zealand's largest and oldest kauri trees.",
                            DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6a"),
                            LenghtInKm = 5.0,
                            Name = "Waipoua Forest Walk",
                            RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6d"),
                            WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/auckland/auckland-region-landscape.jpg"
                        },
                        new
                        {
                            Id = new Guid("a4d10f5a-1dfb-41bc-907c-2f23b7c5d7be"),
                            Description = "A circular track through Fiordland's stunning landscapes, including mountains, forests, and lakes.",
                            DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"),
                            LenghtInKm = 60.0,
                            Name = "Kepler Track",
                            RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6f"),
                            WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/canterbury/canterbury-region-landscape.jpg"
                        },
                        new
                        {
                            Id = new Guid("bd02b96d-2bb8-4968-9a0f-5d0f4f79f621"),
                            Description = "An easy and scenic walk leading to stunning views of Mount Cook and Hooker Lake.",
                            DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6a"),
                            LenghtInKm = 10.0,
                            Name = "Hooker Valley Track",
                            RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6d"),
                            WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/auckland/auckland-region-landscape.jpg"
                        },
                        new
                        {
                            Id = new Guid("cd1e9b2f-3da5-44d5-b2d1-6c9d1b3c6e48"),
                            Description = "A multi-day track offering a mix of coastal views, wetlands, and dense forest in New Zealand's West Coast region.",
                            DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"),
                            LenghtInKm = 135.0,
                            Name = "West Coast Wilderness Trail",
                            RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6f"),
                            WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/canterbury/canterbury-region-landscape.jpg"
                        },
                        new
                        {
                            Id = new Guid("e720d9f8-1f68-4f7a-b9ea-6a2bfbfe6c67"),
                            Description = "A walk through Rakiura National Park on Stewart Island, offering unique wildlife and pristine landscapes.",
                            DifficultyId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6c"),
                            LenghtInKm = 38.0,
                            Name = "Rakiura Track",
                            RegionId = new Guid("b3b3e6e1-1b36-4b0e-8e4b-6b4f3f1b3f6e"),
                            WalkImageUrl = "https://www.doc.govt.nz/globalassets/images/conservation/parks-and-recreation/places-to-visit/wellington/wellington-region-landscape.jpg"
                        });
                });

            modelBuilder.Entity("NZWalksAPI.Models.Domain.Walk", b =>
                {
                    b.HasOne("NZWalksAPI.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NZWalksAPI.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
