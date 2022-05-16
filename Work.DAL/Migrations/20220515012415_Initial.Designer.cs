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
    [Migration("20220515012415_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IdentityUser<int>");
                });

            modelBuilder.Entity("Work.DAL.Entities.Claim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Claims");
                });

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

            modelBuilder.Entity("Work.DAL.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Work.DAL.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser<int>", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Work.DAL.Entities.HotelTicket", "HotelReservationTicket")
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
