using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb3ApiRoutes.Migrations
{
    /// <inheritdoc />
    public partial class addTitleLinkAndEditData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkTitle",
                table: "Links",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 5, 10, 8, 36, 21, 34, DateTimeKind.Local).AddTicks(2482));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 5, 10, 8, 36, 21, 34, DateTimeKind.Local).AddTicks(2522));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 5, 10, 8, 36, 21, 34, DateTimeKind.Local).AddTicks(2524));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2023, 5, 10, 8, 36, 21, 34, DateTimeKind.Local).AddTicks(2526));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2023, 5, 10, 8, 36, 21, 34, DateTimeKind.Local).AddTicks(2562));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2023, 5, 10, 8, 36, 21, 34, DateTimeKind.Local).AddTicks(2564));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2023, 5, 10, 8, 36, 21, 34, DateTimeKind.Local).AddTicks(2566));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2023, 5, 10, 8, 36, 21, 34, DateTimeKind.Local).AddTicks(2568));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2023, 5, 10, 8, 36, 21, 34, DateTimeKind.Local).AddTicks(2569));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2023, 5, 10, 8, 36, 21, 34, DateTimeKind.Local).AddTicks(2571));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2023, 5, 10, 8, 36, 21, 34, DateTimeKind.Local).AddTicks(2573));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 12,
                column: "Created",
                value: new DateTime(2023, 5, 10, 8, 36, 21, 34, DateTimeKind.Local).AddTicks(2574));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 13,
                column: "Created",
                value: new DateTime(2023, 5, 10, 8, 36, 21, 34, DateTimeKind.Local).AddTicks(2576));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 14,
                column: "Created",
                value: new DateTime(2023, 5, 10, 8, 36, 21, 34, DateTimeKind.Local).AddTicks(2578));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 15,
                column: "Created",
                value: new DateTime(2023, 5, 10, 8, 36, 21, 34, DateTimeKind.Local).AddTicks(2579));

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 1,
                column: "LinkTitle",
                value: "Gardens World");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 2,
                column: "LinkTitle",
                value: "BBC good food");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 3,
                column: "LinkTitle",
                value: "Goddreads");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 4,
                column: "LinkTitle",
                value: "Alltrails");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 5,
                column: "LinkTitle",
                value: "National Geo");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 6,
                column: "LinkTitle",
                value: "Health Line");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 7,
                column: "LinkTitle",
                value: "NY times");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 8,
                column: "LinkTitle",
                value: "World Wild Life");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 9,
                column: "LinkTitle",
                value: "The Guardian");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 10,
                column: "LinkTitle",
                value: "The Spruce");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 11,
                column: "LinkTitle",
                value: "National Parks");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 12,
                column: "LinkTitle",
                value: "National Geo Travel");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 13,
                column: "LinkTitle",
                value: "Epicurious");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 14,
                column: "LinkTitle",
                value: "Goodreads");

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 15,
                column: "LinkTitle",
                value: "Dpreview");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkTitle",
                table: "Links");

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 5, 10, 1, 49, 32, 511, DateTimeKind.Local).AddTicks(175));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 5, 10, 1, 49, 32, 511, DateTimeKind.Local).AddTicks(234));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 5, 10, 1, 49, 32, 511, DateTimeKind.Local).AddTicks(236));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2023, 5, 10, 1, 49, 32, 511, DateTimeKind.Local).AddTicks(239));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2023, 5, 10, 1, 49, 32, 511, DateTimeKind.Local).AddTicks(241));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2023, 5, 10, 1, 49, 32, 511, DateTimeKind.Local).AddTicks(243));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2023, 5, 10, 1, 49, 32, 511, DateTimeKind.Local).AddTicks(245));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2023, 5, 10, 1, 49, 32, 511, DateTimeKind.Local).AddTicks(248));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2023, 5, 10, 1, 49, 32, 511, DateTimeKind.Local).AddTicks(250));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2023, 5, 10, 1, 49, 32, 511, DateTimeKind.Local).AddTicks(252));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2023, 5, 10, 1, 49, 32, 511, DateTimeKind.Local).AddTicks(254));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 12,
                column: "Created",
                value: new DateTime(2023, 5, 10, 1, 49, 32, 511, DateTimeKind.Local).AddTicks(256));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 13,
                column: "Created",
                value: new DateTime(2023, 5, 10, 1, 49, 32, 511, DateTimeKind.Local).AddTicks(258));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 14,
                column: "Created",
                value: new DateTime(2023, 5, 10, 1, 49, 32, 511, DateTimeKind.Local).AddTicks(261));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 15,
                column: "Created",
                value: new DateTime(2023, 5, 10, 1, 49, 32, 511, DateTimeKind.Local).AddTicks(263));
        }
    }
}
