﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PexelStore.Data;

#nullable disable

namespace PexelStore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GamesGenre", b =>
                {
                    b.Property<Guid>("gamesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("genresId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("gamesId", "genresId");

                    b.HasIndex("genresId");

                    b.ToTable("GamesGenre");
                });

            modelBuilder.Entity("PexelStore.Models.Domain.Games", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Platform")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Poster")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Story")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("games");
                });

            modelBuilder.Entity("PexelStore.Models.Domain.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("genres");
                });

            modelBuilder.Entity("GamesGenre", b =>
                {
                    b.HasOne("PexelStore.Models.Domain.Games", null)
                        .WithMany()
                        .HasForeignKey("gamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PexelStore.Models.Domain.Genre", null)
                        .WithMany()
                        .HasForeignKey("genresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
