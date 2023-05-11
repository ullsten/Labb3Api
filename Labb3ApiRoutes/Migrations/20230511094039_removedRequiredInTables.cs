using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb3ApiRoutes.Migrations
{
    /// <inheritdoc />
    public partial class removedRequiredInTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 5, 11, 11, 40, 39, 152, DateTimeKind.Local).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 5, 11, 11, 40, 39, 152, DateTimeKind.Local).AddTicks(4951));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 5, 11, 11, 40, 39, 152, DateTimeKind.Local).AddTicks(4953));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2023, 5, 11, 11, 40, 39, 152, DateTimeKind.Local).AddTicks(4954));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2023, 5, 11, 11, 40, 39, 152, DateTimeKind.Local).AddTicks(4956));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2023, 5, 11, 11, 40, 39, 152, DateTimeKind.Local).AddTicks(4959));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2023, 5, 11, 11, 40, 39, 152, DateTimeKind.Local).AddTicks(4961));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2023, 5, 11, 11, 40, 39, 152, DateTimeKind.Local).AddTicks(4963));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2023, 5, 11, 11, 40, 39, 152, DateTimeKind.Local).AddTicks(4965));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2023, 5, 11, 11, 40, 39, 152, DateTimeKind.Local).AddTicks(4966));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2023, 5, 11, 11, 40, 39, 152, DateTimeKind.Local).AddTicks(4968));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 12,
                column: "Created",
                value: new DateTime(2023, 5, 11, 11, 40, 39, 152, DateTimeKind.Local).AddTicks(4970));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 13,
                column: "Created",
                value: new DateTime(2023, 5, 11, 11, 40, 39, 152, DateTimeKind.Local).AddTicks(4972));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 14,
                column: "Created",
                value: new DateTime(2023, 5, 11, 11, 40, 39, 152, DateTimeKind.Local).AddTicks(4974));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 15,
                column: "Created",
                value: new DateTime(2023, 5, 11, 11, 40, 39, 152, DateTimeKind.Local).AddTicks(4975));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 5, 11, 11, 37, 54, 674, DateTimeKind.Local).AddTicks(8818));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 5, 11, 11, 37, 54, 674, DateTimeKind.Local).AddTicks(8862));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 5, 11, 11, 37, 54, 674, DateTimeKind.Local).AddTicks(8864));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2023, 5, 11, 11, 37, 54, 674, DateTimeKind.Local).AddTicks(8866));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2023, 5, 11, 11, 37, 54, 674, DateTimeKind.Local).AddTicks(8867));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2023, 5, 11, 11, 37, 54, 674, DateTimeKind.Local).AddTicks(8869));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2023, 5, 11, 11, 37, 54, 674, DateTimeKind.Local).AddTicks(8871));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2023, 5, 11, 11, 37, 54, 674, DateTimeKind.Local).AddTicks(8872));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2023, 5, 11, 11, 37, 54, 674, DateTimeKind.Local).AddTicks(8874));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2023, 5, 11, 11, 37, 54, 674, DateTimeKind.Local).AddTicks(8876));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2023, 5, 11, 11, 37, 54, 674, DateTimeKind.Local).AddTicks(8878));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 12,
                column: "Created",
                value: new DateTime(2023, 5, 11, 11, 37, 54, 674, DateTimeKind.Local).AddTicks(8879));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 13,
                column: "Created",
                value: new DateTime(2023, 5, 11, 11, 37, 54, 674, DateTimeKind.Local).AddTicks(8881));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 14,
                column: "Created",
                value: new DateTime(2023, 5, 11, 11, 37, 54, 674, DateTimeKind.Local).AddTicks(8883));

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestId",
                keyValue: 15,
                column: "Created",
                value: new DateTime(2023, 5, 11, 11, 37, 54, 674, DateTimeKind.Local).AddTicks(8884));
        }
    }
}
