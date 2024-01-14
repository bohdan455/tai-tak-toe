﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240114111712_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.Models.BoardCellValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ColumnIndex")
                        .HasColumnType("int");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RowIndex")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("RowIndex", "ColumnIndex", "RoomId")
                        .IsUnique();

                    b.ToTable("BoardCellValues");
                });

            modelBuilder.Entity("DataAccess.Models.Player", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("PlayerTypeId")
                        .HasColumnType("int");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PlayerTypeId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("DataAccess.Models.PlayerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("PlayerTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Red"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Blue"
                        });
                });

            modelBuilder.Entity("DataAccess.Models.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstPlayerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("NextPlayerMoveId")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("SecondPlayerId")
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("WinnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FirstPlayerId")
                        .IsUnique();

                    b.HasIndex("NextPlayerMoveId")
                        .IsUnique()
                        .HasFilter("[NextPlayerMoveId] IS NOT NULL");

                    b.HasIndex("SecondPlayerId")
                        .IsUnique()
                        .HasFilter("[SecondPlayerId] IS NOT NULL");

                    b.HasIndex("WinnerId")
                        .IsUnique()
                        .HasFilter("[WinnerId] IS NOT NULL");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("DataAccess.Models.WinnerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("WinnerTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Red"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Blue"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Draw"
                        });
                });

            modelBuilder.Entity("DataAccess.Models.BoardCellValue", b =>
                {
                    b.HasOne("DataAccess.Models.Room", "Room")
                        .WithMany("Values")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("DataAccess.Models.Player", b =>
                {
                    b.HasOne("DataAccess.Models.PlayerType", "PlayerType")
                        .WithMany()
                        .HasForeignKey("PlayerTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlayerType");
                });

            modelBuilder.Entity("DataAccess.Models.Room", b =>
                {
                    b.HasOne("DataAccess.Models.Player", "FirstPlayer")
                        .WithOne()
                        .HasForeignKey("DataAccess.Models.Room", "FirstPlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Models.Player", "NextPlayerMove")
                        .WithOne()
                        .HasForeignKey("DataAccess.Models.Room", "NextPlayerMoveId");

                    b.HasOne("DataAccess.Models.Player", "SecondPlayer")
                        .WithOne("Room")
                        .HasForeignKey("DataAccess.Models.Room", "SecondPlayerId");

                    b.HasOne("DataAccess.Models.WinnerType", "Winner")
                        .WithOne()
                        .HasForeignKey("DataAccess.Models.Room", "WinnerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("FirstPlayer");

                    b.Navigation("NextPlayerMove");

                    b.Navigation("SecondPlayer");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("DataAccess.Models.Player", b =>
                {
                    b.Navigation("Room");
                });

            modelBuilder.Entity("DataAccess.Models.Room", b =>
                {
                    b.Navigation("Values");
                });
#pragma warning restore 612, 618
        }
    }
}
