using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationshipBetweenPlayAndRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Rooms_RoomId2",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_RoomId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_RoomId2",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "RoomId2",
                table: "Players");

            migrationBuilder.CreateIndex(
                name: "IX_Players_RoomId",
                table: "Players",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Players_RoomId",
                table: "Players");

            migrationBuilder.AddColumn<Guid>(
                name: "RoomId2",
                table: "Players",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_RoomId",
                table: "Players",
                column: "RoomId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_RoomId2",
                table: "Players",
                column: "RoomId2",
                unique: true,
                filter: "[RoomId2] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Rooms_RoomId2",
                table: "Players",
                column: "RoomId2",
                principalTable: "Rooms",
                principalColumn: "Id");
        }
    }
}
