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