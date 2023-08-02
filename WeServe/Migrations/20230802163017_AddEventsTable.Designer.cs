﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeServe.Data;

#nullable disable

namespace WeServe.Migrations
{
    [DbContext(typeof(WeServeContext))]
    [Migration("20230802163017_AddEventsTable")]
    partial class AddEventsTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WeServe.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Event", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6440),
                            CreatedByUserId = 3,
                            Description = "Join us for a fun-filled summer festival!",
                            Details = "This event has no details.",
                            EndDate = new DateTime(2023, 8, 15, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "https://placehold.co/320x320",
                            IsDeleted = false,
                            Location = "Central Park, New York",
                            Name = "Summer Festival",
                            OrganizationId = 1,
                            StartDate = new DateTime(2023, 8, 15, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedAt = new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6441)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6448),
                            CreatedByUserId = 3,
                            Description = "Learn about the latest tech trends and innovations.",
                            Details = "This event has no details.",
                            EndDate = new DateTime(2023, 9, 22, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "https://placehold.co/320x320",
                            IsDeleted = false,
                            Location = "Tech Convention Center, San Francisco",
                            Name = "Tech Conference",
                            OrganizationId = 1,
                            StartDate = new DateTime(2023, 9, 20, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            UpdatedAt = new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6448)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6450),
                            CreatedByUserId = 3,
                            Description = "Admire stunning artworks from talented artists.",
                            Details = "This event has no details.",
                            EndDate = new DateTime(2023, 10, 20, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "https://placehold.co/320x320",
                            IsDeleted = false,
                            Location = "City Art Gallery, London",
                            Name = "Art Exhibition",
                            OrganizationId = 1,
                            StartDate = new DateTime(2023, 10, 10, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedAt = new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6451)
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6452),
                            CreatedByUserId = 3,
                            Description = "Run for a cause and support local charities.",
                            Details = "This event has no details.",
                            EndDate = new DateTime(2023, 11, 5, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "https://placehold.co/320x320",
                            IsDeleted = false,
                            Location = "Riverside Park, Chicago",
                            Name = "Charity Run",
                            OrganizationId = 1,
                            StartDate = new DateTime(2023, 11, 5, 9, 30, 0, 0, DateTimeKind.Unspecified),
                            UpdatedAt = new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6453)
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6454),
                            CreatedByUserId = 3,
                            Description = "Get into the holiday spirit with festive vendors.",
                            Details = "This event has no details.",
                            EndDate = new DateTime(2023, 12, 24, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "https://placehold.co/320x320",
                            IsDeleted = false,
                            Location = "Town Square, Paris",
                            Name = "Holiday Market",
                            OrganizationId = 1,
                            StartDate = new DateTime(2023, 12, 15, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedAt = new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6455)
                        });
                });

            modelBuilder.Entity("WeServe.Models.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Banner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Organizations", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressLine1 = "123 Main St.",
                            Banner = "https://placehold.co/640x320",
                            City = "City",
                            CreatedAt = new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6404),
                            Description = "This is the first organization.",
                            Email = "email@me.com",
                            IsDeleted = false,
                            Name = "Organization 1",
                            PhoneNumber = "1234567890",
                            ProfilePicture = "https://placehold.co/320x320",
                            State = "State",
                            UpdatedAt = new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6405),
                            Website = "https://www.google.com",
                            ZipCode = "12345"
                        },
                        new
                        {
                            Id = 2,
                            AddressLine1 = "123 Main St.",
                            Banner = "https://placehold.co/640x320",
                            City = "City",
                            CreatedAt = new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6413),
                            Description = "This is the second organization.",
                            Email = "email@me.com",
                            IsDeleted = false,
                            Name = "Organization 2",
                            PhoneNumber = "1234567890",
                            ProfilePicture = "https://placehold.co/320x320",
                            State = "State",
                            UpdatedAt = new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6414),
                            Website = "https://www.google.com",
                            ZipCode = "12345"
                        });
                });

            modelBuilder.Entity("WeServe.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBanned")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Major")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            Age = 0,
                            Bio = "This user has not set a bio yet.",
                            ConcurrencyStamp = "a0aa8c37-b350-4d87-a5d2-c6378ccd0054",
                            CreatedAt = new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6033),
                            Email = "justin@jkruskie.com",
                            EmailConfirmed = false,
                            FirstName = "Justin",
                            IsBanned = false,
                            IsDeleted = false,
                            LastName = "Kruskie",
                            LockoutEnabled = false,
                            Major = "Undeclared",
                            NormalizedEmail = "JUSTIN@JKRUSKIE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEChYzb3mkPlVn5Tyx/rI21tD1qjPZX0TfsXi2sU1NQgKL/Iv5br8viEgc2zOGmO2Ww==",
                            PhoneNumberConfirmed = false,
                            ProfilePicture = "https://placehold.co/320x320",
                            Role = "Admin",
                            TwoFactorEnabled = false,
                            UpdatedAt = new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6085),
                            Year = "Freshman"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            Age = 0,
                            Bio = "This user has not set a bio yet.",
                            ConcurrencyStamp = "0b54ac36-ca26-4071-b07a-c224664f0db9",
                            CreatedAt = new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6124),
                            Email = "student@weserve.com",
                            EmailConfirmed = false,
                            FirstName = "Student",
                            IsBanned = false,
                            IsDeleted = false,
                            LastName = "Account",
                            LockoutEnabled = false,
                            Major = "Undeclared",
                            NormalizedEmail = "STUDENT@WESERVE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEChYzb3mkPlVn5Tyx/rI21tD1qjPZX0TfsXi2sU1NQgKL/Iv5br8viEgc2zOGmO2Ww==",
                            PhoneNumberConfirmed = false,
                            ProfilePicture = "https://placehold.co/320x320",
                            Role = "Student",
                            TwoFactorEnabled = false,
                            UpdatedAt = new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6126),
                            Year = "Freshman"
                        },
                        new
                        {
                            Id = 3,
                            AccessFailedCount = 0,
                            Age = 0,
                            Bio = "This user has not set a bio yet.",
                            ConcurrencyStamp = "c9a85a1a-2677-445a-90ba-c6851141c38e",
                            CreatedAt = new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6129),
                            Email = "organization@weserve.com",
                            EmailConfirmed = false,
                            FirstName = "Organization",
                            IsBanned = false,
                            IsDeleted = false,
                            LastName = "Account",
                            LockoutEnabled = false,
                            Major = "Undeclared",
                            NormalizedEmail = "ORGANIZATION@WESERVE.COM",
                            OrganizationId = 1,
                            PasswordHash = "AQAAAAIAAYagAAAAEChYzb3mkPlVn5Tyx/rI21tD1qjPZX0TfsXi2sU1NQgKL/Iv5br8viEgc2zOGmO2Ww==",
                            PhoneNumberConfirmed = false,
                            ProfilePicture = "https://placehold.co/320x320",
                            Role = "Organization",
                            TwoFactorEnabled = false,
                            UpdatedAt = new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6130),
                            Year = "Freshman"
                        },
                        new
                        {
                            Id = 4,
                            AccessFailedCount = 0,
                            Age = 0,
                            Bio = "This user has not set a bio yet.",
                            ConcurrencyStamp = "4478b4d7-e14f-4d11-955b-6a0c0599fe69",
                            CreatedAt = new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6134),
                            Email = "moderator@weserve.com",
                            EmailConfirmed = false,
                            FirstName = "Moderator",
                            IsBanned = false,
                            IsDeleted = false,
                            LastName = "Account",
                            LockoutEnabled = false,
                            Major = "Undeclared",
                            NormalizedEmail = "MODERATOR@WESERVE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEChYzb3mkPlVn5Tyx/rI21tD1qjPZX0TfsXi2sU1NQgKL/Iv5br8viEgc2zOGmO2Ww==",
                            PhoneNumberConfirmed = false,
                            ProfilePicture = "https://placehold.co/320x320",
                            Role = "Moderator",
                            TwoFactorEnabled = false,
                            UpdatedAt = new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6135),
                            Year = "Freshman"
                        },
                        new
                        {
                            Id = 5,
                            AccessFailedCount = 0,
                            Age = 0,
                            Bio = "This user has not set a bio yet.",
                            ConcurrencyStamp = "0d62ea1c-2277-452a-a969-e6ffc95cebd1",
                            CreatedAt = new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6138),
                            Email = "admin@weserve.com",
                            EmailConfirmed = false,
                            FirstName = "Admin",
                            IsBanned = false,
                            IsDeleted = false,
                            LastName = "Account",
                            LockoutEnabled = false,
                            Major = "Undeclared",
                            NormalizedEmail = "ADMIN@WESERVE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEChYzb3mkPlVn5Tyx/rI21tD1qjPZX0TfsXi2sU1NQgKL/Iv5br8viEgc2zOGmO2Ww==",
                            PhoneNumberConfirmed = false,
                            ProfilePicture = "https://placehold.co/320x320",
                            Role = "Admin",
                            TwoFactorEnabled = false,
                            UpdatedAt = new DateTime(2023, 8, 2, 12, 30, 17, 402, DateTimeKind.Local).AddTicks(6139),
                            Year = "Freshman"
                        });
                });

            modelBuilder.Entity("WeServe.Models.Event", b =>
                {
                    b.HasOne("WeServe.Models.User", "CreatedByUser")
                        .WithMany("Events")
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WeServe.Models.Organization", "Organization")
                        .WithMany("Events")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedByUser");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("WeServe.Models.User", b =>
                {
                    b.HasOne("WeServe.Models.Organization", "Organization")
                        .WithMany("Users")
                        .HasForeignKey("OrganizationId");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("WeServe.Models.Organization", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("WeServe.Models.User", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
