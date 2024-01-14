using DataAccess.Enum;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Extensions;

public static class ModelBuilderExtensions
{
    public static void PopulateEntities(this ModelBuilder modelBuilder)
    {
        PopulatePlayerTypes(modelBuilder);
        PopulateWinnerTypes(modelBuilder);
    }
    
    public static void ConfigureEntities(this ModelBuilder modelBuilder)
    {
        ConfigurePlayer(modelBuilder);
        ConfigureRoom(modelBuilder);
        ConfigurePlayerType(modelBuilder);
        ConfigureWinnerType(modelBuilder);
        ConfigureBoardCellValue(modelBuilder);
    }

    private static void ConfigureRoom(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Room>().HasKey(r => r.Id);
        
        modelBuilder.Entity<Room>()
            .HasOne(r => r.Winner)
            .WithOne()
            .HasForeignKey<Room>(r => r.WinnerId)
            .OnDelete(DeleteBehavior.Cascade);
            
        modelBuilder.Entity<Room>()
            .HasOne(r => r.FirstPlayer)
            .WithOne()
            .HasForeignKey<Room>(r => r.FirstPlayerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Room>()
            .HasOne(r => r.SecondPlayer)
            .WithOne(r => r.Room)
            .HasForeignKey<Room>(r => r.SecondPlayerId);

        modelBuilder.Entity<Room>()
            .HasOne(r => r.NextPlayerMove)
            .WithOne()
            .HasForeignKey<Room>(r => r.NextPlayerMoveId);
    }

    private static void ConfigurePlayer(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>().HasKey(p => p.Id);

        modelBuilder.Entity<Player>().Property(p => p.Id).HasMaxLength(255);
        
        modelBuilder.Entity<Player>()
            .HasOne(p => p.PlayerType)
            .WithMany()
            .HasForeignKey(p => p.PlayerTypeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
    
    private static void ConfigurePlayerType(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlayerType>().HasKey(pt => pt.Id);
        
        modelBuilder.Entity<PlayerType>().Property(pt => pt.Name).HasMaxLength(255);
    }
    
    private static void ConfigureWinnerType(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WinnerType>().HasKey(wt => wt.Id);
        
        modelBuilder.Entity<WinnerType>().Property(wt => wt.Name).HasMaxLength(255);
    }
    
    private static void ConfigureBoardCellValue(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BoardCellValue>().HasKey(bcv => bcv.Id);

        modelBuilder.Entity<BoardCellValue>().Property(b => b.RowIndex).IsRequired(true);
        modelBuilder.Entity<BoardCellValue>().Property(b => b.ColumnIndex).IsRequired(true);
        
        modelBuilder.Entity<BoardCellValue>()
            .HasIndex(r => new { r.RowIndex, r.ColumnIndex, r.RoomId })
            .IsUnique(true);

        modelBuilder.Entity<BoardCellValue>()
            .HasOne(b => b.Room)
            .WithMany(r => r.Values)
            .HasForeignKey(b => b.RoomId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    private static void PopulatePlayerTypes(ModelBuilder modelBuilder)
    {
        var red = new PlayerType
        {
            Id = PlayerColors.Red,
            Name = "Red",
        };
        var blue = new PlayerType
        {
            Id = PlayerColors.Blue,
            Name = "Blue",
        };
        
        modelBuilder.Entity<PlayerType>().HasData(red, blue);
    }
    
    private static void PopulateWinnerTypes(this ModelBuilder modelBuilder)
    {
        var red = new WinnerType
        {
            Id = PlayerColors.Red,
            Name = "Red",
        };
        var blue = new WinnerType
        {
            Id = PlayerColors.Blue,
            Name = "Blue",
        };
        var draw = new WinnerType
        {
            Id = 3,
            Name = "Draw",
        };
        
        modelBuilder.Entity<WinnerType>().HasData(red, blue, draw);
    }
}