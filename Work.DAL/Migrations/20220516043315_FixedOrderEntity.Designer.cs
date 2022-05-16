﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Work.DAL.Data;

#nullable disable

namespace Work.DAL.Migrations
{
    [DbContext(typeof(TourDbContext))]
    [Migration("20220516043315_FixedOrderEntity")]
    partial class FixedOrderEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Work.DAL.Entities.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("HotelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("HotelName");

                    b.Property<double>("HotelPrice")
                        .HasColumnType("float")
                        .HasColumnName("HotelPrice");

                    b.Property<int>("HotelStars")
                        .HasColumnType("int")
                        .HasColumnName("HotelStars");

                    b.HasKey("Id");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HotelName = "Belagio",
                            HotelPrice = 45.0,
                            HotelStars = 3
                        },
                        new
                        {
                            Id = 2,
                            HotelName = "The Peninsula Chicago",
                            HotelPrice = 70.0,
                            HotelStars = 4
                        },
                        new
                        {
                            Id = 3,
                            HotelName = "Montage Kapalua Bay",
                            HotelPrice = 90.0,
                            HotelStars = 5
                        });
                });

            modelBuilder.Entity("Work.DAL.Entities.HotelTicket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date");

                    b.Property<int>("HotelId")
                        .HasColumnType("int")
                        .HasColumnName("Hotel");

                    b.Property<int>("NumberOfDays")
                        .HasColumnType("int")
                        .HasColumnName("NumberOfDays");

                    b.Property<double>("SummaryPrice")
                        .HasColumnType("float")
                        .HasColumnName("SummaryPrice");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelTickets");
                });

            modelBuilder.Entity("Work.DAL.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("FinalPrice")
                        .HasColumnType("float")
                        .HasColumnName("FinalPrice");

                    b.Property<int?>("HotelTicketReservationId")
                        .HasColumnType("int")
                        .HasColumnName("HotelReservationTicket");

                    b.Property<int>("TourId")
                        .HasColumnType("int")
                        .HasColumnName("Tour");

                    b.Property<int?>("TransportId")
                        .HasColumnType("int");

                    b.Property<int?>("TransportReservationId")
                        .HasColumnType("int")
                        .HasColumnName("TransportReservationTicket");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("User");

                    b.HasKey("Id");

                    b.HasIndex("TourId");

                    b.HasIndex("TransportId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Work.DAL.Entities.Tour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("TourDateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date");

                    b.Property<int>("TourDurationInDays")
                        .HasColumnType("int")
                        .HasColumnName("TourDurationInDays");

                    b.Property<string>("TourMovementType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TourMovementType");

                    b.Property<string>("TourName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TourName");

                    b.Property<string>("TourRegion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TourRegion");

                    b.Property<string>("TourType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TourType");

                    b.HasKey("Id");

                    b.ToTable("Tours");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TourDateTime = new DateTime(2022, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TourDurationInDays = 6,
                            TourMovementType = "Walking",
                            TourName = "Colorado Hiking: Rocky Mountain National Park",
                            TourRegion = "USA",
                            TourType = "Mountain Skiing Tour"
                        });
                });

            modelBuilder.Entity("Work.DAL.Entities.Transport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TransportName");

                    b.Property<double>("TransportPrice")
                        .HasColumnType("float")
                        .HasColumnName("TransportPrice");

                    b.HasKey("Id");

                    b.ToTable("Transports");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Liner",
                            TransportPrice = 82.599999999999994
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bus",
                            TransportPrice = 10.199999999999999
                        },
                        new
                        {
                            Id = 3,
                            Name = "Airplane",
                            TransportPrice = 52.299999999999997
                        });
                });

            modelBuilder.Entity("Work.DAL.Entities.TransportTicket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date");

                    b.Property<int>("NumberOfUsing")
                        .HasColumnType("int")
                        .HasColumnName("NumberOfUsing");

                    b.Property<int>("TransportId")
                        .HasColumnType("int")
                        .HasColumnName("Transport");

                    b.Property<double>("TransportPrice")
                        .HasColumnType("float")
                        .HasColumnName("TransportPrice");

                    b.HasKey("Id");

                    b.HasIndex("TransportId");

                    b.ToTable("TransportTickets");
                });

            modelBuilder.Entity("Work.DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Email");

                    b.Property<bool>("IsLogged")
                        .HasColumnType("bit")
                        .HasColumnName("IsLogged");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PasswordHash");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "administrator@mail.com",
                            IsLogged = true,
                            PasswordHash = "CF-83-5D-E3-D4-EA-01-36-7C-45-E4-12-E7-A9-39-3A-85-A4-E4-0A-F1-49-ED-8C-3E-D6-C3-7C-05-B6-7B-27-81-3D-7F-F8-07-2C-10-35-CE-DD-19-41-5A-DF-17-12-8D-63-18-6F-05-F0-D6-56-00-2B-0C-A1-C3-4F-44-A0",
                            Role = "Administrator"
                        },
                        new
                        {
                            Id = 2,
                            Email = "manager@mail.com",
                            IsLogged = false,
                            PasswordHash = "5F-C2-CA-6F-08-59-19-F2-F7-76-26-F1-E2-80-FA-B9-CC-92-B4-ED-C9-ED-C5-3A-C6-EE-E3-F7-2C-5C-50-8E-86-9E-E9-D6-7A-96-D6-39-86-D1-4C-1C-2B-82-C3-5F-F5-F3-14-94-BE-A8-31-01-54-24-F5-9C-96-FF-F6-64",
                            Role = "Manager"
                        },
                        new
                        {
                            Id = 3,
                            Email = "user@mail.com",
                            IsLogged = false,
                            PasswordHash = "B1-43-61-40-4C-07-8F-FD-54-9C-03-DB-44-3C-3F-ED-E2-F3-E5-34-D7-3F-78-F7-73-01-ED-97-D4-A4-36-A9-FD-9D-B0-5E-E8-B3-25-C0-AD-36-43-8B-43-FE-C8-51-0C-20-4F-C1-C1-ED-B2-1D-09-41-C0-0E-9E-2C-1C-E2",
                            Role = "User"
                        });
                });

            modelBuilder.Entity("Work.DAL.Entities.HotelTicket", b =>
                {
                    b.HasOne("Work.DAL.Entities.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Work.DAL.Entities.Order", b =>
                {
                    b.HasOne("Work.DAL.Entities.Tour", "Tour")
                        .WithMany()
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Work.DAL.Entities.TransportTicket", "TransportReservationTicket")
                        .WithMany()
                        .HasForeignKey("TransportId");

                    b.HasOne("Work.DAL.Entities.HotelTicket", "HotelReservationTicket")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Work.DAL.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HotelReservationTicket");

                    b.Navigation("Tour");

                    b.Navigation("TransportReservationTicket");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Work.DAL.Entities.TransportTicket", b =>
                {
                    b.HasOne("Work.DAL.Entities.Transport", "Transport")
                        .WithMany()
                        .HasForeignKey("TransportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Transport");
                });
#pragma warning restore 612, 618
        }
    }
}
