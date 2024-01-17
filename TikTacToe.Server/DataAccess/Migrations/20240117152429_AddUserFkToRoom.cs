using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddUserFkToRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Players_FirstPlayerId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Players_SecondPlayerId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_FirstPlayerId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_SecondPlayerId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "FirstPlayerId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "SecondPlayerId",
                table: "Rooms");

            migrationBuilder.AddColumn<Guid>(
                name: "RoomId1",
                table: "Players",
                type: "uniqueidentifier",
                nullable: true);

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
                name: "IX_Players_RoomId1",
                table: "Players",
                column: "RoomId1",
                unique: true,
                filter: "[RoomId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Players_RoomId2",
                table: "Players",
                column: "RoomId2",
                unique: true,
                filter: "[RoomId2] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Rooms_RoomId",
                table: "Players",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Rooms_RoomId1",
                table: "Players",
                column: "RoomId1",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Rooms_RoomId2",
                table: "Players",
                column: "RoomId2",
                principalTable: "Rooms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Rooms_RoomId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Rooms_RoomId1",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Rooms_RoomId2",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_RoomId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_RoomId1",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_RoomId2",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "RoomId1",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "RoomId2",
                table: "Players");

            migrationBuilder.AddColumn<string>(
                name: "FirstPlayerId",
                table: "Rooms",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondPlayerId",
                table: "Rooms",
                type: "nvarchar(255)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_FirstPlayerId",
                table: "Rooms",
                column: "FirstPlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_SecondPlayerId",
                table: "Rooms",
                column: "SecondPlayerId",
                unique: true,
                filter: "[SecondPlayerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Players_FirstPlayerId",
                table: "Rooms",
                column: "FirstPlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Players_SecondPlayerId",
                table: "Rooms",
                column: "SecondPlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }
    }
}
