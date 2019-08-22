﻿// <auto-generated />
using System;
using BlueBoard.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BlueBoard.Persistence.Migrations
{
    [DbContext(typeof(BlueBoardContext))]
    partial class BlueBoardContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("BlueBoard.Domain.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Iso")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("BlueBoard.Domain.Participant", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("TripId");

                    b.Property<Guid>("Id");

                    b.Property<int>("Role");

                    b.Property<Guid?>("TripId1");

                    b.HasKey("UserId", "TripId");

                    b.HasIndex("TripId");

                    b.HasIndex("TripId1");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("BlueBoard.Domain.Trip", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreatedById");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("BlueBoard.Domain.TripCountry", b =>
                {
                    b.Property<Guid>("TripId");

                    b.Property<Guid>("CountryId");

                    b.Property<Guid?>("TripId1");

                    b.HasKey("TripId", "CountryId");

                    b.HasIndex("CountryId");

                    b.HasIndex("TripId1");

                    b.ToTable("TripCountries");
                });

            modelBuilder.Entity("BlueBoard.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Avatar");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BlueBoard.Domain.Participant", b =>
                {
                    b.HasOne("BlueBoard.Domain.Trip", "Trip")
                        .WithMany()
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BlueBoard.Domain.Trip")
                        .WithMany("Participants")
                        .HasForeignKey("TripId1");

                    b.HasOne("BlueBoard.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BlueBoard.Domain.Trip", b =>
                {
                    b.HasOne("BlueBoard.Domain.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BlueBoard.Domain.TripCountry", b =>
                {
                    b.HasOne("BlueBoard.Domain.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BlueBoard.Domain.Trip", "Trip")
                        .WithMany()
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BlueBoard.Domain.Trip")
                        .WithMany("Countries")
                        .HasForeignKey("TripId1");
                });
#pragma warning restore 612, 618
        }
    }
}
