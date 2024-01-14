using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WinnerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WinnerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PlayerTypeId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_PlayerTypes_PlayerTypeId",
                        column: x => x.PlayerTypeId,
                        principalTable: "PlayerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstPlayerId = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SecondPlayerId = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    NextPlayerMoveId = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    WinnerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Players_FirstPlayerId",
                        column: x => x.FirstPlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rooms_Players_NextPlayerMoveId",
                        column: x => x.NextPlayerMoveId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rooms_Players_SecondPlayerId",
                        column: x => x.SecondPlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rooms_WinnerTypes_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "WinnerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoardCellValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColumnIndex = table.Column<int>(type: "int", nullable: false),
                    RowIndex = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardCellValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardCellValues_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PlayerTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Red" },
                    { 2, "Blue" }
                });

            migrationBuilder.InsertData(
                table: "WinnerTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Red" },
                    { 2, "Blue" },
                    { 3, "Draw" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardCellValues_RoomId",
                table: "BoardCellValues",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardCellValues_RowIndex_ColumnIndex_RoomId",
                table: "BoardCellValues",
                columns: new[] { "RowIndex", "ColumnIndex", "RoomId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayerTypeId",
                table: "Players",
                column: "PlayerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_FirstPlayerId",
                table: "Rooms",
                column: "FirstPlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_NextPlayerMoveId",
                table: "Rooms",
                column: "NextPlayerMoveId",
                unique: true,
                filter: "[NextPlayerMoveId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_SecondPlayerId",
                table: "Rooms",
                column: "SecondPlayerId",
                unique: true,
                filter: "[SecondPlayerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_WinnerId",
                table: "Rooms",
                column: "WinnerId",
                unique: true,
                filter: "[WinnerId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardCellValues");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "WinnerTypes");

            migrationBuilder.DropTable(
                name: "PlayerTypes");
        }
    }
}
