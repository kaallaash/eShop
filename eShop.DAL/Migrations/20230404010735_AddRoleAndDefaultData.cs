﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.DAL.Migrations
{
    public partial class AddRoleAndDefaultData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Count", "DateCreated", "DateUpdated", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { -3, 1000, new DateTimeOffset(new DateTime(2023, 4, 4, 4, 7, 35, 482, DateTimeKind.Unspecified).AddTicks(5756), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 4, 4, 4, 7, 35, 482, DateTimeKind.Unspecified).AddTicks(5757), new TimeSpan(0, 3, 0, 0, 0)), "Not aluminum", "Nails", 5.99m },
                    { -2, 25, new DateTimeOffset(new DateTime(2023, 4, 4, 4, 7, 35, 482, DateTimeKind.Unspecified).AddTicks(5754), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 4, 4, 4, 7, 35, 482, DateTimeKind.Unspecified).AddTicks(5754), new TimeSpan(0, 3, 0, 0, 0)), "The hammer like my grandfather's", "Hammer", 19.99m },
                    { -1, 10, new DateTimeOffset(new DateTime(2023, 4, 4, 4, 7, 35, 482, DateTimeKind.Unspecified).AddTicks(5749), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 4, 4, 4, 7, 35, 482, DateTimeKind.Unspecified).AddTicks(5751), new TimeSpan(0, 3, 0, 0, 0)), "Electric drill =)", "Drill", 49.99m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Email", "FirstName", "LastName", "Password", "RefreshToken", "RefreshTokenExpiryTime", "Role", "Username" },
                values: new object[] { -1, new DateTimeOffset(new DateTime(2023, 4, 4, 4, 7, 35, 482, DateTimeKind.Unspecified).AddTicks(5634), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 4, 4, 4, 7, 35, 482, DateTimeKind.Unspecified).AddTicks(5660), new TimeSpan(0, 3, 0, 0, 0)), "adminEmail@eShop.com", null, null, "admin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");
        }
    }
}
