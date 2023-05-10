﻿// <auto-generated />
using System;
using Labb3ApiRoutes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb3ApiRoutes.Migrations
{
    [DbContext(typeof(Labb3ApiRouteDbContext))]
    [Migration("20230509234932_createDb")]
    partial class createDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Labb3ApiRoutes.Models.Interest", b =>
                {
                    b.Property<int>("InterestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InterestId"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("FK_PersonId")
                        .HasColumnType("int");

                    b.Property<string>("InterestDescription")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("InterestTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("InterestId");

                    b.HasIndex("FK_PersonId");

                    b.ToTable("Interests");

                    b.HasData(
                        new
                        {
                            InterestId = 1,
                            Created = new DateTime(2023, 5, 10, 1, 49, 32, 511, DateTimeKind.Local).AddTicks(175),
                            FK_PersonId = 1,
                            InterestDescription = "Growing and caring for plants",
                            InterestTitle = "Gardening"
                        },
                        new
                        {
                            InterestId = 2,
                            Created = new DateTime(2023, 5, 10, 1, 49, 32, 511, DateTimeKind.Local).AddTicks(234),
                            FK_PersonId = 2,
                            InterestDescription = "Preparing and cooking meals",
                            InterestTitle = "Cooking"
                        },
                        new
                        {
                            InterestId = 3,
                            Created = new DateTime(2023, 5, 10, 1, 49, 32, 511, DateTimeKind.Local).AddTicks(236),
                            FK_PersonId = 3,
                            InterestDescription = "Enjoying books and literature",
                            InterestTitle = "Reading"
                        },
                        new
                        {
                            InterestId = 4,
                            Created = new DateTime(2023, 5, 10, 1, 49, 32, 511, DateTimeKind.Local).AddTicks(239),
                            FK_PersonId = 1,
                            InterestDescription = "Exploring nature by foot",
                            InterestTitle = "Hiking"
                        },
                        new
                        {
                            InterestId = 5,
                            Created = new DateTime(2023, 5, 10, 1, 49, 32, 511, DateTimeKind.Local).AddTicks(241),
                            FK_PersonId = 2,
                            InterestDescription = "Capturing the world through a lens",
                            InterestTitle = "Photography"
                        },
                        new
                        {
                            InterestId = 6,
                            Created = new DateTime(2023, 5, 10, 1, 49, 32, 511, DateTimeKind.Local).AddTicks(243),
                            FK_PersonId = 4,
                            InterestDescription = "Creating art with pencils, pens, or other media",
                            InterestTitle = "Drawing"
                        },
                        new
                        {
                            InterestId = 7,
                            Created = new DateTime(2023, 5, 10, 1, 49, 32, 511, DateTimeKind.Local).AddTicks(245),
                            FK_PersonId = 5,
                            InterestDescription = "Spending time outdoors and sleeping in a tent",
                            InterestTitle = "Camping"
                        },
                        new
                        {
                            InterestId = 8,
                            Created = new DateTime(2023, 5, 10, 1, 49, 32, 511, DateTimeKind.Local).AddTicks(248),
                            FK_PersonId = 6,
                            InterestDescription = "Practicing physical and mental exercises for relaxation and well-being",
                            InterestTitle = "Yoga"
                        },
                        new
                        {
                            InterestId = 9,
                            Created = new DateTime(2023, 5, 10, 1, 49, 32, 511, DateTimeKind.Local).AddTicks(250),
                            FK_PersonId = 7,
                            InterestDescription = "Enjoying the water and getting exercise",
                            InterestTitle = "Swimming"
                        },
                        new
                        {
                            InterestId = 10,
                            Created = new DateTime(2023, 5, 10, 1, 49, 32, 511, DateTimeKind.Local).AddTicks(252),
                            FK_PersonId = 8,
                            InterestDescription = "Exploring new places and cultures",
                            InterestTitle = "Travel"
                        },
                        new
                        {
                            InterestId = 11,
                            Created = new DateTime(2023, 5, 10, 1, 49, 32, 511, DateTimeKind.Local).AddTicks(254),
                            FK_PersonId = 9,
                            InterestDescription = "Playing and watching athletic games",
                            InterestTitle = "Sports"
                        },
                        new
                        {
                            InterestId = 12,
                            Created = new DateTime(2023, 5, 10, 1, 49, 32, 511, DateTimeKind.Local).AddTicks(256),
                            FK_PersonId = 10,
                            InterestDescription = "Listening to and creating music",
                            InterestTitle = "Music"
                        },
                        new
                        {
                            InterestId = 13,
                            Created = new DateTime(2023, 5, 10, 1, 49, 32, 511, DateTimeKind.Local).AddTicks(258),
                            FK_PersonId = 11,
                            InterestDescription = "Moving to music for fun and exercise",
                            InterestTitle = "Dancing"
                        },
                        new
                        {
                            InterestId = 14,
                            Created = new DateTime(2023, 5, 10, 1, 49, 32, 511, DateTimeKind.Local).AddTicks(261),
                            FK_PersonId = 12,
                            InterestDescription = "Playing video or board games",
                            InterestTitle = "Gaming"
                        },
                        new
                        {
                            InterestId = 15,
                            Created = new DateTime(2023, 5, 10, 1, 49, 32, 511, DateTimeKind.Local).AddTicks(263),
                            FK_PersonId = 13,
                            InterestDescription = "Writing code to create software and websites",
                            InterestTitle = "Programming"
                        });
                });

            modelBuilder.Entity("Labb3ApiRoutes.Models.Link", b =>
                {
                    b.Property<int>("LinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LinkId"));

                    b.Property<int>("FK_InterestId")
                        .HasColumnType("int");

                    b.Property<int>("FK_PersonId")
                        .HasColumnType("int");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("LinkId");

                    b.HasIndex("FK_InterestId");

                    b.HasIndex("FK_PersonId");

                    b.ToTable("Links");

                    b.HasData(
                        new
                        {
                            LinkId = 1,
                            FK_InterestId = 1,
                            FK_PersonId = 1,
                            URL = "https://www.gardenersworld.com/"
                        },
                        new
                        {
                            LinkId = 2,
                            FK_InterestId = 2,
                            FK_PersonId = 2,
                            URL = "https://www.bbcgoodfood.com/"
                        },
                        new
                        {
                            LinkId = 3,
                            FK_InterestId = 3,
                            FK_PersonId = 3,
                            URL = "https://www.goodreads.com/"
                        },
                        new
                        {
                            LinkId = 4,
                            FK_InterestId = 4,
                            FK_PersonId = 1,
                            URL = "https://www.alltrails.com/"
                        },
                        new
                        {
                            LinkId = 5,
                            FK_InterestId = 5,
                            FK_PersonId = 2,
                            URL = "https://www.nationalgeographic.com/photography/"
                        },
                        new
                        {
                            LinkId = 6,
                            FK_InterestId = 6,
                            FK_PersonId = 3,
                            URL = "https://www.healthline.com/nutrition"
                        },
                        new
                        {
                            LinkId = 7,
                            FK_InterestId = 2,
                            FK_PersonId = 1,
                            URL = "https://www.nytimes.com/cooking"
                        },
                        new
                        {
                            LinkId = 8,
                            FK_InterestId = 4,
                            FK_PersonId = 2,
                            URL = "https://www.worldwildlife.org/"
                        },
                        new
                        {
                            LinkId = 9,
                            FK_InterestId = 3,
                            FK_PersonId = 1,
                            URL = "https://www.theguardian.com/books"
                        },
                        new
                        {
                            LinkId = 10,
                            FK_InterestId = 1,
                            FK_PersonId = 2,
                            URL = "https://www.thespruce.com/gardening-4127787"
                        },
                        new
                        {
                            LinkId = 11,
                            FK_InterestId = 4,
                            FK_PersonId = 3,
                            URL = "https://www.nationalparks.org/connect/blog"
                        },
                        new
                        {
                            LinkId = 12,
                            FK_InterestId = 5,
                            FK_PersonId = 1,
                            URL = "https://www.nationalgeographic.com/travel/"
                        },
                        new
                        {
                            LinkId = 13,
                            FK_InterestId = 2,
                            FK_PersonId = 3,
                            URL = "https://www.epicurious.com/"
                        },
                        new
                        {
                            LinkId = 14,
                            FK_InterestId = 3,
                            FK_PersonId = 2,
                            URL = "https://www.goodreads.com/quotes"
                        },
                        new
                        {
                            LinkId = 15,
                            FK_InterestId = 5,
                            FK_PersonId = 3,
                            URL = "https://www.dpreview.com/"
                        });
                });

            modelBuilder.Entity("Labb3ApiRoutes.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            FirstName = "Anna",
                            LastName = "Andersson",
                            PhoneNumber = "+46701234567"
                        },
                        new
                        {
                            PersonId = 2,
                            FirstName = "Björn",
                            LastName = "Bergström",
                            PhoneNumber = "+46707654321"
                        },
                        new
                        {
                            PersonId = 3,
                            FirstName = "Cecilia",
                            LastName = "Carlsson",
                            PhoneNumber = "+46708901234"
                        },
                        new
                        {
                            PersonId = 4,
                            FirstName = "David",
                            LastName = "Dahlberg",
                            PhoneNumber = "+46707650987"
                        },
                        new
                        {
                            PersonId = 5,
                            FirstName = "Emma",
                            LastName = "Eriksson",
                            PhoneNumber = "+46703456789"
                        },
                        new
                        {
                            PersonId = 6,
                            FirstName = "Fredrik",
                            LastName = "Fredriksen",
                            PhoneNumber = "+46701234567"
                        },
                        new
                        {
                            PersonId = 7,
                            FirstName = "Gustav",
                            LastName = "Gustafsson",
                            PhoneNumber = "+467032165498"
                        },
                        new
                        {
                            PersonId = 8,
                            FirstName = "Hanna",
                            LastName = "Hansson",
                            PhoneNumber = "+467017534698"
                        },
                        new
                        {
                            PersonId = 9,
                            FirstName = "Isak",
                            LastName = "Isaksson",
                            PhoneNumber = "+46705576543"
                        },
                        new
                        {
                            PersonId = 10,
                            FirstName = "Jenny",
                            LastName = "Johansson",
                            PhoneNumber = "+46702876534"
                        },
                        new
                        {
                            PersonId = 11,
                            FirstName = "Karl",
                            LastName = "Karlsson",
                            PhoneNumber = "+46705678754"
                        },
                        new
                        {
                            PersonId = 12,
                            FirstName = "Lina",
                            LastName = "Lindqvist",
                            PhoneNumber = "+46709124532"
                        },
                        new
                        {
                            PersonId = 13,
                            FirstName = "Mikael",
                            LastName = "Månsson",
                            PhoneNumber = "+46704567891"
                        },
                        new
                        {
                            PersonId = 14,
                            FirstName = "Nina",
                            LastName = "Nilsson",
                            PhoneNumber = "+46707654321"
                        });
                });

            modelBuilder.Entity("Labb3ApiRoutes.Models.Interest", b =>
                {
                    b.HasOne("Labb3ApiRoutes.Models.Person", "Persons")
                        .WithMany("Interests")
                        .HasForeignKey("FK_PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persons");
                });

            modelBuilder.Entity("Labb3ApiRoutes.Models.Link", b =>
                {
                    b.HasOne("Labb3ApiRoutes.Models.Interest", "Interests")
                        .WithMany("Links")
                        .HasForeignKey("FK_InterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb3ApiRoutes.Models.Person", "Persons")
                        .WithMany("Links")
                        .HasForeignKey("FK_PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interests");

                    b.Navigation("Persons");
                });

            modelBuilder.Entity("Labb3ApiRoutes.Models.Interest", b =>
                {
                    b.Navigation("Links");
                });

            modelBuilder.Entity("Labb3ApiRoutes.Models.Person", b =>
                {
                    b.Navigation("Interests");

                    b.Navigation("Links");
                });
#pragma warning restore 612, 618
        }
    }
}
