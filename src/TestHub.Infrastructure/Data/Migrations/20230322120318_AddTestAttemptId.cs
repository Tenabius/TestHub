﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestHub.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTestAttemptId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TestAttempts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestAttempts",
                table: "TestAttempts",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TestAttempts",
                table: "TestAttempts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TestAttempts");
        }
    }
}
