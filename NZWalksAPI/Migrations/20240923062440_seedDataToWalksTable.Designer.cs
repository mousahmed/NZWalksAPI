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
    [Migration("20240923062440_seedDataToWalksTable")]
    partial class seedDataToWalksTable
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