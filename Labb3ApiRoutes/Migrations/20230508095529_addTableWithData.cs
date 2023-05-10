using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb3ApiRoutes.Migrations
{
    /// <inheritdoc />
    public partial class addTableWithData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterestTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InterestDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FK_PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestId);
                    table.ForeignKey(
                        name: "FK_Interests_Persons_FK_PersonId",
                        column: x => x.FK_PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    LinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FK_InterestId = table.Column<int>(type: "int", nullable: false),
                    FK_PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.LinkId);
                    table.ForeignKey(
                        name: "FK_Links_Interests_FK_InterestId",
                        column: x => x.FK_InterestId,
                        principalTable: "Interests",
                        principalColumn: "InterestId");
                    // onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Links_Persons_FK_PersonId",
                        column: x => x.FK_PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId");
                       // onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Anna", "Andersson", "+46701234567" },
                    { 2, "Björn", "Bergström", "+46707654321" },
                    { 3, "Cecilia", "Carlsson", "+46708901234" },
                    { 4, "David", "Dahlberg", "+46707650987" },
                    { 5, "Emma", "Eriksson", "+46703456789" },
                    { 6, "Fredrik", "Fredriksen", "+46701234567" },
                    { 7, "Gustav", "Gustafsson", "+467032165498" },
                    { 8, "Hanna", "Hansson", "+467017534698" },
                    { 9, "Isak", "Isaksson", "+46705576543" },
                    { 10, "Jenny", "Johansson", "+46702876534" },
                    { 11, "Karl", "Karlsson", "+46705678754" },
                    { 12, "Lina", "Lindqvist", "+46709124532" },
                    { 13, "Mikael", "Månsson", "+46704567891" },
                    { 14, "Nina", "Nilsson", "+46707654321" }
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "InterestId", "Created", "FK_PersonId", "InterestDescription", "InterestTitle" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 8, 11, 55, 29, 467, DateTimeKind.Local).AddTicks(3470), 1, "Growing and caring for plants", "Gardening" },
                    { 2, new DateTime(2023, 5, 8, 11, 55, 29, 467, DateTimeKind.Local).AddTicks(3514), 2, "Preparing and cooking meals", "Cooking" },
                    { 3, new DateTime(2023, 5, 8, 11, 55, 29, 467, DateTimeKind.Local).AddTicks(3516), 3, "Enjoying books and literature", "Reading" },
                    { 4, new DateTime(2023, 5, 8, 11, 55, 29, 467, DateTimeKind.Local).AddTicks(3518), 1, "Exploring nature by foot", "Hiking" },
                    { 5, new DateTime(2023, 5, 8, 11, 55, 29, 467, DateTimeKind.Local).AddTicks(3520), 2, "Capturing the world through a lens", "Photography" },
                    { 6, new DateTime(2023, 5, 8, 11, 55, 29, 467, DateTimeKind.Local).AddTicks(3522), 4, "Creating art with pencils, pens, or other media", "Drawing" },
                    { 7, new DateTime(2023, 5, 8, 11, 55, 29, 467, DateTimeKind.Local).AddTicks(3523), 5, "Spending time outdoors and sleeping in a tent", "Camping" },
                    { 8, new DateTime(2023, 5, 8, 11, 55, 29, 467, DateTimeKind.Local).AddTicks(3525), 6, "Practicing physical and mental exercises for relaxation and well-being", "Yoga" },
                    { 9, new DateTime(2023, 5, 8, 11, 55, 29, 467, DateTimeKind.Local).AddTicks(3527), 7, "Enjoying the water and getting exercise", "Swimming" },
                    { 10, new DateTime(2023, 5, 8, 11, 55, 29, 467, DateTimeKind.Local).AddTicks(3529), 8, "Exploring new places and cultures", "Travel" },
                    { 11, new DateTime(2023, 5, 8, 11, 55, 29, 467, DateTimeKind.Local).AddTicks(3531), 9, "Playing and watching athletic games", "Sports" },
                    { 12, new DateTime(2023, 5, 8, 11, 55, 29, 467, DateTimeKind.Local).AddTicks(3533), 10, "Listening to and creating music", "Music" },
                    { 13, new DateTime(2023, 5, 8, 11, 55, 29, 467, DateTimeKind.Local).AddTicks(3535), 11, "Moving to music for fun and exercise", "Dancing" },
                    { 14, new DateTime(2023, 5, 8, 11, 55, 29, 467, DateTimeKind.Local).AddTicks(3536), 12, "Playing video or board games", "Gaming" },
                    { 15, new DateTime(2023, 5, 8, 11, 55, 29, 467, DateTimeKind.Local).AddTicks(3538), 13, "Writing code to create software and websites", "Programming" }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "LinkId", "FK_InterestId", "FK_PersonId", "URL" },
                values: new object[,]
                {
                    { 1, 1, 1, "https://www.gardenersworld.com/" },
                    { 2, 2, 2, "https://www.bbcgoodfood.com/" },
                    { 3, 3, 3, "https://www.goodreads.com/" },
                    { 4, 4, 1, "https://www.alltrails.com/" },
                    { 5, 5, 2, "https://www.nationalgeographic.com/photography/" },
                    { 6, 6, 3, "https://www.healthline.com/nutrition" },
                    { 7, 2, 1, "https://www.nytimes.com/cooking" },
                    { 8, 4, 2, "https://www.worldwildlife.org/" },
                    { 9, 3, 1, "https://www.theguardian.com/books" },
                    { 10, 1, 2, "https://www.thespruce.com/gardening-4127787" },
                    { 11, 4, 3, "https://www.nationalparks.org/connect/blog" },
                    { 12, 5, 1, "https://www.nationalgeographic.com/travel/" },
                    { 13, 2, 3, "https://www.epicurious.com/" },
                    { 14, 3, 2, "https://www.goodreads.com/quotes" },
                    { 15, 5, 3, "https://www.dpreview.com/" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interests_FK_PersonId",
                table: "Interests",
                column: "FK_PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_FK_InterestId",
                table: "Links",
                column: "FK_InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_FK_PersonId",
                table: "Links",
                column: "FK_PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
